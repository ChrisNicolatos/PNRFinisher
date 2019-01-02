Option Strict On
Option Explicit On
Public Class OpenSegmentCollection
    Inherits Collections.Generic.Dictionary(Of Integer, OpenSegmentItem)
    Public Sub AddItem(ByVal pElementNo As Integer, ByVal pSegmentType As String, ByVal pRemarkType As String, ByVal pRemarkDate As Date, ByVal pRemark As String)
        Dim pobjClass As New OpenSegmentItem
        pobjClass.SetValues(pElementNo, pSegmentType, pRemarkType, pRemarkDate, pRemark)
        MyBase.Add(pobjClass.ElementNo, pobjClass)
    End Sub
End Class