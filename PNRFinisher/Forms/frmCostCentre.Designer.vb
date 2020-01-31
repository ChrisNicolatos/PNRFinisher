<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostCentre
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvCostCentres = New System.Windows.Forms.DataGridView()
        Me.mnuCostCentre = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCostCentreExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstClientGroup = New System.Windows.Forms.ListBox()
        Me.lstClients = New System.Windows.Forms.ListBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtClientGroup = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdAccept = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        CType(Me.dgvCostCentres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuCostCentre.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCostCentres
        '
        Me.dgvCostCentres.AllowUserToAddRows = False
        Me.dgvCostCentres.AllowUserToDeleteRows = False
        Me.dgvCostCentres.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCostCentres.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCostCentres.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCostCentres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCostCentres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCostCentres.ContextMenuStrip = Me.mnuCostCentre
        Me.dgvCostCentres.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCostCentres.Location = New System.Drawing.Point(18, 209)
        Me.dgvCostCentres.MultiSelect = False
        Me.dgvCostCentres.Name = "dgvCostCentres"
        Me.dgvCostCentres.Size = New System.Drawing.Size(709, 244)
        Me.dgvCostCentres.TabIndex = 19
        '
        'mnuCostCentre
        '
        Me.mnuCostCentre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCostCentreExport})
        Me.mnuCostCentre.Name = "mnuCostCentre"
        Me.mnuCostCentre.Size = New System.Drawing.Size(108, 26)
        '
        'mnuCostCentreExport
        '
        Me.mnuCostCentreExport.Name = "mnuCostCentreExport"
        Me.mnuCostCentreExport.Size = New System.Drawing.Size(107, 22)
        Me.mnuCostCentreExport.Text = "Export"
        '
        'lstClientGroup
        '
        Me.lstClientGroup.FormattingEnabled = True
        Me.lstClientGroup.Location = New System.Drawing.Point(393, 43)
        Me.lstClientGroup.Name = "lstClientGroup"
        Me.lstClientGroup.Size = New System.Drawing.Size(337, 134)
        Me.lstClientGroup.TabIndex = 16
        '
        'lstClients
        '
        Me.lstClients.FormattingEnabled = True
        Me.lstClients.Location = New System.Drawing.Point(18, 43)
        Me.lstClients.Name = "lstClients"
        Me.lstClients.Size = New System.Drawing.Size(337, 134)
        Me.lstClients.TabIndex = 13
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(65, 186)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(517, 20)
        Me.txtSearch.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Search"
        '
        'txtClientGroup
        '
        Me.txtClientGroup.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtClientGroup.Location = New System.Drawing.Point(393, 23)
        Me.txtClientGroup.Name = "txtClientGroup"
        Me.txtClientGroup.Size = New System.Drawing.Size(337, 20)
        Me.txtClientGroup.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(393, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Client Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClient
        '
        Me.txtClient.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtClient.Location = New System.Drawing.Point(18, 23)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Size = New System.Drawing.Size(337, 20)
        Me.txtClient.TabIndex = 12
        '
        'lblClient
        '
        Me.lblClient.BackColor = System.Drawing.Color.Yellow
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblClient.Location = New System.Drawing.Point(18, 10)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(337, 13)
        Me.lblClient.TabIndex = 11
        Me.lblClient.Text = "Client"
        Me.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(655, 459)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdAccept
        '
        Me.cmdAccept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdAccept.Location = New System.Drawing.Point(546, 459)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(75, 23)
        Me.cmdAccept.TabIndex = 20
        Me.cmdAccept.Text = "Accept"
        Me.cmdAccept.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Location = New System.Drawing.Point(588, 183)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(142, 23)
        Me.cmdSearch.TabIndex = 22
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'frmCostCentre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 493)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.dgvCostCentres)
        Me.Controls.Add(Me.lstClientGroup)
        Me.Controls.Add(Me.lstClients)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtClientGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtClient)
        Me.Controls.Add(Me.lblClient)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAccept)
        Me.Name = "frmCostCentre"
        Me.Text = "Cost Centre Lookup"
        CType(Me.dgvCostCentres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuCostCentre.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCostCentres As DataGridView
    Friend WithEvents mnuCostCentre As ContextMenuStrip
    Friend WithEvents mnuCostCentreExport As ToolStripMenuItem
    Friend WithEvents lstClientGroup As ListBox
    Friend WithEvents lstClients As ListBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtClientGroup As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtClient As TextBox
    Friend WithEvents lblClient As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdAccept As Button
    Friend WithEvents cmdSearch As Button
End Class
