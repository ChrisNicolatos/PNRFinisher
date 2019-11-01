Public Class frmFormFinisher

    Private mSelectedGDSCode As EnumGDSCode
    Private mintBackOffice As Integer ' 0=Undefined 1=ATH 2=QLI

    Private mflgLoading As Boolean
    Private mflgReadPNR As Boolean
    Private mflgAPISUpdate As Boolean
    Private mflgExpiryDateOK As Boolean

    Private WithEvents mobjPNR As GDSReadPNR
    Private mobjCustomerSelected As CustomerItem
    Private mobjVesselSelected As VesselItem
    Private mobjGender As ReferenceGenderCollection
    Private mobjAirlinePoints As AirlinePointsCollection
    Private mobjCTC As CTCPaxCollection

    Private mfrmItinHelper As frmItineraryHelper
    Private mfrmCTC As frmPaxCTC
    Private mfrmCTCPax As frmPaxCTCOnlyPax
    Private mfrmOptimiser As frmPriceOptimiser
    Private Sub cmdPNRRead1APNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRRead1APNR.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdPNRRead1GPNR_Click(sender As Object, e As EventArgs) Handles cmdPNRRead1GPNR.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Galileo
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdCostCentre_Click(sender As Object, e As EventArgs) Handles cmdCostCentre.Click
        Try
            Dim pfrmcostCentre As New frmCostCentre(mintBackOffice)
            Dim pResult As System.Windows.Forms.DialogResult
            mflgLoading = False
            pResult = pfrmcostCentre.ShowDialog()
            If pResult = Windows.Forms.DialogResult.OK Then
                txtCustomer.Text = pfrmcostCentre.CodeSelected
                txtVessel.Text = pfrmcostCentre.VesselSelected
                DisplayOldCustomProperty(cmbCostCentre, pfrmcostCentre.CostCentreSelected)
            End If
            pfrmcostCentre.Close()
        Catch ex As Exception
            MessageBox.Show("cmdCostCentre_Click()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub cmdOneTimeVessel_Click(sender As Object, e As EventArgs) Handles cmdOneTimeVessel.Click
        Try
            Dim pFrm As New frmVesselForPNR
            If pFrm.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetVesselForPNR("", "")
                    mobjPNR.NewElements.VesselName.SetText(pFrm.VesselName & If(pFrm.Registration <> "", " REG " & pFrm.Registration, ""))
                    mflgLoading = True
                    txtVessel.Text = pFrm.VesselName & If(pFrm.Registration <> "", " REG " & pFrm.Registration, "")
                    'PopulateVesselsList()
                End If
                'With mobjPNR.NewElements
                '    .SetVesselForPNR(pFrm.VesselName, pFrm.Registration)
                '    mflgLoading = True
                '    txtVessel.Text = .VesselNameForPNR.TextRequested & If(.VesselFlagForPNR.TextRequested <> "", " REG " & .VesselFlagForPNR.TextRequested, "")
                'End With
            End If
            pFrm.Dispose()
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub cmdPriceOptimiser_Click(sender As Object, e As EventArgs) Handles cmdPriceOptimiser.Click
        ShowPriceOptimiser()
    End Sub
    Private Sub cmdPNRWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRWrite.Click
        Try
            PNRWrite(True, False)
            ShowPriceOptimiser()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdPNRWriteWithDocs_Click(sender As Object, e As EventArgs) Handles cmdPNRWriteWithDocs.Click
        Try
            PNRWrite(True, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdPNROnlyDocs_Click(sender As Object, e As EventArgs) Handles cmdPNROnlyDocs.Click
        Try
            PNRWrite(False, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmbSubDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubDepartment.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If Not cmbSubDepartment.SelectedItem Is Nothing Then
                    mflgLoading = True
                    Dim pSubDepartmentItem As CustomPropertiesValues = CType(cmbSubDepartment.SelectedItem, CustomPropertiesValues)
                    mobjPNR.NewElements.SetSubDepartment(pSubDepartmentItem.Id, pSubDepartmentItem.Code, pSubDepartmentItem.Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub cmbCRM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCRM.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If Not cmbCRM.SelectedItem Is Nothing Then
                    mflgLoading = True
                    Dim pCRMItem As CustomPropertiesValues = CType(cmbCRM.SelectedItem, CustomPropertiesValues)
                    mobjPNR.NewElements.SetCRM(pCRMItem.Id, pCRMItem.Code, pCRMItem.Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub cmbBookedby_TextChanged(sender As Object, e As EventArgs) Handles cmbBookedby.TextChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetBookedBy(cmbBookedby.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmbReasonForTravel_TextChanged(sender As Object, e As EventArgs) Handles cmbReasonForTravel.TextChanged, cmbReasonForTravel.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetReasonForTravel(cmbReasonForTravel.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmbCostCentre_TextChanged(sender As Object, e As EventArgs) Handles cmbCostCentre.TextChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetCostCentre(cmbCostCentre.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtTrId_TextChanged(sender As Object, e As EventArgs) Handles txtTrId.TextChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetTRId(txtTrId.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtReference_TextChanged(sender As Object, e As EventArgs) Handles txtReference.TextChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetReference(txtReference.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmbDepartment_TextChanged(sender As Object, e As EventArgs) Handles cmbDepartment.TextChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetDepartment(cmbDepartment.Text)
                End If
            End If
            SetEnabled()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing And (txtCustomer.Text.Length = 0 Or txtCustomer.Text.Length > 2) Then
                    PopulateCustomerList(txtCustomer.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged
        Try
            If lstCustomers.SelectedIndex >= 0 Then
                mflgLoading = True
                Dim pCust As CustomerItem = CType(lstCustomers.SelectedItem, CustomerItem)
                SelectCustomer(pCust)
                txtCustomer.Text = lstCustomers.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub

    Private Sub txtVessel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVessel.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    mobjPNR.NewElements.SetVesselForPNR("", "")
                    mobjPNR.NewElements.VesselName.SetText(txtVessel.Text)
                    PopulateVesselsList()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstVessels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVessels.SelectedIndexChanged

        Try
            If lstVessels.SelectedIndex >= 0 Then
                mflgLoading = True
                Dim pVesselItem As VesselItem = CType(lstVessels.SelectedItem, VesselItem)
                SelectVessel(pVesselItem)
                txtVessel.Text = lstVessels.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub cmdAPISEditPax_Click(sender As Object, e As EventArgs) Handles cmdAPISEditPax.Click

        Try
            Dim pFrm As New frmAPISPax
            If pFrm.ShowDialog(Me) = DialogResult.OK Then
                APISDisplayPax()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdItineraryHelper_Click(sender As Object, e As EventArgs) Handles cmdItineraryHelper.Click

        Try
            If mfrmItinHelper.IsDisposed Then
                mfrmItinHelper = New frmItineraryHelper(mintBackOffice)
            End If
            mfrmItinHelper.Location = Me.Location
            mfrmItinHelper.DisplayItinerary(mobjPNR.Itinerary)
            mfrmItinHelper.Show()
            mfrmItinHelper.BringToFront()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dgvApis_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApis.CellValueChanged
        Try
            dgvApis.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dgvApis.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.ToUpper
        Catch ex As Exception

        End Try
        APISValidateDataRow(dgvApis.Rows(e.RowIndex))
    End Sub
    Private Sub dgvApis_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvApis.CurrentCellDirtyStateChanged
        cmdPNROnlyDocs.Enabled = False
        cmdPNRWriteWithDocs.Enabled = False
    End Sub
    Private Sub dgvApis_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvApis.RowValidating
        APISValidateDataRow(dgvApis.Rows(e.RowIndex))
    End Sub
    Private Sub cmdCTCForm_Click(sender As Object, e As EventArgs) Handles cmdCTCForm.Click

        Try
            Dim pClientId As Integer = 0
            Dim pClientCode As String = ""
            Dim pClientName As String = ""
            Dim pVessel As String = ""
            If Not mobjCustomerSelected Is Nothing AndAlso mobjCustomerSelected.ID > 0 Then
                pClientId = mobjCustomerSelected.ID
                pClientCode = mobjCustomerSelected.Code
                pClientName = mobjCustomerSelected.Name
            End If
            If Not mobjVesselSelected Is Nothing Then
                pVessel = mobjVesselSelected.Name
            End If

            If pClientCode = "" Or mobjPNR.Passengers.Count = 0 Then
                If mfrmCTC Is Nothing OrElse mfrmCTC.IsDisposed Then
                    mfrmCTC = New frmPaxCTC
                End If
                mfrmCTC.Location = Me.Location
                mfrmCTC.ShowPaxInformation()
                mfrmCTC.ShowDialog()
            Else
                If mfrmCTCPax Is Nothing OrElse mfrmCTCPax.IsDisposed Then
                    mfrmCTCPax = New frmPaxCTCOnlyPax
                End If
                mfrmCTCPax.Location = Me.Location
                mfrmCTCPax.ShowPaxInformation(mobjPNR, mintBackOffice, pClientId, pClientCode, pClientName, pVessel)
                mfrmCTCPax.ShowDialog()
                PrepareAdditionalEntries()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PNRReadPNR()
        Try
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            ClearForm()
            ReadPNR()
            ShowPriceOptimiser()
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As GDSExistingItem)
        Try
            If Item.Key <> "" Then
                If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
                    If Item.Key <> "" Then
                        cmbList.Text = Item.Key
                    End If
                Else
                    For i As Integer = 0 To cmbList.Items.Count - 1
                        If Item.Key.ToUpper = cmbList.Items(i).ToString.ToUpper Then
                            cmbList.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As GDSExisting.Item)" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DisplayOldCustomProperty(ByRef txtText As TextBox, ByVal Item As GDSExistingItem)
        Try
            txtText.Text = Item.Key
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef txtText As TextBox, ByVal Item As GDSExisting.Item)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As String)
        Try
            If Item <> "" Then
                If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
                    cmbList.Text = Item
                Else
                    For i As Integer = 0 To cmbList.Items.Count - 1
                        If cmbList.Items(i).ToString.ToUpper.StartsWith(Item.ToUpper) Then
                            cmbList.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As String)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SetEnabled()

        Dim pProps As CustomPropertiesItem

        Try
            ' read PNR and Exit are always enabled
            cmdPNRRead1APNR.Enabled = True
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False
            cmdPriceOptimiser.Enabled = False
            cmdPriceOptimiser.Visible = False
            If Not MySettings Is Nothing Then
                If MySettings.PriceOptimiser And mflgReadPNR Then
                    cmdPriceOptimiser.Enabled = True
                End If
            End If
            cmdPriceOptimiser.Visible = cmdPriceOptimiser.Enabled

            ' customer based entries are enabled if a PNR has been read and there is data available
            txtCustomer.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            lstCustomers.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            cmdCostCentre.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)

            txtVessel.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)
            lstVessels.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)

            ' the exception is the one time vessel which is always enabled for any PNR
            cmdOneTimeVessel.Enabled = mflgReadPNR

            ' Update is enabled if a PNR has been read and if mandatory fields have been entered
            cmdPNRWrite.Enabled = mflgReadPNR

            ' Customer is always needed

            txtCustomer.BackColor = lstCustomers.BackColor
            If Not mobjPNR Is Nothing Then
                If Not mobjPNR.NewElements Is Nothing Then
                    If mobjPNR.NewElements.CustomerCode.GDSCommand = "" Then
                        cmdPNRWrite.Enabled = False
                        txtCustomer.BackColor = Color.Red
                    End If

                    If mobjPNR.NewElements.BookedBy.GDSCommand = "" Then
                        lblBookedBy.Text = ""
                        If cmbBookedby.Enabled Then
                            pProps = CType(cmbBookedby.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblBookedBy.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    If mobjPNR.NewElements.CostCentre.GDSCommand = "" Then
                        lblCostCentre.Text = ""
                        If cmbCostCentre.Enabled Then
                            pProps = CType(cmbCostCentre.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblCostCentre.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    If mobjPNR.NewElements.SubDepartmentCode.GDSCommand = "" Then
                        lblSubDepartment.Text = ""
                        If cmbSubDepartment.Enabled Then
                            pProps = CType(cmbSubDepartment.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblSubDepartment.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    If mobjPNR.NewElements.CRMCode.GDSCommand = "" Then
                        lblCRM.Text = ""
                        If cmbCRM.Enabled Then
                            pProps = CType(cmbCRM.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblCRM.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    If mobjPNR.NewElements.Reference.GDSCommand = "" Then
                        lblReference.Text = ""
                        If txtReference.Enabled Then
                            pProps = CType(txtReference.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblReference.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If

                        End If
                    End If
                    If mobjPNR.NewElements.Department.GDSCommand = "" Then
                        lblDepartment.Text = ""
                        If cmbDepartment.Enabled Then
                            pProps = CType(cmbDepartment.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblDepartment.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    If mobjPNR.NewElements.ReasonForTravel.GDSCommand = "" Then
                        lblReasonForTravel.Text = ""
                        If cmbReasonForTravel.Enabled Then
                            pProps = CType(cmbReasonForTravel.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblReasonForTravel.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                    If mobjPNR.NewElements.TRId.GDSCommand = "" Then
                        lblTRID.Text = ""
                        If txtTrId.Enabled Then
                            pProps = CType(txtTrId.Tag, CustomPropertiesItem)
                            If Not pProps Is Nothing Then
                                lblTRID.Text = pProps.Label
                                If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                    cmdPNRWrite.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
                cmdPNRWriteWithDocs.Enabled = cmdPNRWrite.Enabled And mflgAPISUpdate
                cmdPNROnlyDocs.Enabled = mflgAPISUpdate And Not mobjPNR.NewPNR
            End If

            dgvApis.Enabled = True

            lblSubDepartment.Enabled = (cmbSubDepartment.Enabled)
            lblCRM.Enabled = (cmbCRM.Enabled)
            lblReference.Enabled = (txtReference.Enabled)
            lblBookedBy.Enabled = (cmbBookedby.Enabled)
            lblDepartment.Enabled = (cmbDepartment.Enabled)
            lblReasonForTravel.Enabled = (cmbReasonForTravel.Enabled)
            lblCostCentre.Enabled = (cmbCostCentre.Enabled)
            lblTRID.Enabled = (txtTrId.Enabled)

            SetLabelColor(lblSubDepartment, CType(cmbSubDepartment.Tag, CustomPropertiesItem))
            SetLabelColor(lblCRM, CType(cmbCRM.Tag, CustomPropertiesItem))
            SetLabelColor(lblReference, CType(txtReference.Tag, CustomPropertiesItem))
            SetLabelColor(lblBookedBy, CType(cmbBookedby.Tag, CustomPropertiesItem))
            SetLabelColor(lblDepartment, CType(cmbDepartment.Tag, CustomPropertiesItem))
            SetLabelColor(lblReasonForTravel, CType(cmbReasonForTravel.Tag, CustomPropertiesItem))
            SetLabelColor(lblCostCentre, CType(cmbCostCentre.Tag, CustomPropertiesItem))
            SetLabelColor(lblTRID, CType(txtTrId.Tag, CustomPropertiesItem))


        Catch ex As Exception
            Throw New Exception("SetEnabled()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ShowPriceOptimiser()

        If Not MySettings Is Nothing Then
            If MySettings.PriceOptimiser Then
                If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                    Dim pPCC As String = MySettings.GDSPcc
                    Dim pUserId As String = MySettings.GDSUser
                    ' for testing only
#If DEBUG Then
                    'pPCC = "750B"
                    'pUserId = "074866"
#End If
                    If mfrmOptimiser Is Nothing OrElse mfrmOptimiser.IsDisposed Then
                        mfrmOptimiser = New frmPriceOptimiser
                    End If
                    mfrmOptimiser.DisplayItems(pPCC, pUserId, Me.Height, Me.Width)
                    If mfrmOptimiser.FormIsExpanded Then
                        mfrmOptimiser.Show()
                        mfrmOptimiser.BringToFront()
                    End If
                    'End If
                End If
            End If
        End If
    End Sub
    Private Function PNRWrite(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean) As String

        Try
            PNRWrite = UpdatePNR(WritePNR, WriteDocs)
            If mSelectedGDSCode = EnumGDSCode.Galileo And PNRWrite.Length > 6 Then
                MessageBox.Show("Please enter *R or *ALL in Galileo to show the PNR" & If(PNRWrite <> "", vbCrLf & vbCrLf & "PNR: " & PNRWrite, ""), "Galileo Information for PNR")
            End If
            mflgReadPNR = False
            ClearForm()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("PNRWrite(" & WritePNR & ", " & WriteDocs & ")" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Sub ShowOptionsForm()
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function CheckOptions() As Boolean
        Try
            With MySettings
                While Not .isValid
                    If MessageBox.Show("Please enter your details", "Options Missing", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    End If
                    ShowOptionsForm()
                End While
                Return True
            End With
        Catch ex As Exception
            Throw New Exception("CheckOptions()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Sub PopulateCustomerList(ByVal SearchString As String)

        Try
            Dim pCustomers As New CustomerCollection

            pCustomers.Load(SearchString, mintBackOffice)

            lstCustomers.Items.Clear()
            For Each pItem As CustomerItem In pCustomers.Values
                If SearchString = "" Or pItem.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                    lstCustomers.Items.Add(pItem)
                End If
            Next

            If lstCustomers.Items.Count = 1 Then
                Try
                    mflgLoading = True
                    Dim pCust As CustomerItem = CType(lstCustomers.Items(0), CustomerItem)
                    SelectCustomer(pCust)
                    txtCustomer.Text = lstCustomers.Items(0).ToString
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    mflgLoading = False
                End Try
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCustomerList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateVesselsList()

        Try
            Dim pobjVessels As New VesselCollection

            lstVessels.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then

                pobjVessels.Load(mobjCustomerSelected.ID, mintBackOffice)

                For Each pVessel As VesselItem In pobjVessels.Values
                    If mobjPNR.NewElements.VesselName.TextRequested = "" Or pVessel.ToString.ToUpper.Contains(mobjPNR.NewElements.VesselName.TextRequested.ToUpper) Then
                        lstVessels.Items.Add(pVessel)
                    End If
                Next
                If lstVessels.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pVesselItem As VesselItem = CType(lstVessels.Items(0), VesselItem)
                        SelectVessel(pVesselItem)
                        txtVessel.Text = lstVessels.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateVesselsList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectCustomer(ByVal pCustomer As CustomerItem)

        Try
            mobjPNR.NewElements.ClearCustomerElements()
            mobjCustomerSelected = pCustomer
            txtCustomer.Text = pCustomer.ToString
            mobjPNR.NewElements.SetItem(mobjCustomerSelected, mintBackOffice)

            cmbSubDepartment.Items.Clear()

            cmbCRM.Items.Clear()

            txtVessel.Clear()
            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            txtReference.Clear()

            cmbSubDepartment.Text = ""
            cmbCRM.Text = ""
            cmbBookedby.Text = ""
            cmbDepartment.Text = ""
            txtTrId.Clear()

            If mobjCustomerSelected.HasVessels Then
                PopulateVesselsList()
            End If

            PopulateCustomProperties()
            PrepareAdditionalEntries()

            SetEnabled()

            If pCustomer.AlertForFinisher <> "" Then
                MessageBox.Show(pCustomer.AlertForFinisher, pCustomer.Code & " " & pCustomer.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectCustomer()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectVessel(ByVal pVessel As VesselItem)

        Try
            mobjVesselSelected = pVessel
            txtVessel.Text = pVessel.ToString
            mobjPNR.NewElements.SetItem(mobjVesselSelected)
            PrepareAdditionalEntries()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectVessel()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub APISDisplayPax()
        If mobjPNR.SSRDocsExists Then
            txtPNRApis.Location = dgvApis.Location
            txtPNRApis.Size = dgvApis.Size
            txtPNRApis.Text = mobjPNR.SSRDocs
            txtPNRApis.BackColor = Color.Aqua
            txtPNRApis.ForeColor = Color.Blue
            txtPNRApis.Visible = True
            txtPNRApis.BringToFront()
            cmdAPISEditPax.Enabled = False
        Else
            txtPNRApis.Visible = False
            Dim pobjPaxApis As New ApisPaxCollection
            dgvApis.Rows.Clear()
            For Each pobjPax As GDSPaxItem In mobjPNR.Passengers.Values
                Dim pobjPaxItem As New ApisPaxItem(pobjPax.LastName, pobjPax.Initial)
                pobjPaxApis.Read(pobjPax.LastName, APISModifyFirstName(pobjPax.Initial))
                If pobjPaxApis.Count = 0 Then
                    APISAddRow(dgvApis, pobjPax.ElementNo, pobjPax.LastName, pobjPax.Initial, "", "", "", Date.MinValue, "", Date.MinValue)
                Else
                    If pobjPaxApis.Count > 1 Then
                        Dim pFrm As New frmAPISPaxSelect(pobjPax.ElementNo, pobjPax.LastName, pobjPax.Initial, pobjPaxApis)
                        If pFrm.ShowDialog(Me) = DialogResult.OK Then
                            pobjPaxItem = pFrm.SelectedPassenger
                        End If
                    Else
                        pobjPaxItem = pobjPaxApis.Values(0)
                    End If
                    APISAddRow(dgvApis, pobjPax.ElementNo, pobjPax.LastName, pobjPax.Initial, pobjPaxItem.IssuingCountry, pobjPaxItem.PassportNumber, pobjPaxItem.Nationality, pobjPaxItem.BirthDate, pobjPaxItem.Gender, pobjPaxItem.ExpiryDate)
                End If
                APISValidateDataRow(dgvApis.Rows(dgvApis.RowCount - 1))
            Next
            cmdAPISEditPax.Enabled = True
        End If
    End Sub
    Public Sub APISValidateDataRow(ByVal Row As DataGridViewRow)
        Dim pdteDate As DateTime
        Dim pflgGenderFound As Boolean = False
        Dim pflgBirthDateOK As Boolean = False
        Dim pflgPassportNumberOK As Boolean = False
        Dim pstrErrorText As String = ""

        pflgPassportNumberOK = (CStr(Row.Cells("PassportNumber").Value).Trim.Length > 0)
        If Not Date.TryParse(Row.Cells("Birthdate").Value.ToString, pdteDate) Then
            pdteDate = DateFromIATA(Row.Cells("Birthdate").Value.ToString)
            If pdteDate > Date.MinValue Then
                pflgBirthDateOK = True
            Else
                pflgBirthDateOK = False
            End If
        Else
            pflgBirthDateOK = True
        End If
        If Not Date.TryParse(CStr(Row.Cells("ExpiryDate").Value), pdteDate) Then
            pdteDate = DateFromIATA(CStr(Row.Cells("ExpiryDate").Value))
        End If
        If pdteDate > Now Then
            mflgExpiryDateOK = True
        Else
            mflgExpiryDateOK = False
        End If
        If mobjGender Is Nothing Then
            mobjGender = New ReferenceGenderCollection
        End If
        pflgGenderFound = False
        For Each pGenderItem As ReferenceItem In mobjGender.Values
            If CStr(Row.Cells("Gender").Value) = pGenderItem.Code Then
                pflgGenderFound = True
                Exit For
            End If
        Next
        mflgAPISUpdate = mflgAPISUpdate Or (Not mobjPNR.SSRDocsExists And mobjPNR.SegmentsExist And pflgBirthDateOK And pflgGenderFound) '  And pflgPassportNumberOK)
        If Not pflgBirthDateOK Then
            pstrErrorText &= "Invalid birth date" & vbCrLf
        End If
        If Not pflgGenderFound Then
            pstrErrorText &= "Invalid gender" & vbCrLf
        End If
        If Not pflgPassportNumberOK Then
            pstrErrorText &= "Passport number missing" & vbCrLf
        End If
        If Not mflgExpiryDateOK Then
            pstrErrorText &= "Invalid expiry date" & vbCrLf
        End If
        If mobjPNR.SSRDocsExists Then
            lblSSRDocs.Text = "SSR DOCS already exist in the PNR"
            lblSSRDocs.BackColor = Color.Red
            cmdAPISEditPax.Enabled = False
        Else
            If mobjPNR.SegmentsExist Then
                lblSSRDocs.Text = "SSR DOCS"
                lblSSRDocs.BackColor = Color.Yellow
                cmdAPISEditPax.Enabled = True
            Else
                lblSSRDocs.Text = "SSR DOCS cannot be updated - No segments in PNR"
                lblSSRDocs.BackColor = Color.Red
                cmdAPISEditPax.Enabled = False
            End If
        End If
        Row.ErrorText = pstrErrorText
        SetEnabled()

    End Sub
    Private Sub PrepareAdditionalEntries()
        lstGDSEntries.Items.Clear()
        ShowNewItems
        PrepareAirlinePoints()
        If Not mobjPNR.SSRCTCExists Then
            PrepareCTC()
        End If
    End Sub
    Private Sub ReadPNR()
        Dim pDMI As String
        Try
            With mobjPNR
                mflgReadPNR = False
                Dim mGDSUser As New GDSUser(mSelectedGDSCode)
                mintBackOffice = InitSettings(mGDSUser, mintBackOffice)
                SetupPCCOptions()
                pDMI = .Read(mSelectedGDSCode)
                If .NumberOfPax = 0 And Not .IsGroup Then
                    Throw New Exception("Need passenger names")
                End If
                If pDMI <> "" Then
                    lblWarning.Text = pDMI
                    lblWarning.BackColor = Color.OrangeRed
                    tmrWarning.Enabled = True
                    'If MessageBox.Show("There is a problem with your itinerary. Do you want to cancel the PNR Finisher?" & vbCrLf & vbCrLf & pDMI, "Itinerary Check", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    '    Throw New Exception("PNR Finisher cancelled because of itinerary check")
                    'End If
                Else
                    lblWarning.Text = ""
                    lblWarning.BackColor = Color.FromKnownColor(KnownColor.Control)
                    tmrWarning.Enabled = False
                End If

                mflgReadPNR = True
                .PrepareNewGDSElements()
                lblPNR.Text = .PnrNumber
                If .IsGroup Then
                    lblPax.Text = "Group:" & .GroupName & " " & .GroupNamesCount
                Else
                    lblPax.Text = .PaxLeadName
                End If

                lblSegs.Text = .Itinerary
                If .Segments.AirlineAlert <> "" Then
                    MessageBox.Show(.Segments.AirlineAlert, "AIRLINE ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                PrepareAdditionalEntries()
            End With
            DisplayCustomer()
            APISDisplayPax()

        Catch ex As Exception
            Throw New Exception("ReadPNR()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ClearForm()

        Dim pLoading As Boolean = mflgLoading

        Try
            mflgLoading = True
            mobjCustomerSelected = New CustomerItem
            mobjVesselSelected = New VesselItem

            If Not mfrmCTC Is Nothing Then
                mfrmCTC.Dispose()
            End If
            If Not mfrmCTCPax Is Nothing Then
                mfrmCTCPax.Dispose()
            End If
            lblWarning.Text = ""
            lblWarning.BackColor = Color.FromKnownColor(KnownColor.Control)
            tmrWarning.Enabled = False
            lblPNR.Text = ""
            lblPax.Text = ""
            lblSegs.Text = ""

            If mintBackOffice = 1 Then
                optClientATH.Checked = True
            ElseIf mintBackOffice = 2 Then
                optClientQLI.Checked = True
            Else
                optClientATH.Checked = False
                optClientQLI.Checked = False
            End If
            txtCustomer.Clear()
            lstCustomers.Items.Clear()
            txtVessel.Clear()
            lstVessels.Items.Clear()
            lstGDSEntries.Items.Clear()
            If mSelectedGDSCode = EnumGDSCode.Galileo Then
                lstGDSEntries.BackColor = Color.Gray
                lstGDSEntries.ForeColor = Color.White
                Dim pFont As New Font("Consolas", 10)
                lstGDSEntries.Font = pFont
            Else
                lstGDSEntries.BackColor = Color.Aqua
                lstGDSEntries.ForeColor = Color.Blue
                Dim pFont As New Font("Courier New", 8)
                lstGDSEntries.Font = pFont
            End If

            txtReference.Clear()
            cmbSubDepartment.Items.Clear()
            cmbSubDepartment.Text = ""
            cmbSubDepartment.Tag = Nothing
            cmbCRM.Items.Clear()
            cmbCRM.Text = ""
            cmbCRM.Tag = Nothing
            cmbDepartment.Items.Clear()
            cmbDepartment.Text = ""
            cmbDepartment.Tag = Nothing
            cmbBookedby.Items.Clear()
            cmbBookedby.Text = ""
            cmbBookedby.Tag = Nothing
            cmbReasonForTravel.Items.Clear()
            cmbReasonForTravel.Text = ""
            cmbReasonForTravel.Tag = Nothing
            cmbCostCentre.Items.Clear()
            cmbCostCentre.Text = ""
            cmbCostCentre.Tag = Nothing
            txtTrId.Clear()
            txtTrId.Tag = Nothing

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False
            cmdPriceOptimiser.Enabled = False
            If Not MySettings Is Nothing AndAlso MySettings.PriceOptimiser Then
                cmdPriceOptimiser.Visible = True
            Else
                cmdPriceOptimiser.Visible = False
            End If

            mobjPNR.ExistingElements.Clear()
            mobjPNR.NewElements.Clear()

            mflgAPISUpdate = False
            mflgExpiryDateOK = False

            PopulateCustomProperties()
            APISPrepareGrid(dgvApis)
            SetEnabled()

        Catch ex As Exception
            Throw New Exception("ClearForm()" & vbCrLf & ex.Message)
        Finally
            mflgLoading = pLoading
        End Try

    End Sub
    Private Sub SetLabelColor(ByRef TextLabel As Label, ByVal CustomProps As CustomPropertiesItem)
        Try
            If TextLabel.Enabled Then
                If Not CustomProps Is Nothing AndAlso CustomProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                    TextLabel.BackColor = Color.FromArgb(255, 128, 128)
                Else
                    TextLabel.BackColor = Color.Cyan
                End If
            Else
                TextLabel.BackColor = Color.Silver
            End If
        Catch ex As Exception
            Throw New Exception("SetLabelColor()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function UpdatePNR(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean) As String
        Dim pResponse As String = ""
        Try
            pResponse = mobjPNR.SendAllGDSEntriesFromList(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, lstGDSEntries)
            Dim pPNR As String = mobjPNR.PnrNumber
            Dim pNewEntry = False
            If pPNR = "New PNR" Or pPNR = "" Then
                If pResponse.LastIndexOf(" ") > -1 Then
                    pPNR = pResponse.Substring(pResponse.LastIndexOf(" ")).Trim
                ElseIf pResponse.Length = 6 Then
                    pPNR = pResponse
                End If
                pNewEntry = True
            End If
            Dim pClient As String = mobjPNR.ClientCode
            If pClient = "" Then
                pClient = mobjPNR.NewElements.CustomerCode.TextRequested
            End If
            If pPNR <> "" Then
                PNRFinisherTransactions.UpdateTransactions(pPNR, MySettings.GDSAbbreviation, MySettings.GDSPcc, MySettings.GDSUser, Now, mobjPNR.Passengers.AllPassengers, mobjPNR.Segments.FullItinerary, "", pClient, pNewEntry)
            End If
        Catch ex As Exception
            Throw New Exception("UpdatePNR()" & vbCrLf & ex.Message)
        End Try
        Return pResponse
    End Function
    Private Sub PopulateCustomProperties()

        Try
            tabCustomProperties.SuspendLayout()
            cmbSubDepartment.Items.Clear()
            cmbCRM.Items.Clear()
            cmbBookedby.Items.Clear()
            cmbDepartment.Items.Clear()
            cmbReasonForTravel.Items.Clear()
            cmbCostCentre.Items.Clear()
            cmbSubDepartment.Enabled = False
            cmbCRM.Enabled = False
            cmbBookedby.Enabled = False
            cmbDepartment.Enabled = False
            cmbReasonForTravel.Enabled = False
            cmbCostCentre.Enabled = False
            txtReference.Enabled = False
            txtTrId.Enabled = False

            If Not mobjCustomerSelected Is Nothing AndAlso mobjCustomerSelected.ID > 0 Then
                For Each pProp As CustomPropertiesItem In mobjCustomerSelected.CustomerProperties.Values
                    If pProp.CustomPropertyID = EnumCustomPropertyID.SubDepartment Then
                        PrepareCustomProperty(cmbSubDepartment, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.CRM Then
                        PrepareCustomProperty(cmbCRM, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.Reference Then
                        PrepareCustomProperty(txtReference, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.BookedBy Then
                        PrepareCustomProperty(cmbBookedby, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.Department Then
                        PrepareCustomProperty(cmbDepartment, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.ReasonFortravel Then
                        PrepareCustomProperty(cmbReasonForTravel, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.CostCentre Then
                        PrepareCustomProperty(cmbCostCentre, pProp)
                    ElseIf pProp.CustomPropertyID = EnumCustomPropertyID.TRId Then
                        PrepareCustomProperty(txtTrId, pProp)
                    End If
                Next
            End If
            cmbSubDepartment.Visible = cmbSubDepartment.Enabled
            cmbCRM.Visible = cmbCRM.Enabled
            cmbBookedby.Visible = cmbBookedby.Enabled
            cmbDepartment.Visible = cmbDepartment.Enabled
            cmbReasonForTravel.Visible = cmbReasonForTravel.Enabled
            cmbCostCentre.Visible = cmbCostCentre.Enabled
            txtReference.Visible = txtReference.Enabled
            txtTrId.Visible = txtTrId.Enabled
        Catch ex As Exception
            Throw New Exception("PopulateCustomproperties()" & vbCrLf & ex.Message)
        Finally
            tabCustomProperties.ResumeLayout()
        End Try

    End Sub
    Private Sub PrepareAirlinePoints()
        Try
            Dim pFound As Boolean = False
            If Not mobjAirlinePoints Is Nothing Then
                mobjAirlinePoints = New AirlinePointsCollection
            End If
            If mobjCustomerSelected.ID <> 0 Then
                For Each pSeg As GDSSegItem In mobjPNR.Segments.Values
                    mobjAirlinePoints.Load(mobjCustomerSelected.ID, pSeg.Airline, mobjPNR.GDSCode, mintBackOffice)
                    For Each pItem As String In mobjAirlinePoints
                        pFound = False
                        For i As Integer = 0 To lstGDSEntries.Items.Count - 1
                            If lstGDSEntries.Items(i).ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstGDSEntries.Items.Add(pItem, True)
                        End If
                    Next
                Next
            End If

            If mflgReadPNR Then
                Dim pAirlineNotes As New AirlineNotesCollection
                For Each pSeg As GDSSegItem In mobjPNR.Segments.Values
                    pAirlineNotes.Load(pSeg.Airline, mobjPNR.GDSCode)
                    For Each pItem As AirlineNotesItem In pAirlineNotes.Values
                        With pItem
                            If Not .Seaman Or Not mobjVesselSelected Is Nothing Then
                                Dim pGDSText As String = .GDSEntry

                                If pGDSText.Contains("<?VESSEL NAME>") Then
                                    If Not mobjVesselSelected Is Nothing Then
                                        If mobjVesselSelected.Name Is Nothing Then
                                            pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.Name)
                                        Else
                                            pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.Name.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                        End If
                                    End If
                                End If

                                If pGDSText.Contains("<?VESSEL REGISTRATION>") Then
                                    If Not mobjVesselSelected Is Nothing Then
                                        If mobjVesselSelected.Flag Is Nothing Then
                                            pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.Flag)
                                        Else
                                            pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.Flag.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                        End If
                                    End If
                                End If

                                If pGDSText.Contains("<?NBR OF PSGRS>") Then
                                    pGDSText = pGDSText.Replace("<?NBR OF PSGRS>", CStr(mobjPNR.NumberOfPax))
                                End If

                                If pGDSText.Contains("<?Segment selection>") Then
                                    pGDSText = pGDSText.Replace("<?Segment selection>", CStr(pSeg.ElementNo))
                                End If

                                Dim pGDSCommand As String = pGDSText
                                pFound = False
                                For i As Integer = 0 To lstGDSEntries.Items.Count - 1
                                    If lstGDSEntries.Items(i).ToString = pGDSCommand Then
                                        pFound = True
                                        Exit For
                                    End If
                                Next
                                If Not pFound Then
                                    lstGDSEntries.Items.Add(pGDSCommand, True)
                                End If

                            End If
                        End With
                    Next
                Next

                If Not mobjCustomerSelected Is Nothing And Not mobjVesselSelected Is Nothing Then
                    Dim pConditionalEntry As New ConditionalGDSEntryCollection
                    pConditionalEntry.Load(mintBackOffice, mobjCustomerSelected.ID, mobjVesselSelected.Name)
                    For Each pItem As ConditionalGDSEntryItem In pConditionalEntry.Values
                        Dim pGDSCommand As String = ""
                        If mSelectedGDSCode = EnumGDSCode.Amadeus Then
                            pGDSCommand = pItem.ConditionalEntry1A
                        ElseIf mSelectedGDSCode = EnumGDSCode.Galileo Then
                            pGDSCommand = pItem.ConditionalEntry1G
                        Else
                            pGDSCommand = ""
                        End If
                        If pGDSCommand <> "" Then
                            pFound = False
                            For i As Integer = 0 To lstGDSEntries.Items.Count - 1
                                If lstGDSEntries.Items(i).ToString = pGDSCommand Then
                                    pFound = True
                                    Exit For
                                End If
                            Next
                            If Not pFound Then
                                lstGDSEntries.Items.Add(pGDSCommand, True)
                            End If

                        End If

                    Next
                End If
            End If
        Catch aex As System.ArgumentOutOfRangeException
            MessageBox.Show(aex.Message)
        Catch ex As Exception
            Throw New Exception("PrepareAirlinePoints()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PrepareCTC()
        Try
            Dim pFound As String = ""
            Dim pNotFound As String = ""
            If Not mobjCTC Is Nothing Then
                mobjCTC = New CTCPaxCollection
            End If
            mobjCTC.Load(mintBackOffice, mobjCustomerSelected.ID)
            For Each pPax As GDSPaxItem In mobjPNR.Passengers.Values
                Dim pCTCCommand() As String = {""}
                Dim pCTCFound As Boolean = False
                For Each pCTC As CTCPax In mobjCTC.Values
                    If pPax.FirstName = pCTC.FirstName And pPax.LastName = pCTC.Lastname Then
                        pCTCCommand = PrepareCTCCommand(pPax.ElementNo, pCTC)
                        pCTCFound = (pCTCCommand(0) <> "")
                        Exit For
                    End If
                Next
                If Not pCTCFound Then
                    For Each pCTC As CTCPax In mobjCTC.Values
                        If pCTC.Vesselname = mobjPNR.VesselName And pCTC.FirstName = "" And pCTC.Lastname = "" Then
                            pCTCCommand = PrepareCTCCommand(pPax.ElementNo, pCTC)
                            pCTCFound = (pCTCCommand(0) <> "")
                            Exit For
                        End If
                    Next
                End If
                If Not pCTCFound Then
                    For Each pCTC As CTCPax In mobjCTC.Values
                        If pCTC.Vesselname = "" And pCTC.FirstName = "" And pCTC.Lastname = "" Then
                            pCTCCommand = PrepareCTCCommand(pPax.ElementNo, pCTC)
                            pCTCFound = (pCTCCommand(0) <> "")
                            Exit For
                        End If
                    Next
                End If
                If pCTCFound Then
                    For i As Integer = 0 To pCTCCommand.GetUpperBound(0)
                        If pCTCCommand(i) <> "" Then
                            lstGDSEntries.Items.Add(pCTCCommand(i), True)
                        End If
                    Next
                    pFound &= pPax.ElementNo & " "
                Else
                    pNotFound &= pPax.ElementNo & " "
                End If
            Next

            Dim pSSR As Boolean = False
            If mflgReadPNR AndAlso mobjPNR.SSRCTCExists Then
                pSSR = True
            End If
            SetCTCExists(pSSR, pFound, pNotFound)

        Catch ex As Exception
            Throw New Exception("PrepareCTC()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DisplayCustomer()

        Dim pstrCustomerCode As String
        Dim pintSubDepartment As Integer
        Dim pstrCRM As String
        Dim pstrVesselName As String
        Dim pstrVesselRegistration As String

        Try
            With mobjPNR.ExistingElements
                pstrCustomerCode = .CustomerCode.Key
                pintSubDepartment = If(IsNumeric(.SubDepartmentCode.Key), CInt(.SubDepartmentCode.Key), 0)
                pstrCRM = .CRMCode.Key
                pstrVesselName = .VesselName.Key
                pstrVesselRegistration = .VesselFlag.Key

                mobjPNR.NewElements.ClearCustomerElements()

                txtCustomer.Clear()
                txtVessel.Clear()
            End With

            If pstrCustomerCode <> "" Then
                Dim pCustomer As New CustomerItem
                pCustomer.Load(pstrCustomerCode, mintBackOffice)
                txtCustomer.Text = pCustomer.Code
                If pstrVesselName <> "" Then
                    Dim pVessel As New VesselItem
                    If pVessel.Load(pstrCustomerCode, pstrVesselName, mintBackOffice) Then
                        mobjPNR.NewElements.VesselNameForPNR.Clear()
                        mobjPNR.NewElements.VesselFlagForPNR.Clear()
                        txtVessel.Text = pVessel.Name
                    Else
                        mobjPNR.NewElements.SetVesselForPNR(pstrVesselName, pstrVesselRegistration)
                        txtVessel.Text = mobjPNR.NewElements.VesselNameForPNR.TextRequested & " REG " & mobjPNR.NewElements.VesselFlagForPNR.TextRequested
                    End If
                End If
                DisplayOldCustomProperty(cmbSubDepartment, mobjPNR.ExistingElements.SubDepartmentCode)
                DisplayOldCustomProperty(cmbCRM, mobjPNR.ExistingElements.CRMCode)
                DisplayOldCustomProperty(txtReference, mobjPNR.ExistingElements.Reference)
                DisplayOldCustomProperty(cmbBookedby, mobjPNR.ExistingElements.BookedBy)
                DisplayOldCustomProperty(cmbDepartment, mobjPNR.ExistingElements.Department)
                DisplayOldCustomProperty(cmbReasonForTravel, mobjPNR.ExistingElements.ReasonForTravel)
                DisplayOldCustomProperty(cmbCostCentre, mobjPNR.ExistingElements.CostCentre)
                DisplayOldCustomProperty(txtTrId, mobjPNR.ExistingElements.TRId)
                PrepareAdditionalEntries()
            End If
        Catch ex As Exception
            Throw New Exception("DisplayCustomer()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PrepareCustomProperty(ByRef cmbCombo As ComboBox, ByRef pProp As CustomPropertiesItem)
        Try
            cmbCombo.Enabled = True
            cmbCombo.Tag = pProp
            If pProp.LimitToLookup Then
                cmbCombo.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                cmbCombo.DropDownStyle = ComboBoxStyle.DropDown
            End If
            cmbCombo.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            If pProp.RequiredType = CustomPropertyRequiredType.PropertyOptional Then
                Dim pItem As New CustomPropertiesValues(0, "", "")
                cmbCombo.Items.Add(pItem)
            End If
            For Each pItem As CustomPropertiesValues In pProp.Value.Values
                cmbCombo.Items.Add(pItem)
            Next
        Catch ex As Exception
            Throw New Exception("PrepareCustomProperty()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PrepareCustomProperty(ByRef txtText As TextBox, ByRef pProp As CustomPropertiesItem)
        Try
            txtText.Enabled = True
            txtText.Tag = pProp
        Catch ex As Exception
            Throw New Exception("PrepareCustomProperty()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function PrepareCTCCommand(ByVal pPaxNumber As Integer, ByVal pCTC As CTCPax) As String()
        Dim pCommand() As String = {""}
        Dim pCommandCounter As Integer = 0
        If pCTC.Refused Then
            pCommandCounter += 1
            ReDim Preserve pCommand(pCommandCounter - 1)
            If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                pCommand(pCommandCounter - 1) = "SI.P" & pPaxNumber & "/SSRCTCRYYHK1/PASSENGER REFUSED TO PROVIDE INFORMATION"
            Else
                pCommand(pCommandCounter - 1) = "SRCTCR-PASSENGER REFUSED TO PROVIDE INFORMATION/P" & pPaxNumber
            End If
        Else
            If pCTC.Email <> "" Then
                pCommandCounter += 1
                ReDim Preserve pCommand(pCommandCounter - 1)
                If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                    pCommand(pCommandCounter - 1) = "SI.P" & pPaxNumber & "/SSRCTCEYYHK1/" & pCTC.Email.Replace("@", "//").Replace("_", "..").Replace("-", "./")
                Else
                    pCommand(pCommandCounter - 1) = "SRCTCE-" & pCTC.Email.Replace("@", "//").Replace("_", "..").Replace("-", "./") & "/P" & pPaxNumber
                End If
            End If
            If pCTC.Mobile <> "" Then
                pCommandCounter += 1
                ReDim Preserve pCommand(pCommandCounter - 1)
                If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                    pCommand(pCommandCounter - 1) = "SI.P" & pPaxNumber & "/SSRCTCMYYHK1/" & pCTC.Mobile
                Else
                    pCommand(pCommandCounter - 1) = "SRCTCM-" & pCTC.Mobile & "/P" & pPaxNumber
                End If
            End If
        End If
        Return pCommand
    End Function
    Private Sub SetCTCExists(ByVal pSSRExists As Boolean, ByVal pPaxFound As String, ByVal pPaxNotFound As String)
        Try
            If pSSRExists Then
                lblCTC.BackColor = Color.Cyan
                lblCTC.Text = "CTC in PNR"
            ElseIf pPaxFound <> "" And pPaxNotFound = "" Then
                lblCTC.BackColor = Color.LightGreen
                lblCTC.Text = "CTC exists"
            Else
                lblCTC.BackColor = Color.Red
                lblCTC.Text = "CTC Missing"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetupPCCOptions()
        Try
            mflgLoading = True
            If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                SSGDS.Text = MySettings.GDSAbbreviation
                SSPCC.Text = MySettings.GDSPcc
                SSUser.Text = MySettings.GDSUser
            Else
                Throw New Exception("No GDS signed in")
            End If
            If CheckOptions() Then
                mflgReadPNR = False
                ClearForm()
                SetEnabled()
                PrepareForm()
                APISPrepareGrid(dgvApis)
            Else
                Throw New Exception("User not authorized for this PCC")
            End If
        Catch ex As Exception
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub PrepareForm()
        Try
            PrepareLists()
            PopulateCustomerList("")
        Catch ex As Exception
            Throw New Exception("PrepareForms()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PrepareLists()
        Try
            lstCustomers.Items.Clear()
            'cmbSubDepartments.Items.Clear()
            'mobjSubDepartmentSelected = Nothing
            'cmbCRM.Items.Clear()

            'mobjCRMSelected = Nothing
            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing
            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False
        Catch ex As Exception
            Throw New Exception("PrepareLists()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub frmFormFinisher_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            mflgLoading = True
            dgvApis.VirtualMode = False

            If Not MySettings Is Nothing AndAlso MySettings.PriceOptimiser Then
                mfrmOptimiser = New frmPriceOptimiser
            End If
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub optClientATH_CheckedChanged(sender As Object, e As EventArgs) Handles optClientATH.CheckedChanged
        Try
            If Not mflgLoading Then
                If mintBackOffice <> 1 Then
                    mintBackOffice = 1
                    'ClearForm()
                    MySettings.LoadGDSReferences(mintBackOffice, mSelectedGDSCode)
                    PopulateCustomerList(txtCustomer.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub optClientQLI_CheckedChanged(sender As Object, e As EventArgs) Handles optClientQLI.CheckedChanged
        Try
            If Not mflgLoading Then
                If mintBackOffice <> 2 Then
                    mintBackOffice = 2
                    'ClearForm()
                    MySettings.LoadGDSReferences(mintBackOffice, mSelectedGDSCode)
                    PopulateCustomerList("")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tmrWarning_Tick(sender As Object, e As EventArgs) Handles tmrWarning.Tick

        If lblWarning.BackColor = Color.OrangeRed Then
            lblWarning.BackColor = Color.GreenYellow
        Else
            lblWarning.BackColor = Color.OrangeRed
        End If
    End Sub

    Private Sub lblWarning_Click(sender As Object, e As EventArgs) Handles lblWarning.Click
        If tmrWarning.Enabled Then
            lblWarning.BackColor = Color.OrangeRed
            tmrWarning.Enabled = False
        End If
    End Sub

    Private Sub mobjPNR_NewItemCreated() Handles mobjPNR.NewItemCreated
        PrepareAdditionalEntries()
    End Sub
    Private Sub ShowNewItems()

        AddItemToList(mobjPNR.NewElements.PhoneElement.GDSCommand)
        AddItemToList(mobjPNR.NewElements.EmailElement.GDSCommand)
        AddItemToList(mobjPNR.NewElements.AgentID.GDSCommand)
        AddItemToList(mobjPNR.NewElements.AOH.GDSCommand)
        AddItemToList(mobjPNR.NewElements.OpenSegment.GDSCommand)
        AddItemToList(mobjPNR.NewElements.TicketElement.GDSCommand)
        AddItemToList(mobjPNR.NewElements.OptionQueueElement.GDSCommand)
        If mobjPNR.NewPNR Then
            AddItemToList(mobjPNR.NewElements.SavingsElement.GDSCommand)
            AddItemToList(mobjPNR.NewElements.LossElement.GDSCommand)
        End If
        AddItemToList(mobjPNR.NewElements.CustomerCodeAI.GDSCommand)
        AddItemToList(mobjPNR.NewElements.CustomerCode.GDSCommand)
        AddItemToList(mobjPNR.NewElements.CustomerName.GDSCommand)
        AddItemToList(mobjPNR.NewElements.SubDepartmentCode.GDSCommand)
        AddItemToList(mobjPNR.NewElements.SubDepartmentName.GDSCommand)
        AddItemToList(mobjPNR.NewElements.CRMCode.GDSCommand)
        AddItemToList(mobjPNR.NewElements.CRMName.GDSCommand)
        AddItemToList(mobjPNR.NewElements.VesselName.GDSCommand)
        AddItemToList(mobjPNR.NewElements.VesselFlag.GDSCommand)
        AddItemToList(mobjPNR.NewElements.VesselOSI.GDSCommand)
        AddItemToList(mobjPNR.NewElements.Reference.GDSCommand)
        AddItemToList(mobjPNR.NewElements.BookedBy.GDSCommand)
        AddItemToList(mobjPNR.NewElements.Department.GDSCommand)
        AddItemToList(mobjPNR.NewElements.ReasonForTravel.GDSCommand)
        AddItemToList(mobjPNR.NewElements.CostCentre.GDSCommand)
        AddItemToList(mobjPNR.NewElements.TRId.GDSCommand)
        If mSelectedGDSCode = EnumGDSCode.Galileo Then
            AddItemToList(mobjPNR.NewElements.GalileoTrackingCode.GDSCommand)
        End If

    End Sub
    Private Sub AddItemToList(ByVal pItem As String)
        If pItem <> "" Then
            lstGDSEntries.Items.Add(pItem, True)
        End If
    End Sub
End Class