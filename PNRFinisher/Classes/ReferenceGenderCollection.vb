Option Strict On
Option Explicit On
Public Class ReferenceGenderCollection
    Inherits Collections.Generic.Dictionary(Of Integer, ReferenceItem)
    Public Sub New()
        Dim pItem As New ReferenceItem("M", "MALE")
        MyBase.Add(0, pItem)
        pItem = New ReferenceItem("F", "FEMALE")
        MyBase.Add(1, pItem)
        pItem = New ReferenceItem("MI", "MALE INFANT")
        MyBase.Add(2, pItem)
        pItem = New ReferenceItem("FI", "FEMALE INFANT")
        MyBase.Add(3, pItem)
        pItem = New ReferenceItem("U", "UNDISCLOSED GENDER")
        MyBase.Add(4, pItem)
    End Sub
End Class
