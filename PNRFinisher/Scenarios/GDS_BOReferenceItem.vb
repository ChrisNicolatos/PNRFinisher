Option Strict On
Option Explicit On
Public Class GDS_BOReferenceItem
    Public ReadOnly Property Key As String
    Public ReadOnly Property Value As String
    Public ReadOnly Property Element As String
    Public Sub New(ByVal pKey As String, ByVal pValue As String, ByVal pElement As String)
        Key = pKey
        Value = pValue
        Element = pElement
    End Sub
End Class