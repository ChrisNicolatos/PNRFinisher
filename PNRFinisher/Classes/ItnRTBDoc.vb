Option Strict On
Option Explicit On
Public Class ItnRTBDoc
    Private Const STANDARDMAXSTRINGLENGTH As Integer = 80
    Private mobjPNR As GDSReadPNR
    Private mintMaxString As Integer = STANDARDMAXSTRINGLENGTH
    Private ReadOnly mstrRemarks As String
    Private mintHeaderLength As Integer = 0
    Public Sub New(ByRef pPNR As GDSReadPNR, ByRef pItnRemarks As CheckedListBox)
        mobjPNR = pPNR
        mintMaxString = STANDARDMAXSTRINGLENGTH
        mstrRemarks = ""
        For iRem As Integer = 0 To pItnRemarks.CheckedItems.Count - 1
            Dim pItem As RemarksItem
            pItem = CType(pItnRemarks.CheckedItems(iRem), RemarksItem)
            mstrRemarks &= pItem.Remark & vbCrLf
        Next
    End Sub
    Public Function RTBDocPassengers() As String
        Dim pString As New System.Text.StringBuilder
        If mobjPNR.Passengers.Count > 0 Then
            If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Then
                pString.AppendLine("FOR PASSENGER" & If(mobjPNR.Passengers.Count > 1, "(S)", ""))
            End If
            For Each pobjPax In mobjPNR.Passengers.Values
                If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Then
                    pString.AppendLine(pobjPax.PaxName)
                ElseIf MySettings.FormatStyle = EnumItnFormat.Fleet Then
                    pString.AppendLine(pobjPax.PaxName & " " & pobjPax.PaxID)
                Else
                    pString.AppendLine(pobjPax.ElementNo & " " & pobjPax.PaxName & " " & pobjPax.PaxID)
                End If
            Next pobjPax
        ElseIf mobjPNR.IsGroup Then
            pString.AppendLine("GROUP: " & mobjPNR.GroupName & " " & mobjPNR.GroupNamesCount)
        Else
            pString.AppendLine("PASSENGER INFORMATION NOT AVAILABLE")
        End If
        Return pString.ToString
    End Function
    Public Function makeRTBDocAimeryMoxie() As String
        Dim pString As New System.Text.StringBuilder

        pString.Clear()
        mintMaxString = STANDARDMAXSTRINGLENGTH

        Try
            pString.Append(RTBDocPassengersAimeryMoxie)
            pString.Append(ATPIRef)
            pString.Append(RTBDocSegsAimeryMoxie)
            pString.Append(MakeRTBDocTicketsAimeryMoxie)

        Catch ex As Exception
            Throw New Exception("makeRTBDocAimeryMoxie()" & vbCrLf & ex.Message)
        End Try

        Return pString.ToString

    End Function
    Public Function RTBDocPassengersAimeryMoxie() As String
        Dim pString As New System.Text.StringBuilder
        Dim pTitle As String = "PASSENGER  : "
        If mobjPNR.Passengers.Count > 0 Then
            For Each pobjPax In mobjPNR.Passengers.Values
                pString.AppendLine(pTitle & pobjPax.PaxName)
                pTitle = Space(pTitle.Length)
            Next pobjPax
        ElseIf mobjPNR.IsGroup Then
            pString.AppendLine("GROUP      : " & mobjPNR.GroupName & " " & mobjPNR.GroupNamesCount)
        Else
            pString.AppendLine("PASSENGER INFORMATION NOT AVAILABLE")
        End If
        Return pString.ToString
    End Function
    Public Function RTBDocSegsAimeryMoxie() As String
        Dim pString As New System.Text.StringBuilder
        Dim pAirlineLocator As String = ""
        Dim pobjSeg As GDSSegItem

        Dim iSegCount As Integer = 0
        For Each pobjSeg In mobjPNR.Segments.Values
            If pobjSeg.SurfaceSegment Then
                pString.AppendLine("*** ***")
            Else
                iSegCount = iSegCount + 1
                Dim pSeg As New System.Text.StringBuilder
                pSeg.Append(pobjSeg.Airline & pobjSeg.FlightNo.PadLeft(4) & " ")
                pSeg.Append(pobjSeg.DepartureDateIATA & " ")
                pSeg.Append(pobjSeg.BoardPoint & ("T" & pobjSeg.DepartTerminalShort).PadLeft(8) & "/")
                pSeg.Append(pobjSeg.OffPoint & ("T" & pobjSeg.ArriveTerminalShort).PadLeft(8) & " ")
                If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                    pSeg.Append("FLWN")
                Else
                    pSeg.Append(pobjSeg.DepartTimeShort & "  ")
                    pSeg.Append(pobjSeg.ArriveTimeShort & "  ")
                    pSeg.Append("/" & mobjPNR.AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline, pobjSeg.FlightNo, pobjSeg.ClassOfService, pobjSeg.DepartureDateIATA, pobjSeg.DepartTimeShort))

                End If

                pString.AppendLine(pSeg.ToString)
                If pobjSeg.Equipment = "TRN" Then
                    pString.AppendLine("             ***     TRAIN     ****  ")
                End If

                If Not MySettings.FormatStyle = EnumItnFormat.Plain Then
                    If pobjSeg.OperatedBy <> "" Then
                        pString.AppendLine(StrDup(13, " ") & pobjSeg.OperatedBy)
                    End If
                    If (MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Or MySettings.ShowStopovers) And pobjSeg.Stopovers <> "" Then
                        pString.AppendLine("             *INTERMEDIATE STOP*  " & pobjSeg.Stopovers)
                    End If
                End If

                If pSeg.ToString.Length > mintMaxString Then
                    mintMaxString = pSeg.ToString.Length
                End If
                If pAirlineLocator.IndexOf(pobjSeg.AirlineLocator.Trim) = -1 Then
                    If pAirlineLocator = "" Then
                        pAirlineLocator = "AIRLINE REF: " & pobjSeg.AirlineLocator.Trim '& "(" & pobjSeg.Airline & " " & pobjSeg.AirlineName & ")"
                    Else
                        pAirlineLocator &= vbCrLf & "             " & pobjSeg.AirlineLocator.Trim '& "(" & pobjSeg.Airline & " " & pobjSeg.AirlineName & ")"
                    End If
                End If

            End If
        Next pobjSeg

        If iSegCount = 0 Then
            pString.AppendLine("ROUTING INFORMATION NOT AVAILABLE")
        End If
        Return vbCrLf & pAirlineLocator & vbCrLf & vbCrLf & pString.ToString
    End Function
    Private Function MakeRTBDocTicketsAimeryMoxie() As String
        Try
            Dim pString As New System.Text.StringBuilder
            Dim pFFAll As New Collections.Generic.List(Of String)
            Dim pFFTitle As String = "Frequent Flyer Number"
            If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                pFFTitle = "Mileage membership"
            End If
            pString.Clear()
            Dim pHeader As String = ""
            Dim pAncServicesTitle As String = ""
            If MySettings.FormatStyle = EnumItnFormat.DefaultFormat Then
                pHeader = "Ticket Number   "
                If MySettings.ShowPaxSegPerTkt Then
                    pHeader &= "Routing      Passenger"
                End If
                pAncServicesTitle = "Ancillary Services"
            End If

            If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Then
            Else
                For iTickType = 1 To 2 ' 1 for tickets, 2 for EMD
                    For Each tkt As GDSTicketItem In mobjPNR.Tickets.Values
                        If iTickType = 1 And tkt.TicketType = "PAX" Then
                            ' Tickets
                            If pHeader <> "" Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pString.AppendLine(pHeader)
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pHeader = ""
                            End If

                            Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.PadRight(3).Substring(0, tkt.Pax.PadRight(3).Length - 2).Trim)
                            If pFF <> "" Then
                                If Not pFFAll.Contains(pFF) Then
                                    pFFAll.Add(pFF)
                                End If
                                pFF = " - " & pFFTitle & ": " & pFF
                            End If

                            Dim pTemp As String = tkt.IssuingAirline & "-" & tkt.Document & If(tkt.Books > 1, tkt.Conjunction, "") & "  "
                            pString.AppendLine(pTemp & tkt.Segs.PadRight(10).Substring(0, 10) & "   " & tkt.Pax.PadRight(3).Substring(0, tkt.Pax.PadRight(3).Length - 2) & pFF)
                            pTemp = Space(pTemp.Length)
                            For i As Integer = 12 To tkt.Segs.Length - 10 Step 12
                                pString.AppendLine(pTemp & tkt.Segs.Substring(i, 10))
                            Next
                        ElseIf iTickType = 2 And tkt.TicketType <> "PAX" Then
                            'EMDs
                            If pAncServicesTitle <> "" Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pString.AppendLine(pAncServicesTitle)
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pAncServicesTitle = ""
                            End If
                            Dim pTemp As String = tkt.IssuingAirline & "-" & tkt.Document & If(tkt.Books > 1, tkt.Conjunction, "") & "  "
                            pString.AppendLine(pTemp & tkt.Segs.PadRight(10).Substring(0, 10) & "   " & tkt.Pax.PadRight(3).Substring(0, tkt.Pax.PadRight(3).Length - 2))
                            pTemp = Space(pTemp.Length)
                            For i As Integer = 12 To tkt.Segs.Length - 10 Step 12
                                pString.AppendLine(pTemp & tkt.Segs.Substring(i, 10))
                            Next
                            If tkt.ServicesDescription <> "" Then
                                pString.AppendLine(tkt.ServicesDescription)
                            End If
                        End If
                    Next
                Next
            End If
            If MySettings.ShowTickets Then
                For Each pFFItem As FrequentFlyerItem In mobjPNR.FrequentFlyernumberCollection
                    Dim pFF As String = mobjPNR.FrequentFlyerNumber(pFFItem.Airline, pFFItem.PaxName)
                    If Not pFFAll.Contains(pFF) Then
                        pFFAll.Add(pFF)
                        pString.AppendLine(pFFTitle & ": " & pFF)
                    End If
                Next
            End If
            If mobjPNR.Seats <> "" Then
                If Not MySettings.FormatStyle = EnumItnFormat.Plain Then
                    pString.AppendLine(StrDup(mintHeaderLength, "-"))
                End If
                pString.AppendLine("Seat Assignment")
                If Not MySettings.FormatStyle = EnumItnFormat.Plain Then
                    pString.AppendLine(StrDup(mintHeaderLength, "-"))
                End If
                pString.AppendLine(mobjPNR.Seats & vbCrLf)
            End If

            Return vbCrLf & pString.ToString
        Catch ex As Exception
            Throw New Exception("MakeRTBDocTicketsAimeryMoxie()" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function makeRTBDoc() As String
        Dim pString As New System.Text.StringBuilder

        pString.Clear()
        mintMaxString = STANDARDMAXSTRINGLENGTH

        Try
            pString.Append(MakeRTBDocPart1)
            If MySettings.ShowCO2 Then
                pString.Append(MakeRTBDocCO2)
            End If
            pString.Append(MakeRTBDocTickets)
            If MySettings.ShowItinRemarks Then
                pString.Append(MakeRTBDocItinRemarks)
            End If
            If Not (MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode) And mintMaxString > 0 Then
                pString.AppendLine(StrDup(mintHeaderLength, "-"))
            End If
            pString.AppendLine()
            pString.Append(mstrRemarks)
        Catch ex As Exception
            Throw New Exception("makeRTBDoc()" & vbCrLf & ex.Message)
        End Try
        Return pString.ToString
    End Function
    Private Function MakeRTBDocCO2() As String
        Dim pString As New System.Text.StringBuilder
        Dim pValue As String = ""
        Dim pTotal As Decimal = 0
        pString.Clear()
        pString.AppendLine()
        pString.AppendLine("FLIGHT(S) CALCULATED AVERAGE CO2 EMISSIONS PER SEGMENT/PERSON")
        For Each pobjSeg In mobjPNR.Segments.Values
            For Each pLine As CO2Item In pobjSeg.CO2
                If pobjSeg.ClassOfServiceDescription.CabinClass = "F" Or pobjSeg.ClassOfServiceDescription.CabinClass = "J" Then
                    pValue = Format(pLine.Premium, "#,##0.##").PadLeft(11) & " KG/PERSON"
                    pTotal += pLine.Premium
                Else
                    pValue = Format(pLine.Economy, "#,##0.##").PadLeft(11) & " KG/PERSON"
                    pTotal += pLine.Economy
                End If
                pString.AppendLine(pLine.Routing & pValue)
            Next
        Next
        pString.AppendLine("TOTAL  " & Format(pTotal, "#,##0.##").PadLeft(11) & " KG/PERSON")
        pString.AppendLine()
        Return pString.ToString
    End Function
    Private Function MakeRTBDocPart1() As String
        Try
            Dim pString As New System.Text.StringBuilder
            Dim pAirlineLocator As String = ""
            Dim pConnectingTimes As String = ""
            Dim pobjSeg As GDSSegItem
            Dim pPrevOff As String = ""
            pString.Clear()
            pString.Clear()
            Dim pTemp As String = ""
            If Not (MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet) And MySettings.ShowVessel And mobjPNR.VesselName <> "" Then
                pTemp &= Vessel()
            End If
            If Not (MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet) And MySettings.ShowCostCentre And mobjPNR.CostCentre <> "" Then
                If pTemp <> "" Then
                    pTemp &= vbCrLf
                End If
                pTemp &= CostCentre()
            End If
            If pTemp <> "" Then
                pString.AppendLine(" ")
                pString.AppendLine(pTemp)
                pString.AppendLine(" ")
            End If
            Dim pHeader As New System.Text.StringBuilder

            If MySettings.FormatStyle = EnumItnFormat.DefaultFormat Then
                pHeader.Append("Flight ")
                If MySettings.ShowClassOfService Then
                    pHeader.Append("C ")
                End If
                pHeader.Append("Date  ")
                Select Case MySettings.AirportName
                    Case 0
                        pHeader.Append("Org Dest")
                    Case 1
                        pHeader.Append("Origin " & StrDup(mobjPNR.MaxAirportNameLength - 5, " ") & "Destination" & StrDup(mobjPNR.MaxAirportNameLength - 9, " "))
                    Case 2
                        pHeader.Append("Origin " & StrDup(mobjPNR.MaxAirportNameLength - 1, " ") & "Destination" & StrDup(mobjPNR.MaxAirportNameLength - 5, " "))
                    Case 3
                        pHeader.Append("Origin " & StrDup(mobjPNR.MaxAirportShortNameLength - 5, " ") & "Destination" & StrDup(mobjPNR.MaxAirportShortNameLength - 9, " "))
                    Case 4
                        pHeader.Append("Origin " & StrDup(mobjPNR.MaxAirportShortNameLength - 1, " ") & "Destination" & StrDup(mobjPNR.MaxAirportShortNameLength - 5, " "))
                End Select
                pHeader.Append("Dep   ")
                pHeader.Append("Arr   ")
                If MySettings.ShowFlyingTime Then
                    pHeader.Append(" EFT  ")
                End If
                pHeader.Append("ArrDte ")
                If MySettings.ShowEquipmentCode Then
                    pHeader.Append(" EQP")
                End If
                pHeader.Append(If(MySettings.ShowAirlineLocator, " AL Locator", ""))
                pHeader.Append(" - BagAl")
                If MySettings.ShowCabinDescription Then
                    pHeader.Append(" Class")
                End If

                mintHeaderLength = pHeader.Length

                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                pString.AppendLine(pHeader.ToString)
                pString.AppendLine(StrDup(mintHeaderLength, "-"))
            ElseIf MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Then
                pHeader.Append("Flight ")
                pHeader.Append("Date  ")
                If MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Then
                    pHeader.Append("Org    " & StrDup(mobjPNR.MaxAirportShortNameLength - 1, " ") & "Dest       " & StrDup(mobjPNR.MaxAirportShortNameLength - 5, " "))
                Else
                    pHeader.Append("Org    " & StrDup(mobjPNR.MaxAirportShortNameLength - 5, " ") & "Dest       " & StrDup(mobjPNR.MaxAirportShortNameLength - 9, " "))
                End If
                pHeader.Append("Dep   ")
                pHeader.Append("Arr   ")
                pHeader.Append("Term   ")
                pHeader.Append("Status")
                pHeader.Append("   BagAl")
                mintHeaderLength = pHeader.Length

                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                pString.AppendLine(pHeader.ToString)
                pString.AppendLine(StrDup(mintHeaderLength, "-"))
            End If

            Dim iSegCount As Integer = 0
            For Each pobjSeg In mobjPNR.Segments.Values
                If pobjSeg.SurfaceSegment Then
                    pString.AppendLine("*** ***")
                Else
                    iSegCount = iSegCount + 1
                    Dim pSeg As New System.Text.StringBuilder
                    If pobjSeg.ConnectTimeFromPrevious <> "" And MySettings.FormatStyle = EnumItnFormat.Fleet Then
                        If pPrevOff = "" Or pPrevOff = pobjSeg.BoardPoint Then
                            pConnectingTimes &= vbCrLf & pobjSeg.BoardPoint & " CONNECTING TIME: " & pobjSeg.ConnectTimeFromPrevious
                        Else
                            pConnectingTimes &= vbCrLf & pPrevOff & "-" & pobjSeg.BoardPoint & " CONNECTING TIME: " & pobjSeg.ConnectTimeFromPrevious
                        End If

                    End If
                    If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Then
                        pSeg.Append(pobjSeg.Airline & pobjSeg.FlightNo.PadLeft(4) & " ")
                        pSeg.Append(pobjSeg.DepartureDateIATA & " ")
                        If MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Then
                            pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.BoardAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " ")
                            pSeg.Append(pobjSeg.OffPoint & " " & pobjSeg.OffPointAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " ")
                        ElseIf MySettings.FormatStyle = EnumItnFormat.Fleet Then
                            Dim pBoard As String = pobjSeg.BoardAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength - 5)
                            pBoard = (pBoard.Trim & " (" & pobjSeg.BoardPoint & ")").PadRight(mobjPNR.MaxAirportShortNameLength + 2, " "c)
                            Dim pOff As String = pobjSeg.OffPointAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength - 5)
                            pOff = (pOff.Trim & " (" & pobjSeg.OffPoint & ")").PadRight(mobjPNR.MaxAirportShortNameLength + 2, " "c)
                            pSeg.Append(pBoard)
                            pSeg.Append(pOff)
                        Else
                            pSeg.Append(pobjSeg.BoardAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " ")
                            pSeg.Append(pobjSeg.OffPointAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " ")
                        End If
                        If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                            pSeg.Append("FLWN")
                        Else
                            pSeg.Append(pobjSeg.DepartTimeShort & "  ")
                            pSeg.Append(pobjSeg.ArriveTimeShort)
                            If DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate) > 0 Then
                                pSeg.Append("+" & DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate) & " ")
                            ElseIf DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate) < 0 Then
                                pSeg.Append(DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate) & " ")
                            Else
                                pSeg.Append("   ")
                            End If
                            If pobjSeg.DepartTerminal <> "" Then
                                If pobjSeg.DepartTerminal.LastIndexOf(" ") > -1 Then
                                    pSeg.Append(pobjSeg.DepartTerminal.Substring(pobjSeg.DepartTerminal.LastIndexOf(" ")).PadLeft(3))
                                Else
                                    pSeg.Append("   ")
                                End If
                            Else
                                pSeg.Append("   ")
                            End If
                            If pobjSeg.Status = "HL" Then
                                pSeg.Append("      HL")
                            Else
                                pSeg.Append("      OK")
                            End If
                            pSeg.Append(mobjPNR.AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline, pobjSeg.FlightNo, pobjSeg.ClassOfService, pobjSeg.DepartureDateIATA, pobjSeg.DepartTimeShort).PadLeft(8))
                            If pAirlineLocator.IndexOf(pobjSeg.AirlineLocator.Trim) = -1 Then
                                If pAirlineLocator = "" Then
                                    pAirlineLocator = "AIRLINE REF: " & pobjSeg.AirlineLocator.Trim '& "(" & pobjSeg.Airline & " " & pobjSeg.AirlineName & ")"
                                Else
                                    pAirlineLocator &= vbCrLf & "             " & pobjSeg.AirlineLocator.Trim '& "(" & pobjSeg.Airline & " " & pobjSeg.AirlineName & ")"
                                End If
                            End If
                        End If
                    Else
                        pSeg.Append(pobjSeg.Airline & pobjSeg.FlightNo.PadLeft(4) & " ")
                        If MySettings.ShowClassOfService Then
                            pSeg.Append(pobjSeg.ClassOfService & " ")
                        End If
                        pSeg.Append(pobjSeg.DepartureDateIATA & " ")
                        Select Case MySettings.AirportName
                            Case 0 'code
                                pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.OffPoint & " ")
                            Case 1 'airport name
                                pSeg.Append(pobjSeg.BoardAirportName.PadRight(mobjPNR.MaxAirportNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportNameLength + 1) & " " &
                                                pobjSeg.OffPointAirportName.PadRight(mobjPNR.MaxAirportNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportNameLength + 1) & " ")
                            Case 2 'code and airport
                                pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.BoardAirportName.PadRight(mobjPNR.MaxAirportNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportNameLength + 1) & " " &
                                                pobjSeg.OffPoint & " " & pobjSeg.OffPointAirportName.PadRight(mobjPNR.MaxAirportNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportNameLength + 1) & " ")
                            Case 3 'city name
                                pSeg.Append(pobjSeg.BoardAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " " &
                                                pobjSeg.OffPointAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " ")
                            Case 4 'code and city
                                pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.BoardAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " " &
                                                pobjSeg.OffPoint & " " & pobjSeg.OffPointAirportShortName.PadRight(mobjPNR.MaxAirportShortNameLength + 1, " "c).Substring(0, mobjPNR.MaxAirportShortNameLength + 1) & " ")
                        End Select
                        If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                            pSeg.Append("FLWN")
                        Else
                            pSeg.Append(pobjSeg.DepartTimeShort & "  ")
                            pSeg.Append(pobjSeg.ArriveTimeShort & "  ")
                            If MySettings.ShowFlyingTime Then
                                pSeg.Append(pobjSeg.EstimatedFlyingTime & " ")
                            End If
                            pSeg.Append(pobjSeg.ArrivalDateIATA & "   ")
                            If MySettings.ShowEquipmentCode Then
                                pSeg.Append(pobjSeg.Equipment & " ")
                            End If
                            pSeg.Append(If(MySettings.ShowAirlineLocator, pobjSeg.AirlineLocator.PadRight(9, " "c), ""))
                            pSeg.Append(" - " & mobjPNR.AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline, pobjSeg.FlightNo, pobjSeg.ClassOfService, pobjSeg.DepartureDateIATA, pobjSeg.DepartTimeShort).PadLeft(5))
                            If pobjSeg.Status = "HL" Then
                                pSeg.Append("   WAITLISTED")
                            End If
                            If MySettings.ShowCabinDescription Then
                                pSeg.Append(" " & pobjSeg.ClassOfServiceDescription.CabinDescription)
                            End If

                            If MySettings.ShowTerminal And pobjSeg.DepartTerminal <> "" Then
                                pSeg.Append("   " & pobjSeg.DepartTerminal)
                            End If
                        End If
                    End If

                    pString.AppendLine(pSeg.ToString)
                    If pobjSeg.Equipment = "TRN" Then
                        pString.AppendLine("             ***     TRAIN     ****  ")
                    End If

                    If Not MySettings.FormatStyle = EnumItnFormat.Plain Then
                        If pobjSeg.OperatedBy <> "" Then
                            pString.AppendLine(StrDup(13, " ") & pobjSeg.OperatedBy)
                        End If
                        If (MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Or MySettings.ShowStopovers) And pobjSeg.Stopovers <> "" Then
                            pString.AppendLine("             *INTERMEDIATE STOP*  " & pobjSeg.Stopovers)
                        End If
                    End If

                    If pSeg.ToString.Length > mintMaxString Then
                        mintMaxString = pSeg.ToString.Length
                    End If
                    pPrevOff = pobjSeg.OffPoint
                End If
            Next pobjSeg

            If iSegCount = 0 Then
                pString.AppendLine("ROUTING INFORMATION NOT AVAILABLE")
            End If
            If MySettings.FormatStyle = EnumItnFormat.Fleet And pConnectingTimes <> "" Then
                pString.AppendLine(pConnectingTimes)
            End If

            If mobjPNR.RequestedPNR <> "" Then
                pString.AppendLine(" ")
                If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Then
                    pString.AppendLine(ATPIRef)
                ElseIf MySettings.FormatStyle <> EnumItnFormat.Fleet Then
                    pString.AppendLine(ATPIBookingReference)
                End If
                If pAirlineLocator <> "" And (MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet) Then
                    pString.AppendLine(pAirlineLocator)
                End If
            End If

            Return pString.ToString
        Catch ex As Exception
            Throw New Exception("MakeRTBDocPart1()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function ATPIBookingReference() As String
        Return "ATPI Booking Reference: " & mobjPNR.GDSAbbreviation & "/" & mobjPNR.RequestedPNR
    End Function
    Public Function ATPIRef() As String
        Return "ATPI REF   : " & mobjPNR.GDSAbbreviation & "/" & mobjPNR.RequestedPNR
    End Function
    Private Function Vessel() As String
        Return "VESSEL     : " & mobjPNR.VesselName
    End Function
    Private Function CostCentre() As String
        Return "COST CENTRE: " & mobjPNR.CostCentre
    End Function
    Private Function MakeRTBDocTickets() As String
        Try
            Dim pString As New System.Text.StringBuilder
            Dim pFFAll As New Collections.Generic.List(Of String)
            Dim pFFTitle As String = "Frequent Flyer Number"
            If mobjPNR.GDSCode = EnumGDSCode.Galileo Then
                pFFTitle = "Mileage membership"
            End If
            pString.Clear()
            Dim pHeader As String = ""
            Dim pAncServicesTitle As String = ""


            If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Then
                For Each pobjPax In mobjPNR.Passengers.Values
                    Dim pPaxShown As Boolean = False
                    For Each tkt As GDSTicketItem In mobjPNR.Tickets.Values
                        If tkt.TicketType = "PAX" Then
                            If tkt.Pax.Trim = pobjPax.PaxName.Trim Or tkt.Pax.Trim.StartsWith(pobjPax.PaxName.Trim) Or pobjPax.PaxName.Trim.StartsWith(tkt.Pax.Trim) Then
                                Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.Substring(0, tkt.Pax.Length - 2).Trim)
                                If pFF <> "" Then
                                    If Not pFFAll.Contains(pFF) Then
                                        pFFAll.Add(pFF)
                                    End If
                                    pFF = " - " & pFFTitle & ": " & pFF
                                End If
                                If tkt.Document > 0 Then
                                    If Not pPaxShown Then
                                        pString.AppendLine()
                                        If mobjPNR.Passengers.Values.Count > 1 Then
                                            pString.AppendLine(pobjPax.PaxName)
                                        End If
                                        pPaxShown = True
                                    End If
                                    pString.AppendLine("ETICKET NUMBER: " _
                                                           & tkt.IssuingAirline & "-" & tkt.Document & " " & tkt.AirlineCode & " " & Airlines.AirlineName(tkt.AirlineCode) & pFF)
                                Else
                                    If Not pPaxShown Then
                                        pString.AppendLine()
                                        If mobjPNR.Passengers.Values.Count > 1 Then
                                            pString.AppendLine(pobjPax.PaxName)
                                        End If
                                        pPaxShown = True
                                    End If
                                    pString.AppendLine(pFF)
                                End If
                            End If
                        End If
                    Next
                Next
            Else
                If MySettings.FormatStyle = EnumItnFormat.DefaultFormat Then
                    pHeader = "Ticket Number   "
                    If MySettings.ShowPaxSegPerTkt Then
                        pHeader &= "Routing      Passenger"
                    End If
                    pAncServicesTitle = "Ancillary Services"
                End If
                For iTickType = 1 To 2 ' 1 for tickets, 2 for EMD
                    For Each tkt As GDSTicketItem In mobjPNR.Tickets.Values
                        If MySettings.ShowTickets And iTickType = 1 And tkt.TicketType = "PAX" Then
                            ' Tickets
                            If pHeader <> "" Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pString.AppendLine(pHeader)
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pHeader = ""
                            End If
                            If MySettings.ShowPaxSegPerTkt Then
                                Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.PadRight(3).Substring(0, tkt.Pax.PadRight(3).Length - 2).Trim)
                                If pFF <> "" Then
                                    If Not pFFAll.Contains(pFF) Then
                                        pFFAll.Add(pFF)
                                    End If
                                    pFF = " - " & pFFTitle & ": " & pFF
                                End If

                                Dim pTemp As String = tkt.IssuingAirline & "-" & tkt.Document & If(tkt.Books > 1, tkt.Conjunction, "") & "  "
                                pString.AppendLine(pTemp & tkt.Segs.PadRight(10).Substring(0, 10) & "   " & tkt.Pax.PadRight(3).Substring(0, tkt.Pax.PadRight(3).Length - 2) & pFF)
                                pTemp = Space(pTemp.Length)
                                For i As Integer = 12 To tkt.Segs.Length - 10 Step 12
                                    pString.AppendLine(pTemp & tkt.Segs.Substring(i, 10))
                                Next
                            Else
                                pString.AppendLine(tkt.IssuingAirline & "-" & tkt.Document & If(tkt.Books > 1, tkt.Conjunction, ""))
                            End If
                        ElseIf MySettings.ShowEMD And iTickType = 2 And tkt.TicketType <> "PAX" Then
                            'EMDs
                            If pAncServicesTitle <> "" Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pString.AppendLine(pAncServicesTitle)
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                                pAncServicesTitle = ""
                            End If
                            If MySettings.ShowPaxSegPerTkt Then
                                Dim pTemp As String = tkt.IssuingAirline & "-" & tkt.Document & If(tkt.Books > 1, tkt.Conjunction, "") & "  "
                                pString.AppendLine(pTemp & tkt.Segs.PadRight(10).Substring(0, 10) & "   " & tkt.Pax.PadRight(3).Substring(0, tkt.Pax.PadRight(3).Length - 2))
                                pTemp = Space(pTemp.Length)
                                For i As Integer = 12 To tkt.Segs.Length - 10 Step 12
                                    pString.AppendLine(pTemp & tkt.Segs.Substring(i, 10))
                                Next
                                If tkt.ServicesDescription <> "" Then
                                    pString.AppendLine(tkt.ServicesDescription)
                                End If
                            Else
                                pString.AppendLine(tkt.IssuingAirline & "-" & tkt.Document & If(tkt.Books > 1, tkt.Conjunction, ""))
                                If tkt.ServicesDescription <> "" Then
                                    pString.AppendLine(tkt.ServicesDescription)
                                End If
                            End If
                        End If
                    Next
                Next
            End If
            If MySettings.ShowTickets Then
                For Each pFFItem As FrequentFlyerItem In mobjPNR.FrequentFlyernumberCollection
                    Dim pFF As String = mobjPNR.FrequentFlyerNumber(pFFItem.Airline, pFFItem.PaxName)
                    If Not pFFAll.Contains(pFF) Then
                        pFFAll.Add(pFF)
                        pString.AppendLine(pFFTitle & ": " & pFF)
                    End If
                Next
            End If
            If MySettings.FormatStyle = EnumItnFormat.SeaChefs Or MySettings.FormatStyle = EnumItnFormat.SeaChefsWithCode Or MySettings.FormatStyle = EnumItnFormat.Fleet Or MySettings.ShowSeating Then
                If mobjPNR.Seats <> "" Then
                    If Not MySettings.FormatStyle = EnumItnFormat.Plain Then
                        pString.AppendLine(StrDup(mintHeaderLength, "-"))
                    End If
                    pString.AppendLine("Seat Assignment")
                    If Not MySettings.FormatStyle = EnumItnFormat.Plain Then
                        pString.AppendLine(StrDup(mintHeaderLength, "-"))
                    End If
                    pString.AppendLine(mobjPNR.Seats & vbCrLf)
                End If
            End If


            Return pString.ToString
        Catch ex As Exception
            Throw New Exception("MakeRTBDocTickets()" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Function MakeRTBDocItinRemarks() As String
        Dim pString As New System.Text.StringBuilder
        Dim pFound As Boolean = False
        pString.Clear()
        For Each pItem As GDSItineraryRemarksItem In mobjPNR.ItineraryRemarks
            If pItem.FreeFlow.Trim <> "" Then
                If Not pFound Then
                    pString.AppendLine(vbCrLf)
                    pFound = True
                End If
                pString.AppendLine(pItem.FreeFlow)
            End If
        Next
        Return pString.ToString
    End Function

End Class
