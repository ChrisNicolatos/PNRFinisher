Option Strict On
Option Explicit On
Public Class frmFormOSM
    Private mflgLoading As Boolean

    Private mOSMPax As New OSMPaxCollection
    Private mOSMAgentIndex As Integer = -1
    Private mOSMAgents As New OSMEmailCollection

    Private Sub cmdOSMRefresh_Click(sender As Object, e As EventArgs) Handles cmdOSMRefresh.Click

        Try
            OSMRefreshVesselGroup(cmbOSMVesselGroup)
            OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmbOSMVesselGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOSMVesselGroup.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If MySettings Is Nothing Then
                    InitSettings()
                End If
                Dim pSelectedItem As OSMVesselGroupItem
                pSelectedItem = CType(cmbOSMVesselGroup.SelectedItem, OSMVesselGroupItem)
                MySettings.OSMVesselGroup = pSelectedItem.Id
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdOSMCopyTo_Click(sender As Object, e As EventArgs) Handles cmdOSMCopyTo.Click

        Try
            Dim pstrEmail As String = ""

            For Each pSelectedAgent As OSMEmailItem In lstOSMAgents.SelectedItems
                If pstrEmail <> "" Then
                    pstrEmail &= "; "
                End If
                pstrEmail &= pSelectedAgent.ToString
            Next

            For Each pEmailTO As OSMEmailItem In lstOSMToEmail.Items
                If pstrEmail <> "" Then
                    pstrEmail &= "; "
                End If
                pstrEmail &= pEmailTO.ToString
            Next
            Clipboard.Clear()
            Clipboard.SetText(pstrEmail)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdOSMCopyCC_Click(sender As Object, e As EventArgs) Handles cmdOSMCopyCC.Click

        Try
            Dim pstrEmail As String = ""

            For Each pEmailTO As OSMEmailItem In lstOSMCCEmail.Items
                If pstrEmail <> "" Then
                    pstrEmail &= "; "
                End If
                pstrEmail &= pEmailTO.ToString
            Next
            Clipboard.Clear()
            Clipboard.SetText(pstrEmail)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdOSMCopyDocument_Click(sender As Object, e As EventArgs) Handles cmdOSMCopyDocument.Click

        Try
            Dim dobj As New DataObject
            dobj.SetData(DataFormats.Html, webOSMDoc.DocumentStream)
            Clipboard.Clear()
            Clipboard.SetDataObject(dobj)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub lstOSMVessels_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstOSMVessels.DrawItem

        Try
            OSMListBox_DrawItem(CType(sender, ListBox), e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstOSMVessels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMVessels.SelectedIndexChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    OSMShowSelectedVesselEmails()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtOSMPax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOSMPax.KeyDown

        Try
            If e.Control And e.KeyCode = Keys.A Then
                txtOSMPax.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub txtOSMText_TextChanged(sender As Object, e As EventArgs) Handles txtOSMPax.TextChanged
        Try
            OSMAnalyzePax()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMPrepareDoc_Click(sender As Object, e As EventArgs) Handles cmdOSMPrepareDoc.Click
        Try
            webOSMDoc.DocumentText = OSMWebDoc.OSMWebHeader(chkOSMFullPaxSDetails.Checked, lstOSMAgents, lstOSMToEmail, lstOSMCCEmail, lstOSMVessels, dgvOSMPax, mOSMPax)
            cmdOSMCopyDocument.Enabled = True
        Catch ex As Exception
            MessageBox.Show("cmdOSMPrepareDoc_Click()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMVesselsEdit_Click(sender As Object, e As EventArgs) Handles cmdOSMVesselsEdit.Click
        Try
            Dim pFrm As New frmOSMVessels
            pFrm.ShowDialog(Me)
            OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMAgentEdit_Click(sender As Object, e As EventArgs) Handles cmdOSMAgentEdit.Click
        Try
            Dim pFrm As New frmOSMAgents
            If pFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvOSMPax_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOSMPax.CellValueChanged
        Dim pflgLoading As Boolean = mflgLoading
        Try
            If Not mflgLoading Then
                mflgLoading = True
                If e.ColumnIndex = 5 Then
                    For i As Integer = 0 To dgvOSMPax.Rows.Count - 1
                        If i <> e.RowIndex AndAlso CStr(dgvOSMPax.Rows(i).Cells("JoinerLeaver").Value) = "ONSIGNER" AndAlso dgvOSMPax.Rows(i).Cells("VisaType").Value Is Nothing Then
                            dgvOSMPax.Rows(i).Cells("VisaType").Value = dgvOSMPax.Rows(e.RowIndex).Cells("VisaType").Value
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        Finally
            mflgLoading = pflgLoading
        End Try
    End Sub
    Private Sub cmdOSMEmailClear_Click(sender As Object, e As EventArgs) Handles cmdOSMEmailClear.Click
        Try
            txtOSMPax.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMClearSelected_Click(sender As Object, e As EventArgs) Handles cmdOSMClearSelected.Click
        Try
            mflgLoading = True
            For i As Integer = 0 To lstOSMVessels.Items.Count - 1
                lstOSMVessels.SetSelected(i, False)
            Next
            For i As Integer = 0 To lstOSMAgents.Items.Count - 1
                lstOSMAgents.SetSelected(i, False)
            Next
            mflgLoading = False
            OSMShowSelectedVesselEmails()
        Catch ex As Exception
            mflgLoading = False
            MessageBox.Show("cmdOSMClearSelected_Click()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub lstOSMAgents_MouseMove(sender As Object, e As MouseEventArgs) Handles lstOSMAgents.MouseMove
        Try
            Dim pIndex As Integer = lstOSMAgents.IndexFromPoint(e.Location)
            If pIndex >= 0 And pIndex < lstOSMAgents.Items.Count And mOSMAgentIndex <> pIndex Then
                ttpToolTip.SetToolTip(lstOSMAgents, lstOSMAgents.Items(pIndex).ToString)
                mOSMAgentIndex = pIndex
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub lstOSMAgents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMAgents.SelectedIndexChanged
        Try
            cmdOSMCopyTo.Enabled = (lstOSMToEmail.Items.Count > 0 Or lstOSMAgents.SelectedItems.Count > 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtOSMAgentsFilter_TextChanged(sender As Object, e As EventArgs) Handles txtOSMAgentsFilter.TextChanged
        Try
            lstOSMAgents.Items.Clear()
            mOSMAgentIndex = -1
            If txtOSMAgentsFilter.Text.Trim = "" Then
                For Each pAgent As OSMEmailItem In mOSMAgents.Values
                    lstOSMAgents.Items.Add(pAgent)
                Next
            Else
                Dim pFilter() As String = txtOSMAgentsFilter.Text.ToUpper.Trim.Split({"|"}, StringSplitOptions.RemoveEmptyEntries)

                For Each pAgent As OSMEmailItem In mOSMAgents.Values
                    For i As Integer = 0 To pFilter.GetUpperBound(0)
                        If pAgent.ToString.ToUpper.IndexOf(pFilter(i).Trim) >= 0 Then
                            lstOSMAgents.Items.Add(pAgent)
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkOSMVesselInUse_CheckedChanged(sender As Object, e As EventArgs) Handles chkOSMVesselInUse.CheckedChanged
        Try
            If Not mflgLoading And chkOSMVesselInUse.Visible Then
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub OSMShowSelectedVesselEmails()

        Try

            OSMDisplayEmails(lstOSMVessels, lstOSMToEmail, lstOSMCCEmail, lstOSMAgents)
            mOSMAgents.Load()
            mOSMAgentIndex = -1

            cmdOSMCopyTo.Enabled = (lstOSMToEmail.Items.Count > 0 Or lstOSMAgents.SelectedItems.Count > 0)
            cmdOSMCopyCC.Enabled = (lstOSMCCEmail.Items.Count > 0)

            lblOSMVessel.Text = ""
            txtOSMAgentsFilter.Clear()

            For Each pVessel As OSMVesselItem In lstOSMVessels.SelectedItems
                If lblOSMVessel.Text <> "" Then
                    lblOSMVessel.Text &= " / "
                End If
                lblOSMVessel.Text &= pVessel.ToString
            Next
        Catch ex As Exception
            Throw New Exception("OSMShowSelectedVesselEmails()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub OSMAnalyzePax()
        Try
            mOSMPax.Load(txtOSMPax.Text)
            dgvOSMPax.Rows.Clear()
            For Each iPax As OSMPaxItem In mOSMPax.Values
                Dim pId As New DataGridViewTextBoxCell
                Dim pLastName As New DataGridViewTextBoxCell
                Dim pFirstName As New DataGridViewTextBoxCell
                Dim pNationality As New DataGridViewTextBoxCell
                Dim pJoiner As New DataGridViewComboBoxCell
                Dim pVisaType As New DataGridViewComboBoxCell
                pId.Value = iPax.Id
                pLastName.Value = iPax.LastName
                pFirstName.Value = iPax.FirstName
                pNationality.Value = iPax.Nationality
                pJoiner.Items.AddRange({"ONSIGNER", "OFFSIGNER"})
                pVisaType.Items.AddRange({"OKTB", "VISA", "NO VISA"})
                If iPax.JoinerLeaver <> "" Then
                    pJoiner.Value = iPax.JoinerLeaver
                End If
                Dim pRow As New DataGridViewRow
                pRow.Cells.Add(pId)
                pRow.Cells.Add(pLastName)
                pRow.Cells.Add(pFirstName)
                pRow.Cells.Add(pNationality)
                pRow.Cells.Add(pJoiner)
                pRow.Cells.Add(pVisaType)
                dgvOSMPax.Rows.Add(pRow)
            Next
            dgvOSMPax.Columns(1).ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmFormOSM_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            OSMRefreshVesselGroup(cmbOSMVesselGroup)
            OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            cmdOSMCopyDocument.Enabled = False

        Catch ex As Exception

        End Try

    End Sub
End Class