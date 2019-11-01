Option Strict On
Option Explicit On
Public Class OSMVesselGroupItem
    Private Structure ClassProps
        Dim Id As Integer
        Dim GroupName As String
        Dim isNew As Boolean
        Dim isValid As Boolean
    End Structure
    Dim mudtProps As ClassProps
    Public Sub New()
        With mudtProps
            .Id = 0
            .GroupName = ""
            .isNew = True
            CheckValid()
        End With
    End Sub
    Public Sub New(pId As Integer, pGroupName As String)
        With mudtProps
            .Id = pId
            .GroupName = pGroupName
            .isNew = True
            CheckValid()
        End With
    End Sub
    Private Sub CheckValid()
        mudtProps.isValid = (GroupName <> "")
    End Sub
    Public Overrides Function ToString() As String
        Return mudtProps.GroupName
    End Function
    Public ReadOnly Property Id As Integer
        Get
            Return mudtProps.Id
        End Get
    End Property
    Public Property GroupName As String
        Get
            Return mudtProps.GroupName
        End Get
        Set(value As String)
            mudtProps.GroupName = value
            CheckValid()
        End Set
    End Property
    Public ReadOnly Property isValid As Boolean
        Get
            Return mudtProps.isValid
        End Get
    End Property
    Public ReadOnly Property isNew As Boolean
        Get
            Return mudtProps.isNew
        End Get
    End Property
    Public Sub SetValues(ByVal pId As Integer, ByVal pGroupName As String)
        With mudtProps
            .Id = pId
            .GroupName = pGroupName
            .isNew = False
            CheckValid()
        End With
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
            mudtProps.Id = CInt(.ExecuteScalar)
            mudtProps.isNew = False
        End With
    End Sub
    Public Sub Delete()
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            If Not mudtProps.isNew Then
                .Parameters.Add("@Id", SqlDbType.Int).Value = mudtProps.Id
                .CommandText = "DELETE FROM AmadeusReports.dbo.osmVesselGroup 
                                WHERE osmvrId = @Id"
                .ExecuteNonQuery()
            End If
        End With
    End Sub
End Class