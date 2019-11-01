Option Strict On
Option Explicit On
Public Class ConditionalGDSEntryItem

    Public ReadOnly Property ConditionalEntry1A As String
    Public ReadOnly Property ConditionalEntry1G As String
    Friend Sub New(ByVal p1AEntry As String, ByVal p1GEntry As String)
        ConditionalEntry1A = MySettings.ConvertGDSValue(p1AEntry)
        ConditionalEntry1G = MySettings.ConvertGDSValue(p1GEntry)
    End Sub
End Class
