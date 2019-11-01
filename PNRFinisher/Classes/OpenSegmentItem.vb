Option Strict On
Option Explicit On
Public Class OpenSegmentItem
    Public ReadOnly Property ElementNo As Integer
    Public ReadOnly Property SegmentType As String
    Public ReadOnly Property RemarkType As String
    Public ReadOnly Property RemarkDate As Date
    Public ReadOnly Property Remark As String
    Public Sub New(ByVal pElementNo As Integer, ByVal pSegmentType As String, ByVal pRemarkType As String, ByVal pRemarkDate As Date, ByVal pRemark As String)
        ElementNo = pElementNo
        SegmentType = pSegmentType
        RemarkType = pRemarkType
        RemarkDate = pRemarkDate
        Remark = pRemark
    End Sub
End Class