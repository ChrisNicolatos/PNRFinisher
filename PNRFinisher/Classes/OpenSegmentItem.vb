Option Strict On
Option Explicit On
Public Class OpenSegmentItem
    Private Structure ClassProps
        Dim ElementNo As Integer
        Dim SegmentType As String
        Dim RemarkType As String
        Dim RemarkDate As Date
        Dim Remark As String
    End Structure
    Private mudtProps As ClassProps
    Public ReadOnly Property ElementNo As Integer
        Get
            Return mudtProps.ElementNo
        End Get
    End Property
    Public ReadOnly Property SegmentType As String
        Get
            Return mudtProps.SegmentType
        End Get
    End Property
    Public ReadOnly Property RemarkType As String
        Get
            Return mudtProps.RemarkType
        End Get
    End Property
    Public ReadOnly Property RemarkDate As Date
        Get
            Return mudtProps.RemarkDate
        End Get
    End Property
    Public ReadOnly Property Remark As String
        Get
            Return mudtProps.Remark
        End Get
    End Property
    Public Sub SetValues(ByVal pElementNo As Integer, ByVal pSegmentType As String, ByVal pRemarkType As String, ByVal pRemarkDate As Date, ByVal pRemark As String)
        With mudtProps
            .ElementNo = pElementNo
            .SegmentType = pSegmentType
            .RemarkType = pRemarkType
            .RemarkDate = pRemarkDate
            .Remark = pRemark
        End With
    End Sub
End Class