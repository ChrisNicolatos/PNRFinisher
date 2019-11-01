Option Strict On
Option Explicit On
Public Class IHAirportItem

    Public ReadOnly Property Code As String
    Public ReadOnly Property CodeType As String
    Public ReadOnly Property CityCode As String
    Public ReadOnly Property Name As String
    Public Sub New(ByVal pCode As String, ByVal pCodeType As String, ByVal pCityCode As String, ByVal pName As String)
        Code = pCode.Trim
        CodeType = pCodeType.Trim
        CityCode = pCityCode.Trim
        Name = pName.Trim
    End Sub
    Public Overrides Function ToString() As String
        Return Code & " " & CodeType & " " & Name
    End Function

End Class
