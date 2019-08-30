﻿Option Strict On
Option Explicit On
Public Class frmShowOptions

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayOptions()
    End Sub

    Private Sub DisplayOptions()

        If Not MySettings Is Nothing Then
            With MySettings

                txtOfficePCCAmadeus.Text = .GDSPcc
                txtOfficeCityCode.Text = .OfficeCityCode
                txtCountryCode.Text = .CountryCode
                txtOfficeName.Text = .OfficeName
                txtCityName.Text = .CityName
                txtOfficePhone.Text = .Phone
                txtAOHPhone.Text = .AOHPhone

                txtAgentIDAmadeus.Text = .GDSUser
                txtAgentQueueAmadeus.Text = .AgentQueue
                txtAgentOPQueueAmadeus.Text = .AgentOPQueue
                txtAgentName.Text = .AgentName
                txtAgentEmail.Text = .AgentEmail

                txtDBConnectionFile.Text = UtilitiesDB.DBConnectionsFile
                txtSQLServer.Text = "DataSource:" & UtilitiesDB.PNRDataSource & " DataCatalog:" & UtilitiesDB.PNRInitialCatalog & " UserName:" & UtilitiesDB.PNRUserID
            End With

        End If

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub


End Class