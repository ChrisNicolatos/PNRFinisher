<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPISPaxSelect
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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.dgvPax = New System.Windows.Forms.DataGridView()
        CType(Me.dgvPax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(315, 267)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(85, 25)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSelect
        '
        Me.cmdSelect.Location = New System.Drawing.Point(126, 267)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(85, 25)
        Me.cmdSelect.TabIndex = 16
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "First name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Surname"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Passenger Number"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(126, 72)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(848, 20)
        Me.txtFirstName.TabIndex = 12
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(126, 46)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.ReadOnly = True
        Me.txtSurname.Size = New System.Drawing.Size(848, 20)
        Me.txtSurname.TabIndex = 11
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(126, 20)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(59, 20)
        Me.txtNumber.TabIndex = 10
        '
        'dgvPax
        '
        Me.dgvPax.AllowUserToAddRows = False
        Me.dgvPax.AllowUserToDeleteRows = False
        Me.dgvPax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPax.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPax.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPax.Location = New System.Drawing.Point(12, 116)
        Me.dgvPax.MultiSelect = False
        Me.dgvPax.Name = "dgvPax"
        Me.dgvPax.ReadOnly = True
        Me.dgvPax.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPax.Size = New System.Drawing.Size(962, 143)
        Me.dgvPax.TabIndex = 9
        '
        'frmAPISPaxSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 312)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.dgvPax)
        Me.Name = "frmAPISPaxSelect"
        Me.Text = "Duplicate Passenger Names Found"
        CType(Me.dgvPax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSelect As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents dgvPax As DataGridView
End Class
