﻿Option Strict On
Option Explicit On
Imports System.Runtime.InteropServices
Public Class frmPriceOptimiser

    Private WithEvents mobjSession1A As k1aHostToolKit.HostSession
    Private mstrPCC As String
    Private mstrUserID As String
    Private mobjDownsell As DownsellCollection
    'Private mflgExpanded As Boolean = True
    Private mintDisplayedContracted As Integer = 0
    Private mstrPrevPNRs As String
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(
       ByVal lpClassName As String,
       ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Long
    End Function
    ' Here we are looking for Amadeus Selling Platform by class name and caption
    Dim lpszParentClass As String = "Showcase"
    Dim lpszParentWindow As String = "SELLING PLATFORM"

    Dim ParenthWnd As New IntPtr(0)
    Private Sub SwitchWindows1A()
        ' Find the window and get a pointer to it (IntPtr in VB.NET)
        lpszParentClass = "ATL:2227C358"
        lpszParentWindow = "SELLING PLATFORM"
        ParenthWnd = FindWindow(lpszParentClass, lpszParentWindow)
        If Not ParenthWnd.Equals(IntPtr.Zero) Then
            SetForegroundWindow(ParenthWnd)
        End If
    End Sub
    Private Sub SwitchWindows1G()
        ' Find the window and get a pointer to it (IntPtr in VB.NET)
        lpszParentClass = "HwndWrapper[Travelport.Smartpoint.App.exe;;e155e932-bf20-4153-9147-31503041a0cf]"
        lpszParentWindow = "Window 1"
        ParenthWnd = FindWindow(lpszParentClass, lpszParentWindow)
        If Not ParenthWnd.Equals(IntPtr.Zero) Then
            SetForegroundWindow(ParenthWnd)
        End If
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        PrepareDataGrid()
    End Sub
    Private Sub PrepareDataGrid()
        With dgvPNRs
            .Columns.Clear()
            Dim pId As New DataGridViewTextBoxColumn With {
                .Name = "Id",
                .HeaderText = "Id",
                .Visible = False
            }
            .Columns.Add(pId)
            Dim pDateLogged As New DataGridViewTextBoxColumn With {
                .Name = "DateFound",
                .HeaderText = "DateFound"
            }
            .Columns.Add(pDateLogged)
            Dim pPCC As New DataGridViewTextBoxColumn With {
                .Name = "PCC",
                .HeaderText = "PCC"
            }
            .Columns.Add(pPCC)
            Dim pUser As New DataGridViewTextBoxColumn With {
                .Name = "User",
                .HeaderText = "User"
            }
            .Columns.Add(pUser)
            Dim pPNR As New DataGridViewTextBoxColumn With {
                .Name = "PNR",
                .HeaderText = "PNR"
            }
            .Columns.Add(pPNR)
            Dim pPax As New DataGridViewTextBoxColumn With {
                .Name = "Pax",
                .HeaderText = "Pax"
            }
            .Columns.Add(pPax)
            Dim pItinerary As New DataGridViewTextBoxColumn With {
                .Name = "Itinerary",
                .HeaderText = "Itinerary"
            }
            .Columns.Add(pItinerary)
            Dim pTotal As New DataGridViewTextBoxColumn With {
                .Name = "Total",
                .HeaderText = "Total"
            }
            .Columns.Add(pTotal)
            Dim pFareBasis As New DataGridViewTextBoxColumn With {
                .Name = "FareBasis",
                .HeaderText = "FareBasis"
            }
            .Columns.Add(pFareBasis)
            Dim pNewTotal As New DataGridViewTextBoxColumn With {
                .Name = "NewTotal",
                .HeaderText = "NewTotal"
            }
            .Columns.Add(pNewTotal)
            Dim pNewFareBasis As New DataGridViewTextBoxColumn With {
                .Name = "NewFareBasis",
                .HeaderText = "NewFareBasis"
            }
            .Columns.Add(pNewFareBasis)
            Dim pGDSCommand As New DataGridViewTextBoxColumn With {
                .Name = "GDSCommand",
                .HeaderText = "GDSCommand"
            }
            .Columns.Add(pGDSCommand)
            Dim pClient As New DataGridViewTextBoxColumn With {
                .Name = "Client",
                .HeaderText = "Client"
            }
            .Columns.Add(pClient)
            Dim pOpsGroup As New DataGridViewTextBoxColumn With {
                .Name = "OpsGroup",
                .HeaderText = "Ops Group"
            }
            .Columns.Add(pOpsGroup)
            Dim pAlert As New DataGridViewTextBoxColumn With {
                .Name = "Alert",
                .HeaderText = "Alert"
            }
            .Columns.Add(pAlert)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    'Public ReadOnly Property FormIsExpanded As Boolean
    '    Get
    '        Return mflgExpanded
    '    End Get
    'End Property
    Public Function DisplayItems(ByVal pPCC As String, ByVal pUserId As String) As Boolean ', ByVal pParentHeight As Integer, ByVal pParentWidth As Integer)
        Try
            Dim pobjDownSell As DownsellCollection
            Dim pAreEqual As Boolean = False
            mstrPCC = pPCC
            mstrUserID = pUserId
            If mobjDownsell Is Nothing Then
                pobjDownSell = New DownsellCollection
            Else
                pobjDownSell = mobjDownsell
            End If
            mobjDownsell = New DownsellCollection
            mobjDownsell.Load(mstrPCC, mstrUserID)
            pAreEqual = (pobjDownSell.Count = mobjDownsell.Count)
            If pAreEqual Then
                For i As Integer = 1 To mobjDownsell.Count + 1
                    If mobjDownsell.ContainsKey(i) AndAlso pobjDownSell.ContainsKey(i) AndAlso mobjDownsell.Item(i).Equals(pobjDownSell.Item(i)) Then
                        pAreEqual = False
                        Exit For
                    End If
                Next
            End If
            mintDisplayedContracted += 1
            If Not pAreEqual Or mintDisplayedContracted > 10 Or txtAmadeusLastChecked.BackColor = Color.Orange Or txtGalileoLastChecked.BackColor = Color.Orange Then
                lblPCCUser.Text = mstrPCC & "-" & mstrUserID
                LoadDGV()
                ExpandContractWindows()
                mintDisplayedContracted = 0
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception("frmPriceOptimiser.DisplayItems()" & vbCrLf & ex.Message)
        End Try

    End Function

    'Private Sub DisplayItems(ByVal pPCC As String, ByVal pUserId As String)
    '    mstrPCC = pPCC
    '    mstrUserID = pUserId
    '    mobjDownsell = New DownsellCollection
    '    mobjDownsell.Load(mstrPCC, mstrUserID)
    '    lblPCCUser.Text = mstrPCC & "-" & mstrUserID
    '    LoadDGV()
    'End Sub
    Private Sub RefreshDisplay(ByVal pPCC As String, ByVal pUserId As String)
        mstrPCC = pPCC
        mstrUserID = pUserId
        mobjDownsell = New DownsellCollection
        mobjDownsell.Load(mstrPCC, mstrUserID)
        lblPCCUser.Text = mstrPCC & "-" & mstrUserID
        LoadDGV()
    End Sub
    Private Sub CheckGDSFilesDownloadTime()
        Dim pDirectory = "\\eudc-panasoft\Griffin\AIR\Successful\" & Format(Now, "yyyy.MM")
        Dim pDate As Date = System.IO.Directory.GetLastWriteTime(pDirectory)
        txtAmadeusAIRfile.Text = Format(pDate, "dd/MM/yyyy HH:mm") & " (" & DateDiff(DateInterval.Minute, pDate, Now).ToString & " minutes ago)"
        If DateDiff(DateInterval.Minute, pDate, Now) > 60 Then
            txtAmadeusAIRfile.BackColor = Color.Orange
        Else
            txtAmadeusAIRfile.BackColor = Color.White
        End If

        pDirectory = "\\eudc-panasoft\Griffin\MIR\Successful\" & Format(Now, "yyyy.MM")
        pDate = System.IO.Directory.GetLastWriteTime(pDirectory)
        txtGalileoMIRfile.Text = Format(pDate, "dd/MM/yyyy HH:mm") & " (" & DateDiff(DateInterval.Minute, pDate, Now).ToString & " minutes ago)"
        If DateDiff(DateInterval.Minute, pDate, Now) > 60 Then
            txtGalileoMIRfile.BackColor = Color.Orange
        Else
            txtGalileoMIRfile.BackColor = Color.White
        End If

    End Sub
    Private Sub CheckGDSDownsellCheckTime()
        txtAmadeusLastChecked.Text = Format(mobjDownsell.AmadeusLastCheck, "dd/MM/yyyy HH:mm") & " (" & DateDiff(DateInterval.Minute, mobjDownsell.AmadeusLastCheck, Now).ToString & " minutes ago)"
        If DateDiff(DateInterval.Minute, mobjDownsell.AmadeusLastCheck, Now) > 60 Then
            txtAmadeusLastChecked.BackColor = Color.Orange
        Else
            txtAmadeusLastChecked.BackColor = Color.White
        End If
        txtGalileoLastChecked.Text = Format(mobjDownsell.GalileoLastCheck, "dd/MM/yyyy HH:mm") & " (" & DateDiff(DateInterval.Minute, mobjDownsell.GalileoLastCheck, Now).ToString & " minutes ago)"
        If DateDiff(DateInterval.Minute, mobjDownsell.GalileoLastCheck, Now) > 60 Then
            txtGalileoLastChecked.BackColor = Color.Orange
        Else
            txtGalileoLastChecked.BackColor = Color.White
        End If

    End Sub
    Private Sub LoadDGV()

        lblTimeNow.Text = "Time now is : " & Format(Now, "dd/MM/yyyy HH:mm")
        CheckGDSFilesDownloadTime()
        CheckGDSDownsellCheckTime()
        Dim pCurrPNR As String = ""
        If dgvPNRs.ColumnCount = 0 Then
            PrepareDataGrid()
        End If
        dgvPNRs.Rows.Clear()
        For Each pItem As DownsellItem In mobjDownsell.Values
            Dim pId As New DataGridViewTextBoxCell With {
                .Value = 0
            }
            Dim pDateLogged As New DataGridViewTextBoxCell With {
                .Value = Format(pItem.DateLogged, "dd/MM HH:mm")
            }
            Dim pPCC As New DataGridViewTextBoxCell With {
                .Value = pItem.GDS & "-" & pItem.PCC
            }
            Dim pUser As New DataGridViewTextBoxCell With {
                .Value = pItem.UserGdsId
            }
            Dim pPNR As New DataGridViewTextBoxCell With {
                .Value = pItem.PNR
            }
            Dim pPax As New DataGridViewTextBoxCell With {
                .Value = pItem.PaxName
            }
            Dim pItinerary As New DataGridViewTextBoxCell With {
                .Value = pItem.Itinerary
            }
            Dim pTotal As New DataGridViewTextBoxCell With {
                .Value = pItem.Total
            }
            Dim pFareBasis As New DataGridViewTextBoxCell With {
                .Value = pItem.FareBasis
            }
            Dim pNewTotal As New DataGridViewTextBoxCell With {
                .Value = pItem.DownsellTotal
            }
            Dim pNewFareBasis As New DataGridViewTextBoxCell With {
                .Value = pItem.DownsellFareBasis
            }
            Dim pGDSCommand As New DataGridViewTextBoxCell With {
                .Value = pItem.GDSCommand
            }
            Dim pClient As New DataGridViewTextBoxCell With {
                .Value = pItem.ClientCode & " " & pItem.ClientName
            }
            Dim pOpsGroup As New DataGridViewTextBoxCell With {
                .Value = pItem.OpsGroup
            }
            Dim pAlert As New DataGridViewTextBoxCell With {
                .Value = pItem.AlertForDownsell
            }
            Dim pRow As New DataGridViewRow
            pRow.Cells.Add(pId)
            pRow.Cells.Add(pDateLogged)
            pRow.Cells.Add(pPCC)
            pRow.Cells.Add(pUser)
            pRow.Cells.Add(pPNR)
            pRow.Cells.Add(pPax)
            pRow.Cells.Add(pItinerary)
            pRow.Cells.Add(pTotal)
            pRow.Cells.Add(pFareBasis)
            pRow.Cells.Add(pNewTotal)
            pRow.Cells.Add(pNewFareBasis)
            pRow.Cells.Add(pGDSCommand)
            pRow.Cells.Add(pClient)
            pRow.Cells.Add(pOpsGroup)
            pRow.Cells.Add(pAlert)
            If pItem.AlertForDownsell <> "" Then
                pRow.DefaultCellStyle.BackColor = Color.OrangeRed
            ElseIf pItem.OwnPNR = 2 Then
                pRow.DefaultCellStyle.BackColor = Color.Yellow
            End If

            dgvPNRs.Rows.Add(pRow)
            pCurrPNR &= pItem.PNR
        Next
        If pCurrPNR <> mstrPrevPNRs Then
            'mflgExpanded = True
            mstrPrevPNRs = pCurrPNR
        End If
        lblPCCUser.Text = mstrPCC & "-" & mstrUserID & " : " & dgvPNRs.RowCount.ToString & " entries"
        ExpandContractWindows()

    End Sub
    Private Sub mnuOptimiserIgnore_Click(sender As Object, e As EventArgs) Handles mnuOptimiserIgnore.Click
        Dim pText() As String = mnuOptimiserPNR.Text.Split("-".ToCharArray)
        If pText.GetUpperBound(0) = 2 AndAlso pText(2) <> "" Then
            mobjDownsell.IgnorePNR(pText(1), pText(2), "IGNORE")
        End If
        LoadDGV()
    End Sub
    Private Sub mnuOptimiserActioned_Click(sender As Object, e As EventArgs) Handles mnuOptimiserActioned.Click
        Dim pText() As String = mnuOptimiserPNR.Text.Split("-".ToCharArray)
        If pText.GetUpperBound(0) = 2 AndAlso pText(2) <> "" Then
            mobjDownsell.IgnorePNR(pText(1), pText(2), "ACTIONED")
        End If
        LoadDGV()
    End Sub
    Private Sub mnuOptimiserOpenInGDS_Click(sender As Object, e As EventArgs) Handles mnuOptimiserOpenInGDS.Click
        Dim pText() As String = mnuOptimiserPNR.Text.Split("-".ToCharArray)
        If pText.GetUpperBound(0) = 2 AndAlso pText(2) <> "" Then
            If pText(0) = "1A" Then
                Dim pResponse As String = OpenPNR1A(pText(2))
                If pResponse.Length > 0 Then
                    MessageBox.Show(pResponse)
                Else
                    'mobjDownsell.IgnorePNR(pText(0), pText(1), "OPENED")
                    'LoadDGV()
                    SwitchWindows1A()
                End If
            ElseIf pText(0) = "1G" Then
                Dim pResponse As String = OpenPNR1G(pText(2))
                If pResponse.Length > 0 Then
                    MessageBox.Show(pResponse)
                Else
                    SwitchWindows1G()
                End If
            End If
        End If
    End Sub
    Private Sub dgvPNRs_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvPNRs.MouseClick
        SetSelectedPNR()
    End Sub
    Private Sub dgvPNRs_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPNRs.CellMouseEnter
        If e.RowIndex > -1 Then
            dgvPNRs.Rows(e.RowIndex).Selected = True
        End If
        SetSelectedPNR()
    End Sub
    Private Sub SetSelectedPNR()
        Dim pText As String = ""
        If Not dgvPNRs.SelectedRows Is Nothing AndAlso dgvPNRs.SelectedRows.Count > 0 Then
            pText = dgvPNRs.SelectedRows(0).Cells("PCC").Value.ToString & "-" & dgvPNRs.SelectedRows(0).Cells("PNR").Value.ToString
        ElseIf Not dgvPNRs.SelectedCells Is Nothing AndAlso dgvPNRs.SelectedCells.Count > 0 Then
            '            pText = dgvPNRs.Rows(dgvPNRs.SelectedCells("Id").RowIndex).Cells("PNR").Value
            pText = dgvPNRs.Rows(dgvPNRs.SelectedCells(0).RowIndex).Cells("PNR").Value.ToString
        Else
            pText = ""
        End If
        mnuOptimiserPNR.Text = pText
        If pText = "" Then
            mnuOptimiserActioned.Enabled = False
            mnuOptimiserIgnore.Enabled = False
            mnuOptimiserOpenInGDS.Enabled = False
        Else
            mnuOptimiserActioned.Enabled = True
            mnuOptimiserIgnore.Enabled = True
            mnuOptimiserOpenInGDS.Enabled = True
            If pText.StartsWith("1A") Then
                mnuOptimiserOpenInGDS.Text = "Open in Amadeus"
            ElseIf pText.StartsWith("1G") Then
                mnuOptimiserOpenInGDS.Text = "Open in Galileo - (Enter *R or *ALL to see the PNR)"
            Else
                mnuOptimiserOpenInGDS.Text = ""
                mnuOptimiserOpenInGDS.Enabled = False
            End If
        End If
    End Sub
    Private Function OpenPNR1A(ByVal pPNR As String) As String
        Dim pobjHostSessions As k1aHostToolKit.HostSessions
        Dim pResponse As String = ""
        OpenPNR1A = ""
        Try
            pobjHostSessions = New k1aHostToolKit.HostSessions

            If pobjHostSessions.Count > 0 Then
                mobjSession1A = pobjHostSessions.UIActiveSession
                pResponse = mobjSession1A.Send("RT" & pPNR).Text
                If pResponse.IndexOf("FINISH OR IGNORE") > -1 Then
                    OpenPNR1A = pResponse
                End If
            Else
                OpenPNR1A = "Amadeus not signed in"
            End If
        Catch ex As Exception
            OpenPNR1A = ex.Message
        End Try
    End Function
    Private Shared Function OpenPNR1G(ByVal pPNR As String) As String

        OpenPNR1G = ""
        Dim pSession1G As New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")
        Dim pobjPNR As ObjectModel.ReadOnlyCollection(Of String)
        Try
            pobjPNR = pSession1G.SendTerminalCommand("*" & pPNR)
            If pobjPNR.Count <= 3 Or pobjPNR(0) = "FINISH OR IGNORE" Or pobjPNR(0).StartsWith("AG - DUTY CODE") Then
                OpenPNR1G = pobjPNR(0)
            End If
        Catch ex As Travelport.TravelData.DesktopUserNotSignedOnException
            OpenPNR1G = "Please sign in to Galileo/Smartpoint"
        Catch ex As Exception
            OpenPNR1G = "Cannot open Galileo/Smartpoint" & vbCrLf & ex.Message
        End Try

    End Function

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Try
            RefreshDisplay(mstrPCC, mstrUserID)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub mnuOptimiserCopyData_Click(sender As Object, e As EventArgs) Handles mnuOptimiserCopyData.Click
        Try

            dgvPNRs.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dgvPNRs.MultiSelect = True
            dgvPNRs.SelectAll()
            Dim dgvDataObj As DataObject = dgvPNRs.GetClipboardContent
            Clipboard.SetDataObject(dgvDataObj)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            dgvPNRs.MultiSelect = False
        End Try

    End Sub

    'Private Sub cmdMinMax_Click(sender As Object, e As EventArgs) Handles cmdMinMax.Click

    '    mflgExpanded = Not mflgExpanded
    '    ExpandContractWindows()

    'End Sub
    Private Sub ExpandContractWindows()
        Dim pfrmMain As frm01Main
        pfrmMain = DirectCast(Me.MdiParent, frm01Main)

        If dgvPNRs.RowCount = 0 Then
            pfrmMain.PriceOptimizerToolStripMenuItem.Text = "Price Optimizer"
            pfrmMain.PriceOptimizerToolStripMenuItem.BackColor = Color.FromKnownColor(KnownColor.Control)
        Else
            pfrmMain.PriceOptimizerToolStripMenuItem.Text = "Price Optimizer " & dgvPNRs.Rows.Count & " entries"
            pfrmMain.PriceOptimizerToolStripMenuItem.BackColor = Color.Red
        End If
    End Sub

End Class