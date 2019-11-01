Option Strict On
Option Explicit On
Public Class BaggageAllowanceItem
    Private Structure ClassProps
        Dim Origin As String
        Dim Destination As String
        Dim Airline As String
        Dim FlightNumber As String
        Dim ClassofService As String
        Dim DepartureDate As String
        Dim DepartureTime As String
        Dim BaggageAllowance As String
    End Structure
    Private mudtProps As ClassProps
    Public ReadOnly Property Key As String
        Get
            With mudtProps
                Return .Origin & "|" & .Destination & "|" & .Airline & "|" & .FlightNumber & "|" & .ClassofService & "|" & .DepartureDate & "|" & .DepartureTime
            End With
        End Get
    End Property
    Public ReadOnly Property BaggageAllowance As String
        Get
            Return mudtProps.BaggageAllowance
        End Get
    End Property
    Public Sub SetValues(ByVal pOrigin As String, ByVal pDestination As String, ByVal pAirline As String, ByVal pFlightNumber As String _
                         , ByVal pClassofService As String, ByVal pDepartureDate As String, ByVal pDepartureTime As String, ByVal pBaggageAllowance As String)
        With mudtProps
            .Origin = pOrigin
            .Destination = pDestination
            .Airline = pAirline
            .FlightNumber = pFlightNumber
            .ClassofService = pClassofService
            .DepartureDate = pDepartureDate
            .DepartureTime = pDepartureTime
            .BaggageAllowance = pBaggageAllowance
        End With
    End Sub

End Class
