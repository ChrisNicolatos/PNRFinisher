Option Strict On
Option Explicit On
Public Class CloseOffEntriesItem

    Dim mEntry As String

    Public ReadOnly Property CloseOffEntry As String
        Get
            Return MySettings.ConvertGDSValue(mEntry)
        End Get
    End Property
    Public Sub SetValues(ByVal CloseOffEntry As String)
        mEntry = CloseOffEntry
    End Sub
End Class