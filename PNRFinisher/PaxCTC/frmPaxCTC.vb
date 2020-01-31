Option Strict On
Option Explicit On
Public Class frmPaxCTC
    Private mintBackOffice As Integer = 0
    Private mstrClientCode As String = ""
    Private mstrClientName As String = ""
    Private mstrVesselName As String = ""
    Private mstrClientFilter As String = ""
    Private mstrVesselFilter As String = ""
    Private mstrPaxFilter As String = ""
    Private mobjClients As ClientCollectionAll
    Private mobjSelectedClient As Client
    Private mobjSelectedVessel As VesselItem
    Private mobjCTC As New CTCPaxCollection
    Private WithEvents mobjCTCSelectedClient As CTCPax
    Private WithEvents mobjCTCSelectedVessel As CTCPax
    Private WithEvents mobjCTCSelectedPax As CTCPax
    Private PaxFromPNR As Boolean = False
    Private mflgLoading As Boolean = False
    Public Sub ShowPaxInformation()
        Try
            mflgLoading = True
            PaxFromPNR = False
            mintBackOffice = 0
            mstrClientCode = ""
            mstrClientName = ""
            mstrVesselName = ""
            lstClient.Items.Clear()
            lstVessel.Items.Clear()
            lstPassenger.Items.Clear()
        Catch ex As Exception
            Throw New Exception("ShowPaxInformation()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Public Sub ShowPaxInformation(ByVal mPNR As GDSReadPNR, ByVal pBackOfficeID As Integer, ByVal pClientCode As String, ByVal pVesselName As String, ByVal pBackOffice As Integer)
        Try
            mflgLoading = True
            PaxFromPNR = True
            mintBackOffice = pBackOfficeID
            mstrClientCode = pClientCode
            Dim pClientFromDB As New ClientFromDB(mstrClientCode, pBackOffice)
            mobjSelectedClient = pClientFromDB.Client
            mstrClientName = mobjSelectedClient.Name
            mstrVesselName = pVesselName
            lstClient.Items.Clear()
            lstVessel.Items.Clear()
            lstPassenger.Items.Clear()

            mobjSelectedVessel = New VesselItem(mstrClientCode, mstrVesselName, pBackOffice)
            mobjCTCSelectedPax = New CTCPax(mintBackOffice, mobjSelectedClient.ID)

            DisplayInformation()
            SetReadOnlyClientCTC(False)
            For Each mPNRPax As GDSPaxItem In mPNR.Passengers.Values
                Dim pPax As New CTCPax(mintBackOffice, mobjSelectedClient.ID, mPNRPax.FirstName, mPNRPax.LastName)
                For Each mPax As CTCPax In mobjCTC.Values
                    If mPax.FirstName = mPNRPax.FirstName And mPax.Lastname = mPNRPax.LastName Then
                        pPax = mPax
                        Exit For
                    End If
                Next
                lstPassenger.Items.Add(pPax)
            Next
        Catch ex As Exception
            Throw New Exception("ShowPaxInformation(ByVal mPNR As GDSReadPNR)" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub DisplayInformation()
        Try
            mflgLoading = True
            If mintBackOffice = 1 Then
                optATH.Checked = True
            ElseIf mintBackOffice = 2 Then
                optQLI.Checked = True
            Else
                optATH.Checked = False
                optQLI.Checked = False
            End If
            txtClientCode.Text = mstrClientCode
            txtClientName.Text = mstrClientName
            txtVessel.Text = mstrVesselName
            chkClientRefused.Checked = False
            txtClientEmail.Text = ""
            txtClientMobile.Text = ""
            chkVesselRefused.Checked = False
            txtVesselEmail.Text = ""
            txtVesselMobile.Text = ""
            chkPaxRefused.Checked = False
            txtPaxEmail.Text = ""
            txtPaxMobile.Text = ""
            DisplaySelectedClientDetails()
            SetReadOnlyVesselCTC(False)
            DisplayVesselCTC()
            SetReadOnlyPax(False)
            DisplaySelectedPaxCTC()

            If lstPassenger.Items.Count = 1 Then
                Dim pPax As GDSPaxItem
                pPax = CType(lstPassenger.Items(0), GDSPaxItem)
                txtFirstName.Text = pPax.Initial
                txtLastName.Text = pPax.LastName
            End If
        Catch ex As Exception
            Throw New Exception("DisplayInformation()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub optATH_CheckedChanged(sender As Object, e As EventArgs) Handles optATH.CheckedChanged
        Try
            If Not mflgLoading Then
                If mintBackOffice <> 1 Then
                    mintBackOffice = 1
                    mobjClients = New ClientCollectionAll(mintBackOffice)
                    DisplayClients()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub optQLI_CheckedChanged(sender As Object, e As EventArgs) Handles optQLI.CheckedChanged
        Try
            If Not mflgLoading Then
                If mintBackOffice <> 2 Then
                    mintBackOffice = 2
                    mobjClients = New ClientCollectionAll(mintBackOffice)
                    DisplayClients()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DisplayClients()
        Try
            mflgLoading = True
            lstClient.Items.Clear()
            For Each pItem As Client In mobjClients.Values
                If (pItem.Code & pItem.Name).Replace(" ", "").ToUpper.IndexOf(mstrClientFilter.Replace(" ", "")) >= 0 Then
                    lstClient.Items.Add(pItem)
                End If
            Next
        Catch ex As Exception
            Throw New Exception("DisplayClients()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub lstClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClient.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If Not lstClient.SelectedItem Is Nothing Then
                    mobjSelectedClient = CType(lstClient.SelectedItem, Client)
                    DisplaySelectedClientDetails()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub DisplaySelectedClientDetails()
        Try
            mobjCTC.Load(mintBackOffice, mobjSelectedClient.ID)
            SetReadOnlyClientCTC(False)
            SetReadOnlyVesselCTC(True)
            SetReadOnlyPax(True)
            SetReadOnlyPaxCTC(True)
            DisplaySelectedClient()
            DisplayClientCTC()
            DisplaySelectedClientVessels()
            DisplaySelectedClientPax()
        Catch ex As Exception
            Throw New Exception("DisplaySelectedClientDetails()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DisplaySelectedClient()
        Try
            mflgLoading = True
            With mobjSelectedClient
                txtClientCode.Text = .Code
                txtClientName.Text = .Name
            End With
        Catch ex As Exception
            Throw New Exception("DisplaySelectedClient()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub DisplayClientCTC()
        Try
            mflgLoading = True
            mobjCTCSelectedClient = New CTCPax(mintBackOffice, mobjSelectedClient.ID)
            chkClientRefused.Checked = False
            txtClientEmail.Text = ""
            txtClientMobile.Text = ""
            txtVessel.Text = ""
            chkVesselRefused.Checked = False
            txtVesselEmail.Text = ""
            txtVesselMobile.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            chkPaxRefused.Checked = False
            txtPaxEmail.Text = ""
            txtPaxMobile.Text = ""
            cmdUpdateClient.Enabled = False
            cmdUpdateVessel.Enabled = False
            cmdUpdatePax.Enabled = False
            For Each pItem As CTCPax In mobjCTC.Values
                If pItem.Vesselname = "" And pItem.FirstName = "" And pItem.Lastname = "" Then
                    mobjCTCSelectedClient = pItem
                    Exit For
                End If
            Next
            If mobjCTCSelectedClient.ClientId = mobjSelectedClient.ID Then
                chkClientRefused.Checked = mobjCTCSelectedClient.Refused
                txtClientEmail.Text = mobjCTCSelectedClient.Email
                txtClientMobile.Text = mobjCTCSelectedClient.Mobile
            End If
        Catch ex As Exception
            Throw New Exception("DisplayClientCTC()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub DisplaySelectedClientVessels()
        Try
            mflgLoading = True
            Dim pVessels As New VesselCollection
            pVessels.Load(mobjSelectedClient.ID, mintBackOffice)
            lstVessel.Items.Clear()
            For Each pItem As VesselItem In pVessels.Values
                If mstrVesselFilter = "" Or pItem.VesselName.Replace(" ", "").ToUpper.IndexOf(mstrVesselFilter) >= 0 Then
                    lstVessel.Items.Add(pItem)
                End If
            Next
        Catch ex As Exception
            Throw New Exception("DisplaySelectedClientVessels()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub txtClientFilter_TextChanged(sender As Object, e As EventArgs) Handles txtClientFilter.TextChanged
        Try
            If Not mflgLoading Then
                mstrClientFilter = txtClientFilter.Text.Replace(" ", "")
                DisplayClients()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtVesselFilter_TextChanged(sender As Object, e As EventArgs) Handles txtVesselFilter.TextChanged
        Try
            If Not mflgLoading Then
                mstrVesselFilter = txtVesselFilter.Text.Replace(" ", "")
                DisplaySelectedClientVessels()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub lstVessel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstVessel.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If Not lstVessel.SelectedItem Is Nothing Then
                    mobjSelectedVessel = CType(lstVessel.SelectedItem, VesselItem)
                    SetReadOnlyVesselCTC(False)
                    DisplayVesselCTC()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub DisplayVesselCTC()
        Try
            mflgLoading = True
            mobjCTCSelectedVessel = New CTCPax(mintBackOffice, mobjSelectedClient.ID) With {
                .Vesselname = mobjSelectedVessel.VesselName
            }
            txtVessel.Text = mobjSelectedVessel.VesselName
            chkVesselRefused.Checked = False
            txtVesselEmail.Text = ""
            txtVesselMobile.Text = ""
            For Each pItem As CTCPax In mobjCTC.Values
                If pItem.Vesselname = mobjSelectedVessel.VesselName And pItem.FirstName = "" And pItem.Lastname = "" Then
                    mobjCTCSelectedVessel = pItem
                    Exit For
                End If
            Next
            If mobjCTCSelectedVessel.Vesselname <> "" Then
                chkVesselRefused.Checked = mobjCTCSelectedVessel.Refused
                txtVesselEmail.Text = mobjCTCSelectedVessel.Email
                txtVesselMobile.Text = mobjCTCSelectedVessel.Mobile
            End If
        Catch ex As Exception
            Throw New Exception("DisplayVesselCTC()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub DisplaySelectedClientPax()
        Try
            mflgLoading = True
            If Not PaxFromPNR Then
                lstPassenger.Items.Clear()
                For Each pItem As CTCPax In mobjCTC.Values
                    If pItem.ClientId = mobjSelectedClient.ID And pItem.FirstName <> "" And pItem.Lastname <> "" Then
                        If mstrPaxFilter = "" Or (pItem.FirstName & pItem.Lastname).Replace(" ", "").ToUpper.IndexOf(mstrPaxFilter) >= 0 Then
                            lstPassenger.Items.Add(pItem)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception("DisplaySelectedClientPax()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub

    Private Sub txtPaxFilter_TextChanged(sender As Object, e As EventArgs) Handles txtPaxFilter.TextChanged
        Try
            If Not mflgLoading Then
                mstrPaxFilter = txtPaxFilter.Text.Replace(" ", "")
                DisplaySelectedClientPax()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lstPassenger_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPassenger.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If Not lstPassenger.SelectedItem Is Nothing Then
                    mobjCTCSelectedPax = CType(lstPassenger.SelectedItem, CTCPax)
                    SetReadOnlyPax(True)
                    SetReadOnlyPaxCTC(False)
                    DisplaySelectedPaxCTC()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub DisplaySelectedPaxCTC()
        Try
            mflgLoading = True
            txtFirstName.Text = ""
            txtLastName.Text = ""
            chkPaxRefused.Checked = False
            txtPaxEmail.Text = ""
            txtPaxMobile.Text = ""
            If mobjCTCSelectedPax.ClientId <> 0 Then
                txtFirstName.Text = mobjCTCSelectedPax.FirstName
                txtLastName.Text = mobjCTCSelectedPax.Lastname
                chkPaxRefused.Checked = mobjCTCSelectedPax.Refused
                txtPaxEmail.Text = mobjCTCSelectedPax.Email
                txtPaxMobile.Text = mobjCTCSelectedPax.Mobile
            End If
        Catch ex As Exception
            Throw New Exception("DisplaySelectedPaxCTC()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub txtClientEmail_TextChanged(sender As Object, e As EventArgs) Handles txtClientEmail.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedClient.Email = txtClientEmail.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkClientRefused_CheckedChanged(sender As Object, e As EventArgs) Handles chkClientRefused.CheckedChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedClient.Refused = chkClientRefused.Checked
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtClientMobile_TextChanged(sender As Object, e As EventArgs) Handles txtClientMobile.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedClient.Mobile = txtClientMobile.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkVesselRefused_CheckedChanged(sender As Object, e As EventArgs) Handles chkVesselRefused.CheckedChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedVessel.Refused = chkVesselRefused.Checked
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtVesselEmail_TextChanged(sender As Object, e As EventArgs) Handles txtVesselEmail.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedVessel.Email = txtVesselEmail.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtVesselMobile_TextChanged(sender As Object, e As EventArgs) Handles txtVesselMobile.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedVessel.Mobile = txtVesselMobile.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedPax.FirstName = txtFirstName.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedPax.Lastname = txtLastName.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkPaxRefused_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaxRefused.CheckedChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedPax.Refused = chkPaxRefused.Checked
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtPaxEmail_TextChanged(sender As Object, e As EventArgs) Handles txtPaxEmail.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedPax.Email = txtPaxEmail.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtPaxMobile_TextChanged(sender As Object, e As EventArgs) Handles txtPaxMobile.TextChanged
        Try
            If Not mflgLoading Then
                mobjCTCSelectedPax.Mobile = txtPaxMobile.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub mobjCTCSelectedClient_isDirty() Handles mobjCTCSelectedClient.isDirty
        cmdUpdateClient.Enabled = True
    End Sub
    Private Sub mobjCTCSelectedPax_isDirty() Handles mobjCTCSelectedPax.isDirty
        cmdUpdatePax.Enabled = True
    End Sub
    Private Sub mobjCTCSelectedVessel_isDirty() Handles mobjCTCSelectedVessel.isDirty
        cmdUpdateVessel.Enabled = True
    End Sub
    Private Sub cmdUpdateClient_Click(sender As Object, e As EventArgs) Handles cmdUpdateClient.Click
        Try
            mobjCTCSelectedClient.Update()
            cmdUpdateClient.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdUpdateVessel_Click(sender As Object, e As EventArgs) Handles cmdUpdateVessel.Click
        Try
            mobjCTCSelectedVessel.Update()
            cmdUpdateVessel.Enabled = False
            DisplaySelectedClientDetails()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdUpdatePax_Click(sender As Object, e As EventArgs) Handles cmdUpdatePax.Click
        Try
            mobjCTCSelectedPax.Update()
            cmdUpdatePax.Enabled = False
            DisplaySelectedClientDetails()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdNewPax_Click(sender As Object, e As EventArgs) Handles cmdNewPax.Click
        Try
            mobjCTCSelectedPax = New CTCPax(mintBackOffice, mobjSelectedClient.ID)
            SetReadOnlyPax(False)
            DisplaySelectedPaxCTC()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetReadOnlyClientCTC(ByVal SetReadOnly As Boolean)
        chkClientRefused.Enabled = Not SetReadOnly
        txtClientEmail.ReadOnly = SetReadOnly
        txtClientMobile.ReadOnly = SetReadOnly
    End Sub
    Private Sub SetReadOnlyVesselCTC(ByVal SetReadOnly As Boolean)
        chkVesselRefused.Enabled = Not SetReadOnly
        txtVesselEmail.ReadOnly = SetReadOnly
        txtVesselMobile.ReadOnly = SetReadOnly
    End Sub
    Private Sub SetReadOnlyPax(ByVal SetReadOnly As Boolean)
        txtFirstName.ReadOnly = SetReadOnly
        txtLastName.ReadOnly = SetReadOnly
    End Sub
    Private Sub SetReadOnlyPaxCTC(ByVal SetReadOnly As Boolean)
        chkPaxRefused.Enabled = Not SetReadOnly
        txtPaxEmail.ReadOnly = SetReadOnly
        txtPaxMobile.ReadOnly = SetReadOnly
    End Sub

    Private Sub frmPaxCTC_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetReadOnlyClientCTC(Not PaxFromPNR)
        SetReadOnlyVesselCTC(True)
        SetReadOnlyPax(True)
        SetReadOnlyPaxCTC(True)
    End Sub
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class