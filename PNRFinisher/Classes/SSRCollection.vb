Option Strict On
Option Explicit On
Public Class SSRCollection
    Inherits Collections.Generic.Dictionary(Of Integer, SSRitem)
    Public Sub AddItem(ByVal pElementNo As Integer, ByVal pSSRType As String, ByVal pSSRCode As String, ByVal pCarrierCode As String _
                         , ByVal pStatusCode As String, ByVal pText As String, ByVal pLastName As String, ByVal pFirstname As String _
                         , ByVal pDateOfBirth As Date, ByVal pPassportNumber As String)
        Dim pobjClass As New SSRitem(pElementNo, pSSRType, pSSRCode, pCarrierCode _
                         , pStatusCode, pText, pLastName, pFirstname _
                         , pDateOfBirth, pPassportNumber)
        MyBase.Add(pobjClass.ElementNo, pobjClass)
    End Sub
End Class
