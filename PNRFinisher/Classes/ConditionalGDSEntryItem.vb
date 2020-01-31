Option Strict On
Option Explicit On
Public Class ConditionalGDSEntryItem

    Dim m1AEntry As String
    Dim m1GEntry As String
    Public ReadOnly Property ConditionalEntry1A As String
        Get
            Return MySettings.ConvertGDSValue(m1AEntry)
        End Get
    End Property
    Public ReadOnly Property ConditionalEntry1G As String
        Get
            Return MySettings.ConvertGDSValue(m1GEntry)
        End Get
    End Property
    Public Sub SetValues(ByVal p1AEntry As String, ByVal p1GEntry As String)
        m1AEntry = p1AEntry
        m1GEntry = p1GEntry
    End Sub
End Class
