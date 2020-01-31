Option Strict On
Option Explicit On
Public Class ClientCollection
    Inherits Collections.Generic.Dictionary(Of Integer, Client)
    Private AllClients As ClientCollectionAll
    Public Sub New(ByVal SearchString As String, ByVal BackOffice As Integer)
        Try
            If AllClients Is Nothing OrElse AllClients.PCCBackOffice <> BackOffice Then
                Cursor.Current = Cursors.WaitCursor
                AllClients = New ClientCollectionAll(BackOffice)
            End If

            MyBase.Clear()

            Dim pItem As Client

            For Each pItem In AllClients.Values
                If pItem.Code.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or (Not IsNumeric(SearchString) And (pItem.Name.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or pItem.Logo.ToUpper.IndexOf(SearchString.ToUpper) >= 0)) Then
                    MyBase.Add(pItem.ID, pItem)
                End If
            Next
        Catch ex As Exception
            Throw New Exception("ClientCollection.New()" & vbCrLf & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class