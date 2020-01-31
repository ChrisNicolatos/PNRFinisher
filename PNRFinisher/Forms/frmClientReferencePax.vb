Option Strict On
Option Explicit On
Public Class frmClientReferencePax
    Private mTitle As String
    Private mCombo As ComboBox
    Private mReferences As Dictionary(Of Integer, ClientReferencePax)
    Private mCombos() As ComboBox
    Private mLabels() As Label
    Public Sub New(ByVal pTitle As String, ByVal pPax As GDSPaxCollection, ByVal pCombo As ComboBox)

        ' This call is required by the designer.
        InitializeComponent()
        mCombos = New ComboBox() {cmbPax1, cmbPax2, cmbPax3, cmbPax4, cmbPax5, cmbPax6, cmbPax7, cmbPax8, cmbPax9}
        For Each pItem As ComboBox In mCombos
            AddHandler pItem.TextChanged, AddressOf ComboBoxUserInput
            AddHandler pItem.SelectedIndexChanged, AddressOf ComboBoxUserInput
        Next
        mLabels = New Label() {lblPax1, lblPax2, lblPax3, lblPax4, lblPax5, lblPax6, lblPax7, lblPax8, lblPax9}
        ' Add any initialization after the InitializeComponent() call.

        mTitle = pTitle
        mCombo = pCombo
        mReferences = New Dictionary(Of Integer, ClientReferencePax)
        For Each pItem As GDSPaxItem In pPax.Values
            mReferences.Add(pItem.ElementNo, New ClientReferencePax(pItem.ElementNo, pItem.PaxName))
        Next

    End Sub
    Public Property PaxReferences As Dictionary(Of Integer, ClientReferencePax)
        Get
            Return mReferences
        End Get
        Set(value As Dictionary(Of Integer, ClientReferencePax))
            mReferences = value
        End Set
    End Property
    Private Sub frmClientReferencePax_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            PrepareForm()
        Catch ex As Exception
            Throw New Exception("frmClientReferencePax()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PrepareForm()
        lblClientReference.Text = mTitle

        Dim pComboIndex As Integer = -1
        For Each pItem As ClientReferencePax In mReferences.Values
            pComboIndex += 1
            mLabels(pComboIndex).Text = pItem.PaxName
            mLabels(pComboIndex).Visible = True
            mCombos(pComboIndex).DropDownStyle = mCombo.DropDownStyle
            mCombos(pComboIndex).Tag = pItem.ElementID
            mCombos(pComboIndex).Items.Clear()
            For Each pCItem In mCombo.Items
                mCombos(pComboIndex).Items.Add(pCItem)
            Next
        Next
        For i As Integer = pComboIndex + 1 To mCombos.GetUpperBound(0)
            mCombos(i).Visible = False
            mLabels(i).Visible = False
        Next

        cmdSave.Enabled = False
        cmdCancel.Enabled = True
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBoxUserInput(sender As Object, e As EventArgs)
        'mReferences.Clear()
        cmdSave.Enabled = True
        For i = 0 To mCombos.GetUpperBound(0)
            If mCombos(i).Visible Then
                mReferences.Item(CInt(mCombos(i).Tag)).Reference = mCombos(i).Text.Trim
                cmdSave.Enabled = cmdSave.Enabled And (mReferences.Item(CInt(mCombos(i).Tag)).Reference <> "")
            End If
        Next

    End Sub

End Class