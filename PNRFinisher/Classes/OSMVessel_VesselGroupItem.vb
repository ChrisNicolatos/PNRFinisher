Option Strict On
Option Explicit On
Public Class OSMVessel_VesselGroupItem
    Public Overrides Function ToString() As String
        Return VesselName & "-" & VesselGroupName
    End Function
    Public ReadOnly Property Id As Integer
    Public ReadOnly Property VesselName As String
    Public ReadOnly Property VesselGroupName As String
    Public Property VesselId As Integer
    Public Property VesselGroupId As Integer
    Public Property Exists As Boolean
    Public Sub New(ByVal pId As Integer, ByVal pVesselId As Integer, ByVal pVesselGroupId As Integer, ByVal pVesselName As String, ByVal pVesselGroupName As String, ByVal pVesselId_fkey As Integer)
        Id = pId
        VesselId = pVesselId
        VesselGroupId = pVesselGroupId
        VesselName = pVesselName
        VesselGroupName = pVesselGroupName
        Exists = (pVesselId_fkey <> 0)
    End Sub
End Class