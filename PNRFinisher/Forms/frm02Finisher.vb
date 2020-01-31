Option Strict On
Option Explicit On
Public Class frm02Finisher

    Private mSelectedGDSCode As EnumGDSCode = EnumGDSCode.Unknown
    Private mSelectedBOCode As EnumBOCode = EnumBOCode.Unknown

    Private mflgLoading As Boolean
    Private mflgReadPNR As Boolean

    Private mobjPNR As GDSReadPNR

    Private mobjClientSelected As Client
    Private mobjSubDepartmentSelected As SubDepartmentItem
    Private mobjCRMSelected As CRMItem
    Private mobjVesselSelected As VesselItem
    Private mobjAirlinePoints As New AirlinePointsCollection

    Private mflgAPISUpdate As Boolean
    Private mflgExpiryDateOK As Boolean

    Private mfrmItinHelper As frmItineraryHelper
    Private mfrmCTC As New frmPaxCTC
    Private mfrmCTCPax As New frmPaxCTCOnlyPax
    Private mobjCTC As New CTCPaxCollection

    Private mobjGender As New ReferenceGenderCollection
    Private UCRefArray() As UCRef
    Private Sub cmdPNRRead1AATH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRRead1AATH.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            mSelectedBOCode = EnumBOCode.ATH
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdPNRRead1GPNR_Click(sender As Object, e As EventArgs) Handles cmdPNRRead1GATH.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Galileo
            mSelectedBOCode = EnumBOCode.ATH
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdPNRRead1AQLI_Click(sender As Object, e As EventArgs) Handles cmdPNRRead1AQLI.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            mSelectedBOCode = EnumBOCode.QLI
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdPNRRead1GQLI_Click(sender As Object, e As EventArgs) Handles cmdPNRRead1GQLI.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Galileo
            mSelectedBOCode = EnumBOCode.QLI
            PNRReadPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdCostCentre_Click(sender As Object, e As EventArgs) Handles cmdClientGroupCostCentreLookup.Click
        Try
            Dim pfrmcostCentre As New frmCostCentre(mSelectedBOCode)    ' TODO for BO Change
            Dim pResult As System.Windows.Forms.DialogResult
            mflgLoading = False
            pResult = pfrmcostCentre.ShowDialog()

            If pResult = Windows.Forms.DialogResult.OK Then
                txtClient.Text = pfrmcostCentre.CodeSelected
                txtVessel.Text = pfrmcostCentre.VesselSelected
                DisplayOldClientReference(UcRef5.cmbClientRef, pfrmcostCentre.CostCentreSelected)
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
                    mobjPNR.NewElements.SetVesselForPNR(mSelectedBOCode, "", "")
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
    Private Sub cmdPNRWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRWrite.Click

        Try
            PNRWrite(True, False)
            ShowPriceOptimiser(Me.MdiParent, False)
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

    Private Sub txtClient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClient.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateClientList(txtClient.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtSubdepartment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubdepartment.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateSubdepartmentsList(txtSubdepartment.Text)
                End If
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtCRM_TextChanged(sender As Object, e As EventArgs) Handles txtCRM.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateCRMList(txtCRM.Text)
                End If
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub lstClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstClient.SelectedIndexChanged

        Try
            If lstClient.SelectedIndex >= 0 Then
                mflgLoading = True
                Dim pClient As Client = CType(lstClient.SelectedItem, Client)
                SelectClient(pClient)
                txtClient.Text = lstClient.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub lstSubDepartments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSubDepartments.SelectedIndexChanged

        Try
            If Not lstSubDepartments.SelectedItem Is Nothing Then
                mflgLoading = True
                Dim pSubDepartmentItem As SubDepartmentItem
                pSubDepartmentItem = CType(lstSubDepartments.SelectedItem, SubDepartmentItem)
                SelectSubDepartment(pSubDepartmentItem)
                txtSubdepartment.Text = lstSubDepartments.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub lstCRM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCRM.SelectedIndexChanged

        Try
            If Not lstCRM.SelectedItem Is Nothing Then
                mflgLoading = True
                Dim pCRMItem As CRMItem
                pCRMItem = CType(lstCRM.SelectedItem, CRMItem)
                SelectCRM(pCRMItem)
                txtCRM.Text = lstCRM.SelectedItem.ToString
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
                    mobjPNR.NewElements.SetVesselForPNR(mSelectedBOCode, "", "")
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
                SelectVessel(mSelectedBOCode, pVesselItem)
                txtVessel.Text = lstVessels.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub


    'Private Sub txtReference_TextChanged(sender As Object, e As EventArgs)

    '    Try
    '        If Not mflgLoading Then
    '            If Not MySettings Is Nothing Then
    '                mobjPNR.NewElements.SetReference(mSelectedBOCode, txtReference.Text)
    '            End If
    '        End If
    '        SetEnabled()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
    Private Sub APISDisplayPax()
        If mobjPNR.ExistingElements.SSRDocsExists Then
            txtPNRApis.Location = dgvApis.Location
            txtPNRApis.Size = dgvApis.Size
            txtPNRApis.Text = mobjPNR.ExistingElements.SSRDocs
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
        pflgGenderFound = False
        For Each pGenderItem As ReferenceItem In mobjGender.Values
            If CStr(Row.Cells("Gender").Value) = pGenderItem.Code Then
                pflgGenderFound = True
                Exit For
            End If
        Next
        If Not mobjPNR.ExistingElements Is Nothing Then
            mflgAPISUpdate = mflgAPISUpdate Or (Not mobjPNR.ExistingElements.SSRDocsExists And mobjPNR.Segments.SegmentsExist And pflgBirthDateOK And pflgGenderFound) '  And pflgPassportNumberOK)
        Else
            mflgAPISUpdate = mflgAPISUpdate Or (mobjPNR.Segments.SegmentsExist And pflgBirthDateOK And pflgGenderFound) '  And pflgPassportNumberOK)
        End If
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
        If Not mobjPNR.ExistingElements Is Nothing AndAlso mobjPNR.ExistingElements.SSRDocsExists Then
            lblSSRDocs.Text = "SSR DOCS already exist in the PNR"
            lblSSRDocs.BackColor = Color.Red
            cmdAPISEditPax.Enabled = False
        Else
            If mobjPNR.Segments.SegmentsExist Then
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
    ' TODO for BO Change
    Private Sub PopulateCRMList(ByVal SearchString As String)

        Try
            Dim pobjCRM As New CRMCollection

            If SearchString = "" Then
                mobjCRMSelected = Nothing
                mobjPNR.NewElements.SetCRM(mSelectedBOCode, 0, "", "")
            End If
            lstCRM.Items.Clear()

            If Not mobjClientSelected Is Nothing Then
                pobjCRM.Load(mobjClientSelected.ID, mSelectedBOCode)    ' TODO for BO Change


                For Each pCRM As CRMItem In pobjCRM.Values
                    If SearchString = "" Or pCRM.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                        lstCRM.Items.Add(pCRM)
                    End If
                Next
                If mobjPNR.NewElements.CRMCode.TextRequested <> "" And lstCRM.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pCRMItem As CRMItem
                        pCRMItem = CType(lstCRM.Items(0), CRMItem)
                        SelectCRM(pCRMItem)
                        txtCRM.Text = lstCRM.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCRMList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateClientList(ByVal SearchString As String)

        Try
            Dim pClients As New ClientCollection(SearchString, mSelectedBOCode)    ' TODO for BO Change
            lstClient.Items.Clear()
            For Each pItem As Client In pClients.Values
                If SearchString = "" Or pItem.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                    lstClient.Items.Add(pItem)
                End If
            Next
            If lstClient.Items.Count = 1 Then
                Try
                    mflgLoading = True
                    Dim pClient As Client = CType(lstClient.Items(0), Client)
                    SelectClient(pClient)
                    txtClient.Text = lstClient.Items(0).ToString
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    mflgLoading = False
                End Try
            End If
        Catch ex As Exception
            Throw New Exception("PopulateClientList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateSubdepartmentsList(ByVal SearchString As String)

        Try
            Dim pobjSubDepartments As New SubDepartmentCollection

            If SearchString = "" Then
                mobjSubDepartmentSelected = Nothing
                mobjPNR.NewElements.SetSubDepartment(mSelectedBOCode, 0, "", "")
            End If
            lstSubDepartments.Items.Clear()

            If Not mobjClientSelected Is Nothing Then
                pobjSubDepartments.Load(mobjClientSelected.ID, mSelectedBOCode) ' TODO for BO Change

                For Each pSubDepartment As SubDepartmentItem In pobjSubDepartments.Values
                    If SearchString = "" Or pSubDepartment.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                        lstSubDepartments.Items.Add(pSubDepartment)
                    End If
                Next

                If lstSubDepartments.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pSubDepartmentItem As SubDepartmentItem
                        pSubDepartmentItem = CType(lstSubDepartments.Items(0), SubDepartmentItem)
                        SelectSubDepartment(pSubDepartmentItem)
                        txtSubdepartment.Text = lstSubDepartments.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateSubdepartmentsList()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateVesselsList()

        Try
            Dim pobjVessels As New VesselCollection

            lstVessels.Items.Clear()

            If Not mobjClientSelected Is Nothing Then

                pobjVessels.Load(mobjClientSelected.ID, mSelectedBOCode) ' TODO for BO Change

                For Each pVessel As VesselItem In pobjVessels.Values
                    If mobjPNR.NewElements.VesselName.TextRequested = "" Or pVessel.ToString.ToUpper.Contains(mobjPNR.NewElements.VesselName.TextRequested.ToUpper) Then
                        lstVessels.Items.Add(pVessel)
                    End If
                Next
                If lstVessels.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        Dim pVesselItem As VesselItem = CType(lstVessels.Items(0), VesselItem)
                        SelectVessel(mSelectedBOCode, pVesselItem)
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

    Private Sub DisplayClient()

        Dim pstrClientCode As String
        Dim pintSubDepartment As Integer
        Dim pstrCRM As String
        Dim pstrVesselName As String
        Dim pstrVesselRegistration As String

        Try
            With mobjPNR.ExistingElements
                pstrClientCode = .ClientCodeItem.Key
                pintSubDepartment = If(IsNumeric(.SubDepartmentCode.Key), CInt(.SubDepartmentCode.Key), 0)
                pstrCRM = .CRMCode.Key
                pstrVesselName = .VesselNameItem.Key
                pstrVesselRegistration = .VesselFlag.Key

                mobjPNR.NewElements.ClearClientElements()

                txtClient.Clear()
                txtSubdepartment.Clear()
                txtCRM.Clear()
                txtVessel.Clear()

                'txtReference.Text = .Reference.Key
                txtSubdepartment.Text = .SubDepartmentCode.Key
                txtCRM.Text = .CRMCode.Key
            End With

            If pstrClientCode <> "" Then
                Dim pClientFromDB As New ClientFromDB(pstrClientCode, mSelectedBOCode)
                Dim pClient As Client = pClientFromDB.Client
                txtClient.Text = pClient.Code
                If pintSubDepartment <> 0 Then
                    Dim pSub As New SubDepartmentItem
                    pSub.Load(pintSubDepartment, mSelectedBOCode) ' TODO for BO Change
                    txtSubdepartment.Text = pSub.Code & " " & pSub.Name
                End If
                If Not pstrCRM Is Nothing AndAlso pstrCRM.Length > 0 Then
                    Dim pSub As New CRMItem
                    pSub.Load(pstrCRM, mSelectedBOCode) ' TODO for BO Change
                    txtCRM.Text = pSub.Code & " " & pSub.Name
                End If

                If pstrVesselName <> "" Then
                    Dim pVessel As New VesselItem(pstrClientCode, pstrVesselName, mSelectedBOCode)
                    If pVessel.Loaded Then ' TODO for BO Change
                        mobjPNR.NewElements.VesselNameForPNR = New GDSNewItem
                        mobjPNR.NewElements.VesselFlagForPNR = New GDSNewItem
                        txtVessel.Text = pVessel.VesselName
                    Else
                        mobjPNR.NewElements.SetVesselForPNR(mSelectedBOCode, pstrVesselName, pstrVesselRegistration)
                        txtVessel.Text = mobjPNR.NewElements.VesselNameForPNR.TextRequested & " REG " & mobjPNR.NewElements.VesselFlagForPNR.TextRequested
                    End If
                End If

                For Each pClientRef As GDSExistingItem In mobjPNR.ExistingElements.ClientReferences
                    For Each pRef As UCRef In UCRefArray
                        If pRef.cmbClientRef.Enabled Then
                            If mSelectedGDSCode = EnumGDSCode.Galileo And (pClientRef.RawText.IndexOf(pRef.ClientRefItem.GalileoTemplate) >= 0 Or ("DI.FT-" & pClientRef.RawText).IndexOf(pRef.ClientRefItem.GalileoTemplate) >= 0) Then
                                pRef.DisplayOldReference(pClientRef)
                                Exit For
                            ElseIf mSelectedGDSCode = EnumGDSCode.Amadeus And pClientRef.RawText.IndexOf(pRef.ClientRefItem.AmadeusTemplate) >= 0 Then
                                pRef.DisplayOldReference(pClientRef)
                                Exit For
                            End If
                        End If
                    Next
                Next

                ShowGDSEntries()
            End If
        Catch ex As Exception
            Throw New Exception("DisplayClient()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PrepareOtherOfficeEntries()
        If mSelectedGDSCode = EnumGDSCode.Amadeus Then
            If mSelectedBOCode = EnumBOCode.ATH Then

            ElseIf mSelectedBOCode = EnumBOCode.QLI Then
                lstGDSElementsAddItem("RM *GRACE/CLN/020208")
                lstGDSElementsAddItem("RM *GRACE/CLA/ATPI CYPRUS LTD")
                lstGDSElementsAddItem("FK QLIG42100")
            End If
        ElseIf mSelectedGDSCode = EnumGDSCode.Galileo Then
            If mSelectedBOCode = EnumBOCode.ATH Then

            ElseIf mSelectedBOCode = EnumBOCode.QLI Then
                lstGDSElementsAddItem("DI.FT-GRACE/CLN/020208")
                lstGDSElementsAddItem("DI.FT-GRACE/CLA/ATPI CYPRUS LTD")
            End If

        End If
    End Sub
    Private Sub PrepareCTC()
        Try
            Dim pFound As String = ""
            Dim pNotFound As String = ""
            mobjCTC.Load(mSelectedBOCode, mobjClientSelected.ID) ' TODO for BO Change
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
                        If pCTC.Vesselname = mobjPNR.ExistingElements.VesselName And pCTC.FirstName = "" And pCTC.Lastname = "" Then
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
                            lstGDSElementsAddItem(pCTCCommand(i))
                        End If
                    Next
                    pFound &= pPax.ElementNo & " "
                Else
                    pNotFound &= pPax.ElementNo & " "
                End If
            Next

            Dim pSSR As Boolean = False
            If mflgReadPNR AndAlso mobjPNR.ExistingElements.SSRCTCExists Then
                pSSR = True
            End If
            SetCTCExists(pSSR, pFound, pNotFound)

        Catch ex As Exception
            Throw New Exception("PrepareCTC()" & vbCrLf & ex.Message)
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
    Private Sub ShowGDSEntries()
        Try
            lstGDSElements.Items.Clear()
            If mSelectedBOCode = EnumBOCode.QLI Then
                If mSelectedGDSCode = EnumGDSCode.Amadeus Then
                    lstGDSElementsAddItem("RM *D,DEP-1CYP")
                Else
                    lstGDSElementsAddItem("DI.FT-DEP-1CYP")
                End If
            End If
            PrepareAirlinePoints()
            PrepareAirlineNotes()
            PrepareConditionalEntries()
            PrepareClientReferences()
            If Not mobjPNR.ExistingElements.SSRCTCExists Then
                PrepareCTC()
            End If
            If chkAddOtherOfficeEntries.Checked Then
                PrepareOtherOfficeEntries()
            End If
        Catch ex As Exception
            Throw New Exception("ShowGDSEntries()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PrepareClientReferences()
        For i As Integer = UCRefArray.GetLowerBound(0) To UCRefArray.GetUpperBound(0)
            If UCRefArray(i).cmbClientRef.Enabled AndAlso Not UCRefArray(i).ClientRefItem.SelectedValue Is Nothing Then
                If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                    lstGDSElementsAddItem(UCRefArray(i).ClientRefItem.GalileoEntry)
                Else
                    lstGDSElementsAddItem(UCRefArray(i).ClientRefItem.AmadeusEntry)
                End If
            End If
            If Not UCRefArray(i).ClientRefItem Is Nothing AndAlso Not UCRefArray(i).ClientRefItem.PaxReferences Is Nothing Then
                If UCRefArray(i).ClientRefItem.PaxReferences.Count > 0 Then
                    If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                        For Each pItem As ClientReferencePax In UCRefArray(i).ClientRefItem.PaxReferences.Values
                            lstGDSElementsAddItem(UCRefArray(i).ClientRefItem.GalileoEntry(pItem.ElementID))
                        Next
                    Else
                        For Each pItem As ClientReferencePax In UCRefArray(i).ClientRefItem.PaxReferences.Values
                            lstGDSElementsAddItem(UCRefArray(i).ClientRefItem.AmadeusEntry(pItem.ElementID))
                        Next
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub PrepareAirlinePoints()
        Try
            Dim pFound As Boolean = False
            If mflgReadPNR Then
                If mobjClientSelected.ID <> 0 Then
                    For Each pSeg As GDSSegItem In mobjPNR.Segments.Values
                        If Not mobjVesselSelected Is Nothing Then
                            mobjAirlinePoints.Load(mobjClientSelected.ID, mobjVesselSelected.VesselName, pSeg.Airline, mobjPNR.GDSCode, mSelectedBOCode) ' TODO for BO Change
                        Else
                            mobjAirlinePoints.Load(mobjClientSelected.ID, "", pSeg.Airline, mobjPNR.GDSCode, mSelectedBOCode) ' TODO for BO Change
                        End If

                        For Each pItem As String In mobjAirlinePoints
                            lstGDSElementsAddItem(pItem)
                        Next
                    Next
                End If
            End If
        Catch aex As System.ArgumentOutOfRangeException
            MessageBox.Show(aex.Message)
        Catch ex As Exception
            Throw New Exception("PrepareAirlinePoints()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PrepareAirlineNotes()
        Dim pFound As Boolean = False
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
                                    If mobjVesselSelected.VesselName Is Nothing Then
                                        pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.VesselName)
                                    Else
                                        pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.VesselName.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                    End If
                                End If
                            End If

                            If pGDSText.Contains("<?VESSEL REGISTRATION>") Then
                                If Not mobjVesselSelected Is Nothing Then
                                    If mobjVesselSelected.VesselRegistration Is Nothing Then
                                        pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.VesselRegistration)
                                    Else
                                        pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.VesselRegistration.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                    End If
                                End If
                            End If

                            If pGDSText.Contains("<?NBR OF PSGRS>") Then
                                pGDSText = pGDSText.Replace("<?NBR OF PSGRS>", CStr(mobjPNR.Passengers.Count))
                            End If

                            If pGDSText.Contains("<?Segment selection>") Then
                                pGDSText = pGDSText.Replace("<?Segment selection>", CStr(pSeg.ElementNo))
                            End If

                            lstGDSElementsAddItem(pGDSText)

                        End If
                    End With
                Next
            Next
        End If
    End Sub
    Private Sub PrepareConditionalEntries()
        Dim pFound As Boolean = False
        If mflgReadPNR Then
            If Not mobjClientSelected Is Nothing And Not mobjVesselSelected Is Nothing Then
                Dim pConditionalEntry As New ConditionalGDSEntryCollection
                pConditionalEntry.Load(mSelectedBOCode, mobjClientSelected.ID, mobjVesselSelected.VesselName) ' TODO for BO Change
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
                        lstGDSElementsAddItem(pGDSCommand)
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub SelectCRM(ByVal pCRM As CRMItem)

        Try
            mobjCRMSelected = pCRM
            txtCRM.Text = pCRM.ToString
            mobjPNR.NewElements.SetCRM(mSelectedBOCode, mobjCRMSelected.ID, mobjCRMSelected.Code, mobjCRMSelected.Name)

            SetEnabled()
            If pCRM.Alert <> "" Then
                MessageBox.Show(pCRM.Alert, pCRM.Code & " " & pCRM.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectCRM()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectClient(ByVal pClient As Client)

        Try
            mobjPNR.NewElements.ClearClientElements()
            mobjClientSelected = pClient
            txtClient.Text = pClient.ToString
            mobjPNR.NewElements.SetClient(mSelectedBOCode, mobjClientSelected) ' TODO for BO Change

            txtSubdepartment.Clear()
            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            txtCRM.Clear()
            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            txtVessel.Clear()
            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            'txtReference.Clear()

            If mobjClientSelected.HasVessels Then
                PopulateVesselsList()
            End If

            If mobjClientSelected.HasDepartments Then
                PopulateSubdepartmentsList("")
            End If

            PopulateCRMList("")
            PopulateClientReferences()
            ShowGDSEntries()

            SetEnabled()

            If pClient.AlertForFinisher <> "" Then
                MessageBox.Show(pClient.AlertForFinisher, pClient.Code & " " & pClient.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectClient()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PopulateClientReferences()

        Try
            For i As Integer = UCRefArray.GetLowerBound(0) To UCRefArray.GetUpperBound(0)
                UCRefArray(i).Clear()
            Next

            If Not mobjClientSelected Is Nothing Then
                For Each pProp As ClientReference In mobjClientSelected.ClientReferences.Values
                    If pProp.SequenceNo - 1 >= UCRefArray.GetLowerBound(0) And pProp.SequenceNo - 1 <= UCRefArray.GetUpperBound(0) Then
                        UCRefArray(pProp.SequenceNo - 1).PrepareClientReference(pProp, mobjPNR.Passengers)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception("PopulateClientReferences()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub SelectSubDepartment(ByVal pSubDepartment As SubDepartmentItem)

        Try
            mobjSubDepartmentSelected = pSubDepartment
            txtSubdepartment.Text = pSubDepartment.ToString
            mobjPNR.NewElements.SetSubDepartment(mSelectedBOCode, mobjSubDepartmentSelected.ID, mobjSubDepartmentSelected.Code, mobjSubDepartmentSelected.Name)

            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectSubDepartment()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectVessel(ByVal pBackOffice As Integer, ByVal pVessel As VesselItem)

        Try
            mobjVesselSelected = pVessel
            txtVessel.Text = pVessel.ToString
            mobjPNR.NewElements.SetVessel(pBackOffice, mobjVesselSelected)
            ShowGDSEntries()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectVessel()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SetEnabled()

        Try
            ' read PNR is always enabled
            cmdPNRRead1AATH.Enabled = True

            ' client based entries are enabled if a PNR has been read and there is data available
            txtClient.Enabled = mflgReadPNR And (lstClient.Items.Count > 0)
            lstClient.Enabled = mflgReadPNR And (lstClient.Items.Count > 0)
            cmdClientGroupCostCentreLookup.Enabled = mflgReadPNR And (lstClient.Items.Count > 0)

            txtSubdepartment.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)
            lstSubDepartments.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)

            txtCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)
            lstCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)

            txtVessel.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)
            lstVessels.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)

            ' the exception is the one time vessel which is always enabled for any PNR
            cmdOneTimeVessel.Enabled = mflgReadPNR

            ' Update is enabled if a PNR has been read and if mandatory fields have been entered
            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

            ' client is always needed

            txtClient.BackColor = lstClient.BackColor
            txtSubdepartment.BackColor = lstClient.BackColor
            txtCRM.BackColor = lstClient.BackColor
            If Not mobjPNR Is Nothing Then
                cmdPNRWrite.Enabled = mflgReadPNR
                If Not mobjPNR.NewElements Is Nothing Then
                    If mobjPNR.NewElements.ClientCodeItem.GDSCommand = "" Then
                        cmdPNRWrite.Enabled = False
                        txtClient.BackColor = Color.Red
                    End If

                    ' if subdepartments exist they are by default madatory
                    If mobjPNR.NewElements.ClientCodeItem.GDSCommand <> "" And lstSubDepartments.Items.Count > 0 And mobjPNR.NewElements.SubDepartmentCode.GDSCommand = "" Then
                        cmdPNRWrite.Enabled = False
                        txtSubdepartment.BackColor = Color.Red
                    End If

                    ' the code above is complete validation but allow entry without CRM in any case
                    If mobjPNR.NewElements.ClientCodeItem.GDSCommand <> "" And lstCRM.Items.Count > 0 And mobjPNR.NewElements.CRMCode.GDSCommand = "" Then
                        txtCRM.BackColor = Color.Pink
                    End If

                    For i As Integer = UCRefArray.GetLowerBound(0) To UCRefArray.GetUpperBound(0)
                        cmdPNRWrite.Enabled = (cmdPNRWrite.Enabled And (Not UCRefArray(i).cmbClientRef.Enabled OrElse UCRefArray(i).SetEnabled()))
                    Next
                End If

                cmdPNRWriteWithDocs.Enabled = cmdPNRWrite.Enabled And mflgAPISUpdate
                cmdPNROnlyDocs.Enabled = mflgAPISUpdate And Not mobjPNR.NewPNR
            End If

            dgvApis.Enabled = True
            'txtReference.Enabled = True
            For i As Integer = UCRefArray.GetLowerBound(0) To UCRefArray.GetUpperBound(0)
                UCRefArray(i).SetLabelColor()
            Next

        Catch ex As Exception
            Throw New Exception("SetEnabled()" & vbCrLf & ex.Message)
        End Try

    End Sub

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
    Private Sub ClearLists()

        Try
            lstClient.Items.Clear()

            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

        Catch ex As Exception
            Throw New Exception("PrepareLists()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Function UpdatePNR(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean) As String
        Try
            UpdatePNR = mobjPNR.SendAllGDSEntries(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, lstGDSElements)
            Dim pPNR As String = mobjPNR.PnrNumber
            Dim pNewEntry = False
            If pPNR = "New PNR" Or pPNR = "" Then
                If UpdatePNR.LastIndexOf(" ") > -1 Then
                    pPNR = UpdatePNR.Substring(UpdatePNR.LastIndexOf(" ")).Trim
                ElseIf UpdatePNR.Length = 6 Then
                    pPNR = UpdatePNR
                End If
                pNewEntry = True
            End If
            Dim pClient As String = mobjPNR.ExistingElements.ClientCode
            If pClient = "" Then
                pClient = mobjPNR.NewElements.ClientCodeItem.TextRequested
            End If
            If pPNR <> "" Then
                PNRFinisherTransactions.UpdateTransactions(pPNR, MySettings.GDSAbbreviation, MySettings.GDSPcc, MySettings.GDSUser, Now, mobjPNR.Passengers.AllPassengers, mobjPNR.Segments.FullItinerary, "", pClient, pNewEntry)
            End If
        Catch ex As Exception
            Throw New Exception("UpdatePNR()" & vbCrLf & ex.Message)
        End Try

    End Function

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

    Private Sub ReadPNR()
        Dim pDMI As String
        Try
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            With mobjPNR
                mflgReadPNR = False

                SetupPCCOptions()
                pDMI = .ReadFinisher(mSelectedBOCode)
                If .Passengers.Count = 0 And Not .IsGroup Then
                    Throw New Exception("Need passenger names")
                End If
                If pDMI <> "" Then
                    If MessageBox.Show("There is a problem with your itinerary. Do you want to cancel the PNR Finisher?" & vbCrLf & vbCrLf & pDMI, "Itinerary Check", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Throw New Exception("PNR Finisher cancelled because of itinerary check")
                    End If
                End If

                mflgReadPNR = True
                .PrepareNewGDSElements(mSelectedBOCode)
                lblPNR.Text = .PnrNumber
                If .IsGroup Then
                    lblPax.Text = "Group:" & .GroupName & " " & .GroupNamesCount
                Else
                    lblPax.Text = .Passengers.LeadName
                End If

                lblSegs.Text = .Segments.Itinerary
                If .Segments.AirlineAlert <> "" Then
                    MessageBox.Show(.Segments.AirlineAlert, "AIRLINE ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                ShowGDSEntries()
            End With
            DisplayClient()
            APISDisplayPax()

        Catch ex As Exception
            Throw New Exception("ReadPNR()" & vbCrLf & ex.Message)
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

    Private Sub DisplayOldClientReference(ByRef cmbList As ComboBox, ByVal Item As String)
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
            Throw New Exception("DisplayOldClientReference(ByRef cmbList As ComboBox, ByVal Item As String)" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ClearForm()

        Try
            mobjClientSelected = New Client
            mobjSubDepartmentSelected = New SubDepartmentItem
            mobjCRMSelected = New CRMItem
            mobjVesselSelected = New VesselItem
            mobjAirlinePoints = New AirlinePointsCollection
            mobjCTC = New CTCPaxCollection
            mfrmCTC.Dispose()
            mfrmCTCPax.Dispose()
            lblPNR.Text = ""
            lblPax.Text = ""
            lblSegs.Text = ""

            txtClient.Clear()
            txtSubdepartment.Clear()
            txtCRM.Clear()
            txtVessel.Clear()
            lstGDSElements.Items.Clear()
            lstVessels.Items.Clear()
            lstSubDepartments.Items.Clear()
            txtSubdepartment.Enabled = (lstSubDepartments.Items.Count > 0)
            lstCRM.Items.Clear()
            txtCRM.Enabled = (lstCRM.Items.Count > 0)

            'txtReference.Clear()
            For i As Integer = UCRefArray.GetLowerBound(0) To UCRefArray.GetUpperBound(0)
                UCRefArray(i).Clear()
            Next

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

            mobjPNR.NewElements.Clear()

            mflgAPISUpdate = False
            mflgExpiryDateOK = False

            APISPrepareGrid(dgvApis)

        Catch ex As Exception
            Throw New Exception("ClearForm()" & vbCrLf & ex.Message)
        End Try

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

    Private Sub PNRReadPNR()
        Try
            Dim mGDSUser As New GDSUser(mSelectedGDSCode)
            InitSettings(mGDSUser)
            If mSelectedBOCode = EnumBOCode.ATH Then
                MySettings.CountryCode = "GR"
            ElseIf mSelectedBOCode = EnumBOCode.QLI Then
                MySettings.CountryCode = "CY"
            End If
            ReadPNR()
            ShowPriceOptimiser(Me.MdiParent, False)
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetupPCCOptions()
        Try
            mflgLoading = True
            Dim pText As String = ""
            If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                pText &= MySettings.GDSPcc & " " & MySettings.GDSUser
                SSGDS.Text = MySettings.GDSAbbreviation
                SSPCC.Text = MySettings.GDSPcc
                SSUser.Text = MySettings.GDSUser
            Else
                Throw New Exception("No GDS signed in")
            End If
            mflgReadPNR = False
            ClearForm()
            If CheckOptions() Then
                SetEnabled()
                PrepareForm()
            Else
                Throw New Exception("User not authorized for this PCC")
            End If
        Catch ex As Exception
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub cmdItineraryHelper_Click(sender As Object, e As EventArgs) Handles cmdItineraryHelper.Click

        Try
            If mfrmItinHelper Is Nothing OrElse mfrmItinHelper.IsDisposed Then
                mfrmItinHelper = New frmItineraryHelper(mSelectedBOCode) ' TODO for BO Change
            End If
            mfrmItinHelper.Location = Me.Location
            mfrmItinHelper.DisplayItinerary(mobjPNR.Segments.Itinerary)
            mfrmItinHelper.Show()
            mfrmItinHelper.BringToFront()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdCTCForm_Click(sender As Object, e As EventArgs) Handles cmdCTCForm.Click

        Try
            Dim pClientId As Integer = 0
            Dim pClientCode As String = ""
            Dim pClientName As String = ""
            Dim pVessel As String = ""
            If Not mobjClientSelected Is Nothing AndAlso mobjClientSelected.ID > 0 Then
                pClientId = mobjClientSelected.ID
                pClientCode = mobjClientSelected.Code
                pClientName = mobjClientSelected.Name
            End If
            If Not mobjVesselSelected Is Nothing Then
                pVessel = mobjVesselSelected.VesselName
            End If

            If pClientCode = "" Or (Not mobjPNR Is Nothing AndAlso Not mobjPNR.Passengers Is Nothing AndAlso mobjPNR.Passengers.Count = 0) Then
                If mfrmCTC.IsDisposed Then
                    mfrmCTC = New frmPaxCTC
                End If
                mfrmCTC.Location = Me.Location
                mfrmCTC.ShowPaxInformation()
                mfrmCTC.ShowDialog()
            Else
                If mfrmCTCPax.IsDisposed Then
                    mfrmCTCPax = New frmPaxCTCOnlyPax
                End If
                mfrmCTCPax.Location = Me.Location
                mfrmCTCPax.ShowPaxInformation(mobjPNR, mSelectedBOCode, pClientId, pClientCode, pClientName, pVessel) ' TODO for BO Change
                mfrmCTCPax.ShowDialog()
                ShowGDSEntries()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub llbOptions_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOptions.LinkClicked

    '    Try
    '        ShowOptionsForm()

    '        If Not CheckOptions() Then
    '            Me.Close()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
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
    Private Sub PrepareForm()

        Try
            ClearLists()
            PopulateClientList("")
        Catch ex As Exception
            Throw New Exception("PrepareForms()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub frm02Finisher_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            mflgLoading = True
            PrepareControlArrays()
            dgvApis.VirtualMode = False
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub PrepareControlArrays()
        UCRefArray = New UCRef() {UcRef1, UcRef2, UcRef3, UcRef4, UcRef5, UcRef6, UcRef7, UcRef8, UcRef9}
        For Each pItem As UCRef In UCRefArray
            AddHandler pItem.SelectedIndexChanged, AddressOf UcRefArray_SelectedIndexChanged
            AddHandler pItem.VesselLoaded, AddressOf UcRefArray_VesselLoaded
        Next
    End Sub


    Private Sub chkAddOtherOfficeEntries_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddOtherOfficeEntries.CheckedChanged
        Try
            ShowGDSEntries()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UcRefArray_SelectedIndexChanged()
        ShowGDSEntries()
        SetEnabled()
    End Sub

    Private Sub UcRefArray_VesselLoaded(VesselName As String)
        If VesselName = "" Then
            mobjVesselSelected = Nothing
        Else
            mobjVesselSelected = New VesselItem(VesselName, "")
        End If
    End Sub

    Private Sub lstGDSElementsAddItem(ByVal pItem As String)

        Dim pFound As Boolean = False
        For i As Integer = 0 To lstGDSElements.Items.Count - 1
            If lstGDSElements.Items(i).ToString = pItem Then
                pFound = True
                Exit For
            End If
        Next
        If Not pFound Then
            lstGDSElements.Items.Add(pItem)
        End If
    End Sub

End Class