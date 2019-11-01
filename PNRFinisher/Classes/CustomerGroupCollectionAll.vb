Option Strict On
Option Explicit On
Public Class CustomerGroupCollectionAll
    Inherits Collections.Generic.Dictionary(Of Integer, CustomerGroupItem)
    Public Sub Load(ByVal pBackOffice As Integer)

        Dim pCommandText As String

        Try
            If pBackOffice = 1 Then
                pCommandText = " USE TravelForceCosmos 
                                 SELECT Id, Description 
                                 FROM Tags 
                                 WHERE TagGroupId = 146 
                                 ORDER BY Description "
                ReadCustomerGroups(pCommandText, pBackOffice)
            Else
                'Dim pobjClass As CustomerGroupItem
                'pobjClass = New CustomerGroupItem
                'pobjClass.SetValues(0, "All customers")
                'MyBase.Add(pobjClass.ID, pobjClass)
            End If
        Catch ex As Exception
            Throw New Exception("AllCustomerGroups.Load()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ReadCustomerGroups(ByVal CommandText As String, ByVal pBackOffice As Integer)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        Dim pobjClass As CustomerGroupItem

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = CommandText
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            Do While .Read
                pobjClass = New CustomerGroupItem(CInt(.Item("Id")), CStr(.Item("Description")))
                MyBase.Add(pobjClass.ID, pobjClass)
            Loop
            .Close()
        End With
        pobjConn.Close()

    End Sub
End Class