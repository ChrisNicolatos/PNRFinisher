Option Strict On
Option Explicit On
Public Class OSMVesselGroupItem
    Private mflgIsNew As Boolean = True
    Public ReadOnly Property Id As Integer = 0
    Public Property GroupName As String = ""
    Public Overrides Function ToString() As String
        Return GroupName
    End Function
    Public Sub New(ByVal pId As Integer, ByVal pGroupName As String)
        Id = pId
        GroupName = pGroupName
        mflgIsNew = False
    End Sub
    Public Sub Update()

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@GroupName", SqlDbType.NVarChar, 254).Value = GroupName
            .CommandText = "INSERT INTO [AmadeusReports].[dbo].[osmVesselGroup] 
                            (osmvrGroupName) 
                            VALUES 
                            ( @GroupName ) 
                            select scope_identity() as Id"
            _Id = CInt(.ExecuteScalar)
            mflgIsNew = False
        End With
    End Sub
    Public Sub Delete()
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            If Not mflgIsNew Then
                .Parameters.Add("@Id", SqlDbType.Int).Value = Id
                .CommandText = "DELETE FROM AmadeusReports.dbo.osmVesselGroup 
                                WHERE osmvrId = @Id"
                .ExecuteNonQuery()
            End If
        End With
    End Sub
End Class