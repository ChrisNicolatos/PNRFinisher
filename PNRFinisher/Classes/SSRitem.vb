Option Strict On
Option Explicit On
Public Class SSRitem
    Public ReadOnly Property ElementNo As Integer
    Public ReadOnly Property SSRType As String
    Public ReadOnly Property SSRCode As String
    Public ReadOnly Property CarrierCode As String
    Public ReadOnly Property StatusCode As String
    Public ReadOnly Property Text As String
    Public ReadOnly Property LastName As String
    Public ReadOnly Property FirstName As String
    Public ReadOnly Property DateOfBirth As Date
    Public ReadOnly Property PassportNumber As String
    Public Sub New(ByVal pElementNo As Integer, ByVal pSSRType As String, ByVal pSSRCode As String, ByVal pCarrierCode As String _
                         , ByVal pStatusCode As String, ByVal pText As String, ByVal pLastName As String, ByVal pFirstname As String _
                         , ByVal pDateOfBirth As Date, ByVal pPassportNumber As String)
        ElementNo = pElementNo
        SSRType = pSSRType
        SSRCode = pSSRCode
        CarrierCode = pCarrierCode
        StatusCode = pStatusCode
        Text = pText
        LastName = pLastName
        FirstName = pFirstname
        DateOfBirth = pDateOfBirth
        PassportNumber = pPassportNumber
    End Sub
End Class
