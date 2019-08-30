Option Strict On
Option Explicit On
Public Class BackOfficeCollection
    Inherits Collections.Generic.Dictionary(Of Integer, BackOfficeItem)
    Public Function Load(ByVal BOName As String) As BackOfficeItem
        Dim pobjClass As BackOfficeItem

        If MyBase.Count = 0 Then
            ReadDB()
        End If
        pobjClass = New BackOfficeItem

        For Each pobjItem As BackOfficeItem In MyBase.Values
            If pobjItem.BOName = BOName Then
                pobjClass = pobjItem
                Exit For
            End If
        Next

        Return pobjClass
    End Function
    Public Function Load(ByVal Id As Integer) As BackOfficeItem

        Dim pobjClass As BackOfficeItem

        If MyBase.Count = 0 Then
            ReadDB()
        End If

        If MyBase.ContainsKey(Id) Then
            pobjClass = MyBase.Item(Id)
        Else
            pobjClass = New BackOfficeItem
        End If
        Return pobjClass

    End Function
    Private Sub ReadDB()
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        Dim pobjClass As BackOfficeItem

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = "USE AmadeusReports
                            SELECT pfrBOId
                                  ,ISNULL(pfrBOName, '') AS pfrBOName
                                  ,ISNULL(pfrBODBDataSource, '') AS pfrBODBDataSource
                                  ,ISNULL(pfrBODBInitialCatalog, '') AS pfrBODBInitialCatalog
                                  ,ISNULL(pfrBODBUserId, '') AS pfrBODBUserId
                                  ,ISNULL(pfrBODBUserPassword, '') AS pfrBODBUserPassword
                                  ,ISNULL(pfrBODBBranchCode, '') AS pfrBODBBranchCode
                              FROM PNRFinisherBackOffice
                              ORDER BY pfrBOId"
            pobjReader = .ExecuteReader
        End With
        With pobjReader
            Do While .Read
                pobjClass = New BackOfficeItem
                pobjClass.SetValues(CInt(.Item("pfrBOId")), CStr(.Item("pfrBOName")), CStr(.Item("pfrBODBDataSource")), CStr(.Item("pfrBODBInitialCatalog")), CStr(.Item("pfrBODBUserId")) _
                                    , CStr(.Item("pfrBODBUserPassword")), CStr(.Item("pfrBODBBranchCode")))
                MyBase.Add(pobjClass.ID, pobjClass)
            Loop
            .Close()
        End With
        pobjConn.Close()
    End Sub
End Class
