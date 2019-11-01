Option Strict On
Option Explicit On
Public Class GDS_BOReferenceCollection
    Inherits Collections.Generic.Dictionary(Of String, GDS_BOReferenceItem)
    Private mintBackOffice As Integer
    Private mstrGDSCode As EnumGDSCode
    Friend Sub Read(ByVal pBackOffice As Integer, ByVal pGDSCode As EnumGDSCode)

        If MyBase.Count = 0 Or pBackOffice <> mintBackOffice Or pGDSCode <> mstrGDSCode Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@PCCBackOffice", SqlDbType.BigInt).Value = pBackOffice
                .Parameters.Add("@GDS", SqlDbType.BigInt).Value = pGDSCode
                .CommandText = " SELECT pfrID  
                             , ISNULL(pfrKey,'') AS pfrKey  
                             , ISNULL(pfrValue,'') AS pfrValue  
                             , ISNULL(pfrGDS_fkey,0) AS pfrGDS_fkey  
                             , ISNULL(pfrBO_fkey,0) AS pfrBO_fkey  
                             , ISNULL(pfrGDSElement,'') AS pfrGDSElement  
                             , ISNULL(pfrReferenceIdentifier,'') AS pfrReferenceIdentifier  
                             , ISNULL(pfrReferenceDetail,'') AS pfrReferenceDetail  
                             FROM [AmadeusReports].[dbo].[PNRFinisherGDS_BOReferences]  
                             WHERE pfrGDS_fkey = @GDS AND pfrBO_fkey = @PCCBackOffice"
                pobjReader = .ExecuteReader
            End With

            mintBackOffice = pBackOffice
            mstrGDSCode = pGDSCode
            MyBase.Clear()

            With pobjReader
                While pobjReader.Read
                    Dim pItem As New GDS_BOReferenceItem
                    pItem.SetValues(CInt(.Item("pfrID")), CStr(.Item("pfrKey")), CStr(.Item("pfrValue")), CInt(.Item("pfrGDS_fkey")), CInt(.Item("pfrBO_fkey")), CStr(.Item("pfrGDSElement")), CStr(.Item("pfrReferenceIdentifier")), CStr(.Item("pfrReferenceDetail")))
                    MyBase.Add(pItem.Key, pItem)
                End While
                .Close()
            End With
            pobjConn.Close()
        End If
    End Sub
    Public ReadOnly Property BackOffice As Integer
        Get
            Return mintBackOffice
        End Get
    End Property
    Friend ReadOnly Property GDSCode As EnumGDSCode
        Get
            Return mstrGDSCode
        End Get
    End Property
End Class