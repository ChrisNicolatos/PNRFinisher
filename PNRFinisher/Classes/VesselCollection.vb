Option Strict On
Option Explicit On
Public Class VesselCollection
    Inherits Collections.Generic.Dictionary(Of String, VesselItem)
    Private mlngEntityID As Integer
    Private mintBackOffice As Integer
    Public Sub Load(ByVal pEntityID As Integer, ByVal BackOffice As Integer)
        If BackOffice = 1 Then
            mintBackOffice = BackOffice
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(mintBackOffice))
            ReadDB(pEntityID, pobjConn)
        End If
    End Sub
    Private Sub ReadDB(ByVal pEntityID As Integer, ByRef pobjConn As SqlClient.SqlConnection)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        Dim pobjClass As VesselItem

        mlngEntityID = pEntityID

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@EntityId", SqlDbType.Int).Value = mlngEntityID
            .CommandText = PrepareVesselSelectCommand()
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            Do While .Read
                pobjClass = New VesselItem(CStr(.Item("Name")), CStr(.Item("Flag")))
                If pobjClass.ToString <> "" And Not MyBase.ContainsKey(pobjClass.ToString) Then
                    MyBase.Add(pobjClass.ToString, pobjClass)
                End If
            Loop
            .Close()
        End With
        pobjConn.Close()
    End Sub
    Private Function PrepareVesselSelectCommand() As String

        Select Case mintBackOffice
            Case 1
                PrepareVesselSelectCommand = " SELECT DISTINCT  
                                               RTRIM(LTRIM(Name)) AS Name  
                                               ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag  
                                               FROM [TravelForceCosmos].[dbo].[TFEntityDepartments]  
                                               WHERE InUse = 1  
                                               AND RTRIM(LTRIM(Name)) <> '' AND EntityID = @EntityId  
                                               ORDER BY Name "
            Case 2
                PrepareVesselSelectCommand = " SELECT [Child_Value] AS Name  
                                               ,'' AS Flag  
                                               FROM [Disco_Instone_EU].[dbo].[Costcen]  
                                               WHERE Child_Value IS NOT NULL AND Child_Name = 'CC1' AND CostCen.Account_id =  @EntityId"
            Case Else
                PrepareVesselSelectCommand = ""
        End Select

    End Function
End Class