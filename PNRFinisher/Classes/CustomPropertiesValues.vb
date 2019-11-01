Option Strict On
Option Explicit On
Public Class CustomPropertiesValues
    Public ReadOnly Property Id As String
    Public ReadOnly Property Code As String
    Public ReadOnly Property Value As String
    Public Sub New(ByVal pId As String, ByVal pCode As String, ByVal pValue As String)
        Id = pId
        Code = pCode
        Value = pValue
    End Sub
    Public Overrides Function ToString() As String
        Return (Code & " " & Value).Trim
    End Function
End Class
