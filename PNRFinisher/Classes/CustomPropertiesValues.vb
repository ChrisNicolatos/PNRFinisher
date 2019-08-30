Option Strict On
Option Explicit On
Public Class CustomPropertiesValues
    Private Structure ClassProps
        Dim Id As String
        Dim Code As String
        Dim Value As String
    End Structure
    Private mudtProps As ClassProps
    Public Sub New(ByVal pId As String, ByVal pCode As String, ByVal pValue As String)
        mudtProps.Id = pId
        mudtProps.Code = pCode
        mudtProps.Value = pValue
    End Sub
    Public Overrides Function ToString() As String
        With mudtProps
            Return (.Code & " " & .Value).Trim
        End With
    End Function
    Public ReadOnly Property Id As String
        Get
            Return mudtProps.Id
        End Get
    End Property
    Public ReadOnly Property Code As String
        Get
            Return mudtProps.Code
        End Get
    End Property
    Public ReadOnly Property Value As String
        Get
            Return mudtProps.Value
        End Get
    End Property
End Class
