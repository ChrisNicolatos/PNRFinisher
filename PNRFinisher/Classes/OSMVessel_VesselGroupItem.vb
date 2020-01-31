Option Strict On
Option Explicit On
Public Class OSMVessel_VesselGroupItem
    Private Structure ClassProps
        Dim Id As Integer
        Dim VesselId As Integer
        Dim VesselGroupId As Integer
        Dim VesselName As String
        Dim VesselGroupName As String
        Dim Exists As Boolean
    End Structure
    Dim mudtProps As ClassProps
    Public Sub New()
        With mudtProps
            .Id = 0
            .VesselId = 0
            .VesselGroupId = 0
            .VesselName = ""
            .VesselGroupName = ""
            .Exists = False
        End With
    End Sub
    Public Overrides Function ToString() As String
        Return mudtProps.VesselName & "-" & mudtProps.VesselGroupName
    End Function
    Public ReadOnly Property Id As Integer
        Get
            Return mudtProps.Id
        End Get
    End Property
    Public ReadOnly Property VesselName As String
        Get
            Return mudtProps.VesselName
        End Get
    End Property
    Public ReadOnly Property VesselGroupName As String
        Get
            Return mudtProps.VesselGroupName
        End Get
    End Property
    Public Property VesselId As Integer
        Get
            Return mudtProps.VesselId
        End Get
        Set(value As Integer)
            mudtProps.VesselId = value
        End Set
    End Property
    Public Property VesselGroupId As Integer
        Get
            Return mudtProps.VesselGroupId
        End Get
        Set(value As Integer)
            mudtProps.VesselGroupId = value
        End Set
    End Property
    Public Property Exists As Boolean
        Get
            Return mudtProps.Exists
        End Get
        Set(value As Boolean)
            mudtProps.Exists = value
        End Set
    End Property
    Public Sub SetValues(ByVal pId As Integer, ByVal pVesselId As Integer, ByVal pVesselGroupId As Integer, ByVal pVesselName As String, ByVal pVesselGroupName As String, ByVal pVesselId_fkey As Integer)
        With mudtProps
            .Id = pId
            .VesselId = pVesselId
            .VesselGroupId = pVesselGroupId
            .VesselName = pVesselName
            .VesselGroupName = pVesselGroupName
            .Exists = (pVesselId_fkey <> 0)
        End With
    End Sub
End Class