Option Strict On
Option Explicit On
Public Class ClientGroupCollectionAll
    Inherits Collections.Generic.Dictionary(Of Integer, ClientGroup)
    Public Sub New(ByVal pBackOffice As Integer)

        Dim pCommandText As String

        Try
            If pBackOffice = 1 Then
                pCommandText = " USE TravelForceCosmos 
                                 SELECT Id, Description 
                                 FROM Tags 
                                 WHERE TagGroupId = 146 
                                 ORDER BY Description "
                ReadClientGroups(pCommandText, pBackOffice)
            End If
        Catch ex As Exception
            Throw New Exception("ClientGroupCollectionAll.Load()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ReadClientGroups(ByVal CommandText As String, ByVal pBackOffice As Integer)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        Dim pobjClass As ClientGroup

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = CommandText
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            Do While .Read
                pobjClass = New ClientGroup(CInt(.Item("Id")), CStr(.Item("Description")))
                MyBase.Add(pobjClass.ID, pobjClass)
            Loop
            .Close()
        End With
        pobjConn.Close()

    End Sub
End Class