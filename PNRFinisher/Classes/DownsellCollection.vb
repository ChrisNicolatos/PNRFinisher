Option Strict On
Option Explicit On
Public Class DownsellCollection
    Inherits Collections.Generic.Dictionary(Of Integer, DownsellItem)
    Private mstrPCC As String = ""
    Private mstrUserID As String = ""
    Private mAmadeusLastCheck As Date = Date.MinValue
    Private mGalileoLastCheck As Date = Date.MinValue
    Public Function CountNonVerified(ByVal PCC As String, ByVal UserID As String) As Integer
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand

        CountNonVerified = 0
        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        mstrPCC = PCC
        mstrUserID = UserID

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@PCC", SqlDbType.NVarChar, 9).Value = PCC
            .Parameters.Add("@UserID", SqlDbType.NVarChar, 20).Value = UserID

            .CommandText = "SELECT COUNT(*)
            FROM AmadeusReports.dbo.DownsellPNRLog
            WHERE ISNULL(doVerifiedbyUser, 0) = 0 AND (doPCC + '|' + doUserGdsId in (
            SELECT  pfPCC + '|' + pfUser AS UserKey
            FROM AmadeusReports.dbo.PNRFinisherUserName
            LEFT JOIN AmadeusReports.dbo.PNRFinisherUsers
            ON pfnID = pfUsername_fk
            WHERE pfnUserTeamleaderID_fk = (SELECT PU.pfUserName_fk FROM AmadeusReports.dbo.PNRFinisherUsers PU WHERE PU.pfPCC = @PCC AND PU.pfUser = @UserID)
            OR pfUserName_fk IN (SELECT PU.pfUserName_fk FROM AmadeusReports.dbo.PNRFinisherUsers PU WHERE PU.pfPCC = @PCC AND PU.pfUser = @UserID))
            OR (SELECT pfnIsAdministrator
            FROM AmadeusReports.dbo.PNRFinisherUsers
            LEFT JOIN AmadeusReports.dbo.PNRFinisherUserName
            ON pfUserName_fk = pfnID
            WHERE pfPCC = @PCC AND pfUser = @UserID)=1)"
            CountNonVerified = CInt(.ExecuteScalar)
        End With
        pobjConn.Close()
    End Function
    Public Sub Load(ByVal PCC As String, ByVal UserID As String)

        MyBase.Clear()
        If PCC <> "" And UserID <> "" Then
            mstrPCC = PCC
            mstrUserID = UserID

            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As DownsellItem
            Dim pID As Integer

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand
            MyBase.Clear()
            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@PCC", SqlDbType.NVarChar, 9).Value = PCC
                .Parameters.Add("@UserID", SqlDbType.NVarChar, 20).Value = UserID
                .Parameters.Add("@Verified", SqlDbType.Bit).Value = 0
                .CommandText = "If(OBJECT_ID('tempdb..#TempClients') Is Not Null)
Begin
Drop Table #TempClients
End
SELECT DISTINCT doClientCode AS ClientCode, TFEntities.Name AS ClientName
, ISNULL((SELECT [Description]
							    FROM  [Eudc-clssql15\DBS1].[TravelForceCosmos].[dbo].TFEntityTags 
							    LEFT JOIN [Eudc-clssql15\DBS1].[TravelForceCosmos].[dbo].Tags 
								ON TFEntityTags.TagId = Tags.Id
								WHERE TFEntityTags.TFEntityId = TFEntities.Id AND Tags.TagGroupId = 149), '') AS OpsGroup
,ISNULL(pnaAlertForDownsell, '') AS AlertForDownsell

INTO #TempClients
FROM AmadeusReports.dbo.DownsellPNRLog
LEFT JOIN [Eudc-clssql15\DBS1].[TravelForceCosmos].[dbo].[TFEntities]
ON doClientCode=TFEntities.Code
LEFT JOIN [AmadeusReports].[dbo].[PNRFinisherAlerts]
ON pnaClientCode = doClientCode
WHERE TFEntities.Id IS NOT NULL AND  ISNULL(doVerifiedbyUser, 0) = @Verified

SELECT DISTINCT 
1 AS OwnPNR
,doPCC
,doGDS
,doPNR
,doUserGdsId
,doDateLogged
,doDownsellDecision
,doClientCode
,ISNULL(ClientName, '') AS ClientName
,ISNULL(OpsGroup, '') AS OpsGroup
,ISNULL(AlertForDownsell, '') AS AlertForDownsell
,doPaxName
,doItinerary
,doTotal
,doDownsellTotal
,doFareBasis
,doDownsellFareBasis
,doGDSCommand
FROM AmadeusReports.dbo.DownsellPNRLog
LEFT JOIN #TempClients
ON doClientCode = #TempClients.ClientCode
WHERE ISNULL(doVerifiedbyUser, 0) = @Verified
AND doPCC + '|' + doUserGdsId IN (SELECT pfPCC + '|' + pfUser AS UserKey
                                  FROM AmadeusReports.dbo.PNRFinisherUsers
                                  WHERE pfUserName_fk IN (SELECT PU.pfUserName_fk 
								                          FROM AmadeusReports.dbo.PNRFinisherUsers PU 
														  WHERE PU.pfPCC = @PCC AND PU.pfUser = @UserID))
UNION
SELECT DISTINCT 
2 AS OwnPNR
,doPCC
,doGDS
,doPNR
,doUserGdsId
,doDateLogged
,doDownsellDecision
,doClientCode
,ISNULL(ClientName, '') AS ClientName
,ISNULL(OpsGroup, '') AS OpsGroup
,ISNULL(AlertForDownsell, '') AS AlertForDownsell
,doPaxName
,doItinerary
,doTotal
,doDownsellTotal
,doFareBasis
,doDownsellFareBasis
,doGDSCommand
FROM AmadeusReports.dbo.DownsellPNRLog
LEFT JOIN #TempClients
ON doClientCode = #TempClients.ClientCode
WHERE ISNULL(doVerifiedbyUser, 0) = @Verified
AND (doPCC + '|' + doUserGdsId in (SELECT  pfPCC + '|' + pfUser AS UserKey
                                   FROM AmadeusReports.dbo.PNRFinisherUserName
                                   LEFT JOIN AmadeusReports.dbo.PNRFinisherUsers
                                   ON pfnID = pfUsername_fk
                                   WHERE ISNULL(pfnUserTeamleaderID_fk,0) = (SELECT ISNULL(PU.pfUserName_fk,1) 
								                                             FROM AmadeusReports.dbo.PNRFinisherUsers PU 
																             WHERE PU.pfPCC = @PCC AND PU.pfUser = @UserID))

    OR (OpsGroup in (SELECT  pfnOperationsGroup AS UserKey
                    FROM AmadeusReports.dbo.PNRFinisherUserName
                    LEFT JOIN AmadeusReports.dbo.PNRFinisherUsers
                    ON pfnID = pfUsername_fk
                    WHERE ISNULL(pfnUserTeamleaderID_fk,0) = (SELECT ISNULL(PU.pfUserName_fk,1) 
								                                             FROM AmadeusReports.dbo.PNRFinisherUsers PU 
																             WHERE PU.pfPCC = @PCC AND PU.pfUser = @UserID)))

	OR (SELECT pfnIsAdministrator
		FROM AmadeusReports.dbo.PNRFinisherUsers
		LEFT JOIN AmadeusReports.dbo.PNRFinisherUserName
		ON pfUserName_fk = pfnID
		WHERE pfPCC = @PCC AND pfUser = @UserID)=1)
ORDER BY OwnPNR,doPCC,doUserGdsId

If(OBJECT_ID('tempdb..#TempClients') Is Not Null)
Begin
Drop Table #TempClients
End"
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pID += 1
                    pobjClass = New DownsellItem(CInt(.Item("OwnPNR")), CStr(.Item("doPCC")), CStr(.Item("doGDS")), CStr(.Item("doPNR")) _
                          , CStr(.Item("doUserGdsId")), CDate(.Item("doDateLogged")), CStr(.Item("doDownsellDecision")), CStr(.Item("doClientCode")) _
                          , CStr(.Item("ClientName")), CStr(.Item("AlertForDownsell")), CStr(.Item("doPaxName")), CStr(.Item("doItinerary")), CDec(.Item("doTotal")), CDec(.Item("doDownsellTotal")) _
                          , CStr(.Item("doFareBasis")), CStr(.Item("doDownsellFareBasis")), CStr(.Item("doGDSCommand")), CStr(.Item("OpsGroup")))
                    MyBase.Add(pID, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()
        End If
        FindLastUpdates()
    End Sub
    Public Sub IgnorePNR(ByVal PCC As String, ByVal PNR As String, ByVal VerificationReason As String)
        If mstrPCC <> "" And mstrUserID <> "" Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand
            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand
            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@PCC", SqlDbType.NVarChar, 20).Value = PCC
                .Parameters.Add("@PNR", SqlDbType.NVarChar, 6).Value = PNR
                .Parameters.Add("@UserId", SqlDbType.NVarChar, 30).Value = mstrPCC & "-" & mstrUserID
                .Parameters.Add("@Date", SqlDbType.DateTime).Value = Now
                .Parameters.Add("@VerificationReason", SqlDbType.NVarChar, 50).Value = VerificationReason
                .CommandText = "UPDATE AmadeusReports.dbo.DownsellPNRLog 
                            SET doVerifiedByUser = 1, doVerifiedUserId = @UserId, doVerifiedDate = @Date, doVerificationReason=@VerificationReason
                            WHERE doPCC = @PCC AND doPNR = @PNR AND ISNULL(doVerifiedbyUser,0) = 0"
                .ExecuteNonQuery()
            End With
            pobjConn.Close()
            Load(mstrPCC, mstrUserID)
        End If
    End Sub
    Private Sub FindLastUpdates()
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        mAmadeusLastCheck = Date.MinValue
        mGalileoLastCheck = Date.MinValue
        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = "SELECT TOP 1 doDateLogged 
                            FROM AmadeusReports.dbo.DownsellPNRLog
                            WHERE doPCC = 'START' AND doGDS = '1A'
                            ORDER BY doId DESC"
            pobjReader = .ExecuteReader
            If pobjReader.Read Then
                mAmadeusLastCheck = CDate(pobjReader.Item("doDateLogged"))
            End If
            pobjReader.Close()
            .CommandText = "SELECT TOP 1 doDateLogged 
                            FROM AmadeusReports.dbo.DownsellPNRLog
                            WHERE doPCC = 'START' AND doGDS = '1G'
                            ORDER BY doId DESC"
            pobjReader = .ExecuteReader
            If pobjReader.Read Then
                mGalileoLastCheck = CDate(pobjReader.Item("doDateLogged"))
            End If
        End With
        pobjConn.Close()
    End Sub
    Public ReadOnly Property AmadeusLastCheck As Date
        Get
            Return mAmadeusLastCheck
        End Get
    End Property
    Public ReadOnly Property GalileoLastCheck As Date
        Get
            Return mGalileoLastCheck
        End Get
    End Property
End Class
