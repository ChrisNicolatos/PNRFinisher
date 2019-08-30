Option Strict On
Option Explicit On
Public Class AirlinePointsCollection
    Inherits System.Collections.ObjectModel.Collection(Of String)
    Private mPrevCustID As Integer = 0
    Private mPrevAirlineCode As String = ""
    Private mPrevGDSCode As EnumGDSCode = EnumGDSCode.Unknown
    Public Sub New()
        mPrevCustID = 0
        mPrevAirlineCode=""
        mPrevGDSCode=EnumGDSCode.Unknown
    End Sub
    Friend Sub Load(ByVal pCustID As Integer, ByVal pAirlineCode As String, ByVal GDSCode As EnumGDSCode, ByVal pBackOffice As Integer)

        If pCustID <> mPrevCustID Or pAirlineCode <> mPrevAirlineCode Or GDSCode <> mPrevGDSCode Then

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
            pobjComm.Parameters.Add("@CustID", SqlDbType.Int).Value = pCustID
            pobjComm.Parameters.Add("@AirlineCode", SqlDbType.NVarChar, 10).Value = pAirlineCode
            pobjComm.CommandText = SQLCommandText(pBackOffice, GDSCode)
            pobjReader = pobjComm.ExecuteReader
            With pobjReader
                Do While .Read
                    MyBase.Add(CStr(.Item("Remarks")))
                Loop
                .Close()
            End With
            pobjConn.Close()
            mPrevCustID = pCustID
            mPrevAirlineCode = pAirlineCode
            mPrevGDSCode = GDSCode
        End If

    End Sub
    Private Shared ReadOnly Property SQLCommandText(ByVal pBackOffice As Integer, ByVal pGDSCode As EnumGDSCode) As String
        Get
            Select Case pBackOffice
                Case 1
                    If pGDSCode = EnumGDSCode.Amadeus Then
                        Return "SELECT TravelForceCosmos.dbo.FrequentFlyerCards.Remarks 
                                    FROM TravelForceCosmos.dbo.FrequentFlyerCards  
                                    	LEFT OUTER JOIN TravelForceCosmos.dbo.Airlines  
                                    		ON TravelForceCosmos.dbo.FrequentFlyerCards.AirlineID = TravelForceCosmos.dbo.Airlines.Id 
                                    WHERE (TravelForceCosmos.dbo.FrequentFlyerCards.TFEntityID = @CustID)  
                                    			AND (TravelForceCosmos.dbo.Airlines.IATACode = @AirlineCode)"
                    ElseIf pGDSCode = EnumGDSCode.Galileo Then
                        Return "SELECT FrequentFlyerCards_1G.ff1GRemark  AS Remarks 
                                         FROM TravelForceCosmos.dbo.FrequentFlyerCards 
                                         LEFT OUTER JOIN TravelForceCosmos.dbo.Airlines 
                                         ON TravelForceCosmos.dbo.FrequentFlyerCards.AirlineID = TravelForceCosmos.dbo.Airlines.Id 
                                         LEFT JOIN [EUDC-CLSSQL14.ATPI.PRI].AmadeusReports.dbo.FrequentFlyerCards_1G 
                                         ON FrequentFlyerCards.Remarks = FrequentFlyerCards_1G.ffTFCRemark 
                                         WHERE (TravelForceCosmos.dbo.FrequentFlyerCards.TFEntityID = @CustID)  
                                         AND (TravelForceCosmos.dbo.Airlines.IATACode = @AirlineCode)"
                    End If
                Case 2

                    If pGDSCode = EnumGDSCode.Amadeus Then
                        Return "SELECT pnfAmadeusEntry AS Remarks 
                                     From AmadeusReports.dbo.PNRFinisherCorporateDeals 
                                     Where pnfClientId_fkey = @CustID And pnfAirlineCode = @AirlineCode And ISNULL(pnfAmadeusEntry, '') <>''  "
                    ElseIf pGDSCode = EnumGDSCode.Galileo Then
                        Return "SELECT pnfGalileoEntry AS Remarks 
                                     FROM AmadeusReports.dbo.PNRFinisherCorporateDeals 
                                     WHERE pnfClientId_fkey = @CustID AND pnfAirlineCode = @AirlineCode AND ISNULL(pnfGalileoEntry, '') <>'' "
                    End If
            End Select
            Return ""
        End Get
    End Property
End Class
