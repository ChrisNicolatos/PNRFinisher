<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPISPax
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
        Me.txtNationality = New System.Windows.Forms.TextBox()
        Me.txtPassportIssuingCountry = New System.Windows.Forms.TextBox()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPassportExpiryDate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassportNumber = New System.Windows.Forms.TextBox()
        Me.txtDateOfBirth = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtNationality
        '
        Me.txtNationality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtNationality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNationality.Location = New System.Drawing.Point(162, 142)
        Me.txtNationality.Name = "txtNationality"
        Me.txtNationality.Size = New System.Drawing.Size(277, 20)
        Me.txtNationality.TabIndex = 27
        '
        'txtPassportIssuingCountry
        '
        Me.txtPassportIssuingCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtPassportIssuingCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPassportIssuingCountry.Location = New System.Drawing.Point(162, 169)
        Me.txtPassportIssuingCountry.Name = "txtPassportIssuingCountry"
        Me.txtPassportIssuingCountry.Size = New System.Drawing.Size(277, 20)
        Me.txtPassportIssuingCountry.TabIndex = 29
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Location = New System.Drawing.Point(162, 87)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(277, 21)
        Me.cmbGender.TabIndex = 23
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(162, 292)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(102, 23)
        Me.cmdCancel.TabIndex = 35
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(32, 292)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(102, 23)
        Me.cmdSave.TabIndex = 34
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Nationality"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Passport Expiry date"
        '
        'txtPassportExpiryDate
        '
        Me.txtPassportExpiryDate.Location = New System.Drawing.Point(162, 223)
        Me.txtPassportExpiryDate.Name = "txtPassportExpiryDate"
        Me.txtPassportExpiryDate.Size = New System.Drawing.Size(102, 20)
        Me.txtPassportExpiryDate.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Passport Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Passport Issuing Country"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Date of Birth"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Gender"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "First Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Surname"
        '
        'txtPassportNumber
        '
        Me.txtPassportNumber.Location = New System.Drawing.Point(162, 196)
        Me.txtPassportNumber.Name = "txtPassportNumber"
        Me.txtPassportNumber.Size = New System.Drawing.Size(277, 20)
        Me.txtPassportNumber.TabIndex = 31
        '
        'txtDateOfBirth
        '
        Me.txtDateOfBirth.Location = New System.Drawing.Point(162, 115)
        Me.txtDateOfBirth.Name = "txtDateOfBirth"
        Me.txtDateOfBirth.Size = New System.Drawing.Size(102, 20)
        Me.txtDateOfBirth.TabIndex = 25
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(162, 60)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(277, 20)
        Me.txtFirstName.TabIndex = 21
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(162, 33)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(277, 20)
        Me.txtSurname.TabIndex = 19
        '
        'frmAPISPax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 348)
        Me.Controls.Add(Me.txtNationality)
        Me.Controls.Add(Me.txtPassportIssuingCountry)
        Me.Controls.Add(Me.cmbGender)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPassportExpiryDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassportNumber)
        Me.Controls.Add(Me.txtDateOfBirth)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtSurname)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAPISPax"
        Me.Text = "Pax Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNationality As TextBox
    Friend WithEvents txtPassportIssuingCountry As TextBox
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPassportExpiryDate As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassportNumber As TextBox
    Friend WithEvents txtDateOfBirth As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtSurname As TextBox
End Class
