Option Strict On
Option Explicit On
Public Class CustomerGroupItem
    Public ReadOnly Property ID() As Integer
    Public ReadOnly Property Name() As String
    Public Sub New(ByVal pID As Integer, ByVal pName As String)
        ID = pID
        Name = pName
    End Sub
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class