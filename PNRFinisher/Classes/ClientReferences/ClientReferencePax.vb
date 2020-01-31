Option Strict On
Option Explicit On
Public Class ClientReferencePax
    Public ReadOnly Property ElementID As Integer
    Public ReadOnly Property PaxName As String
    Public Property Reference As String
    Public Sub New(ByVal ElementId As Integer, ByVal PaxName As String)
        Me.ElementID = ElementId
        Me.PaxName = PaxName
    End Sub
End Class
