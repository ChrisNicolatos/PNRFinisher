Option Strict On
Option Explicit On
Public Class IHAirportCollection
    Inherits Collections.Generic.Dictionary(Of String, IHAirportItem)

    Public Function Load(ByVal AirportCode As String, ByVal AirportOnly As Boolean) As Collections.Generic.Dictionary(Of String, IHAirportItem)

        Dim pCityCode As String = ""

        Load = New Collections.Generic.Dictionary(Of String, IHAirportItem)

        If MyBase.ContainsKey(AirportCode) Then
            pCityCode = MyBase.Item(AirportCode).CityCode
        Else
            If AirportCode = "..." Then
                Dim pItem As New IHAirportItem
                pItem.SetValues("...", "A", "...", "ANY AIRPORT")
                MyBase.Add(pItem.Code, pItem)
            Else
                ReadDB(AirportCode)
            End If
        End If
        If MyBase.ContainsKey(AirportCode) Then
            pCityCode = MyBase.Item(AirportCode).CityCode
        End If

        For Each pItem As IHAirportItem In MyBase.Values
            If (AirportOnly And pItem.CodeType = "A" And pItem.Code = AirportCode) Or (Not AirportOnly And (pItem.Code = AirportCode Or pItem.CityCode = pCityCode)) Then
                Load.Add(pItem.Code, pItem)
            End If
        Next

    End Function
    Private Sub ReadDB(ByVal AirportCode As String)
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@AirportCode", SqlDbType.Char, 3).Value = AirportCode
            .CommandText = "
                            USE AmadeusReports
                            SELECT AirportCode, 'A' AS CodeType, zzCities.cityCode
                                 , coalesce(airportShortname, [airportName]) + CASE WHEN coalesce(airportShortname, [airportName]) =  zzCities.cityName THEN '' ELSE ', ' + zzCities.cityName END + ',' + zzCountries.countryName AS Name
                              FROM [AmadeusReports].[dbo].[zzAirports]
                              LEFT JOIN AmadeusReports.dbo.zzCities
                              ON airportCityCode_FK = zzCities.cityCode
                              LEFT JOIN AmadeusReports.dbo.zzCountries
                              ON zzCities.cityCountryCode_FK = zzCountries.countryCode
                              WHERE airportType = 'A' AND (AirportCode = @AirportCode OR zzCities.cityCode = @AirportCode OR airportCityCode_FK = (SELECT ZZA.airportCityCode_FK FROM zzAirports ZZA WHERE ZZA.AirportCode = @AirportCode))
 
                              UNION 

                              SELECT zzCities.cityCode AS AirportCode, 'C' AS CodeType, zzCities.cityCode AS cityCode, zzCities.cityName AS Name
                              FROM AmadeusReports.dbo.zzCities
                              WHERE (zzCities.cityCode = @AirportCode OR zzCities.cityCode IN (SELECT ZZA.airportCityCode_FK FROM zzAirports ZZA WHERE ZZA.AirportCode = @AirportCode))
                                    AND (SELECT COUNT(*) FROM [AmadeusReports].[dbo].[zzAirports] WHERE AirportCode IN (SELECT ZZA.airportCityCode_FK FROM zzAirports ZZA WHERE ZZA.AirportCode = @AirportCode)) = 0
                              ORDER BY CodeType DESC, AirportCode
"
            pobjReader = .ExecuteReader
        End With
        With pobjReader
            Do While .Read
                Dim pItem As New IHAirportItem
                pItem.SetValues(CStr(.Item("AirportCode")), CStr(.Item("CodeType")), CStr(.Item("cityCode")), CStr(.Item("Name")))
                If Not MyBase.ContainsKey(pItem.Code) Then
                    MyBase.Add(pItem.Code, pItem)
                End If
            Loop
        End With
        pobjConn.Close()
    End Sub

End Class
