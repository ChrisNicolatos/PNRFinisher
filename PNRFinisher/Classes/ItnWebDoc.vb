Public Class ItnWebDoc
    Dim mobjPNR As GDSReadPNR
    Public Sub New(ByRef pPNR As GDSReadPNR)
        mobjPNR = pPNR
    End Sub

    Public ReadOnly Property WebDoc As String
        Get
            WebDoc = ""
            Try
                Return WebDocBody()
            Catch ex As Exception

            End Try
        End Get
    End Property
    Private Function WebDocBody() As String

        Dim pString As New System.Text.StringBuilder

        Try

            With mobjPNR
                pString.Clear()
                pString.AppendLine("")
                pString.AppendLine("<div>")
                pString.AppendLine("<span style='font-size:12.0pt;font-family:arial'>")
                pString.AppendLine("Flight Routing Information<br />")
                pString.AppendLine("</span>")
                pString.AppendLine("<span style='font-size:10.0pt;font-family:arial'>")
                pString.AppendLine(MySettings.FormalOfficeName & "<br />")
                pString.AppendLine("Flight routing information<br />")
                If Not mobjPNR.ExistingElements Is Nothing Then
                    If .ExistingElements.ClientName.Trim <> "" Then
                        pString.AppendLine("For: " & .ExistingElements.ClientName)
                    End If
                End If
                pString.AppendLine("<br /><br />")
                pString.AppendLine("Date: " & Format(Now, "dd/MM/yyyy") & "<br /><br />")
                If Not mobjPNR.ExistingElements Is Nothing Then
                    If mobjPNR.ExistingElements.VesselName <> "" Then
                        pString.AppendLine("<b><u>VESSEL:</u></b><br />" & mobjPNR.ExistingElements.VesselName & "<br /><br />")
                    End If
                End If
                If mobjPNR.Passengers.Count > 0 Then
                    pString.AppendLine("<b><u>")
                    If mobjPNR.Passengers.Count = 1 Then
                        pString.AppendLine("PASSENGER<br />")
                    Else
                        pString.AppendLine("PASSENGERS<br />")
                    End If
                    pString.AppendLine("</u></b>")
                    Dim iPaxCount As Integer = 0
                    For Each pobjPax As GDSPaxItem In mobjPNR.Passengers.Values
                        iPaxCount = iPaxCount + 1
                        pString.AppendLine(pobjPax.ElementNo & " " & pobjPax.PaxName & " " & pobjPax.PaxID & "<br />")
                    Next pobjPax
                ElseIf mobjPNR.IsGroup Then
                    pString.AppendLine("<b><u>")
                    pString.AppendLine("GROUP<br />")
                    pString.AppendLine("</u></b>")
                    pString.AppendLine(mobjPNR.GroupName & " " & mobjPNR.GroupNamesCount & "<br />")
                Else
                    pString.AppendLine("PASSENGER INFORMATION NOT AVAILABLE")
                End If
                pString.AppendLine("<span style='font-size:12.0pt;font-family:arial'>")
                pString.AppendLine("<br />FLIGHT ROUTING<br />")
                pString.AppendLine("</span>")
                'pString.AppendLine("<div align=left>")
                pString.AppendLine("<span style='font-size:10.0pt;font-family:arial'>")
                pString.AppendLine("<table cellspacing=" & Chr(34) & "1" & Chr(34) & " cellpadding=" & Chr(34) & "2" & Chr(34) & " border=" & Chr(34) & "1" & Chr(34) & " >")
                pString.AppendLine("<tr bgcolor=" & Chr(34) & "#0Fffff" & Chr(34) & ">")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Airline</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Flight</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Date</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Itinerary</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Depart</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Arrive</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Airline Locator</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Baggage Allowance</td>")
                pString.AppendLine("</tr>")

                Dim iSegCount As Integer = 0
                Dim pPrevOff As String = ""
                For Each pobjSeg As GDSSegItem In .Segments.Values
                    iSegCount = iSegCount + 1
                    If iSegCount > 1 And pPrevOff <> pobjSeg.Origin.AirportCode Then
                        pString.AppendLine("<tr>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")

                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>** CHANGE OF AIRPORT **</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("</tr>")
                    End If
                    pPrevOff = pobjSeg.Destination.AirportCode
                    pString.AppendLine("<tr>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & iSegCount & "</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Airline & "-" & pobjSeg.AirlineName)
                    If pobjSeg.OperatedBy <> "" Then
                        pString.AppendLine("<br /><span style='font-size:6.0pt;font-family:arial'>" & pobjSeg.OperatedBy & "</span>")
                    End If
                    pString.AppendLine("</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.FlightNo & "</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & Format(pobjSeg.Departure.SegDate, "dd/MM/yyyy") & "<br><span style='font-size:6.0pt;font-family:arial'>" & pobjSeg.Departure.DayOfTheWeek & "</span></td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Origin.AirportCode & " " & pobjSeg.Origin.CityName.PadRight(.Segments.MaxCityNameLength + 1, " "c).Substring(0, .Segments.MaxCityNameLength + 1) & " - " &
                    pobjSeg.Destination.AirportCode & " " & pobjSeg.Destination.CityName.PadRight(.Segments.MaxCityNameLength + 1, " "c).Substring(0, .Segments.MaxCityNameLength + 1) & "</td>")
                    If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>FLOWN</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                    Else
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Departure.TimeShort(":") & "</td>")
                        Dim pDateDiff As Long = DateDiff(DateInterval.Day, pobjSeg.Departure.SegDate, pobjSeg.Arrival.SegDate)
                        If pDateDiff = 0 Then
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Arrival.TimeShort(":") & "</td>")
                        Else
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Arrival.TimeShort(":") & " " & Format(pDateDiff, "+0;-0") & "</td>")
                        End If
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;" & pobjSeg.AirlineLocator & "</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;" & .AllowanceForSegment(pobjSeg.Origin.AirportCode, pobjSeg.Destination.AirportCode, pobjSeg.Airline, pobjSeg.FlightNo, pobjSeg.ClassOfService, pobjSeg.Departure.DateIATA, pobjSeg.Departure.TimeShort) & "</td>")

                    End If
                    pString.AppendLine("</tr>")
                    If pobjSeg.Stopovers <> "" Then
                        pString.AppendLine("<tr>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        If pobjSeg.Stopovers <> "" Then
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>*INTERMEDIATE STOP*  " & pobjSeg.Stopovers.Trim & "</td>")
                        Else
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        End If
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("</tr>")
                    End If

                Next pobjSeg

                pString.AppendLine("</table>")
                pString.AppendLine("</span>")
                'pString.AppendLine("</div>")
                pString.AppendLine("<br />")
                pString.AppendLine("<br />")
                pString.AppendLine("<div>")
                pString.AppendLine("<span style='font-size:10.0pt;font-family:arial'><b><u>Booking Reference</u></b><br />")
                pString.AppendLine(.GDSAbbreviation & "/" & .RequestedPNR & "<br /><br />")
                pString.AppendLine("<b><u>Tickets</u></b><br />")

                For Each pobjPax As GDSPaxItem In .Passengers.Values
                    If .Passengers.Values.Count > 1 Then
                        pString.AppendLine("<u>" & pobjPax.PaxName & "</u><br />")
                    End If

                    For Each tkt As GDSTicketItem In .Tickets.Values
                        If tkt.Pax.Trim = pobjPax.PaxName.Trim Then
                            If tkt.TicketType = "PAX" Then
                                Dim pff As String = ""
                                If Not mobjPNR.ExistingElements Is Nothing Then
                                    pff = mobjPNR.ExistingElements.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.Substring(0, tkt.Pax.Length - 2).Trim)
                                    If pff <> "" Then
                                        pff = "Frequent Flyer Number: " & pff
                                    End If
                                End If
                                pString.AppendLine(tkt.IssuingAirline & "-" & tkt.Document & " " & tkt.AirlineCode & " " & pff & "<br />")
                                End If
                            End If
                    Next
                Next
                pString.AppendLine("<br />")

                pString.AppendLine("Kind Regards<br />")
                pString.AppendLine("</span>")
                pString.AppendLine("</div>")
                pString.AppendLine("</div>")

            End With
        Catch ex As Exception

        End Try

        Return pString.ToString
    End Function
End Class
