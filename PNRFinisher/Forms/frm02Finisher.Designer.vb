<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm02Finisher
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
        Me.lblCTC = New System.Windows.Forms.Label()
        Me.cmdCTCForm = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPNRApis = New System.Windows.Forms.TextBox()
        Me.cmdAPISEditPax = New System.Windows.Forms.Button()
        Me.cmdPNRRead1GATH = New System.Windows.Forms.Button()
        Me.cmdPNROnlyDocs = New System.Windows.Forms.Button()
        Me.cmdPNRWriteWithDocs = New System.Windows.Forms.Button()
        Me.lblSSRDocs = New System.Windows.Forms.Label()
        Me.dgvApis = New System.Windows.Forms.DataGridView()
        Me.cmdItineraryHelper = New System.Windows.Forms.Button()
        Me.cmdClientGroupCostCentreLookup = New System.Windows.Forms.Button()
        Me.cmdPNRRead1AATH = New System.Windows.Forms.Button()
        Me.cmdOneTimeVessel = New System.Windows.Forms.Button()
        Me.txtSubdepartment = New System.Windows.Forms.TextBox()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.cmdPNRWrite = New System.Windows.Forms.Button()
        Me.lstCRM = New System.Windows.Forms.ListBox()
        Me.lblSegs = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.txtCRM = New System.Windows.Forms.TextBox()
        Me.lblPax = New System.Windows.Forms.Label()
        Me.lstSubDepartments = New System.Windows.Forms.ListBox()
        Me.lblSubDepartment = New System.Windows.Forms.Label()
        Me.lblPNR = New System.Windows.Forms.Label()
        Me.lblCRM = New System.Windows.Forms.Label()
        Me.lstVessels = New System.Windows.Forms.ListBox()
        Me.lblVessel = New System.Windows.Forms.Label()
        Me.lstClient = New System.Windows.Forms.ListBox()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.lblAirlinePoints = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SSGDS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSPCC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chkAddOtherOfficeEntries = New System.Windows.Forms.CheckBox()
        Me.UcRef8 = New PNRFinisher.UCRef()
        Me.UcRef7 = New PNRFinisher.UCRef()
        Me.UcRef6 = New PNRFinisher.UCRef()
        Me.UcRef5 = New PNRFinisher.UCRef()
        Me.UcRef4 = New PNRFinisher.UCRef()
        Me.UcRef3 = New PNRFinisher.UCRef()
        Me.UcRef2 = New PNRFinisher.UCRef()
        Me.UcRef1 = New PNRFinisher.UCRef()
        Me.UcRef9 = New PNRFinisher.UCRef()
        Me.lstGDSElements = New System.Windows.Forms.ListBox()
        Me.cmdPNRRead1AQLI = New System.Windows.Forms.Button()
        Me.cmdPNRRead1GQLI = New System.Windows.Forms.Button()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCTC
        '
        Me.lblCTC.BackColor = System.Drawing.Color.Yellow
        Me.lblCTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCTC.Location = New System.Drawing.Point(987, 61)
        Me.lblCTC.Name = "lblCTC"
        Me.lblCTC.Size = New System.Drawing.Size(91, 39)
        Me.lblCTC.TabIndex = 102
        Me.lblCTC.Text = "CTC"
        Me.lblCTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCTCForm
        '
        Me.cmdCTCForm.Location = New System.Drawing.Point(1084, 61)
        Me.cmdCTCForm.Name = "cmdCTCForm"
        Me.cmdCTCForm.Size = New System.Drawing.Size(116, 39)
        Me.cmdCTCForm.TabIndex = 101
        Me.cmdCTCForm.Text = "Passenger Contact Information (CTC)"
        Me.cmdCTCForm.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(172, 419)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 29)
        Me.Button1.TabIndex = 100
        Me.Button1.Text = "Edit Pax CTC"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPNRApis
        '
        Me.txtPNRApis.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtPNRApis.Location = New System.Drawing.Point(1390, 454)
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
        Me.cmdAPISEditPax.Location = New System.Drawing.Point(12, 419)
        Me.cmdAPISEditPax.Name = "cmdAPISEditPax"
        Me.cmdAPISEditPax.Size = New System.Drawing.Size(154, 29)
        Me.cmdAPISEditPax.TabIndex = 84
        Me.cmdAPISEditPax.Text = "Edit Pax SSRDOCS"
        Me.cmdAPISEditPax.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1GATH
        '
        Me.cmdPNRRead1GATH.Location = New System.Drawing.Point(258, 11)
        Me.cmdPNRRead1GATH.Name = "cmdPNRRead1GATH"
        Me.cmdPNRRead1GATH.Size = New System.Drawing.Size(116, 35)
        Me.cmdPNRRead1GATH.TabIndex = 55
        Me.cmdPNRRead1GATH.Text = "Galileo ATH client"
        Me.cmdPNRRead1GATH.UseVisualStyleBackColor = True
        '
        'cmdPNROnlyDocs
        '
        Me.cmdPNROnlyDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNROnlyDocs.Location = New System.Drawing.Point(1057, 11)
        Me.cmdPNROnlyDocs.Name = "cmdPNROnlyDocs"
        Me.cmdPNROnlyDocs.Size = New System.Drawing.Size(115, 35)
        Me.cmdPNROnlyDocs.TabIndex = 89
        Me.cmdPNROnlyDocs.Text = "Only DOCS"
        Me.cmdPNROnlyDocs.UseVisualStyleBackColor = True
        '
        'cmdPNRWriteWithDocs
        '
        Me.cmdPNRWriteWithDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWriteWithDocs.Location = New System.Drawing.Point(824, 11)
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
        Me.lblSSRDocs.Location = New System.Drawing.Point(332, 419)
        Me.lblSSRDocs.Name = "lblSSRDocs"
        Me.lblSSRDocs.Size = New System.Drawing.Size(999, 29)
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
        Me.dgvApis.Location = New System.Drawing.Point(12, 454)
        Me.dgvApis.Name = "dgvApis"
        Me.dgvApis.Size = New System.Drawing.Size(1319, 130)
        Me.dgvApis.TabIndex = 86
        '
        'cmdItineraryHelper
        '
        Me.cmdItineraryHelper.Location = New System.Drawing.Point(1206, 61)
        Me.cmdItineraryHelper.Name = "cmdItineraryHelper"
        Me.cmdItineraryHelper.Size = New System.Drawing.Size(125, 39)
        Me.cmdItineraryHelper.TabIndex = 94
        Me.cmdItineraryHelper.Text = "Itinerary Helper"
        Me.cmdItineraryHelper.UseVisualStyleBackColor = True
        '
        'cmdClientGroupCostCentreLookup
        '
        Me.cmdClientGroupCostCentreLookup.Location = New System.Drawing.Point(504, 11)
        Me.cmdClientGroupCostCentreLookup.Name = "cmdClientGroupCostCentreLookup"
        Me.cmdClientGroupCostCentreLookup.Size = New System.Drawing.Size(133, 35)
        Me.cmdClientGroupCostCentreLookup.TabIndex = 56
        Me.cmdClientGroupCostCentreLookup.Text = "Client Group Cost Centre Lookup"
        Me.cmdClientGroupCostCentreLookup.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1AATH
        '
        Me.cmdPNRRead1AATH.Location = New System.Drawing.Point(12, 11)
        Me.cmdPNRRead1AATH.Name = "cmdPNRRead1AATH"
        Me.cmdPNRRead1AATH.Size = New System.Drawing.Size(116, 35)
        Me.cmdPNRRead1AATH.TabIndex = 54
        Me.cmdPNRRead1AATH.Text = "Amadeus ATH client"
        Me.cmdPNRRead1AATH.UseVisualStyleBackColor = True
        '
        'cmdOneTimeVessel
        '
        Me.cmdOneTimeVessel.Location = New System.Drawing.Point(12, 382)
        Me.cmdOneTimeVessel.Name = "cmdOneTimeVessel"
        Me.cmdOneTimeVessel.Size = New System.Drawing.Size(277, 28)
        Me.cmdOneTimeVessel.TabIndex = 57
        Me.cmdOneTimeVessel.Text = "One time Vessel for PNR"
        Me.cmdOneTimeVessel.UseVisualStyleBackColor = True
        '
        'txtSubdepartment
        '
        Me.txtSubdepartment.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSubdepartment.Location = New System.Drawing.Point(301, 67)
        Me.txtSubdepartment.Name = "txtSubdepartment"
        Me.txtSubdepartment.Size = New System.Drawing.Size(337, 20)
        Me.txtSubdepartment.TabIndex = 62
        '
        'txtClient
        '
        Me.txtClient.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtClient.Location = New System.Drawing.Point(12, 70)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Size = New System.Drawing.Size(277, 20)
        Me.txtClient.TabIndex = 59
        '
        'cmdPNRWrite
        '
        Me.cmdPNRWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWrite.Location = New System.Drawing.Point(675, 11)
        Me.cmdPNRWrite.Name = "cmdPNRWrite"
        Me.cmdPNRWrite.Size = New System.Drawing.Size(141, 35)
        Me.cmdPNRWrite.TabIndex = 87
        Me.cmdPNRWrite.Text = "Write to PNR"
        Me.cmdPNRWrite.UseVisualStyleBackColor = True
        '
        'lstCRM
        '
        Me.lstCRM.FormattingEnabled = True
        Me.lstCRM.Location = New System.Drawing.Point(301, 163)
        Me.lstCRM.Name = "lstCRM"
        Me.lstCRM.Size = New System.Drawing.Size(337, 30)
        Me.lstCRM.TabIndex = 66
        '
        'lblSegs
        '
        Me.lblSegs.BackColor = System.Drawing.Color.Coral
        Me.lblSegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSegs.Location = New System.Drawing.Point(675, 87)
        Me.lblSegs.Name = "lblSegs"
        Me.lblSegs.Size = New System.Drawing.Size(306, 13)
        Me.lblSegs.TabIndex = 93
        Me.lblSegs.Text = "."
        Me.lblSegs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtVessel.Location = New System.Drawing.Point(12, 241)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(277, 20)
        Me.txtVessel.TabIndex = 68
        '
        'txtCRM
        '
        Me.txtCRM.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCRM.Location = New System.Drawing.Point(301, 143)
        Me.txtCRM.Name = "txtCRM"
        Me.txtCRM.Size = New System.Drawing.Size(337, 20)
        Me.txtCRM.TabIndex = 65
        '
        'lblPax
        '
        Me.lblPax.BackColor = System.Drawing.Color.Coral
        Me.lblPax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPax.Location = New System.Drawing.Point(675, 74)
        Me.lblPax.Name = "lblPax"
        Me.lblPax.Size = New System.Drawing.Size(306, 13)
        Me.lblPax.TabIndex = 92
        Me.lblPax.Text = "."
        Me.lblPax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstSubDepartments
        '
        Me.lstSubDepartments.FormattingEnabled = True
        Me.lstSubDepartments.Location = New System.Drawing.Point(301, 87)
        Me.lstSubDepartments.Name = "lstSubDepartments"
        Me.lstSubDepartments.Size = New System.Drawing.Size(337, 43)
        Me.lstSubDepartments.TabIndex = 63
        '
        'lblSubDepartment
        '
        Me.lblSubDepartment.BackColor = System.Drawing.Color.Yellow
        Me.lblSubDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSubDepartment.Location = New System.Drawing.Point(301, 54)
        Me.lblSubDepartment.Name = "lblSubDepartment"
        Me.lblSubDepartment.Size = New System.Drawing.Size(337, 13)
        Me.lblSubDepartment.TabIndex = 61
        Me.lblSubDepartment.Text = "SubDepartment"
        Me.lblSubDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPNR
        '
        Me.lblPNR.BackColor = System.Drawing.Color.Coral
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.Location = New System.Drawing.Point(675, 61)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.Size = New System.Drawing.Size(306, 13)
        Me.lblPNR.TabIndex = 91
        Me.lblPNR.Text = "."
        Me.lblPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCRM
        '
        Me.lblCRM.BackColor = System.Drawing.Color.Yellow
        Me.lblCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCRM.Location = New System.Drawing.Point(301, 130)
        Me.lblCRM.Name = "lblCRM"
        Me.lblCRM.Size = New System.Drawing.Size(337, 13)
        Me.lblCRM.TabIndex = 64
        Me.lblCRM.Text = "CRM - Invoicing Addresses"
        Me.lblCRM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstVessels
        '
        Me.lstVessels.FormattingEnabled = True
        Me.lstVessels.Location = New System.Drawing.Point(12, 261)
        Me.lstVessels.Name = "lstVessels"
        Me.lstVessels.Size = New System.Drawing.Size(277, 121)
        Me.lstVessels.TabIndex = 69
        '
        'lblVessel
        '
        Me.lblVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(12, 228)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(277, 13)
        Me.lblVessel.TabIndex = 67
        Me.lblVessel.Text = "Vessel"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstClient
        '
        Me.lstClient.FormattingEnabled = True
        Me.lstClient.Location = New System.Drawing.Point(12, 90)
        Me.lstClient.Name = "lstClient"
        Me.lstClient.Size = New System.Drawing.Size(277, 121)
        Me.lstClient.TabIndex = 60
        '
        'lblClient
        '
        Me.lblClient.BackColor = System.Drawing.Color.Yellow
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblClient.Location = New System.Drawing.Point(12, 53)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(277, 17)
        Me.lblClient.TabIndex = 58
        Me.lblClient.Text = "Client"
        Me.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAirlinePoints
        '
        Me.lblAirlinePoints.BackColor = System.Drawing.Color.Silver
        Me.lblAirlinePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAirlinePoints.Location = New System.Drawing.Point(675, 105)
        Me.lblAirlinePoints.Name = "lblAirlinePoints"
        Me.lblAirlinePoints.Size = New System.Drawing.Size(656, 28)
        Me.lblAirlinePoints.TabIndex = 82
        Me.lblAirlinePoints.Text = "GDS Elements"
        Me.lblAirlinePoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SSGDS, Me.SSPCC, Me.SSUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1472, 22)
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
        'chkAddOtherOfficeEntries
        '
        Me.chkAddOtherOfficeEntries.AutoSize = True
        Me.chkAddOtherOfficeEntries.Location = New System.Drawing.Point(12, 211)
        Me.chkAddOtherOfficeEntries.Name = "chkAddOtherOfficeEntries"
        Me.chkAddOtherOfficeEntries.Size = New System.Drawing.Size(135, 17)
        Me.chkAddOtherOfficeEntries.TabIndex = 106
        Me.chkAddOtherOfficeEntries.Text = "Add other office entries"
        Me.chkAddOtherOfficeEntries.UseVisualStyleBackColor = True
        '
        'UcRef8
        '
        Me.UcRef8.ClientRefItem = Nothing
        Me.UcRef8.Location = New System.Drawing.Point(297, 366)
        Me.UcRef8.Name = "UcRef8"
        Me.UcRef8.Size = New System.Drawing.Size(372, 22)
        Me.UcRef8.TabIndex = 115
        '
        'UcRef7
        '
        Me.UcRef7.ClientRefItem = Nothing
        Me.UcRef7.Location = New System.Drawing.Point(297, 344)
        Me.UcRef7.Name = "UcRef7"
        Me.UcRef7.Size = New System.Drawing.Size(372, 22)
        Me.UcRef7.TabIndex = 114
        '
        'UcRef6
        '
        Me.UcRef6.ClientRefItem = Nothing
        Me.UcRef6.Location = New System.Drawing.Point(297, 322)
        Me.UcRef6.Name = "UcRef6"
        Me.UcRef6.Size = New System.Drawing.Size(372, 22)
        Me.UcRef6.TabIndex = 113
        '
        'UcRef5
        '
        Me.UcRef5.ClientRefItem = Nothing
        Me.UcRef5.Location = New System.Drawing.Point(297, 300)
        Me.UcRef5.Name = "UcRef5"
        Me.UcRef5.Size = New System.Drawing.Size(372, 22)
        Me.UcRef5.TabIndex = 112
        '
        'UcRef4
        '
        Me.UcRef4.ClientRefItem = Nothing
        Me.UcRef4.Location = New System.Drawing.Point(297, 278)
        Me.UcRef4.Name = "UcRef4"
        Me.UcRef4.Size = New System.Drawing.Size(372, 22)
        Me.UcRef4.TabIndex = 111
        '
        'UcRef3
        '
        Me.UcRef3.ClientRefItem = Nothing
        Me.UcRef3.Location = New System.Drawing.Point(297, 256)
        Me.UcRef3.Name = "UcRef3"
        Me.UcRef3.Size = New System.Drawing.Size(372, 22)
        Me.UcRef3.TabIndex = 110
        '
        'UcRef2
        '
        Me.UcRef2.ClientRefItem = Nothing
        Me.UcRef2.Location = New System.Drawing.Point(297, 234)
        Me.UcRef2.Name = "UcRef2"
        Me.UcRef2.Size = New System.Drawing.Size(372, 22)
        Me.UcRef2.TabIndex = 109
        '
        'UcRef1
        '
        Me.UcRef1.ClientRefItem = Nothing
        Me.UcRef1.Location = New System.Drawing.Point(297, 212)
        Me.UcRef1.Name = "UcRef1"
        Me.UcRef1.Size = New System.Drawing.Size(372, 22)
        Me.UcRef1.TabIndex = 108
        '
        'UcRef9
        '
        Me.UcRef9.ClientRefItem = Nothing
        Me.UcRef9.Location = New System.Drawing.Point(297, 388)
        Me.UcRef9.Name = "UcRef9"
        Me.UcRef9.Size = New System.Drawing.Size(372, 22)
        Me.UcRef9.TabIndex = 116
        '
        'lstGDSElements
        '
        Me.lstGDSElements.BackColor = System.Drawing.Color.Aqua
        Me.lstGDSElements.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGDSElements.ForeColor = System.Drawing.Color.Blue
        Me.lstGDSElements.FormattingEnabled = True
        Me.lstGDSElements.ItemHeight = 14
        Me.lstGDSElements.Location = New System.Drawing.Point(675, 133)
        Me.lstGDSElements.Name = "lstGDSElements"
        Me.lstGDSElements.Size = New System.Drawing.Size(656, 270)
        Me.lstGDSElements.TabIndex = 117
        '
        'cmdPNRRead1AQLI
        '
        Me.cmdPNRRead1AQLI.Location = New System.Drawing.Point(135, 11)
        Me.cmdPNRRead1AQLI.Name = "cmdPNRRead1AQLI"
        Me.cmdPNRRead1AQLI.Size = New System.Drawing.Size(116, 35)
        Me.cmdPNRRead1AQLI.TabIndex = 118
        Me.cmdPNRRead1AQLI.Text = "Amadeus QLI client"
        Me.cmdPNRRead1AQLI.UseVisualStyleBackColor = True
        '
        'cmdPNRRead1GQLI
        '
        Me.cmdPNRRead1GQLI.Location = New System.Drawing.Point(381, 11)
        Me.cmdPNRRead1GQLI.Name = "cmdPNRRead1GQLI"
        Me.cmdPNRRead1GQLI.Size = New System.Drawing.Size(116, 35)
        Me.cmdPNRRead1GQLI.TabIndex = 119
        Me.cmdPNRRead1GQLI.Text = "Galileo QLI client"
        Me.cmdPNRRead1GQLI.UseVisualStyleBackColor = True
        '
        'frm02Finisher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 626)
        Me.Controls.Add(Me.cmdPNRRead1GQLI)
        Me.Controls.Add(Me.cmdPNRRead1AQLI)
        Me.Controls.Add(Me.lstGDSElements)
        Me.Controls.Add(Me.UcRef9)
        Me.Controls.Add(Me.UcRef8)
        Me.Controls.Add(Me.UcRef7)
        Me.Controls.Add(Me.UcRef6)
        Me.Controls.Add(Me.UcRef5)
        Me.Controls.Add(Me.UcRef4)
        Me.Controls.Add(Me.UcRef3)
        Me.Controls.Add(Me.UcRef2)
        Me.Controls.Add(Me.UcRef1)
        Me.Controls.Add(Me.chkAddOtherOfficeEntries)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblCTC)
        Me.Controls.Add(Me.cmdCTCForm)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPNRApis)
        Me.Controls.Add(Me.cmdAPISEditPax)
        Me.Controls.Add(Me.cmdPNRRead1GATH)
        Me.Controls.Add(Me.cmdPNROnlyDocs)
        Me.Controls.Add(Me.cmdPNRWriteWithDocs)
        Me.Controls.Add(Me.lblSSRDocs)
        Me.Controls.Add(Me.dgvApis)
        Me.Controls.Add(Me.cmdItineraryHelper)
        Me.Controls.Add(Me.cmdClientGroupCostCentreLookup)
        Me.Controls.Add(Me.cmdPNRRead1AATH)
        Me.Controls.Add(Me.cmdOneTimeVessel)
        Me.Controls.Add(Me.txtSubdepartment)
        Me.Controls.Add(Me.txtClient)
        Me.Controls.Add(Me.cmdPNRWrite)
        Me.Controls.Add(Me.lstCRM)
        Me.Controls.Add(Me.lblSegs)
        Me.Controls.Add(Me.txtVessel)
        Me.Controls.Add(Me.txtCRM)
        Me.Controls.Add(Me.lblPax)
        Me.Controls.Add(Me.lstSubDepartments)
        Me.Controls.Add(Me.lblSubDepartment)
        Me.Controls.Add(Me.lblPNR)
        Me.Controls.Add(Me.lblCRM)
        Me.Controls.Add(Me.lstVessels)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.lstClient)
        Me.Controls.Add(Me.lblClient)
        Me.Controls.Add(Me.lblAirlinePoints)
        Me.Name = "frm02Finisher"
        Me.Text = "Finisher"
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCTC As Label
    Friend WithEvents cmdCTCForm As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtPNRApis As TextBox
    Friend WithEvents cmdAPISEditPax As Button
    Friend WithEvents cmdPNRRead1GATH As Button
    Friend WithEvents cmdPNROnlyDocs As Button
    Friend WithEvents cmdPNRWriteWithDocs As Button
    Friend WithEvents lblSSRDocs As Label
    Friend WithEvents dgvApis As DataGridView
    Friend WithEvents cmdItineraryHelper As Button
    Friend WithEvents cmdClientGroupCostCentreLookup As Button
    Friend WithEvents cmdPNRRead1AATH As Button
    Friend WithEvents cmdOneTimeVessel As Button
    Friend WithEvents txtSubdepartment As TextBox
    Friend WithEvents txtClient As TextBox
    Friend WithEvents cmdPNRWrite As Button
    Friend WithEvents lstCRM As ListBox
    Friend WithEvents lblSegs As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents txtCRM As TextBox
    Friend WithEvents lblPax As Label
    Friend WithEvents lstSubDepartments As ListBox
    Friend WithEvents lblSubDepartment As Label
    Friend WithEvents lblPNR As Label
    Friend WithEvents lblCRM As Label
    Friend WithEvents lstVessels As ListBox
    Friend WithEvents lblVessel As Label
    Friend WithEvents lstClient As ListBox
    Friend WithEvents lblClient As Label
    Friend WithEvents lblAirlinePoints As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SSGDS As ToolStripStatusLabel
    Friend WithEvents SSPCC As ToolStripStatusLabel
    Friend WithEvents SSUser As ToolStripStatusLabel
    Friend WithEvents chkAddOtherOfficeEntries As CheckBox
    Friend WithEvents UcRef1 As UCRef
    Friend WithEvents UcRef2 As UCRef
    Friend WithEvents UcRef3 As UCRef
    Friend WithEvents UcRef4 As UCRef
    Friend WithEvents UcRef5 As UCRef
    Friend WithEvents UcRef6 As UCRef
    Friend WithEvents UcRef7 As UCRef
    Friend WithEvents UcRef8 As UCRef
    Friend WithEvents UcRef9 As UCRef
    Friend WithEvents lstGDSElements As ListBox
    Friend WithEvents cmdPNRRead1AQLI As Button
    Friend WithEvents cmdPNRRead1GQLI As Button
End Class
