Option Strict On
Option Explicit On
Public Class frmCostCentre

    Private mintBackOffice As Integer
    Private mobjClients As ClientCollection
    Private mobjClientGroups As ClientGroupCollection
    Private SearchString As String = ""
    Private mflgLoading As Boolean = False
    Private mobjClientSelected As Client
    Private mobjClientGroupSelected As ClientGroup
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
            LoadClients()
            LoadClientGroups()
        Catch ex As Exception

        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub LoadClients()

        mobjClients = New ClientCollection("", mintBackOffice)
        lstClients.Items.Clear()
        For Each pClient As Client In mobjClients.Values
            If SearchString = "" Or pClient.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                lstClients.Items.Add(pClient)
            End If
        Next

    End Sub

    Private Sub txtClient_TextChanged(sender As Object, e As EventArgs) Handles txtClient.TextChanged

        If Not mflgLoading Then
            PopulateClientList(txtClient.Text)
        End If

    End Sub

    Private Sub PopulateClientList(ByVal pSearchString As String)

        mobjClients = New ClientCollection(pSearchString, mintBackOffice)

        lstClients.Items.Clear()
        For Each pClient As Client In mobjClients.Values
            If pSearchString = "" Or pClient.ToString.ToUpper.Contains(pSearchString.ToUpper) Then
                lstClients.Items.Add(pClient)
            End If
        Next

        If lstClients.Items.Count = 1 Then
            Try
                mflgLoading = True

                SelectClient(CType(lstClients.Items(0), Client))
                txtClient.Text = lstClients.Items(0).ToString
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                mflgLoading = False
            End Try
        End If

    End Sub

    Private Sub SelectClient(ByVal pClient As Client)
        'TODO
        mobjClientSelected = pClient
        txtClient.Text = pClient.ToString

        mobjCostCentres.LoadClient(mobjClientSelected.ID, mintBackOffice)
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

    Private Sub lstClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClients.SelectedIndexChanged

        Try
            If lstClients.SelectedIndex >= 0 Then
                mflgLoading = True
                SelectClient(CType(lstClients.SelectedItem, Client))
                txtClient.Text = lstClients.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub txtClientGroup_TextChanged(sender As Object, e As EventArgs) Handles txtClientGroup.TextChanged

        If Not mflgLoading Then
            PopulateClientGroupList(txtClientGroup.Text)
        End If

    End Sub
    Private Sub LoadClientGroups()

        mobjClientGroups = New ClientGroupCollection(txtClientGroup.Text, mintBackOffice)
        lstClientGroup.Items.Clear()
        For Each pGroup As ClientGroup In mobjClientGroups.Values
            If SearchString = "" Or pGroup.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                lstClientGroup.Items.Add(pGroup)
            End If
        Next
    End Sub

    Private Sub PopulateClientGroupList(ByVal pSearchString As String)

        mobjClients = New ClientCollection(pSearchString, mintBackOffice)

        lstClients.Items.Clear()
        For Each pClientGroup As ClientGroup In mobjClientGroups.Values
            If pSearchString = "" Or pClientGroup.ToString.ToUpper.Contains(pSearchString.ToUpper) Then
                lstClientGroup.Items.Add(pClientGroup)
            End If
        Next

        If lstClients.Items.Count = 1 Then
            Try
                mflgLoading = True

                SelectClientGroup(CType(lstClientGroup.Items(0), ClientGroup))
                txtClientGroup.Text = lstClientGroup.Items(0).ToString
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                mflgLoading = False
            End Try
        End If

    End Sub

    Private Sub SelectClientGroup(ByVal pClientGroup As ClientGroup)
        'TODO
        mobjClientGroupSelected = pClientGroup
        txtClientGroup.Text = pClientGroup.ToString

        mobjCostCentres.LoadClientGroup(mobjClientGroupSelected.ID, mintBackOffice)
        PopulateCostCentres()

        SetEnabled()

    End Sub

    Private Sub lstClientGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstClientGroup.SelectedIndexChanged

        Try
            If lstClientGroup.SelectedIndex >= 0 Then
                mflgLoading = True
                SelectClientGroup(CType(lstClientGroup.SelectedItem, ClientGroup))
                txtClientGroup.Text = lstClientGroup.SelectedItem.ToString
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