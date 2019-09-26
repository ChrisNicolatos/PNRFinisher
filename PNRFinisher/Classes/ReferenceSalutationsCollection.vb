Option Strict On
Option Explicit On
Public Class ReferenceSalutationsCollection
    Inherits Collections.Generic.Dictionary(Of Integer, ReferenceItem)
    Private mstrSalutations() As String = {"MR", "MRS", "MS", "MISS", "MISTER"}
    Public Sub New()
        For i As Integer = 0 To mstrSalutations.GetUpperBound(0)
            Dim pItem As New ReferenceItem(mstrSalutations(i), "")
            MyBase.Add(i, pItem)
        Next
    End Sub
End Class
