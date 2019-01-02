Option Strict On
Option Explicit On
Public Class PhoneNumbersCollection
    Inherits Collections.Generic.Dictionary(Of Integer, PhoneNumbersItem)
    Public Sub AddItem(ByVal pElementNo As Integer, ByVal pCityCode As String, ByVal pPhoneType As String, ByVal pPhoneNumber As String)
        Dim pobjClass As New PhoneNumbersItem
        pobjClass.SetValues(pElementNo, pCityCode, pPhoneType, pPhoneNumber)
        MyBase.Add(pobjClass.ElementNo, pobjClass)
    End Sub
End Class