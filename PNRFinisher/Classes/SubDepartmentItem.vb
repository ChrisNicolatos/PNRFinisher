Option Strict On
Option Explicit On
Public Class SubDepartmentItem
    Public Overrides Function ToString() As String
        Return Code & " " & Name
    End Function
    Public ReadOnly Property ID() As Integer
    Public ReadOnly Property Code() As String
    Public ReadOnly Property Name() As String
    Public Sub New(ByVal pID As Integer, ByVal pCode As String, ByVal pName As String)
        ID = pID
        Code = pCode
        Name = pName
    End Sub

    Public Sub New(ByVal pSubID As Integer, ByVal pBackOffice As Integer)
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
                    ID = CInt(.Item("Id"))
                    Code = CStr(.Item("Code"))
                    Name = CStr(.Item("Name"))
                Loop
                .Close()
            End With
            pobjConn.Close()
        End If
    End Sub
End Class