<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVesselForPNR
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
        Me.lblNotice = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtRegistration = New System.Windows.Forms.TextBox()
        Me.txtVesselName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblNotice
        '
        Me.lblNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblNotice.ForeColor = System.Drawing.Color.Red
        Me.lblNotice.Location = New System.Drawing.Point(8, 11)
        Me.lblNotice.Name = "lblNotice"
        Me.lblNotice.Size = New System.Drawing.Size(350, 103)
        Me.lblNotice.TabIndex = 7
        Me.lblNotice.Text = "NOTE: This vessel will not be added to the customer's vessels and is used only in" &
    " this PNR"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(283, 193)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(81, 193)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtRegistration
        '
        Me.txtRegistration.Location = New System.Drawing.Point(81, 153)
        Me.txtRegistration.Name = "txtRegistration"
        Me.txtRegistration.Size = New System.Drawing.Size(277, 20)
        Me.txtRegistration.TabIndex = 11
        '
        'txtVesselName
        '
        Me.txtVesselName.Location = New System.Drawing.Point(81, 127)
        Me.txtVesselName.Name = "txtVesselName"
        Me.txtVesselName.Size = New System.Drawing.Size(277, 20)
        Me.txtVesselName.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Registration"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Vessel name"
        '
        'frmVesselForPNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 226)
        Me.Controls.Add(Me.lblNotice)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtRegistration)
        Me.Controls.Add(Me.txtVesselName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmVesselForPNR"
        Me.Text = "Vessel for PNR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNotice As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents txtRegistration As TextBox
    Friend WithEvents txtVesselName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
