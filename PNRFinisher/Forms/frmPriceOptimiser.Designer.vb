<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPriceOptimiser
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
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.lblPCCUser = New System.Windows.Forms.Label()
        Me.mnuOptimiserCopyData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOptimiserOpenInGDS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOptimiserActioned = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptimiserIgnore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOptimiserPNR = New System.Windows.Forms.ToolStripTextBox()
        Me.mnuOptimiser = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.dgvPNRs = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAmadeusLastChecked = New System.Windows.Forms.TextBox()
        Me.txtGalileoLastChecked = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTimeNow = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGalileoMIRfile = New System.Windows.Forms.TextBox()
        Me.txtAmadeusAIRfile = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mnuOptimiser.SuspendLayout()
        CType(Me.dgvPNRs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 21)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(117, 34)
        Me.cmdRefresh.TabIndex = 12
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'lblPCCUser
        '
        Me.lblPCCUser.AutoSize = True
        Me.lblPCCUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCCUser.Location = New System.Drawing.Point(295, 42)
        Me.lblPCCUser.Name = "lblPCCUser"
        Me.lblPCCUser.Size = New System.Drawing.Size(178, 13)
        Me.lblPCCUser.TabIndex = 11
        Me.lblPCCUser.Text = "These PNRs can be optimised"
        '
        'mnuOptimiserCopyData
        '
        Me.mnuOptimiserCopyData.Name = "mnuOptimiserCopyData"
        Me.mnuOptimiserCopyData.Size = New System.Drawing.Size(260, 22)
        Me.mnuOptimiserCopyData.Text = "Copy data"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(257, 6)
        '
        'mnuOptimiserOpenInGDS
        '
        Me.mnuOptimiserOpenInGDS.Name = "mnuOptimiserOpenInGDS"
        Me.mnuOptimiserOpenInGDS.Size = New System.Drawing.Size(260, 22)
        Me.mnuOptimiserOpenInGDS.Text = "Open in GDS"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(257, 6)
        '
        'mnuOptimiserActioned
        '
        Me.mnuOptimiserActioned.Name = "mnuOptimiserActioned"
        Me.mnuOptimiserActioned.Size = New System.Drawing.Size(260, 22)
        Me.mnuOptimiserActioned.Text = "Actioned"
        '
        'mnuOptimiserIgnore
        '
        Me.mnuOptimiserIgnore.Name = "mnuOptimiserIgnore"
        Me.mnuOptimiserIgnore.Size = New System.Drawing.Size(260, 22)
        Me.mnuOptimiserIgnore.Text = "Ignore"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(257, 6)
        '
        'mnuOptimiserPNR
        '
        Me.mnuOptimiserPNR.Enabled = False
        Me.mnuOptimiserPNR.Name = "mnuOptimiserPNR"
        Me.mnuOptimiserPNR.Size = New System.Drawing.Size(200, 23)
        '
        'mnuOptimiser
        '
        Me.mnuOptimiser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptimiserPNR, Me.ToolStripSeparator1, Me.mnuOptimiserIgnore, Me.mnuOptimiserActioned, Me.ToolStripMenuItem1, Me.mnuOptimiserOpenInGDS, Me.ToolStripSeparator2, Me.mnuOptimiserCopyData})
        Me.mnuOptimiser.Name = "mnuOptimiser"
        Me.mnuOptimiser.Size = New System.Drawing.Size(261, 135)
        '
        'dgvPNRs
        '
        Me.dgvPNRs.AllowUserToAddRows = False
        Me.dgvPNRs.AllowUserToDeleteRows = False
        Me.dgvPNRs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPNRs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPNRs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPNRs.ContextMenuStrip = Me.mnuOptimiser
        Me.dgvPNRs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPNRs.Location = New System.Drawing.Point(12, 82)
        Me.dgvPNRs.MultiSelect = False
        Me.dgvPNRs.Name = "dgvPNRs"
        Me.dgvPNRs.ReadOnly = True
        Me.dgvPNRs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPNRs.ShowEditingIcon = False
        Me.dgvPNRs.Size = New System.Drawing.Size(1450, 253)
        Me.dgvPNRs.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(295, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "These PNRs can be optimised"
        '
        'txtAmadeusLastChecked
        '
        Me.txtAmadeusLastChecked.Location = New System.Drawing.Point(755, 36)
        Me.txtAmadeusLastChecked.Name = "txtAmadeusLastChecked"
        Me.txtAmadeusLastChecked.Size = New System.Drawing.Size(246, 20)
        Me.txtAmadeusLastChecked.TabIndex = 18
        '
        'txtGalileoLastChecked
        '
        Me.txtGalileoLastChecked.Location = New System.Drawing.Point(755, 56)
        Me.txtGalileoLastChecked.Name = "txtGalileoLastChecked"
        Me.txtGalileoLastChecked.Size = New System.Drawing.Size(246, 20)
        Me.txtGalileoLastChecked.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(610, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Amadeus last checked"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(610, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Galileo last checked"
        '
        'lblTimeNow
        '
        Me.lblTimeNow.BackColor = System.Drawing.Color.Aqua
        Me.lblTimeNow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeNow.Location = New System.Drawing.Point(610, 10)
        Me.lblTimeNow.Name = "lblTimeNow"
        Me.lblTimeNow.Size = New System.Drawing.Size(785, 13)
        Me.lblTimeNow.TabIndex = 23
        Me.lblTimeNow.Text = "Time now"
        Me.lblTimeNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1013, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Latest Galileo MIR file"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1013, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Latest Amadeus AIR file"
        '
        'txtGalileoMIRfile
        '
        Me.txtGalileoMIRfile.Location = New System.Drawing.Point(1149, 56)
        Me.txtGalileoMIRfile.Name = "txtGalileoMIRfile"
        Me.txtGalileoMIRfile.Size = New System.Drawing.Size(246, 20)
        Me.txtGalileoMIRfile.TabIndex = 25
        '
        'txtAmadeusAIRfile
        '
        Me.txtAmadeusAIRfile.Location = New System.Drawing.Point(1149, 36)
        Me.txtAmadeusAIRfile.Name = "txtAmadeusAIRfile"
        Me.txtAmadeusAIRfile.Size = New System.Drawing.Size(246, 20)
        Me.txtAmadeusAIRfile.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(1013, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(382, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Travel Force GDS Import Check"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(610, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(391, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Price Optimization"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPriceOptimiser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1474, 342)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtGalileoMIRfile)
        Me.Controls.Add(Me.txtAmadeusAIRfile)
        Me.Controls.Add(Me.lblTimeNow)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGalileoLastChecked)
        Me.Controls.Add(Me.txtAmadeusLastChecked)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.lblPCCUser)
        Me.Controls.Add(Me.dgvPNRs)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPriceOptimiser"
        Me.Text = "Price Optimisation"
        Me.mnuOptimiser.ResumeLayout(False)
        Me.mnuOptimiser.PerformLayout()
        CType(Me.dgvPNRs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents lblPCCUser As Label
    Friend WithEvents mnuOptimiserCopyData As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuOptimiserOpenInGDS As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuOptimiserActioned As ToolStripMenuItem
    Friend WithEvents mnuOptimiserIgnore As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuOptimiserPNR As ToolStripTextBox
    Friend WithEvents mnuOptimiser As ContextMenuStrip
    Friend WithEvents dgvPNRs As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAmadeusLastChecked As TextBox
    Friend WithEvents txtGalileoLastChecked As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTimeNow As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtGalileoMIRfile As TextBox
    Friend WithEvents txtAmadeusAIRfile As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
