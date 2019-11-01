Option Strict On
Option Explicit On
Public Class GDSNewItem
    Public ReadOnly Property GDSCommand As String = ""
    Public ReadOnly Property TextRequested As String = ""
    Public Sub New()
        TextRequested = ""
        GDSCommand = ""
    End Sub
    Public Sub New(ByVal Value As String)
        TextRequested = Value
        GDSCommand = ""
    End Sub
    Public Sub New(ByVal Value As String, ByVal pGDSCommand As String)
        TextRequested = Value
        GDSCommand = pGDSCommand
    End Sub
End Class
