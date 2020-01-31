Option Strict On
Option Explicit On
Public Class CTCPaxCollection
    Inherits Collections.Generic.Dictionary(Of Integer, CTCPax)
    Event isDirty()
    Event isValid()
    Private WithEvents mItem As CTCPax
    Private mintBackOfficeID As Integer
    Private mintClientID As Integer
    Public Sub AddNewItem(ByVal pId As Integer)
        Dim pItem As New CTCPax(mintBackOfficeID, mintClientID)
        pItem.SetValues(pId, mintBackOfficeID, mintClientID, "", "", "", "", "", False)
        MyBase.Add(pItem.Id, pItem)
    End Sub
    Public Sub Load(ByVal BackOfficeID As Integer, ByVal ClientID As Integer)
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        Dim pobjClass As CTCPax
        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        mintBackOfficeID = BackOfficeID
        mintClientID = ClientID
        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@BackOfficeID", SqlDbType.Int).Value = BackOfficeID
            .Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID
            .CommandText = "USE AmadeusReports
      SELECT ctcID
      ,ctcBackOffice_fkey
      ,ctcClientId_fkey
      ,ISNULL(ctcVesselName, '') AS ctcVesselName
      ,ISNULL(ctcPassengerFirstName, '') AS ctcPassengerFirstName
      ,ISNULL(ctcPassengerLastName, '') AS ctcPassengerLastName
      ,ISNULL(ctcEmail, '') AS ctcEmail
      ,ISNULL(ctcMobile, '') AS ctcMobile
      ,ISNULL(ctcRefused, 0) AS ctcRefused
  FROM AmadeusReports.dbo.PaxCTC
  WHERE ctcBackOffice_fkey = @BackOfficeID
  AND ctcClientId_fkey = @ClientID
  "
            pobjReader = .ExecuteReader
        End With
        MyBase.Clear()
        With pobjReader
            Do While .Read
                pobjClass = New CTCPax(BackOfficeID, ClientID)
                pobjClass.SetValues(CInt(.Item("ctcID")), CInt(.Item("ctcBackOffice_fkey")), CInt(.Item("ctcClientId_fkey")), CStr(.Item("ctcVesselName")) _
                                  , CStr(.Item("ctcPassengerFirstName")), CStr(.Item("ctcPassengerLastName")), CStr(.Item("ctcEmail")), CStr(.Item("ctcMobile")), CBool(.Item("ctcRefused")))
                MyBase.Add(pobjClass.Id, pobjClass)
            Loop
            .Close()
        End With
        pobjConn.Close()
    End Sub
    Public Sub Update()
        For Each pItem As CTCPax In MyBase.Values
            If pItem.Dirty Then
                pItem.Update()
            End If
        Next
    End Sub
    Public Sub AmendItem(ByVal Id As Integer, ByVal VesselName As String, ByVal LastName As String, ByVal FirstName As String, ByVal Email As String, ByVal Mobile As String, ByVal Refused As Boolean)
        mItem = MyBase.Item(Id)
        mItem.SetValues(Id, mintBackOfficeID, mintClientID, VesselName, FirstName, LastName, Email, Mobile, Refused)
        mItem.Email = Email
        mItem.Mobile = Mobile
        mItem.Refused = Refused
        MyBase.Item(Id) = mItem
    End Sub
    Private Sub mItem_isDirty() Handles mItem.isDirty
        RaiseEvent isDirty()
    End Sub
    Private Sub mItem_isValid() Handles mItem.isValid
        RaiseEvent isValid()
    End Sub
End Class
