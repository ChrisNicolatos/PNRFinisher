<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaxCTCOnlyPax
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblClientCode = New System.Windows.Forms.Label()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.lblVessel = New System.Windows.Forms.Label()
        Me.dgvPax = New System.Windows.Forms.DataGridView()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Refused = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        CType(Me.dgvPax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Client Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Vessel"
        '
        'lblClientCode
        '
        Me.lblClientCode.AutoSize = True
        Me.lblClientCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClientCode.Location = New System.Drawing.Point(89, 16)
        Me.lblClientCode.Name = "lblClientCode"
        Me.lblClientCode.Size = New System.Drawing.Size(2, 15)
        Me.lblClientCode.TabIndex = 3
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClientName.Location = New System.Drawing.Point(89, 37)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(2, 15)
        Me.lblClientName.TabIndex = 4
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVessel.Location = New System.Drawing.Point(89, 58)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(2, 15)
        Me.lblVessel.TabIndex = 5
        '
        'dgvPax
        '
        Me.dgvPax.AllowUserToAddRows = False
        Me.dgvPax.AllowUserToDeleteRows = False
        Me.dgvPax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPax.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LastName, Me.FirstName, Me.EMail, Me.Mobile, Me.Refused})
        Me.dgvPax.Location = New System.Drawing.Point(12, 95)
        Me.dgvPax.Name = "dgvPax"
        Me.dgvPax.Size = New System.Drawing.Size(744, 323)
        Me.dgvPax.TabIndex = 36
        '
        'LastName
        '
        Me.LastName.HeaderText = "Last Name"
        Me.LastName.Name = "LastName"
        Me.LastName.ReadOnly = True
        '
        'FirstName
        '
        Me.FirstName.HeaderText = "First Name"
        Me.FirstName.Name = "FirstName"
        Me.FirstName.ReadOnly = True
        '
        'EMail
        '
        Me.EMail.HeaderText = "EMail"
        Me.EMail.Name = "EMail"
        '
        'Mobile
        '
        Me.Mobile.HeaderText = "Mobile"
        Me.Mobile.Name = "Mobile"
        '
        'Refused
        '
        Me.Refused.HeaderText = "Refused"
        Me.Refused.Name = "Refused"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(600, 66)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 37
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(681, 66)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 38
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'frmPaxCTCOnlyPax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 430)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.dgvPax)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.lblClientName)
        Me.Controls.Add(Me.lblClientCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPaxCTCOnlyPax"
        Me.Text = "Passenger Contact Details"
        CType(Me.dgvPax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblClientCode As Label
    Friend WithEvents lblClientName As Label
    Friend WithEvents lblVessel As Label
    Friend WithEvents dgvPax As DataGridView
    Friend WithEvents LastName As DataGridViewTextBoxColumn
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents EMail As DataGridViewTextBoxColumn
    Friend WithEvents Mobile As DataGridViewTextBoxColumn
    Friend WithEvents Refused As DataGridViewCheckBoxColumn
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents cmdExit As Button
End Class
