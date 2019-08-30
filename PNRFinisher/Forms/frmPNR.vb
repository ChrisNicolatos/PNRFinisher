Option Strict On
Option Explicit On
Public Class frmPNR
    Private Const VersionText As String = "V 3.17 (18/06/2019 16:45)"
    ' 08/11/2018 17:11
    ' 1. Show EMD Tickets and ancillary services description
    ' 2. Show RIR and *RI
    ' 22/11/2018 10:39
    ' 1. Galileo read HDE tickets failed
    '    when tickets were from office
    '    and the program returned UNABLE TO PROCESS ELECTRONIC TICKET DISPLAY
    '    I made a change so that the ticket number was retrieved from the TE line
    ' 2. Changed the layout of the Seat Assignment in itinerary
    '    so as to remove the extra blank lines at the end of the itinerary
    '    These were inserted from the add remarks routine which added CRLF for blank lines as well
    ' 23/11/2018 13:22
    ' 1. Airline Notes error for SK elements. A period(.) was added asfter the SK command making the entry invalid
    '    The program now uses the anAmadeusEntry field from the AirlineNotes table rather than building the command
    '    from the element and text fields
    ' 26/11/2018
    ' 1. Mileage membership card Galileo. If the plating carrier does not match the MM carrier the netry was ignored
    '    I have changed this and now all MM entries that do not match plating carriers are added at the bottom of the tickets (Fouli)
    ' 2. Price Optimiser form. New button Expand/Shrink will make the form small at the top left of the screen. 
    '    The user can click on the Expand button to see it or the Shrink button to make it small (this is the same button which changes name)
    '    When the form is shrunk, it will expand automatically if the list of PNRs changes or if the user clicks on the "Read PNR" button
    '    10 times while the form is shrunken. (Katerina)
    ' 3. New Itinerary layout for Fleet (Fleet)
    ' 12/12/2018 10:13 Build 72
    ' 1. Calculate Connection Time for Galileo PNR. (Fleet)
    ' 2. In Galileo Itinerary, void and refunded tickets were shown in tickets list. Now fixed (Fouli)
    ' 3. New options for the shrunken Price Optimisation screen. Four new buttons to move it to top, bottom, left right corners (Katerina)
    ' 4. In Galileo itinerary, when there were multiple Mileage Membership numbers, the wrong airline could be shown (Fouli)
    ' 12/12/2018 11:38 Build 73
    ' 1. ARNK Surface segment leaves elements with NOTHING value. Now fixed. (Agorastos)
    ' 12/12/2018 11:57 (PNRFinisher_3_0_0_0)
    ' 1. Optimise Form - if form is not shrunken then show in task bar, if shrunken, do not show in task bar (Karakostas)
    ' 2. Changed Average Price query to use parameters and not inline variables (Papanastasiou)
    ' 3. Moved project source code to C:\Users\Chris.Nicolatos\Documents\Visual Studio 2017\Projects\PNRFinisher (me)
    ' 4. Close off entries for Galileo had a spurious "I" (ignore) command which lost entries that were not QEB (Takis)
    ' 18/12/2018 12:51 (PNRFinisher_3_0_0_1)
    ' 1. Error in OSM LoG - When selecting office without a signee name (CYPRUS), the program should pick up the booked by name
    '    but it doesn't. It reads the booked by and displays it but doesn't store it in the Signed By field for the 
    '    PDF file. Now fixed (Agorastos)
    ' 01/02/2019 10:07 (PNRFinisher_3_0_0_2)
    ' 1. Itinerary helper replaces the Average Price module (I have not made public the option to enter ... as a city code specifying ANY AIRPORT)
    ' 04/02/2019 14:49 (PNRFinisher_3_0_0_3)
    ' 1. Urgent hotfix - Itinerary helper form crashes with disposed form when clicked a second time
    ' 08/02/2019 10:57 (PNRFinisher_3_0_0_4)
    ' 1. Added a new itinerary format for OSM Aimery/Moxie
    ' 11/02/2019 10:42 (PNRFinisher_3_0_0_6)
    ' 1. Added tickets info in itinerary format for OSM Aimery/Moxie
    ' 2. In frmPriceOptimiser if the PCC is blank, could not set Status to Ignored/Actioned nor open PNR in GDS. This has now been fixed.
    ' 19/02/2019 12:25 (PNRFinisher_3_0_0_7)
    ' 1. Add new functionality in Alerts Collection to send particular clients PNRs to a queue at time of booking
    '    When an alert that has client code, no finisher alert, no downsell alert then the Queue Numbers (1A and 1G)
    '    are used to send all PNRs for the client  to the specified queues.
    ' 05/03/2019
    ' 1. Change the flow of the cost centre form to make it quicker
    '    - search starts auomatically when 3 characters have been entered
    '    - when entering search string, enter triggers the search
    '    - there is also a button to trigger the search
    ' 20/03/2019 15:00 (PNRFinisher_3_0_0_8)
    ' 1. GDSReadPNR1G.GetTicketsHTEParser was crashing because of a short string. Changed the AND to ANDALSO
    ' 2. Added a new itinerary option to show the equipment code per segment
    ' 11/04/2019 12:00 (PNRFinisher_3_0_0_9)
    ' 1. Itinerary Connection time in Amadeus is wrong when it is greater than 9:59 (DM command in Amadeus is a 3 digit number giving 1 digit hour and 2 digit minutes)
    '    Instead of taking the connection time from the DM command in GDSReadPNR.GetSegs1A(), calculate the connection time from the previous arrival and the current departure times
    ' 2. Terminal number when there are stopovers with terminals are wrong because the program reads the last DEPARTURE TERMINAL from DO command and this is
    '    usually the stopover point's terminal and not the boarding point's terminal. Changed GDSSegItem.AnalyseSegDo1A() to look for airport code as well in the
    '    lines containing the text "DEPARTURE" and "ARRIVAL" for the relevant terminals
    ' 19/04/2019 12:37  (PNRFinisher_3_0_0_10)
    ' 1. Price Optimiser
    '    Added three new text boxes:
    '       - Time now
    '       - Amadeus last check
    '       - Galileo last check
    '    these show the time the downsell manager last wrote the START record to the log. If the time is more than 1 hour, the display is orange, else white
    ' 2. Price Optimiser
    '    The lookup for which PNRs are shown to the Team Leader has been enhanced and will select PNR depending on the client's Operations Group as well as the'
    '    agent's sign. Therefore a PNR created for a client by an agent who doesn't belong to the client's ops group will now show in the team leader of the
    '    group where the client belongs as well as the team leader of the agent who created it
    ' 22/04/2019 14:55  (PNRFinisher_3_0_0_11)
    ' 1. frmPriceOptimiser
    '    Changed the format string for the time in the text boxes. It was hh instaed of HH and showed the time in 12-hour format instead of 24-hour format which is more legible
    ' 07/05/2019 16:47  (PNRFinisher_3_0_0_12)
    ' 1. In GDSReadPNR.GetSegs1A() added a check to ignore FLWN segments because they cause havoc with the calculation of flown segments
    '    However, by leaving them out, problems arise when matching tickets to segments.
    ' 13/05/2019 15:17  (PNRFinisher_3_0_0_13)
    ' 1. GDSReadPNR1G.GetPassengers1G() added the line
    '    pAllPax = pAllPax.Replace(".I/",".")
    '    so as to bypass Infant Passenger which caused the passenger name parser to crash. This is a workaround and not a solution
    ' 14/06/2019 11:00  (PNRFinisher_3_0_0_14)
    ' 1. Hotfix - added Cost Centres (CC2) for Discovery database
    ' 14/06/2019 15:13  (PNRFinisher_3_0_0_15)
    ' 1. Added Pax contact information as per IATA Mandate 830D
    ' 14/06/2019 15:45  (PNRFinisher_3_0_0_16)
    ' URGENT Fix for baggage allowance
    ' In Baggage AllowanceCollection.AddItem()
    ' added a check that the key does not exist in the collection before adding it. For complex TQTs this could crash
    ' REMEMBER TO REMOVE UNNECCESSARY COLUMNS FROM PaxApisInformation
    ' ppQRFrequentFlyer
    ' ppIDNumber
    ' ppRank
    ' ppEmail
    ' ppMobile
    ' AFTER THE NEW VERSION HAS BEEN INSTALLED 
    ' 18/06/2019 16:46  (PNRFinisher_3_0_0_17)
    ' 1. Added an option for CO2 allowance in the itineraries


    ' TODO
    ' 1. start setting up the Finisher to handle scenarios (OSM/Takis)
    ' Scenarios will be set up depending on the type of booking:
    '   - ATH booking with ATH tickets - this is the normal everyday case all remarks pertain to one office
    '   - QLI bookings with QLI tickets - same as the above
    '   - ATH bookings with QLI tickets in this case we add remarks:
    '               - for ATH the client details from Travel Force
    '               - for QLI remarks showing the client as Athens
    '               - for ATH, an ADG/CONSOL line showing QLI as the supplier
    '               - QLI back office will be updated automatically from the AIR/MIR file when the ticket is issued
    '               - ATH back office will require a manual BT/TKPDAD command to update the back office
    '   - QLI bookings with ATH tickets in this case we add remarks:
    '               - for QLI the client details from Discovery
    '               - for ATH remarks showing the client as Cyprus
    '               - for QLI, an ADG/CONSOL line showing ATH as the supplier
    '               - ATH back office will be updated automatically from the AIR/MIR file when the ticket is issued
    '               - QLI back office will require a manual BT/TKPDAD command to update the back office
    ' 2. OSM needs a facility to enter ranks as a DI field (OSM/Takis)
    ' 3. ID and RANK to be entered in the docs grid to be entered in the name field as (ID.....)
    '    Give an option to the user to select which items should be entered - None, ID, ID-Rank, ID-Rank-Nationality, Rank only, etc
    '    Possibly set up a field to specify the required format per client
    ' 4. One time vessel is not working
    Private mSelectedGDSCode As EnumGDSCode
    Private mflgLoading As Boolean
    Private mflgLoadingItin As Boolean
    Private mflgAPISUpdate As Boolean
    Private mflgExpiryDateOK As Boolean
    Private mOSMAgentIndex As Integer = -1
    Private mOSMAgents As New OSMEmailCollection

    Private mfrmOptimiser As frmPriceOptimiser
    Private mfrmItinHelper As frmItineraryHelper
    Private mfrmCTC As New frmPaxCTC
    Private mfrmCTCPax As New frmPaxCTCOnlyPax
    Private mobjCustomerSelected As CustomerItem
    Private mobjSubDepartmentSelected As SubDepartmentItem
    Private mobjCRMSelected As CRMItem
    Private mobjVesselSelected As VesselItem
    Private mobjGender As New ReferenceGenderCollection
    Private mobjAirlinePoints As New AirlinePointsCollection
    Private mobjCTC As New CTCPaxCollection

    Private mobjPNR As New GDSReadPNR
    Private mOSMPax As New OSMPaxCollection
    Private mflgReadPNR As Boolean

#Region "Events"
    Private Sub frmPNR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mflgLoading = True
            SSVersion.Text = VersionText
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, cmdItnExit.Click
        Me.Close()
    End Sub
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
    Private Sub PNRReadPNR()
        Try
            ClearForm()
            ReadPNR(mSelectedGDSCode)
            ShowPriceOptimiser()
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    PopulateCustomerList(txtCustomer.Text)
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
    Private Sub llbOptions_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOptions.LinkClicked

        Try
            ShowOptionsForm()

            If Not CheckOptions() Then
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    Private Sub cmdItn1AReadPNR_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadPNR.Click

        mSelectedGDSCode = EnumGDSCode.Amadeus
        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim mGDSUser As New GDSUser(EnumGDSCode.Amadeus)
            InitSettings(mGDSUser, 0)
            SetupPCCOptions()
            lblItnPNRCounter.Text = ""
            ProcessRequestedPNRs(txtItnPNR)
            CopyItinToClipboard()
            cmdItnRefresh.Enabled = False
            cmdItnFormatOSMLoG.Enabled = True
            Cursor = Cursors.Default
            MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdItnReadQueue_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadQueue.Click

        Try
            lblItnPNRCounter.Text = ""
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            txtItnPNR.Text = mobjPNR.RetrievePNRsFromQueue(txtItnPNR.Text)
            mSelectedGDSCode = EnumGDSCode.Amadeus
            Dim mGDSUser As New GDSUser(mSelectedGDSCode)
            InitSettings(mGDSUser, 0)
            SetupPCCOptions()
            ProcessRequestedPNRs(txtItnPNR)
            CopyItinToClipboard()
            cmdItnRefresh.Enabled = False
            cmdItnFormatOSMLoG.Enabled = False
            Cursor = Cursors.Default
            MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdItnRead1ACurrent_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadCurrent.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Amadeus
            ITNReadCurrent()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmdItnRead1GCurrent_Click(sender As Object, e As EventArgs) Handles cmdItn1GReadCurrent.Click
        Try
            mSelectedGDSCode = EnumGDSCode.Galileo
            ITNReadCurrent()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ITNReadCurrent()
        Try
            ItnReadCurrentPNR()
            ShowPriceOptimiser()
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
    Private Sub cmdCostCentre_Click(sender As Object, e As EventArgs) Handles cmdCostCentre.Click

        Try
            Dim pfrmcostCentre As New frmCostCentre(MySettings.PCCBackOffice)
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

    Private Sub cmdItineraryHelper_Click(sender As Object, e As EventArgs) Handles cmdItineraryHelper.Click

        Try
            If mfrmItinHelper.IsDisposed Then
                mfrmItinHelper = New frmItineraryHelper(MySettings.PCCBackOffice)
            End If
            mfrmItinHelper.Location = Me.Location
            mfrmItinHelper.DisplayItinerary(mobjPNR.Itinerary)
            mfrmItinHelper.Show()
            mfrmItinHelper.BringToFront()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    'Private Sub cmdAveragePrice_Click(sender As Object, e As EventArgs)

    '    Try
    '        Dim pAveragePrice As New AveragePriceCollection
    '        Dim pFromDate As Date = DateAdd(DateInterval.Month, -3, Today)
    '        pFromDate = DateSerial(Year(pFromDate), Month(pFromDate), 1)
    '        With pAveragePrice
    '            .SetValues(pFromDate, mobjPNR.Itinerary)
    '            If .Load() Then
    '                lblAvPriceDetails.Text = MySettings.OfficeCityCode & " office:From: " & DateToIATA(.FromDate) & "  " & .Itinerary
    '                lblAveragePrice.Text = .TicketCount & " tkts - Avge Price (incl taxes): " & Format(.AveragePrice, "#,##0 EUR")
    '            Else
    '                lblAvPriceDetails.Text = "Cannot calculate round trip"
    '                lblAveragePrice.Text = ""
    '            End If
    '        End With
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
#Region "OSM"

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
#End Region
    Private Sub tabPNR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPNR.SelectedIndexChanged
        Try
            mflgLoading = True
            If tabPNR.SelectedIndex = 1 Then
                cmdItnFormatOSMLoG.Enabled = False
            ElseIf tabPNR.SelectedIndex = 2 Then
                OSMRefreshVesselGroup(cmbOSMVesselGroup)
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
                cmdOSMCopyDocument.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
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
    Private Sub MenuCopyItn_Click(sender As Object, e As EventArgs) Handles MenuCopyItn.Click
        Try
            rtbItnDoc.SelectAll()
            Clipboard.Clear()
            Clipboard.SetText(rtbItnDoc.Rtf, TextDataFormat.Rtf)
            Clipboard.SetText(rtbItnDoc.SelectedText, TextDataFormat.Text)
        Catch ex As Exception
            ' ignore any error that occurs when copying to clipboard
        End Try
    End Sub
    Private Sub cmdAdmin_Click(sender As Object, e As EventArgs) Handles cmdAdmin.Click
        Try
            Dim pfrmAdmin As New frmUser(EnumGDSCode.Amadeus, "ATHG42100", "9044CN")
            MessageBox.Show(pfrmAdmin.ShowDialog(Me).ToString)
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

    Private Sub cmdPriceOptimiser_Click(sender As Object, e As EventArgs) Handles cmdPriceOptimiser.Click

        ShowPriceOptimiser()

    End Sub
#End Region

#Region "Local Functions"
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
    Private Sub ClearForm()

        Try
            mobjCustomerSelected = New CustomerItem
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

            txtCustomer.Clear()
            txtSubdepartment.Clear()
            txtCRM.Clear()
            txtVessel.Clear()
            lstAirlineEntries.Items.Clear()

            lstVessels.Items.Clear()

            lstSubDepartments.Items.Clear()
            txtSubdepartment.Enabled = (lstSubDepartments.Items.Count > 0)

            lstCRM.Items.Clear()
            txtCRM.Enabled = (lstCRM.Items.Count > 0)

            txtReference.Clear()
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

            APISPrepareGrid(dgvApis)

        Catch ex As Exception
            Throw New Exception("ClearForm()" & vbCrLf & ex.Message)
        End Try

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
    Private Sub ItnReadCurrentPNR()
        Dim mGDSUser As New GDSUser(mSelectedGDSCode)
        InitSettings(mGDSUser, 0)
        SetupPCCOptions()
        lblItnPNRCounter.Text = ""
        ReadPNRandCreateItn(False)
        cmdItnRefresh.Enabled = True
        cmdItnFormatOSMLoG.Enabled = True
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
    Private Sub PopulateCRMList(ByVal SearchString As String)

        Try
            Dim pobjCRM As New CRMCollection

            If SearchString = "" Then
                mobjCRMSelected = Nothing
                mobjPNR.NewElements.SetCRM(0, "", "")
            End If
            lstCRM.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then
                pobjCRM.Load(mobjCustomerSelected.ID, MySettings.PCCBackOffice)

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
    Private Sub PopulateCustomerList(ByVal SearchString As String)

        Try
            Dim pCustomers As New CustomerCollection

            pCustomers.Load(SearchString, MySettings.PCCBackOffice)

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
    Private Sub PopulateSubdepartmentsList(ByVal SearchString As String)

        Try
            Dim pobjSubDepartments As New SubDepartmentCollection

            If SearchString = "" Then
                mobjSubDepartmentSelected = Nothing
                mobjPNR.NewElements.SetSubDepartment(0, "", "")
            End If
            lstSubDepartments.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then
                pobjSubDepartments.Load(mobjCustomerSelected.ID, MySettings.PCCBackOffice)

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

            If Not mobjCustomerSelected Is Nothing Then

                pobjVessels.Load(mobjCustomerSelected.ID, MySettings.PCCBackOffice)

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
    Private Sub readGDS(ByVal RecordLocator As String)

        Try
            If RecordLocator = "" Then
                mobjPNR.CancelError = True
            Else
                mobjPNR.CancelError = False
            End If
            mobjPNR.Read(mSelectedGDSCode, RecordLocator)
        Catch ex As Exception
            Throw New Exception("readGDS()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ReadPNR(ByVal GDSCode As EnumGDSCode)
        Dim pDMI As String
        Try
            With mobjPNR
                mflgReadPNR = False
                Dim mGDSUser As New GDSUser(GDSCode)
                InitSettings(mGDSUser, 0)
                SetupPCCOptions()
                pDMI = .Read(GDSCode)
                If .NumberOfPax = 0 And Not .IsGroup Then
                    Throw New Exception("Need passenger names")
                End If
                If pDMI <> "" Then
                    If MessageBox.Show("There is a problem with your itinerary. Do you want to cancel the PNR Finisher?" & vbCrLf & vbCrLf & pDMI, "Itinerary Check", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Throw New Exception("PNR Finisher cancelled because of itinerary check")
                    End If
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
                txtSubdepartment.Clear()
                txtCRM.Clear()
                txtVessel.Clear()

                txtReference.Text = .Reference.Key
                txtSubdepartment.Text = .SubDepartmentCode.Key
                txtCRM.Text = .CRMCode.Key
            End With

            If pstrCustomerCode <> "" Then
                Dim pCustomer As New CustomerItem
                pCustomer.Load(pstrCustomerCode, MySettings.PCCBackOffice)
                txtCustomer.Text = pCustomer.Code
                If pintSubDepartment <> 0 Then
                    Dim pSub As New SubDepartmentItem
                    pSub.Load(pintSubDepartment, MySettings.PCCBackOffice)
                    txtSubdepartment.Text = pSub.Code & " " & pSub.Name
                End If
                If Not pstrCRM Is Nothing AndAlso pstrCRM.Length > 0 Then
                    Dim pSub As New CRMItem
                    pSub.Load(pstrCRM, MySettings.PCCBackOffice)
                    txtCRM.Text = pSub.Code & " " & pSub.Name
                End If

                If pstrVesselName <> "" Then
                    Dim pVessel As New VesselItem
                    If pVessel.Load(pstrCustomerCode, pstrVesselName, MySettings.PCCBackOffice) Then
                        mobjPNR.NewElements.VesselNameForPNR.Clear()
                        mobjPNR.NewElements.VesselFlagForPNR.Clear()
                        txtVessel.Text = pVessel.Name
                    Else
                        mobjPNR.NewElements.SetVesselForPNR(pstrVesselName, pstrVesselRegistration)
                        txtVessel.Text = mobjPNR.NewElements.VesselNameForPNR.TextRequested & " REG " & mobjPNR.NewElements.VesselFlagForPNR.TextRequested
                    End If
                End If

                DisplayOldCustomProperty(cmbBookedby, mobjPNR.ExistingElements.BookedBy)
                DisplayOldCustomProperty(cmbDepartment, mobjPNR.ExistingElements.Department)
                DisplayOldCustomProperty(cmbReasonForTravel, mobjPNR.ExistingElements.ReasonForTravel)
                DisplayOldCustomProperty(cmbCostCentre, mobjPNR.ExistingElements.CostCentre)
                DisplayOldCustomProperty(txtTrId, mobjPNR.ExistingElements.TRId)

                txtReference.Text = mobjPNR.ExistingElements.Reference.Key
                PrepareAdditionalEntries()
            End If
        Catch ex As Exception
            Throw New Exception("DisplayCustomer()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PrepareAdditionalEntries()
        lstAirlineEntries.Items.Clear()
        PrepareAirlinePoints()
        If Not mobjPNR.SSRCTCExists Then
            PrepareCTC()
        End If
    End Sub
    Private Sub PrepareCTC()
        Try
            Dim pFound As String = ""
            Dim pNotFound As String = ""
            mobjCTC.Load(MySettings.PCCBackOffice, mobjCustomerSelected.ID)
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
                            lstAirlineEntries.Items.Add(pCTCCommand(i), True)
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
    Private Sub PrepareAirlinePoints()
        Try
            Dim pFound As Boolean = False

            If mobjCustomerSelected.ID <> 0 Then
                'Dim pAirlinePoints As New AirlinePointsCollection
                For Each pSeg As GDSSegItem In mobjPNR.Segments.Values
                    mobjAirlinePoints.Load(mobjCustomerSelected.ID, pSeg.Airline, mobjPNR.GDSCode, MySettings.PCCBackOffice)
                    For Each pItem As String In mobjAirlinePoints
                        pFound = False
                        For i As Integer = 0 To lstAirlineEntries.Items.Count - 1
                            If lstAirlineEntries.Items(i).ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstAirlineEntries.Items.Add(pItem, True)
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
                                For i As Integer = 0 To lstAirlineEntries.Items.Count - 1
                                    If lstAirlineEntries.Items(i).ToString = pGDSCommand Then
                                        pFound = True
                                        Exit For
                                    End If
                                Next
                                If Not pFound Then
                                    lstAirlineEntries.Items.Add(pGDSCommand, True)
                                End If

                            End If
                        End With
                    Next
                Next

                If Not mobjCustomerSelected Is Nothing And Not mobjVesselSelected Is Nothing Then
                    Dim pConditionalEntry As New ConditionalGDSEntryCollection
                    pConditionalEntry.Load(MySettings.PCCBackOffice, mobjCustomerSelected.ID, mobjVesselSelected.Name)
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
                            For i As Integer = 0 To lstAirlineEntries.Items.Count - 1
                                If lstAirlineEntries.Items(i).ToString = pGDSCommand Then
                                    pFound = True
                                    Exit For
                                End If
                            Next
                            If Not pFound Then
                                lstAirlineEntries.Items.Add(pGDSCommand, True)
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
    Private Sub ReadPNRandCreateItn(ByVal RefreshOnly As Boolean)

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            ProcessRequestedPNRs(RefreshOnly)
            CopyItinToClipboard()
            If Not RefreshOnly Then
                MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw New Exception("ReadPNRandCreateItn" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub SelectCRM(ByVal pCRM As CRMItem)

        Try
            mobjCRMSelected = pCRM
            txtCRM.Text = pCRM.ToString
            mobjPNR.NewElements.SetCRM(mobjCRMSelected.ID, mobjCRMSelected.Code, mobjCRMSelected.Name)

            SetEnabled()
            If pCRM.Alert <> "" Then
                MessageBox.Show(pCRM.Alert, pCRM.Code & " " & pCRM.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectCRM()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SelectCustomer(ByVal pCustomer As CustomerItem)

        Try
            mobjPNR.NewElements.ClearCustomerElements()
            mobjCustomerSelected = pCustomer
            txtCustomer.Text = pCustomer.ToString
            mobjPNR.NewElements.SetItem(mobjCustomerSelected, MySettings.PCCBackOffice)

            txtSubdepartment.Clear()
            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            txtCRM.Clear()
            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            txtVessel.Clear()
            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            txtReference.Clear()

            cmbBookedby.Text = ""
            cmbDepartment.Text = ""
            txtTrId.Clear()

            If mobjCustomerSelected.HasVessels Then
                PopulateVesselsList()
            End If

            If mobjCustomerSelected.HasDepartments Then
                PopulateSubdepartmentsList("")
            End If

            PopulateCRMList("")
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
    Private Sub PopulateCustomProperties()

        Try
            cmbBookedby.Items.Clear()
            cmbDepartment.Items.Clear()
            cmbReasonForTravel.Items.Clear()
            cmbCostCentre.Items.Clear()
            cmbBookedby.Enabled = False
            cmbDepartment.Enabled = False
            cmbReasonForTravel.Enabled = False
            cmbCostCentre.Enabled = False
            txtTrId.Enabled = False

            If Not mobjCustomerSelected Is Nothing Then
                For Each pProp As CustomPropertiesItem In mobjCustomerSelected.CustomerProperties.Values
                    If pProp.CustomPropertyID = EnumCustomPropertyID.BookedBy Then
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
        Catch ex As Exception
            Throw New Exception("PopulateCustomproperties()" & vbCrLf & ex.Message)
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
                cmbCombo.Items.Add("")
            End If
            For Each pItem As CustomPropertiesValues In pProp.Value.Values
                cmbCombo.Items.Add(pItem.Value)
            Next
            'For i As Integer = 0 To pProp.ValuesCount - 1
            '    cmbCombo.Items.Add(pProp.Value(i))
            'Next
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
    Private Sub SelectSubDepartment(ByVal pSubDepartment As SubDepartmentItem)

        Try
            mobjSubDepartmentSelected = pSubDepartment
            txtSubdepartment.Text = pSubDepartment.ToString
            mobjPNR.NewElements.SetSubDepartment(mobjSubDepartmentSelected.ID, mobjSubDepartmentSelected.Code, mobjSubDepartmentSelected.Name)

            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectSubDepartment()" & vbCrLf & ex.Message)
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
    Private Sub SetEnabled()

        Dim pProps As CustomPropertiesItem

        Try
            ' read PNR and Exit are always enabled
            cmdPNRRead1APNR.Enabled = True
            cmdExit.Enabled = True
            cmdAdmin.Enabled = False
            cmdPriceOptimiser.Enabled = False
            cmdPriceOptimiser.Visible = False
            If Not MySettings Is Nothing Then
                cmdAdmin.Enabled = MySettings.Administrator
                If MySettings.PriceOptimiser And mflgReadPNR Then
                    cmdPriceOptimiser.Enabled = True
                End If
            End If
            cmdPriceOptimiser.Visible = cmdPriceOptimiser.Enabled
            cmdAdmin.Visible = cmdAdmin.Enabled

            ' customer based entries are enabled if a PNR has been read and there is data available
            txtCustomer.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            lstCustomers.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            cmdCostCentre.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)

            txtSubdepartment.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)
            lstSubDepartments.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)

            txtCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)
            lstCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)

            txtVessel.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)
            lstVessels.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)

            ' the exception is the one time vessel which is always enabled for any PNR
            cmdOneTimeVessel.Enabled = mflgReadPNR

            ' Update is enabled if a PNR has been read and if mandatory fields have been entered
            cmdPNRWrite.Enabled = mflgReadPNR

            ' Customer is always needed

            txtCustomer.BackColor = lstCustomers.BackColor
            txtSubdepartment.BackColor = lstCustomers.BackColor
            txtCRM.BackColor = lstCustomers.BackColor
            If Not mobjPNR.NewElements Is Nothing Then
                If mobjPNR.NewElements.CustomerCode.GDSCommand = "" Then
                    cmdPNRWrite.Enabled = False
                    txtCustomer.BackColor = Color.Red
                End If

                ' if subdepartments exist they are by default madatory
                If mobjPNR.NewElements.CustomerCode.GDSCommand <> "" And lstSubDepartments.Items.Count > 0 And mobjPNR.NewElements.SubDepartmentCode.GDSCommand = "" Then
                    cmdPNRWrite.Enabled = False
                    txtSubdepartment.BackColor = Color.Red
                End If

                ' the code above is complete validation but allow entry without CRM in any case
                If mobjPNR.NewElements.CustomerCode.GDSCommand <> "" And lstCRM.Items.Count > 0 And mobjPNR.NewElements.CRMCode.GDSCommand = "" Then
                    txtCRM.BackColor = Color.Pink
                End If

                If mobjPNR.NewElements.BookedBy.GDSCommand = "" Then
                    lblBookedByHighlight.Text = ""
                    If cmbBookedby.Enabled Then
                        pProps = CType(cmbBookedby.Tag, CustomPropertiesItem)
                        If Not pProps Is Nothing Then
                            lblBookedByHighlight.Text = pProps.Label
                            If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                cmdPNRWrite.Enabled = False
                            End If
                        End If
                    End If
                End If
                If mobjPNR.NewElements.CostCentre.GDSCommand = "" Then
                    lblCostCentreHighlight.Text = ""
                    If cmbCostCentre.Enabled Then
                        pProps = CType(cmbCostCentre.Tag, CustomPropertiesItem)
                        If Not pProps Is Nothing Then
                            lblCostCentreHighlight.Text = pProps.Label
                            If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                cmdPNRWrite.Enabled = False
                            End If
                        End If
                    End If
                End If
                If mobjPNR.NewElements.Department.GDSCommand = "" Then
                    lblDepartmentHighlight.Text = ""
                    If cmbDepartment.Enabled Then
                        pProps = CType(cmbDepartment.Tag, CustomPropertiesItem)
                        If Not pProps Is Nothing Then
                            lblDepartmentHighlight.Text = pProps.Label
                            If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                cmdPNRWrite.Enabled = False
                            End If
                        End If
                    End If
                End If
                If mobjPNR.NewElements.ReasonForTravel.GDSCommand = "" Then
                    lblReasonForTravelHighLight.Text = ""
                    If cmbReasonForTravel.Enabled Then
                        pProps = CType(cmbReasonForTravel.Tag, CustomPropertiesItem)
                        If Not pProps Is Nothing Then
                            lblReasonForTravelHighLight.Text = pProps.Label
                            If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                cmdPNRWrite.Enabled = False
                            End If
                        End If
                    End If
                End If
                If mobjPNR.NewElements.TRId.GDSCommand = "" Then
                    lblTRIDHighLight.Text = ""
                    If txtTrId.Enabled Then
                        pProps = CType(txtTrId.Tag, CustomPropertiesItem)
                        If Not pProps Is Nothing Then
                            lblTRIDHighLight.Text = pProps.Label
                            If pProps.RequiredType = CustomPropertyRequiredType.PropertyReqToSave Then
                                cmdPNRWrite.Enabled = False
                            End If
                        End If
                    End If
                End If
            End If

            cmdPNRWriteWithDocs.Enabled = cmdPNRWrite.Enabled And mflgAPISUpdate
            cmdPNROnlyDocs.Enabled = mflgAPISUpdate And Not mobjPNR.NewPNR
            dgvApis.Enabled = True

            txtReference.Enabled = True

            lblBookedByHighlight.Enabled = (cmbBookedby.Enabled)
            lblDepartmentHighlight.Enabled = (cmbDepartment.Enabled)
            lblReasonForTravelHighLight.Enabled = (cmbReasonForTravel.Enabled)
            lblCostCentreHighlight.Enabled = (cmbCostCentre.Enabled)
            lblTRIDHighLight.Enabled = (txtTrId.Enabled)

            SetLabelColor(lblBookedByHighlight, CType(cmbBookedby.Tag, CustomPropertiesItem))
            SetLabelColor(lblDepartmentHighlight, CType(cmbDepartment.Tag, CustomPropertiesItem))
            SetLabelColor(lblReasonForTravelHighLight, CType(cmbReasonForTravel.Tag, CustomPropertiesItem))
            SetLabelColor(lblCostCentreHighlight, CType(cmbCostCentre.Tag, CustomPropertiesItem))
            SetLabelColor(lblTRIDHighLight, CType(txtTrId.Tag, CustomPropertiesItem))


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
    Private Sub ShowPriceOptimiser()
        If Not MySettings Is Nothing Then
            If MySettings.PriceOptimiser Then
                If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                    Dim pPCC As String = MySettings.GDSPcc
                    Dim pUserId As String = MySettings.GDSUser
                    ' for testing only
#If DEBUG Then
                    'pPCC = "750B"
                    'pUserId = "038981"
#End If
                    'pPCC = "750B"
                    'pUserId = "051244"
                    'Dim pDownsell As New DownsellCollection
                    'If pDownsell.CountNonVerified(pPCC, pUserId) > 0 Then
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
    Private Sub SetITNEnabled(ByVal AllowOptions As Boolean)
        fraItnAirportName.Enabled = AllowOptions
        fraItnOptions.Enabled = AllowOptions
        lstItnRemarks.Enabled = AllowOptions
    End Sub
    Private Sub SetupPCCOptions()
        Try
            mflgLoading = True
            Dim pText As String = ""
            SSVersion.Text = VersionText
            If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                pText &= MySettings.GDSPcc & " " & MySettings.GDSUser
                SSGDS.Text = MySettings.GDSAbbreviation
                SSPCC.Text = MySettings.GDSPcc
                SSUser.Text = MySettings.GDSUser
            Else
                Throw New Exception("No GDS signed in")
            End If

            If CheckOptions() Then
                ' finisher tab
                mflgReadPNR = False
                ClearForm()
                SetEnabled()
                PrepareForm()
                APISPrepareGrid(dgvApis)

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
        Catch ex As Exception
        Finally
            mflgLoading = False
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
    Private Sub ShowOptionsForm()
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function UpdatePNR(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean) As String
        Try
            UpdatePNR = mobjPNR.SendAllGDSEntries(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, lstAirlineEntries)
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

    End Function
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
                mfrmCTCPax.ShowPaxInformation(mobjPNR, MySettings.PCCBackOffice, pClientId, pClientCode, pClientName, pVessel)
                mfrmCTCPax.ShowDialog()
                PrepareAdditionalEntries()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

End Class
