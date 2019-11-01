Option Strict On
Option Explicit On
Public Class ReferenceItem
    Public ReadOnly Property Code As String
    Public ReadOnly Property Description As String
    Public Sub New(ByVal pCode As String, ByVal pDescription As String)
        Code = pCode
        Description = pDescription
    End Sub
    Public Overrides Function ToString() As String
        Return Code & If(Description = "", "", " - " & Description)
    End Function
End Class
