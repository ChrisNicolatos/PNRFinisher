<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCRef
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblClientRef = New System.Windows.Forms.Label()
        Me.cmbClientRef = New System.Windows.Forms.ComboBox()
        Me.lnkPassenger = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblClientRef
        '
        Me.lblClientRef.BackColor = System.Drawing.Color.Pink
        Me.lblClientRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblClientRef.Location = New System.Drawing.Point(1, 1)
        Me.lblClientRef.Name = "lblClientRef"
        Me.lblClientRef.Size = New System.Drawing.Size(125, 20)
        Me.lblClientRef.TabIndex = 78
        Me.lblClientRef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbClientRef
        '
        Me.cmbClientRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientRef.DropDownWidth = 207
        Me.cmbClientRef.FormattingEnabled = True
        Me.cmbClientRef.Location = New System.Drawing.Point(133, 1)
        Me.cmbClientRef.Name = "cmbClientRef"
        Me.cmbClientRef.Size = New System.Drawing.Size(207, 21)
        Me.cmbClientRef.TabIndex = 79
        '
        'lnkPassenger
        '
        Me.lnkPassenger.AutoSize = True
        Me.lnkPassenger.Location = New System.Drawing.Point(346, 5)
        Me.lnkPassenger.Name = "lnkPassenger"
        Me.lnkPassenger.Size = New System.Drawing.Size(25, 13)
        Me.lnkPassenger.TabIndex = 80
        Me.lnkPassenger.TabStop = True
        Me.lnkPassenger.Text = "Pax"
        Me.lnkPassenger.Visible = False
        '
        'UCRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lnkPassenger)
        Me.Controls.Add(Me.lblClientRef)
        Me.Controls.Add(Me.cmbClientRef)
        Me.Name = "UCRef"
        Me.Size = New System.Drawing.Size(370, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblClientRef As Label
    Friend WithEvents cmbClientRef As ComboBox
    Friend WithEvents lnkPassenger As LinkLabel
End Class
