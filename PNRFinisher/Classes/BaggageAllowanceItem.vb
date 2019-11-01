Option Strict On
Option Explicit On
Public Class BaggageAllowanceItem
    Public ReadOnly Property Key As String = ""
    Public ReadOnly Property BaggageAllowance As String = ""
    Public Sub New(ByVal pOrigin As String, ByVal pDestination As String, ByVal pAirline As String, ByVal pFlightNumber As String _
                         , ByVal pClassofService As String, ByVal pDepartureDate As String, ByVal pDepartureTime As String, ByVal pBaggageAllowance As String)
        BaggageAllowance = pBaggageAllowance
        Key = pOrigin & "|" & pDestination & "|" & pAirline & "|" & pFlightNumber & "|" & pClassofService & "|" & pDepartureDate & "|" & pDepartureTime
    End Sub

End Class
