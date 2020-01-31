Option Strict On
Option Explicit On
Public Class SubDepartmentCollection

    Inherits Collections.Generic.Dictionary(Of Integer, SubDepartmentItem)

    Public Sub Load(ByVal pEntityID As Long, ByVal pBackOffice As Integer)
        If pBackOffice = 1 Then

            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As SubDepartmentItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@EntityID", SqlDbType.Int).Value = pEntityID
                .CommandText = " SELECT Id  
                                       ,Code  
                                       ,Name  
                             FROM TravelForceCosmos.dbo.TFEntitySubdepartments
                             WHERE EntityID = @EntityID AND InUse = 1  
                             ORDER BY Name "
                pobjReader = .ExecuteReader
            End With
            With pobjReader
                Do While .Read
                    pobjClass = New SubDepartmentItem
                    pobjClass.SetValues(CInt(.Item("Id")), CStr(.Item("Code")), CStr(.Item("Name")))
                    MyBase.Add(pobjClass.ID, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()
        End If
    End Sub

End Class