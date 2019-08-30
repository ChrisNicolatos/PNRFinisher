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
        Me.lstCustomerGroup = New System.Windows.Forms.ListBox()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustomerGroup = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        'lstCustomerGroup
        '
        Me.lstCustomerGroup.FormattingEnabled = True
        Me.lstCustomerGroup.Location = New System.Drawing.Point(393, 43)
        Me.lstCustomerGroup.Name = "lstCustomerGroup"
        Me.lstCustomerGroup.Size = New System.Drawing.Size(337, 134)
        Me.lstCustomerGroup.TabIndex = 16
        '
        'lstCustomers
        '
        Me.lstCustomers.FormattingEnabled = True
        Me.lstCustomers.Location = New System.Drawing.Point(18, 43)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(337, 134)
        Me.lstCustomers.TabIndex = 13
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
        'txtCustomerGroup
        '
        Me.txtCustomerGroup.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomerGroup.Location = New System.Drawing.Point(393, 23)
        Me.txtCustomerGroup.Name = "txtCustomerGroup"
        Me.txtCustomerGroup.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomerGroup.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(393, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Customer Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(18, 23)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomer.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Controls.Add(Me.lstCustomerGroup)
        Me.Controls.Add(Me.lstCustomers)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCustomerGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents lstCustomerGroup As ListBox
    Friend WithEvents lstCustomers As ListBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCustomerGroup As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdAccept As Button
    Friend WithEvents cmdSearch As Button
End Class
