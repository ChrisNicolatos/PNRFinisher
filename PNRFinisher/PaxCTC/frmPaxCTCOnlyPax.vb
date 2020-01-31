Public Class frmPaxCTCOnlyPax
    Private mobjPNR As GDSReadPNR
    Private mintBackOffice As Integer = 0
    Private mintClientId As Integer = 0
    Private mstrClientCode As String = ""
    Private mstrClientName As String = ""
    Private mstrVesselName As String = ""
    Private WithEvents mobjCTCPaxCollection As New CTCPaxCollection
    Public Sub ShowPaxInformation(ByVal mPNR As GDSReadPNR, ByVal pBackOfficeID As Integer, ByVal pClientID As Integer, ByVal pClientCode As String, ByVal pClientName As String, ByVal pVesselName As String)
        mintBackOffice = pBackOfficeID
        mintClientId = pClientID
        mstrClientCode = pClientCode
        mstrClientName = pClientName
        mstrVesselName = pVesselName

        mobjPNR = mPNR
        mobjCTCPaxCollection.Load(mintBackOffice, mintClientId)
        DisplayPax()

    End Sub
    Private Sub DisplayPax()

        lblClientCode.Text = mstrClientCode
        lblClientName.Text = mstrClientName
        lblVessel.Text = mstrVesselName
        dgvPax.Rows.Clear()
        For Each pPax As GDSPaxItem In mobjPNR.Passengers.Values
            Dim pId As Integer = 0
            Dim pLastName As New DataGridViewTextBoxCell With {
                .Value = pPax.LastName}
            Dim pFirstName As New DataGridViewTextBoxCell With {
                .Value = pPax.FirstName}
            Dim pEMail As New DataGridViewTextBoxCell With {
                .Value = ""}
            Dim pMobile As New DataGridViewTextBoxCell With {
                .Value = ""}
            Dim pRefused As New DataGridViewCheckBoxCell With {
                .Value = False}
            For Each pCTCPax As CTCPax In mobjCTCPaxCollection.Values
                If pCTCPax.Lastname = pPax.LastName And pCTCPax.FirstName = pPax.FirstName Then
                    pId = pCTCPax.Id
                    pEMail.Value = pCTCPax.Email
                    pMobile.Value = pCTCPax.Mobile
                    pRefused.Value = pCTCPax.Refused
                    Exit For
                End If
            Next
            Dim pRow As New DataGridViewRow With {
                .Tag = pId} ' pPax.ElementNo}
            pRow.Cells.Add(pLastName)
            pRow.Cells.Add(pFirstName)
            pRow.Cells.Add(pEMail)
            pRow.Cells.Add(pMobile)
            pRow.Cells.Add(pRefused)
            dgvPax.Rows.Add(pRow)
        Next
    End Sub

    Private Sub dgvPax_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPax.CellValueChanged
        If e.RowIndex > -1 AndAlso Not dgvPax.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
            dgvPax.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dgvPax.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.ToUpper
        End If
    End Sub
    Private Sub dgvPax_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPax.RowValidating
        mobjCTCPaxCollection.AmendItem(dgvPax.Rows(e.RowIndex).Tag, mstrVesselName, dgvPax.Rows(e.RowIndex).Cells(0).Value, dgvPax.Rows(e.RowIndex).Cells(1).Value, dgvPax.Rows(e.RowIndex).Cells(2).Value, dgvPax.Rows(e.RowIndex).Cells(3).Value, dgvPax.Rows(e.RowIndex).Cells(4).Value)
        ValidatePaxOptions(dgvPax.Rows(e.RowIndex))
    End Sub
    Private Sub frmPaxCTCOnlyPax_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmdUpdate.Enabled = False
    End Sub
    Private Sub dgvPax_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPax.CellValidating
        If e.ColumnIndex > 1 Then
            If Not dgvPax.Rows(e.RowIndex).Tag Is Nothing Then
                If Not mobjCTCPaxCollection.ContainsKey(dgvPax.Rows(e.RowIndex).Tag) Then
                    mobjCTCPaxCollection.AddNewItem(dgvPax.Rows(e.RowIndex).Tag)
                End If
                If dgvPax.Columns(e.ColumnIndex).Name = "Email" Then
                    mobjCTCPaxCollection(dgvPax.Rows(e.RowIndex).Tag).Email = e.FormattedValue
                ElseIf dgvPax.Columns(e.ColumnIndex).Name = "Mobile" Then
                    mobjCTCPaxCollection(dgvPax.Rows(e.RowIndex).Tag).Mobile = e.FormattedValue
                ElseIf dgvPax.Columns(e.ColumnIndex).Name = "Refused" Then
                    mobjCTCPaxCollection(dgvPax.Rows(e.RowIndex).Tag).Refused = e.FormattedValue
                End If
                ValidatePaxOptions(dgvPax.Rows(e.RowIndex))
            End If
        End If
    End Sub
    Private Sub ValidatePaxOptions(ByRef pRow As DataGridViewRow)
        Dim pEmail As String = ""
        Dim pMobile As String = ""
        Dim pRefused As Boolean = False

        If Not pRow.Cells("Email").Value Is Nothing Then
            pEmail = pRow.Cells("Email").Value.ToString.Trim
        End If
        If Not pRow.Cells("Mobile").Value Is Nothing Then
            pMobile = pRow.Cells("Mobile").Value.ToString.Trim
        End If
        If Not pRow.Cells("Refused").Value Is Nothing Then
            pRefused = pRow.Cells("Refused").Value
        End If

        Dim pEMailValid As Boolean = (pEmail = "" OrElse System.Text.RegularExpressions.Regex.IsMatch(pEmail, "(?i)^(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+\/=\?\^`{}|~\w])*)(?<=[0-9a-z])@)(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][-a-z0-9]{0,22}[a-z0-9])$"))
        Dim pMobileValid As Boolean = (pMobile = "" OrElse IsNumeric(pMobile))
        Dim pRefusedValid As Boolean = ((pRefused And pEmail = "" And pMobile = "") Or (Not pRefused And (pEmail <> "" Or pMobile <> "")))
        Dim pRowValid As Boolean = pEMailValid And pMobileValid And pRefusedValid

        If pRowValid Then
            pRow.ErrorText = ""
            cmdUpdate.Enabled = True
        Else
            Dim pText As String = ""
            If Not pEMailValid Then pText &= "Invalid email" & vbCrLf
            If Not pMobileValid Then pText &= "Invalid mobile" & vbCrLf
            If Not pRefusedValid Then pText &= "Invalid Refused option"
            pRow.ErrorText = pText
            cmdUpdate.Enabled = False
        End If
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        mobjCTCPaxCollection.Update()
    End Sub
    Private Sub mobjCTCPaxCollection_isDirty() Handles mobjCTCPaxCollection.isDirty
        Dim i As Integer = 1
    End Sub
    Private Sub mobjCTCPaxCollection_isValid() Handles mobjCTCPaxCollection.isValid
        Dim i As Integer = 1
    End Sub
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class