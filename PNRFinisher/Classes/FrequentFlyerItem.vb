Option Strict On
Option Explicit On
Public Class FrequentFlyerItem
    Public ReadOnly Property PaxName As String
    Public ReadOnly Property Airline As String
    Public ReadOnly Property FrequentTravelerNo As String
    Public ReadOnly Property CrossAccrual As String
    Public Sub New(ByVal pPaxName As String, ByVal pAirline As String, ByVal pFrequentTravelerNo As String, ByVal pCrossAccrual As String)
        PaxName = pPaxName
        Airline = pAirline
        FrequentTravelerNo = pFrequentTravelerNo
        CrossAccrual = pCrossAccrual
    End Sub
End Class