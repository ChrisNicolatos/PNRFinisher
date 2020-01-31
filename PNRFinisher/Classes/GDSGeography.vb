Option Strict On
Option Explicit On
Public Class GDSGeography
    Public ReadOnly Property AirportCode As String = ""
    Public ReadOnly Property AirportName As String = ""
    Public ReadOnly Property AirportShortName As String = ""
    Public ReadOnly Property CityName As String = ""
    Public ReadOnly Property CountryName As String = ""
    Public ReadOnly Property CountryCode As String = ""

    Public Sub New(ByVal AirportCode As String)
        If AirportCode <> "" Then
            Me.AirportCode = AirportCode
        AirportName = Airport.CityAirportName(AirportCode)
        CityName = Airport.CityName(AirportCode)
        AirportShortName = Airport.AirportShortname(AirportCode)
        CountryName = Airport.CountryName(AirportCode)
        CountryCode = Airport.CountryCode(AirportCode)
            If AirportShortName = "" Then
                AirportShortName = CityName.Trim
            End If
        End If
    End Sub
End Class
