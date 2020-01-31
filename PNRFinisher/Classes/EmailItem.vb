Option Strict On
Option Explicit On
Public Class EmailItem
    Private Structure ClassProps
        Dim ElementNo As Integer
        Dim EmailAddress As String
        Dim EmailComment As String
    End Structure
    Private mudtProps As ClassProps
    Public ReadOnly Property ElementNo As Integer
        Get
            Return mudtProps.ElementNo
        End Get
    End Property
    Public ReadOnly Property EmailAddress As String
        Get
            Return mudtProps.EmailAddress
        End Get
    End Property
    Public ReadOnly Property EmailComment As String
        Get
            Return mudtProps.EmailComment
        End Get
    End Property
    Public Sub SetValues(ByVal pElementNo As Integer, ByVal pEmailAddress As String, ByVal pEmailComment As String)
        With mudtProps
            .ElementNo = pElementNo
            .EmailAddress = pEmailAddress
            .EmailComment = pEmailComment
        End With
    End Sub
End Class