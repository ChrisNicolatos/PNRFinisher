Option Strict On
Option Explicit On
Public Class GDSNewItem
    'Private Structure NewItemClass
    '    Dim GDSCommand As String
    '    Dim TextRequested As String
    '    Public Sub Clear()
    '        GDSCommand = ""
    '        TextRequested = ""
    '    End Sub
    'End Structure
    'Private mudtProps As NewItemClass
    Public ReadOnly Property GDSCommand As String = ""
    Public ReadOnly Property TextRequested As String = ""

    Public Sub SetText(ByVal Value As String)
        _TextRequested = Value
    End Sub
    Public Sub New()
    End Sub
    Public Sub New(ByVal Value As String, ByVal pGDSCommand As String)
        If Value <> "" And pGDSCommand <> "" Then
            TextRequested = Value
            GDSCommand = pGDSCommand
        End If
    End Sub

    'Public Sub Clear()
    '    mudtProps.Clear()
    'End Sub

End Class
