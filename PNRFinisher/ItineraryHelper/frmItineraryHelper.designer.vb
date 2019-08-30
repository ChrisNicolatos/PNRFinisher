<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItineraryHelper
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
        Me.dtpFromIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tvwItineraries = New System.Windows.Forms.TreeView()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.txtOrigin = New System.Windows.Forms.TextBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.chkFromAirportOnly = New System.Windows.Forms.CheckBox()
        Me.chkToAirportOnly = New System.Windows.Forms.CheckBox()
        Me.lstFromAirport = New System.Windows.Forms.ListBox()
        Me.lstToAirport = New System.Windows.Forms.ListBox()
        Me.lstStopover = New System.Windows.Forms.ListBox()
        Me.chkStopoverAirportOnly = New System.Windows.Forms.CheckBox()
        Me.txtStopover = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(149, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Origin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(675, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Destination"
        '
        'dtpFromIssueDate
        '
        Me.dtpFromIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromIssueDate.Location = New System.Drawing.Point(10, 15)
        Me.dtpFromIssueDate.Name = "dtpFromIssueDate"
        Me.dtpFromIssueDate.Size = New System.Drawing.Size(115, 20)
        Me.dtpFromIssueDate.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "From Issue Date"
        '
        'tvwItineraries
        '
        Me.tvwItineraries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwItineraries.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwItineraries.Location = New System.Drawing.Point(10, 141)
        Me.tvwItineraries.Name = "tvwItineraries"
        Me.tvwItineraries.Size = New System.Drawing.Size(1066, 328)
        Me.tvwItineraries.TabIndex = 16
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Location = New System.Drawing.Point(1001, 12)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 12
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1001, 41)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtOrigin
        '
        Me.txtOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigin.Location = New System.Drawing.Point(149, 15)
        Me.txtOrigin.MaxLength = 3
        Me.txtOrigin.Name = "txtOrigin"
        Me.txtOrigin.Size = New System.Drawing.Size(115, 20)
        Me.txtOrigin.TabIndex = 1
        '
        'txtDestination
        '
        Me.txtDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestination.Location = New System.Drawing.Point(675, 15)
        Me.txtDestination.MaxLength = 3
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(115, 20)
        Me.txtDestination.TabIndex = 9
        '
        'chkFromAirportOnly
        '
        Me.chkFromAirportOnly.AutoSize = True
        Me.chkFromAirportOnly.Location = New System.Drawing.Point(149, 35)
        Me.chkFromAirportOnly.Name = "chkFromAirportOnly"
        Me.chkFromAirportOnly.Size = New System.Drawing.Size(118, 17)
        Me.chkFromAirportOnly.TabIndex = 2
        Me.chkFromAirportOnly.Text = "Specific airport only"
        Me.chkFromAirportOnly.UseVisualStyleBackColor = True
        '
        'chkToAirportOnly
        '
        Me.chkToAirportOnly.AutoSize = True
        Me.chkToAirportOnly.Location = New System.Drawing.Point(675, 35)
        Me.chkToAirportOnly.Name = "chkToAirportOnly"
        Me.chkToAirportOnly.Size = New System.Drawing.Size(118, 17)
        Me.chkToAirportOnly.TabIndex = 10
        Me.chkToAirportOnly.Text = "Specific airport only"
        Me.chkToAirportOnly.UseVisualStyleBackColor = True
        '
        'lstFromAirport
        '
        Me.lstFromAirport.FormattingEnabled = True
        Me.lstFromAirport.Location = New System.Drawing.Point(148, 58)
        Me.lstFromAirport.Name = "lstFromAirport"
        Me.lstFromAirport.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstFromAirport.Size = New System.Drawing.Size(257, 69)
        Me.lstFromAirport.TabIndex = 3
        '
        'lstToAirport
        '
        Me.lstToAirport.FormattingEnabled = True
        Me.lstToAirport.Location = New System.Drawing.Point(674, 58)
        Me.lstToAirport.Name = "lstToAirport"
        Me.lstToAirport.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstToAirport.Size = New System.Drawing.Size(257, 69)
        Me.lstToAirport.TabIndex = 11
        '
        'lstStopover
        '
        Me.lstStopover.FormattingEnabled = True
        Me.lstStopover.Location = New System.Drawing.Point(411, 58)
        Me.lstStopover.Name = "lstStopover"
        Me.lstStopover.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstStopover.Size = New System.Drawing.Size(257, 69)
        Me.lstStopover.TabIndex = 7
        '
        'chkStopoverAirportOnly
        '
        Me.chkStopoverAirportOnly.AutoSize = True
        Me.chkStopoverAirportOnly.Location = New System.Drawing.Point(412, 35)
        Me.chkStopoverAirportOnly.Name = "chkStopoverAirportOnly"
        Me.chkStopoverAirportOnly.Size = New System.Drawing.Size(118, 17)
        Me.chkStopoverAirportOnly.TabIndex = 6
        Me.chkStopoverAirportOnly.Text = "Specific airport only"
        Me.chkStopoverAirportOnly.UseVisualStyleBackColor = True
        '
        'txtStopover
        '
        Me.txtStopover.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStopover.Location = New System.Drawing.Point(412, 15)
        Me.txtStopover.MaxLength = 3
        Me.txtStopover.Name = "txtStopover"
        Me.txtStopover.Size = New System.Drawing.Size(115, 20)
        Me.txtStopover.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(412, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "StopOver"
        '
        'frmItineraryHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 487)
        Me.Controls.Add(Me.lstStopover)
        Me.Controls.Add(Me.chkStopoverAirportOnly)
        Me.Controls.Add(Me.txtStopover)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstToAirport)
        Me.Controls.Add(Me.lstFromAirport)
        Me.Controls.Add(Me.chkToAirportOnly)
        Me.Controls.Add(Me.chkFromAirportOnly)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.txtOrigin)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.tvwItineraries)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFromIssueDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(803, 526)
        Me.Name = "frmItineraryHelper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Itinerary Helper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFromIssueDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents tvwItineraries As TreeView
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents txtOrigin As TextBox
    Friend WithEvents txtDestination As TextBox
    Friend WithEvents chkFromAirportOnly As CheckBox
    Friend WithEvents chkToAirportOnly As CheckBox
    Friend WithEvents lstFromAirport As ListBox
    Friend WithEvents lstToAirport As ListBox
    Friend WithEvents lstStopover As ListBox
    Friend WithEvents chkStopoverAirportOnly As CheckBox
    Friend WithEvents txtStopover As TextBox
    Friend WithEvents Label4 As Label
End Class
