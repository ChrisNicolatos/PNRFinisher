Option Strict On
Option Explicit On
Public Class PhoneNumbersItem
    Public ReadOnly Property ElementNo As Integer
    Public ReadOnly Property CityCode As String
    Public ReadOnly Property PhoneType As String
    Public ReadOnly Property PhoneNumber As String
    Public Sub New(ByVal pElementNo As Integer, ByVal pCityCode As String, ByVal pPhoneType As String, ByVal pPhoneNumber As String)
        ElementNo = pElementNo
        CityCode = pCityCode
        PhoneType = pPhoneType
        PhoneNumber = pPhoneNumber
    End Sub
End Class
