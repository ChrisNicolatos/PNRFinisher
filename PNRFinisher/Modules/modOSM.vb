Option Strict On
Option Explicit On
Module modOSM
    Public Sub OSMRefreshVessels(ByRef lstListBox As ListBox, ByVal InUseOnly As Boolean)

        Dim pOSMVessels As New OSMVesselCollection

        If Not MySettings Is Nothing Then
            pOSMVessels.Load(MySettings.OSMVesselGroup)
        Else
            pOSMVessels.Load()
        End If
        lstListBox.Items.Clear()

        For Each pVessels As OSMVesselItem In pOSMVessels.Values
            If Not InUseOnly Or pVessels.InUse Then
                lstListBox.Items.Add(pVessels)
            End If
        Next

    End Sub
    Public Sub OSMRefreshVessels(ByRef lstListBox As ListBox)

        Dim pOSMVessels As New OSMVesselCollection

        pOSMVessels.Load()
        lstListBox.Items.Clear()

        For Each pVessels As OSMVesselItem In pOSMVessels.Values
            lstListBox.Items.Add(pVessels)
        Next

    End Sub
    Public Sub OSMRefreshVesselGroup(ByRef cmbComboBox As ComboBox)

        Dim pOSMVesselGroup As New OSMVesselGroupCollection

        pOSMVesselGroup.Load()
        cmbComboBox.Items.Clear()

        For Each PVesselGroup As OSMVesselGroupItem In pOSMVesselGroup.Values
            cmbComboBox.Items.Add(PVesselGroup)
            If Not MySettings Is Nothing Then
                If PVesselGroup.Id = MySettings.OSMVesselGroup Then
                    cmbComboBox.SelectedItem = PVesselGroup
                End If
            End If
        Next

    End Sub
    Public Sub OSMDisplayVesselGroups(ByRef lstListBox As CheckedListBox, ByVal pobjGroups As OSMVessel_VesselGroupCollection)

        lstListBox.Items.Clear()
        For Each Vessel_VesselGroup As OSMVessel_VesselGroupItem In pobjGroups.Values
            lstListBox.Items.Add(Vessel_VesselGroup, Vessel_VesselGroup.Exists)
        Next

    End Sub
    Public Sub OSMDisplayEmails(ByVal VesselList As ListBox, ByRef lstToEmail As ListBox, ByRef lstCCEmail As ListBox, ByRef lstAgentsEmail As ListBox)

        Dim pobjEmails As New OSMEmailCollection

        lstToEmail.Items.Clear()
        lstCCEmail.Items.Clear()
        lstAgentsEmail.Items.Clear()
        lstAgentsEmail.Items.Add("")

        For Each SelectedVessel As OSMVesselItem In VesselList.SelectedItems

            pobjEmails.Load(SelectedVessel.Id)

            For Each pEmail As OSMEmailItem In pobjEmails.Values
                With pEmail
                    If .EmailType = "TO" Then
                        Dim pFound As Boolean = False
                        For Each pItem As OSMEmailItem In lstToEmail.Items
                            If pEmail.ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstToEmail.Items.Add(pEmail)
                        End If
                    ElseIf .EmailType = "CC" Then
                        Dim pFound As Boolean = False
                        For Each pItem As OSMEmailItem In lstCCEmail.Items
                            If pEmail.ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstCCEmail.Items.Add(pEmail)
                        End If

                    ElseIf .EmailType = "AGENT" Then
                        lstAgentsEmail.Items.Add(pEmail)
                    End If
                End With
            Next
        Next

    End Sub
    Public Sub OSMDisplayEmails(ByVal VesselId As Integer, ByRef lstToEmail As ListBox, ByRef lstCCEmail As ListBox)

        Dim pobjEmails As New OSMEmailCollection

        pobjEmails.Load(VesselId)

        lstToEmail.Items.Clear()
        lstCCEmail.Items.Clear()

        For Each pEmail As OSMEmailItem In pobjEmails.Values
            With pEmail
                If .EmailType = "TO" Then
                    lstToEmail.Items.Add(pEmail)
                ElseIf .EmailType = "CC" Then
                    lstCCEmail.Items.Add(pEmail)
                End If
            End With
        Next
    End Sub
    Public Sub OSMDisplayEmails(ByRef lstAgents As ListBox)

        Dim pobjEmails As New OSMEmailCollection

        pobjEmails.Load()

        lstAgents.Items.Clear()

        For Each pEmail As OSMEmailItem In pobjEmails.Values
            With pEmail
                If .EmailType = "AGENT" Then
                    lstAgents.Items.Add(pEmail)
                End If
            End With
        Next
    End Sub

    Public Sub OSMListBox_DrawItem(sender As ListBox, e As DrawItemEventArgs)

        If e.Index >= 0 And e.Index < sender.Items.Count Then
            Dim stringToDraw As String = sender.Items(e.Index).ToString
            Dim VesselToDraw As OSMVesselItem = CType(sender.Items(e.Index), OSMVesselItem)
            Dim C As Color
            If Not VesselToDraw.InUse Then
                C = Color.Red
            Else
                C = sender.ForeColor
            End If

            e.DrawBackground()
            e.DrawFocusRectangle()
            e.Graphics.DrawString(stringToDraw, e.Font, New SolidBrush(C), e.Bounds)
        End If

    End Sub

End Module
