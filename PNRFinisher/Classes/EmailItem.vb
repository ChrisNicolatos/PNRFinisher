Option Strict On
Option Explicit On
Public Class EmailItem
    Public ReadOnly Property ElementNo As Integer
    Public ReadOnly Property EmailAddress As String
    Public ReadOnly Property EmailComment As String
    Friend Sub New(ByVal pElementNo As Integer, ByVal pEmailAddress As String, ByVal pEmailComment As String)
        ElementNo = pElementNo
        EmailAddress = pEmailAddress
        EmailComment = pEmailComment
    End Sub
End Class