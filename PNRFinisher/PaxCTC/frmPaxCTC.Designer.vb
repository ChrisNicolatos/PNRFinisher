<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaxCTC
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstClient = New System.Windows.Forms.ListBox()
        Me.lstVessel = New System.Windows.Forms.ListBox()
        Me.optATH = New System.Windows.Forms.RadioButton()
        Me.optQLI = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstPassenger = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtClientCode = New System.Windows.Forms.TextBox()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtClientEmail = New System.Windows.Forms.TextBox()
        Me.txtClientMobile = New System.Windows.Forms.TextBox()
        Me.txtVesselEmail = New System.Windows.Forms.TextBox()
        Me.txtVesselMobile = New System.Windows.Forms.TextBox()
        Me.txtPaxEmail = New System.Windows.Forms.TextBox()
        Me.txtPaxMobile = New System.Windows.Forms.TextBox()
        Me.chkPaxRefused = New System.Windows.Forms.CheckBox()
        Me.chkVesselRefused = New System.Windows.Forms.CheckBox()
        Me.chkClientRefused = New System.Windows.Forms.CheckBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.txtClientFilter = New System.Windows.Forms.TextBox()
        Me.txtVesselFilter = New System.Windows.Forms.TextBox()
        Me.txtPaxFilter = New System.Windows.Forms.TextBox()
        Me.cmdUpdateClient = New System.Windows.Forms.Button()
        Me.cmdUpdateVessel = New System.Windows.Forms.Button()
        Me.cmdUpdatePax = New System.Windows.Forms.Button()
        Me.cmdNewPax = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1160, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1160, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vessel"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(558, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "eMail"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(558, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Mobile"
        '
        'lstClient
        '
        Me.lstClient.FormattingEnabled = True
        Me.lstClient.Location = New System.Drawing.Point(12, 91)
        Me.lstClient.Name = "lstClient"
        Me.lstClient.Size = New System.Drawing.Size(531, 121)
        Me.lstClient.TabIndex = 6
        '
        'lstVessel
        '
        Me.lstVessel.FormattingEnabled = True
        Me.lstVessel.Location = New System.Drawing.Point(12, 267)
        Me.lstVessel.Name = "lstVessel"
        Me.lstVessel.Size = New System.Drawing.Size(531, 121)
        Me.lstVessel.TabIndex = 7
        '
        'optATH
        '
        Me.optATH.AutoSize = True
        Me.optATH.Location = New System.Drawing.Point(12, 21)
        Me.optATH.Name = "optATH"
        Me.optATH.Size = New System.Drawing.Size(110, 17)
        Me.optATH.TabIndex = 8
        Me.optATH.TabStop = True
        Me.optATH.Text = "ATH Travel Force"
        Me.optATH.UseVisualStyleBackColor = True
        '
        'optQLI
        '
        Me.optQLI.AutoSize = True
        Me.optQLI.Location = New System.Drawing.Point(129, 21)
        Me.optQLI.Name = "optQLI"
        Me.optQLI.Size = New System.Drawing.Size(92, 17)
        Me.optQLI.TabIndex = 9
        Me.optQLI.TabStop = True
        Me.optQLI.Text = "QLI Discovery"
        Me.optQLI.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(558, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Mobile"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(558, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "eMail"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(558, 531)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Mobile"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(558, 503)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "eMail"
        '
        'lstPassenger
        '
        Me.lstPassenger.FormattingEnabled = True
        Me.lstPassenger.Location = New System.Drawing.Point(12, 430)
        Me.lstPassenger.Name = "lstPassenger"
        Me.lstPassenger.Size = New System.Drawing.Size(531, 121)
        Me.lstPassenger.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Yellow
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 391)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1160, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Passenger"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(558, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Client Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(558, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Client Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(558, 252)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Vessel Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(558, 415)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Pax First Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(558, 443)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Pax Last Name"
        '
        'txtClientCode
        '
        Me.txtClientCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientCode.Location = New System.Drawing.Point(652, 72)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.ReadOnly = True
        Me.txtClientCode.Size = New System.Drawing.Size(520, 20)
        Me.txtClientCode.TabIndex = 21
        '
        'txtClientName
        '
        Me.txtClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientName.Location = New System.Drawing.Point(652, 101)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.ReadOnly = True
        Me.txtClientName.Size = New System.Drawing.Size(520, 20)
        Me.txtClientName.TabIndex = 22
        '
        'txtVessel
        '
        Me.txtVessel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVessel.Location = New System.Drawing.Point(652, 248)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.ReadOnly = True
        Me.txtVessel.Size = New System.Drawing.Size(520, 20)
        Me.txtVessel.TabIndex = 23
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Location = New System.Drawing.Point(652, 411)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(420, 20)
        Me.txtFirstName.TabIndex = 24
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Location = New System.Drawing.Point(652, 439)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(420, 20)
        Me.txtLastName.TabIndex = 25
        '
        'txtClientEmail
        '
        Me.txtClientEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientEmail.Location = New System.Drawing.Point(652, 163)
        Me.txtClientEmail.Name = "txtClientEmail"
        Me.txtClientEmail.Size = New System.Drawing.Size(420, 20)
        Me.txtClientEmail.TabIndex = 26
        '
        'txtClientMobile
        '
        Me.txtClientMobile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientMobile.Location = New System.Drawing.Point(652, 192)
        Me.txtClientMobile.Name = "txtClientMobile"
        Me.txtClientMobile.Size = New System.Drawing.Size(420, 20)
        Me.txtClientMobile.TabIndex = 27
        '
        'txtVesselEmail
        '
        Me.txtVesselEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVesselEmail.Location = New System.Drawing.Point(652, 339)
        Me.txtVesselEmail.Name = "txtVesselEmail"
        Me.txtVesselEmail.Size = New System.Drawing.Size(420, 20)
        Me.txtVesselEmail.TabIndex = 28
        '
        'txtVesselMobile
        '
        Me.txtVesselMobile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVesselMobile.Location = New System.Drawing.Point(652, 368)
        Me.txtVesselMobile.Name = "txtVesselMobile"
        Me.txtVesselMobile.Size = New System.Drawing.Size(420, 20)
        Me.txtVesselMobile.TabIndex = 29
        '
        'txtPaxEmail
        '
        Me.txtPaxEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaxEmail.Location = New System.Drawing.Point(652, 499)
        Me.txtPaxEmail.Name = "txtPaxEmail"
        Me.txtPaxEmail.Size = New System.Drawing.Size(420, 20)
        Me.txtPaxEmail.TabIndex = 30
        '
        'txtPaxMobile
        '
        Me.txtPaxMobile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaxMobile.Location = New System.Drawing.Point(652, 527)
        Me.txtPaxMobile.Name = "txtPaxMobile"
        Me.txtPaxMobile.Size = New System.Drawing.Size(420, 20)
        Me.txtPaxMobile.TabIndex = 31
        '
        'chkPaxRefused
        '
        Me.chkPaxRefused.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPaxRefused.Location = New System.Drawing.Point(558, 467)
        Me.chkPaxRefused.Name = "chkPaxRefused"
        Me.chkPaxRefused.Size = New System.Drawing.Size(108, 24)
        Me.chkPaxRefused.TabIndex = 32
        Me.chkPaxRefused.Text = "CTC Refused"
        Me.chkPaxRefused.UseVisualStyleBackColor = True
        '
        'chkVesselRefused
        '
        Me.chkVesselRefused.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVesselRefused.Location = New System.Drawing.Point(558, 306)
        Me.chkVesselRefused.Name = "chkVesselRefused"
        Me.chkVesselRefused.Size = New System.Drawing.Size(108, 24)
        Me.chkVesselRefused.TabIndex = 34
        Me.chkVesselRefused.Text = "CTC Refused"
        Me.chkVesselRefused.UseVisualStyleBackColor = True
        '
        'chkClientRefused
        '
        Me.chkClientRefused.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkClientRefused.Location = New System.Drawing.Point(558, 130)
        Me.chkClientRefused.Name = "chkClientRefused"
        Me.chkClientRefused.Size = New System.Drawing.Size(108, 24)
        Me.chkClientRefused.TabIndex = 35
        Me.chkClientRefused.Text = "CTC Refused"
        Me.chkClientRefused.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1097, 15)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 36
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtClientFilter
        '
        Me.txtClientFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientFilter.Location = New System.Drawing.Point(12, 65)
        Me.txtClientFilter.Name = "txtClientFilter"
        Me.txtClientFilter.Size = New System.Drawing.Size(531, 20)
        Me.txtClientFilter.TabIndex = 38
        '
        'txtVesselFilter
        '
        Me.txtVesselFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVesselFilter.Location = New System.Drawing.Point(12, 241)
        Me.txtVesselFilter.Name = "txtVesselFilter"
        Me.txtVesselFilter.Size = New System.Drawing.Size(531, 20)
        Me.txtVesselFilter.TabIndex = 39
        '
        'txtPaxFilter
        '
        Me.txtPaxFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaxFilter.Location = New System.Drawing.Point(12, 404)
        Me.txtPaxFilter.Name = "txtPaxFilter"
        Me.txtPaxFilter.Size = New System.Drawing.Size(531, 20)
        Me.txtPaxFilter.TabIndex = 40
        '
        'cmdUpdateClient
        '
        Me.cmdUpdateClient.Location = New System.Drawing.Point(1097, 162)
        Me.cmdUpdateClient.Name = "cmdUpdateClient"
        Me.cmdUpdateClient.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdateClient.TabIndex = 41
        Me.cmdUpdateClient.Text = "Update"
        Me.cmdUpdateClient.UseVisualStyleBackColor = True
        '
        'cmdUpdateVessel
        '
        Me.cmdUpdateVessel.Location = New System.Drawing.Point(1097, 338)
        Me.cmdUpdateVessel.Name = "cmdUpdateVessel"
        Me.cmdUpdateVessel.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdateVessel.TabIndex = 42
        Me.cmdUpdateVessel.Text = "Update"
        Me.cmdUpdateVessel.UseVisualStyleBackColor = True
        '
        'cmdUpdatePax
        '
        Me.cmdUpdatePax.Location = New System.Drawing.Point(1097, 498)
        Me.cmdUpdatePax.Name = "cmdUpdatePax"
        Me.cmdUpdatePax.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdatePax.TabIndex = 43
        Me.cmdUpdatePax.Text = "Update"
        Me.cmdUpdatePax.UseVisualStyleBackColor = True
        '
        'cmdNewPax
        '
        Me.cmdNewPax.Location = New System.Drawing.Point(1097, 411)
        Me.cmdNewPax.Name = "cmdNewPax"
        Me.cmdNewPax.Size = New System.Drawing.Size(75, 23)
        Me.cmdNewPax.TabIndex = 44
        Me.cmdNewPax.Text = "New Pax"
        Me.cmdNewPax.UseVisualStyleBackColor = True
        '
        'frmPaxCTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 630)
        Me.Controls.Add(Me.cmdNewPax)
        Me.Controls.Add(Me.cmdUpdatePax)
        Me.Controls.Add(Me.cmdUpdateVessel)
        Me.Controls.Add(Me.cmdUpdateClient)
        Me.Controls.Add(Me.txtPaxFilter)
        Me.Controls.Add(Me.txtVesselFilter)
        Me.Controls.Add(Me.txtClientFilter)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.chkClientRefused)
        Me.Controls.Add(Me.chkVesselRefused)
        Me.Controls.Add(Me.chkPaxRefused)
        Me.Controls.Add(Me.txtPaxMobile)
        Me.Controls.Add(Me.txtPaxEmail)
        Me.Controls.Add(Me.txtVesselMobile)
        Me.Controls.Add(Me.txtVesselEmail)
        Me.Controls.Add(Me.txtClientMobile)
        Me.Controls.Add(Me.txtClientEmail)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtVessel)
        Me.Controls.Add(Me.txtClientName)
        Me.Controls.Add(Me.txtClientCode)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstPassenger)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.optQLI)
        Me.Controls.Add(Me.optATH)
        Me.Controls.Add(Me.lstVessel)
        Me.Controls.Add(Me.lstClient)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPaxCTC"
        Me.Text = "Passenger CTC Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lstClient As ListBox
    Friend WithEvents lstVessel As ListBox
    Friend WithEvents optATH As RadioButton
    Friend WithEvents optQLI As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lstPassenger As ListBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtClientCode As TextBox
    Friend WithEvents txtClientName As TextBox
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtClientEmail As TextBox
    Friend WithEvents txtClientMobile As TextBox
    Friend WithEvents txtVesselEmail As TextBox
    Friend WithEvents txtVesselMobile As TextBox
    Friend WithEvents txtPaxEmail As TextBox
    Friend WithEvents txtPaxMobile As TextBox
    Friend WithEvents chkPaxRefused As CheckBox
    Friend WithEvents chkVesselRefused As CheckBox
    Friend WithEvents chkClientRefused As CheckBox
    Friend WithEvents cmdExit As Button
    Friend WithEvents txtClientFilter As TextBox
    Friend WithEvents txtVesselFilter As TextBox
    Friend WithEvents txtPaxFilter As TextBox
    Friend WithEvents cmdUpdateClient As Button
    Friend WithEvents cmdUpdateVessel As Button
    Friend WithEvents cmdUpdatePax As Button
    Friend WithEvents cmdNewPax As Button
End Class
