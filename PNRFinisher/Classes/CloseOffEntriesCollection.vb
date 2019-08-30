﻿Option Strict On
Option Explicit On
Public Class CloseOffEntriesCollection
    Inherits Collections.Generic.Dictionary(Of Integer, CloseOffEntriesItem)

    Public Sub Load(ByVal GDSPcc As String, ByVal OwnPCC As Boolean)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@PCC", SqlDbType.NChar, 9).Value = GDSPcc
            .Parameters.Add("@OwnPCC", SqlDbType.Bit).Value = IIf(OwnPCC, 1, 0)
            .CommandText = "SELECT pfcEntry 
                            FROM AmadeusReports.dbo.PNRFinisherCloseOff 
                            WHERE pfcPCC = @PCC AND pfcOwnPCC = @OwnPCC 
                            ORDER BY pfcSeqNo "
            pobjReader = .ExecuteReader
        End With

        MyBase.Clear()

        Dim pIndex As Integer = 0
        With pobjReader
            While pobjReader.Read
                Dim pItem As New CloseOffEntriesItem
                pIndex += 1
                pItem.SetValues(CStr(.Item("pfcEntry")))
                MyBase.Add(pIndex, pItem)
            End While
            .Close()
        End With
        pobjConn.Close()

    End Sub
End Class