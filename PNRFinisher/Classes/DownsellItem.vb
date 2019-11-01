Option Strict On
Option Explicit On
Public Class DownsellItem
    Public ReadOnly Property OwnPNR As Integer
    Public ReadOnly Property PCC As String
    Public ReadOnly Property GDS As String
    Public ReadOnly Property PNR As String
    Public ReadOnly Property UserGdsId As String
    Public ReadOnly Property DateLogged As Date
    Public ReadOnly Property DownsellDecision As String
    Public ReadOnly Property ClientCode As String
    Public ReadOnly Property ClientName As String
    Public ReadOnly Property OpsGroup As String
    Public ReadOnly Property AlertForDownsell As String
    Public ReadOnly Property PaxName As String
    Public ReadOnly Property Itinerary As String
    Public ReadOnly Property Total As Decimal
    Public ReadOnly Property DownsellTotal As Decimal
    Public ReadOnly Property FareBasis As String
    Public ReadOnly Property DownsellFareBasis As String
    Public ReadOnly Property GDSCommand As String
    Public Sub New(ByVal pOwnPNR As Integer, ByVal pPCC As String, ByVal pGDS As String, ByVal pPNR As String _
                 , ByVal pUserGdsId As String, ByVal pDateLogged As Date, ByVal pDownsellDecision As String _
                 , ByVal pClientCode As String, ByVal pClientName As String, ByVal pAlertForDownsell As String, ByVal pPaxName As String, ByVal pItinerary As String _
                 , ByVal pTotal As Decimal, ByVal pDownsellTotal As Decimal, ByVal pFareBasis As String, ByVal pDownsellFareBasis As String _
                 , ByVal pGDSCommand As String, ByVal pOpsGroup As String)
        OwnPNR = pOwnPNR
        PCC = pPCC
        GDS = pGDS
        PNR = pPNR
        UserGdsId = pUserGdsId
        DateLogged = pDateLogged
        DownsellDecision = pDownsellDecision
        ClientCode = pClientCode
        ClientName = pClientName
        AlertForDownsell = pAlertForDownsell
        PaxName = pPaxName
        Itinerary = pItinerary
        Total = pTotal
        DownsellTotal = pDownsellTotal
        FareBasis = pFareBasis
        DownsellFareBasis = pDownsellFareBasis
        GDSCommand = pGDSCommand
        OpsGroup = pOpsGroup
    End Sub

End Class
