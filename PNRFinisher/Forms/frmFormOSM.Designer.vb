<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormOSM
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
        Me.chkOSMFullPaxSDetails = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOSMVesselGroup = New System.Windows.Forms.ComboBox()
        Me.chkOSMVesselInUse = New System.Windows.Forms.CheckBox()
        Me.lblOSMMultipleSearchSeparator = New System.Windows.Forms.Label()
        Me.txtOSMAgentsFilter = New System.Windows.Forms.TextBox()
        Me.cmdOSMClearSelected = New System.Windows.Forms.Button()
        Me.cmdOSMEmailClear = New System.Windows.Forms.Button()
        Me.webOSMDoc = New System.Windows.Forms.WebBrowser()
        Me.lstOSMVessels = New System.Windows.Forms.ListBox()
        Me.cmdOSMCopyDocument = New System.Windows.Forms.Button()
        Me.cmdOSMPrepareDoc = New System.Windows.Forms.Button()
        Me.dgvOSMPax = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nationality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JoinerLeaver = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VisaType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblOSMPasteEmailsHere = New System.Windows.Forms.Label()
        Me.txtOSMPax = New System.Windows.Forms.TextBox()
        Me.cmdOSMVesselsEdit = New System.Windows.Forms.Button()
        Me.lblOSMVessels = New System.Windows.Forms.Label()
        Me.cmdOSMAgentEdit = New System.Windows.Forms.Button()
        Me.lstOSMAgents = New System.Windows.Forms.ListBox()
        Me.cmdOSMCopyCC = New System.Windows.Forms.Button()
        Me.cmdOSMCopyTo = New System.Windows.Forms.Button()
        Me.lblOSMEmailsCC = New System.Windows.Forms.Label()
        Me.lblOSMEmailsTo = New System.Windows.Forms.Label()
        Me.lstOSMCCEmail = New System.Windows.Forms.ListBox()
        Me.lstOSMToEmail = New System.Windows.Forms.ListBox()
        Me.cmdOSMRefresh = New System.Windows.Forms.Button()
        Me.lblOSMVessel = New System.Windows.Forms.Label()
        Me.ttpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvOSMPax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkOSMFullPaxSDetails
        '
        Me.chkOSMFullPaxSDetails.AutoSize = True
        Me.chkOSMFullPaxSDetails.Location = New System.Drawing.Point(756, 451)
        Me.chkOSMFullPaxSDetails.Name = "chkOSMFullPaxSDetails"
        Me.chkOSMFullPaxSDetails.Size = New System.Drawing.Size(126, 17)
        Me.chkOSMFullPaxSDetails.TabIndex = 54
        Me.chkOSMFullPaxSDetails.Text = "Show Full Pax details"
        Me.chkOSMFullPaxSDetails.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Vessel Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbOSMVesselGroup
        '
        Me.cmbOSMVesselGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOSMVesselGroup.FormattingEnabled = True
        Me.cmbOSMVesselGroup.Location = New System.Drawing.Point(19, 105)
        Me.cmbOSMVesselGroup.Name = "cmbOSMVesselGroup"
        Me.cmbOSMVesselGroup.Size = New System.Drawing.Size(193, 21)
        Me.cmbOSMVesselGroup.TabIndex = 52
        '
        'chkOSMVesselInUse
        '
        Me.chkOSMVesselInUse.AutoSize = True
        Me.chkOSMVesselInUse.Checked = True
        Me.chkOSMVesselInUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOSMVesselInUse.Location = New System.Drawing.Point(19, 159)
        Me.chkOSMVesselInUse.Name = "chkOSMVesselInUse"
        Me.chkOSMVesselInUse.Size = New System.Drawing.Size(81, 17)
        Me.chkOSMVesselInUse.TabIndex = 51
        Me.chkOSMVesselInUse.Text = "In Use Only"
        Me.chkOSMVesselInUse.UseVisualStyleBackColor = True
        '
        'lblOSMMultipleSearchSeparator
        '
        Me.lblOSMMultipleSearchSeparator.AutoSize = True
        Me.lblOSMMultipleSearchSeparator.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMMultipleSearchSeparator.Location = New System.Drawing.Point(218, 355)
        Me.lblOSMMultipleSearchSeparator.Name = "lblOSMMultipleSearchSeparator"
        Me.lblOSMMultipleSearchSeparator.Size = New System.Drawing.Size(112, 9)
        Me.lblOSMMultipleSearchSeparator.TabIndex = 50
        Me.lblOSMMultipleSearchSeparator.Text = "Multiple search separated with |"
        '
        'txtOSMAgentsFilter
        '
        Me.txtOSMAgentsFilter.Location = New System.Drawing.Point(218, 332)
        Me.txtOSMAgentsFilter.Name = "txtOSMAgentsFilter"
        Me.txtOSMAgentsFilter.Size = New System.Drawing.Size(166, 20)
        Me.txtOSMAgentsFilter.TabIndex = 49
        '
        'cmdOSMClearSelected
        '
        Me.cmdOSMClearSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOSMClearSelected.Location = New System.Drawing.Point(19, 585)
        Me.cmdOSMClearSelected.Name = "cmdOSMClearSelected"
        Me.cmdOSMClearSelected.Size = New System.Drawing.Size(483, 30)
        Me.cmdOSMClearSelected.TabIndex = 48
        Me.cmdOSMClearSelected.Text = "Clear Selected Vessel(s) and/or Agent(s)"
        Me.cmdOSMClearSelected.UseVisualStyleBackColor = True
        '
        'cmdOSMEmailClear
        '
        Me.cmdOSMEmailClear.BackColor = System.Drawing.Color.Red
        Me.cmdOSMEmailClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOSMEmailClear.Location = New System.Drawing.Point(769, 92)
        Me.cmdOSMEmailClear.Name = "cmdOSMEmailClear"
        Me.cmdOSMEmailClear.Size = New System.Drawing.Size(21, 13)
        Me.cmdOSMEmailClear.TabIndex = 42
        Me.cmdOSMEmailClear.Text = "X"
        Me.cmdOSMEmailClear.UseVisualStyleBackColor = False
        '
        'webOSMDoc
        '
        Me.webOSMDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webOSMDoc.Location = New System.Drawing.Point(509, 475)
        Me.webOSMDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webOSMDoc.Name = "webOSMDoc"
        Me.webOSMDoc.Size = New System.Drawing.Size(911, 140)
        Me.webOSMDoc.TabIndex = 47
        '
        'lstOSMVessels
        '
        Me.lstOSMVessels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMVessels.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstOSMVessels.FormattingEnabled = True
        Me.lstOSMVessels.Location = New System.Drawing.Point(19, 184)
        Me.lstOSMVessels.Name = "lstOSMVessels"
        Me.lstOSMVessels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstOSMVessels.Size = New System.Drawing.Size(193, 368)
        Me.lstOSMVessels.TabIndex = 32
        '
        'cmdOSMCopyDocument
        '
        Me.cmdOSMCopyDocument.Enabled = False
        Me.cmdOSMCopyDocument.Location = New System.Drawing.Point(628, 443)
        Me.cmdOSMCopyDocument.Name = "cmdOSMCopyDocument"
        Me.cmdOSMCopyDocument.Size = New System.Drawing.Size(113, 30)
        Me.cmdOSMCopyDocument.TabIndex = 46
        Me.cmdOSMCopyDocument.Text = "Copy Document"
        Me.cmdOSMCopyDocument.UseVisualStyleBackColor = True
        '
        'cmdOSMPrepareDoc
        '
        Me.cmdOSMPrepareDoc.Location = New System.Drawing.Point(509, 443)
        Me.cmdOSMPrepareDoc.Name = "cmdOSMPrepareDoc"
        Me.cmdOSMPrepareDoc.Size = New System.Drawing.Size(113, 30)
        Me.cmdOSMPrepareDoc.TabIndex = 45
        Me.cmdOSMPrepareDoc.Text = "Prepare Document"
        Me.cmdOSMPrepareDoc.UseVisualStyleBackColor = True
        '
        'dgvOSMPax
        '
        Me.dgvOSMPax.AllowUserToAddRows = False
        Me.dgvOSMPax.AllowUserToDeleteRows = False
        Me.dgvOSMPax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOSMPax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOSMPax.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LastName, Me.FirstName, Me.Nationality, Me.JoinerLeaver, Me.VisaType})
        Me.dgvOSMPax.Location = New System.Drawing.Point(812, 105)
        Me.dgvOSMPax.Name = "dgvOSMPax"
        Me.dgvOSMPax.Size = New System.Drawing.Size(647, 332)
        Me.dgvOSMPax.TabIndex = 44
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        '
        'LastName
        '
        Me.LastName.HeaderText = "LastName"
        Me.LastName.Name = "LastName"
        '
        'FirstName
        '
        Me.FirstName.HeaderText = "FirstName"
        Me.FirstName.Name = "FirstName"
        '
        'Nationality
        '
        Me.Nationality.HeaderText = "Nationality"
        Me.Nationality.Name = "Nationality"
        '
        'JoinerLeaver
        '
        Me.JoinerLeaver.HeaderText = "JoinerLeaver"
        Me.JoinerLeaver.Items.AddRange(New Object() {"Joiner", "Homegoing"})
        Me.JoinerLeaver.Name = "JoinerLeaver"
        '
        'VisaType
        '
        Me.VisaType.HeaderText = "VisaType"
        Me.VisaType.Items.AddRange(New Object() {"Visa required", "OKTB", "No Visa required"})
        Me.VisaType.Name = "VisaType"
        '
        'lblOSMPasteEmailsHere
        '
        Me.lblOSMPasteEmailsHere.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblOSMPasteEmailsHere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMPasteEmailsHere.Location = New System.Drawing.Point(510, 92)
        Me.lblOSMPasteEmailsHere.Name = "lblOSMPasteEmailsHere"
        Me.lblOSMPasteEmailsHere.Size = New System.Drawing.Size(262, 13)
        Me.lblOSMPasteEmailsHere.TabIndex = 41
        Me.lblOSMPasteEmailsHere.Text = "PASTE OSM EMAIL HERE"
        Me.lblOSMPasteEmailsHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOSMPax
        '
        Me.txtOSMPax.AllowDrop = True
        Me.txtOSMPax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtOSMPax.Font = New System.Drawing.Font("Courier New", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtOSMPax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOSMPax.Location = New System.Drawing.Point(508, 105)
        Me.txtOSMPax.Multiline = True
        Me.txtOSMPax.Name = "txtOSMPax"
        Me.txtOSMPax.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOSMPax.Size = New System.Drawing.Size(282, 332)
        Me.txtOSMPax.TabIndex = 43
        '
        'cmdOSMVesselsEdit
        '
        Me.cmdOSMVesselsEdit.Location = New System.Drawing.Point(114, 156)
        Me.cmdOSMVesselsEdit.Name = "cmdOSMVesselsEdit"
        Me.cmdOSMVesselsEdit.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMVesselsEdit.TabIndex = 31
        Me.cmdOSMVesselsEdit.Text = "Edit Vessels"
        Me.cmdOSMVesselsEdit.UseVisualStyleBackColor = True
        '
        'lblOSMVessels
        '
        Me.lblOSMVessels.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMVessels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMVessels.Location = New System.Drawing.Point(19, 135)
        Me.lblOSMVessels.Name = "lblOSMVessels"
        Me.lblOSMVessels.Size = New System.Drawing.Size(193, 13)
        Me.lblOSMVessels.TabIndex = 30
        Me.lblOSMVessels.Text = "Vessels"
        Me.lblOSMVessels.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdOSMAgentEdit
        '
        Me.cmdOSMAgentEdit.Location = New System.Drawing.Point(405, 343)
        Me.cmdOSMAgentEdit.Name = "cmdOSMAgentEdit"
        Me.cmdOSMAgentEdit.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMAgentEdit.TabIndex = 39
        Me.cmdOSMAgentEdit.Text = "Edit Agents"
        Me.cmdOSMAgentEdit.UseVisualStyleBackColor = True
        '
        'lstOSMAgents
        '
        Me.lstOSMAgents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMAgents.FormattingEnabled = True
        Me.lstOSMAgents.Location = New System.Drawing.Point(218, 366)
        Me.lstOSMAgents.Name = "lstOSMAgents"
        Me.lstOSMAgents.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstOSMAgents.Size = New System.Drawing.Size(285, 186)
        Me.lstOSMAgents.TabIndex = 40
        '
        'cmdOSMCopyCC
        '
        Me.cmdOSMCopyCC.Enabled = False
        Me.cmdOSMCopyCC.Location = New System.Drawing.Point(405, 203)
        Me.cmdOSMCopyCC.Name = "cmdOSMCopyCC"
        Me.cmdOSMCopyCC.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMCopyCC.TabIndex = 37
        Me.cmdOSMCopyCC.Text = "Copy CC"
        Me.cmdOSMCopyCC.UseVisualStyleBackColor = True
        '
        'cmdOSMCopyTo
        '
        Me.cmdOSMCopyTo.Enabled = False
        Me.cmdOSMCopyTo.Location = New System.Drawing.Point(404, 84)
        Me.cmdOSMCopyTo.Name = "cmdOSMCopyTo"
        Me.cmdOSMCopyTo.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMCopyTo.TabIndex = 34
        Me.cmdOSMCopyTo.Text = "Copy TO"
        Me.cmdOSMCopyTo.UseVisualStyleBackColor = True
        '
        'lblOSMEmailsCC
        '
        Me.lblOSMEmailsCC.AutoSize = True
        Me.lblOSMEmailsCC.Location = New System.Drawing.Point(218, 203)
        Me.lblOSMEmailsCC.Name = "lblOSMEmailsCC"
        Me.lblOSMEmailsCC.Size = New System.Drawing.Size(53, 13)
        Me.lblOSMEmailsCC.TabIndex = 36
        Me.lblOSMEmailsCC.Text = "emails CC"
        '
        'lblOSMEmailsTo
        '
        Me.lblOSMEmailsTo.AutoSize = True
        Me.lblOSMEmailsTo.Location = New System.Drawing.Point(218, 84)
        Me.lblOSMEmailsTo.Name = "lblOSMEmailsTo"
        Me.lblOSMEmailsTo.Size = New System.Drawing.Size(54, 13)
        Me.lblOSMEmailsTo.TabIndex = 33
        Me.lblOSMEmailsTo.Text = "emails TO"
        '
        'lstOSMCCEmail
        '
        Me.lstOSMCCEmail.FormattingEnabled = True
        Me.lstOSMCCEmail.Location = New System.Drawing.Point(218, 222)
        Me.lstOSMCCEmail.Name = "lstOSMCCEmail"
        Me.lstOSMCCEmail.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstOSMCCEmail.Size = New System.Drawing.Size(285, 82)
        Me.lstOSMCCEmail.TabIndex = 38
        '
        'lstOSMToEmail
        '
        Me.lstOSMToEmail.FormattingEnabled = True
        Me.lstOSMToEmail.Location = New System.Drawing.Point(218, 105)
        Me.lstOSMToEmail.Name = "lstOSMToEmail"
        Me.lstOSMToEmail.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstOSMToEmail.Size = New System.Drawing.Size(285, 82)
        Me.lstOSMToEmail.TabIndex = 35
        '
        'cmdOSMRefresh
        '
        Me.cmdOSMRefresh.Location = New System.Drawing.Point(15, 51)
        Me.cmdOSMRefresh.Name = "cmdOSMRefresh"
        Me.cmdOSMRefresh.Size = New System.Drawing.Size(70, 22)
        Me.cmdOSMRefresh.TabIndex = 29
        Me.cmdOSMRefresh.Text = "Refresh"
        Me.cmdOSMRefresh.UseVisualStyleBackColor = True
        '
        'lblOSMVessel
        '
        Me.lblOSMVessel.AutoSize = True
        Me.lblOSMVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMVessel.Location = New System.Drawing.Point(218, 56)
        Me.lblOSMVessel.Name = "lblOSMVessel"
        Me.lblOSMVessel.Size = New System.Drawing.Size(0, 13)
        Me.lblOSMVessel.TabIndex = 55
        '
        'frmFormOSM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1474, 665)
        Me.Controls.Add(Me.lblOSMVessel)
        Me.Controls.Add(Me.chkOSMFullPaxSDetails)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbOSMVesselGroup)
        Me.Controls.Add(Me.chkOSMVesselInUse)
        Me.Controls.Add(Me.lblOSMMultipleSearchSeparator)
        Me.Controls.Add(Me.txtOSMAgentsFilter)
        Me.Controls.Add(Me.cmdOSMClearSelected)
        Me.Controls.Add(Me.cmdOSMEmailClear)
        Me.Controls.Add(Me.webOSMDoc)
        Me.Controls.Add(Me.lstOSMVessels)
        Me.Controls.Add(Me.cmdOSMCopyDocument)
        Me.Controls.Add(Me.cmdOSMPrepareDoc)
        Me.Controls.Add(Me.dgvOSMPax)
        Me.Controls.Add(Me.lblOSMPasteEmailsHere)
        Me.Controls.Add(Me.txtOSMPax)
        Me.Controls.Add(Me.cmdOSMVesselsEdit)
        Me.Controls.Add(Me.lblOSMVessels)
        Me.Controls.Add(Me.cmdOSMAgentEdit)
        Me.Controls.Add(Me.lstOSMAgents)
        Me.Controls.Add(Me.cmdOSMCopyCC)
        Me.Controls.Add(Me.cmdOSMCopyTo)
        Me.Controls.Add(Me.lblOSMEmailsCC)
        Me.Controls.Add(Me.lblOSMEmailsTo)
        Me.Controls.Add(Me.lstOSMCCEmail)
        Me.Controls.Add(Me.lstOSMToEmail)
        Me.Controls.Add(Me.cmdOSMRefresh)
        Me.MinimumSize = New System.Drawing.Size(1490, 704)
        Me.Name = "frmFormOSM"
        Me.Text = "OSM"
        CType(Me.dgvOSMPax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkOSMFullPaxSDetails As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbOSMVesselGroup As ComboBox
    Friend WithEvents chkOSMVesselInUse As CheckBox
    Friend WithEvents lblOSMMultipleSearchSeparator As Label
    Friend WithEvents txtOSMAgentsFilter As TextBox
    Friend WithEvents cmdOSMClearSelected As Button
    Friend WithEvents cmdOSMEmailClear As Button
    Friend WithEvents webOSMDoc As WebBrowser
    Friend WithEvents lstOSMVessels As ListBox
    Friend WithEvents cmdOSMCopyDocument As Button
    Friend WithEvents cmdOSMPrepareDoc As Button
    Friend WithEvents dgvOSMPax As DataGridView
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents LastName As DataGridViewTextBoxColumn
    Friend WithEvents FirstName As DataGridViewTextBoxColumn
    Friend WithEvents Nationality As DataGridViewTextBoxColumn
    Friend WithEvents JoinerLeaver As DataGridViewComboBoxColumn
    Friend WithEvents VisaType As DataGridViewComboBoxColumn
    Friend WithEvents lblOSMPasteEmailsHere As Label
    Friend WithEvents txtOSMPax As TextBox
    Friend WithEvents cmdOSMVesselsEdit As Button
    Friend WithEvents lblOSMVessels As Label
    Friend WithEvents cmdOSMAgentEdit As Button
    Friend WithEvents lstOSMAgents As ListBox
    Friend WithEvents cmdOSMCopyCC As Button
    Friend WithEvents cmdOSMCopyTo As Button
    Friend WithEvents lblOSMEmailsCC As Label
    Friend WithEvents lblOSMEmailsTo As Label
    Friend WithEvents lstOSMCCEmail As ListBox
    Friend WithEvents lstOSMToEmail As ListBox
    Friend WithEvents cmdOSMRefresh As Button
    Friend WithEvents lblOSMVessel As Label
    Friend WithEvents ttpToolTip As ToolTip
End Class
