Option Strict On
Option Explicit On
Public Class ClientGroupCollection
    Inherits Collections.Generic.Dictionary(Of Integer, ClientGroup)
    Private mobjAllClientGroups As ClientGroupCollectionAll

    Public Sub New(ByVal SearchString As String, ByVal pBackOffice As Integer)

        Try
            If mobjAllClientGroups Is Nothing Then
                Cursor.Current = Cursors.WaitCursor
                mobjAllClientGroups = New ClientGroupCollectionAll(pBackOffice)
            End If

            MyBase.Clear()

            Dim pItem As ClientGroup

            For Each pItem In mobjAllClientGroups.Values
                If pItem.Name.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Then
                    MyBase.Add(pItem.ID, pItem)
                End If
            Next


        Catch ex As Exception
            Throw New Exception("ClientGroupCollection.New()" & vbCrLf & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

End Class