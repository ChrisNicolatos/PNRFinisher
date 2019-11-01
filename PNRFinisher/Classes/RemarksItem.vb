Option Strict On
Option Explicit On
Public Class RemarksItem
    Public Overrides Function ToString() As String
        Return Title
    End Function
    Public ReadOnly Property Id As Integer
    Public ReadOnly Property Title As String
    Public ReadOnly Property Remark As String
    Public ReadOnly Property InUse As Boolean
    Public Sub New(ByVal pId As Integer, ByVal pTitle As String, ByVal pRemark As String, ByVal pInUse As Boolean)
        Id = pId
        Title = pTitle
        Remark = pRemark
        InUse = pInUse
    End Sub
End Class
