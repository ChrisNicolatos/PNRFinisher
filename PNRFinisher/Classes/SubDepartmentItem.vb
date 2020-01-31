Option Strict On
Option Explicit On
Public Class SubDepartmentItem
    Private Structure ClassProps
        Dim ID As Integer
        Dim Code As String
        Dim Name As String
    End Structure
    Private mudtProps As ClassProps
    Public Overrides Function ToString() As String
        With mudtProps
            Return .Code & " " & .Name
        End With
    End Function
    Public ReadOnly Property ID() As Integer
        Get
            Return mudtProps.ID
        End Get
    End Property
    Public ReadOnly Property Code() As String
        Get
            Return mudtProps.Code
        End Get
    End Property
    Public ReadOnly Property Name() As String
        Get
            Return mudtProps.Name
        End Get
    End Property
    Public Sub SetValues(ByVal pID As Integer, ByVal pCode As String, ByVal pName As String)
        With mudtProps
            .ID = pID
            .Code = pCode
            .Name = pName
        End With
    End Sub

    Public Sub Load(ByVal pSubID As Integer, ByVal pBackOffice As Integer)
        If pBackOffice = 1 Then

            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@SubID", SqlDbType.Int).Value = pSubID
                .CommandText = " SELECT Id  
                                       ,Code
                                       ,Name
                                 FROM TravelForceCosmos.dbo.TFEntitySubdepartments 
                                 WHERE ID = @SubID  
                                 ORDER BY Name "
                pobjReader = .ExecuteReader
            End With
            With pobjReader
                Do While .Read
                    SetValues(CInt(.Item("Id")), CStr(.Item("Code")), CStr(.Item("Name")))
                Loop
                .Close()
            End With
            pobjConn.Close()
        End If
    End Sub
End Class