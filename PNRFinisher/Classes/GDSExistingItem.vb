Option Strict On
Option Explicit On
Public Class GDSExistingItem
    Public ReadOnly Property Exists As Boolean = False
    Public ReadOnly Property LineNumber As Integer = 0
    Public ReadOnly Property Category As String = ""
    Public ReadOnly Property RawText As String = ""
    Public ReadOnly Property Key As String = ""
    Public Sub New(ByVal pExists As Boolean, ByVal pLineNumber As Integer, ByVal pCategory As String, ByVal pRawText As String, ByVal pKey As String)
        Exists = pExists
        LineNumber = pLineNumber
        Category = pCategory
        RawText = pRawText
        Key = pKey
    End Sub
    Friend Sub New()
        Exists = False
        LineNumber = 0
        Category = ""
        RawText = ""
        Key = ""
    End Sub
End Class
