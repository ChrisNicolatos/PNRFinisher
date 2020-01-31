Option Strict On
Option Explicit On
Public Class ClientFromDB
    Private mobjAlerts As New AlertsCollection
    Public ReadOnly Property Client As Client
    Public Sub New(ByVal pCode As String, ByVal pBackOffice As Integer)

        mobjAlerts.Load()

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@ClientCode", SqlDbType.NVarChar, 20).Value = pCode
            .CommandText = PrepareClientSelectCommand(pBackOffice)
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            If pobjReader.Read Then
                Client = New Client(pBackOffice, pobjReader)
                'Client = New ClientItem(CInt(.Item("Id")), CStr(.Item("Code")), CStr(.Item("Name")), CStr(.Item("Logo")), CInt(.Item("TFEntityKindLT")), mobjAlerts.AlertForFinisher(pBackOffice, CStr(.Item("Code"))), mobjAlerts.AlertForDownsell(pBackOffice, CStr(.Item("Code"))), CStr(.Item("GalileoTrackingCode")), CStr(.Item("OpsGroup")), CInt(.Item("CTCCount")), pBackOffice)
                .Close()
            End If
        End With
        pobjConn.Close()
    End Sub

    Private Shared ReadOnly Property PrepareClientSelectCommand(ByVal pBackOffice As Integer) As String
        Get

            Select Case pBackOffice
                Case 1 ' Travel Force
                    Return " SELECT TFEntities.Id 
                                ,TFEntities.Code
                                ,TFEntities.Name 
                                ,TFEntities.Logo
                                ,TFEntityCategories.TFEntityKindLT 
                                ,ISNULL(DealCodes.Code, '') AS GalileoTrackingCode 
                                , ISNULL((SELECT Description 
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
                Case 2 ' Discovery
                    Return " Select [Account_Id] As Id 
                            ,[Account_Abbriviation] AS Code 
                            ,[Account_Name] AS Name 
                            ,[Account_Name] AS Logo 
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

                            From [Disco_Instone_EU].[dbo].[Company] 
                            Where Account_Abbriviation = @ClientCode "
                Case Else
                    Return ""
            End Select
        End Get
    End Property
End Class
