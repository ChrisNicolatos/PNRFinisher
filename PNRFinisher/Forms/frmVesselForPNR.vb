﻿Option Strict On
Option Explicit On
Public Class frmVesselForPNR

    Dim mstrVesselName As String
    Dim mstrRegistration As String

    Public ReadOnly Property VesselName() As String
        Get
            Return mstrVesselName
        End Get
    End Property

    Public ReadOnly Property Registration() As String
        Get
            Return mstrRegistration
        End Get
    End Property

    Private Sub frmVesselForPNR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblNotice.Text = "Use only for vessels which will be used once. For new vessels not in the customer's list contact IT or the accounts department."
        mstrVesselName = ""
        mstrRegistration = ""
        ShowEnabled()

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub txtVesselName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVesselName.TextChanged

        mstrVesselName = txtVesselName.Text.Trim
        ShowEnabled()

    End Sub

    Private Sub txtRegistration_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegistration.TextChanged

        mstrRegistration = txtRegistration.Text.Trim
        ShowEnabled()

    End Sub

    Private Sub ShowEnabled()

        cmdOK.Enabled = (mstrVesselName <> "")

    End Sub


End Class