Option Strict On
Option Explicit On
Public Class OSMVesselCollection
    Inherits Collections.Generic.Dictionary(Of Integer, OSMVesselItem)

    Public Sub Load()

        Dim pText As String

        pText = "SELECT osmvID 
                 ,osmvVesselName 
                 , ISNULL(osmvInUse, 0) AS osmvInUse 
                 FROM AmadeusReports.dbo.osmVessels 
                 ORDER BY osmvVesselName"
        ExecuteLoad(pText, 0)

    End Sub
    Public Sub Load(ByVal pVesselGroup As Integer)

        Dim pText As String

        pText = "SELECT osmvID 
                 ,osmvVesselName 
                 , ISNULL(osmvInUse, 0) AS osmvInUse 
                 FROM AmadeusReports.dbo.osmVessels 
                 WHERE osmvID IN (SELECT osmVesselGroup_Vessels.osmvId_fkey FROM osmVesselGroup_Vessels WHERE osmVesselGroup_Vessels.osmvrId_fkey= @VesselGroup)
                 ORDER BY osmvVesselName"
        ExecuteLoad(pText, pVesselGroup)

    End Sub
    Private Sub ExecuteLoad(ByVal pText As String, ByVal pVesselGroup As Integer)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        Dim pobjClass As OSMVesselItem

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@VesselGroup", SqlDbType.Int).Value = pVesselGroup
            .CommandText = pText
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            Do While .Read
                pobjClass = New OSMVesselItem
                pobjClass.SetValues(CInt(.Item("osmvId")), CStr(.Item("osmvVesselName")), CBool(.Item("osmvInUse")))
                MyBase.Add(pobjClass.Id, pobjClass)
            Loop
            .Close()
        End With
        pobjConn.Close()
    End Sub
End Class