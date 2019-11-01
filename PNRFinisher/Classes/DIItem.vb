Option Strict On
Option Explicit On
Public Class DIItem
    Public ReadOnly Property ElementNo As Integer = 0
    Public ReadOnly Property Category As String = ""
    Public ReadOnly Property Remark As String = ""
    Friend Sub New(ByVal pElementNo As Integer, ByVal pCategory As String, ByVal pRemark As String)
        ElementNo = pElementNo
        Select Case pCategory
            Case "FREE TEXT"
                Category = "FT"
            Case Else
                Category = pCategory
        End Select
        Remark = pRemark
    End Sub
End Class
