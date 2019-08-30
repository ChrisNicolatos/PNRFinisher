Option Strict On
Option Explicit On
Public Class ItnWebDocElements
    Public Shared ReadOnly Property WebHead As String
        Get
            Return "<head>
<style>
td {
    font-size:10.0pt;
    font-family:arial;
}
</style>
</head><body>"
        End Get
    End Property
    Public Shared ReadOnly Property WebClose As String
        Get
            Return "</body></html>"
        End Get
    End Property
End Class
