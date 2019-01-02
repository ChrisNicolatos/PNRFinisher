Public Class OSMWebDoc
    Public Function OSMWebHeader(ByVal ShowFullPaxDetails As Boolean, ByRef lstOSMAgents As ListBox, ByRef lstOSMToEmail As ListBox, ByRef lstOSMCCEmail As ListBox, ByRef lstOSMVessels As ListBox, ByRef dgvOSMPax As DataGridView, ByRef mOSMPax As OSMPaxCollection) As String

        Try
            Dim xDoctext As String = "<html><head></head><body>"

            xDoctext &= "MESSAGE FROM :<br>"
            xDoctext &= "<b>ATPI GRIFFINSTONE GREECE</b><br><br>"

            For Each pSelectedAgent As OSMEmailItem In lstOSMAgents.SelectedItems
                xDoctext &= "TO         : " & pSelectedAgent.Name & " / " & pSelectedAgent.Details & "<br>"
            Next

            For Each pEmail As OSMEmailItem In lstOSMToEmail.Items
                If lstOSMVessels.SelectedItems.Count > 1 Then
                    xDoctext &= "TO         : " & pEmail.Name & If(pEmail.Details <> "", " / " & pEmail.Details, "") & If(pEmail.VesselName <> "", "(" & pEmail.VesselName & ")", "") & "<br>"
                Else
                    xDoctext &= "TO         : " & pEmail.Name & If(pEmail.Details <> "", " / " & pEmail.Details, "") & "<br>"
                End If
            Next

            xDoctext &= "<br>"
            xDoctext &= "CC         : OSM CYPRUS<br>"
            For Each pEmail As OSMEmailItem In lstOSMCCEmail.Items
                xDoctext &= "CC         : " & pEmail.Name & If(pEmail.Details <> "", " / " & pEmail.Details, "") & "<br>"
            Next
            xDoctext &= "CC         : 3rd party applicable<br>"
            xDoctext &= "<br>"
            xDoctext &= "<br>If more information is required please contact ATPI Greece and copy vessel's IMO email address.<br><br>"
            xDoctext &= "DATE/REF   : " & Format(Now, "dd/MM/yyyy") & "<br><br><br>"
            Dim pTempSubject As String = ""

            For Each pVessel As OSMVesselItem In lstOSMVessels.SelectedItems
                If pTempSubject <> "" Then
                    pTempSubject &= " / "
                End If
                pTempSubject &= pVessel.VesselName
            Next
            xDoctext &= "SUBJECT     : VSL " & pTempSubject & " CREW CHANGE AT PORT  <br>"

            xDoctext &= "<br><br>"
            xDoctext &= "PLEASE BE ADVISED OF THE FOLLOWING ARRANGEMENTS FOR EMBARKING / DISEMBARKING CREW.<br><br><br>"
            xDoctext &= "<font color=" & Chr(34) & "red" & Chr(34) & ">PLEASE CONFIRM RECEIPT OF BELOW :</font><br><br><br>"

            Dim pOnSigners As String = ""
            Dim pOnSignerNoVisa As String = ""
            Dim pOnSignerVisa As String = ""
            Dim pOnSignerOKTB As String = ""

            Dim pOffSigners As String = ""

            Dim pOther As String = ""

            For i As Integer = 0 To dgvOSMPax.Rows.Count - 1
                Dim pId As Integer = CInt(dgvOSMPax.Rows(i).Cells(0).Value)
                Dim pPax As OSMPaxItem = mOSMPax(pId)
                Select Case CStr(dgvOSMPax.Rows(i).Cells("JoinerLeaver").Value)
                    Case "ONSIGNER"
                        If ShowFullPaxDetails Then
                            pOnSigners &= "<pre>" & pPax.TextFullDetails & "</pre><br><br>"
                        Else
                            pOnSigners &= "<pre>" & pPax.Text & "</pre><br><br>"
                        End If
                    Case "OFFSIGNER"
                        If ShowFullPaxDetails Then
                            pOffSigners &= "<pre>" & pPax.TextFullDetails & "</pre><br><br>"
                        Else
                            pOffSigners &= "<pre>" & pPax.Text & "</pre><br><br>"
                        End If
                    Case Else
                        If ShowFullPaxDetails Then
                            pOther &= "<pre>" & pPax.TextFullDetails & "</pre><br><br>"
                        Else
                            pOther &= "<pre>" & pPax.Text & "</pre><br><br>"
                        End If
                End Select

                Select Case CStr(dgvOSMPax.Rows(i).Cells("VisaType").Value)
                    Case "OKTB"
                        pOnSignerOKTB &= dgvOSMPax.Rows(i).Cells("Lastname").Value.ToString & "/" & dgvOSMPax.Rows(i).Cells("Firstname").Value.ToString & "<br>"
                    Case "NO VISA"
                        pOnSignerNoVisa &= dgvOSMPax.Rows(i).Cells("Lastname").Value.ToString & "/" & dgvOSMPax.Rows(i).Cells("Firstname").Value.ToString & "<br>"
                    Case "VISA"
                        pOnSignerVisa &= dgvOSMPax.Rows(i).Cells("Lastname").Value.ToString & "/" & dgvOSMPax.Rows(i).Cells("Firstname").Value.ToString & "<br>"
                End Select
            Next

            If pOther <> "" Then
                xDoctext &= "PARTICULARS OF TRAVELLER AS FOLLOWS:</b><br><br>"
                xDoctext &= "<pre>" & pOther
                xDoctext &= "<font color=" & Chr(34) & "red" & Chr(34) & ">FLIGHT DETAILS: </font></pre><br><br>"
            End If
            If pOnSigners <> "" Then
                xDoctext &= "PARTICULARS OF JOINERS AS FOLLOWS:</b><br><br>"
                xDoctext &= "SIGNING ON<br><br>"
                xDoctext &= "<pre>" & pOnSigners
                xDoctext &= "<font color=" & Chr(34) & "red" & Chr(34) & "><b>FLIGHT DETAILS: </b></font><br><br>"
                If pOnSignerNoVisa <> "" Then
                    xDoctext &= "<hr width=30% align=left>" & pOnSignerNoVisa & "<br><br>"
                    xDoctext &= "<pre><b>NO VISA REQUIRED</b></pre><br><br>"
                End If
                If pOnSignerVisa <> "" Then
                    xDoctext &= "<hr width=30% align=left>" & pOnSignerVisa & "<br><br>"
                    xDoctext &= "<pre><b>VISA REQUIRED</b></pre><br><br>"
                    xDoctext &= "<b>CREW WILL TRAVEL WITH VALID VISA. <br><br>"
                    xDoctext &= "AGENT PLEASE ENSURE THAT ONSIGNER'S PASSPORT HAVE AN EXIT STAMP <br>"
                    xDoctext &= "FROM THE IMMIGRATION BEFORE THEY GO ON BOARD. </b><br><br>"
                End If
                If pOnSignerOKTB <> "" Then
                    xDoctext &= "<hr width=30% align=left>" & pOnSignerOKTB & "<br>"
                    xDoctext &= "<pre><b>OKTB</b></pre><br><br>"
                    xDoctext &= "<b>*****IMPORTANT******<br><br>"
                    xDoctext &= "PLS SEND -OK TO BOARD- TO ____ THROUGH NEAREST TOWNOFFICE/AIRPORT<br>"
                    xDoctext &= "OFFICE YOUR SIDE .<br><br>"
                    xDoctext &= "THE LETTER SHOULD CONTAIN THE FOLLOWING WORDINGS OK TO BOARD THAT<br>"
                    xDoctext &= "AIRLINE COUNTER IS REQUIRING FROM THE AGENT.<br><br>"
                    xDoctext &= "WE NEED YOUR FORMAL ACKNOWLEDGEMENT THAT YOU HAVE GIVEN THE -OK TO BOARD<br>"
                    xDoctext &= "PLS ALSO SEND COPY OF OK TO BOARD TO :<br><br>"
                    xDoctext &= "ATPI ATHENS  = E-MAIL : osmsmart.greece@ atpi.com<br>"
                    xDoctext &= "OSM ________ = E-MAIL : _________@_______<br><br>"
                    xDoctext &= "AGENT PLEASE ENSURE THAT ONSIGNER'S PASSPORT HAVE AN EXIT STAMP <br>"
                    xDoctext &= "FROM THE IMMIGRATION BEFORE THEY GO ON BOARD. </b><br><br>"
                End If
                xDoctext &= " "
                xDoctext &= "<br>AGENT PLS CHECK IF THIS ARRANGEMENT IS ACCEPTABLE WITH ETA/ETD<br><br>"
                xDoctext &= "PLS LIASE WITH MASTER, MEET CREW, ARRANGE ENTRY FORMALITIES AND SECURE <br>"
                xDoctext &= "SAFE JOINSHIP.</pre><br>"
            End If
            If pOffSigners <> "" Then
                xDoctext &= "<hr SIZE=2 COLOR=gray>"
                xDoctext &= "<b>TO MASTER/PORT AGENT</b><br><br>"
                xDoctext &= "FOLLOWING ROUTE ARE CONFIRMED FOR HOMEGOING CREW AS FLWS :<br><br>"
                xDoctext &= "OFFSIGNER:<br><br>"
                xDoctext &= "<pre>" & pOffSigners & "</pre><br>"
                xDoctext &= "<pre><font color=" & Chr(34) & "red" & Chr(34) & "><b>FLIGHT DETAILS: </b></font></pre><br><br>"
                xDoctext &= "<pre><b>AGENT – CREW TRAVELING ON E-TICKETS, AND MUST GO DIRECTLY TO CHECK-IN<br>"
                xDoctext &= "COUNTER AT AIRPORT WITH PASSPORT READY.</b></pre><br><br>"
                xDoctext &= "<br><pre>PLS LIASE WITH MASTER AND CONVEY CREW TO AIRPORT.</pre><br>"

            End If
            xDoctext &= "<br><pre>IF ANY PROBLEM REGARDING FLIGHT DETAILS, PLS CONTACT OUR OFFICE.</pre><br><br>"

            xDoctext &= "</body></html>"

            Return xDoctext
        Catch ex As Exception
            Throw New Exception("OSMWebHeader()" & vbCrLf & ex.Message)
        End Try
    End Function
End Class
