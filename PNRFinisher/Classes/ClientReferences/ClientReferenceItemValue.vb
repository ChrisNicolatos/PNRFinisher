Option Strict On
Option Explicit On
Public Class ClientReferenceItemValue
    Public ReadOnly Property Id As String
    Public ReadOnly Property Code As String
    Public ReadOnly Property Value As String
    Public Sub New(ByVal pId As String, ByVal pCode As String, ByVal pValue As String)
        Id = pId.Trim.ToUpper
        Code = pCode.Trim.ToUpper
        Value = pValue.Trim.ToUpper
    End Sub
    Public Sub New(ByVal pItem As ClientReferenceItemValue)
        Me.Id = pItem.Id
        Me.Code = pItem.Code
        Me.Value = pItem.Value
    End Sub
    Public Overrides Function ToString() As String
        If Code <> Value Then
            Return (Code & " " & Value).Trim
        Else
            Return Code.Trim
        End If

    End Function
End Class
