Option Strict On
Option Explicit On
Public Class CustomerItem
    ' SQL for Travel Force
    Private Const SQL1 As String = " SELECT TFEntities.Id 
                                ,ISNULL(TFEntities.Code, '') AS Code
                                ,ISNULL(TFEntities.Name, '') AS Name 
                                ,ISNULL(TFEntities.Logo, '') AS Logo
                                ,ISNULL(TFEntityCategories.TFEntityKindLT, 0) AS TFEntityKindLT
                                ,ISNULL(DealCodes.Code, '') AS GalileoTrackingCode 
                                ,ISNULL((SELECT Description 
							    FROM  [TravelForceCosmos].[dbo].TFEntityTags 
							    LEFT JOIN [TravelForceCosmos].[dbo].Tags 
								ON TFEntityTags.TagId = Tags.Id
								WHERE TFEntityTags.TFEntityId = TFEntities.Id AND Tags.TagGroupId = 149), '') AS OpsGroup
                             , (SELECT COUNT(*) AS CTCCount
								   FROM [EUDC-CLSSQL14.atpi.pri].AmadeusReports.dbo.PaxCTC  
								   WHERE ctcBackOffice_fkey=1 
								     AND ctcClientId_fkey=TFEntities.Id 
									 AND ISNULL(ctcVesselName, '') = '' 
									 AND ISNULL(ctcPassengerFirstName, '') = '' 
									 AND ISNULL(ctcPassengerLastName, '') = '') AS CTCCount
                                FROM [TravelForceCosmos].[dbo].[TFEntities] 
                                LEFT JOIN [TravelForceCosmos].[dbo].[TFEntityCategories] 
                                ON TFEntities.CategoryID = TFEntityCategories.Id 
                                LEFT JOIN TravelForceCosmos.dbo.DealCodes 
                                ON DealCodes.ClientID=TFEntities.Id And DealCodes.AirlineID=3352 
                                WHERE TFEntities.IsClient = 1  
                                AND TFEntities.CanHaveCT = 1 
                                AND TFEntities.IsActive = 1 
                                AND TFEntities.Code = @ClientCode "
    ' SQL for Discovery
    Private Const SQL2 As String = " SELECT ISNULL([Account_Id], 0) As Id 
                            ,ISNULL([Account_Abbriviation], '') AS Code 
                            ,ISNULL([Account_Name], '') AS Name 
                            ,ISNULL([Account_Name], '') AS Logo 
                            ,526 AS TFEntityKindLT 
                            ,'' AS GalileoTrackingCode 
                            ,'' AS OpsGroup
                             , (SELECT COUNT(*) AS CTCCount
								   FROM [EUDC-CLSSQL14.atpi.pri].AmadeusReports.dbo.PaxCTC  
								   WHERE ctcBackOffice_fkey=2
								     AND ctcClientId_fkey=[Account_Id] 
									 AND ISNULL(ctcVesselName, '') = '' 
									 AND ISNULL(ctcPassengerFirstName, '') = '' 
									 AND ISNULL(ctcPassengerLastName, '') = '') AS CTCCount

                            FROM [Disco_Instone_EU].[dbo].[Company] 
                            WHERE Account_Abbriviation = @ClientCode "

    Private mobjCustomProperties As New CustomPropertiesCollection
    Private mflgCustomProperties As Boolean
    Private mobjAlerts As New AlertsCollection
    Public Overrides Function ToString() As String
        If CTCCount > 0 Then
            Return Code & " " & Logo & " ==>"
        Else
            Return Code & " " & Logo
        End If
    End Function
    Public ReadOnly Property BackOffice As Integer = 0
    Public ReadOnly Property ID As Integer = 0
    Public ReadOnly Property Code As String = ""
    Public ReadOnly Property Name As String = ""
    Public ReadOnly Property Logo As String = ""
    ' TFEntityKind (from DB table [TravelForceCosmos].[dbo].[LookupTable])
    ' 404 = Other
    ' 405 = Individual
    ' 406 = Corporate
    ' 526 = Shipping Co
    ' 527 = Travel Agency
    Public ReadOnly Property EntityKindLT As Integer = 0
    Public ReadOnly Property HasVessels As Boolean = False
    Public ReadOnly Property HasDepartments As Boolean = False
    Public ReadOnly Property OpsGroup As String = ""
    Public ReadOnly Property CTCCount As Integer = 0
    Public ReadOnly Property AlertForFinisher As String = ""
    Public ReadOnly Property AlertForDownsell As String = ""
    Public ReadOnly Property GalileoTrackingCode As String = ""
    Public ReadOnly Property CustomerProperties As CustomPropertiesCollection
        Get
            If Not mflgCustomProperties Then
                mobjCustomProperties.Load(ID, BackOffice)
                mflgCustomProperties = True
            End If
            Return mobjCustomProperties
        End Get
    End Property
    Friend Sub New(ByVal pID As Integer, ByVal pCode As String, ByVal pName As String, ByVal pLogo As String, ByVal pEntityKindLT As Integer, ByVal pAlertForFinisher As String, ByVal pAlertForDownsell As String, ByVal pGalileoTrackingCode As String, ByVal pOpsGroup As String, ByVal pCTCCount As Integer, ByVal pBackOffice As Integer)
        ID = pID
        Code = pCode
        Name = pName.ToUpper
        Logo = pLogo.ToUpper
        EntityKindLT = pEntityKindLT
        AlertForFinisher = pAlertForFinisher.Trim
        AlertForDownsell = pAlertForDownsell.Trim
        GalileoTrackingCode = pGalileoTrackingCode
        OpsGroup = pOpsGroup
        CTCCount = pCTCCount
        BackOffice = pBackOffice
        Select Case pEntityKindLT
            Case 526, 527
                HasDepartments = True
                HasVessels = True
            Case Else
                HasDepartments = False
                HasVessels = False
        End Select
        mflgCustomProperties = False
    End Sub
    Public Sub New(ByVal pCode As String, ByVal pBackOffice As Integer)

        If pBackOffice <> 1 And pBackOffice <> 2 Then
            Throw New Exception("CustomerItem.Load() - BackOffice not defined")
        End If
        mobjAlerts.Load()

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@ClientCode", SqlDbType.NVarChar, 20).Value = pCode
            If pBackOffice = 1 Then
                .CommandText = SQL1
            ElseIf pBackOffice = 2 Then
                .CommandText = SQL2
            End If
            pobjReader = .ExecuteReader
        End With
        With pobjReader
            If pobjReader.Read Then
                BackOffice = pBackOffice
                ID = CInt(.Item("Id"))
                Code = CStr(.Item("Code"))
                Name = CStr(.Item("Name")).ToUpper
                Logo = CStr(.Item("Logo")).ToUpper
                EntityKindLT = CInt(.Item("TFEntityKindLT"))
                AlertForFinisher = mobjAlerts.AlertForFinisher(pBackOffice, Code).Trim
                AlertForDownsell = mobjAlerts.AlertForDownsell(pBackOffice, Code).Trim
                GalileoTrackingCode = CStr(.Item("GalileoTrackingCode"))
                OpsGroup = CStr(.Item("OpsGroup"))
                CTCCount = CInt(.Item("CTCCount"))
                Select Case EntityKindLT
                    Case 526, 527
                        HasDepartments = True
                        HasVessels = True
                    Case Else
                        HasDepartments = False
                        HasVessels = False
                End Select
                mflgCustomProperties = False
                .Close()
            End If
        End With
        pobjConn.Close()
    End Sub
End Class
