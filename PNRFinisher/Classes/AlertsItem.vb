Option Strict On
Option Explicit On
Public Class AlertsItem
    Public ReadOnly Property BackOfficeID As Integer
    Public ReadOnly Property ClientCode As String
    Public ReadOnly Property AlertForFinisher As String
    Public ReadOnly Property OriginCountry As String
    Public ReadOnly Property DestinationCountry As String
    Public ReadOnly Property Airline As String
    Public ReadOnly Property AmadeusQueue As String
    Public ReadOnly Property GalileoQueue As String
    Public ReadOnly Property AlertForDownsell As String
    Public Sub New(ByVal pBackOfficeID As Integer, ByVal pClientCode As String, ByVal pAlertForFinisher As String, ByVal pOriginCountry As String, ByVal pDestinationCountry As String, ByVal pAirline As String, ByVal pAmadeusQueue As String, ByVal pGalileoQueue As String, ByVal pAlertForDownsell As String)
        BackOfficeID = pBackOfficeID
        ClientCode = pClientCode
        AlertForFinisher = pAlertForFinisher
        OriginCountry = pOriginCountry
        DestinationCountry = pDestinationCountry
        Airline = pAirline
        AmadeusQueue = pAmadeusQueue
        GalileoQueue = pGalileoQueue
        AlertForDownsell = pAlertForDownsell
    End Sub
End Class
