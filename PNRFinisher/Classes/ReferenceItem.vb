Option Strict On
Option Explicit On
Public Class ReferenceItem
    Private Structure ClassProps
        Dim Code As String
        Dim Description As String
    End Structure
    Private mudtProps As ClassProps
    Public Sub New(ByVal pCode As String, ByVal pDescription As String)
        mudtProps.Code = pCode
        mudtProps.Description = pDescription
    End Sub
    Public ReadOnly Property Code As String
        Get
            Return mudtProps.Code
        End Get
    End Property
    Public ReadOnly Property Description As String
        Get
            Return mudtProps.Description
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return mudtProps.Code & If(Description = "", "", " - " & mudtProps.Description)
    End Function
    'Friend Sub SetValues(ByVal pCode As String, ByVal pDescription As String)
    '    With mudtProps
    '        .Code = pCode
    '        .Description = pDescription
    '    End With
    'End Sub

End Class
