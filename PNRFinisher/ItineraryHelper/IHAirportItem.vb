Option Strict On
Option Explicit On
Public Class IHAirportItem
    Private Structure ClassProps
        Dim Code As String
        Dim CodeType As String
        Dim CityCode As String
        Dim Name As String
    End Structure
    Private mudtProps As ClassProps
    Public Overrides Function ToString() As String
        Return mudtProps.Code & " " & mudtProps.CodeType & " " & mudtProps.Name
    End Function
    Public ReadOnly Property Code As String
        Get
            Return mudtProps.Code
        End Get
    End Property
    Public ReadOnly Property CodeType As String
        Get
            Return mudtProps.CodeType
        End Get
    End Property
    Public ReadOnly Property CityCode As String
        Get
            Return mudtProps.CityCode
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return mudtProps.Name
        End Get
    End Property
    Public Sub SetValues(ByVal pCode As String, ByVal pCodeType As String, ByVal pCityCode As String, ByVal pName As String)
        With mudtProps
            .Code = pCode.Trim
            .CodeType = pCodeType.Trim
            .CityCode = pCityCode.Trim
            .Name = pName.Trim
        End With
    End Sub
End Class
