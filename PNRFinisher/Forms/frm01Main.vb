Option Strict On
Option Explicit On
Public Class frm01Main
    Private Const VersionText As String = "V 4.2 HOTFIX (31/01/2020 10:36)"
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
    ' V 4.0 (07/11/2019 12:11)
    ' 1. Change form to MDI
    ' 2. Add facility to read corporate deals per vessel 
    ' 3. Add option in OSM LoG so that the Copmpany that covers exp[enses is not always our client
    ' these were the requirements as listed previously
    ' 8. There is a requirement that the airline corporate deals can be connected to a vessel and not to the client
    ' 9. In OSM LoG, the guarantor of the expenses can be other than the client
    ' V 4.1 (07/11/2019 14:17)
    ' I had to publish again because I had left in 2 command which were used for testing the
    ' Price Optimiser and it was running always as user 9680TN
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
    ' 5. Nationality reference fields for WSM
    ' 6. Vessel is not picked up correctly for OSM LoG
    ' 7. When reading existing PNRs, the references can be confusing depending if they are from Athens, Crewlink, Discovery etc

    Private pfrmFinisher As frm02Finisher
    Private pfrmItinerary As frm03Itinerary
    Private pfrmOSM As frm04OSM

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub FinisherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinisherToolStripMenuItem.Click
        Try
            ShowFinisher()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ShowFinisher()
        If pfrmFinisher Is Nothing OrElse pfrmFinisher.IsDisposed Then
            pfrmFinisher = New frm02Finisher With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Maximized}
        End If
        pfrmFinisher.Show()
        pfrmFinisher.BringToFront()

    End Sub
    Private Sub ItineraryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItineraryToolStripMenuItem.Click
        If pfrmItinerary Is Nothing OrElse pfrmItinerary.IsDisposed Then
            pfrmItinerary = New frm03Itinerary With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Maximized}
        End If
        pfrmItinerary.Show()
        pfrmItinerary.BringToFront()
    End Sub

    Private Sub OSMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OSMToolStripMenuItem.Click
        If pfrmOSM Is Nothing OrElse pfrmOSM.IsDisposed Then
            pfrmOSM = New frm04OSM With {
            .MdiParent = Me,
            .WindowState = FormWindowState.Maximized}
        End If
        pfrmOSM.Show()
        pfrmOSM.BringToFront()
    End Sub

    Private Sub frmFormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        SSVersion.Text = VersionText
        ShowFinisher()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        Try
            Dim pfrmAdmin As New frmUser(EnumGDSCode.Amadeus, "ATHG42100", "9044CN")
            MessageBox.Show(pfrmAdmin.ShowDialog(Me).ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PriceOptimizerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceOptimizerToolStripMenuItem.Click
        ShowPriceOptimiser(Me, True)
    End Sub
End Class