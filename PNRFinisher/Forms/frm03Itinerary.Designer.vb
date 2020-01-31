<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm03Itinerary
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
        Me.fraGalileo = New System.Windows.Forms.GroupBox()
        Me.cmdItn1GReadPNR = New System.Windows.Forms.Button()
        Me.cmdItn1GReadCurrent = New System.Windows.Forms.Button()
        Me.cmdItn1GReadQueue = New System.Windows.Forms.Button()
        Me.fraAmadeus = New System.Windows.Forms.GroupBox()
        Me.cmdItn1AReadPNR = New System.Windows.Forms.Button()
        Me.cmdItn1AReadCurrent = New System.Windows.Forms.Button()
        Me.cmdItn1AReadQueue = New System.Windows.Forms.Button()
        Me.cmdItnFormatOSMLoG = New System.Windows.Forms.Button()
        Me.webItnDoc = New System.Windows.Forms.WebBrowser()
        Me.lblItnPNRCounter = New System.Windows.Forms.Label()
        Me.cmdItnRefresh = New System.Windows.Forms.Button()
        Me.fraItnFormat = New System.Windows.Forms.GroupBox()
        Me.optItnFormatAimeryMoxie = New System.Windows.Forms.RadioButton()
        Me.optItnFormatFleet = New System.Windows.Forms.RadioButton()
        Me.optItnFormatSeaChefsWith3LetterCode = New System.Windows.Forms.RadioButton()
        Me.optItnFormatEuronav = New System.Windows.Forms.RadioButton()
        Me.optItnFormatSeaChefs = New System.Windows.Forms.RadioButton()
        Me.optItnFormatPlain = New System.Windows.Forms.RadioButton()
        Me.optItnFormatDefault = New System.Windows.Forms.RadioButton()
        Me.cmdItnExit = New System.Windows.Forms.Button()
        Me.lstItnRemarks = New System.Windows.Forms.CheckedListBox()
        Me.fraItnAirportName = New System.Windows.Forms.GroupBox()
        Me.optItnAirportCityBoth = New System.Windows.Forms.RadioButton()
        Me.optItnAirportCityName = New System.Windows.Forms.RadioButton()
        Me.optItnAirportBoth = New System.Windows.Forms.RadioButton()
        Me.optItnAirportname = New System.Windows.Forms.RadioButton()
        Me.optItnAirportCode = New System.Windows.Forms.RadioButton()
        Me.fraItnOptions = New System.Windows.Forms.GroupBox()
        Me.chkItnCO2 = New System.Windows.Forms.CheckBox()
        Me.chkItnEquipmentCode = New System.Windows.Forms.CheckBox()
        Me.chkItnEMD = New System.Windows.Forms.CheckBox()
        Me.chkItnItinRemarks = New System.Windows.Forms.CheckBox()
        Me.chkItnCabinDescription = New System.Windows.Forms.CheckBox()
        Me.chkItnCostCentre = New System.Windows.Forms.CheckBox()
        Me.chkItnFlyingTime = New System.Windows.Forms.CheckBox()
        Me.chkItnSeating = New System.Windows.Forms.CheckBox()
        Me.chkItnStopovers = New System.Windows.Forms.CheckBox()
        Me.chkItnTerminal = New System.Windows.Forms.CheckBox()
        Me.chkItnPaxSegPerTicket = New System.Windows.Forms.CheckBox()
        Me.chkItnTickets = New System.Windows.Forms.CheckBox()
        Me.chkItnClass = New System.Windows.Forms.CheckBox()
        Me.chkItnVessel = New System.Windows.Forms.CheckBox()
        Me.chkItnAirlineLocator = New System.Windows.Forms.CheckBox()
        Me.rtbItnDoc = New System.Windows.Forms.RichTextBox()
        Me.txtItnPNR = New System.Windows.Forms.TextBox()
        Me.lblItnPNR = New System.Windows.Forms.Label()
        Me.menuITNSelectCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuCopyItn = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SSGDS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSPCC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SSUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.fraGalileo.SuspendLayout()
        Me.fraAmadeus.SuspendLayout()
        Me.fraItnFormat.SuspendLayout()
        Me.fraItnAirportName.SuspendLayout()
        Me.fraItnOptions.SuspendLayout()
        Me.menuITNSelectCopy.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraGalileo
        '
        Me.fraGalileo.Controls.Add(Me.cmdItn1GReadPNR)
        Me.fraGalileo.Controls.Add(Me.cmdItn1GReadCurrent)
        Me.fraGalileo.Controls.Add(Me.cmdItn1GReadQueue)
        Me.fraGalileo.Location = New System.Drawing.Point(307, 12)
        Me.fraGalileo.Name = "fraGalileo"
        Me.fraGalileo.Size = New System.Drawing.Size(289, 46)
        Me.fraGalileo.TabIndex = 36
        Me.fraGalileo.TabStop = False
        Me.fraGalileo.Text = "Galileo"
        '
        'cmdItn1GReadPNR
        '
        Me.cmdItn1GReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1GReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1GReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1GReadPNR.Location = New System.Drawing.Point(6, 14)
        Me.cmdItn1GReadPNR.Name = "cmdItn1GReadPNR"
        Me.cmdItn1GReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1GReadPNR.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1GReadPNR.TabIndex = 0
        Me.cmdItn1GReadPNR.Text = "Read PNR"
        Me.cmdItn1GReadPNR.UseVisualStyleBackColor = True
        '
        'cmdItn1GReadCurrent
        '
        Me.cmdItn1GReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1GReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1GReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1GReadCurrent.Location = New System.Drawing.Point(85, 14)
        Me.cmdItn1GReadCurrent.Name = "cmdItn1GReadCurrent"
        Me.cmdItn1GReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1GReadCurrent.Size = New System.Drawing.Size(99, 21)
        Me.cmdItn1GReadCurrent.TabIndex = 1
        Me.cmdItn1GReadCurrent.Text = "Read Current"
        Me.cmdItn1GReadCurrent.UseVisualStyleBackColor = False
        '
        'cmdItn1GReadQueue
        '
        Me.cmdItn1GReadQueue.Location = New System.Drawing.Point(190, 14)
        Me.cmdItn1GReadQueue.Name = "cmdItn1GReadQueue"
        Me.cmdItn1GReadQueue.Size = New System.Drawing.Size(80, 21)
        Me.cmdItn1GReadQueue.TabIndex = 13
        Me.cmdItn1GReadQueue.Text = "Read Queue"
        Me.cmdItn1GReadQueue.UseVisualStyleBackColor = True
        '
        'fraAmadeus
        '
        Me.fraAmadeus.Controls.Add(Me.cmdItn1AReadPNR)
        Me.fraAmadeus.Controls.Add(Me.cmdItn1AReadCurrent)
        Me.fraAmadeus.Controls.Add(Me.cmdItn1AReadQueue)
        Me.fraAmadeus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraAmadeus.Location = New System.Drawing.Point(12, 12)
        Me.fraAmadeus.Name = "fraAmadeus"
        Me.fraAmadeus.Size = New System.Drawing.Size(289, 46)
        Me.fraAmadeus.TabIndex = 35
        Me.fraAmadeus.TabStop = False
        Me.fraAmadeus.Text = "Amadeus"
        '
        'cmdItn1AReadPNR
        '
        Me.cmdItn1AReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1AReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1AReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1AReadPNR.Location = New System.Drawing.Point(6, 14)
        Me.cmdItn1AReadPNR.Name = "cmdItn1AReadPNR"
        Me.cmdItn1AReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1AReadPNR.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1AReadPNR.TabIndex = 0
        Me.cmdItn1AReadPNR.Text = "Read PNR"
        Me.cmdItn1AReadPNR.UseVisualStyleBackColor = True
        '
        'cmdItn1AReadCurrent
        '
        Me.cmdItn1AReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1AReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1AReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1AReadCurrent.Location = New System.Drawing.Point(85, 14)
        Me.cmdItn1AReadCurrent.Name = "cmdItn1AReadCurrent"
        Me.cmdItn1AReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1AReadCurrent.Size = New System.Drawing.Size(99, 21)
        Me.cmdItn1AReadCurrent.TabIndex = 1
        Me.cmdItn1AReadCurrent.Text = "Read Current"
        Me.cmdItn1AReadCurrent.UseVisualStyleBackColor = False
        '
        'cmdItn1AReadQueue
        '
        Me.cmdItn1AReadQueue.Location = New System.Drawing.Point(190, 14)
        Me.cmdItn1AReadQueue.Name = "cmdItn1AReadQueue"
        Me.cmdItn1AReadQueue.Size = New System.Drawing.Size(80, 21)
        Me.cmdItn1AReadQueue.TabIndex = 13
        Me.cmdItn1AReadQueue.Text = "Read Queue"
        Me.cmdItn1AReadQueue.UseVisualStyleBackColor = True
        '
        'cmdItnFormatOSMLoG
        '
        Me.cmdItnFormatOSMLoG.Location = New System.Drawing.Point(616, 26)
        Me.cmdItnFormatOSMLoG.Name = "cmdItnFormatOSMLoG"
        Me.cmdItnFormatOSMLoG.Size = New System.Drawing.Size(108, 21)
        Me.cmdItnFormatOSMLoG.TabIndex = 34
        Me.cmdItnFormatOSMLoG.Text = "OSM LoG"
        Me.cmdItnFormatOSMLoG.UseVisualStyleBackColor = True
        '
        'webItnDoc
        '
        Me.webItnDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webItnDoc.Location = New System.Drawing.Point(987, 26)
        Me.webItnDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webItnDoc.Name = "webItnDoc"
        Me.webItnDoc.Size = New System.Drawing.Size(96, 27)
        Me.webItnDoc.TabIndex = 33
        Me.webItnDoc.Visible = False
        '
        'lblItnPNRCounter
        '
        Me.lblItnPNRCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItnPNRCounter.BackColor = System.Drawing.Color.Aqua
        Me.lblItnPNRCounter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnPNRCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnPNRCounter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnPNRCounter.Location = New System.Drawing.Point(14, 551)
        Me.lblItnPNRCounter.Name = "lblItnPNRCounter"
        Me.lblItnPNRCounter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnPNRCounter.Size = New System.Drawing.Size(137, 13)
        Me.lblItnPNRCounter.TabIndex = 32
        Me.lblItnPNRCounter.Text = "PNR"
        Me.lblItnPNRCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdItnRefresh
        '
        Me.cmdItnRefresh.Enabled = False
        Me.cmdItnRefresh.Location = New System.Drawing.Point(760, 26)
        Me.cmdItnRefresh.Name = "cmdItnRefresh"
        Me.cmdItnRefresh.Size = New System.Drawing.Size(80, 21)
        Me.cmdItnRefresh.TabIndex = 31
        Me.cmdItnRefresh.Text = "Refresh"
        Me.cmdItnRefresh.UseVisualStyleBackColor = True
        '
        'fraItnFormat
        '
        Me.fraItnFormat.Controls.Add(Me.optItnFormatAimeryMoxie)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatFleet)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatSeaChefsWith3LetterCode)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatEuronav)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatSeaChefs)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatPlain)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatDefault)
        Me.fraItnFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnFormat.Location = New System.Drawing.Point(318, 64)
        Me.fraItnFormat.Name = "fraItnFormat"
        Me.fraItnFormat.Size = New System.Drawing.Size(273, 134)
        Me.fraItnFormat.TabIndex = 26
        Me.fraItnFormat.TabStop = False
        Me.fraItnFormat.Text = "Format"
        '
        'optItnFormatAimeryMoxie
        '
        Me.optItnFormatAimeryMoxie.AutoSize = True
        Me.optItnFormatAimeryMoxie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatAimeryMoxie.Location = New System.Drawing.Point(130, 78)
        Me.optItnFormatAimeryMoxie.Name = "optItnFormatAimeryMoxie"
        Me.optItnFormatAimeryMoxie.Size = New System.Drawing.Size(119, 17)
        Me.optItnFormatAimeryMoxie.TabIndex = 9
        Me.optItnFormatAimeryMoxie.Text = " OSM Aimery/Moxie"
        Me.optItnFormatAimeryMoxie.UseVisualStyleBackColor = True
        '
        'optItnFormatFleet
        '
        Me.optItnFormatFleet.AutoSize = True
        Me.optItnFormatFleet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatFleet.Location = New System.Drawing.Point(130, 49)
        Me.optItnFormatFleet.Name = "optItnFormatFleet"
        Me.optItnFormatFleet.Size = New System.Drawing.Size(48, 17)
        Me.optItnFormatFleet.TabIndex = 8
        Me.optItnFormatFleet.Text = "Fleet"
        Me.optItnFormatFleet.UseVisualStyleBackColor = True
        '
        'optItnFormatSeaChefsWith3LetterCode
        '
        Me.optItnFormatSeaChefsWith3LetterCode.AutoSize = True
        Me.optItnFormatSeaChefsWith3LetterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatSeaChefsWith3LetterCode.Location = New System.Drawing.Point(17, 107)
        Me.optItnFormatSeaChefsWith3LetterCode.Name = "optItnFormatSeaChefsWith3LetterCode"
        Me.optItnFormatSeaChefsWith3LetterCode.Size = New System.Drawing.Size(158, 17)
        Me.optItnFormatSeaChefsWith3LetterCode.TabIndex = 7
        Me.optItnFormatSeaChefsWith3LetterCode.Text = "Sea Chefs with 3 letter code"
        Me.optItnFormatSeaChefsWith3LetterCode.UseVisualStyleBackColor = True
        '
        'optItnFormatEuronav
        '
        Me.optItnFormatEuronav.AutoSize = True
        Me.optItnFormatEuronav.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatEuronav.Location = New System.Drawing.Point(130, 20)
        Me.optItnFormatEuronav.Name = "optItnFormatEuronav"
        Me.optItnFormatEuronav.Size = New System.Drawing.Size(65, 17)
        Me.optItnFormatEuronav.TabIndex = 6
        Me.optItnFormatEuronav.Text = "Euronav"
        Me.optItnFormatEuronav.UseVisualStyleBackColor = True
        '
        'optItnFormatSeaChefs
        '
        Me.optItnFormatSeaChefs.AutoSize = True
        Me.optItnFormatSeaChefs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatSeaChefs.Location = New System.Drawing.Point(17, 78)
        Me.optItnFormatSeaChefs.Name = "optItnFormatSeaChefs"
        Me.optItnFormatSeaChefs.Size = New System.Drawing.Size(74, 17)
        Me.optItnFormatSeaChefs.TabIndex = 2
        Me.optItnFormatSeaChefs.Text = "Sea Chefs"
        Me.optItnFormatSeaChefs.UseVisualStyleBackColor = True
        '
        'optItnFormatPlain
        '
        Me.optItnFormatPlain.AutoSize = True
        Me.optItnFormatPlain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatPlain.Location = New System.Drawing.Point(17, 49)
        Me.optItnFormatPlain.Name = "optItnFormatPlain"
        Me.optItnFormatPlain.Size = New System.Drawing.Size(48, 17)
        Me.optItnFormatPlain.TabIndex = 1
        Me.optItnFormatPlain.Text = "Plain"
        Me.optItnFormatPlain.UseVisualStyleBackColor = True
        '
        'optItnFormatDefault
        '
        Me.optItnFormatDefault.AutoSize = True
        Me.optItnFormatDefault.Checked = True
        Me.optItnFormatDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatDefault.Location = New System.Drawing.Point(17, 20)
        Me.optItnFormatDefault.Name = "optItnFormatDefault"
        Me.optItnFormatDefault.Size = New System.Drawing.Size(59, 17)
        Me.optItnFormatDefault.TabIndex = 0
        Me.optItnFormatDefault.TabStop = True
        Me.optItnFormatDefault.Text = "Default"
        Me.optItnFormatDefault.UseVisualStyleBackColor = True
        '
        'cmdItnExit
        '
        Me.cmdItnExit.Location = New System.Drawing.Point(844, 26)
        Me.cmdItnExit.Name = "cmdItnExit"
        Me.cmdItnExit.Size = New System.Drawing.Size(80, 21)
        Me.cmdItnExit.TabIndex = 30
        Me.cmdItnExit.Text = "Exit"
        Me.cmdItnExit.UseVisualStyleBackColor = True
        '
        'lstItnRemarks
        '
        Me.lstItnRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItnRemarks.CheckOnClick = True
        Me.lstItnRemarks.FormattingEnabled = True
        Me.lstItnRemarks.Location = New System.Drawing.Point(597, 71)
        Me.lstItnRemarks.Name = "lstItnRemarks"
        Me.lstItnRemarks.Size = New System.Drawing.Size(834, 124)
        Me.lstItnRemarks.TabIndex = 28
        '
        'fraItnAirportName
        '
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCityBoth)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCityName)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportBoth)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportname)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCode)
        Me.fraItnAirportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnAirportName.Location = New System.Drawing.Point(173, 64)
        Me.fraItnAirportName.Name = "fraItnAirportName"
        Me.fraItnAirportName.Size = New System.Drawing.Size(137, 134)
        Me.fraItnAirportName.TabIndex = 25
        Me.fraItnAirportName.TabStop = False
        Me.fraItnAirportName.Text = "Airport Name"
        '
        'optItnAirportCityBoth
        '
        Me.optItnAirportCityBoth.AutoSize = True
        Me.optItnAirportCityBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCityBoth.Location = New System.Drawing.Point(7, 88)
        Me.optItnAirportCityBoth.Name = "optItnAirportCityBoth"
        Me.optItnAirportCityBoth.Size = New System.Drawing.Size(109, 17)
        Me.optItnAirportCityBoth.TabIndex = 4
        Me.optItnAirportCityBoth.TabStop = True
        Me.optItnAirportCityBoth.Text = "Code / City Name"
        Me.optItnAirportCityBoth.UseVisualStyleBackColor = True
        '
        'optItnAirportCityName
        '
        Me.optItnAirportCityName.AutoSize = True
        Me.optItnAirportCityName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCityName.Location = New System.Drawing.Point(7, 71)
        Me.optItnAirportCityName.Name = "optItnAirportCityName"
        Me.optItnAirportCityName.Size = New System.Drawing.Size(92, 17)
        Me.optItnAirportCityName.TabIndex = 3
        Me.optItnAirportCityName.TabStop = True
        Me.optItnAirportCityName.Text = "Full City Name"
        Me.optItnAirportCityName.UseVisualStyleBackColor = True
        '
        'optItnAirportBoth
        '
        Me.optItnAirportBoth.AutoSize = True
        Me.optItnAirportBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportBoth.Location = New System.Drawing.Point(6, 54)
        Me.optItnAirportBoth.Name = "optItnAirportBoth"
        Me.optItnAirportBoth.Size = New System.Drawing.Size(122, 17)
        Me.optItnAirportBoth.TabIndex = 2
        Me.optItnAirportBoth.TabStop = True
        Me.optItnAirportBoth.Text = "Code / Airport Name"
        Me.optItnAirportBoth.UseVisualStyleBackColor = True
        '
        'optItnAirportname
        '
        Me.optItnAirportname.AutoSize = True
        Me.optItnAirportname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportname.Location = New System.Drawing.Point(6, 37)
        Me.optItnAirportname.Name = "optItnAirportname"
        Me.optItnAirportname.Size = New System.Drawing.Size(105, 17)
        Me.optItnAirportname.TabIndex = 1
        Me.optItnAirportname.TabStop = True
        Me.optItnAirportname.Text = "Full Airport Name"
        Me.optItnAirportname.UseVisualStyleBackColor = True
        '
        'optItnAirportCode
        '
        Me.optItnAirportCode.AutoSize = True
        Me.optItnAirportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCode.Location = New System.Drawing.Point(6, 20)
        Me.optItnAirportCode.Name = "optItnAirportCode"
        Me.optItnAirportCode.Size = New System.Drawing.Size(89, 17)
        Me.optItnAirportCode.TabIndex = 0
        Me.optItnAirportCode.TabStop = True
        Me.optItnAirportCode.Text = "3 Letter Code"
        Me.optItnAirportCode.UseVisualStyleBackColor = True
        '
        'fraItnOptions
        '
        Me.fraItnOptions.Controls.Add(Me.chkItnCO2)
        Me.fraItnOptions.Controls.Add(Me.chkItnEquipmentCode)
        Me.fraItnOptions.Controls.Add(Me.chkItnEMD)
        Me.fraItnOptions.Controls.Add(Me.chkItnItinRemarks)
        Me.fraItnOptions.Controls.Add(Me.chkItnCabinDescription)
        Me.fraItnOptions.Controls.Add(Me.chkItnCostCentre)
        Me.fraItnOptions.Controls.Add(Me.chkItnFlyingTime)
        Me.fraItnOptions.Controls.Add(Me.chkItnSeating)
        Me.fraItnOptions.Controls.Add(Me.chkItnStopovers)
        Me.fraItnOptions.Controls.Add(Me.chkItnTerminal)
        Me.fraItnOptions.Controls.Add(Me.chkItnPaxSegPerTicket)
        Me.fraItnOptions.Controls.Add(Me.chkItnTickets)
        Me.fraItnOptions.Controls.Add(Me.chkItnClass)
        Me.fraItnOptions.Controls.Add(Me.chkItnVessel)
        Me.fraItnOptions.Controls.Add(Me.chkItnAirlineLocator)
        Me.fraItnOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnOptions.Location = New System.Drawing.Point(173, 198)
        Me.fraItnOptions.Name = "fraItnOptions"
        Me.fraItnOptions.Size = New System.Drawing.Size(137, 393)
        Me.fraItnOptions.TabIndex = 27
        Me.fraItnOptions.TabStop = False
        Me.fraItnOptions.Text = "Options"
        '
        'chkItnCO2
        '
        Me.chkItnCO2.AutoSize = True
        Me.chkItnCO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnCO2.Location = New System.Drawing.Point(6, 338)
        Me.chkItnCO2.Name = "chkItnCO2"
        Me.chkItnCO2.Size = New System.Drawing.Size(47, 17)
        Me.chkItnCO2.TabIndex = 18
        Me.chkItnCO2.Text = "CO2"
        Me.chkItnCO2.UseVisualStyleBackColor = True
        '
        'chkItnEquipmentCode
        '
        Me.chkItnEquipmentCode.AutoSize = True
        Me.chkItnEquipmentCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnEquipmentCode.Location = New System.Drawing.Point(6, 315)
        Me.chkItnEquipmentCode.Name = "chkItnEquipmentCode"
        Me.chkItnEquipmentCode.Size = New System.Drawing.Size(104, 17)
        Me.chkItnEquipmentCode.TabIndex = 17
        Me.chkItnEquipmentCode.Text = "Equipment Code"
        Me.chkItnEquipmentCode.UseVisualStyleBackColor = True
        '
        'chkItnEMD
        '
        Me.chkItnEMD.AutoSize = True
        Me.chkItnEMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnEMD.Location = New System.Drawing.Point(6, 116)
        Me.chkItnEMD.Name = "chkItnEMD"
        Me.chkItnEMD.Size = New System.Drawing.Size(50, 17)
        Me.chkItnEMD.TabIndex = 16
        Me.chkItnEMD.Text = "EMD"
        Me.chkItnEMD.UseVisualStyleBackColor = True
        '
        'chkItnItinRemarks
        '
        Me.chkItnItinRemarks.AutoSize = True
        Me.chkItnItinRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnItinRemarks.Location = New System.Drawing.Point(6, 292)
        Me.chkItnItinRemarks.Name = "chkItnItinRemarks"
        Me.chkItnItinRemarks.Size = New System.Drawing.Size(121, 17)
        Me.chkItnItinRemarks.TabIndex = 15
        Me.chkItnItinRemarks.Text = "Itin.Remarks RIR RI"
        Me.chkItnItinRemarks.UseVisualStyleBackColor = True
        '
        'chkItnCabinDescription
        '
        Me.chkItnCabinDescription.AutoSize = True
        Me.chkItnCabinDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnCabinDescription.Location = New System.Drawing.Point(6, 270)
        Me.chkItnCabinDescription.Name = "chkItnCabinDescription"
        Me.chkItnCabinDescription.Size = New System.Drawing.Size(109, 17)
        Me.chkItnCabinDescription.TabIndex = 14
        Me.chkItnCabinDescription.Text = "Cabin Description"
        Me.chkItnCabinDescription.UseVisualStyleBackColor = True
        '
        'chkItnCostCentre
        '
        Me.chkItnCostCentre.AutoSize = True
        Me.chkItnCostCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnCostCentre.Location = New System.Drawing.Point(6, 248)
        Me.chkItnCostCentre.Name = "chkItnCostCentre"
        Me.chkItnCostCentre.Size = New System.Drawing.Size(81, 17)
        Me.chkItnCostCentre.TabIndex = 13
        Me.chkItnCostCentre.Text = "Cost Centre"
        Me.chkItnCostCentre.UseVisualStyleBackColor = True
        '
        'chkItnFlyingTime
        '
        Me.chkItnFlyingTime.AutoSize = True
        Me.chkItnFlyingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnFlyingTime.Location = New System.Drawing.Point(6, 226)
        Me.chkItnFlyingTime.Name = "chkItnFlyingTime"
        Me.chkItnFlyingTime.Size = New System.Drawing.Size(79, 17)
        Me.chkItnFlyingTime.TabIndex = 12
        Me.chkItnFlyingTime.Text = "Flying Time"
        Me.chkItnFlyingTime.UseVisualStyleBackColor = True
        '
        'chkItnSeating
        '
        Me.chkItnSeating.AutoSize = True
        Me.chkItnSeating.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnSeating.Location = New System.Drawing.Point(6, 160)
        Me.chkItnSeating.Name = "chkItnSeating"
        Me.chkItnSeating.Size = New System.Drawing.Size(118, 17)
        Me.chkItnSeating.TabIndex = 5
        Me.chkItnSeating.Text = "Seating assignment"
        Me.chkItnSeating.UseVisualStyleBackColor = True
        '
        'chkItnStopovers
        '
        Me.chkItnStopovers.AutoSize = True
        Me.chkItnStopovers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnStopovers.Location = New System.Drawing.Point(6, 204)
        Me.chkItnStopovers.Name = "chkItnStopovers"
        Me.chkItnStopovers.Size = New System.Drawing.Size(102, 17)
        Me.chkItnStopovers.TabIndex = 7
        Me.chkItnStopovers.Text = "Show stopovers"
        Me.chkItnStopovers.UseVisualStyleBackColor = True
        '
        'chkItnTerminal
        '
        Me.chkItnTerminal.AutoSize = True
        Me.chkItnTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnTerminal.Location = New System.Drawing.Point(6, 182)
        Me.chkItnTerminal.Name = "chkItnTerminal"
        Me.chkItnTerminal.Size = New System.Drawing.Size(92, 17)
        Me.chkItnTerminal.TabIndex = 6
        Me.chkItnTerminal.Text = "Show terminal"
        Me.chkItnTerminal.UseVisualStyleBackColor = True
        '
        'chkItnPaxSegPerTicket
        '
        Me.chkItnPaxSegPerTicket.AutoSize = True
        Me.chkItnPaxSegPerTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnPaxSegPerTicket.Location = New System.Drawing.Point(6, 138)
        Me.chkItnPaxSegPerTicket.Name = "chkItnPaxSegPerTicket"
        Me.chkItnPaxSegPerTicket.Size = New System.Drawing.Size(115, 17)
        Me.chkItnPaxSegPerTicket.TabIndex = 4
        Me.chkItnPaxSegPerTicket.Text = "Pax/Seg per ticket"
        Me.chkItnPaxSegPerTicket.UseVisualStyleBackColor = True
        '
        'chkItnTickets
        '
        Me.chkItnTickets.AutoSize = True
        Me.chkItnTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnTickets.Location = New System.Drawing.Point(6, 94)
        Me.chkItnTickets.Name = "chkItnTickets"
        Me.chkItnTickets.Size = New System.Drawing.Size(61, 17)
        Me.chkItnTickets.TabIndex = 3
        Me.chkItnTickets.Text = "Tickets"
        Me.chkItnTickets.UseVisualStyleBackColor = True
        '
        'chkItnClass
        '
        Me.chkItnClass.AutoSize = True
        Me.chkItnClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnClass.Location = New System.Drawing.Point(6, 50)
        Me.chkItnClass.Name = "chkItnClass"
        Me.chkItnClass.Size = New System.Drawing.Size(102, 17)
        Me.chkItnClass.TabIndex = 1
        Me.chkItnClass.Text = "Class of Service"
        Me.chkItnClass.UseVisualStyleBackColor = True
        '
        'chkItnVessel
        '
        Me.chkItnVessel.AutoSize = True
        Me.chkItnVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnVessel.Location = New System.Drawing.Point(6, 28)
        Me.chkItnVessel.Name = "chkItnVessel"
        Me.chkItnVessel.Size = New System.Drawing.Size(57, 17)
        Me.chkItnVessel.TabIndex = 0
        Me.chkItnVessel.Text = "Vessel"
        Me.chkItnVessel.UseVisualStyleBackColor = True
        '
        'chkItnAirlineLocator
        '
        Me.chkItnAirlineLocator.AutoSize = True
        Me.chkItnAirlineLocator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnAirlineLocator.Location = New System.Drawing.Point(6, 72)
        Me.chkItnAirlineLocator.Name = "chkItnAirlineLocator"
        Me.chkItnAirlineLocator.Size = New System.Drawing.Size(93, 17)
        Me.chkItnAirlineLocator.TabIndex = 2
        Me.chkItnAirlineLocator.Text = "Airline Locator"
        Me.chkItnAirlineLocator.UseVisualStyleBackColor = True
        '
        'rtbItnDoc
        '
        Me.rtbItnDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbItnDoc.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.rtbItnDoc.Location = New System.Drawing.Point(316, 214)
        Me.rtbItnDoc.Name = "rtbItnDoc"
        Me.rtbItnDoc.Size = New System.Drawing.Size(1115, 350)
        Me.rtbItnDoc.TabIndex = 29
        Me.rtbItnDoc.Text = ""
        '
        'txtItnPNR
        '
        Me.txtItnPNR.AcceptsReturn = True
        Me.txtItnPNR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtItnPNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtItnPNR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItnPNR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtItnPNR.Location = New System.Drawing.Point(17, 80)
        Me.txtItnPNR.MaxLength = 0
        Me.txtItnPNR.Multiline = True
        Me.txtItnPNR.Name = "txtItnPNR"
        Me.txtItnPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtItnPNR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtItnPNR.Size = New System.Drawing.Size(134, 468)
        Me.txtItnPNR.TabIndex = 24
        '
        'lblItnPNR
        '
        Me.lblItnPNR.BackColor = System.Drawing.Color.Yellow
        Me.lblItnPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnPNR.Location = New System.Drawing.Point(14, 64)
        Me.lblItnPNR.Name = "lblItnPNR"
        Me.lblItnPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnPNR.Size = New System.Drawing.Size(137, 13)
        Me.lblItnPNR.TabIndex = 23
        Me.lblItnPNR.Text = "PNR"
        Me.lblItnPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'menuITNSelectCopy
        '
        Me.menuITNSelectCopy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuCopyItn})
        Me.menuITNSelectCopy.Name = "menuSelectCopy"
        Me.menuITNSelectCopy.Size = New System.Drawing.Size(181, 48)
        '
        'MenuCopyItn
        '
        Me.MenuCopyItn.Name = "MenuCopyItn"
        Me.MenuCopyItn.Size = New System.Drawing.Size(180, 22)
        Me.MenuCopyItn.Text = "Copy Itinerary"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SSGDS, Me.SSPCC, Me.SSUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1472, 22)
        Me.StatusStrip1.TabIndex = 104
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SSGDS
        '
        Me.SSGDS.Name = "SSGDS"
        Me.SSGDS.Size = New System.Drawing.Size(29, 17)
        Me.SSGDS.Text = "GDS"
        '
        'SSPCC
        '
        Me.SSPCC.Name = "SSPCC"
        Me.SSPCC.Size = New System.Drawing.Size(30, 17)
        Me.SSPCC.Text = "PCC"
        '
        'SSUser
        '
        Me.SSUser.Name = "SSUser"
        Me.SSUser.Size = New System.Drawing.Size(30, 17)
        Me.SSUser.Text = "User"
        '
        'lblClient
        '
        Me.lblClient.BackColor = System.Drawing.Color.Yellow
        Me.lblClient.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblClient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClient.Location = New System.Drawing.Point(316, 198)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClient.Size = New System.Drawing.Size(1115, 13)
        Me.lblClient.TabIndex = 105
        Me.lblClient.Text = "Client"
        Me.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm03Itinerary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 626)
        Me.Controls.Add(Me.lblClient)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.fraGalileo)
        Me.Controls.Add(Me.fraAmadeus)
        Me.Controls.Add(Me.cmdItnFormatOSMLoG)
        Me.Controls.Add(Me.webItnDoc)
        Me.Controls.Add(Me.lblItnPNRCounter)
        Me.Controls.Add(Me.cmdItnRefresh)
        Me.Controls.Add(Me.fraItnFormat)
        Me.Controls.Add(Me.cmdItnExit)
        Me.Controls.Add(Me.lstItnRemarks)
        Me.Controls.Add(Me.fraItnAirportName)
        Me.Controls.Add(Me.fraItnOptions)
        Me.Controls.Add(Me.rtbItnDoc)
        Me.Controls.Add(Me.txtItnPNR)
        Me.Controls.Add(Me.lblItnPNR)
        Me.Name = "frm03Itinerary"
        Me.Text = "Itinerary"
        Me.fraGalileo.ResumeLayout(False)
        Me.fraAmadeus.ResumeLayout(False)
        Me.fraItnFormat.ResumeLayout(False)
        Me.fraItnFormat.PerformLayout()
        Me.fraItnAirportName.ResumeLayout(False)
        Me.fraItnAirportName.PerformLayout()
        Me.fraItnOptions.ResumeLayout(False)
        Me.fraItnOptions.PerformLayout()
        Me.menuITNSelectCopy.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fraGalileo As GroupBox
    Public WithEvents cmdItn1GReadPNR As Button
    Public WithEvents cmdItn1GReadCurrent As Button
    Friend WithEvents cmdItn1GReadQueue As Button
    Friend WithEvents fraAmadeus As GroupBox
    Public WithEvents cmdItn1AReadPNR As Button
    Public WithEvents cmdItn1AReadCurrent As Button
    Friend WithEvents cmdItn1AReadQueue As Button
    Friend WithEvents cmdItnFormatOSMLoG As Button
    Friend WithEvents webItnDoc As WebBrowser
    Public WithEvents lblItnPNRCounter As Label
    Friend WithEvents cmdItnRefresh As Button
    Friend WithEvents fraItnFormat As GroupBox
    Friend WithEvents optItnFormatAimeryMoxie As RadioButton
    Friend WithEvents optItnFormatFleet As RadioButton
    Friend WithEvents optItnFormatSeaChefsWith3LetterCode As RadioButton
    Friend WithEvents optItnFormatEuronav As RadioButton
    Friend WithEvents optItnFormatSeaChefs As RadioButton
    Friend WithEvents optItnFormatPlain As RadioButton
    Friend WithEvents optItnFormatDefault As RadioButton
    Friend WithEvents cmdItnExit As Button
    Friend WithEvents lstItnRemarks As CheckedListBox
    Friend WithEvents fraItnAirportName As GroupBox
    Friend WithEvents optItnAirportCityBoth As RadioButton
    Friend WithEvents optItnAirportCityName As RadioButton
    Friend WithEvents optItnAirportBoth As RadioButton
    Friend WithEvents optItnAirportname As RadioButton
    Friend WithEvents optItnAirportCode As RadioButton
    Friend WithEvents fraItnOptions As GroupBox
    Friend WithEvents chkItnCO2 As CheckBox
    Friend WithEvents chkItnEquipmentCode As CheckBox
    Friend WithEvents chkItnEMD As CheckBox
    Friend WithEvents chkItnItinRemarks As CheckBox
    Friend WithEvents chkItnCabinDescription As CheckBox
    Friend WithEvents chkItnCostCentre As CheckBox
    Friend WithEvents chkItnFlyingTime As CheckBox
    Friend WithEvents chkItnSeating As CheckBox
    Friend WithEvents chkItnStopovers As CheckBox
    Friend WithEvents chkItnTerminal As CheckBox
    Friend WithEvents chkItnPaxSegPerTicket As CheckBox
    Friend WithEvents chkItnTickets As CheckBox
    Friend WithEvents chkItnClass As CheckBox
    Friend WithEvents chkItnVessel As CheckBox
    Friend WithEvents chkItnAirlineLocator As CheckBox
    Friend WithEvents rtbItnDoc As RichTextBox
    Public WithEvents txtItnPNR As TextBox
    Public WithEvents lblItnPNR As Label
    Friend WithEvents menuITNSelectCopy As ContextMenuStrip
    Friend WithEvents MenuCopyItn As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SSGDS As ToolStripStatusLabel
    Friend WithEvents SSPCC As ToolStripStatusLabel
    Friend WithEvents SSUser As ToolStripStatusLabel
    Public WithEvents lblClient As Label
End Class
