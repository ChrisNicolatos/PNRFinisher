Option Strict On
Option Explicit On
Public Class UCRef
    Public Event SelectedIndexChanged()
    Public Event VesselLoaded(ByVal VesselName As String)
    Private mPax As GDSPaxCollection
    Public Property ClientRefItem As ClientReference
    Public ReadOnly Property isValid As Boolean = False

    Private Sub cmbClientRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientRef.LostFocus ' cmbClientRef.SelectedIndexChanged, cmbClientRef.TextChanged
        Try
            SetSelectedValue()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetSelectedValue()
        Try
            If cmbClientRef.DropDownStyle = ComboBoxStyle.DropDownList Then
                ClientRefItem.SelectedValue = New ClientReferenceItemValue(CType(cmbClientRef.SelectedItem, ClientReferenceItemValue))
            Else
                ClientRefItem.SelectedValue = New ClientReferenceItemValue(ClientRefItem.Id, cmbClientRef.Text, cmbClientRef.Text)
            End If
            If ClientRefItem.SelectedValue.Code = "" Then
                ClientRefItem.SelectedValue = Nothing
            End If
            If ClientRefItem.IsVessel Then
                If ClientRefItem.SelectedValue Is Nothing Then
                    RaiseEvent VesselLoaded("")
                Else
                    RaiseEvent VesselLoaded(ClientRefItem.SelectedValue.Value)
                End If
            End If
        Catch ex As Exception
            ClientRefItem.SelectedValue = Nothing
        End Try
        RaiseEvent SelectedIndexChanged()
    End Sub
    Public Sub Clear()
        lblClientRef.Text = ""
        cmbClientRef.Text = ""
        cmbClientRef.Items.Clear()
        cmbClientRef.DropDownStyle = ComboBoxStyle.DropDownList
        cmbClientRef.Enabled = False
        lnkPassenger.Visible = False
    End Sub

    Public Sub PrepareClientReference(ByRef pProp As ClientReference, ByVal Pax As GDSPaxCollection)
        Try
            ClientRefItem = pProp
            mPax = Pax
            ClientRefItem.PaxReferences = New Dictionary(Of Integer, ClientReferencePax)

            'mflgOldMode = False
            cmbClientRef.Enabled = True
            If pProp.LimitToLookup Then
                cmbClientRef.DropDownStyle = ComboBoxStyle.DropDown
            Else
                If pProp.LookupValues.Count = 0 Then
                    cmbClientRef.DropDownStyle = ComboBoxStyle.Simple
                Else
                    cmbClientRef.DropDownStyle = ComboBoxStyle.DropDown
                End If
            End If
            cmbClientRef.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbClientRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            lnkPassenger.Visible = (mPax.Count > 1) ' pProp.MandatoryForPax

            If pProp.Mandatory Then
                cmbClientRef.Items.Add("")
            End If
            For Each pItem As ClientReferenceItemValue In pProp.LookupValues
                cmbClientRef.Items.Add(pItem)
            Next
        Catch ex As Exception
            Throw New Exception("PrepareClientReference()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function SetEnabled() As Boolean
        lblClientRef.Text = ""
        If cmbClientRef.Enabled Then
            If Not ClientRefItem Is Nothing Then
                lblClientRef.Text = ClientRefItem.Title
                If ClientRefItem.MandatoryForPax Then
                    If ClientRefItem.PaxReferences.Count > 0 Or (mPax.Count = 1 And Not ClientRefItem.SelectedValue Is Nothing) Then
                        _isValid = True
                    Else
                        _isValid = False
                    End If
                ElseIf ClientRefItem.Mandatory Then
                    If Not ClientRefItem.SelectedValue Is Nothing Or ClientRefItem.PaxReferences.Count > 0 Then
                        _isValid = True
                    Else
                        _isValid = False
                    End If
                Else
                    _isValid = True
                End If
            End If
        End If
        Return isValid
    End Function

    Public Sub SetLabelColor()
        Try
            lblClientRef.Enabled = cmbClientRef.Enabled
            Dim pSelectedColorLBL As Color = Color.Silver
            Dim pSelectedColorLNK As Color = Color.Silver
            If lblClientRef.Enabled AndAlso Not ClientRefItem Is Nothing Then
                If ClientRefItem.Mandatory Then
                    pSelectedColorLBL = Color.FromArgb(255, 128, 128)
                Else
                    pSelectedColorLBL = Color.Cyan
                End If
                If ClientRefItem.MandatoryForPax Then
                    pSelectedColorLNK = Color.Red
                End If
            End If
            lblClientRef.BackColor = pSelectedColorLBL
            lnkPassenger.BackColor = pSelectedColorLNK
        Catch ex As Exception
            Throw New Exception("SetLabelColor()" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub DisplayOldReference(ByVal Item As GDSExistingItem)
        Try
            If Item.Key <> "" Then
                If cmbClientRef.DropDownStyle = ComboBoxStyle.DropDown Or cmbClientRef.DropDownStyle = ComboBoxStyle.Simple Then
                    If Item.Key <> "" Then
                        cmbClientRef.Text = Item.Key
                    End If
                Else
                    For i As Integer = 0 To cmbClientRef.Items.Count - 1
                        If Item.Key.ToUpper = cmbClientRef.Items(i).ToString.ToUpper Then
                            cmbClientRef.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                SetSelectedValue()
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldReference(ByVal Item As GDSExisting.Item)" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub lnkPassenger_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPassenger.LinkClicked

        Dim pFrm As New frmClientReferencePax(ClientRefItem.Title, mPax, cmbClientRef)
        Dim pResult As DialogResult = pFrm.ShowDialog()
        If pResult = DialogResult.OK Then
            ClientRefItem.PaxReferences = pFrm.PaxReferences
            RaiseEvent SelectedIndexChanged()
        End If

    End Sub

End Class
