Option Strict On
Option Explicit On
Public Class AirlinePointsCollection
    Inherits System.Collections.ObjectModel.Collection(Of String)
#Region "CONSTANTS"
    Private Const SQL_TF_AMADEUS As String = "If(OBJECT_ID('tempdb..#TempClients') Is Not Null)
Begin
Drop Table #TempClients
End

SELECT TravelForceCosmos.dbo.FrequentFlyerCards.Remarks, '' AS VesselName 
INTO #TempClients
                                    FROM TravelForceCosmos.dbo.FrequentFlyerCards  
                                    	LEFT OUTER JOIN TravelForceCosmos.dbo.Airlines  
                                    		ON TravelForceCosmos.dbo.FrequentFlyerCards.AirlineID = TravelForceCosmos.dbo.Airlines.Id 
                                    WHERE (TravelForceCosmos.dbo.FrequentFlyerCards.TFEntityID = @ClientID)  
                                    			AND (TravelForceCosmos.dbo.Airlines.IATACode = @AirlineCode)

UNION

SELECT  pnfAmadeusEntry AS Remarks, pnfVesselName AS VesselName    

FROM [EUDC-CLSSQL14.ATPI.PRI].AmadeusReports.dbo.PNRFinisherCorporateDeals                                      
WHERE pnfBackOffice_fkey = 1 AND pnfClientId_fkey = @ClientID AND pnfAirlineCode = @AirlineCode AND ISNULL(pnfAmadeusEntry, '') <>''
      AND (pnfVesselName IS NULL OR pnfVesselName = @VesselName)    


SELECT TOP 1 * FROM #TempClients	       
ORDER BY VesselName DESC

If(OBJECT_ID('tempdb..#TempClients') Is Not Null)
Begin
Drop Table #TempClients
End"
    Private Const SQL_TF_GALILEO As String = "If(OBJECT_ID('tempdb..#TempClients') Is Not Null)
Begin
Drop Table #TempClients
End

SELECT FrequentFlyerCards_1G.ff1GRemark  AS Remarks, '' AS VesselName
INTO #TempClients
                                         FROM TravelForceCosmos.dbo.FrequentFlyerCards 
                                         LEFT OUTER JOIN TravelForceCosmos.dbo.Airlines 
                                         ON TravelForceCosmos.dbo.FrequentFlyerCards.AirlineID = TravelForceCosmos.dbo.Airlines.Id 
                                         LEFT JOIN [EUDC-CLSSQL14.ATPI.PRI].AmadeusReports.dbo.FrequentFlyerCards_1G 
                                         ON FrequentFlyerCards.Remarks = FrequentFlyerCards_1G.ffTFCRemark 
                                         WHERE (TravelForceCosmos.dbo.FrequentFlyerCards.TFEntityID = @ClientID)  
                                         AND (TravelForceCosmos.dbo.Airlines.IATACode = @AirlineCode)

UNION

SELECT  pnfGalileoEntry AS Remarks, pnfVesselName AS VesselName    

FROM [EUDC-CLSSQL14.ATPI.PRI].AmadeusReports.dbo.PNRFinisherCorporateDeals                                      
WHERE pnfBackOffice_fkey = 1 AND pnfClientId_fkey = @ClientID AND pnfAirlineCode = @AirlineCode AND ISNULL(pnfAmadeusEntry, '') <>''
      AND (pnfVesselName IS NULL OR pnfVesselName = @VesselName)    										 

SELECT TOP 1 *
FROM #TempClients
ORDER BY VesselName DESC

If(OBJECT_ID('tempdb..#TempClients') Is Not Null)
Begin
Drop Table #TempClients
End"
    Private Const SQL_DISCO_AMADEUS As String = "SELECT TOP 1 pnfAmadeusEntry AS Remarks 
                                     FROM AmadeusReports.dbo.PNRFinisherCorporateDeals 
                                     WHERE pnfClientId_fkey = @ClientID AND pnfAirlineCode = @AirlineCode AND ISNULL(pnfAmadeusEntry, '') <>''
                                     AND (pnfVesselName IS NULL OR pnfVesselName = @VesselName)   
                                     ORDER BY pnfVesselName DESC"
    Private Const SQL_DISCO_GALILEO As String = "SELECT TOP 1 pnfGalileoEntry AS Remarks 
                                     FROM AmadeusReports.dbo.PNRFinisherCorporateDeals 
                                     WHERE pnfClientId_fkey = @ClientID AND pnfAirlineCode = @AirlineCode AND ISNULL(pnfGalileoEntry, '') <>'' 
                                     AND (pnfVesselName IS NULL OR pnfVesselName = @VesselName)   
                                     ORDER BY pnfVesselName DESC"
#End Region
    Private mPreviousClientID As Integer = 0
    Private mPreviousVesselName As String = Nothing
    Private mPreviousAirlineCode As String = ""
    Private mPreviousGDSCode As EnumGDSCode = EnumGDSCode.Unknown
    Public Sub New()
        mPreviousClientID = 0
        mPreviousAirlineCode = ""
        mPreviousGDSCode = EnumGDSCode.Unknown
    End Sub
    Public Sub Load(ByVal pClientID As Integer, ByVal pVesselName As String, ByVal pAirlineCode As String, ByVal GDSCode As EnumGDSCode, ByVal pBackOffice As Integer)

        If pClientID <> mPreviousClientID Or pAirlineCode <> mPreviousAirlineCode Or GDSCode <> mPreviousGDSCode Or (mPreviousVesselName Is Nothing OrElse mPreviousVesselName <> pVesselName) Then

            Dim pobjConn As New SqlClient.SqlConnection
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            MyBase.Clear()

            If pBackOffice = 1 Then
                pobjConn = New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            ElseIf pBackOffice = 2 Then
                pobjConn = New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Else
                Throw New System.ArgumentOutOfRangeException("GDSCode", "AirlinePointsCollection.Load()" & vbCrLf & "Back Office is not selected")
            End If
            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand
            pobjComm.CommandType = CommandType.Text
            pobjComm.Parameters.Add("@ClientID", SqlDbType.Int).Value = pClientID
            pobjComm.Parameters.Add("@AirlineCode", SqlDbType.NVarChar, 10).Value = pAirlineCode
            pobjComm.Parameters.Add("@VesselName", SqlDbType.NVarChar, 254).Value = pVesselName
            pobjComm.CommandText = SQLCommandText(pBackOffice, GDSCode)
            pobjReader = pobjComm.ExecuteReader
            With pobjReader
                Do While .Read
                    MyBase.Add(CStr(.Item("Remarks")))
                Loop
                .Close()
            End With
            pobjConn.Close()
            mPreviousClientID = pClientID
            mPreviousAirlineCode = pAirlineCode
            mPreviousVesselName = pVesselName
            mPreviousGDSCode = GDSCode
        End If

    End Sub
    Private Shared ReadOnly Property SQLCommandText(ByVal pBackOffice As Integer, ByVal pGDSCode As EnumGDSCode) As String
        Get
            Select Case pBackOffice
                Case 1
                    If pGDSCode = EnumGDSCode.Amadeus Then
                        Return SQL_TF_AMADEUS
                    ElseIf pGDSCode = EnumGDSCode.Galileo Then
                        Return SQL_TF_GALILEO
                    End If
                Case 2
                    If pGDSCode = EnumGDSCode.Amadeus Then
                        Return SQL_DISCO_AMADEUS
                    ElseIf pGDSCode = EnumGDSCode.Galileo Then
                        Return SQL_DISCO_GALILEO
                    End If
            End Select
            Return ""
        End Get
    End Property
End Class
