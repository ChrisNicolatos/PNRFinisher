Option Strict On
Option Explicit On
Public Class frmItineraryHelper
    Private mintBackOffice As Integer
    Private mstrOrigin As String = ""
    Private mstrStopover As String = ""
    Private mstrDestination As String = ""
    Private mdteFromDate As Date
    Private mflgFromAirportOnly As Boolean = True
    Private mflgStopoverAirportOnly As Boolean = True
    Private mflgToAirportOnly As Boolean = True
    Private mobjAirportCollection As New IHAirportCollection
    Private mflgIsLoaded As Boolean = False
    Private mflgLoading As Boolean
    Public Sub New(ByVal pBackOffice As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mintBackOffice = pBackOffice

    End Sub
    Private Sub frmItineraryHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mflgLoading = True
            PrepareForm()
            CheckOptions()
            mflgIsLoaded = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub
    Public Sub DisplayItinerary(ByVal Itinerary As String)
        Try
            mstrOrigin = ""
            mstrStopover = ""
            mstrDestination = ""
            Itinerary = Itinerary.Trim
            If Itinerary.Length >= 6 Then
                mstrOrigin = Itinerary.Substring(0, 3)
                If Itinerary.IndexOf(" (") = -1 Then
                    mstrDestination = Itinerary.Substring(Itinerary.Length - 3)
                Else
                    mstrDestination = Itinerary.Substring(Itinerary.IndexOf(" ") - 3, 3)
                End If
            End If
            If Not mflgIsLoaded Then
                Me.Show()
            Else
                PrepareForm()
                CheckOptions()
            End If
            'PrepareForm()
            'CheckOptions()
            If cmdSearch.Enabled Then
                ShowItinerary()
            End If
        Catch ex As Exception
            Throw New Exception("ItineraryHelper.DisplayItinerary()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub PrepareForm()
        Try
            txtOrigin.Text = mstrOrigin
            txtStopover.Text = mstrStopover
            txtDestination.Text = mstrDestination
            mdteFromDate = DateAdd(DateInterval.Month, -3, Today)
            mflgFromAirportOnly = True
            mflgStopoverAirportOnly = True
            mflgToAirportOnly = True
            dtpFromIssueDate.Value = mdteFromDate
            chkFromAirportOnly.Checked = mflgFromAirportOnly
            chkStopoverAirportOnly.Checked = mflgStopoverAirportOnly
            chkToAirportOnly.Checked = mflgToAirportOnly
        Catch ex As Exception
            Throw New Exception("PrepareForm()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub dtpFromIssueDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFromIssueDate.ValueChanged
        If Not mflgLoading Then
            mdteFromDate = dtpFromIssueDate.Value
            CheckOptions()
        End If
    End Sub
    Private Sub CheckOptions()
        cmdSearch.Enabled = (mstrOrigin <> "" And mstrDestination <> "")
        lstFromAirport.Items.Clear()
        If mstrOrigin <> "" Then
            For Each pItem As IHAirportItem In mobjAirportCollection.Load(mstrOrigin, mflgFromAirportOnly).Values
                lstFromAirport.Items.Add(pItem)
            Next
        End If

        lstToAirport.Items.Clear()
        If mstrDestination <> "" Then
            For Each pItem As IHAirportItem In mobjAirportCollection.Load(mstrDestination, mflgToAirportOnly).Values
                lstToAirport.Items.Add(pItem)
            Next
        End If
        lstStopover.Items.Clear()
        If mstrStopover <> "" Then
            For Each pItem As IHAirportItem In mobjAirportCollection.Load(mstrStopover, mflgStopoverAirportOnly).Values
                lstStopover.Items.Add(pItem)
            Next
        End If

    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Try
            ShowItinerary()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SetEnabled()
        End Try
    End Sub
    Private Sub ShowItinerary()
        Try
            SetDisabled()
            LoadTree()
        Catch ex As Exception
            Throw New Exception("ShowItinerary()" & vbCrLf & ex.Message)
        Finally
            SetEnabled()
        End Try

    End Sub
    Private Sub SetDisabled()
        Me.Cursor = Cursors.WaitCursor
        dtpFromIssueDate.Enabled = False
        txtOrigin.Enabled = False
        chkFromAirportOnly.Enabled = False
        lstFromAirport.Enabled = False
        txtStopover.Enabled = False
        chkStopoverAirportOnly.Enabled = False
        lstStopover.Enabled = False
        txtDestination.Enabled = False
        chkToAirportOnly.Enabled = False
        lstToAirport.Enabled = False
        tvwItineraries.Enabled = False
        cmdSearch.Enabled = False
        cmdExit.Enabled = False
    End Sub
    Private Sub SetEnabled()
        dtpFromIssueDate.Enabled = True
        txtOrigin.Enabled = True
        chkFromAirportOnly.Enabled = True
        lstFromAirport.Enabled = True
        txtStopover.Enabled = True
        chkStopoverAirportOnly.Enabled = True
        lstStopover.Enabled = True
        txtDestination.Enabled = True
        chkToAirportOnly.Enabled = True
        lstToAirport.Enabled = True
        tvwItineraries.Enabled = True
        cmdSearch.Enabled = False
        cmdExit.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadTree()
        Dim pItin As New IHItinCollection
        Dim pLevel0 As New TreeNode
        Dim pLevel1 As New TreeNode
        Dim pLevel2 As New TreeNode
        Dim pLevel3 As New TreeNode
        Dim pLevel4 As New TreeNode
        Dim pLevel5 As New TreeNode
        Dim pCurrentLevel = 0
        pItin.Load(mstrOrigin, mstrStopover, mstrDestination, mdteFromDate, mflgFromAirportOnly, mflgStopoverAirportOnly, mflgToAirportOnly)
        tvwItineraries.Nodes.Clear()
        If pItin.Count > 0 Then
            For Each pItem As IHItinItem In pItin
                If pItem.Level = 0 Then
                    pLevel0 = New TreeNode(pItem.Value(pItin.MaxDescLen(0)))
                    If pCurrentLevel >= 5 Then
                        pLevel4.Nodes.Add(pLevel5)
                    End If
                    If pCurrentLevel >= 4 Then
                        pLevel3.Nodes.Add(pLevel4)
                    End If
                    If pCurrentLevel >= 3 Then
                        pLevel2.Nodes.Add(pLevel3)
                    End If
                    If pCurrentLevel >= 2 Then
                        pLevel1.Nodes.Add(pLevel2)
                    End If
                    If pCurrentLevel >= 1 Then
                        pLevel0.Nodes.Add(pLevel1)
                    End If
                ElseIf pItem.Level = 1 Then
                    If pCurrentLevel >= 5 Then
                        pLevel4.Nodes.Add(pLevel5)
                    End If
                    If pCurrentLevel >= 4 Then
                        pLevel3.Nodes.Add(pLevel4)
                    End If
                    If pCurrentLevel >= 3 Then
                        pLevel2.Nodes.Add(pLevel3)
                    End If
                    If pCurrentLevel >= 2 Then
                        pLevel1.Nodes.Add(pLevel2)
                    End If
                    If pCurrentLevel >= 1 Then
                        pLevel0.Nodes.Add(pLevel1)
                    End If
                    pLevel1 = New TreeNode(pItem.Value(pItin.MaxDescLen(1)))
                    If pItem.TotalFarePlusTaxes = pItin.MinTotalFare(pItem.Level) Then
                        pLevel1.BackColor = Color.Yellow
                    End If
                    If pItem.Routing.IndexOf(",") > 0 Then
                        pLevel1.ForeColor = Color.Blue
                    End If
                    pCurrentLevel = 1
                ElseIf pItem.Level = 2 Then
                    If pCurrentLevel >= 5 Then
                        pLevel4.Nodes.Add(pLevel5)
                    End If
                    If pCurrentLevel >= 4 Then
                        pLevel3.Nodes.Add(pLevel4)
                    End If
                    If pCurrentLevel >= 3 Then
                        pLevel2.Nodes.Add(pLevel3)
                    End If
                    If pCurrentLevel >= 2 Then
                        pLevel1.Nodes.Add(pLevel2)
                    End If
                    pLevel2 = New TreeNode(pItem.Value(pItin.MaxDescLen(2)))
                    If pItem.TotalFarePlusTaxes = pItin.MinTotalFare(pItem.Level) Then
                        pLevel2.BackColor = Color.Yellow
                    End If
                    If pItem.TicketingAirline.Length > 2 Then
                        pLevel2.ForeColor = Color.Blue
                    End If
                    pCurrentLevel = 2
                ElseIf pItem.Level = 3 Then
                    If pCurrentLevel >= 5 Then
                        pLevel4.Nodes.Add(pLevel5)
                    End If
                    If pCurrentLevel >= 4 Then
                        pLevel3.Nodes.Add(pLevel4)
                    End If
                    If pCurrentLevel >= 3 Then
                        pLevel2.Nodes.Add(pLevel3)
                    End If
                    pLevel3 = New TreeNode(pItem.Value(pItin.MaxDescLen(3)))
                    If pItem.TotalFarePlusTaxes = pItin.MinTotalFare(pItem.Level) Then
                        pLevel3.BackColor = Color.Yellow
                    End If
                    If pItem.TicketingAirline.Length > 2 Then
                        pLevel3.ForeColor = Color.Blue
                    End If
                    pCurrentLevel = 3
                ElseIf pItem.Level = 4 Then
                    If pCurrentLevel >= 5 Then
                        pLevel4.Nodes.Add(pLevel5)
                    End If
                    If pCurrentLevel >= 4 Then
                        pLevel3.Nodes.Add(pLevel4)
                    End If
                    pLevel4 = New TreeNode(pItem.Value(pItin.MaxDescLen(4)))
                    If pItem.TotalFarePlusTaxes = pItin.MinTotalFare(pItem.Level) Then
                        pLevel4.BackColor = Color.Yellow
                    End If
                    If pItem.TicketingAirline.Length > 2 Then
                        pLevel4.ForeColor = Color.Blue
                    End If
                    pCurrentLevel = 4
                ElseIf pItem.Level = 5 Then
                    If pCurrentLevel >= 5 Then
                        pLevel4.Nodes.Add(pLevel5)
                    End If
                    pLevel5 = New TreeNode(pItem.Value(pItin.MaxDescLen(5)))
                    If pItem.TotalFarePlusTaxes = pItin.MinTotalFare(pItem.Level) Then
                        pLevel5.BackColor = Color.Yellow
                    End If
                    If pItem.TicketingAirline.Length > 2 Then
                        pLevel5.ForeColor = Color.Blue
                    End If
                    pCurrentLevel = 5
                End If
            Next
            If pCurrentLevel >= 5 Then
                pLevel4.Nodes.Add(pLevel5)
            End If
            If pCurrentLevel >= 4 Then
                pLevel3.Nodes.Add(pLevel4)
            End If
            If pCurrentLevel >= 3 Then
                pLevel2.Nodes.Add(pLevel3)
            End If
            If pCurrentLevel >= 2 Then
                pLevel1.Nodes.Add(pLevel2)
            End If
            If pCurrentLevel >= 1 Then
                pLevel0.Nodes.Add(pLevel1)
            End If
            tvwItineraries.Nodes.Add(pLevel0)
            tvwItineraries.Nodes(0).Expand()
        Else
            MessageBox.Show("No bookings found for " & mstrOrigin & " " & mstrDestination & " since " & Format(mdteFromDate, "dd/MM/yyyy"))
        End If

    End Sub
    Private Sub txtOrigin_TextChanged(sender As Object, e As EventArgs) Handles txtOrigin.TextChanged
        If Not mflgLoading Then
            If txtOrigin.Text.Trim.Length = 3 Then
                mstrOrigin = txtOrigin.Text.Trim
            End If
            CheckOptions()
        End If
    End Sub

    Private Sub txtDestination_TextChanged(sender As Object, e As EventArgs) Handles txtDestination.TextChanged
        If Not mflgLoading Then
            If txtDestination.Text.Trim.Length = 3 Then
                mstrDestination = txtDestination.Text.Trim
            End If
            CheckOptions()
        End If
    End Sub
    Private Sub chkFromAirportOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkFromAirportOnly.CheckedChanged
        If Not mflgLoading Then
            mflgFromAirportOnly = chkFromAirportOnly.Checked
            CheckOptions()
        End If
    End Sub

    Private Sub chkToAirportOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkToAirportOnly.CheckedChanged
        If Not mflgLoading Then
            mflgToAirportOnly = chkToAirportOnly.Checked
            CheckOptions()
        End If
    End Sub

    Private Sub txtStopover_TextChanged(sender As Object, e As EventArgs) Handles txtStopover.TextChanged
        If Not mflgLoading Then
            If txtStopover.Text.Trim.Length = 0 Or txtStopover.Text.Trim.Length = 3 Then
                mstrStopover = txtStopover.Text.Trim
            End If
            CheckOptions()
        End If
    End Sub

    Private Sub chkStopoverAirportOnly_CheckedChanged(sender As Object, e As EventArgs) Handles chkStopoverAirportOnly.CheckedChanged
        If Not mflgLoading Then
            mflgStopoverAirportOnly = chkStopoverAirportOnly.Checked
            CheckOptions()
        End If
    End Sub
End Class
