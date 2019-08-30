Option Strict On
Option Explicit On
Public Class frmOSMVessels
    Private mOSMSelectedVessel As OSMVesselItem
    Private mOSMSelectedEmail As OSMEmailItem

    Private Sub frmOSMVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        OSMRefreshVessels(lstOSMEditVessels)
        CheckValid()

    End Sub

    Private Sub CheckValid()
        If mOSMSelectedVessel Is Nothing Then
            cmdOSMEditUpdateVessel.Enabled = False
            cmdOSMAddCCEmail.Enabled = False
            cmdOSMAddToEmail.Enabled = False
        Else
            cmdOSMEditUpdateVessel.Enabled = mOSMSelectedVessel.isValid
            cmdOSMAddCCEmail.Enabled = True
            cmdOSMAddToEmail.Enabled = True
        End If
        If mOSMSelectedEmail Is Nothing Then
            cmdOSMEditUpdateEmail.Enabled = False
            cmdOSMEditDeleteEmail.Enabled = False
            txtOSMEditEmail.Enabled = False
            txtOSMEditEmailname.Enabled = False
        Else
            cmdOSMEditUpdateEmail.Enabled = mOSMSelectedEmail.isValid
            cmdOSMEditDeleteEmail.Enabled = Not mOSMSelectedEmail.isNew
            txtOSMEditEmail.Enabled = True
            txtOSMEditEmailname.Enabled = True
        End If
    End Sub

    Private Sub lstOSMEditVessels_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstOSMEditVessels.DrawItem

        OSMListBox_DrawItem(CType(sender, ListBox), e)

    End Sub

    Private Sub lstOSMEditVessels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditVessels.SelectedIndexChanged

        If Not lstOSMEditVessels.SelectedItem Is Nothing Then
            mOSMSelectedVessel = CType(lstOSMEditVessels.SelectedItem, OSMVesselItem)
            txtOSMEditVessel.Text = mOSMSelectedVessel.ToString
            chkOSMVesselInUse.Checked = mOSMSelectedVessel.InUse
            OSMDisplayVesselGroups(lstVesselGroup, mOSMSelectedVessel.Vessel_VesselGroup)
            OSMDisplayEmails(mOSMSelectedVessel.Id, lstOSMEditToEmail, lstOSMEditCCEmail)
        End If

    End Sub

    Private Sub lstOSMEditToEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditToEmail.SelectedIndexChanged

        If Not lstOSMEditToEmail.SelectedItem Is Nothing Then
            mOSMSelectedEmail = CType(lstOSMEditToEmail.SelectedItem, OSMEmailItem)
            DisplaySelectedEmail()
            CheckValid()
        End If
    End Sub

    Private Sub cmdOSMEditUpdateEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMEditUpdateEmail.Click

        mOSMSelectedEmail.Update()
        OSMDisplayEmails(mOSMSelectedVessel.Id, lstOSMEditToEmail, lstOSMEditCCEmail)
        mOSMSelectedEmail = Nothing
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub cmdOSMEditDeleteEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMEditDeleteEmail.Click

        mOSMSelectedEmail.Delete()
        OSMDisplayEmails(mOSMSelectedVessel.Id, lstOSMEditToEmail, lstOSMEditCCEmail)
        mOSMSelectedEmail = Nothing
        DisplaySelectedEmail()
        CheckValid()

    End Sub
    Private Sub txtOSMEditEmailname_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditEmailname.TextChanged

        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Name = txtOSMEditEmailname.Text.Trim
            CheckValid()
        End If

    End Sub

    Private Sub txtOSMEditEmail_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditEmail.TextChanged

        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Email = txtOSMEditEmail.Text.Trim
            CheckValid()
        End If

    End Sub

    Private Sub cmdOSMEditExit_Click(sender As Object, e As EventArgs) Handles cmdOSMEditExit.Click

        Me.Close()

    End Sub

    Private Sub cmdOSMAddToEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMAddToEmail.Click

        mOSMSelectedEmail = New OSMEmailItem("TO", mOSMSelectedVessel.Id)
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub cmdOSMAddCCEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMAddCCEmail.Click

        mOSMSelectedEmail = New OSMEmailItem("CC", mOSMSelectedVessel.Id)
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub lstOSMEditCCEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditCCEmail.SelectedIndexChanged

        If Not lstOSMEditCCEmail.SelectedItem Is Nothing Then
            mOSMSelectedEmail = CType(lstOSMEditCCEmail.SelectedItem, OSMEmailItem)
            DisplaySelectedEmail()
            CheckValid()
        End If

    End Sub
    Private Sub DisplaySelectedEmail()

        If mOSMSelectedEmail Is Nothing Then
            lblEmailType.Text = ""
            txtOSMEditEmailname.Text = ""
            txtOSMEditEmail.Text = ""
        Else
            lblEmailType.Text = mOSMSelectedEmail.EmailType
            txtOSMEditEmailname.Text = mOSMSelectedEmail.Name
            txtOSMEditEmail.Text = mOSMSelectedEmail.Email
        End If

    End Sub
    Private Sub cmdOSMEditUpdateVessel_Click(sender As Object, e As EventArgs) Handles cmdOSMEditUpdateVessel.Click

        Try
            mOSMSelectedVessel.Update()

            OSMRefreshVessels(lstOSMEditVessels)
            CheckValid()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtOSMEditVessel_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditVessel.TextChanged

        mOSMSelectedVessel.VesselName = txtOSMEditVessel.Text.Trim
        CheckValid()

    End Sub

    Private Sub cmdOSMAddVessel_Click(sender As Object, e As EventArgs) Handles cmdOSMAddVessel.Click

        Dim pFrm As New frmOSMAddVessel

        If pFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            OSMRefreshVessels(lstOSMEditVessels)
            CheckValid()
        End If

        pFrm.Close()

    End Sub

    Private Sub chkOSMVesselInUse_CheckedChanged(sender As Object, e As EventArgs) Handles chkOSMVesselInUse.CheckedChanged

        mOSMSelectedVessel.InUse = chkOSMVesselInUse.Checked
        CheckValid()

    End Sub

    Private Sub lstVesselGroup_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstVesselGroup.ItemCheck

        Dim pItem As OSMVessel_VesselGroupItem = CType(lstVesselGroup.Items(e.Index), OSMVessel_VesselGroupItem)
        pItem.Exists = CBool(e.NewValue)

    End Sub

End Class