﻿Option Strict On
Option Explicit On
Public Class CustomerCollection
    Inherits Collections.Generic.Dictionary(Of Integer, CustomerItem)
    Private mAllCustomer As New CustomerCollectionAll
    'Public Sub Load(ByVal SearchString As String)

    '    Try
    '        If mAllCustomer.Count = 0 Or mAllCustomer.PCCBackOffice <> MySettings.PCCBackOffice Then
    '            Cursor.Current = Cursors.WaitCursor
    '            mAllCustomer.Load()
    '        End If

    '        MyBase.Clear()

    '        Dim pItem As CustomerItem

    '        For Each pItem In mAllCustomer.Values
    '            If pItem.Code.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or (Not IsNumeric(SearchString) And (pItem.Name.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or pItem.Logo.ToUpper.IndexOf(SearchString.ToUpper) >= 0)) Then
    '                MyBase.Add(pItem.ID, pItem)
    '            End If
    '        Next

    '    Catch ex As Exception
    '        Throw New Exception("CustomerCollection.Load()" & vbCrLf & ex.Message)
    '    Finally
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub

    Public Sub Load(ByVal SearchString As String, ByVal BackOffice As Integer)
        Try
            If mAllCustomer.Count = 0 Or mAllCustomer.PCCBackOffice <> BackOffice Then
                Cursor.Current = Cursors.WaitCursor
                mAllCustomer.Load(BackOffice)
            End If

            MyBase.Clear()

            Dim pItem As CustomerItem

            For Each pItem In mAllCustomer.Values
                If pItem.Code.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or (Not IsNumeric(SearchString) And (pItem.Name.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or pItem.Logo.ToUpper.IndexOf(SearchString.ToUpper) >= 0)) Then
                    MyBase.Add(pItem.ID, pItem)
                End If
            Next
        Catch ex As Exception
            Throw New Exception("CustomerCollection.Load()" & vbCrLf & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class