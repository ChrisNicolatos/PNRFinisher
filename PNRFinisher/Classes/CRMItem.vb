Option Strict On
Option Explicit On
Public Class CRMItem
    Public Overrides Function ToString() As String
        Return Code & " " & Name
    End Function
    Public ReadOnly Property ID() As Integer
    Public ReadOnly Property Code() As String
    Public ReadOnly Property Name() As String
    Public ReadOnly Property Alert As String
    Friend Sub New(ByVal pID As Integer, ByVal pCode As String, ByVal pName As String, ByVal pAlert As String)
        ID = pID
        Code = pCode
        Name = pName
        Alert = pAlert
    End Sub

    Public Sub New(ByVal pSubCode As String, ByVal pBackOffice As Integer)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        Dim pobjAlerts As New AlertsCollection()
        pobjAlerts.Load()

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@SubCode", SqlDbType.NVarChar, 20).Value = pSubCode
            .CommandText = " SELECT [Id]  
                             ,[Code]  
                             ,[Name]  
                             FROM [TravelForceCosmos].[dbo].[TFEntities]  
                             WHERE Code = @SubCode  
                             ORDER BY Name "


            pobjReader = .ExecuteReader
        End With

        With pobjReader
            Do While .Read
                ID = CInt(.Item("Id"))
                Code = CStr(.Item("Code"))
                Name = CStr(.Item("Name"))
                Alert = pobjAlerts.AlertForFinisher(pBackOffice, CStr(.Item("Code")))
            Loop
            .Close()
        End With
        pobjConn.Close()
    End Sub
End Class
