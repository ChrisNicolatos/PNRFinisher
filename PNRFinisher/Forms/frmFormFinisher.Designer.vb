<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFormFinisher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblCTC = New System.Windows.Forms.Label()
        Me.cmdCTCForm = New System.Windows.Forms.Button()
        Me.cmbInterofficePurchase = New System.Windows.Forms.ComboBox()
        Me.cmdPriceOptimiser = New System.Windows.Forms.Button()
        Me.lstGDSEntries = New System.Windows.Forms.CheckedListBox()
        Me.txtTrId = New System.Windows.Forms.TextBox()
        Me.lblTRID = New System.Windows.Forms.Label()
        Me.txtPNRApis = New System.Windows.Forms.TextBox()
        Me.cmdAPISEditPax = New System.Windows.Forms.Button()
        Me.cmdPNRRead1GPNR = New System.Windows.Forms.Button()
        Me.cmdPNROnlyDocs = New System.Windows.Forms.Button()
        Me.cmdPNRWriteWithDocs = New System.Windows.Forms.Button()
        Me.lblSSRDocs = New System.Windows.Forms.Label()
        Me.dgvApis = New System.Windows.Forms.DataGridView()
        Me.cmdItineraryHelper = New System.Windows.Forms.Button()
        Me.cmdCostCentre = New System.Windows.Forms.Button()
        Me.cmdPNRRead1APNR = New System.Windows.Forms.Button()
        Me.cmdOneTimeVessel = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lblCostCentre = New System.Windows.Forms.Label()
        Me.cmbCostCentre = New System.Windows.Forms.ComboBox()
        Me.cmdPNRWrite = New System.Windows.Forms.Button()
        Me.lblSegs = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.lblReasonForTravel = New System.Windows.Forms.Label()
        Me.lblPax = New System.Windows.Forms.Label()
        Me.cmbReasonForTravel = New System.Windows.Forms.ComboBox()
        Me.lblSubDepartment = New System.Windows.Forms.Label()
        Me.lblPNR = New System.Windows.Forms.Label()
        Me.lblCRM = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lstVessels = New System.Windows.Forms.ListBox()
        Me.lblVessel = New System.Windows.Forms.Label()
        Me.lblBookedBy = New System.Windows.Forms.Label()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblReference = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.cmbBookedby = New System.Windows.Forms.ComboBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SSGDS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSPCC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.optClientATH = New System.Windows.Forms.RadioButton()
        Me.optClientQLI = New System.Windows.Forms.RadioButton()
        Me.tabCustomProperties = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbCRM = New System.Windows.Forms.ComboBox()
        Me.cmbSubDepartment = New System.Windows.Forms.ComboBox()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.tmrWarning = New System.Windows.Forms.Timer(Me.components)
        Me.grpGDSEntries = New System.Windows.Forms.GroupBox()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.tabCustomProperties.SuspendLayout()
        Me.grpGDSEntries.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCTC
        '
        Me.lblCTC.BackColor = System.Drawing.Color.Yellow
        Me.lblCTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCTC.Location = New System.Drawing.Point(1008, 460)
        Me.lblCTC.Name = "lblCTC"
        Me.lblCTC.Size = New System.Drawing.Size(91, 29)
        Me.lblCTC.TabIndex = 102
        Me.lblCTC.Text = "CTC"
        Me.lblCTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCTCForm
        '
        Me.cmdCTCForm.Location = New System.Drawing.Point(1105, 460)
        Me.cmdCTCForm.Name = "cmdCTCForm"
        Me.cmdCTCForm.Size = New System.Drawing.Size(269, 29)
        Me.cmdCTCForm.TabIndex = 101
        Me.cmdCTCForm.Text = "Passenger Contact Information (CTC)"
        Me.cmdCTCForm.UseVisualStyleBackColor = True
        '
        'cmbInterofficePurchase
        '
        Me.cmbInterofficePurchase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInterofficePurchase.FormattingEnabled = True
        Me.cmbInterofficePurchase.Location = New System.Drawing.Point(12, 52)
        Me.cmbInterofficePurchase.Name = "cmbInterofficePurchase"
        Me.cmbInterofficePurchase.Size = New System.Drawing.Size(322, 21)
        Me.cmbInterofficePurchase.TabIndex = 99
        Me.cmbInterofficePurchase.Visible = False
        '
        'cmdPriceOptimiser
        '
        Me.cmdPriceOptimiser.Location = New System.Drawing.Point(624, 11)
        Me.cmdPriceOptimiser.Name = "cmdPriceOptimiser"
        Me.cmdPriceOptimiser.Size = New System.Drawing.Size(116, 35)
        Me.cmdPriceOptimiser.TabIndex = 98
        Me.cmdPriceOptimiser.Text = "Price Optimiser"
        Me.cmdPriceOptimiser.UseVisualStyleBackColor = True
        '
        'lstGDSEntries
        '
        Me.lstGDSEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstGDSEntries.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lstGDSEntries.FormattingEnabled = True
        Me.lstGDSEntries.Location = New System.Drawing.Point(6, 52)
        Me.lstGDSEntries.Name = "lstGDSEntries"
        Me.lstGDSEntries.Size = New System.Drawing.Size(616, 319)
        Me.lstGDSEntries.TabIndex = 97
        '
        'txtTrId
        '
        Me.txtTrId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTrId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTrId.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtTrId.Location = New System.Drawing.Point(172, 108)
        Me.txtTrId.Name = "txtTrId"
        Me.txtTrId.Size = New System.Drawing.Size(563, 20)
        Me.txtTrId.TabIndex = 81
        '
        'lblTRID
        '
        Me.lblTRID.BackColor = System.Drawing.Color.Pink
        Me.lblTRID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblTRID.Location = New System.Drawing.Point(4, 105)
        Me.lblTRID.Name = "lblTRID"
        Me.lblTRID.Size = New System.Drawing.Size(160, 23)
        Me.lblTRID.TabIndex = 80
        Me.lblTRID.Text = "TR ID"
        Me.lblTRID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPNRApis
        '
        Me.txtPNRApis.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPNRApis.Location = New System.Drawing.Point(1353, 53)
        Me.txtPNRApis.Multiline = True
        Me.txtPNRApis.Name = "txtPNRApis"
        Me.txtPNRApis.ReadOnly = True
        Me.txtPNRApis.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPNRApis.Size = New System.Drawing.Size(28, 18)
        Me.txtPNRApis.TabIndex = 83
        Me.txtPNRApis.Visible = False
        '
        'cmdAPISEditPax
        '
        Me.cmdAPISEditPax.Location = New System.Drawing.Point(12, 460)
        Me.cmdAPISEditPax.Name = "cmdAPISEditPax"
        Me.cmdAPISEditPax.Size = New System.Drawing.Size(154, 29)
        Me.cmdAPISEditPax.TabIndex = 84
        Me.cmdAPISEditPax.Text = "Edit Pax SSRDOCS"
        Me.cmdAPISEditPax.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1GPNR
        '
        Me.cmdPNRRead1GPNR.Location = New System.Drawing.Point(177, 11)
        Me.cmdPNRRead1GPNR.Name = "cmdPNRRead1GPNR"
        Me.cmdPNRRead1GPNR.Size = New System.Drawing.Size(157, 35)
        Me.cmdPNRRead1GPNR.TabIndex = 55
        Me.cmdPNRRead1GPNR.Text = "Read Galileo PNR"
        Me.cmdPNRRead1GPNR.UseVisualStyleBackColor = True
        '
        'cmdPNROnlyDocs
        '
        Me.cmdPNROnlyDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNROnlyDocs.Location = New System.Drawing.Point(1130, 11)
        Me.cmdPNROnlyDocs.Name = "cmdPNROnlyDocs"
        Me.cmdPNROnlyDocs.Size = New System.Drawing.Size(115, 35)
        Me.cmdPNROnlyDocs.TabIndex = 89
        Me.cmdPNROnlyDocs.Text = "Only DOCS"
        Me.cmdPNROnlyDocs.UseVisualStyleBackColor = True
        '
        'cmdPNRWriteWithDocs
        '
        Me.cmdPNRWriteWithDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWriteWithDocs.Location = New System.Drawing.Point(897, 11)
        Me.cmdPNRWriteWithDocs.Name = "cmdPNRWriteWithDocs"
        Me.cmdPNRWriteWithDocs.Size = New System.Drawing.Size(225, 35)
        Me.cmdPNRWriteWithDocs.TabIndex = 88
        Me.cmdPNRWriteWithDocs.Text = "Write to PNR with DOCS"
        Me.cmdPNRWriteWithDocs.UseVisualStyleBackColor = True
        '
        'lblSSRDocs
        '
        Me.lblSSRDocs.BackColor = System.Drawing.Color.Yellow
        Me.lblSSRDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSSRDocs.Location = New System.Drawing.Point(172, 460)
        Me.lblSSRDocs.Name = "lblSSRDocs"
        Me.lblSSRDocs.Size = New System.Drawing.Size(830, 29)
        Me.lblSSRDocs.TabIndex = 85
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
        Me.dgvApis.Location = New System.Drawing.Point(12, 495)
        Me.dgvApis.Name = "dgvApis"
        Me.dgvApis.Size = New System.Drawing.Size(1362, 132)
        Me.dgvApis.TabIndex = 86
        '
        'cmdItineraryHelper
        '
        Me.cmdItineraryHelper.Location = New System.Drawing.Point(1251, 11)
        Me.cmdItineraryHelper.Name = "cmdItineraryHelper"
        Me.cmdItineraryHelper.Size = New System.Drawing.Size(125, 35)
        Me.cmdItineraryHelper.TabIndex = 94
        Me.cmdItineraryHelper.Text = "Itinerary Helper"
        Me.cmdItineraryHelper.UseVisualStyleBackColor = True
        '
        'cmdCostCentre
        '
        Me.cmdCostCentre.Location = New System.Drawing.Point(342, 11)
        Me.cmdCostCentre.Name = "cmdCostCentre"
        Me.cmdCostCentre.Size = New System.Drawing.Size(133, 35)
        Me.cmdCostCentre.TabIndex = 56
        Me.cmdCostCentre.Text = "Client Group Cost Centre Lookup"
        Me.cmdCostCentre.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1APNR
        '
        Me.cmdPNRRead1APNR.Location = New System.Drawing.Point(12, 11)
        Me.cmdPNRRead1APNR.Name = "cmdPNRRead1APNR"
        Me.cmdPNRRead1APNR.Size = New System.Drawing.Size(157, 35)
        Me.cmdPNRRead1APNR.TabIndex = 54
        Me.cmdPNRRead1APNR.Text = "Read Amadeus PNR"
        Me.cmdPNRRead1APNR.UseVisualStyleBackColor = True
        '
        'cmdOneTimeVessel
        '
        Me.cmdOneTimeVessel.Location = New System.Drawing.Point(483, 11)
        Me.cmdOneTimeVessel.Name = "cmdOneTimeVessel"
        Me.cmdOneTimeVessel.Size = New System.Drawing.Size(133, 35)
        Me.cmdOneTimeVessel.TabIndex = 57
        Me.cmdOneTimeVessel.Text = "One time Vessel for PNR"
        Me.cmdOneTimeVessel.UseVisualStyleBackColor = True
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(12, 93)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomer.TabIndex = 59
        '
        'lblCostCentre
        '
        Me.lblCostCentre.BackColor = System.Drawing.Color.Pink
        Me.lblCostCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCostCentre.Location = New System.Drawing.Point(4, 183)
        Me.lblCostCentre.Name = "lblCostCentre"
        Me.lblCostCentre.Size = New System.Drawing.Size(160, 23)
        Me.lblCostCentre.TabIndex = 78
        Me.lblCostCentre.Text = "Cost Centre"
        Me.lblCostCentre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbCostCentre
        '
        Me.cmbCostCentre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCostCentre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCostCentre.FormattingEnabled = True
        Me.cmbCostCentre.Location = New System.Drawing.Point(172, 186)
        Me.cmbCostCentre.Name = "cmbCostCentre"
        Me.cmbCostCentre.Size = New System.Drawing.Size(563, 21)
        Me.cmbCostCentre.TabIndex = 79
        '
        'cmdPNRWrite
        '
        Me.cmdPNRWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWrite.Location = New System.Drawing.Point(748, 11)
        Me.cmdPNRWrite.Name = "cmdPNRWrite"
        Me.cmdPNRWrite.Size = New System.Drawing.Size(141, 35)
        Me.cmdPNRWrite.TabIndex = 87
        Me.cmdPNRWrite.Text = "Write to PNR"
        Me.cmdPNRWrite.UseVisualStyleBackColor = True
        '
        'lblSegs
        '
        Me.lblSegs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSegs.BackColor = System.Drawing.Color.Coral
        Me.lblSegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSegs.Location = New System.Drawing.Point(6, 38)
        Me.lblSegs.Name = "lblSegs"
        Me.lblSegs.Size = New System.Drawing.Size(616, 13)
        Me.lblSegs.TabIndex = 93
        Me.lblSegs.Text = "."
        Me.lblSegs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtVessel.Location = New System.Drawing.Point(355, 93)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(385, 20)
        Me.txtVessel.TabIndex = 68
        '
        'lblReasonForTravel
        '
        Me.lblReasonForTravel.BackColor = System.Drawing.Color.Pink
        Me.lblReasonForTravel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReasonForTravel.Location = New System.Drawing.Point(4, 157)
        Me.lblReasonForTravel.Name = "lblReasonForTravel"
        Me.lblReasonForTravel.Size = New System.Drawing.Size(160, 23)
        Me.lblReasonForTravel.TabIndex = 76
        Me.lblReasonForTravel.Text = "Reason for Travel"
        Me.lblReasonForTravel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPax
        '
        Me.lblPax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPax.BackColor = System.Drawing.Color.Coral
        Me.lblPax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPax.Location = New System.Drawing.Point(6, 25)
        Me.lblPax.Name = "lblPax"
        Me.lblPax.Size = New System.Drawing.Size(616, 13)
        Me.lblPax.TabIndex = 92
        Me.lblPax.Text = "."
        Me.lblPax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbReasonForTravel
        '
        Me.cmbReasonForTravel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbReasonForTravel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReasonForTravel.FormattingEnabled = True
        Me.cmbReasonForTravel.Location = New System.Drawing.Point(172, 160)
        Me.cmbReasonForTravel.Name = "cmbReasonForTravel"
        Me.cmbReasonForTravel.Size = New System.Drawing.Size(563, 21)
        Me.cmbReasonForTravel.TabIndex = 77
        '
        'lblSubDepartment
        '
        Me.lblSubDepartment.BackColor = System.Drawing.Color.Pink
        Me.lblSubDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSubDepartment.Location = New System.Drawing.Point(4, 1)
        Me.lblSubDepartment.Name = "lblSubDepartment"
        Me.lblSubDepartment.Size = New System.Drawing.Size(160, 23)
        Me.lblSubDepartment.TabIndex = 61
        Me.lblSubDepartment.Text = "SubDepartment"
        Me.lblSubDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPNR
        '
        Me.lblPNR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPNR.BackColor = System.Drawing.Color.Coral
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.Location = New System.Drawing.Point(6, 12)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.Size = New System.Drawing.Size(616, 13)
        Me.lblPNR.TabIndex = 91
        Me.lblPNR.Text = "."
        Me.lblPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRM
        '
        Me.lblCRM.BackColor = System.Drawing.Color.Pink
        Me.lblCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCRM.Location = New System.Drawing.Point(4, 27)
        Me.lblCRM.Name = "lblCRM"
        Me.lblCRM.Size = New System.Drawing.Size(160, 23)
        Me.lblCRM.TabIndex = 64
        Me.lblCRM.Text = "CRM - Invoicing Addresses"
        Me.lblCRM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDepartment
        '
        Me.lblDepartment.BackColor = System.Drawing.Color.Pink
        Me.lblDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDepartment.Location = New System.Drawing.Point(4, 79)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(160, 23)
        Me.lblDepartment.TabIndex = 72
        Me.lblDepartment.Text = "Department"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstVessels
        '
        Me.lstVessels.FormattingEnabled = True
        Me.lstVessels.Location = New System.Drawing.Point(355, 113)
        Me.lstVessels.Name = "lstVessels"
        Me.lstVessels.Size = New System.Drawing.Size(385, 121)
        Me.lstVessels.TabIndex = 69
        '
        'lblVessel
        '
        Me.lblVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(355, 77)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(385, 13)
        Me.lblVessel.TabIndex = 67
        Me.lblVessel.Text = "Vessel"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBookedBy
        '
        Me.lblBookedBy.BackColor = System.Drawing.Color.Pink
        Me.lblBookedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblBookedBy.Location = New System.Drawing.Point(4, 131)
        Me.lblBookedBy.Name = "lblBookedBy"
        Me.lblBookedBy.Size = New System.Drawing.Size(160, 23)
        Me.lblBookedBy.TabIndex = 74
        Me.lblBookedBy.Text = "Booked by"
        Me.lblBookedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstCustomers
        '
        Me.lstCustomers.FormattingEnabled = True
        Me.lstCustomers.Location = New System.Drawing.Point(12, 113)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(337, 121)
        Me.lstCustomers.TabIndex = 60
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Yellow
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(12, 77)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(157, 13)
        Me.lblCustomer.TabIndex = 58
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReference
        '
        Me.lblReference.BackColor = System.Drawing.Color.Pink
        Me.lblReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReference.Location = New System.Drawing.Point(4, 53)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(160, 23)
        Me.lblReference.TabIndex = 70
        Me.lblReference.Text = "Reference"
        Me.lblReference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbDepartment
        '
        Me.cmbDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(172, 82)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(563, 21)
        Me.cmbDepartment.TabIndex = 73
        '
        'cmbBookedby
        '
        Me.cmbBookedby.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbBookedby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBookedby.FormattingEnabled = True
        Me.cmbBookedby.Location = New System.Drawing.Point(172, 134)
        Me.cmbBookedby.Name = "cmbBookedby"
        Me.cmbBookedby.Size = New System.Drawing.Size(563, 21)
        Me.cmbBookedby.TabIndex = 75
        '
        'txtReference
        '
        Me.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReference.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtReference.Location = New System.Drawing.Point(172, 56)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(563, 20)
        Me.txtReference.TabIndex = 71
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SSGDS, Me.SSPCC, Me.SSUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 643)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1393, 22)
        Me.StatusStrip1.TabIndex = 103
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SSGDS
        '
        Me.SSGDS.Name = "SSGDS"
        Me.SSGDS.Size = New System.Drawing.Size(29, 17)
        Me.SSGDS.Text = "GDS"
        '
        'SSPCC
        '
        Me.SSPCC.Name = "SSPCC"
        Me.SSPCC.Size = New System.Drawing.Size(30, 17)
        Me.SSPCC.Text = "PCC"
        '
        'SSUser
        '
        Me.SSUser.Name = "SSUser"
        Me.SSUser.Size = New System.Drawing.Size(30, 17)
        Me.SSUser.Text = "User"
        '
        'optClientATH
        '
        Me.optClientATH.AutoSize = True
        Me.optClientATH.Location = New System.Drawing.Point(192, 75)
        Me.optClientATH.Name = "optClientATH"
        Me.optClientATH.Size = New System.Drawing.Size(47, 17)
        Me.optClientATH.TabIndex = 104
        Me.optClientATH.TabStop = True
        Me.optClientATH.Text = "ATH"
        Me.optClientATH.UseVisualStyleBackColor = True
        '
        'optClientQLI
        '
        Me.optClientQLI.AutoSize = True
        Me.optClientQLI.Location = New System.Drawing.Point(256, 75)
        Me.optClientQLI.Name = "optClientQLI"
        Me.optClientQLI.Size = New System.Drawing.Size(42, 17)
        Me.optClientQLI.TabIndex = 105
        Me.optClientQLI.TabStop = True
        Me.optClientQLI.Text = "QLI"
        Me.optClientQLI.UseVisualStyleBackColor = True
        '
        'tabCustomProperties
        '
        Me.tabCustomProperties.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tabCustomProperties.ColumnCount = 2
        Me.tabCustomProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167.0!))
        Me.tabCustomProperties.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 569.0!))
        Me.tabCustomProperties.Controls.Add(Me.cmbCRM, 1, 1)
        Me.tabCustomProperties.Controls.Add(Me.cmbSubDepartment, 1, 0)
        Me.tabCustomProperties.Controls.Add(Me.lblReference, 0, 2)
        Me.tabCustomProperties.Controls.Add(Me.txtReference, 1, 2)
        Me.tabCustomProperties.Controls.Add(Me.lblDepartment, 0, 3)
        Me.tabCustomProperties.Controls.Add(Me.cmbDepartment, 1, 3)
        Me.tabCustomProperties.Controls.Add(Me.lblTRID, 0, 4)
        Me.tabCustomProperties.Controls.Add(Me.txtTrId, 1, 4)
        Me.tabCustomProperties.Controls.Add(Me.lblBookedBy, 0, 5)
        Me.tabCustomProperties.Controls.Add(Me.cmbBookedby, 1, 5)
        Me.tabCustomProperties.Controls.Add(Me.lblReasonForTravel, 0, 6)
        Me.tabCustomProperties.Controls.Add(Me.cmbReasonForTravel, 1, 6)
        Me.tabCustomProperties.Controls.Add(Me.lblCostCentre, 0, 7)
        Me.tabCustomProperties.Controls.Add(Me.cmbCostCentre, 1, 7)
        Me.tabCustomProperties.Controls.Add(Me.lblCRM, 0, 1)
        Me.tabCustomProperties.Controls.Add(Me.lblSubDepartment, 0, 0)
        Me.tabCustomProperties.Location = New System.Drawing.Point(12, 244)
        Me.tabCustomProperties.Name = "tabCustomProperties"
        Me.tabCustomProperties.RowCount = 8
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tabCustomProperties.Size = New System.Drawing.Size(728, 210)
        Me.tabCustomProperties.TabIndex = 106
        '
        'cmbCRM
        '
        Me.cmbCRM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCRM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCRM.FormattingEnabled = True
        Me.cmbCRM.Location = New System.Drawing.Point(172, 30)
        Me.cmbCRM.Name = "cmbCRM"
        Me.cmbCRM.Size = New System.Drawing.Size(563, 21)
        Me.cmbCRM.TabIndex = 83
        '
        'cmbSubDepartment
        '
        Me.cmbSubDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSubDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubDepartment.FormattingEnabled = True
        Me.cmbSubDepartment.Location = New System.Drawing.Point(172, 4)
        Me.cmbSubDepartment.Name = "cmbSubDepartment"
        Me.cmbSubDepartment.Size = New System.Drawing.Size(563, 21)
        Me.cmbSubDepartment.TabIndex = 82
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.SystemColors.Control
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblWarning.Location = New System.Drawing.Point(355, 52)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(1019, 21)
        Me.lblWarning.TabIndex = 107
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrWarning
        '
        Me.tmrWarning.Interval = 500
        '
        'grpGDSEntries
        '
        Me.grpGDSEntries.Controls.Add(Me.lstGDSEntries)
        Me.grpGDSEntries.Controls.Add(Me.lblPNR)
        Me.grpGDSEntries.Controls.Add(Me.lblPax)
        Me.grpGDSEntries.Controls.Add(Me.lblSegs)
        Me.grpGDSEntries.Location = New System.Drawing.Point(746, 76)
        Me.grpGDSEntries.Name = "grpGDSEntries"
        Me.grpGDSEntries.Size = New System.Drawing.Size(628, 380)
        Me.grpGDSEntries.TabIndex = 108
        Me.grpGDSEntries.TabStop = False
        '
        'frmFormFinisher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1393, 665)
        Me.Controls.Add(Me.grpGDSEntries)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.cmdPNRRead1APNR)
        Me.Controls.Add(Me.cmdPNRRead1GPNR)
        Me.Controls.Add(Me.tabCustomProperties)
        Me.Controls.Add(Me.cmdCostCentre)
        Me.Controls.Add(Me.optClientQLI)
        Me.Controls.Add(Me.optClientATH)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblCTC)
        Me.Controls.Add(Me.cmdCTCForm)
        Me.Controls.Add(Me.cmbInterofficePurchase)
        Me.Controls.Add(Me.cmdPriceOptimiser)
        Me.Controls.Add(Me.txtPNRApis)
        Me.Controls.Add(Me.cmdAPISEditPax)
        Me.Controls.Add(Me.cmdPNROnlyDocs)
        Me.Controls.Add(Me.cmdPNRWriteWithDocs)
        Me.Controls.Add(Me.lblSSRDocs)
        Me.Controls.Add(Me.dgvApis)
        Me.Controls.Add(Me.cmdItineraryHelper)
        Me.Controls.Add(Me.cmdOneTimeVessel)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.cmdPNRWrite)
        Me.Controls.Add(Me.txtVessel)
        Me.Controls.Add(Me.lstVessels)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.lstCustomers)
        Me.Controls.Add(Me.lblCustomer)
        Me.MinimumSize = New System.Drawing.Size(1409, 704)
        Me.Name = "frmFormFinisher"
        Me.Text = "Finisher"
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabCustomProperties.ResumeLayout(False)
        Me.tabCustomProperties.PerformLayout()
        Me.grpGDSEntries.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCTC As Label
    Friend WithEvents cmdCTCForm As Button
    Friend WithEvents cmbInterofficePurchase As ComboBox
    Friend WithEvents cmdPriceOptimiser As Button
    Friend WithEvents lstGDSEntries As CheckedListBox
    Friend WithEvents txtTrId As TextBox
    Friend WithEvents lblTRID As Label
    Friend WithEvents txtPNRApis As TextBox
    Friend WithEvents cmdAPISEditPax As Button
    Friend WithEvents cmdPNRRead1GPNR As Button
    Friend WithEvents cmdPNROnlyDocs As Button
    Friend WithEvents cmdPNRWriteWithDocs As Button
    Friend WithEvents lblSSRDocs As Label
    Friend WithEvents dgvApis As DataGridView
    Friend WithEvents cmdItineraryHelper As Button
    Friend WithEvents cmdCostCentre As Button
    Friend WithEvents cmdPNRRead1APNR As Button
    Friend WithEvents cmdOneTimeVessel As Button
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents lblCostCentre As Label
    Friend WithEvents cmbCostCentre As ComboBox
    Friend WithEvents cmdPNRWrite As Button
    Friend WithEvents lblSegs As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents lblReasonForTravel As Label
    Friend WithEvents lblPax As Label
    Friend WithEvents cmbReasonForTravel As ComboBox
    Friend WithEvents lblSubDepartment As Label
    Friend WithEvents lblPNR As Label
    Friend WithEvents lblCRM As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents lstVessels As ListBox
    Friend WithEvents lblVessel As Label
    Friend WithEvents lblBookedBy As Label
    Friend WithEvents lstCustomers As ListBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblReference As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents cmbBookedby As ComboBox
    Friend WithEvents txtReference As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SSGDS As ToolStripStatusLabel
    Friend WithEvents SSPCC As ToolStripStatusLabel
    Friend WithEvents SSUser As ToolStripStatusLabel
    Friend WithEvents optClientATH As RadioButton
    Friend WithEvents optClientQLI As RadioButton
    Friend WithEvents tabCustomProperties As TableLayoutPanel
    Friend WithEvents cmbCRM As ComboBox
    Friend WithEvents cmbSubDepartment As ComboBox
    Friend WithEvents tstrRead As ToolStrip
    Friend WithEvents cmdTSReadAmadeus As ToolStripButton
    Friend WithEvents cmdTSReadGalileo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents cmdTSWritePNR As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdTSWritePNRwithDocs As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmdTSWriteOnlyDOCS As ToolStripButton
    Friend WithEvents lblWarning As Label
    Friend WithEvents tmrWarning As Timer
    Friend WithEvents grpGDSEntries As GroupBox
End Class
