Option Strict On
Option Explicit On
Public Class frm03Itinerary

    Private mSelectedGDSCode As EnumGDSCode = EnumGDSCode.Unknown
    Private mSelectedBOCode As EnumBOCode = EnumBOCode.Unknown

    Private mflgLoading As Boolean
    Private mflgLoadingItin As Boolean

    Private mobjPNR As GDSReadPNR

    Private Sub cmdItn1AReadPNR_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadPNR.Click

        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim mGDSUser As New GDSUser(EnumGDSCode.Amadeus)
            mSelectedBOCode = InitSettings(mGDSUser)
            SetupPCCOptions()
            lblItnPNRCounter.Text = ""
            ProcessRequestedPNRs(txtItnPNR)
            CopyItinToClipboard()
            cmdItnRefresh.Enabled = False
            cmdItnFormatOSMLoG.Enabled = True
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdItn1AReadQueue_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadQueue.Click

        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            lblItnPNRCounter.Text = ""
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            txtItnPNR.Text = mobjPNR.RetrievePNRsFromQueue(txtItnPNR.Text)
            Dim mGDSUser As New GDSUser(mSelectedGDSCode)
            InitSettings(mGDSUser)
            SetupPCCOptions()
            ProcessRequestedPNRs(txtItnPNR)
            CopyItinToClipboard()
            cmdItnRefresh.Enabled = False
            cmdItnFormatOSMLoG.Enabled = False
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdItnRead1ACurrent_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadCurrent.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            ITNReadCurrent()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmdItnRead1GCurrent_Click(sender As Object, e As EventArgs) Handles cmdItn1GReadCurrent.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Galileo
            mobjPNR = New GDSReadPNR(mSelectedGDSCode)
            ITNReadCurrent()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ITNReadCurrent()
        Try
            ItnReadCurrentPNR()
            ShowPriceOptimiser(Me.MdiParent, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdItnRefresh_Click(sender As Object, e As EventArgs) Handles cmdItnRefresh.Click

        Try
            ReadPNRandCreateItn(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub optItnAirportCode_CheckedChanged(sender As Object, e As EventArgs) Handles optItnAirportCode.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.AirportName = 0
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub optItnAirportname_CheckedChanged(sender As Object, e As EventArgs) Handles optItnAirportname.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.AirportName = 1
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub optItnAirportBoth_CheckedChanged(sender As Object, e As EventArgs) Handles optItnAirportBoth.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.AirportName = 2
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub optItnAirportCityName_CheckedChanged(sender As Object, e As EventArgs) Handles optItnAirportCityName.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.AirportName = 3
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub optItnAirportCityBoth_CheckedChanged(sender As Object, e As EventArgs) Handles optItnAirportCityBoth.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.AirportName = 4
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnVessel_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnVessel.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowVessel = chkItnVessel.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnClass_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnClass.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowClassOfService = chkItnClass.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnAirlineLocator_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnAirlineLocator.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowAirlineLocator = chkItnAirlineLocator.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnTickets_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnTickets.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowTickets = chkItnTickets.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub chkItnEMD_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnEMD.CheckedChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowEMD = chkItnEMD.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkPaxSegPerTicket_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnPaxSegPerTicket.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowPaxSegPerTkt = chkItnPaxSegPerTicket.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkSeating_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnSeating.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowSeating = chkItnSeating.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkTerminal_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnTerminal.CheckedChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowTerminal = chkItnTerminal.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkStopovers_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnStopovers.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowStopovers = chkItnStopovers.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnFlyingTime_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnFlyingTime.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowFlyingTime = chkItnFlyingTime.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnCostCentre_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnCostCentre.CheckedChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowCostCentre = chkItnCostCentre.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnCabinDescription_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnCabinDescription.CheckedChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowCabinDescription = chkItnCabinDescription.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkItnItinRemarks_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnItinRemarks.CheckedChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowItinRemarks = chkItnItinRemarks.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkItnEquipmentCode_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnEquipmentCode.CheckedChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowEquipmentCode = chkItnEquipmentCode.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkItnCO2_CheckedChanged(sender As Object, e As EventArgs) Handles chkItnCO2.CheckedChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    MySettings.ShowCO2 = chkItnCO2.Checked
                    MySettings.Save()
                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub optItnFormatDefaultAndPlain_CheckedChanged(sender As Object, e As EventArgs) Handles optItnFormatDefault.CheckedChanged, optItnFormatPlain.CheckedChanged
        Try
            If CType(sender, RadioButton).Checked Then
                If Not mflgLoading Or Not mflgLoadingItin Then
                    If Not MySettings Is Nothing Then
                        ChangeItinFormat(True)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub optItnFormat_CheckedChanged(sender As Object, e As EventArgs) Handles optItnFormatSeaChefs.CheckedChanged, optItnFormatSeaChefsWith3LetterCode.CheckedChanged, optItnFormatEuronav.CheckedChanged, optItnFormatFleet.CheckedChanged, optItnFormatAimeryMoxie.CheckedChanged
        Try
            If CType(sender, RadioButton).Checked Then
                If Not mflgLoading Or Not mflgLoadingItin Then
                    If Not MySettings Is Nothing Then
                        ChangeItinFormat(False)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ChangeItinFormat(ByVal pSetITNEnabled As Boolean)
        Try
            If Not mflgLoading Or Not mflgLoadingItin Then
                If Not MySettings Is Nothing Then
                    If optItnFormatDefault.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.DefaultFormat
                    ElseIf optItnFormatPlain.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.Plain
                    ElseIf optItnFormatSeaChefs.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.SeaChefs
                    ElseIf optItnFormatSeaChefsWith3LetterCode.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode
                    ElseIf optItnFormatEuronav.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.Euronav
                    ElseIf optItnFormatFleet.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.Fleet
                    ElseIf optItnFormatAimeryMoxie.Checked Then
                        MySettings.FormatStyle = EnumItnFormat.AimeryMoxie
                    End If
                    MySettings.Save()

                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                    mflgLoadingItin = True
                    SetITNEnabled(pSetITNEnabled)
                    mflgLoadingItin = False
                End If
            End If
        Catch ex As Exception
            Throw New Exception("ChangeItinFormat()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub cmdItnFormatOSMLoG_Click(sender As Object, e As EventArgs) Handles cmdItnFormatOSMLoG.Click
        Try
            If mobjPNR.Segments.Count > 0 And mobjPNR.Passengers.Count > 0 Then
                Dim pOSMLoG = New OSMLog
                pOSMLoG.CreatePDF(mobjPNR)
            Else
                MessageBox.Show("PNR must have passengers and segments to produce a Letter of Guarantee")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub lstItnRemarks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstItnRemarks.SelectedIndexChanged
        Try
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub webItnDoc_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webItnDoc.DocumentCompleted

        Try
            If optItnFormatEuronav.Checked Then
                Dim dobj As New DataObject
                dobj.SetData(DataFormats.Text, webItnDoc.Document.Body.InnerText)
                dobj.SetData(DataFormats.Html, webItnDoc.DocumentStream)
                Clipboard.Clear()
                Clipboard.SetDataObject(dobj, True)
            End If
        Catch ex As Exception
            ' ignore any error that occurs when copying to clipboard
        End Try

    End Sub

    Private Sub ItnReadCurrentPNR()
        Dim mGDSUser As New GDSUser(mSelectedGDSCode)
        mSelectedBOCode = InitSettings(mGDSUser)
        SetupPCCOptions()
        lblItnPNRCounter.Text = ""
        ReadPNRandCreateItn(False)
        cmdItnRefresh.Enabled = True
        cmdItnFormatOSMLoG.Enabled = True
    End Sub

    Private Sub ProcessRequestedPNRs(ByVal RefreshOnly As Boolean)

        Try

            If Not RefreshOnly Then
                'ReDim mudtPaxNames(0)
                readGDS("")
            End If
            If optItnFormatEuronav.Checked Then
                Dim pWebDoc As New ItnWebDoc(mobjPNR)
                rtbItnDoc.Visible = False
                webItnDoc.Width = rtbItnDoc.Width
                webItnDoc.Height = rtbItnDoc.Height
                webItnDoc.Left = rtbItnDoc.Left
                webItnDoc.Top = rtbItnDoc.Top
                webItnDoc.Visible = True
                webItnDoc.BringToFront()
                webItnDoc.DocumentText = ItnWebDocElements.WebHead & pWebDoc.WebDoc & ItnWebDocElements.WebClose
            Else
                webItnDoc.Visible = False
                rtbItnDoc.Visible = True
                rtbItnDoc.Clear()
                makeRTBDoc()
            End If
        Catch ex As Exception
            Throw New Exception("ProcessRequestedPNRs(RefreshOnly)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ProcessRequestedPNRs(ByVal txtPNR As TextBox)

        Try
            Dim pPNR() As String = txtPNR.Text.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim pWebItn As String = ""
            Dim pWebDoc As New ItnWebDoc(mobjPNR)
            'ReDim mudtPaxNames(0)
            If optItnFormatEuronav.Checked Then

                webItnDoc.Width = rtbItnDoc.Width
                webItnDoc.Height = rtbItnDoc.Height
                webItnDoc.Left = rtbItnDoc.Left
                webItnDoc.Top = rtbItnDoc.Top
                webItnDoc.Visible = True
                rtbItnDoc.Visible = False
                pWebItn = ItnWebDocElements.WebHead
            Else
                webItnDoc.Visible = False
                rtbItnDoc.Visible = True
                rtbItnDoc.Clear()
            End If
            For i As Integer = pPNR.GetLowerBound(0) To pPNR.GetUpperBound(0)
                lblItnPNRCounter.Text = i + 1 & " of " & pPNR.GetUpperBound(0) + 1
                If pPNR(i).Trim <> "" Then
                    readGDS(pPNR(i).Trim)
                    If optItnFormatEuronav.Checked Then
                        pWebItn &= pWebDoc.WebDoc
                    Else
                        makeRTBDoc()
                    End If
                End If
            Next
            If optItnFormatEuronav.Checked Then
                pWebItn &= ItnWebDocElements.WebClose()
                webItnDoc.DocumentText = pWebItn
            End If
        Catch ex As Exception
            Throw New Exception("ProcessRequestedPNRs(txtPNR)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub makeRTBDoc()

        Dim pItnRTBDoc As New ItnRTBDoc(mobjPNR, lstItnRemarks)
        Dim pFont As Font = rtbItnDoc.SelectionFont
        Dim pStart As Integer = rtbItnDoc.Text.Length + 1
        If MySettings.FormatStyle = EnumItnFormat.AimeryMoxie Then
            rtbItnDoc.Text &= pItnRTBDoc.makeRTBDocAimeryMoxie
        Else
            If MySettings.FormatStyle = EnumItnFormat.Fleet Then
                rtbItnDoc.Text &= pItnRTBDoc.ATPIRef & vbCrLf
            End If

            rtbItnDoc.Text &= pItnRTBDoc.RTBDocPassengers

            Dim pEnd As Integer = rtbItnDoc.Text.Length

            rtbItnDoc.Select(pStart, pEnd)
            rtbItnDoc.SelectionFont = New Font(pFont, FontStyle.Bold)
            rtbItnDoc.Text &= pItnRTBDoc.makeRTBDoc
        End If

    End Sub

    Private Sub ReadPNRandCreateItn(ByVal RefreshOnly As Boolean)

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            ProcessRequestedPNRs(RefreshOnly)
            CopyItinToClipboard()
        Catch ex As Exception
            Throw New Exception("ReadPNRandCreateItn" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub SetITNEnabled(ByVal AllowOptions As Boolean)
        fraItnAirportName.Enabled = AllowOptions
        fraItnOptions.Enabled = AllowOptions
        lstItnRemarks.Enabled = AllowOptions
    End Sub

    Private Sub CopyItinToClipboard()

        Try
            If Not optItnFormatEuronav.Checked Then
                rtbItnDoc.SelectAll()
                Clipboard.Clear()
                Clipboard.SetText(rtbItnDoc.Rtf, TextDataFormat.Rtf)
                Clipboard.SetText(rtbItnDoc.SelectedText, TextDataFormat.Text)
            End If
        Catch ex As Exception
            ' ignore any error that occurs when copying to clipboard
        End Try

    End Sub

    Private Sub txtPNR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtItnPNR.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    cmdItn1AReadPNR.Enabled = (txtItnPNR.Text.Trim.Length >= 6)
                    cmdItn1AReadQueue.Enabled = (txtItnPNR.Text.Trim.Length >= 2)
                    cmdItn1GReadPNR.Enabled = cmdItn1AReadPNR.Enabled
                    cmdItn1GReadQueue.Enabled = cmdItn1AReadQueue.Enabled
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SetupPCCOptions()
        Try
            If Not MySettings Is Nothing Then
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
                If CheckOptions() Then
                    ' itinerary tab
                    LoadRemarks()
                    If MySettings.AirportName = 0 Then
                        optItnAirportCode.Checked = True
                    ElseIf MySettings.AirportName = 1 Then
                        optItnAirportname.Checked = True
                    ElseIf MySettings.AirportName = 2 Then
                        optItnAirportBoth.Checked = True
                    ElseIf MySettings.AirportName = 3 Then
                        optItnAirportCityName.Checked = True
                    ElseIf MySettings.AirportName = 4 Then
                        optItnAirportCityBoth.Checked = True
                    End If

                    Select Case MySettings.FormatStyle
                        Case EnumItnFormat.DefaultFormat
                            optItnFormatDefault.Checked = True
                        Case EnumItnFormat.Plain
                            optItnFormatPlain.Checked = True
                        Case EnumItnFormat.SeaChefs
                            optItnFormatSeaChefs.Checked = True
                        Case EnumItnFormat.SeaChefsWithCode
                            optItnFormatSeaChefsWith3LetterCode.Checked = True
                        Case EnumItnFormat.Euronav
                            optItnFormatEuronav.Checked = True
                        Case EnumItnFormat.Fleet
                            optItnFormatFleet.Checked = True
                    End Select
                    SetITNEnabled(True)

                    chkItnVessel.Checked = MySettings.ShowVessel
                    chkItnClass.Checked = MySettings.ShowClassOfService
                    chkItnAirlineLocator.Checked = MySettings.ShowAirlineLocator
                    chkItnTickets.Checked = MySettings.ShowTickets
                    chkItnEMD.Checked = MySettings.ShowEMD
                    chkItnPaxSegPerTicket.Checked = MySettings.ShowPaxSegPerTkt
                    chkItnSeating.Checked = MySettings.ShowSeating
                    chkItnStopovers.Checked = MySettings.ShowStopovers
                    chkItnTerminal.Checked = MySettings.ShowTerminal
                    chkItnFlyingTime.Checked = MySettings.ShowFlyingTime
                    chkItnCostCentre.Checked = MySettings.ShowCostCentre
                    chkItnCabinDescription.Checked = MySettings.ShowCabinDescription
                    chkItnItinRemarks.Checked = MySettings.ShowItinRemarks
                    chkItnEquipmentCode.Checked = MySettings.ShowEquipmentCode
                    chkItnCO2.Checked = MySettings.ShowCO2
                    cmdItn1AReadPNR.Enabled = False
                    cmdItn1AReadQueue.Enabled = False
                    cmdItn1GReadPNR.Enabled = False
                    cmdItn1GReadQueue.Enabled = False
                Else
                    Throw New Exception("User not authorized for this PCC")
                End If
            End If
        Catch ex As Exception
        Finally
            mflgLoading = False
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
    Private Sub ShowOptionsForm()
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadRemarks()

        Try
            Dim pRemarksCollection As New RemarksCollection
            pRemarksCollection.Load()
            With lstItnRemarks.Items()
                .Clear()
                For Each pRem As RemarksItem In pRemarksCollection.Values
                    .Add(pRem)
                Next
            End With

        Catch ex As Exception
            Throw New Exception("LoadRemarks()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub readGDS(ByVal RecordLocator As String)

        Try
            mobjPNR.ReadItinerary(mSelectedBOCode, RecordLocator)
            If Not mobjPNR.ExistingElements Is Nothing Then
                If mSelectedBOCode = EnumBOCode.ATH And mobjPNR.ExistingElements.ClientCode = "020208" Then
                    mSelectedBOCode = EnumBOCode.QLI
                    MySettings.CountryCode = "CY"
                    mobjPNR.ReadItinerary(mSelectedBOCode, RecordLocator)
                End If
                lblClient.Text = mobjPNR.ExistingElements.ClientCode & " " & mobjPNR.ExistingElements.ClientName
            End If
        Catch ex As Exception
            Throw New Exception("readGDS()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub frm03Itinerary_Load(sender As Object, e As EventArgs) Handles Me.Load

        cmdItnFormatOSMLoG.Enabled = False
        SetupPCCOptions()
    End Sub

End Class