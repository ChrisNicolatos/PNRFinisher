Option Strict Off
Option Explicit On
Public Class GDSExistingCollection

    Private ReadOnly BackOffice As EnumBOCode
    Private mobjPNR1A As s1aPNR.PNR
    Private WithEvents mobjPNR1GRaw As GDSReadPNR1G
    Private mobjPassengers As GDSPaxCollection
    Private mGDSEntryCollection As New ClientReferenceGDSEntryCollection

    Public Property ClientCode As String = ""
    Public Property VesselName As String = ""
    Public Property ClientName As String = ""
    Public Property SSRDocs As String = ""
    Public Property SSRDocsExists As Boolean = False
    Public Property SSRCTCExists As Boolean = False
    Public Property Seats As String = ""

    Public ReadOnly Property OpenSegment As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property PhoneElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property AgentElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property EmailElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property TicketElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property OptionQueueElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property AOH As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property AgentID As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property SavingsElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property LossElement As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property ClientCodeAIItem As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property ClientCodeItem As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property ClientNameItem As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property SubDepartmentCode As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property SubDepartmentName As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property CRMCode As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property CRMName As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property VesselNameItem As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property VesselFlag As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property VesselOSI As GDSExistingItem = New GDSExistingItem(False, 0, "", "", "")
    Public ReadOnly Property SSRDocsCollection As ApisPaxCollection = New ApisPaxCollection
    Public ReadOnly Property FrequentFlyerNumberCollection As FrequentFlyerCollection = New FrequentFlyerCollection
    '
    ' Client References
    '
    Public Property BookedBy As String = ""
    Public Property CostCentre As String = ""

    Public Property ClientReferences As Collections.Generic.List(Of GDSExistingItem)

    Public Sub New(ByVal pBackOffice As EnumBOCode, ByVal pPnr1A As s1aPNR.PNR, ByVal pRTSTR As String, ByVal pPassengers As GDSPaxCollection)
        ' Amadeus
        BackOffice = pBackOffice
        mobjPNR1A = pPnr1A
        mobjPassengers = pPassengers
        ClientReferences = New Collections.Generic.List(Of GDSExistingItem)
        GetPhoneElement1A()
        GetEmailElement1A()
        GetAOH1A()
        GetOpenSegment1A()
        GetTicketElement1A()
        GetOptionQueueElement1A()
        GetVesselOSI1A()
        GetSSR1A()
        GetAI1A()
        GetRM1A()
        GetOtherServiceElements1A()
        GetSSRElements1A(pRTSTR)
        GetSSR1A()
        GetRMElements1A(pBackOffice)

    End Sub
    Public Sub New(ByVal pBackOffice As EnumBOCode, ByVal pPnr1G As GDSReadPNR1G, ByVal pRTSTR As String, ByVal pPassengers As GDSPaxCollection)
        ' Galileo
        BackOffice = pBackOffice
        mobjPNR1GRaw = pPnr1G
        mobjPassengers = pPassengers
        ClientReferences = New Collections.Generic.List(Of GDSExistingItem)

        GetPhoneElement1G()
        GetEmailElement1G()
        GetTicketElement1G()
        GetOpenSegment1G()
        GetOptionQueueElement1G()
        GetSSR1G()
        GetRM1G()

    End Sub
    Private Sub GetOpenSegment1A()

        For Each pSeg As s1aPNR.MemoSegment In mobjPNR1A.MemoSegments
            If pSeg.Text.Contains(MySettings.GDSValue(BackOffice, "TextMISSegmentLookup") & mobjPNR1A.NameElements.Count & " " & MySettings.OfficeCityCode) Then
                _OpenSegment = New GDSExistingItem(True, pSeg.ElementNo, MySettings.GDSElement(BackOffice, "TextMISSegmentLookup"), "", "")
                Exit For
            End If
        Next

    End Sub
    Private Sub GetPhoneElement1A()

        For Each pField As s1aPNR.PhoneElement In mobjPNR1A.PhoneElements
            If pField.Text.Replace(" ", "").Contains(MySettings.GDSValue(BackOffice, "TextAP").Replace(" ", "")) Then
                _PhoneElement = New GDSExistingItem(True, CInt(pField.Text.Substring(0, pField.Text.IndexOf(pField.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextAP"), "", "")
                Exit For
            End If
        Next

    End Sub

    Private Sub GetOpenSegment1G()

        For Each pOpenSeg As OpenSegmentItem In mobjPNR1GRaw.OpenSegments.Values
            If pOpenSeg.SegmentType = "T" Then
                _OpenSegment = New GDSExistingItem(True, pOpenSeg.ElementNo, "Segment", pOpenSeg.Remark.ToString, "")
            End If
        Next
    End Sub
    Private Sub GetPhoneElement1G()

        For Each pPhone As PhoneNumbersItem In mobjPNR1GRaw.PhoneNumbers.Values
            If "P." & pPhone.CityCode & "T*" & pPhone.PhoneNumber = MySettings.GDSValue(BackOffice, "TextAP") Then
                _PhoneElement = New GDSExistingItem(True, pPhone.ElementNo, MySettings.GDSElement(BackOffice, "TextAP"), pPhone.PhoneNumber, pPhone.PhoneNumber)
            ElseIf "P." & pPhone.CityCode & "T*" & pPhone.PhoneNumber = MySettings.GDSValue(BackOffice, "TextAOH") Then
                _AOH = New GDSExistingItem(True, pPhone.ElementNo, MySettings.GDSElement(BackOffice, "TextAOH"), pPhone.PhoneNumber, pPhone.PhoneNumber)
            End If
        Next
    End Sub
    Private Sub GetEmailElement1A()

        For Each pField As s1aPNR.PhoneElement In mobjPNR1A.PhoneElements
            If pField.Text.Contains(MySettings.GDSValue(BackOffice, "TextAPE_ToFind")) Then
                _EmailElement = New GDSExistingItem(True, CInt(pField.Text.Substring(0, pField.Text.IndexOf(pField.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextAPE_ToFind"), "", "")
            End If
        Next
    End Sub
    Private Sub GetEmailElement1G()
        For Each pEmail As EmailItem In mobjPNR1GRaw.Emails.Values
            If "MT." & pEmail.EmailAddress = MySettings.GDSValue(BackOffice, "TextAPE") Then
                _EmailElement = New GDSExistingItem(True, pEmail.ElementNo, MySettings.GDSElement(BackOffice, "TextAPE"), pEmail.EmailAddress, pEmail.EmailAddress)
            End If
        Next
    End Sub
    Private Sub GetAOH1A()
        For Each pElement As s1aPNR.SSRElement In mobjPNR1A.SSRElements
            If pElement.Text.Contains(MySettings.GDSValue(BackOffice, "TextAOH_ToFind")) Then
                _AOH = New GDSExistingItem(True, CInt(pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextAOH_ToFind"), "", "")
            End If
        Next
    End Sub

    Private Sub GetTicketElement1A()
        For Each pElement As s1aPNR.TicketElement In mobjPNR1A.TicketElements
            _TicketElement = New GDSExistingItem(True, CInt(pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1)), "TKT", "", "")
        Next
    End Sub
    Private Sub GetTicketElement1G()

        If mobjPNR1GRaw.TicketElement.ElementNo = 1 Then
            _TicketElement = New GDSExistingItem(True, 1, "T.", CStr(mobjPNR1GRaw.TicketElement.ActionDateTime), "")
        End If
    End Sub

    Private Sub GetOptionQueueElement1A()
        For Each pElement As s1aPNR.OptionQueueElement In mobjPNR1A.OptionQueueElements
            If pElement.Text.Contains(MySettings.GDSValue(BackOffice, "TextOP")) Then
                _OptionQueueElement = New GDSExistingItem(True, CInt(pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextOP"), "", "")
                Exit For
            End If
        Next
    End Sub
    Private Sub GetOptionQueueElement1G()
        For Each pField As OptionQueueItem In mobjPNR1GRaw.OptionQueue.Values
            Dim pFullText As String = MySettings.GDSValue(BackOffice, "TextOP") & "/DDMMM/0001/Q" & MySettings.AgentOPQueue
            If pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextOP")) And pFullText.EndsWith("/0001/Q" & MySettings.AgentOPQueue) Then
                _OptionQueueElement = New GDSExistingItem(True, pField.ElementNo, MySettings.GDSElement(BackOffice, "TextOP"), pField.QueueNumber, pField.QueueNumber)
            End If
        Next
    End Sub
    Private Sub GetVesselOSI1A()
        For Each pOSI As s1aPNR.OtherServiceElement In mobjPNR1A.OtherServiceElements
            If pOSI.Text.Contains(MySettings.GDSValue(BackOffice, "TextVOSI")) Then
                If _VesselOSI.Exists Then
                    Throw New Exception("Please check PNR. Duplicate OSI Vessel defined" & vbCrLf & _VesselOSI.RawText & vbCrLf & pOSI.Text)
                Else
                    Dim pVesselNameOSI As String = pOSI.Text.Substring(pOSI.Text.IndexOf(MySettings.GDSValue(BackOffice, "TextVSL")) + MySettings.GDSValue(BackOffice, "TextVSL").Length)
                    _VesselOSI = New GDSExistingItem(True, CInt(pOSI.Text.Substring(0, pOSI.Text.IndexOf(pOSI.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextVSL"), pOSI.Text, pVesselNameOSI)
                End If
            End If
        Next
    End Sub
    Private Sub GetAI1A()
        For Each pElement As s1aPNR.AccountingAIElement In mobjPNR1A.AccountingAIElements
            If pElement.Text.Contains(MySettings.GDSValue(BackOffice, "TextAI")) Then
                _ClientCodeAIItem = New GDSExistingItem(True, CInt(pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextAI"), pElement.Text, pElement.AccountNo)
            End If
        Next
    End Sub
    Private Sub GetRM1A()
        For Each pRemark As s1aPNR.RemarkElement In mobjPNR1A.RemarkElements
            If pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextAGT")) Then
                _AgentID = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextAGT"), pRemark.Text, "")
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextCLN")) Then
                If _ClientCodeItem.Exists Then
                    Throw New Exception("Please check PNR. Duplicate client defined" & vbCrLf & _ClientCodeItem.RawText & vbCrLf & pRemark.Text)
                Else
                    Dim pClientCode As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue(BackOffice, "TextCLN")) + MySettings.GDSValue(BackOffice, "TextCLN").Length)
                    _ClientCodeItem = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextCLN"), pRemark.Text, pClientCode)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextSBN")) Then
                If _SubDepartmentCode.Exists Then
                    Throw New Exception("Please check PNR. Duplicate subdepartment defined" & vbCrLf & _SubDepartmentCode.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pSubDepartment As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue(BackOffice, "TextSBN")) + MySettings.GDSValue(BackOffice, "TextSBN").Length)
                    _SubDepartmentCode = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextSBN"), "", pSubDepartment)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextCRN")) Then
                If _CRMCode.Exists Then
                    Throw New Exception("Please check PNR. Duplicate CRM defined" & vbCrLf & _CRMCode.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pCRM As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue(BackOffice, "TextCRN")) + MySettings.GDSValue(BackOffice, "TextCRN").Length)
                    _CRMCode = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextCRN"), "", pCRM)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextVSL")) Then
                If _VesselNameItem.Exists Then
                    Throw New Exception("Please check PNR. Duplicate vessel defined" & vbCrLf & _VesselNameItem.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pVesselName As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue(BackOffice, "TextVSL")) + MySettings.GDSValue(BackOffice, "TextVSL").Length)
                    _VesselNameItem = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextVSL"), "", pVesselName)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextVSR")) Then
                If _VesselFlag.Exists Then
                    Throw New Exception("Please check PNR. Duplicate vessel registration defined" & vbCrLf & _VesselFlag.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pVesselRegistration As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue(BackOffice, "TextVSR")) + MySettings.GDSValue(BackOffice, "TextVSR").Length)
                    _VesselFlag = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextVSR"), "", pVesselRegistration)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextCLA")) Then
                If _ClientNameItem.Exists Then
                    Throw New Exception("Please check PNR. Duplicate client name defined" & vbCrLf & _ClientNameItem.LineNumber & vbCrLf & pRemark.Text)
                Else
                    _ClientNameItem = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextCLA"), "", "")
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextSBA")) Then
                _SubDepartmentName = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextSBA"), "", "")
            ElseIf pRemark.Text.Contains(MySettings.GDSValue(BackOffice, "TextCRA")) Then
                _CRMName = New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), MySettings.GDSElement(BackOffice, "TextCRA"), "", "")
            End If

            For Each pItem As ClientReferenceGDSEntry In mGDSEntryCollection.Values
                If pItem.BackOffice = BackOffice Then
                    If pRemark.Text.IndexOf(pItem.Amadeus) >= 0 Then
                        Dim pKey As String = pRemark.Text.Substring(pRemark.Text.IndexOf(pItem.Amadeus) + pItem.Amadeus.Length)
                        If pKey.IndexOf("/") > 0 Then
                            pKey = pKey.Substring(0, pKey.IndexOf("/"))
                        ElseIf pKey.IndexOf("/") = 0 Then
                            pKey = ""
                        End If
                        If pKey <> "" Then
                            ClientReferences.Add(New GDSExistingItem(True, CInt(pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1)), pItem.ID, pRemark.Text, pKey))
                            If pItem.IsVessel Then
                                VesselName = pKey
                            ElseIf pItem.IsBookedBy Then
                                BookedBy = pKey
                            ElseIf pItem.IsCostCentre Then
                                CostCentre = pKey
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub GetRM1G()
        For Each pRemark As DIItem In mobjPNR1GRaw.DIElements.Values
            With pRemark
                Dim pFullText As String = ""
                If .Category = "FT" Then
                    pFullText = "DI." & .Category & "-" & .Remark
                ElseIf .Category = "AC ACCT" Then
                    pFullText = "DI.AC-" & .Remark
                End If
                If pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextAGT")) Then
                    _AgentID = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextAGT"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextAGT").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextCLA")) Then
                    If Not _ClientNameItem.Exists Then
                        ClientName = .Remark.Substring(10)
                        _ClientNameItem = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextCLA"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextCLA").Length))
                    End If
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextCLN")) Then
                    Dim pClientCode As String = pFullText.Substring(MySettings.GDSValue(BackOffice, "TextCLN").Length)
                    If _ClientCodeItem.Exists Then
                        Throw New Exception("Please check PNR. Duplicate client defined" & vbCrLf & _ClientCodeItem.RawText & vbCrLf & .Remark)
                    Else
                        ClientCode = pClientCode
                        _ClientCodeItem = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextCLN"), .Remark, pClientCode)
                    End If
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextCRA")) Then
                    _CRMName = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextCRA"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextCRA").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextCRN")) Then
                    _CRMCode = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextCRN"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextCRN").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextSBA")) Then
                    _SubDepartmentName = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextSBA"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextSBA").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextSBN")) Then
                    _SubDepartmentCode = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextSBN"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextSBN").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextVSL")) Then
                    VesselName = pFullText.Substring(MySettings.GDSValue(BackOffice, "TextVSL").Length)
                    _VesselNameItem = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextVSL"), .Remark, VesselName)
                ElseIf pFullText.StartsWith(MySettings.GDSValue(BackOffice, "TextVSR")) Then
                    _VesselFlag = New GDSExistingItem(True, .ElementNo, MySettings.GDSElement(BackOffice, "TextVSR"), .Remark, pFullText.Substring(MySettings.GDSValue(BackOffice, "TextVSR").Length))
                ElseIf pFullText.StartsWith("D,AC") Then
                    If _ClientCodeItem.Exists Then
                        Throw New Exception("Please check PNR. Duplicate client defined" & vbCrLf & _ClientCodeItem.RawText & vbCrLf & .Remark)
                    Else
                        _ClientCodeItem = New GDSExistingItem(True, .ElementNo, "D,AC", .Remark, "DI.")
                    End If
                End If

                For Each pItem As ClientReferenceGDSEntry In mGDSEntryCollection.Values
                    If pItem.BackOffice = BackOffice Then
                        If pFullText.IndexOf(pItem.Galileo) >= 0 Then
                            Dim pKey As String = pFullText.Substring(pFullText.IndexOf(pItem.Galileo) + pItem.Galileo.Length)
                            If pKey.IndexOf("/") > 0 Then
                                pKey = pKey.Substring(0, pKey.IndexOf("/"))
                            ElseIf pKey.IndexOf("/") = 0 Then
                                pKey = ""
                            End If
                            If pKey <> "" Then
                                ClientReferences.Add(New GDSExistingItem(True, .ElementNo, pItem.ID, .Remark, pKey))
                                If pItem.IsVessel Then
                                    VesselName = pKey
                                ElseIf pItem.IsBookedBy Then
                                    BookedBy = pKey
                                ElseIf pItem.IsCostCentre Then
                                    CostCentre = pKey
                                End If
                            End If
                        End If
                    End If
                Next
            End With

        Next

    End Sub
    Private Sub GetSSR1G()
        SSRDocsExists = False
        SSRDocs = ""
        For Each pobjSSR As SSRitem In mobjPNR1GRaw.SSR.Values
            With pobjSSR
                '"SEMN/VESSEL-CHRISTOS"
                If (("SI." & .CarrierCode & "*" & .Text).StartsWith(MySettings.GDSValue(BackOffice, "TextVOSI"))) Then
                    Dim pVesselNameOSI As String = ("SI." & .CarrierCode & "*" & .Text).Substring(MySettings.GDSValue(BackOffice, "TextVOSI").Length).Trim
                    _VesselOSI = New GDSExistingItem(True, pobjSSR.ElementNo, MySettings.GDSElement(BackOffice, "TextVOSI"), pobjSSR.Text, pVesselNameOSI)
                    VesselName = .Text.Substring(12).Trim
                ElseIf .SSRCode = "DOCS" Then
                    SSRDocs &= "SI.SSR" & .SSRCode & .CarrierCode & .StatusCode & "1" & .Text.Split("-"c)(0) & vbCrLf
                    SSRDocsExists = True
                End If
            End With
        Next pobjSSR
    End Sub
    Private Sub GetRMElements1A(ByVal pBackOffice As Integer)

        For Each pobjRMElement As s1aPNR.RemarkElement In mobjPNR1A.RemarkElements
            parseRMElements1A(pBackOffice, pobjRMElement)
        Next pobjRMElement

    End Sub
    Private Sub parseRMElements1A(ByVal pBackOffice As Integer, ByVal Element As s1aPNR.RemarkElement)

        Dim pintLen As Integer
        Dim pstrText As String
        Dim pstrSplit() As String
        Dim pFound As Boolean = False

        pstrText = Element.ElementID & " " & Element.FreeFlow ' ConcatenateText(Element.Text)
        ClientName = SplitRM1AElement(ClientName, MySettings.GDSValue(pBackOffice, "TextCLA"), pstrText)
        ClientCode = SplitRM1AElement(ClientCode, MySettings.GDSValue(pBackOffice, "TextCLN"), pstrText)
        ClientCode = SplitRM1AElement(ClientCode, "RM *GRACECLN/", pstrText)
        ClientCode = SplitRM1AElement(ClientCode, "RM *D,AC-", pstrText)
        BookedBy = SplitRM1AElement(BookedBy, MySettings.GDSValue(pBackOffice, "TextBBY"), pstrText)
        BookedBy = SplitRM1AElement(BookedBy, "RM *GRACECRM/BOOKED BY-", pstrText)
        BookedBy = SplitRM1AElement(BookedBy, "RM *D,BOOKED-", pstrText)
        VesselName = SplitRM1AElement(VesselName, MySettings.GDSValue(pBackOffice, "TextVSL"), pstrText)
        VesselName = SplitRM1AElement(VesselName, "RM *D,CC1-", pstrText)
        VesselName = SplitRM1AElement(VesselName, "RM *GRACECRM/VESSEL-", pstrText)

        If pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextCLA")) > -1 Then
            ClientName = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextCLA")) + MySettings.GDSValue(pBackOffice, "TextCLA").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextCC")) > -1 Then
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextCLN")) > -1 Then
            ClientCode = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextCLN")) + MySettings.GDSValue(pBackOffice, "TextCLN").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextBBY")) > -1 Then
            BookedBy = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextBBY")) + MySettings.GDSValue(pBackOffice, "TextBBY").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextVSL")) > -1 Then
            VesselName = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextVSL")) + MySettings.GDSValue(pBackOffice, "TextVSL").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue(pBackOffice, "TextTRID")) > -1 Then
            pFound = True
        End If

        If Not pFound Then
            pintLen = pstrText.Length
            pstrSplit = Split(Left(pstrText, pintLen), "/")

            If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
                If pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextCLA")) Then
                    ClientName = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextCC")) Then
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextCLN")) Then
                    ClientCode = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextBBY")) Then
                    BookedBy = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextVSL")) Then
                    VesselName = pstrSplit(2)
                    pFound = True
                End If
            ElseIf IsArray(pstrSplit) AndAlso pstrSplit.Length >= 1 Then
                If pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextTRID")) Then
                    pFound = True
                End If
            End If

        End If
        If Not pFound Then
            pstrSplit = Split(Left(pstrText, pintLen), "-")
            If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
                If pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextCLA")) Then
                    ClientName = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextCC")) Then
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextCLN")) Then
                    ClientCode = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextBBY")) Then
                    BookedBy = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue(pBackOffice, "TextVSL")) Then
                    VesselName = pstrSplit(1)
                End If

            End If

        End If


    End Sub
    Private Function SplitRM1AElement(ByVal OriginalValue As String, ByVal ElementKey As String, ByVal ElementText As String) As String
        Dim pElementFound As String = ""
        Dim pFound As Boolean = False
        Dim pintLen As Integer = ElementText.Length
        If ElementText.IndexOf(ElementKey) > 1 Then
            pElementFound = ElementText.Substring(ElementText.IndexOf(ElementKey) + ElementKey.Length).Trim
            pFound = True
        End If
        If Not pFound Then
            Dim pstrSplit() As String = Split(Left(ElementText, pintLen), "/")
            If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
                If ElementText.StartsWith(ElementKey) Then
                    pElementFound = pstrSplit(1)
                    pFound = True
                End If
            End If
        End If
        If Not pFound Then
            Dim pstrSplit() As String = Split(Left(ElementText, pintLen), "-")
            If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
                If ElementText.StartsWith(ElementKey) Then
                    pElementFound = pstrSplit(1)
                    pFound = True
                End If
            End If
        End If
        If Not pFound Then
            pElementFound = OriginalValue
        End If
        Return pElementFound
    End Function
    Private Sub GetSSRElements1A(ByVal pRTSTR As String)

        Dim pobjSSR As s1aPNR.SSRfqtvElement

        For Each pobjSSR In mobjPNR1A.SSRfqtvElements
            If pobjSSR.Associations.Passengers.Count > 0 Then
                For Each objPax In pobjSSR.Associations.Passengers
                    FrequentFlyerNumberCollection.AddItem(mobjPassengers(objPax.ElementNo).PaxName, pobjSSR.Airline, pobjSSR.FrequentTravelerNo, "")
                Next
            Else
                For Each pPax As GDSPaxItem In mobjPassengers.Values
                    FrequentFlyerNumberCollection.AddItem(pPax.PaxName, pobjSSR.Airline, pobjSSR.FrequentTravelerNo, "")
                Next
            End If
        Next

        If pRTSTR.IndexOf("NO SEATS") = 0 Then
            Seats = ""
        Else
            Dim pTemp() As String = pRTSTR.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            Dim pTemp2 As String = ""
            If IsArray(pTemp) Then

                pTemp2 = pTemp(0)
                For i As Integer = 1 To pTemp.GetUpperBound(0)
                    If pTemp(i).Length > 10 Then
                        If pTemp2.Length > 0 Then
                            pTemp2 &= vbCrLf
                        End If
                        If pTemp(i).Length > 25 AndAlso pTemp(i).Substring(0, 25).Replace(" ", "").Length = 18 AndAlso pTemp(i).StartsWith(Space(4)) AndAlso pTemp(i).Substring(10, 1) = " " AndAlso pTemp(i).Substring(12, 1) = " " Then
                            pTemp2 &= pTemp(i).Substring(0, 10) & " " & pTemp(i).Substring(13)
                        Else
                            pTemp2 &= pTemp(i)
                        End If
                    End If
                Next
            End If
            Seats = pTemp2
        End If

    End Sub

    Private Sub GetSSR1A()
        SSRDocsExists = False
        SSRCTCExists = False
        SSRDocs = ""
        SSRDocsCollection.Clear()

        For Each pSSR As s1aPNR.SSRElement In mobjPNR1A.SSRElements
            If pSSR.Text.IndexOf("SSR DOCS") > 0 And pSSR.Text.IndexOf("SSR DOCS") < 10 Then
                SSRDocs &= pSSR.Text & vbCrLf
                SSRDocsCollection.AddSSRDocsItem(pSSR.ElementNo, pSSR.FreeFlow)
                SSRDocsExists = True
            ElseIf pSSR.Text.IndexOf("SSR CTC") > 0 And pSSR.Text.IndexOf("SSR CTC") < 10 Then
                SSRCTCExists = True
            End If
        Next
    End Sub
    Private Sub GetOtherServiceElements1A()

        For Each pobjOtherServiceElement As s1aPNR.OtherServiceElement In mobjPNR1A.OtherServiceElements
            parseOtherServiceElements1A(pobjOtherServiceElement)
        Next pobjOtherServiceElement

    End Sub

    Private Sub parseOtherServiceElements1A(ByVal Element As s1aPNR.OtherServiceElement)

        Dim i As Integer
        Dim j As Integer

        Dim pintLen As Integer
        Dim pstrText As String
        Dim pstrSplit() As String

        pstrText = Element.ElementID & " " & Element.FreeFlow ' ConcatenateText(Element.Text)
        pintLen = pstrText.Length

        i = InStr(pstrText, "/SG")
        j = InStr(pstrText, "/P")
        If i > 0 And i - 1 < pintLen Then
            pintLen = i - 1
        End If
        If j > 0 And j - 1 < pintLen Then
            pintLen = j - 1
        End If

        pstrSplit = Split(Left(pstrText, pintLen), " ")

        If IsArray(pstrSplit) Then
            For i = pstrSplit.GetLowerBound(0) To pstrSplit.GetUpperBound(0)
                If pstrSplit(i) = "MV" Then
                    VesselName = ""
                    For j = i + 1 To pstrSplit.GetUpperBound(0)
                        VesselName = VesselName & " " & pstrSplit(j).Trim
                    Next j
                    Exit For
                ElseIf pstrSplit(i).StartsWith("SEMN/VESSEL") Then
                    VesselName = pstrSplit(i).Substring(12).Trim
                    For j = i + 1 To pstrSplit.GetUpperBound(0)
                        If pstrSplit(j) <> "-" Then
                            VesselName = VesselName & " " & pstrSplit(j).Trim
                        End If
                    Next j
                    Exit For
                End If
            Next i
        End If

    End Sub
    Public ReadOnly Property FrequentFlyerNumber(ByVal Airline As String, ByVal PaxName As String) As String
        Get
            FrequentFlyerNumber = ""
            For Each pItem As FrequentFlyerItem In FrequentFlyerNumberCollection
                If pItem.PaxName.StartsWith(PaxName) Or PaxName.StartsWith(pItem.PaxName) Then
                    Dim pAirlineCode = Airlines.AirlineCode(Airline)
                    If pItem.Airline = Airline Or pItem.Airline = pAirlineCode Then
                        FrequentFlyerNumber = pItem.Airline & " " & pItem.FrequentTravelerNo
                        Exit For
                    ElseIf pItem.CrossAccrual.IndexOf(Airline) > -1 Or pItem.CrossAccrual.IndexOf(pAirlineCode) > -1 Then
                        FrequentFlyerNumber = pItem.Airline & " " & pItem.FrequentTravelerNo '& " (Cross Accrual: " & pItem.CrossAccrual & ")"
                    End If
                End If
            Next
        End Get
    End Property

End Class