Option Strict On
Option Explicit On
Public Class ClassOfServiceItem
    Public ReadOnly Property Key As String
    Public ReadOnly Property Carrier As String
    Public ReadOnly Property Origin As String
    Public ReadOnly Property Destination As String
    Public ReadOnly Property ClassOfService As String
    Public ReadOnly Property CabinDescription As String
    Public ReadOnly Property ClassDescription As String
    Public ReadOnly Property CabinClass As String
    Public Sub New(ByVal pCarrier As String, ByVal pOrigin As String, ByVal pDestination As String, ByVal pClassOfService As String, ByVal pCabinDescription As String, ByVal pClassDescription As String, ByVal pcabinClass As String)
        Carrier = pCarrier
        Origin = pOrigin
        Destination = pDestination
        ClassOfService = pClassOfService
        CabinDescription = pCabinDescription
        ClassDescription = pClassDescription
        CabinClass = pcabinClass
        Key = Carrier & "|" & Origin & "|" & Destination & "|" & ClassOfService
    End Sub
End Class
