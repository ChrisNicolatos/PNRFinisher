Option Strict On
Option Explicit On
Public Class TicketElementItem
    Public ReadOnly Property ElementNo As Integer
    Public ReadOnly Property PCC As String
    Public ReadOnly Property ActionDateTime As Date
    Public ReadOnly Property Remark As String
    Public Sub New(ByVal pElementNo As Integer, ByVal pPCC As String, ByVal pActionDateTime As Date, ByVal pRemark As String)
        ElementNo = pElementNo
        PCC = pPCC
        ActionDateTime = pActionDateTime
        Remark = pRemark
    End Sub
End Class