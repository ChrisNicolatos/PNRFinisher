Option Strict On
Option Explicit On
Public Class CostCentreLookupItem
    Public Sub New(ByVal Id As Integer, ByVal Code As String, ByVal OldCode As String, ByVal ClientName As String, ByVal ClientLogo As String, ByVal VesselName As String, ByVal CostCentre As String)
        Id = Id
        Code = Code
        OldCode = OldCode
        ClientName = ClientName
        ClientLogo = ClientLogo
        VesselName = VesselName
        CostCentre = CostCentre
    End Sub
    Public ReadOnly Property Id As Integer
    Public ReadOnly Property Code As String
    Public ReadOnly Property OldCode As String
    Public ReadOnly Property ClientName As String
    Public ReadOnly Property ClientLogo As String
    Public ReadOnly Property VesselName As String
    Public ReadOnly Property CostCentre As String
End Class
