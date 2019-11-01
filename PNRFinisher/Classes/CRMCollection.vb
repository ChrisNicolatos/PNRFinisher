Option Strict On
Option Explicit On
Public Class CRMCollection
    Inherits Collections.Generic.Dictionary(Of Integer, CRMItem)
    Private mlngEntityID As Long
    Private mobjAlerts As New AlertsCollection()
    Public Sub Load(ByVal pEntityID As Long, ByVal pBackOffice As Integer)

        mobjAlerts.Load()

        If pBackOffice = 1 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As CRMItem

            mlngEntityID = pEntityID

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@EntityID", SqlDbType.Int).Value = mlngEntityID
                .CommandText = " SELECT [Id] 
                                ,[Code] 
                                ,[Name] 
                                FROM [TravelForceCosmos].[dbo].[TFEntities] 
                                WHERE  IsMLEntity = 1 AND IsActive = 1 AND RelatedEntityID = @EntityID  
                                ORDER BY Name "

                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pobjClass = New CRMItem(CInt(.Item("Id")), CStr(.Item("Code")), CStr(.Item("Name")), mobjAlerts.AlertForFinisher(pBackOffice, CStr(.Item("Code"))))
                    MyBase.Add(pobjClass.ID, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()
        End If
    End Sub

End Class
