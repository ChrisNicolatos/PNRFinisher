Option Strict On
Option Explicit On
Public Class GDSExistingItem
    Private Structure ExistingItemClass

        Dim Exists As Boolean
        Dim LineNumber As Integer
        Dim Category As String
        Dim RawText As String
        Dim Key As String

        Friend Sub Clear()
            Exists = False
            LineNumber = 0
            Category = ""
            RawText = ""
            Key = ""
        End Sub

    End Structure
    Private mudtProps As ExistingItemClass

    Public ReadOnly Property Exists As Boolean
        Get
            Return mudtProps.Exists
        End Get
    End Property

    Public ReadOnly Property LineNumber As Integer
        Get
            Return mudtProps.LineNumber
        End Get
    End Property
    Public ReadOnly Property Category As String
        Get
            Return mudtProps.Category
        End Get
    End Property
    Public ReadOnly Property RawText As String
        Get
            Return mudtProps.RawText
        End Get
    End Property
    Public ReadOnly Property Key As String
        Get
            Return mudtProps.Key
        End Get
    End Property
    Public Sub SetValues(ByVal pExists As Boolean, ByVal pLineNumber As Integer, ByVal pCategory As String, ByVal pRawText As String, ByVal pKey As String)
        With mudtProps
            .Exists = pExists
            .LineNumber = pLineNumber
            .Category = pCategory
            .RawText = pRawText
            .Key = pKey
        End With
    End Sub
    Friend Sub Clear()
        mudtProps.Clear()
    End Sub
End Class
