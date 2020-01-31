Option Strict On
Option Explicit On
Public Class BaggageAllowanceCollection
    Inherits Collections.Generic.Dictionary(Of String, BaggageAllowanceItem)
    Public Sub AddItem(ByVal pLine1 As String, ByVal pLine2 As String)

        Dim pItem As New BaggageAllowanceItem
        Dim pOrigin As String = ""
        Dim pDestination As String = ""
        Dim pAirline As String = ""
        Dim pFlightNumber As String = ""
        Dim pClassOfService As String = ""
        Dim pDepDate As String = ""
        Dim pDepTime As String = ""
        Dim pBaggageAllowance As String = ""

        If pLine1.Length > 60 And pLine2.Length > 6 Then
            pOrigin = pLine1.Substring(5, 3).Trim
            pDestination = pLine2.Substring(5, 3).Trim
            pAirline = pLine1.Substring(9, 2).Trim
            pFlightNumber = pLine1.Substring(12, 4).Trim
            pClassOfService = pLine1.Substring(17, 1).Trim
            pDepDate = pLine1.Substring(19, 5).Trim
            pDepTime = pLine1.Substring(25, 4).Trim
            pBaggageAllowance = pLine1.Substring(60).Trim
            pItem.SetValues(pOrigin, pDestination, pAirline, pFlightNumber, pClassOfService, pDepDate, pDepTime, pBaggageAllowance)
            If Not MyBase.ContainsKey(pItem.Key) Then
                MyBase.Add(pItem.Key, pItem)
            End If

        End If

    End Sub
    Public Sub AddItem(ByVal pSegment As GDSSegItem, ByVal pBaggageAllowance As String)
        Try
            Dim pItem As New BaggageAllowanceItem
            With pSegment
                pItem.SetValues(.Origin.AirportCode, .Destination.AirportCode, .Airline, .FlightNo, .ClassOfService, .Departure.DateIATA, .Departure.TimeShort, pBaggageAllowance)
                If Not MyBase.ContainsKey(pItem.Key) Then
                    MyBase.Add(pItem.Key, pItem)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
    Public ReadOnly Property BaggageAllowance(ByVal Origin As String, ByVal Destination As String, ByVal Airline As String, ByVal FlightNumber As String, ByVal ClassOfService As String, ByVal DepDate As String, ByVal DepTime As String) As String
        Get
            Dim pTemp As New BaggageAllowanceItem
            pTemp.SetValues(Origin, Destination, Airline, FlightNumber, ClassOfService, DepDate, DepTime, "")
            If MyBase.ContainsKey(pTemp.Key) Then
                Return MyBase.Item(pTemp.Key).BaggageAllowance
            Else
                Return ""
            End If
        End Get
    End Property
End Class
