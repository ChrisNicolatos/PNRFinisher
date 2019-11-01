Option Strict On
Option Explicit On
Public Class CloseOffEntriesItem
    Public ReadOnly Property CloseOffEntry As String
    Public Sub New(ByVal pCloseOffEntry As String)
        CloseOffEntry = MySettings.ConvertGDSValue(pCloseOffEntry)
    End Sub
End Class