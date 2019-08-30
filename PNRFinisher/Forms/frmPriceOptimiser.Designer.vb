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
        Me.cmdBottomRight = New System.Windows.Forms.Button()
        Me.cmdBottomLeft = New System.Windows.Forms.Button()
        Me.cmdTopLeft = New System.Windows.Forms.Button()
        Me.cmdMinMax = New System.Windows.Forms.Button()
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
        Me.cmdTopRight = New System.Windows.Forms.Button()
        Me.dgvPNRs = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAmadeusLastChecked = New System.Windows.Forms.TextBox()
        Me.txtGalileoLastChecked = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTimeChecked = New System.Windows.Forms.TextBox()
        Me.mnuOptimiser.SuspendLayout()
        CType(Me.dgvPNRs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdBottomRight
        '
        Me.cmdBottomRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBottomRight.Location = New System.Drawing.Point(72, 54)
        Me.cmdBottomRight.Name = "cmdBottomRight"
        Me.cmdBottomRight.Size = New System.Drawing.Size(58, 13)
        Me.cmdBottomRight.TabIndex = 17
        Me.cmdBottomRight.UseVisualStyleBackColor = True
        '
        'cmdBottomLeft
        '
        Me.cmdBottomLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBottomLeft.Location = New System.Drawing.Point(13, 54)
        Me.cmdBottomLeft.Name = "cmdBottomLeft"
        Me.cmdBottomLeft.Size = New System.Drawing.Size(58, 13)
        Me.cmdBottomLeft.TabIndex = 15
        Me.cmdBottomLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdBottomLeft.UseVisualStyleBackColor = True
        '
        'cmdTopLeft
        '
        Me.cmdTopLeft.Location = New System.Drawing.Point(13, 7)
        Me.cmdTopLeft.Name = "cmdTopLeft"
        Me.cmdTopLeft.Size = New System.Drawing.Size(58, 13)
        Me.cmdTopLeft.TabIndex = 14
        Me.cmdTopLeft.UseVisualStyleBackColor = True
        '
        'cmdMinMax
        '
        Me.cmdMinMax.Location = New System.Drawing.Point(13, 20)
        Me.cmdMinMax.Name = "cmdMinMax"
        Me.cmdMinMax.Size = New System.Drawing.Size(117, 34)
        Me.cmdMinMax.TabIndex = 13
        Me.cmdMinMax.Text = "Expand"
        Me.cmdMinMax.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(163, 21)
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
        'cmdTopRight
        '
        Me.cmdTopRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTopRight.Location = New System.Drawing.Point(72, 7)
        Me.cmdTopRight.Name = "cmdTopRight"
        Me.cmdTopRight.Size = New System.Drawing.Size(58, 13)
        Me.cmdTopRight.TabIndex = 16
        Me.cmdTopRight.UseVisualStyleBackColor = True
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
        Me.dgvPNRs.Location = New System.Drawing.Point(12, 75)
        Me.dgvPNRs.MultiSelect = False
        Me.dgvPNRs.Name = "dgvPNRs"
        Me.dgvPNRs.ReadOnly = True
        Me.dgvPNRs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPNRs.ShowEditingIcon = False
        Me.dgvPNRs.Size = New System.Drawing.Size(1450, 260)
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
        Me.txtAmadeusLastChecked.Location = New System.Drawing.Point(755, 26)
        Me.txtAmadeusLastChecked.Name = "txtAmadeusLastChecked"
        Me.txtAmadeusLastChecked.Size = New System.Drawing.Size(246, 20)
        Me.txtAmadeusLastChecked.TabIndex = 18
        '
        'txtGalileoLastChecked
        '
        Me.txtGalileoLastChecked.Location = New System.Drawing.Point(755, 46)
        Me.txtGalileoLastChecked.Name = "txtGalileoLastChecked"
        Me.txtGalileoLastChecked.Size = New System.Drawing.Size(246, 20)
        Me.txtGalileoLastChecked.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(610, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Amadeus last checked"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(610, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Galileo last checked"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(610, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Time now"
        '
        'txtTimeChecked
        '
        Me.txtTimeChecked.Location = New System.Drawing.Point(755, 6)
        Me.txtTimeChecked.Name = "txtTimeChecked"
        Me.txtTimeChecked.Size = New System.Drawing.Size(246, 20)
        Me.txtTimeChecked.TabIndex = 22
        '
        'frmPriceOptimiser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1474, 342)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTimeChecked)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGalileoLastChecked)
        Me.Controls.Add(Me.txtAmadeusLastChecked)
        Me.Controls.Add(Me.cmdBottomRight)
        Me.Controls.Add(Me.cmdBottomLeft)
        Me.Controls.Add(Me.cmdTopLeft)
        Me.Controls.Add(Me.cmdMinMax)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.lblPCCUser)
        Me.Controls.Add(Me.cmdTopRight)
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

    Friend WithEvents cmdBottomRight As Button
    Friend WithEvents cmdBottomLeft As Button
    Friend WithEvents cmdTopLeft As Button
    Friend WithEvents cmdMinMax As Button
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
    Friend WithEvents cmdTopRight As Button
    Friend WithEvents dgvPNRs As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAmadeusLastChecked As TextBox
    Friend WithEvents txtGalileoLastChecked As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTimeChecked As TextBox
End Class
