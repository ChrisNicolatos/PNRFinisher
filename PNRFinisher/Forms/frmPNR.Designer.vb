﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPNR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPNR))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabOSM = New System.Windows.Forms.TabPage()
        Me.chkOSMFullPaxSDetails = New System.Windows.Forms.CheckBox()
        Me.cmbOSMVesselGroup = New System.Windows.Forms.ComboBox()
        Me.chkOSMVesselInUse = New System.Windows.Forms.CheckBox()
        Me.lblOSMMultipleSearchSeparator = New System.Windows.Forms.Label()
        Me.txtOSMAgentsFilter = New System.Windows.Forms.TextBox()
        Me.cmdOSMClearSelected = New System.Windows.Forms.Button()
        Me.cmdOSMEmailClear = New System.Windows.Forms.Button()
        Me.webOSMDoc = New System.Windows.Forms.WebBrowser()
        Me.lstOSMVessels = New System.Windows.Forms.ListBox()
        Me.cmdOSMCopyDocument = New System.Windows.Forms.Button()
        Me.cmdOSMPrepareDoc = New System.Windows.Forms.Button()
        Me.dgvOSMPax = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nationality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JoinerLeaver = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VisaType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblOSMPasteEmailsHere = New System.Windows.Forms.Label()
        Me.txtOSMPax = New System.Windows.Forms.TextBox()
        Me.lblOSMVessel = New System.Windows.Forms.Label()
        Me.cmdOSMVesselsEdit = New System.Windows.Forms.Button()
        Me.lblOSMVessels = New System.Windows.Forms.Label()
        Me.cmdOSMAgentEdit = New System.Windows.Forms.Button()
        Me.lblOSMAgents = New System.Windows.Forms.Label()
        Me.lstOSMAgents = New System.Windows.Forms.ListBox()
        Me.cmdOSMCopyCC = New System.Windows.Forms.Button()
        Me.cmdOSMCopyTo = New System.Windows.Forms.Button()
        Me.lblOSMEmailsCC = New System.Windows.Forms.Label()
        Me.lblOSMEmailsTo = New System.Windows.Forms.Label()
        Me.lstOSMCCEmail = New System.Windows.Forms.ListBox()
        Me.lstOSMToEmail = New System.Windows.Forms.ListBox()
        Me.cmdOSMRefresh = New System.Windows.Forms.Button()
        Me.txtItnPNR = New System.Windows.Forms.TextBox()
        Me.lblItnPNR = New System.Windows.Forms.Label()
        Me.MenuCopyItn = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuITNSelectCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.rtbItnDoc = New System.Windows.Forms.RichTextBox()
        Me.chkItnEMD = New System.Windows.Forms.CheckBox()
        Me.chkItnItinRemarks = New System.Windows.Forms.CheckBox()
        Me.chkItnCabinDescription = New System.Windows.Forms.CheckBox()
        Me.chkItnCostCentre = New System.Windows.Forms.CheckBox()
        Me.chkItnFlyingTime = New System.Windows.Forms.CheckBox()
        Me.chkItnSeating = New System.Windows.Forms.CheckBox()
        Me.optItnFormatFleet = New System.Windows.Forms.RadioButton()
        Me.cmdItnExit = New System.Windows.Forms.Button()
        Me.chkItnStopovers = New System.Windows.Forms.CheckBox()
        Me.chkItnTerminal = New System.Windows.Forms.CheckBox()
        Me.chkItnPaxSegPerTicket = New System.Windows.Forms.CheckBox()
        Me.chkItnTickets = New System.Windows.Forms.CheckBox()
        Me.chkItnClass = New System.Windows.Forms.CheckBox()
        Me.chkItnVessel = New System.Windows.Forms.CheckBox()
        Me.lstItnRemarks = New System.Windows.Forms.CheckedListBox()
        Me.fraItnAirportName = New System.Windows.Forms.GroupBox()
        Me.optItnAirportCityBoth = New System.Windows.Forms.RadioButton()
        Me.optItnAirportCityName = New System.Windows.Forms.RadioButton()
        Me.optItnAirportBoth = New System.Windows.Forms.RadioButton()
        Me.optItnAirportname = New System.Windows.Forms.RadioButton()
        Me.optItnAirportCode = New System.Windows.Forms.RadioButton()
        Me.chkItnAirlineLocator = New System.Windows.Forms.CheckBox()
        Me.fraItnOptions = New System.Windows.Forms.GroupBox()
        Me.ttpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.optItnFormatSeaChefsWith3LetterCode = New System.Windows.Forms.RadioButton()
        Me.tabPNR = New System.Windows.Forms.TabControl()
        Me.tabPageFinisher = New System.Windows.Forms.TabPage()
        Me.cmdPriceOptimiser = New System.Windows.Forms.Button()
        Me.lstAirlineEntries = New System.Windows.Forms.CheckedListBox()
        Me.txtTrId = New System.Windows.Forms.TextBox()
        Me.lblTRIDHighLight = New System.Windows.Forms.Label()
        Me.lblPNRGalileo = New System.Windows.Forms.Label()
        Me.lblPNRAmadeus = New System.Windows.Forms.Label()
        Me.txtPNRApis = New System.Windows.Forms.TextBox()
        Me.cmdAPISEditPax = New System.Windows.Forms.Button()
        Me.cmdPNRRead1GPNR = New System.Windows.Forms.Button()
        Me.cmdAdmin = New System.Windows.Forms.Button()
        Me.cmdPNROnlyDocs = New System.Windows.Forms.Button()
        Me.cmdPNRWriteWithDocs = New System.Windows.Forms.Button()
        Me.lblSSRDocs = New System.Windows.Forms.Label()
        Me.dgvApis = New System.Windows.Forms.DataGridView()
        Me.cmdAveragePrice = New System.Windows.Forms.Button()
        Me.lblAveragePrice = New System.Windows.Forms.Label()
        Me.lblAvPriceDetails = New System.Windows.Forms.Label()
        Me.cmdCostCentre = New System.Windows.Forms.Button()
        Me.cmdPNRRead1APNR = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdOneTimeVessel = New System.Windows.Forms.Button()
        Me.txtSubdepartment = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lblCostCentreHighlight = New System.Windows.Forms.Label()
        Me.llbOptions = New System.Windows.Forms.LinkLabel()
        Me.cmbCostCentre = New System.Windows.Forms.ComboBox()
        Me.cmdPNRWrite = New System.Windows.Forms.Button()
        Me.lstCRM = New System.Windows.Forms.ListBox()
        Me.lblSegs = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.lblReasonForTravelHighLight = New System.Windows.Forms.Label()
        Me.txtCRM = New System.Windows.Forms.TextBox()
        Me.lblPax = New System.Windows.Forms.Label()
        Me.lstSubDepartments = New System.Windows.Forms.ListBox()
        Me.cmbReasonForTravel = New System.Windows.Forms.ComboBox()
        Me.lblSubDepartment = New System.Windows.Forms.Label()
        Me.lblPNR = New System.Windows.Forms.Label()
        Me.lblCRM = New System.Windows.Forms.Label()
        Me.lblDepartmentHighlight = New System.Windows.Forms.Label()
        Me.lstVessels = New System.Windows.Forms.ListBox()
        Me.lblVessel = New System.Windows.Forms.Label()
        Me.lblBookedByHighlight = New System.Windows.Forms.Label()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblReference = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.lblAirlinePoints = New System.Windows.Forms.Label()
        Me.cmbBookedby = New System.Windows.Forms.ComboBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.tabPageItinerary = New System.Windows.Forms.TabPage()
        Me.fraGalileo = New System.Windows.Forms.GroupBox()
        Me.cmdItn1GReadPNR = New System.Windows.Forms.Button()
        Me.cmdItn1GReadCurrent = New System.Windows.Forms.Button()
        Me.cmdItn1GReadQueue = New System.Windows.Forms.Button()
        Me.fraAmadeus = New System.Windows.Forms.GroupBox()
        Me.cmdItn1AReadPNR = New System.Windows.Forms.Button()
        Me.cmdItn1AReadCurrent = New System.Windows.Forms.Button()
        Me.cmdItn1AReadQueue = New System.Windows.Forms.Button()
        Me.cmdItnFormatOSMLoG = New System.Windows.Forms.Button()
        Me.webItnDoc = New System.Windows.Forms.WebBrowser()
        Me.lblItnPNRCounter = New System.Windows.Forms.Label()
        Me.cmdItnRefresh = New System.Windows.Forms.Button()
        Me.fraItnFormat = New System.Windows.Forms.GroupBox()
        Me.optItnFormatEuronav = New System.Windows.Forms.RadioButton()
        Me.optItnFormatSeaChefs = New System.Windows.Forms.RadioButton()
        Me.optItnFormatPlain = New System.Windows.Forms.RadioButton()
        Me.optItnFormatDefault = New System.Windows.Forms.RadioButton()
        Me.cmbPNRScenario = New System.Windows.Forms.ComboBox()
        Me.tabOSM.SuspendLayout()
        CType(Me.dgvOSMPax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuITNSelectCopy.SuspendLayout()
        Me.fraItnAirportName.SuspendLayout()
        Me.fraItnOptions.SuspendLayout()
        Me.tabPNR.SuspendLayout()
        Me.tabPageFinisher.SuspendLayout()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageItinerary.SuspendLayout()
        Me.fraGalileo.SuspendLayout()
        Me.fraAmadeus.SuspendLayout()
        Me.fraItnFormat.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Vessel Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabOSM
        '
        Me.tabOSM.Controls.Add(Me.chkOSMFullPaxSDetails)
        Me.tabOSM.Controls.Add(Me.Label2)
        Me.tabOSM.Controls.Add(Me.cmbOSMVesselGroup)
        Me.tabOSM.Controls.Add(Me.chkOSMVesselInUse)
        Me.tabOSM.Controls.Add(Me.lblOSMMultipleSearchSeparator)
        Me.tabOSM.Controls.Add(Me.txtOSMAgentsFilter)
        Me.tabOSM.Controls.Add(Me.cmdOSMClearSelected)
        Me.tabOSM.Controls.Add(Me.cmdOSMEmailClear)
        Me.tabOSM.Controls.Add(Me.webOSMDoc)
        Me.tabOSM.Controls.Add(Me.lstOSMVessels)
        Me.tabOSM.Controls.Add(Me.cmdOSMCopyDocument)
        Me.tabOSM.Controls.Add(Me.cmdOSMPrepareDoc)
        Me.tabOSM.Controls.Add(Me.dgvOSMPax)
        Me.tabOSM.Controls.Add(Me.lblOSMPasteEmailsHere)
        Me.tabOSM.Controls.Add(Me.txtOSMPax)
        Me.tabOSM.Controls.Add(Me.lblOSMVessel)
        Me.tabOSM.Controls.Add(Me.cmdOSMVesselsEdit)
        Me.tabOSM.Controls.Add(Me.lblOSMVessels)
        Me.tabOSM.Controls.Add(Me.cmdOSMAgentEdit)
        Me.tabOSM.Controls.Add(Me.lblOSMAgents)
        Me.tabOSM.Controls.Add(Me.lstOSMAgents)
        Me.tabOSM.Controls.Add(Me.cmdOSMCopyCC)
        Me.tabOSM.Controls.Add(Me.cmdOSMCopyTo)
        Me.tabOSM.Controls.Add(Me.lblOSMEmailsCC)
        Me.tabOSM.Controls.Add(Me.lblOSMEmailsTo)
        Me.tabOSM.Controls.Add(Me.lstOSMCCEmail)
        Me.tabOSM.Controls.Add(Me.lstOSMToEmail)
        Me.tabOSM.Controls.Add(Me.cmdOSMRefresh)
        Me.tabOSM.Location = New System.Drawing.Point(4, 22)
        Me.tabOSM.Name = "tabOSM"
        Me.tabOSM.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOSM.Size = New System.Drawing.Size(1464, 559)
        Me.tabOSM.TabIndex = 2
        Me.tabOSM.Text = "OSM"
        Me.tabOSM.UseVisualStyleBackColor = True
        '
        'chkOSMFullPaxSDetails
        '
        Me.chkOSMFullPaxSDetails.AutoSize = True
        Me.chkOSMFullPaxSDetails.Location = New System.Drawing.Point(755, 413)
        Me.chkOSMFullPaxSDetails.Name = "chkOSMFullPaxSDetails"
        Me.chkOSMFullPaxSDetails.Size = New System.Drawing.Size(126, 17)
        Me.chkOSMFullPaxSDetails.TabIndex = 28
        Me.chkOSMFullPaxSDetails.Text = "Show Full Pax details"
        Me.chkOSMFullPaxSDetails.UseVisualStyleBackColor = True
        '
        'cmbOSMVesselGroup
        '
        Me.cmbOSMVesselGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOSMVesselGroup.FormattingEnabled = True
        Me.cmbOSMVesselGroup.Location = New System.Drawing.Point(18, 67)
        Me.cmbOSMVesselGroup.Name = "cmbOSMVesselGroup"
        Me.cmbOSMVesselGroup.Size = New System.Drawing.Size(193, 21)
        Me.cmbOSMVesselGroup.TabIndex = 26
        '
        'chkOSMVesselInUse
        '
        Me.chkOSMVesselInUse.AutoSize = True
        Me.chkOSMVesselInUse.Checked = True
        Me.chkOSMVesselInUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOSMVesselInUse.Location = New System.Drawing.Point(18, 121)
        Me.chkOSMVesselInUse.Name = "chkOSMVesselInUse"
        Me.chkOSMVesselInUse.Size = New System.Drawing.Size(81, 17)
        Me.chkOSMVesselInUse.TabIndex = 24
        Me.chkOSMVesselInUse.Text = "In Use Only"
        Me.chkOSMVesselInUse.UseVisualStyleBackColor = True
        '
        'lblOSMMultipleSearchSeparator
        '
        Me.lblOSMMultipleSearchSeparator.AutoSize = True
        Me.lblOSMMultipleSearchSeparator.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMMultipleSearchSeparator.Location = New System.Drawing.Point(217, 317)
        Me.lblOSMMultipleSearchSeparator.Name = "lblOSMMultipleSearchSeparator"
        Me.lblOSMMultipleSearchSeparator.Size = New System.Drawing.Size(112, 9)
        Me.lblOSMMultipleSearchSeparator.TabIndex = 23
        Me.lblOSMMultipleSearchSeparator.Text = "Multiple search separated with |"
        '
        'txtOSMAgentsFilter
        '
        Me.txtOSMAgentsFilter.Location = New System.Drawing.Point(217, 294)
        Me.txtOSMAgentsFilter.Name = "txtOSMAgentsFilter"
        Me.txtOSMAgentsFilter.Size = New System.Drawing.Size(166, 20)
        Me.txtOSMAgentsFilter.TabIndex = 22
        '
        'cmdOSMClearSelected
        '
        Me.cmdOSMClearSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOSMClearSelected.Location = New System.Drawing.Point(18, 501)
        Me.cmdOSMClearSelected.Name = "cmdOSMClearSelected"
        Me.cmdOSMClearSelected.Size = New System.Drawing.Size(483, 30)
        Me.cmdOSMClearSelected.TabIndex = 21
        Me.cmdOSMClearSelected.Text = "Clear Selected Vessel(s) and/or Agent(s)"
        Me.cmdOSMClearSelected.UseVisualStyleBackColor = True
        '
        'cmdOSMEmailClear
        '
        Me.cmdOSMEmailClear.BackColor = System.Drawing.Color.Red
        Me.cmdOSMEmailClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOSMEmailClear.Location = New System.Drawing.Point(768, 54)
        Me.cmdOSMEmailClear.Name = "cmdOSMEmailClear"
        Me.cmdOSMEmailClear.Size = New System.Drawing.Size(21, 13)
        Me.cmdOSMEmailClear.TabIndex = 15
        Me.cmdOSMEmailClear.Text = "X"
        Me.cmdOSMEmailClear.UseVisualStyleBackColor = False
        '
        'webOSMDoc
        '
        Me.webOSMDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webOSMDoc.Location = New System.Drawing.Point(508, 437)
        Me.webOSMDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webOSMDoc.Name = "webOSMDoc"
        Me.webOSMDoc.Size = New System.Drawing.Size(909, 94)
        Me.webOSMDoc.TabIndex = 20
        '
        'lstOSMVessels
        '
        Me.lstOSMVessels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMVessels.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstOSMVessels.FormattingEnabled = True
        Me.lstOSMVessels.Location = New System.Drawing.Point(18, 146)
        Me.lstOSMVessels.Name = "lstOSMVessels"
        Me.lstOSMVessels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstOSMVessels.Size = New System.Drawing.Size(193, 329)
        Me.lstOSMVessels.TabIndex = 3
        '
        'cmdOSMCopyDocument
        '
        Me.cmdOSMCopyDocument.Enabled = False
        Me.cmdOSMCopyDocument.Location = New System.Drawing.Point(627, 405)
        Me.cmdOSMCopyDocument.Name = "cmdOSMCopyDocument"
        Me.cmdOSMCopyDocument.Size = New System.Drawing.Size(113, 30)
        Me.cmdOSMCopyDocument.TabIndex = 19
        Me.cmdOSMCopyDocument.Text = "Copy Document"
        Me.cmdOSMCopyDocument.UseVisualStyleBackColor = True
        '
        'cmdOSMPrepareDoc
        '
        Me.cmdOSMPrepareDoc.Location = New System.Drawing.Point(508, 405)
        Me.cmdOSMPrepareDoc.Name = "cmdOSMPrepareDoc"
        Me.cmdOSMPrepareDoc.Size = New System.Drawing.Size(113, 30)
        Me.cmdOSMPrepareDoc.TabIndex = 18
        Me.cmdOSMPrepareDoc.Text = "Prepare Document"
        Me.cmdOSMPrepareDoc.UseVisualStyleBackColor = True
        '
        'dgvOSMPax
        '
        Me.dgvOSMPax.AllowUserToAddRows = False
        Me.dgvOSMPax.AllowUserToDeleteRows = False
        Me.dgvOSMPax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOSMPax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOSMPax.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LastName, Me.FirstName, Me.Nationality, Me.JoinerLeaver, Me.VisaType})
        Me.dgvOSMPax.Location = New System.Drawing.Point(811, 67)
        Me.dgvOSMPax.Name = "dgvOSMPax"
        Me.dgvOSMPax.Size = New System.Drawing.Size(645, 332)
        Me.dgvOSMPax.TabIndex = 17
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        '
        'LastName
        '
        Me.LastName.HeaderText = "LastName"
        Me.LastName.Name = "LastName"
        '
        'FirstName
        '
        Me.FirstName.HeaderText = "FirstName"
        Me.FirstName.Name = "FirstName"
        '
        'Nationality
        '
        Me.Nationality.HeaderText = "Nationality"
        Me.Nationality.Name = "Nationality"
        '
        'JoinerLeaver
        '
        Me.JoinerLeaver.HeaderText = "JoinerLeaver"
        Me.JoinerLeaver.Items.AddRange(New Object() {"Joiner", "Homegoing"})
        Me.JoinerLeaver.Name = "JoinerLeaver"
        '
        'VisaType
        '
        Me.VisaType.HeaderText = "VisaType"
        Me.VisaType.Items.AddRange(New Object() {"Visa required", "OKTB", "No Visa required"})
        Me.VisaType.Name = "VisaType"
        '
        'lblOSMPasteEmailsHere
        '
        Me.lblOSMPasteEmailsHere.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblOSMPasteEmailsHere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMPasteEmailsHere.Location = New System.Drawing.Point(509, 54)
        Me.lblOSMPasteEmailsHere.Name = "lblOSMPasteEmailsHere"
        Me.lblOSMPasteEmailsHere.Size = New System.Drawing.Size(262, 13)
        Me.lblOSMPasteEmailsHere.TabIndex = 14
        Me.lblOSMPasteEmailsHere.Text = "PASTE OSM EMAIL HERE"
        Me.lblOSMPasteEmailsHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOSMPax
        '
        Me.txtOSMPax.AllowDrop = True
        Me.txtOSMPax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtOSMPax.Font = New System.Drawing.Font("Courier New", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtOSMPax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOSMPax.Location = New System.Drawing.Point(507, 67)
        Me.txtOSMPax.Multiline = True
        Me.txtOSMPax.Name = "txtOSMPax"
        Me.txtOSMPax.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOSMPax.Size = New System.Drawing.Size(282, 332)
        Me.txtOSMPax.TabIndex = 16
        '
        'lblOSMVessel
        '
        Me.lblOSMVessel.AutoSize = True
        Me.lblOSMVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMVessel.Location = New System.Drawing.Point(217, 18)
        Me.lblOSMVessel.Name = "lblOSMVessel"
        Me.lblOSMVessel.Size = New System.Drawing.Size(0, 13)
        Me.lblOSMVessel.TabIndex = 4
        '
        'cmdOSMVesselsEdit
        '
        Me.cmdOSMVesselsEdit.Location = New System.Drawing.Point(113, 118)
        Me.cmdOSMVesselsEdit.Name = "cmdOSMVesselsEdit"
        Me.cmdOSMVesselsEdit.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMVesselsEdit.TabIndex = 2
        Me.cmdOSMVesselsEdit.Text = "Edit Vessels"
        Me.cmdOSMVesselsEdit.UseVisualStyleBackColor = True
        '
        'lblOSMVessels
        '
        Me.lblOSMVessels.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMVessels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMVessels.Location = New System.Drawing.Point(18, 97)
        Me.lblOSMVessels.Name = "lblOSMVessels"
        Me.lblOSMVessels.Size = New System.Drawing.Size(193, 13)
        Me.lblOSMVessels.TabIndex = 1
        Me.lblOSMVessels.Text = "Vessels"
        Me.lblOSMVessels.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdOSMAgentEdit
        '
        Me.cmdOSMAgentEdit.Location = New System.Drawing.Point(404, 305)
        Me.cmdOSMAgentEdit.Name = "cmdOSMAgentEdit"
        Me.cmdOSMAgentEdit.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMAgentEdit.TabIndex = 12
        Me.cmdOSMAgentEdit.Text = "Edit Agents"
        Me.cmdOSMAgentEdit.UseVisualStyleBackColor = True
        '
        'lblOSMAgents
        '
        Me.lblOSMAgents.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMAgents.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMAgents.Location = New System.Drawing.Point(217, 275)
        Me.lblOSMAgents.Name = "lblOSMAgents"
        Me.lblOSMAgents.Size = New System.Drawing.Size(285, 13)
        Me.lblOSMAgents.TabIndex = 11
        Me.lblOSMAgents.Text = "Agents"
        Me.lblOSMAgents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstOSMAgents
        '
        Me.lstOSMAgents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMAgents.FormattingEnabled = True
        Me.lstOSMAgents.Location = New System.Drawing.Point(217, 328)
        Me.lstOSMAgents.Name = "lstOSMAgents"
        Me.lstOSMAgents.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstOSMAgents.Size = New System.Drawing.Size(285, 147)
        Me.lstOSMAgents.TabIndex = 13
        '
        'cmdOSMCopyCC
        '
        Me.cmdOSMCopyCC.Enabled = False
        Me.cmdOSMCopyCC.Location = New System.Drawing.Point(404, 165)
        Me.cmdOSMCopyCC.Name = "cmdOSMCopyCC"
        Me.cmdOSMCopyCC.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMCopyCC.TabIndex = 9
        Me.cmdOSMCopyCC.Text = "Copy CC"
        Me.cmdOSMCopyCC.UseVisualStyleBackColor = True
        '
        'cmdOSMCopyTo
        '
        Me.cmdOSMCopyTo.Enabled = False
        Me.cmdOSMCopyTo.Location = New System.Drawing.Point(403, 46)
        Me.cmdOSMCopyTo.Name = "cmdOSMCopyTo"
        Me.cmdOSMCopyTo.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMCopyTo.TabIndex = 6
        Me.cmdOSMCopyTo.Text = "Copy TO"
        Me.cmdOSMCopyTo.UseVisualStyleBackColor = True
        '
        'lblOSMEmailsCC
        '
        Me.lblOSMEmailsCC.AutoSize = True
        Me.lblOSMEmailsCC.Location = New System.Drawing.Point(217, 165)
        Me.lblOSMEmailsCC.Name = "lblOSMEmailsCC"
        Me.lblOSMEmailsCC.Size = New System.Drawing.Size(53, 13)
        Me.lblOSMEmailsCC.TabIndex = 8
        Me.lblOSMEmailsCC.Text = "emails CC"
        '
        'lblOSMEmailsTo
        '
        Me.lblOSMEmailsTo.AutoSize = True
        Me.lblOSMEmailsTo.Location = New System.Drawing.Point(217, 46)
        Me.lblOSMEmailsTo.Name = "lblOSMEmailsTo"
        Me.lblOSMEmailsTo.Size = New System.Drawing.Size(54, 13)
        Me.lblOSMEmailsTo.TabIndex = 5
        Me.lblOSMEmailsTo.Text = "emails TO"
        '
        'lstOSMCCEmail
        '
        Me.lstOSMCCEmail.FormattingEnabled = True
        Me.lstOSMCCEmail.Location = New System.Drawing.Point(217, 184)
        Me.lstOSMCCEmail.Name = "lstOSMCCEmail"
        Me.lstOSMCCEmail.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstOSMCCEmail.Size = New System.Drawing.Size(285, 82)
        Me.lstOSMCCEmail.TabIndex = 10
        '
        'lstOSMToEmail
        '
        Me.lstOSMToEmail.FormattingEnabled = True
        Me.lstOSMToEmail.Location = New System.Drawing.Point(217, 67)
        Me.lstOSMToEmail.Name = "lstOSMToEmail"
        Me.lstOSMToEmail.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstOSMToEmail.Size = New System.Drawing.Size(285, 82)
        Me.lstOSMToEmail.TabIndex = 7
        '
        'cmdOSMRefresh
        '
        Me.cmdOSMRefresh.Location = New System.Drawing.Point(14, 13)
        Me.cmdOSMRefresh.Name = "cmdOSMRefresh"
        Me.cmdOSMRefresh.Size = New System.Drawing.Size(70, 22)
        Me.cmdOSMRefresh.TabIndex = 0
        Me.cmdOSMRefresh.Text = "Refresh"
        Me.cmdOSMRefresh.UseVisualStyleBackColor = True
        '
        'txtItnPNR
        '
        Me.txtItnPNR.AcceptsReturn = True
        Me.txtItnPNR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtItnPNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtItnPNR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItnPNR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtItnPNR.Location = New System.Drawing.Point(16, 74)
        Me.txtItnPNR.MaxLength = 0
        Me.txtItnPNR.Multiline = True
        Me.txtItnPNR.Name = "txtItnPNR"
        Me.txtItnPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtItnPNR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtItnPNR.Size = New System.Drawing.Size(134, 461)
        Me.txtItnPNR.TabIndex = 3
        '
        'lblItnPNR
        '
        Me.lblItnPNR.BackColor = System.Drawing.Color.Yellow
        Me.lblItnPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnPNR.Location = New System.Drawing.Point(13, 58)
        Me.lblItnPNR.Name = "lblItnPNR"
        Me.lblItnPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnPNR.Size = New System.Drawing.Size(137, 13)
        Me.lblItnPNR.TabIndex = 2
        Me.lblItnPNR.Text = "PNR"
        Me.lblItnPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuCopyItn
        '
        Me.MenuCopyItn.Name = "MenuCopyItn"
        Me.MenuCopyItn.Size = New System.Drawing.Size(148, 22)
        Me.MenuCopyItn.Text = "Copy Itinerary"
        '
        'menuITNSelectCopy
        '
        Me.menuITNSelectCopy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuCopyItn})
        Me.menuITNSelectCopy.Name = "menuSelectCopy"
        Me.menuITNSelectCopy.Size = New System.Drawing.Size(149, 26)
        '
        'rtbItnDoc
        '
        Me.rtbItnDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbItnDoc.ContextMenuStrip = Me.menuITNSelectCopy
        Me.rtbItnDoc.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.rtbItnDoc.Location = New System.Drawing.Point(315, 199)
        Me.rtbItnDoc.Name = "rtbItnDoc"
        Me.rtbItnDoc.Size = New System.Drawing.Size(1115, 352)
        Me.rtbItnDoc.TabIndex = 11
        Me.rtbItnDoc.Text = ""
        '
        'chkItnEMD
        '
        Me.chkItnEMD.AutoSize = True
        Me.chkItnEMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnEMD.Location = New System.Drawing.Point(6, 116)
        Me.chkItnEMD.Name = "chkItnEMD"
        Me.chkItnEMD.Size = New System.Drawing.Size(50, 17)
        Me.chkItnEMD.TabIndex = 16
        Me.chkItnEMD.Text = "EMD"
        Me.chkItnEMD.UseVisualStyleBackColor = True
        '
        'chkItnItinRemarks
        '
        Me.chkItnItinRemarks.AutoSize = True
        Me.chkItnItinRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnItinRemarks.Location = New System.Drawing.Point(6, 292)
        Me.chkItnItinRemarks.Name = "chkItnItinRemarks"
        Me.chkItnItinRemarks.Size = New System.Drawing.Size(121, 17)
        Me.chkItnItinRemarks.TabIndex = 15
        Me.chkItnItinRemarks.Text = "Itin.Remarks RIR RI"
        Me.chkItnItinRemarks.UseVisualStyleBackColor = True
        '
        'chkItnCabinDescription
        '
        Me.chkItnCabinDescription.AutoSize = True
        Me.chkItnCabinDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnCabinDescription.Location = New System.Drawing.Point(6, 270)
        Me.chkItnCabinDescription.Name = "chkItnCabinDescription"
        Me.chkItnCabinDescription.Size = New System.Drawing.Size(109, 17)
        Me.chkItnCabinDescription.TabIndex = 14
        Me.chkItnCabinDescription.Text = "Cabin Description"
        Me.chkItnCabinDescription.UseVisualStyleBackColor = True
        '
        'chkItnCostCentre
        '
        Me.chkItnCostCentre.AutoSize = True
        Me.chkItnCostCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnCostCentre.Location = New System.Drawing.Point(6, 248)
        Me.chkItnCostCentre.Name = "chkItnCostCentre"
        Me.chkItnCostCentre.Size = New System.Drawing.Size(81, 17)
        Me.chkItnCostCentre.TabIndex = 13
        Me.chkItnCostCentre.Text = "Cost Centre"
        Me.chkItnCostCentre.UseVisualStyleBackColor = True
        '
        'chkItnFlyingTime
        '
        Me.chkItnFlyingTime.AutoSize = True
        Me.chkItnFlyingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnFlyingTime.Location = New System.Drawing.Point(6, 226)
        Me.chkItnFlyingTime.Name = "chkItnFlyingTime"
        Me.chkItnFlyingTime.Size = New System.Drawing.Size(79, 17)
        Me.chkItnFlyingTime.TabIndex = 12
        Me.chkItnFlyingTime.Text = "Flying Time"
        Me.chkItnFlyingTime.UseVisualStyleBackColor = True
        '
        'chkItnSeating
        '
        Me.chkItnSeating.AutoSize = True
        Me.chkItnSeating.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnSeating.Location = New System.Drawing.Point(6, 160)
        Me.chkItnSeating.Name = "chkItnSeating"
        Me.chkItnSeating.Size = New System.Drawing.Size(118, 17)
        Me.chkItnSeating.TabIndex = 5
        Me.chkItnSeating.Text = "Seating assignment"
        Me.chkItnSeating.UseVisualStyleBackColor = True
        '
        'optItnFormatFleet
        '
        Me.optItnFormatFleet.AutoSize = True
        Me.optItnFormatFleet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatFleet.Location = New System.Drawing.Point(17, 105)
        Me.optItnFormatFleet.Name = "optItnFormatFleet"
        Me.optItnFormatFleet.Size = New System.Drawing.Size(48, 17)
        Me.optItnFormatFleet.TabIndex = 8
        Me.optItnFormatFleet.Text = "Fleet"
        Me.optItnFormatFleet.UseVisualStyleBackColor = True
        '
        'cmdItnExit
        '
        Me.cmdItnExit.Location = New System.Drawing.Point(843, 20)
        Me.cmdItnExit.Name = "cmdItnExit"
        Me.cmdItnExit.Size = New System.Drawing.Size(80, 21)
        Me.cmdItnExit.TabIndex = 12
        Me.cmdItnExit.Text = "Exit"
        Me.cmdItnExit.UseVisualStyleBackColor = True
        '
        'chkItnStopovers
        '
        Me.chkItnStopovers.AutoSize = True
        Me.chkItnStopovers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnStopovers.Location = New System.Drawing.Point(6, 204)
        Me.chkItnStopovers.Name = "chkItnStopovers"
        Me.chkItnStopovers.Size = New System.Drawing.Size(102, 17)
        Me.chkItnStopovers.TabIndex = 7
        Me.chkItnStopovers.Text = "Show stopovers"
        Me.chkItnStopovers.UseVisualStyleBackColor = True
        '
        'chkItnTerminal
        '
        Me.chkItnTerminal.AutoSize = True
        Me.chkItnTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnTerminal.Location = New System.Drawing.Point(6, 182)
        Me.chkItnTerminal.Name = "chkItnTerminal"
        Me.chkItnTerminal.Size = New System.Drawing.Size(92, 17)
        Me.chkItnTerminal.TabIndex = 6
        Me.chkItnTerminal.Text = "Show terminal"
        Me.chkItnTerminal.UseVisualStyleBackColor = True
        '
        'chkItnPaxSegPerTicket
        '
        Me.chkItnPaxSegPerTicket.AutoSize = True
        Me.chkItnPaxSegPerTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnPaxSegPerTicket.Location = New System.Drawing.Point(6, 138)
        Me.chkItnPaxSegPerTicket.Name = "chkItnPaxSegPerTicket"
        Me.chkItnPaxSegPerTicket.Size = New System.Drawing.Size(115, 17)
        Me.chkItnPaxSegPerTicket.TabIndex = 4
        Me.chkItnPaxSegPerTicket.Text = "Pax/Seg per ticket"
        Me.chkItnPaxSegPerTicket.UseVisualStyleBackColor = True
        '
        'chkItnTickets
        '
        Me.chkItnTickets.AutoSize = True
        Me.chkItnTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnTickets.Location = New System.Drawing.Point(6, 94)
        Me.chkItnTickets.Name = "chkItnTickets"
        Me.chkItnTickets.Size = New System.Drawing.Size(61, 17)
        Me.chkItnTickets.TabIndex = 3
        Me.chkItnTickets.Text = "Tickets"
        Me.chkItnTickets.UseVisualStyleBackColor = True
        '
        'chkItnClass
        '
        Me.chkItnClass.AutoSize = True
        Me.chkItnClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnClass.Location = New System.Drawing.Point(6, 50)
        Me.chkItnClass.Name = "chkItnClass"
        Me.chkItnClass.Size = New System.Drawing.Size(102, 17)
        Me.chkItnClass.TabIndex = 1
        Me.chkItnClass.Text = "Class of Service"
        Me.chkItnClass.UseVisualStyleBackColor = True
        '
        'chkItnVessel
        '
        Me.chkItnVessel.AutoSize = True
        Me.chkItnVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnVessel.Location = New System.Drawing.Point(6, 28)
        Me.chkItnVessel.Name = "chkItnVessel"
        Me.chkItnVessel.Size = New System.Drawing.Size(57, 17)
        Me.chkItnVessel.TabIndex = 0
        Me.chkItnVessel.Text = "Vessel"
        Me.chkItnVessel.UseVisualStyleBackColor = True
        '
        'lstItnRemarks
        '
        Me.lstItnRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItnRemarks.CheckOnClick = True
        Me.lstItnRemarks.FormattingEnabled = True
        Me.lstItnRemarks.Location = New System.Drawing.Point(508, 65)
        Me.lstItnRemarks.Name = "lstItnRemarks"
        Me.lstItnRemarks.Size = New System.Drawing.Size(922, 124)
        Me.lstItnRemarks.TabIndex = 8
        '
        'fraItnAirportName
        '
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCityBoth)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCityName)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportBoth)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportname)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCode)
        Me.fraItnAirportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnAirportName.Location = New System.Drawing.Point(172, 58)
        Me.fraItnAirportName.Name = "fraItnAirportName"
        Me.fraItnAirportName.Size = New System.Drawing.Size(137, 134)
        Me.fraItnAirportName.TabIndex = 4
        Me.fraItnAirportName.TabStop = False
        Me.fraItnAirportName.Text = "Airport Name"
        '
        'optItnAirportCityBoth
        '
        Me.optItnAirportCityBoth.AutoSize = True
        Me.optItnAirportCityBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCityBoth.Location = New System.Drawing.Point(7, 88)
        Me.optItnAirportCityBoth.Name = "optItnAirportCityBoth"
        Me.optItnAirportCityBoth.Size = New System.Drawing.Size(109, 17)
        Me.optItnAirportCityBoth.TabIndex = 4
        Me.optItnAirportCityBoth.TabStop = True
        Me.optItnAirportCityBoth.Text = "Code / City Name"
        Me.optItnAirportCityBoth.UseVisualStyleBackColor = True
        '
        'optItnAirportCityName
        '
        Me.optItnAirportCityName.AutoSize = True
        Me.optItnAirportCityName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCityName.Location = New System.Drawing.Point(7, 71)
        Me.optItnAirportCityName.Name = "optItnAirportCityName"
        Me.optItnAirportCityName.Size = New System.Drawing.Size(92, 17)
        Me.optItnAirportCityName.TabIndex = 3
        Me.optItnAirportCityName.TabStop = True
        Me.optItnAirportCityName.Text = "Full City Name"
        Me.optItnAirportCityName.UseVisualStyleBackColor = True
        '
        'optItnAirportBoth
        '
        Me.optItnAirportBoth.AutoSize = True
        Me.optItnAirportBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportBoth.Location = New System.Drawing.Point(6, 54)
        Me.optItnAirportBoth.Name = "optItnAirportBoth"
        Me.optItnAirportBoth.Size = New System.Drawing.Size(122, 17)
        Me.optItnAirportBoth.TabIndex = 2
        Me.optItnAirportBoth.TabStop = True
        Me.optItnAirportBoth.Text = "Code / Airport Name"
        Me.optItnAirportBoth.UseVisualStyleBackColor = True
        '
        'optItnAirportname
        '
        Me.optItnAirportname.AutoSize = True
        Me.optItnAirportname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportname.Location = New System.Drawing.Point(6, 37)
        Me.optItnAirportname.Name = "optItnAirportname"
        Me.optItnAirportname.Size = New System.Drawing.Size(105, 17)
        Me.optItnAirportname.TabIndex = 1
        Me.optItnAirportname.TabStop = True
        Me.optItnAirportname.Text = "Full Airport Name"
        Me.optItnAirportname.UseVisualStyleBackColor = True
        '
        'optItnAirportCode
        '
        Me.optItnAirportCode.AutoSize = True
        Me.optItnAirportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCode.Location = New System.Drawing.Point(6, 20)
        Me.optItnAirportCode.Name = "optItnAirportCode"
        Me.optItnAirportCode.Size = New System.Drawing.Size(89, 17)
        Me.optItnAirportCode.TabIndex = 0
        Me.optItnAirportCode.TabStop = True
        Me.optItnAirportCode.Text = "3 Letter Code"
        Me.optItnAirportCode.UseVisualStyleBackColor = True
        '
        'chkItnAirlineLocator
        '
        Me.chkItnAirlineLocator.AutoSize = True
        Me.chkItnAirlineLocator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnAirlineLocator.Location = New System.Drawing.Point(6, 72)
        Me.chkItnAirlineLocator.Name = "chkItnAirlineLocator"
        Me.chkItnAirlineLocator.Size = New System.Drawing.Size(93, 17)
        Me.chkItnAirlineLocator.TabIndex = 2
        Me.chkItnAirlineLocator.Text = "Airline Locator"
        Me.chkItnAirlineLocator.UseVisualStyleBackColor = True
        '
        'fraItnOptions
        '
        Me.fraItnOptions.Controls.Add(Me.chkItnEMD)
        Me.fraItnOptions.Controls.Add(Me.chkItnItinRemarks)
        Me.fraItnOptions.Controls.Add(Me.chkItnCabinDescription)
        Me.fraItnOptions.Controls.Add(Me.chkItnCostCentre)
        Me.fraItnOptions.Controls.Add(Me.chkItnFlyingTime)
        Me.fraItnOptions.Controls.Add(Me.chkItnSeating)
        Me.fraItnOptions.Controls.Add(Me.chkItnStopovers)
        Me.fraItnOptions.Controls.Add(Me.chkItnTerminal)
        Me.fraItnOptions.Controls.Add(Me.chkItnPaxSegPerTicket)
        Me.fraItnOptions.Controls.Add(Me.chkItnTickets)
        Me.fraItnOptions.Controls.Add(Me.chkItnClass)
        Me.fraItnOptions.Controls.Add(Me.chkItnVessel)
        Me.fraItnOptions.Controls.Add(Me.chkItnAirlineLocator)
        Me.fraItnOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnOptions.Location = New System.Drawing.Point(172, 192)
        Me.fraItnOptions.Name = "fraItnOptions"
        Me.fraItnOptions.Size = New System.Drawing.Size(137, 393)
        Me.fraItnOptions.TabIndex = 6
        Me.fraItnOptions.TabStop = False
        Me.fraItnOptions.Text = "Options"
        '
        'optItnFormatSeaChefsWith3LetterCode
        '
        Me.optItnFormatSeaChefsWith3LetterCode.AutoSize = True
        Me.optItnFormatSeaChefsWith3LetterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatSeaChefsWith3LetterCode.Location = New System.Drawing.Point(17, 71)
        Me.optItnFormatSeaChefsWith3LetterCode.Name = "optItnFormatSeaChefsWith3LetterCode"
        Me.optItnFormatSeaChefsWith3LetterCode.Size = New System.Drawing.Size(158, 17)
        Me.optItnFormatSeaChefsWith3LetterCode.TabIndex = 7
        Me.optItnFormatSeaChefsWith3LetterCode.Text = "Sea Chefs with 3 letter code"
        Me.optItnFormatSeaChefsWith3LetterCode.UseVisualStyleBackColor = True
        '
        'tabPNR
        '
        Me.tabPNR.Controls.Add(Me.tabPageFinisher)
        Me.tabPNR.Controls.Add(Me.tabPageItinerary)
        Me.tabPNR.Controls.Add(Me.tabOSM)
        Me.tabPNR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.tabPNR.Location = New System.Drawing.Point(0, 0)
        Me.tabPNR.Name = "tabPNR"
        Me.tabPNR.SelectedIndex = 0
        Me.tabPNR.Size = New System.Drawing.Size(1472, 619)
        Me.tabPNR.TabIndex = 1
        '
        'tabPageFinisher
        '
        Me.tabPageFinisher.Controls.Add(Me.cmbPNRScenario)
        Me.tabPageFinisher.Controls.Add(Me.cmdPriceOptimiser)
        Me.tabPageFinisher.Controls.Add(Me.lstAirlineEntries)
        Me.tabPageFinisher.Controls.Add(Me.txtTrId)
        Me.tabPageFinisher.Controls.Add(Me.lblTRIDHighLight)
        Me.tabPageFinisher.Controls.Add(Me.lblPNRGalileo)
        Me.tabPageFinisher.Controls.Add(Me.lblPNRAmadeus)
        Me.tabPageFinisher.Controls.Add(Me.txtPNRApis)
        Me.tabPageFinisher.Controls.Add(Me.cmdAPISEditPax)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRRead1GPNR)
        Me.tabPageFinisher.Controls.Add(Me.cmdAdmin)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNROnlyDocs)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRWriteWithDocs)
        Me.tabPageFinisher.Controls.Add(Me.lblSSRDocs)
        Me.tabPageFinisher.Controls.Add(Me.dgvApis)
        Me.tabPageFinisher.Controls.Add(Me.cmdAveragePrice)
        Me.tabPageFinisher.Controls.Add(Me.lblAveragePrice)
        Me.tabPageFinisher.Controls.Add(Me.lblAvPriceDetails)
        Me.tabPageFinisher.Controls.Add(Me.cmdCostCentre)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRRead1APNR)
        Me.tabPageFinisher.Controls.Add(Me.cmdExit)
        Me.tabPageFinisher.Controls.Add(Me.cmdOneTimeVessel)
        Me.tabPageFinisher.Controls.Add(Me.txtSubdepartment)
        Me.tabPageFinisher.Controls.Add(Me.txtCustomer)
        Me.tabPageFinisher.Controls.Add(Me.lblCostCentreHighlight)
        Me.tabPageFinisher.Controls.Add(Me.llbOptions)
        Me.tabPageFinisher.Controls.Add(Me.cmbCostCentre)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRWrite)
        Me.tabPageFinisher.Controls.Add(Me.lstCRM)
        Me.tabPageFinisher.Controls.Add(Me.lblSegs)
        Me.tabPageFinisher.Controls.Add(Me.txtVessel)
        Me.tabPageFinisher.Controls.Add(Me.lblReasonForTravelHighLight)
        Me.tabPageFinisher.Controls.Add(Me.txtCRM)
        Me.tabPageFinisher.Controls.Add(Me.lblPax)
        Me.tabPageFinisher.Controls.Add(Me.lstSubDepartments)
        Me.tabPageFinisher.Controls.Add(Me.cmbReasonForTravel)
        Me.tabPageFinisher.Controls.Add(Me.lblSubDepartment)
        Me.tabPageFinisher.Controls.Add(Me.lblPNR)
        Me.tabPageFinisher.Controls.Add(Me.lblCRM)
        Me.tabPageFinisher.Controls.Add(Me.lblDepartmentHighlight)
        Me.tabPageFinisher.Controls.Add(Me.lstVessels)
        Me.tabPageFinisher.Controls.Add(Me.lblVessel)
        Me.tabPageFinisher.Controls.Add(Me.lblBookedByHighlight)
        Me.tabPageFinisher.Controls.Add(Me.lstCustomers)
        Me.tabPageFinisher.Controls.Add(Me.lblCustomer)
        Me.tabPageFinisher.Controls.Add(Me.lblReference)
        Me.tabPageFinisher.Controls.Add(Me.cmbDepartment)
        Me.tabPageFinisher.Controls.Add(Me.lblAirlinePoints)
        Me.tabPageFinisher.Controls.Add(Me.cmbBookedby)
        Me.tabPageFinisher.Controls.Add(Me.txtReference)
        Me.tabPageFinisher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.tabPageFinisher.Location = New System.Drawing.Point(4, 22)
        Me.tabPageFinisher.Name = "tabPageFinisher"
        Me.tabPageFinisher.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageFinisher.Size = New System.Drawing.Size(1464, 593)
        Me.tabPageFinisher.TabIndex = 0
        Me.tabPageFinisher.Text = "PNR Finisher"
        Me.tabPageFinisher.UseVisualStyleBackColor = True
        '
        'cmdPriceOptimiser
        '
        Me.cmdPriceOptimiser.Location = New System.Drawing.Point(512, 6)
        Me.cmdPriceOptimiser.Name = "cmdPriceOptimiser"
        Me.cmdPriceOptimiser.Size = New System.Drawing.Size(116, 35)
        Me.cmdPriceOptimiser.TabIndex = 49
        Me.cmdPriceOptimiser.Text = "Price Optimiser"
        Me.cmdPriceOptimiser.UseVisualStyleBackColor = True
        '
        'lstAirlineEntries
        '
        Me.lstAirlineEntries.BackColor = System.Drawing.Color.Aqua
        Me.lstAirlineEntries.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lstAirlineEntries.ForeColor = System.Drawing.Color.Blue
        Me.lstAirlineEntries.FormattingEnabled = True
        Me.lstAirlineEntries.Location = New System.Drawing.Point(645, 237)
        Me.lstAirlineEntries.Name = "lstAirlineEntries"
        Me.lstAirlineEntries.Size = New System.Drawing.Size(687, 169)
        Me.lstAirlineEntries.Sorted = True
        Me.lstAirlineEntries.TabIndex = 48
        '
        'txtTrId
        '
        Me.txtTrId.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtTrId.Location = New System.Drawing.Point(778, 178)
        Me.txtTrId.Name = "txtTrId"
        Me.txtTrId.Size = New System.Drawing.Size(207, 20)
        Me.txtTrId.TabIndex = 29
        '
        'lblTRIDHighLight
        '
        Me.lblTRIDHighLight.BackColor = System.Drawing.Color.Pink
        Me.lblTRIDHighLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblTRIDHighLight.Location = New System.Drawing.Point(645, 175)
        Me.lblTRIDHighLight.Name = "lblTRIDHighLight"
        Me.lblTRIDHighLight.Size = New System.Drawing.Size(125, 27)
        Me.lblTRIDHighLight.TabIndex = 28
        Me.lblTRIDHighLight.Text = "TR ID"
        Me.lblTRIDHighLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPNRGalileo
        '
        Me.lblPNRGalileo.AutoSize = True
        Me.lblPNRGalileo.Location = New System.Drawing.Point(193, 42)
        Me.lblPNRGalileo.Name = "lblPNRGalileo"
        Me.lblPNRGalileo.Size = New System.Drawing.Size(21, 13)
        Me.lblPNRGalileo.TabIndex = 2
        Me.lblPNRGalileo.Text = "1G"
        '
        'lblPNRAmadeus
        '
        Me.lblPNRAmadeus.AutoSize = True
        Me.lblPNRAmadeus.Location = New System.Drawing.Point(13, 42)
        Me.lblPNRAmadeus.Name = "lblPNRAmadeus"
        Me.lblPNRAmadeus.Size = New System.Drawing.Size(20, 13)
        Me.lblPNRAmadeus.TabIndex = 0
        Me.lblPNRAmadeus.Text = "1A"
        '
        'txtPNRApis
        '
        Me.txtPNRApis.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPNRApis.Location = New System.Drawing.Point(3, 396)
        Me.txtPNRApis.Multiline = True
        Me.txtPNRApis.Name = "txtPNRApis"
        Me.txtPNRApis.ReadOnly = True
        Me.txtPNRApis.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPNRApis.Size = New System.Drawing.Size(28, 18)
        Me.txtPNRApis.TabIndex = 32
        Me.txtPNRApis.Visible = False
        '
        'cmdAPISEditPax
        '
        Me.cmdAPISEditPax.Location = New System.Drawing.Point(13, 414)
        Me.cmdAPISEditPax.Name = "cmdAPISEditPax"
        Me.cmdAPISEditPax.Size = New System.Drawing.Size(154, 29)
        Me.cmdAPISEditPax.TabIndex = 33
        Me.cmdAPISEditPax.Text = "Edit Pax Info"
        Me.cmdAPISEditPax.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1GPNR
        '
        Me.cmdPNRRead1GPNR.Location = New System.Drawing.Point(193, 6)
        Me.cmdPNRRead1GPNR.Name = "cmdPNRRead1GPNR"
        Me.cmdPNRRead1GPNR.Size = New System.Drawing.Size(157, 35)
        Me.cmdPNRRead1GPNR.TabIndex = 3
        Me.cmdPNRRead1GPNR.Text = "Read Galileo PNR"
        Me.cmdPNRRead1GPNR.UseVisualStyleBackColor = True
        '
        'cmdAdmin
        '
        Me.cmdAdmin.Location = New System.Drawing.Point(1269, 22)
        Me.cmdAdmin.Name = "cmdAdmin"
        Me.cmdAdmin.Size = New System.Drawing.Size(63, 19)
        Me.cmdAdmin.TabIndex = 47
        Me.cmdAdmin.Text = "Admin"
        Me.cmdAdmin.UseVisualStyleBackColor = True
        '
        'cmdPNROnlyDocs
        '
        Me.cmdPNROnlyDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNROnlyDocs.Location = New System.Drawing.Point(1026, 6)
        Me.cmdPNROnlyDocs.Name = "cmdPNROnlyDocs"
        Me.cmdPNROnlyDocs.Size = New System.Drawing.Size(115, 35)
        Me.cmdPNROnlyDocs.TabIndex = 38
        Me.cmdPNROnlyDocs.Text = "Only DOCS"
        Me.cmdPNROnlyDocs.UseVisualStyleBackColor = True
        '
        'cmdPNRWriteWithDocs
        '
        Me.cmdPNRWriteWithDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWriteWithDocs.Location = New System.Drawing.Point(793, 6)
        Me.cmdPNRWriteWithDocs.Name = "cmdPNRWriteWithDocs"
        Me.cmdPNRWriteWithDocs.Size = New System.Drawing.Size(225, 35)
        Me.cmdPNRWriteWithDocs.TabIndex = 37
        Me.cmdPNRWriteWithDocs.Text = "Write to PNR with DOCS"
        Me.cmdPNRWriteWithDocs.UseVisualStyleBackColor = True
        '
        'lblSSRDocs
        '
        Me.lblSSRDocs.BackColor = System.Drawing.Color.Yellow
        Me.lblSSRDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSSRDocs.Location = New System.Drawing.Point(173, 414)
        Me.lblSSRDocs.Name = "lblSSRDocs"
        Me.lblSSRDocs.Size = New System.Drawing.Size(1159, 29)
        Me.lblSSRDocs.TabIndex = 34
        Me.lblSSRDocs.Text = "SSR DOCS"
        Me.lblSSRDocs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvApis
        '
        Me.dgvApis.AllowUserToAddRows = False
        Me.dgvApis.AllowUserToDeleteRows = False
        Me.dgvApis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvApis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApis.Location = New System.Drawing.Point(13, 449)
        Me.dgvApis.Name = "dgvApis"
        Me.dgvApis.Size = New System.Drawing.Size(1319, 136)
        Me.dgvApis.TabIndex = 35
        '
        'cmdAveragePrice
        '
        Me.cmdAveragePrice.Location = New System.Drawing.Point(993, 56)
        Me.cmdAveragePrice.Name = "cmdAveragePrice"
        Me.cmdAveragePrice.Size = New System.Drawing.Size(61, 39)
        Me.cmdAveragePrice.TabIndex = 43
        Me.cmdAveragePrice.Text = "Average Price"
        Me.cmdAveragePrice.UseVisualStyleBackColor = True
        '
        'lblAveragePrice
        '
        Me.lblAveragePrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAveragePrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAveragePrice.Location = New System.Drawing.Point(1060, 78)
        Me.lblAveragePrice.Name = "lblAveragePrice"
        Me.lblAveragePrice.Size = New System.Drawing.Size(272, 17)
        Me.lblAveragePrice.TabIndex = 45
        Me.lblAveragePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAvPriceDetails
        '
        Me.lblAvPriceDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAvPriceDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAvPriceDetails.Location = New System.Drawing.Point(1060, 56)
        Me.lblAvPriceDetails.Name = "lblAvPriceDetails"
        Me.lblAvPriceDetails.Size = New System.Drawing.Size(272, 22)
        Me.lblAvPriceDetails.TabIndex = 44
        Me.lblAvPriceDetails.Text = "Average Price"
        Me.lblAvPriceDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCostCentre
        '
        Me.cmdCostCentre.Location = New System.Drawing.Point(363, 6)
        Me.cmdCostCentre.Name = "cmdCostCentre"
        Me.cmdCostCentre.Size = New System.Drawing.Size(133, 35)
        Me.cmdCostCentre.TabIndex = 4
        Me.cmdCostCentre.Text = "Client Group Cost Centre Lookup"
        Me.cmdCostCentre.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1APNR
        '
        Me.cmdPNRRead1APNR.Location = New System.Drawing.Point(13, 7)
        Me.cmdPNRRead1APNR.Name = "cmdPNRRead1APNR"
        Me.cmdPNRRead1APNR.Size = New System.Drawing.Size(157, 35)
        Me.cmdPNRRead1APNR.TabIndex = 1
        Me.cmdPNRRead1APNR.Text = "Read Amadeus PNR"
        Me.cmdPNRRead1APNR.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1147, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(116, 35)
        Me.cmdExit.TabIndex = 39
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdOneTimeVessel
        '
        Me.cmdOneTimeVessel.Location = New System.Drawing.Point(363, 47)
        Me.cmdOneTimeVessel.Name = "cmdOneTimeVessel"
        Me.cmdOneTimeVessel.Size = New System.Drawing.Size(133, 35)
        Me.cmdOneTimeVessel.TabIndex = 5
        Me.cmdOneTimeVessel.Text = "One time Vessel for PNR"
        Me.cmdOneTimeVessel.UseVisualStyleBackColor = True
        '
        'txtSubdepartment
        '
        Me.txtSubdepartment.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSubdepartment.Location = New System.Drawing.Point(13, 209)
        Me.txtSubdepartment.Name = "txtSubdepartment"
        Me.txtSubdepartment.Size = New System.Drawing.Size(337, 20)
        Me.txtSubdepartment.TabIndex = 10
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(13, 107)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomer.TabIndex = 7
        '
        'lblCostCentreHighlight
        '
        Me.lblCostCentreHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblCostCentreHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCostCentreHighlight.Location = New System.Drawing.Point(993, 175)
        Me.lblCostCentreHighlight.Name = "lblCostCentreHighlight"
        Me.lblCostCentreHighlight.Size = New System.Drawing.Size(125, 27)
        Me.lblCostCentreHighlight.TabIndex = 26
        Me.lblCostCentreHighlight.Text = "Cost Centre"
        Me.lblCostCentreHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'llbOptions
        '
        Me.llbOptions.AutoSize = True
        Me.llbOptions.Location = New System.Drawing.Point(1279, 6)
        Me.llbOptions.Name = "llbOptions"
        Me.llbOptions.Size = New System.Drawing.Size(43, 13)
        Me.llbOptions.TabIndex = 46
        Me.llbOptions.TabStop = True
        Me.llbOptions.Text = "Options"
        '
        'cmbCostCentre
        '
        Me.cmbCostCentre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCostCentre.FormattingEnabled = True
        Me.cmbCostCentre.Location = New System.Drawing.Point(1125, 178)
        Me.cmbCostCentre.Name = "cmbCostCentre"
        Me.cmbCostCentre.Size = New System.Drawing.Size(207, 21)
        Me.cmbCostCentre.TabIndex = 27
        '
        'cmdPNRWrite
        '
        Me.cmdPNRWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWrite.Location = New System.Drawing.Point(644, 6)
        Me.cmdPNRWrite.Name = "cmdPNRWrite"
        Me.cmdPNRWrite.Size = New System.Drawing.Size(141, 35)
        Me.cmdPNRWrite.TabIndex = 36
        Me.cmdPNRWrite.Text = "Write to PNR"
        Me.cmdPNRWrite.UseVisualStyleBackColor = True
        '
        'lstCRM
        '
        Me.lstCRM.FormattingEnabled = True
        Me.lstCRM.Location = New System.Drawing.Point(13, 335)
        Me.lstCRM.Name = "lstCRM"
        Me.lstCRM.Size = New System.Drawing.Size(337, 69)
        Me.lstCRM.TabIndex = 14
        '
        'lblSegs
        '
        Me.lblSegs.BackColor = System.Drawing.Color.Coral
        Me.lblSegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSegs.Location = New System.Drawing.Point(645, 82)
        Me.lblSegs.Name = "lblSegs"
        Me.lblSegs.Size = New System.Drawing.Size(337, 13)
        Me.lblSegs.TabIndex = 42
        Me.lblSegs.Text = "."
        Me.lblSegs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtVessel.Location = New System.Drawing.Point(363, 107)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(265, 20)
        Me.txtVessel.TabIndex = 16
        '
        'lblReasonForTravelHighLight
        '
        Me.lblReasonForTravelHighLight.BackColor = System.Drawing.Color.Pink
        Me.lblReasonForTravelHighLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReasonForTravelHighLight.Location = New System.Drawing.Point(993, 141)
        Me.lblReasonForTravelHighLight.Name = "lblReasonForTravelHighLight"
        Me.lblReasonForTravelHighLight.Size = New System.Drawing.Size(125, 27)
        Me.lblReasonForTravelHighLight.TabIndex = 24
        Me.lblReasonForTravelHighLight.Text = "Reason for Travel"
        Me.lblReasonForTravelHighLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCRM
        '
        Me.txtCRM.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCRM.Location = New System.Drawing.Point(13, 313)
        Me.txtCRM.Name = "txtCRM"
        Me.txtCRM.Size = New System.Drawing.Size(337, 20)
        Me.txtCRM.TabIndex = 13
        '
        'lblPax
        '
        Me.lblPax.BackColor = System.Drawing.Color.Coral
        Me.lblPax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPax.Location = New System.Drawing.Point(645, 69)
        Me.lblPax.Name = "lblPax"
        Me.lblPax.Size = New System.Drawing.Size(337, 13)
        Me.lblPax.TabIndex = 41
        Me.lblPax.Text = "."
        Me.lblPax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstSubDepartments
        '
        Me.lstSubDepartments.FormattingEnabled = True
        Me.lstSubDepartments.Location = New System.Drawing.Point(13, 229)
        Me.lstSubDepartments.Name = "lstSubDepartments"
        Me.lstSubDepartments.Size = New System.Drawing.Size(337, 69)
        Me.lstSubDepartments.TabIndex = 11
        '
        'cmbReasonForTravel
        '
        Me.cmbReasonForTravel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReasonForTravel.FormattingEnabled = True
        Me.cmbReasonForTravel.Location = New System.Drawing.Point(1125, 144)
        Me.cmbReasonForTravel.Name = "cmbReasonForTravel"
        Me.cmbReasonForTravel.Size = New System.Drawing.Size(207, 21)
        Me.cmbReasonForTravel.TabIndex = 25
        '
        'lblSubDepartment
        '
        Me.lblSubDepartment.BackColor = System.Drawing.Color.Yellow
        Me.lblSubDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSubDepartment.Location = New System.Drawing.Point(13, 196)
        Me.lblSubDepartment.Name = "lblSubDepartment"
        Me.lblSubDepartment.Size = New System.Drawing.Size(337, 13)
        Me.lblSubDepartment.TabIndex = 9
        Me.lblSubDepartment.Text = "SubDepartment"
        Me.lblSubDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPNR
        '
        Me.lblPNR.BackColor = System.Drawing.Color.Coral
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.Location = New System.Drawing.Point(645, 56)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.Size = New System.Drawing.Size(337, 13)
        Me.lblPNR.TabIndex = 40
        Me.lblPNR.Text = "."
        Me.lblPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRM
        '
        Me.lblCRM.BackColor = System.Drawing.Color.Yellow
        Me.lblCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCRM.Location = New System.Drawing.Point(13, 300)
        Me.lblCRM.Name = "lblCRM"
        Me.lblCRM.Size = New System.Drawing.Size(337, 13)
        Me.lblCRM.TabIndex = 12
        Me.lblCRM.Text = "CRM - Invoicing Addresses"
        Me.lblCRM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDepartmentHighlight
        '
        Me.lblDepartmentHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblDepartmentHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDepartmentHighlight.Location = New System.Drawing.Point(645, 141)
        Me.lblDepartmentHighlight.Name = "lblDepartmentHighlight"
        Me.lblDepartmentHighlight.Size = New System.Drawing.Size(125, 27)
        Me.lblDepartmentHighlight.TabIndex = 20
        Me.lblDepartmentHighlight.Text = "Department"
        Me.lblDepartmentHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstVessels
        '
        Me.lstVessels.FormattingEnabled = True
        Me.lstVessels.Location = New System.Drawing.Point(363, 127)
        Me.lstVessels.Name = "lstVessels"
        Me.lstVessels.Size = New System.Drawing.Size(265, 277)
        Me.lstVessels.TabIndex = 17
        '
        'lblVessel
        '
        Me.lblVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(363, 91)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(265, 13)
        Me.lblVessel.TabIndex = 15
        Me.lblVessel.Text = "Vessel"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBookedByHighlight
        '
        Me.lblBookedByHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblBookedByHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblBookedByHighlight.Location = New System.Drawing.Point(993, 107)
        Me.lblBookedByHighlight.Name = "lblBookedByHighlight"
        Me.lblBookedByHighlight.Size = New System.Drawing.Size(125, 27)
        Me.lblBookedByHighlight.TabIndex = 22
        Me.lblBookedByHighlight.Text = "Booked by"
        Me.lblBookedByHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstCustomers
        '
        Me.lstCustomers.FormattingEnabled = True
        Me.lstCustomers.Location = New System.Drawing.Point(13, 127)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(337, 69)
        Me.lstCustomers.TabIndex = 8
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Yellow
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(13, 91)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(337, 13)
        Me.lblCustomer.TabIndex = 6
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReference
        '
        Me.lblReference.BackColor = System.Drawing.Color.Cyan
        Me.lblReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReference.Location = New System.Drawing.Point(645, 107)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(125, 27)
        Me.lblReference.TabIndex = 18
        Me.lblReference.Text = "Reference"
        Me.lblReference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(778, 144)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(207, 21)
        Me.cmbDepartment.TabIndex = 21
        '
        'lblAirlinePoints
        '
        Me.lblAirlinePoints.BackColor = System.Drawing.Color.Silver
        Me.lblAirlinePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAirlinePoints.Location = New System.Drawing.Point(645, 209)
        Me.lblAirlinePoints.Name = "lblAirlinePoints"
        Me.lblAirlinePoints.Size = New System.Drawing.Size(687, 28)
        Me.lblAirlinePoints.TabIndex = 30
        Me.lblAirlinePoints.Text = "GDS Elements"
        Me.lblAirlinePoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbBookedby
        '
        Me.cmbBookedby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBookedby.FormattingEnabled = True
        Me.cmbBookedby.Location = New System.Drawing.Point(1125, 110)
        Me.cmbBookedby.Name = "cmbBookedby"
        Me.cmbBookedby.Size = New System.Drawing.Size(207, 21)
        Me.cmbBookedby.TabIndex = 23
        '
        'txtReference
        '
        Me.txtReference.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtReference.Location = New System.Drawing.Point(778, 110)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(207, 20)
        Me.txtReference.TabIndex = 19
        '
        'tabPageItinerary
        '
        Me.tabPageItinerary.Controls.Add(Me.fraGalileo)
        Me.tabPageItinerary.Controls.Add(Me.fraAmadeus)
        Me.tabPageItinerary.Controls.Add(Me.cmdItnFormatOSMLoG)
        Me.tabPageItinerary.Controls.Add(Me.webItnDoc)
        Me.tabPageItinerary.Controls.Add(Me.lblItnPNRCounter)
        Me.tabPageItinerary.Controls.Add(Me.cmdItnRefresh)
        Me.tabPageItinerary.Controls.Add(Me.fraItnFormat)
        Me.tabPageItinerary.Controls.Add(Me.cmdItnExit)
        Me.tabPageItinerary.Controls.Add(Me.lstItnRemarks)
        Me.tabPageItinerary.Controls.Add(Me.fraItnAirportName)
        Me.tabPageItinerary.Controls.Add(Me.fraItnOptions)
        Me.tabPageItinerary.Controls.Add(Me.rtbItnDoc)
        Me.tabPageItinerary.Controls.Add(Me.txtItnPNR)
        Me.tabPageItinerary.Controls.Add(Me.lblItnPNR)
        Me.tabPageItinerary.Location = New System.Drawing.Point(4, 22)
        Me.tabPageItinerary.Name = "tabPageItinerary"
        Me.tabPageItinerary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageItinerary.Size = New System.Drawing.Size(1464, 559)
        Me.tabPageItinerary.TabIndex = 1
        Me.tabPageItinerary.Text = "PNR Itinerary"
        Me.tabPageItinerary.UseVisualStyleBackColor = True
        '
        'fraGalileo
        '
        Me.fraGalileo.Controls.Add(Me.cmdItn1GReadPNR)
        Me.fraGalileo.Controls.Add(Me.cmdItn1GReadCurrent)
        Me.fraGalileo.Controls.Add(Me.cmdItn1GReadQueue)
        Me.fraGalileo.Location = New System.Drawing.Point(306, 6)
        Me.fraGalileo.Name = "fraGalileo"
        Me.fraGalileo.Size = New System.Drawing.Size(289, 46)
        Me.fraGalileo.TabIndex = 22
        Me.fraGalileo.TabStop = False
        Me.fraGalileo.Text = "Galileo"
        '
        'cmdItn1GReadPNR
        '
        Me.cmdItn1GReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1GReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1GReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1GReadPNR.Location = New System.Drawing.Point(6, 14)
        Me.cmdItn1GReadPNR.Name = "cmdItn1GReadPNR"
        Me.cmdItn1GReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1GReadPNR.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1GReadPNR.TabIndex = 0
        Me.cmdItn1GReadPNR.Text = "Read PNR"
        Me.cmdItn1GReadPNR.UseVisualStyleBackColor = True
        '
        'cmdItn1GReadCurrent
        '
        Me.cmdItn1GReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1GReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1GReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1GReadCurrent.Location = New System.Drawing.Point(85, 14)
        Me.cmdItn1GReadCurrent.Name = "cmdItn1GReadCurrent"
        Me.cmdItn1GReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1GReadCurrent.Size = New System.Drawing.Size(99, 21)
        Me.cmdItn1GReadCurrent.TabIndex = 1
        Me.cmdItn1GReadCurrent.Text = "Read Current"
        Me.cmdItn1GReadCurrent.UseVisualStyleBackColor = False
        '
        'cmdItn1GReadQueue
        '
        Me.cmdItn1GReadQueue.Location = New System.Drawing.Point(190, 14)
        Me.cmdItn1GReadQueue.Name = "cmdItn1GReadQueue"
        Me.cmdItn1GReadQueue.Size = New System.Drawing.Size(80, 21)
        Me.cmdItn1GReadQueue.TabIndex = 13
        Me.cmdItn1GReadQueue.Text = "Read Queue"
        Me.cmdItn1GReadQueue.UseVisualStyleBackColor = True
        '
        'fraAmadeus
        '
        Me.fraAmadeus.Controls.Add(Me.cmdItn1AReadPNR)
        Me.fraAmadeus.Controls.Add(Me.cmdItn1AReadCurrent)
        Me.fraAmadeus.Controls.Add(Me.cmdItn1AReadQueue)
        Me.fraAmadeus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraAmadeus.Location = New System.Drawing.Point(11, 6)
        Me.fraAmadeus.Name = "fraAmadeus"
        Me.fraAmadeus.Size = New System.Drawing.Size(289, 46)
        Me.fraAmadeus.TabIndex = 21
        Me.fraAmadeus.TabStop = False
        Me.fraAmadeus.Text = "Amadeus"
        '
        'cmdItn1AReadPNR
        '
        Me.cmdItn1AReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1AReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1AReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1AReadPNR.Location = New System.Drawing.Point(6, 14)
        Me.cmdItn1AReadPNR.Name = "cmdItn1AReadPNR"
        Me.cmdItn1AReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1AReadPNR.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1AReadPNR.TabIndex = 0
        Me.cmdItn1AReadPNR.Text = "Read PNR"
        Me.cmdItn1AReadPNR.UseVisualStyleBackColor = True
        '
        'cmdItn1AReadCurrent
        '
        Me.cmdItn1AReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1AReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1AReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1AReadCurrent.Location = New System.Drawing.Point(85, 14)
        Me.cmdItn1AReadCurrent.Name = "cmdItn1AReadCurrent"
        Me.cmdItn1AReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1AReadCurrent.Size = New System.Drawing.Size(99, 21)
        Me.cmdItn1AReadCurrent.TabIndex = 1
        Me.cmdItn1AReadCurrent.Text = "Read Current"
        Me.cmdItn1AReadCurrent.UseVisualStyleBackColor = False
        '
        'cmdItn1AReadQueue
        '
        Me.cmdItn1AReadQueue.Location = New System.Drawing.Point(190, 14)
        Me.cmdItn1AReadQueue.Name = "cmdItn1AReadQueue"
        Me.cmdItn1AReadQueue.Size = New System.Drawing.Size(80, 21)
        Me.cmdItn1AReadQueue.TabIndex = 13
        Me.cmdItn1AReadQueue.Text = "Read Queue"
        Me.cmdItn1AReadQueue.UseVisualStyleBackColor = True
        '
        'cmdItnFormatOSMLoG
        '
        Me.cmdItnFormatOSMLoG.Location = New System.Drawing.Point(615, 20)
        Me.cmdItnFormatOSMLoG.Name = "cmdItnFormatOSMLoG"
        Me.cmdItnFormatOSMLoG.Size = New System.Drawing.Size(108, 21)
        Me.cmdItnFormatOSMLoG.TabIndex = 17
        Me.cmdItnFormatOSMLoG.Text = "OSM LoG"
        Me.cmdItnFormatOSMLoG.UseVisualStyleBackColor = True
        '
        'webItnDoc
        '
        Me.webItnDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webItnDoc.Location = New System.Drawing.Point(986, 20)
        Me.webItnDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webItnDoc.Name = "webItnDoc"
        Me.webItnDoc.Size = New System.Drawing.Size(96, 20)
        Me.webItnDoc.TabIndex = 16
        Me.webItnDoc.Visible = False
        '
        'lblItnPNRCounter
        '
        Me.lblItnPNRCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItnPNRCounter.BackColor = System.Drawing.Color.Aqua
        Me.lblItnPNRCounter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnPNRCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnPNRCounter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnPNRCounter.Location = New System.Drawing.Point(13, 538)
        Me.lblItnPNRCounter.Name = "lblItnPNRCounter"
        Me.lblItnPNRCounter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnPNRCounter.Size = New System.Drawing.Size(137, 13)
        Me.lblItnPNRCounter.TabIndex = 15
        Me.lblItnPNRCounter.Text = "PNR"
        Me.lblItnPNRCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdItnRefresh
        '
        Me.cmdItnRefresh.Enabled = False
        Me.cmdItnRefresh.Location = New System.Drawing.Point(759, 20)
        Me.cmdItnRefresh.Name = "cmdItnRefresh"
        Me.cmdItnRefresh.Size = New System.Drawing.Size(80, 21)
        Me.cmdItnRefresh.TabIndex = 14
        Me.cmdItnRefresh.Text = "Refresh"
        Me.cmdItnRefresh.UseVisualStyleBackColor = True
        '
        'fraItnFormat
        '
        Me.fraItnFormat.Controls.Add(Me.optItnFormatFleet)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatSeaChefsWith3LetterCode)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatEuronav)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatSeaChefs)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatPlain)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatDefault)
        Me.fraItnFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnFormat.Location = New System.Drawing.Point(317, 58)
        Me.fraItnFormat.Name = "fraItnFormat"
        Me.fraItnFormat.Size = New System.Drawing.Size(183, 134)
        Me.fraItnFormat.TabIndex = 5
        Me.fraItnFormat.TabStop = False
        Me.fraItnFormat.Text = "Format"
        '
        'optItnFormatEuronav
        '
        Me.optItnFormatEuronav.AutoSize = True
        Me.optItnFormatEuronav.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatEuronav.Location = New System.Drawing.Point(17, 88)
        Me.optItnFormatEuronav.Name = "optItnFormatEuronav"
        Me.optItnFormatEuronav.Size = New System.Drawing.Size(65, 17)
        Me.optItnFormatEuronav.TabIndex = 6
        Me.optItnFormatEuronav.Text = "Euronav"
        Me.optItnFormatEuronav.UseVisualStyleBackColor = True
        '
        'optItnFormatSeaChefs
        '
        Me.optItnFormatSeaChefs.AutoSize = True
        Me.optItnFormatSeaChefs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatSeaChefs.Location = New System.Drawing.Point(17, 54)
        Me.optItnFormatSeaChefs.Name = "optItnFormatSeaChefs"
        Me.optItnFormatSeaChefs.Size = New System.Drawing.Size(74, 17)
        Me.optItnFormatSeaChefs.TabIndex = 2
        Me.optItnFormatSeaChefs.Text = "Sea Chefs"
        Me.optItnFormatSeaChefs.UseVisualStyleBackColor = True
        '
        'optItnFormatPlain
        '
        Me.optItnFormatPlain.AutoSize = True
        Me.optItnFormatPlain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatPlain.Location = New System.Drawing.Point(17, 37)
        Me.optItnFormatPlain.Name = "optItnFormatPlain"
        Me.optItnFormatPlain.Size = New System.Drawing.Size(48, 17)
        Me.optItnFormatPlain.TabIndex = 1
        Me.optItnFormatPlain.Text = "Plain"
        Me.optItnFormatPlain.UseVisualStyleBackColor = True
        '
        'optItnFormatDefault
        '
        Me.optItnFormatDefault.AutoSize = True
        Me.optItnFormatDefault.Checked = True
        Me.optItnFormatDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatDefault.Location = New System.Drawing.Point(17, 20)
        Me.optItnFormatDefault.Name = "optItnFormatDefault"
        Me.optItnFormatDefault.Size = New System.Drawing.Size(59, 17)
        Me.optItnFormatDefault.TabIndex = 0
        Me.optItnFormatDefault.TabStop = True
        Me.optItnFormatDefault.Text = "Default"
        Me.optItnFormatDefault.UseVisualStyleBackColor = True
        '
        'cmbPNRScenario
        '
        Me.cmbPNRScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPNRScenario.FormattingEnabled = True
        Me.cmbPNRScenario.Location = New System.Drawing.Point(13, 58)
        Me.cmbPNRScenario.Name = "cmbPNRScenario"
        Me.cmbPNRScenario.Size = New System.Drawing.Size(334, 21)
        Me.cmbPNRScenario.TabIndex = 50
        '
        'frmPNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 619)
        Me.Controls.Add(Me.tabPNR)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPNR"
        Me.Text = "PNR Finisher Athens"
        Me.tabOSM.ResumeLayout(False)
        Me.tabOSM.PerformLayout()
        CType(Me.dgvOSMPax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuITNSelectCopy.ResumeLayout(False)
        Me.fraItnAirportName.ResumeLayout(False)
        Me.fraItnAirportName.PerformLayout()
        Me.fraItnOptions.ResumeLayout(False)
        Me.fraItnOptions.PerformLayout()
        Me.tabPNR.ResumeLayout(False)
        Me.tabPageFinisher.ResumeLayout(False)
        Me.tabPageFinisher.PerformLayout()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageItinerary.ResumeLayout(False)
        Me.tabPageItinerary.PerformLayout()
        Me.fraGalileo.ResumeLayout(False)
        Me.fraAmadeus.ResumeLayout(False)
        Me.fraItnFormat.ResumeLayout(False)
        Me.fraItnFormat.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents tabOSM As TabPage
    Friend WithEvents chkOSMFullPaxSDetails As CheckBox
    Friend WithEvents cmbOSMVesselGroup As ComboBox
    Friend WithEvents chkOSMVesselInUse As CheckBox
    Friend WithEvents lblOSMMultipleSearchSeparator As Label
    Friend WithEvents txtOSMAgentsFilter As TextBox
    Friend WithEvents cmdOSMClearSelected As Button
    Friend WithEvents cmdOSMEmailClear As Button
    Friend WithEvents webOSMDoc As WebBrowser
    Friend WithEvents lstOSMVessels As ListBox
    Friend WithEvents cmdOSMCopyDocument As Button
    Friend WithEvents cmdOSMPrepareDoc As Button
    Friend WithEvents dgvOSMPax As DataGridView
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents LastName As DataGridViewTextBoxColumn
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents Nationality As DataGridViewTextBoxColumn
    Friend WithEvents JoinerLeaver As DataGridViewComboBoxColumn
    Friend WithEvents VisaType As DataGridViewComboBoxColumn
    Friend WithEvents lblOSMPasteEmailsHere As Label
    Friend WithEvents txtOSMPax As TextBox
    Friend WithEvents lblOSMVessel As Label
    Friend WithEvents cmdOSMVesselsEdit As Button
    Friend WithEvents lblOSMVessels As Label
    Friend WithEvents cmdOSMAgentEdit As Button
    Friend WithEvents lblOSMAgents As Label
    Friend WithEvents lstOSMAgents As ListBox
    Friend WithEvents cmdOSMCopyCC As Button
    Friend WithEvents cmdOSMCopyTo As Button
    Friend WithEvents lblOSMEmailsCC As Label
    Friend WithEvents lblOSMEmailsTo As Label
    Friend WithEvents lstOSMCCEmail As ListBox
    Friend WithEvents lstOSMToEmail As ListBox
    Friend WithEvents cmdOSMRefresh As Button
    Public WithEvents txtItnPNR As TextBox
    Public WithEvents lblItnPNR As Label
    Friend WithEvents MenuCopyItn As ToolStripMenuItem
    Friend WithEvents menuITNSelectCopy As ContextMenuStrip
    Friend WithEvents rtbItnDoc As RichTextBox
    Friend WithEvents chkItnEMD As CheckBox
    Friend WithEvents chkItnItinRemarks As CheckBox
    Friend WithEvents chkItnCabinDescription As CheckBox
    Friend WithEvents chkItnCostCentre As CheckBox
    Friend WithEvents chkItnFlyingTime As CheckBox
    Friend WithEvents chkItnSeating As CheckBox
    Friend WithEvents optItnFormatFleet As RadioButton
    Friend WithEvents cmdItnExit As Button
    Friend WithEvents chkItnStopovers As CheckBox
    Friend WithEvents chkItnTerminal As CheckBox
    Friend WithEvents chkItnPaxSegPerTicket As CheckBox
    Friend WithEvents chkItnTickets As CheckBox
    Friend WithEvents chkItnClass As CheckBox
    Friend WithEvents chkItnVessel As CheckBox
    Friend WithEvents lstItnRemarks As CheckedListBox
    Friend WithEvents fraItnAirportName As GroupBox
    Friend WithEvents optItnAirportCityBoth As RadioButton
    Friend WithEvents optItnAirportCityName As RadioButton
    Friend WithEvents optItnAirportBoth As RadioButton
    Friend WithEvents optItnAirportname As RadioButton
    Friend WithEvents optItnAirportCode As RadioButton
    Friend WithEvents chkItnAirlineLocator As CheckBox
    Friend WithEvents fraItnOptions As GroupBox
    Friend WithEvents ttpToolTip As ToolTip
    Friend WithEvents optItnFormatSeaChefsWith3LetterCode As RadioButton
    Friend WithEvents tabPNR As TabControl
    Friend WithEvents tabPageFinisher As TabPage
    Friend WithEvents cmdPriceOptimiser As Button
    Friend WithEvents lstAirlineEntries As CheckedListBox
    Friend WithEvents txtTrId As TextBox
    Friend WithEvents lblTRIDHighLight As Label
    Friend WithEvents lblPNRGalileo As Label
    Friend WithEvents lblPNRAmadeus As Label
    Friend WithEvents txtPNRApis As TextBox
    Friend WithEvents cmdAPISEditPax As Button
    Friend WithEvents cmdPNRRead1GPNR As Button
    Friend WithEvents cmdAdmin As Button
    Friend WithEvents cmdPNROnlyDocs As Button
    Friend WithEvents cmdPNRWriteWithDocs As Button
    Friend WithEvents lblSSRDocs As Label
    Friend WithEvents dgvApis As DataGridView
    Friend WithEvents cmdAveragePrice As Button
    Friend WithEvents lblAveragePrice As Label
    Friend WithEvents lblAvPriceDetails As Label
    Friend WithEvents cmdCostCentre As Button
    Friend WithEvents cmdPNRRead1APNR As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdOneTimeVessel As Button
    Friend WithEvents txtSubdepartment As TextBox
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents lblCostCentreHighlight As Label
    Friend WithEvents llbOptions As LinkLabel
    Friend WithEvents cmbCostCentre As ComboBox
    Friend WithEvents cmdPNRWrite As Button
    Friend WithEvents lstCRM As ListBox
    Friend WithEvents lblSegs As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents lblReasonForTravelHighLight As Label
    Friend WithEvents txtCRM As TextBox
    Friend WithEvents lblPax As Label
    Friend WithEvents lstSubDepartments As ListBox
    Friend WithEvents cmbReasonForTravel As ComboBox
    Friend WithEvents lblSubDepartment As Label
    Friend WithEvents lblPNR As Label
    Friend WithEvents lblCRM As Label
    Friend WithEvents lblDepartmentHighlight As Label
    Friend WithEvents lstVessels As ListBox
    Friend WithEvents lblVessel As Label
    Friend WithEvents lblBookedByHighlight As Label
    Friend WithEvents lstCustomers As ListBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblReference As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents lblAirlinePoints As Label
    Friend WithEvents cmbBookedby As ComboBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents tabPageItinerary As TabPage
    Friend WithEvents fraGalileo As GroupBox
    Public WithEvents cmdItn1GReadPNR As Button
    Public WithEvents cmdItn1GReadCurrent As Button
    Friend WithEvents cmdItn1GReadQueue As Button
    Friend WithEvents fraAmadeus As GroupBox
    Public WithEvents cmdItn1AReadPNR As Button
    Public WithEvents cmdItn1AReadCurrent As Button
    Friend WithEvents cmdItn1AReadQueue As Button
    Friend WithEvents cmdItnFormatOSMLoG As Button
    Friend WithEvents webItnDoc As WebBrowser
    Public WithEvents lblItnPNRCounter As Label
    Friend WithEvents cmdItnRefresh As Button
    Friend WithEvents fraItnFormat As GroupBox
    Friend WithEvents optItnFormatEuronav As RadioButton
    Friend WithEvents optItnFormatSeaChefs As RadioButton
    Friend WithEvents optItnFormatPlain As RadioButton
    Friend WithEvents optItnFormatDefault As RadioButton
    Friend WithEvents cmbPNRScenario As ComboBox
End Class
