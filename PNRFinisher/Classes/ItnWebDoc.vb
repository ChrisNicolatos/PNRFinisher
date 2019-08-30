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
                If .ClientName.Trim <> "" Then
                    pString.AppendLine("For: " & .ClientName)
                End If
                pString.AppendLine("<br /><br />")
                pString.AppendLine("Date: " & Format(Now, "dd/MM/yyyy") & "<br /><br />")
                If mobjPNR.VesselName <> "" Then
                    pString.AppendLine("<b><u>VESSEL:</u></b><br />" & mobjPNR.VesselName & "<br /><br />")
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
                    If iSegCount > 1 And pPrevOff <> pobjSeg.BoardPoint Then
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
                    pPrevOff = pobjSeg.OffPoint
                    pString.AppendLine("<tr>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & iSegCount & "</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Airline & "-" & pobjSeg.AirlineName)
                    If pobjSeg.OperatedBy <> "" Then
                        pString.AppendLine("<br /><span style='font-size:6.0pt;font-family:arial'>" & pobjSeg.OperatedBy & "</span>")
                    End If
                    pString.AppendLine("</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.FlightNo & "</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & Format(pobjSeg.DepartureDate, "dd/MM/yyyy") & "<br><span style='font-size:6.0pt;font-family:arial'>" & pobjSeg.DepartureDay & "</span></td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.BoardPoint & " " & pobjSeg.BoardCityName.PadRight(.MaxCityNameLength + 1, " "c).Substring(0, .MaxCityNameLength + 1) & " - " &
                    pobjSeg.OffPoint & " " & pobjSeg.OffPointCityName.PadRight(.MaxCityNameLength + 1, " "c).Substring(0, .MaxCityNameLength + 1) & "</td>")
                    If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>FLOWN</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                    Else
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.DepartTimeShort(":") & "</td>")
                        Dim pDateDiff As Long = DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate)
                        If pDateDiff = 0 Then
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.ArriveTimeShort(":") & "</td>")
                        Else
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.ArriveTimeShort(":") & " " & Format(pDateDiff, "+0;-0") & "</td>")
                        End If
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;" & pobjSeg.AirlineLocator & "</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;" & .AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline, pobjSeg.FlightNo, pobjSeg.ClassOfService, pobjSeg.DepartureDateIATA, pobjSeg.DepartTimeShort) & "</td>")

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
                                Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.Substring(0, tkt.Pax.Length - 2).Trim)
                                If pFF <> "" Then
                                    pFF = "Frequent Flyer Number: " & pFF
                                End If
                                pString.AppendLine(tkt.IssuingAirline & "-" & tkt.Document & " " & tkt.AirlineCode & " " & pFF & "<br />")
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
