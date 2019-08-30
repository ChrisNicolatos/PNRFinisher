Option Strict On
Option Explicit On
Public Class frmCostCentre

    Private mintBackOffice As Integer
    Private mobjCustomers As CustomerCollection
    Private mobjCustomerGroups As CustomerGroupCollection
    Private SearchString As String = ""
    Private mflgLoading As Boolean = False
    Private mobjCustomerSelected As CustomerItem
    Private mobjCustomerGroupSelected As CustomerGroupItem
    Private mobjCostCentres As New CostCentreLookupCollection

    Private mSearchString As String = ""

    Private mCodeSelected As String = ""
    Private mVesselSelected As String = ""
    Private mCostCentreSelected As String = ""
    Public Sub New(ByVal pBackOffice As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mintBackOffice = pBackOffice

    End Sub
    Public ReadOnly Property CodeSelected As String
        Get
            Return mCodeSelected
        End Get
    End Property
    Public ReadOnly Property VesselSelected As String
        Get
            Return mVesselSelected
        End Get
    End Property
    Public ReadOnly Property CostCentreSelected As String
        Get
            Return mCostCentreSelected
        End Get
    End Property
    Private Sub frmCostCentre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            mflgLoading = True
            SearchString = ""
            mCodeSelected = ""
            mVesselSelected = ""
            mCostCentreSelected = ""
            LoadCustomers()
            LoadCustomerGroups()
        Catch ex As Exception

        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub LoadCustomers()

        mobjCustomers = New CustomerCollection
        mobjCustomers.Load("", mintBackOffice)
        lstCustomers.Items.Clear()
        For Each pCustomer As CustomerItem In mobjCustomers.Values
            If SearchString = "" Or pCustomer.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                lstCustomers.Items.Add(pCustomer)
            End If
        Next

    End Sub

    Private Sub txtCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtCustomer.TextChanged

        If Not mflgLoading Then
            PopulateCustomerList(txtCustomer.Text)
        End If

    End Sub

    Private Sub PopulateCustomerList(ByVal pSearchString As String)

        mobjCustomers.Load(pSearchString, mintBackOffice)

        lstCustomers.Items.Clear()
        For Each pCustomer As CustomerItem In mobjCustomers.Values
            If pSearchString = "" Or pCustomer.ToString.ToUpper.Contains(pSearchString.ToUpper) Then
                lstCustomers.Items.Add(pCustomer)
            End If
        Next

        If lstCustomers.Items.Count = 1 Then
            Try
                mflgLoading = True

                SelectCustomer(CType(lstCustomers.Items(0), CustomerItem))
                txtCustomer.Text = lstCustomers.Items(0).ToString
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                mflgLoading = False
            End Try
        End If

    End Sub

    Private Sub SelectCustomer(ByVal pCustomer As CustomerItem)
        'TODO
        mobjCustomerSelected = pCustomer
        txtCustomer.Text = pCustomer.ToString

        mobjCostCentres.LoadCustomer(mobjCustomerSelected.ID, mintBackOffice)
        PopulateCostCentres()

        SetEnabled()

    End Sub
    Private Sub PopulateCostCentres()

        With dgvCostCentres
            .Rows.Clear()
            .Columns.Clear()
            Dim pCode As New DataGridViewTextBoxColumn
            Dim pOldCode As New DataGridViewTextBoxColumn
            Dim pName As New DataGridViewTextBoxColumn
            Dim pLogo As New DataGridViewTextBoxColumn
            Dim pCostCentre As New DataGridViewTextBoxColumn
            Dim pVessel As New DataGridViewTextBoxColumn
            .Columns.Add(pCostCentre)
            .Columns.Add(pVessel)
            .Columns.Add(pCode)
            .Columns.Add(pOldCode)
            .Columns.Add(pName)
            .Columns.Add(pLogo)
        End With
        For Each pCC As CostCentreLookupItem In mobjCostCentres.Values
            If mSearchString = "" Then
                dgvCostCentres.Rows.Add(pCC.CostCentre, pCC.VesselName, pCC.Code, pCC.OldCode, pCC.ClientName, pCC.ClientLogo)
            Else
                Dim pSearch As String = mSearchString.ToUpper
                If pCC.CostCentre.ToUpper.IndexOf(pSearch) >= 0 Or pCC.VesselName.ToUpper.IndexOf(pSearch) >= 0 Or pCC.Code.ToUpper.IndexOf(pSearch) >= 0 Or pCC.OldCode.ToUpper.IndexOf(pSearch) >= 0 Or pCC.ClientName.ToUpper.IndexOf(pSearch) >= 0 Or pCC.ClientLogo.ToUpper.IndexOf(pSearch) >= 0 Then
                    dgvCostCentres.Rows.Add(pCC.CostCentre, pCC.VesselName, pCC.Code, pCC.OldCode, pCC.ClientName, pCC.ClientLogo)
                End If
            End If
        Next

    End Sub
    Private Sub SetEnabled()

        cmdAccept.Enabled = (mCodeSelected <> "") And (mVesselSelected <> "")
        cmdCancel.Enabled = True
        If cmdAccept.Enabled Then
            Me.AcceptButton = cmdAccept
        End If

    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCustomers.SelectedIndexChanged

        Try
            If lstCustomers.SelectedIndex >= 0 Then
                mflgLoading = True
                SelectCustomer(CType(lstCustomers.SelectedItem, CustomerItem))
                txtCustomer.Text = lstCustomers.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub txtCustomerGroup_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerGroup.TextChanged

        If Not mflgLoading Then
            PopulateCustomerGroupList(txtCustomerGroup.Text)
        End If

    End Sub
    Private Sub LoadCustomerGroups()

        mobjCustomerGroups = New CustomerGroupCollection
        mobjCustomerGroups.Load(txtCustomerGroup.Text, mintBackOffice)
        lstCustomerGroup.Items.Clear()
        For Each pGroup As CustomerGroupItem In mobjCustomerGroups.Values
            If SearchString = "" Or pGroup.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                lstCustomerGroup.Items.Add(pGroup)
            End If
        Next
    End Sub

    Private Sub PopulateCustomerGroupList(ByVal pSearchString As String)

        mobjCustomers.Load(pSearchString, mintBackOffice)

        lstCustomers.Items.Clear()
        For Each pCustomerGroup As CustomerGroupItem In mobjCustomerGroups.Values
            If pSearchString = "" Or pCustomerGroup.ToString.ToUpper.Contains(pSearchString.ToUpper) Then
                lstCustomerGroup.Items.Add(pCustomerGroup)
            End If
        Next

        If lstCustomers.Items.Count = 1 Then
            Try
                mflgLoading = True

                SelectCustomerGroup(CType(lstCustomerGroup.Items(0), CustomerGroupItem))
                txtCustomerGroup.Text = lstCustomerGroup.Items(0).ToString
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                mflgLoading = False
            End Try
        End If

    End Sub

    Private Sub SelectCustomerGroup(ByVal pCustomerGroup As CustomerGroupItem)
        'TODO
        mobjCustomerGroupSelected = pCustomerGroup
        txtCustomerGroup.Text = pCustomerGroup.ToString

        mobjCostCentres.LoadCustomerGroup(mobjCustomerGroupSelected.ID, mintBackOffice)
        PopulateCostCentres()

        SetEnabled()

    End Sub

    Private Sub lstCustomerGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCustomerGroup.SelectedIndexChanged

        Try
            If lstCustomerGroup.SelectedIndex >= 0 Then
                mflgLoading = True
                SelectCustomerGroup(CType(lstCustomerGroup.SelectedItem, CustomerGroupItem))
                txtCustomerGroup.Text = lstCustomerGroup.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub

    Private Sub dgvCostCentres_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostCentres.CellContentClick

        mCodeSelected = dgvCostCentres.Rows(e.RowIndex).Cells(2).Value.ToString
        mVesselSelected = dgvCostCentres.Rows(e.RowIndex).Cells(1).Value.ToString
        mCostCentreSelected = dgvCostCentres.Rows(e.RowIndex).Cells(0).Value.ToString
        SetEnabled()

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        mSearchString = txtSearch.Text.Trim
        If mSearchString <> "" Then
            cmdSearch.BackColor = Color.Yellow
            Me.AcceptButton = cmdSearch
        Else
            cmdSearch.BackColor = cmdAccept.BackColor
        End If
        If mSearchString.Length >= 3 Then
            PopulateCostCentres()
        End If

    End Sub
    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            mSearchString = txtSearch.Text.Trim
            PopulateCostCentres()
        End If

    End Sub

    Private Sub mnuCostCentreExport_Click(sender As Object, e As EventArgs) Handles mnuCostCentreExport.Click

        Try
            Dim pResponse As String

            pResponse = ExportDataGrid.Export(dgvCostCentres)
            MessageBox.Show("Exported OK" & vbCrLf & "File: " & pResponse)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        mSearchString = txtSearch.Text.Trim
        PopulateCostCentres()
    End Sub

End Class