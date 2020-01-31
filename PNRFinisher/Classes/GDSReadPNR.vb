Option Strict Off ' Unfortunately Amadeus uses Objects in its libraries so STRICT doesn't work
Option Explicit On
Imports k1aHostToolKit
Public Class GDSReadPNR
    Public Event NewItemCreated()
    Private Structure LineNumbers
        Dim Category As String
        Dim LineNumber As Integer
    End Structure

    Private mobjHostSessions As k1aHostToolKit.HostSessions
    Private WithEvents mobjSession1A As k1aHostToolKit.HostSession
    Private mobjPNR1A As s1aPNR.PNR

    Private mobjSession1G As Travelport.TravelData.Factory.GalileoDesktopFactory
    Private WithEvents mobjPNR1GRaw As GDSReadPNR1G

    Private mobjPassengers As GDSPaxCollection
    Private mobjSegments As GDSSegCollection
    Private mobjTickets As GDSTicketCollection
    Private mobjItinRemarks As GDSItineraryRemarksCollection
    'Private mobjFrequentFlyer As FrequentFlyerCollection
    Private mobjNumberParser As GDSNumberParser
    'Private mobjExistingGDSElements As GDSExistingCollection
    Private WithEvents mobjNewGDSElements As GDSNewCollection
    Private mobjBaggageAllowance As BaggageAllowanceCollection
    Private mstrPNRResponse As String
    'Private mobjSSRDocs As ApisPaxCollection
    Private mflgCancelError As Boolean

    Private mstrStatus As String
    Public Sub New(ByVal pGDSCode As modEnums.EnumGDSCode)

        GDSCode = pGDSCode
        If GDSCode = EnumGDSCode.Galileo Then
            mobjSession1G = New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")
        End If
        ClearElements()

    End Sub
    Private Sub IsAmadeus()
        If GDSCode <> EnumGDSCode.Amadeus Then
            Throw New Exception("Selected GDS is not Amadeus")
        End If
    End Sub
    Private Sub IsGalileo()
        If GDSCode <> EnumGDSCode.Galileo Then
            Throw New Exception("Selected GDS is not Galileo")
        End If
    End Sub
    Private Sub ClearElements()

        If GDSCode = EnumGDSCode.Galileo Then
            mobjPNR1GRaw = New GDSReadPNR1G
        End If
        mobjPassengers = New GDSPaxCollection
        mobjSegments = New GDSSegCollection
        mobjTickets = New GDSTicketCollection
        mobjItinRemarks = New GDSItineraryRemarksCollection
        'mobjFrequentFlyer = New FrequentFlyerCollection
        mobjNumberParser = New GDSNumberParser
        'mobjExistingGDSElements.Clear()
        mobjNewGDSElements = New GDSNewCollection
        mobjBaggageAllowance = New BaggageAllowanceCollection

        mstrPNRResponse = ""
        PnrNumber = ""
        NewPNR = False
        GroupName = ""
        GroupNamesCount = 0

        OfficeOfResponsibility = ""
        'SSRDocsExists = False
        'SSRCTCExists = False
        'SSRDocs = ""
        'mobjSSRDocs = New ApisPaxCollection

        'VesselName = ""
        'BookedBy = ""
        'ClientCode = ""
        'ClientName = ""
        'ClientBO = EnumBOCode.Unknown
        mflgCancelError = False
        mstrStatus = ""

    End Sub
    Private Sub GetActiveAmadeusSession()
        mobjHostSessions = New k1aHostToolKit.HostSessions
        If mobjHostSessions.Count > 0 Then
            mobjSession1A = mobjHostSessions.UIActiveSession
        Else
            Throw New Exception("Amadeus not signed in")
        End If
    End Sub

    Private Sub mobjSession_ReceivedResponse(ByRef newResponse As CHostResponse) Handles mobjSession1A.ReceivedResponse
        mstrPNRResponse = newResponse.Text
    End Sub

    Public ReadOnly Property Segments As GDSSegCollection
        Get
            Return mobjSegments
        End Get
    End Property

    Public ReadOnly Property Passengers As GDSPaxCollection
        Get
            Return mobjPassengers
        End Get
    End Property

    Public ReadOnly Property AllowanceForSegment(ByVal Origin As String, ByVal Destination As String, ByVal Airline As String, ByVal FlightNumber As String, ByVal ClassOfService As String, ByVal DepDate As String, ByVal DepTime As String) As String
        Get
            Return mobjBaggageAllowance.BaggageAllowance(Origin, Destination, Airline, FlightNumber, ClassOfService, DepDate, DepTime)
        End Get
    End Property

    Public Property GroupName As String = ""
    Public Property GroupNamesCount As Integer = 0
    Public ReadOnly Property NumberOfPax As Integer
        Get
            Return mobjPassengers.Count
        End Get
    End Property
    'Public ReadOnly Property SSRDocsCollection As ApisPaxCollection
    '    Get
    '        Return mobjSSRDocs
    '    End Get
    'End Property
    Public ReadOnly Property IsGroup As Boolean
        Get
            Return (GroupName <> "")
        End Get
    End Property
    Public ReadOnly Property Tickets() As GDSTicketCollection
        Get
            Return mobjTickets
        End Get
    End Property

    'Public ReadOnly Property FrequentFlyerNumber(ByVal Airline As String, ByVal PaxName As String) As String
    '    Get
    '        FrequentFlyerNumber = ""
    '        For Each pItem As FrequentFlyerItem In mobjFrequentFlyer
    '            If pItem.PaxName.StartsWith(PaxName) Or PaxName.StartsWith(pItem.PaxName) Then
    '                Dim pAirlineCode = Airlines.AirlineCode(Airline)
    '                If pItem.Airline = Airline Or pItem.Airline = pAirlineCode Then
    '                    FrequentFlyerNumber = pItem.Airline & " " & pItem.FrequentTravelerNo
    '                    Exit For
    '                ElseIf pItem.CrossAccrual.IndexOf(Airline) > -1 Or pItem.CrossAccrual.IndexOf(pAirlineCode) > -1 Then
    '                    FrequentFlyerNumber = pItem.Airline & " " & pItem.FrequentTravelerNo '& " (Cross Accrual: " & pItem.CrossAccrual & ")"
    '                End If
    '            End If
    '        Next
    '    End Get
    'End Property
    'Public ReadOnly Property FrequentFlyernumberCollection As FrequentFlyerCollection
    '    Get
    '        Return mobjFrequentFlyer
    '    End Get
    'End Property
    'Public  Property ClientBO As EnumBOCode = EnumBOCode.Unknown

    'Public Property VesselName As String = ""
    'Public Property ClientName As String = ""
    'Public Property BookedBy As String = ""
    'Public Property CostCentre As String = ""
    Public Property RequestedPNR As String = ""
    'Public Property Seats As String = ""
    Public Property PnrNumber As String = ""
    Public Property OfficeOfResponsibility As String = ""
    Public Property ExistingElements As GDSExistingCollection
    '    Get
    '        Return mobjExistingGDSElements
    '    End Get
    'End Property
    Public ReadOnly Property NewElements As GDSNewCollection
        Get
            Return mobjNewGDSElements
        End Get
    End Property
    'Public Property SSRCTCExists As Boolean = False
    'Public Property SSRDocs As String = ""
    'Public Property SSRDocsExists As Boolean = False
    Public ReadOnly Property GDSAbbreviation As String
        Get
            If GDSCode = EnumGDSCode.Amadeus Then
                Return "1A"
            ElseIf GDSCode = EnumGDSCode.Galileo Then
                Return "1G"
            Else
                Return ""
            End If
        End Get
    End Property
    Public ReadOnly Property GDSCode As EnumGDSCode
    Public ReadOnly Property CancelError() As Boolean
        Get
            Return mflgCancelError
        End Get
    End Property
    Public Property NewPNR As Boolean = False
    Public ReadOnly Property ItineraryRemarks As GDSItineraryRemarksCollection
        Get
            Return mobjItinRemarks
        End Get
    End Property
    Public Function RetrievePNRsFromQueue(ByVal Queue As String) As String

        Dim pQV As String = ""
        RetrievePNRsFromQueue = ""
        Try
            mstrStatus = ""
            GetActiveAmadeusSession()
            If Queue <> "" Then
                mobjSession1A.Send("QI")
                mobjSession1A.Send("IG")
            End If
            pQV &= mobjSession1A.Send("QV/" & Queue).Text
            Do While pQV.LastIndexOf(")>") = pQV.Length - 4
                pQV &= mobjSession1A.Send("MDR").Text
            Loop
            Dim pLines() As String = pQV.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim pPNRs As String = ""
            For i As Integer = 4 To pLines.GetUpperBound(0)
                If pLines(i).Length >= 19 Then
                    pPNRs &= pLines(i).Substring(14, 6) & vbCrLf
                End If
            Next
            RetrievePNRsFromQueue = pPNRs
        Catch ex As Exception
            mstrStatus = Err.Description
            If CancelError Then
                Throw New Exception("RetrievePNRsFromQueue()" & vbCrLf & mstrStatus)
            End If
        End Try
    End Function
    Public Sub ReadItinerary(ByVal pBackOffice As EnumBOCode, ByVal PNR As String)
        ' Itinerary
        mflgCancelError = (PNR = "")
        ClearElements()
        If GDSCode = EnumGDSCode.Amadeus Then
            Read1A(pBackOffice, PNR)
        ElseIf GDSCode = EnumGDSCode.Galileo Then
            ReadPNR1G(pBackOffice, PNR)
        Else
            Throw New Exception("Incorrect GDS")
        End If
    End Sub
    Public Function ReadFinisher(ByVal pBackOffice As EnumBOCode) As String
        ' Finisher
        Dim pReturnValue As String = ""
        ClearElements()
        If GDSCode = EnumGDSCode.Amadeus Then
            pReturnValue = RetrievePNR1AFinisher(pBackOffice)
        ElseIf GDSCode = EnumGDSCode.Galileo Then
            pReturnValue = Read1G(pBackOffice)
        Else
            Throw New Exception("GDSReadPNR.Read()" & vbCrLf & "NO GDS Specified")
        End If
        Return pReturnValue
    End Function
    Private Sub Read1A(ByVal pBackOffice As EnumBOCode, ByVal PNR As String)
        ' Itinerary
        Try
            IsAmadeus()
            mstrStatus = ""
            GetActiveAmadeusSession()
            If PNR <> "" Then
                mobjSession1A.Send("QI")
                mobjSession1A.Send("IG")
            End If
            RequestedPNR = PNR
            Dim pReturnValue As Boolean = RetrievePNR1AItinerary(pBackOffice)
            If pReturnValue Then
                mstrStatus = "Amadeus read " & PNR & " OK"
            Else
                mstrStatus = "Amadeus " & PNR & " not found"
            End If
            mobjSession1A.SendSpecialKey(512 + 282) '(k1aHostConstantsLib.AmaKeyValues.keySHIFT + k1aHostConstantsLib.AmaKeyValues.keyPause)
            mobjSession1A.Send("RT")
        Catch ex As Exception
            mstrStatus = Err.Description
            If CancelError Then
                Throw New Exception("GDSReadPNR.Read1A()" & vbCrLf & mstrStatus)
            End If
        End Try

    End Sub
    Private Function RetrievePNR1AFinisher(ByVal pBackOffice As EnumBOCode) As String
        ' Finisher
        Try
            Dim pReturnValue As String = ""
            IsAmadeus()
            GetActiveAmadeusSession()
            mobjPNR1A = New s1aPNR.PNR
            Dim pStatus As Integer = mobjPNR1A.RetrievePNR(mobjSession1A, "RT")
            Dim pSeatData As String = mobjSession1A.Send("RTSTR").Text
            NewPNR = False
            If pStatus = 0 Or pStatus = 1005 Then
                GetOfficeOfResponsibility1A()
                GetPnrNumber1A()
                GetGroup1A()
                GetPassengers1A()
                GetSegs1AFinisher()
                'GetPhoneElement1A(pBackOffice)
                'GetEmailElement1A(pBackOffice)
                'GetAOH1A(pBackOffice)
                'GetOpenSegment1A(pBackOffice)
                'GetTicketElement1A()
                'GetOptionQueueElement1A(pBackOffice)
                'GetVesselOSI1A(pBackOffice)
                'GetSSR1A()
                'GetAI1A(pBackOffice)
                'GetRM1A(pBackOffice)
                GetTickets1A()
                GetItinRemarks1A()
                ExistingElements = New GDSExistingCollection(pBackOffice, mobjPNR1A, pSeatData, mobjPassengers)
                If mobjPNR1A.RawResponse.IndexOf("***  NHP  ***") >= 0 Then
                    pReturnValue = "               ***  NHP  ***"
                Else
                    pReturnValue = CheckDMI1A()
                End If
                Return pReturnValue
            Else
                Throw New Exception("There is no active PNR" & vbCrLf & mstrPNRResponse)
            End If
        Catch ex As Exception
            Throw New Exception("GDSReadPNR.Read1A()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function RetrievePNR1AItinerary(ByVal pBackOffice As EnumBOCode) As Boolean
        ' Itinerary
        Dim pintPNRStatus As Integer
        Dim pReturnValue As Boolean = False

        mobjPNR1A = New s1aPNR.PNR
        mobjTickets = New GDSTicketCollection
        mobjItinRemarks = New GDSItineraryRemarksCollection
        'VesselName = ""
        'BookedBy = ""
        'ClientName = ""
        'ClientCode = ""
        'ClientBO = EnumBOCode.Unknown


        If RequestedPNR = "" Then
            pintPNRStatus = mobjPNR1A.RetrieveCurrent(mobjSession1A)
        Else
            pintPNRStatus = mobjPNR1A.RetrievePNR(mobjSession1A, "RT" & RequestedPNR)
        End If
        Dim pSeatData As String = mobjSession1A.Send("RTSTR").Text
        If pintPNRStatus = 0 Or pintPNRStatus = 1005 Then
            RequestedPNR = setRecordLocator1A()
            GetTQT1A()
            GetGroup1A()
            GetPax1A()
            GetSegs1AItinerary()
            GetAutoTickets1A()
            'GetOtherServiceElements1A()
            'GetSSRElements1A()
            'GetSSR1A()
            'GetRMElements1A(pBackOffice)
            GetItinRemarks1A()
            ExistingElements = New GDSExistingCollection(pBackOffice, mobjPNR1A, pSeatData, mobjPassengers)
            pReturnValue = True
        Else
            pReturnValue = False
        End If
        Return pReturnValue
    End Function

    Private Sub ReadPNR1G(ByVal pBackOffice As EnumBOCode, ByVal PNR As String)
        Try
            If PNR <> "" Then
                mobjSession1G.SendTerminalCommand("QXI+I")
            End If
            RequestedPNR = PNR
            Read1G(pBackOffice)
        Catch ex As Exception
            Throw New Exception("GDSReadPNR.ReadPNR1G()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Read1G(ByVal pBackOffice As EnumBOCode) As String

        mobjPNR1GRaw = New GDSReadPNR1G
        Dim pResponse As ObjectModel.ReadOnlyCollection(Of String) = mobjSession1G.SendTerminalCommand("*R")
        If pResponse.Count > 0 AndAlso pResponse(0).Length > 5 AndAlso pResponse(0).Substring(6, 1) = "/" Then
            RequestedPNR = pResponse(0).Substring(0, 6)
        ElseIf pResponse.Count > 1 AndAlso pResponse(1).Length > 5 AndAlso pResponse(1).Substring(6, 1) = "/" Then
            RequestedPNR = pResponse(1).Substring(0, 6)
        ElseIf pResponse.Count > 2 AndAlso pResponse(2).Length > 6 AndAlso pResponse(2).Substring(6, 1) = "/" Then
            RequestedPNR = pResponse(2).Substring(0, 6)
        ElseIf Not pResponse(0).StartsWith(" ") Then
            Throw New Exception(pResponse(0))
        Else
            RequestedPNR = ""
        End If
        Read1G = ""
        If RequestedPNR.Trim <> "" Then
            mobjSession1G.SendTerminalCommand("*" & RequestedPNR)
        End If
        Try
            mobjTickets = New GDSTicketCollection
            mobjItinRemarks = New GDSItineraryRemarksCollection
            'VesselName = ""
            'BookedBy = ""
            'ClientName = ""
            'ClientCode = ""
            'ClientBO = EnumBOCode.Unknown

            mobjPNR1GRaw.ReadRaw(RequestedPNR)
            RequestedPNR = mobjPNR1GRaw.RequestedPNR
            OfficeOfResponsibility = mobjPNR1GRaw.OfficeOfResponsibility
            mobjPassengers = mobjPNR1GRaw.Passengers
            mobjSegments = mobjPNR1GRaw.Segments
            'mobjFrequentFlyer = mobjPNR1GRaw.FrequentFlyers
            mobjItinRemarks = mobjPNR1GRaw.ItineraryRemarks
            ExistingElements = New GDSExistingCollection(pBackOffice, mobjPNR1GRaw, mobjPNR1GRaw.Seats, mobjPassengers)
            'mstrItinerary = mobjSegments.Itinerary
            'mdteDepartureDate = mobjPNR1GRaw.DepartureDate
            'mflgExistsSegments = (mobjSegments.Count > 0)
            'mSegsFirstElement = mobjPNR1GRaw.SegsFirstElement
            'mSegsLastElement = mobjPNR1GRaw.SegsLastElement
            'mudtAllowance = mobjPNR1GRaw.Allowance
            mobjBaggageAllowance = mobjPNR1GRaw.BaggageAllowance
            mobjTickets = mobjPNR1GRaw.Tickets
            'Seats = mobjPNR1GRaw.Seats
            'SSRCTCExists = mobjPNR1GRaw.HasCTC
            'GetPhoneElement1G(pBackOffice)
            'GetEmailElement1G(pBackOffice)
            'GetTicketElement1G()
            'GetOpenSegment1G(pBackOffice)
            'GetOptionQueueElement1G(pBackOffice)
            'GetSSR1G(pBackOffice)
            'GetRM1G(pBackOffice)
        Catch ex As Exception
            Throw New Exception("GDSReadPNR.Read1G()" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Sub PrepareNewGDSElements(ByVal pBackOffice As Integer)
        Try
            mobjNewGDSElements = New GDSNewCollection(OfficeOfResponsibility, Segments.DepartureDate, Passengers.Count, GDSCode, pBackOffice)
        Catch ex As Exception
        End Try
    End Sub
    Private Function CheckDMI1A() As String
        Try
            IsAmadeus()
            If mobjPNR1A.AirSegments.Count <= 1 Then
                Return ""
            End If
            Dim pDMI As String = mobjSession1A.Send("DMI").Text.Replace(vbCrLf & ">" & vbCrLf, "")
            If pDMI.Contains("ITINERARY OK") Then
                Return ""
            Else
                Return pDMI
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub RemoveOldGDSEntries1A()
        IsAmadeus()
        Dim pLineNumbers(0) As Integer
        ' the following elements remain as they are if they already exist in the PNR
        ClearExistingItems(ExistingElements.PhoneElement, mobjNewGDSElements.PhoneElement)
        ClearExistingItems(ExistingElements.EmailElement, mobjNewGDSElements.EmailElement)
        ClearExistingItems(ExistingElements.AOH, mobjNewGDSElements.AOH)
        ClearExistingItems(ExistingElements.OpenSegment, mobjNewGDSElements.OpenSegment)
        ClearExistingItems(ExistingElements.OptionQueueElement, mobjNewGDSElements.OptionQueueElement)
        ClearExistingItems(ExistingElements.TicketElement, mobjNewGDSElements.TicketElement)
        ClearExistingItems(ExistingElements.AgentID, mobjNewGDSElements.AgentID)
        ' the following elements are removed and replaced if they exist in the PNR
        PrepareLineNumbers1A(ExistingElements.ClientCodeAIItem, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.ClientCodeItem, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.ClientNameItem, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.SubDepartmentCode, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.SubDepartmentName, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.CRMCode, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.CRMName, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.VesselFlag, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.VesselNameItem, pLineNumbers)
        PrepareLineNumbers1A(ExistingElements.VesselOSI, pLineNumbers)
        For Each pItem As GDSExistingItem In ExistingElements.ClientReferences
            PrepareLineNumbers1A(pItem, pLineNumbers)
        Next
        'PrepareLineNumbers1A(ExistingElements.Reference, pLineNumbers)
        'PrepareLineNumbers1A(ExistingElements.BookedByItem, pLineNumbers)
        'PrepareLineNumbers1A(ExistingElements.Department, pLineNumbers)
        'PrepareLineNumbers1A(ExistingElements.ReasonForTravel, pLineNumbers)
        'PrepareLineNumbers1A(ExistingElements.CostCentreItem, pLineNumbers)
        'PrepareLineNumbers1A(ExistingElements.TRId, pLineNumbers)
        Dim pMax As Integer = 0
        Dim pMaxIndex As Integer = -1
        Dim pFound As Boolean = True
        Do While pFound
            pFound = False
            For i As Integer = 0 To pLineNumbers.GetUpperBound(0)
                If pLineNumbers(i) > pMax Then
                    pMax = pLineNumbers(i)
                    pMaxIndex = i
                    pFound = True
                End If
            Next
            If pMaxIndex > -1 Then
                mobjSession1A.Send("XE" & pMax)
                pLineNumbers(pMaxIndex) = 0
            End If
            pMax = 0
            pMaxIndex = -1
        Loop
    End Sub
    Private Sub RemoveOldGDSEntries1G()
        IsGalileo()
        Dim pLineNumbers(0) As LineNumbers
        ' the following elements remain as they are if they already exist in the PNR
        ClearExistingItems(ExistingElements.PhoneElement, mobjNewGDSElements.PhoneElement)
        ClearExistingItems(ExistingElements.EmailElement, mobjNewGDSElements.EmailElement)
        ClearExistingItems(ExistingElements.AOH, mobjNewGDSElements.AOH)
        ' the following elements are removed and replaced if they exist in the PNR
        PrepareLineNumbers1G(ExistingElements.OpenSegment, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.AgentID, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.OptionQueueElement, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.TicketElement, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.ClientCodeItem, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.ClientNameItem, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.SubDepartmentCode, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.SubDepartmentName, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.CRMCode, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.CRMName, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.VesselFlag, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.VesselNameItem, pLineNumbers)
        PrepareLineNumbers1G(ExistingElements.VesselOSI, pLineNumbers)
        For Each pItem As GDSExistingItem In ExistingElements.ClientReferences
            PrepareLineNumbers1G(pItem, pLineNumbers)
        Next
        'PrepareLineNumbers1G(ExistingElements.Reference, pLineNumbers)
        'PrepareLineNumbers1G(ExistingElements.BookedByItem, pLineNumbers)
        'PrepareLineNumbers1G(ExistingElements.Department, pLineNumbers)
        'PrepareLineNumbers1G(ExistingElements.ReasonForTravel, pLineNumbers)
        'PrepareLineNumbers1G(ExistingElements.CostCentreItem, pLineNumbers)
        'PrepareLineNumbers1G(ExistingElements.TRId, pLineNumbers)
        Dim pMax As Integer = 0
        Dim pMaxIndex As Integer = -1
        Dim pCategory As String = ""
        Dim pFound As Boolean = True
        Do While pFound
            If pCategory = "" Then
                For i As Integer = 0 To pLineNumbers.GetUpperBound(0)
                    If pLineNumbers(i).Category <> "" Then
                        pCategory = pLineNumbers(i).Category
                        pMax = pLineNumbers(i).LineNumber
                        pMaxIndex = i
                        Exit For
                    End If
                Next
            End If
            If pCategory <> "" Then
                For i As Integer = 0 To pLineNumbers.GetUpperBound(0)
                    If pLineNumbers(i).Category = pCategory And pLineNumbers(i).LineNumber > pMax Then
                        pMax = pLineNumbers(i).LineNumber
                        pMaxIndex = i
                        pFound = True
                    End If
                Next
                Dim pResponse As ObjectModel.ReadOnlyCollection(Of String)
                If pMaxIndex > -1 Then
                    If pCategory = "Segment." Then
                        pResponse = mobjSession1G.SendTerminalCommand("X" & pMax)
                    Else
                        pResponse = mobjSession1G.SendTerminalCommand(pCategory & pMax & "@")
                    End If
                    If pResponse(0) = "INVALID ENTRY" Then
                        pResponse = mobjSession1G.SendTerminalCommand(pCategory & "@")
                    End If
                    pLineNumbers(pMaxIndex).Category = ""
                    pLineNumbers(pMaxIndex).LineNumber = 0
                Else
                    pCategory = ""
                End If
                pMax = 0
                pMaxIndex = -1
            Else
                pFound = False
            End If
        Loop
    End Sub
    Private Shared Sub ClearExistingItems(ByRef ExistingItem As GDSExistingItem, ByRef NewItem As GDSNewItem)
        If ExistingItem.Exists Then
            NewItem = New GDSNewItem
        End If
    End Sub
    Private Shared Sub PrepareLineNumbers1G(ByVal ExistingItem As GDSExistingItem, ByRef pLineNumbers() As LineNumbers)
        If ExistingItem.Exists Then
            Dim pItems() As String = ExistingItem.Category.Split("."c)
            If IsArray(pItems) AndAlso pItems(0) <> "" Then
                ReDim Preserve pLineNumbers(pLineNumbers.GetUpperBound(0) + 1)
                pLineNumbers(pLineNumbers.GetUpperBound(0)).Category = pItems(0) & "."
                pLineNumbers(pLineNumbers.GetUpperBound(0)).LineNumber = ExistingItem.LineNumber
            End If
        End If
    End Sub
    Public Sub SendGDSEntry1A(ByVal GDSEntry As String)
        IsAmadeus()

        If GDSEntry <> "" Then
            mobjSession1A.Send(GDSEntry)
        End If
    End Sub
    Public Sub SendGDSEntry1G(ByVal GDSEntry As String)
        IsGalileo()
        If GDSEntry <> "" Then
            mobjSession1G.SendTerminalCommand(GDSEntry)
        End If
    End Sub
    Public Function SendAllGDSEntries(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As ListBox) As String
        Dim pResponse As String = ""
        If GDSCode = EnumGDSCode.Amadeus Then
            pResponse = SendAllGDSEntries1A(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        ElseIf GDSCode = EnumGDSCode.Galileo Then
            pResponse = SendAllGDSEntries1G(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        Else
            Throw New Exception("GDSReadPNR.SendAllGDSEntries()" & vbCrLf & "No GDS Selected")
        End If
        Return pResponse
    End Function
    Public Function SendAllGDSEntriesFromList(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As ListBox) As String
        Dim pResponse As String = ""
        If GDSCode = EnumGDSCode.Amadeus Then
            pResponse = SendAllGDSEntries1AFromList(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        ElseIf GDSCode = EnumGDSCode.Galileo Then
            pResponse = SendAllGDSEntries1GFromList(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        Else
            Throw New Exception("GDSReadPNR.SendAllGDSEntriesFromList()" & vbCrLf & "No GDS Selected")
        End If
        Return pResponse
    End Function
    Private Function SendAllGDSEntries1A(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As ListBox) As String
        Dim pResponse As String = ""
        Try
            If WritePNR Then
                RemoveOldGDSEntries1A()
                SendGDSElement1A(mobjNewGDSElements.PhoneElement)
                SendGDSElement1A(mobjNewGDSElements.EmailElement)
                SendGDSElement1A(mobjNewGDSElements.AgentID)
                SendGDSElement1A(mobjNewGDSElements.AOH)
                SendGDSElement1A(mobjNewGDSElements.OpenSegment)
                SendGDSElement1A(mobjNewGDSElements.TicketElement)
                SendGDSElement1A(mobjNewGDSElements.OptionQueueElement)
                If NewPNR Then
                    SendGDSElement1A(mobjNewGDSElements.SavingsElement)
                    SendGDSElement1A(mobjNewGDSElements.LossElement)
                End If
                SendGDSElement1A(mobjNewGDSElements.ClientCodeAIItem)
                SendGDSElement1A(mobjNewGDSElements.ClientCodeItem)
                SendGDSElement1A(mobjNewGDSElements.ClientNameItem)
                SendGDSElement1A(mobjNewGDSElements.SubDepartmentCode)
                SendGDSElement1A(mobjNewGDSElements.SubDepartmentName)
                SendGDSElement1A(mobjNewGDSElements.CRMCode)
                SendGDSElement1A(mobjNewGDSElements.CRMName)
                SendGDSElement1A(mobjNewGDSElements.VesselName)
                SendGDSElement1A(mobjNewGDSElements.VesselFlag)
                SendGDSElement1A(mobjNewGDSElements.VesselOSI)
                'SendGDSElement1A(mobjNewGDSElements.Reference)
                'SendGDSElement1A(mobjNewGDSElements.BookedBy)
                'SendGDSElement1A(mobjNewGDSElements.Department)
                'SendGDSElement1A(mobjNewGDSElements.ReasonForTravel)
                'SendGDSElement1A(mobjNewGDSElements.CostCentre)
                'SendGDSElement1A(mobjNewGDSElements.TRId)
                For i As Integer = 0 To GDSEntries.Items.Count - 1
                    If GDSEntries.Items(i).ToString.Trim <> "" Then
                        SendGDSItemsNoDuplicate1A(GDSEntries.Items(i).ToString.Trim)
                    End If
                Next
            End If

            If WriteDocs Then
                APISUpdate1A(mflgExpiryDateOK, dgvApis)
            End If

            If WritePNR Or WriteDocs Then
                pResponse = CloseOffPNR1A(GDSEntries)
            End If
        Catch ex As Exception
            Throw New Exception("SendNewGDSEntries()" & vbCrLf & ex.Message)
        End Try
        Return pResponse
    End Function
    Private Function SendAllGDSEntries1AFromList(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As ListBox) As String
        Dim pResponse As String = ""
        Try
            If WritePNR Then
                RemoveOldGDSEntries1A()
                For i As Integer = 0 To GDSEntries.Items.Count - 1
                    If GDSEntries.Items(i).ToString.Trim <> "" Then
                        SendGDSItemsNoDuplicate1A(GDSEntries.Items(i).ToString.Trim)
                    End If
                Next
            End If

            If WriteDocs Then
                APISUpdate1A(mflgExpiryDateOK, dgvApis)
            End If

            If WritePNR Or WriteDocs Then
                pResponse = CloseOffPNR1A(GDSEntries)
            End If
        Catch ex As Exception
            Throw New Exception("SendNewGDSEntries()" & vbCrLf & ex.Message)
        End Try
        Return pResponse
    End Function
    Private Function SendAllGDSEntries1GFromList(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As ListBox) As String
        Dim pResponse As String = ""
        Try
            If WritePNR Then
                RemoveOldGDSEntries1G()

                For i As Integer = 0 To GDSEntries.Items.Count - 1
                    If GDSEntries.Items(i).ToString.Trim <> "" Then
                        pResponse &= SendGDSAirlineItems1G(GDSEntries.Items(i).ToString.Trim)
                    End If
                Next
            End If

            If WriteDocs Then
                APISUpdate1G(mflgExpiryDateOK, dgvApis)
            End If

            If WritePNR Or WriteDocs Then
                pResponse &= CloseOffPNR1G()
            End If
        Catch ex As Exception
            Throw New Exception("SendNewGDSEntries()" & vbCrLf & ex.Message)
        End Try
        Return pResponse
    End Function
    Private Function SendAllGDSEntries1G(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As ListBox) As String
        Dim pResponse As String = ""
        Try
            If WritePNR Then
                RemoveOldGDSEntries1G()

                pResponse &= SendGDSElement1G(mobjNewGDSElements.PhoneElement, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.EmailElement, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.AgentID, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.AOH, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.OpenSegment, False)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.TicketElement, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.OptionQueueElement, True)

                If NewPNR Then
                    pResponse &= SendGDSElement1G(mobjNewGDSElements.SavingsElement, True)
                    pResponse &= SendGDSElement1G(mobjNewGDSElements.LossElement, True)
                End If

                pResponse &= SendGDSElement1G(mobjNewGDSElements.ClientCodeItem, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.ClientNameItem, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.SubDepartmentCode, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.SubDepartmentName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.CRMCode, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.CRMName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.VesselName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.VesselFlag, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.VesselOSI, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.GalileoTrackingCode, True)
                'pResponse &= SendGDSElement1G(mobjNewGDSElements.Reference, True)
                'pResponse &= SendGDSElement1G(mobjNewGDSElements.BookedBy, True)
                'pResponse &= SendGDSElement1G(mobjNewGDSElements.Department, True)
                'pResponse &= SendGDSElement1G(mobjNewGDSElements.ReasonForTravel, True)
                'pResponse &= SendGDSElement1G(mobjNewGDSElements.CostCentre, True)
                'pResponse &= SendGDSElement1G(mobjNewGDSElements.TRId, True)

                For i As Integer = 0 To GDSEntries.Items.Count - 1
                    If GDSEntries.Items(i).ToString.Trim <> "" Then
                        pResponse &= SendGDSAirlineItems1G(GDSEntries.Items(i).ToString.Trim)
                    End If
                Next
            End If

            If WriteDocs Then
                APISUpdate1G(mflgExpiryDateOK, dgvApis)
            End If

            If WritePNR Or WriteDocs Then
                pResponse &= CloseOffPNR1G()
            End If
        Catch ex As Exception
            Throw New Exception("SendNewGDSEntries()" & vbCrLf & ex.Message)
        End Try
        Return pResponse
    End Function
    Private Sub APISUpdate1A(ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView)

        Dim pstrCommand As String
        Try
            For i = 0 To dgvApis.RowCount - 1
                With dgvApis.Rows(i)
                    If .ErrorText.IndexOf("Birth") = -1 Then
                        Dim pobjItem As New ApisPaxItem(CInt(.Cells(0).Value), CStr(.Cells(1).Value), CStr(.Cells(2).Value),
                                                        DateFromIATA(CStr(.Cells(6).Value)), CStr(.Cells(7).Value), CStr(.Cells(3).Value),
                                                        CStr(.Cells(4).Value), DateFromIATA(CStr(.Cells(8).Value)), CStr(.Cells(5).Value))
                        pobjItem.Update(mflgExpiryDateOK)
                        pstrCommand = "SR DOCS YY HK1-P-" & pobjItem.IssuingCountry & "-" & pobjItem.PassportNumber & "-" & pobjItem.Nationality & "-" & DateToIATA(pobjItem.BirthDate) & "-" & pobjItem.Gender & "-"
                        If mflgExpiryDateOK Then
                            pstrCommand &= DateToIATA(pobjItem.ExpiryDate)
                        Else
                            pstrCommand &= ""
                        End If
                        pstrCommand &= "-" & pobjItem.Surname & "-" & pobjItem.FirstName & "/P" & pobjItem.Id
                        SendGDSEntry1A(pstrCommand)
                    End If
                End With
            Next
        Catch ex As Exception
            Throw New Exception("APISUpdate()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub APISUpdate1G(ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView)

        Try
            IsGalileo()
            Dim pstrCommand As String
            For i = 0 To dgvApis.RowCount - 1
                With dgvApis.Rows(i)
                    If .ErrorText.IndexOf("Birth") = -1 Then
                        Dim pobjItem As New ApisPaxItem(CInt(.Cells(0).Value), CStr(.Cells(1).Value), CStr(.Cells(2).Value),
                                                       DateFromIATA(CStr(.Cells(6).Value)), CStr(.Cells(7).Value), CStr(.Cells(3).Value),
                                                     CStr(.Cells(4).Value), DateFromIATA(CStr(.Cells(8).Value)), CStr(.Cells(5).Value))

                        pobjItem.Update(mflgExpiryDateOK)
                        'SI.P1/SSRDOCSBAHK1/P/GB/S12345678/GB/12JUL76/M/23OCT16/SMITH/JOHN/RICHARD
                        pstrCommand = "SI.P" & pobjItem.Id & "/SSRDOCSYYHK1/P/" & pobjItem.IssuingCountry & "/" & pobjItem.PassportNumber & "/" & pobjItem.Nationality & "/" & DateToIATA(pobjItem.BirthDate) & "/" & pobjItem.Gender & "/"
                        If mflgExpiryDateOK Then
                            pstrCommand &= DateToIATA(pobjItem.ExpiryDate)
                        Else
                            pstrCommand &= ""
                        End If
                        pstrCommand &= "/" & pobjItem.Surname & "/" & pobjItem.FirstName
                        For Each pElement As SSRitem In mobjPNR1GRaw.SSR.Values
                            If pElement.SSRCode = "DOCS" Then
                                If pElement.LastName = pobjItem.Surname And pElement.PassportNumber = pobjItem.PassportNumber And pElement.DateOfBirth = pobjItem.BirthDate Then
                                    pstrCommand = ""
                                    Exit For
                                End If
                            End If
                        Next
                        If pstrCommand <> "" Then
                            SendGDSEntry1G(pstrCommand)
                        End If
                    End If
                End With
            Next
        Catch ex As Exception
            Throw New Exception("APISUpdate()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function CloseOffPNR1A(AirlineEntries As ListBox) As String

        IsAmadeus()

        Dim pLastCommand As String = ""
        Dim pCloseOffEntries As New CloseOffEntriesCollection

        pCloseOffEntries.Load(MySettings.GDSPcc, OfficeOfResponsibility = MySettings.GDSPcc)

        For Each pCommand As CloseOffEntriesItem In pCloseOffEntries.Values
            Dim pCommandExists As Boolean = False
            pLastCommand = pCommand.CloseOffEntry
            If pLastCommand.StartsWith("SRCTC") Then
                For i As Integer = 0 To AirlineEntries.Items.Count - 1
                    If AirlineEntries.Items(i).ToString.Trim.StartsWith("SRCTC") Then
                        pCommandExists = True
                    End If
                Next
            End If
            If Not pCommandExists Then
                SendGDSItemsNoDuplicate1A(pLastCommand)
            End If
        Next
        If mobjSegments.AmadeusQueue <> "" Then
            pLastCommand = "QE" & mobjSegments.AmadeusQueue & "-RT"
            SendGDSItemsNoDuplicate1A(pLastCommand)
        End If
        If mstrPNRResponse.Contains("WARNING: SECURE FLT PASSENGER DATA REQUIRED") Then
            MessageBox.Show(mstrPNRResponse)
            SendGDSItemsNoDuplicate1A(pLastCommand)
        End If
        If mstrPNRResponse.Contains("SIMULTANEOUS CHANGES") Then
            MessageBox.Show(mstrPNRResponse & vbCrLf & "PNR NOT UPDATED", "SIMULTANEOUS CHANGES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If mobjNewGDSElements.ClientQueue <> "" Then
                pLastCommand = "QE" & mobjNewGDSElements.ClientQueue & "-RT"
                SendGDSItemsNoDuplicate1A(pLastCommand)
            End If
            If mstrPNRResponse.Contains("WARNING: SECURE FLT PASSENGER DATA REQUIRED") Then
                MessageBox.Show(mstrPNRResponse)
                SendGDSItemsNoDuplicate1A(pLastCommand)
            End If
            If mstrPNRResponse.Contains("SIMULTANEOUS CHANGES") Then
                MessageBox.Show(mstrPNRResponse & vbCrLf & "PNR NOT UPDATED", "SIMULTANEOUS CHANGES", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Dim pTQTtext As k1aHostToolKit.CHostResponse = mobjSession1A.Send("RTN")
        Return pTQTtext.Text.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)(0)

    End Function
    Private Function CloseOffPNR1G() As String
        IsGalileo()

        Dim pCloseOffEntries As New CloseOffEntriesCollection
        CloseOffPNR1G = ""
        pCloseOffEntries.Load(MySettings.GDSPcc, OfficeOfResponsibility = MySettings.GDSPcc)

        Dim pResponse As ObjectModel.ReadOnlyCollection(Of String)
        Dim pPNR As String
        pResponse = mobjSession1G.SendTerminalCommand("R.CN")
        pResponse = mobjSession1G.SendTerminalCommand("ER")
        If pResponse(0).IndexOf("CHECK MINIMUM CONNECT TIME") > -1 Then
            pResponse = mobjSession1G.SendTerminalCommand("ER")
        End If
        If (pResponse(0).ToString.IndexOf("CHECK") >= 0 AndAlso pResponse(0).ToString.IndexOf("CONTINUITY") >= 0) Or pResponse(0).ToString.IndexOf("MINIMUM CONNECT TIME UNAVAILABLE") >= 0 Then
            MessageBox.Show(pResponse(0))
            pResponse = mobjSession1G.SendTerminalCommand("ER")
        End If
        If pResponse(0).ToString.Length > 9 AndAlso pResponse(0).ToString.Substring(6, 1) = "/" Then
            pPNR = pResponse(0).ToString.Substring(0, 6)
            pResponse = mobjSession1G.SendTerminalCommand("I")
            For Each pCommand As CloseOffEntriesItem In pCloseOffEntries.Values
                pResponse = mobjSession1G.SendTerminalCommand("*" & pPNR)
                pResponse = mobjSession1G.SendTerminalCommand(pCommand.CloseOffEntry)
                If pResponse(0) & pResponse(1) <> " *>" And pResponse(0).ToString.IndexOf("ON QUEUE") = -1 Then
                    MessageBox.Show(pCommand.CloseOffEntry & vbCrLf & pResponse(0) & pResponse(1))
                End If
                'pResponse = mobjSession1G.SendTerminalCommand("I")
            Next
            If mobjSegments.GalileoQueue <> "" Then
                pResponse = mobjSession1G.SendTerminalCommand("*" & pPNR)
                pResponse = mobjSession1G.SendTerminalCommand("QEB/" & mobjSegments.GalileoQueue)
            End If
            If mobjNewGDSElements.ClientQueue <> "" Then
                pResponse = mobjSession1G.SendTerminalCommand("*" & pPNR)
                pResponse = mobjSession1G.SendTerminalCommand("QEB/" & mobjNewGDSElements.ClientQueue)
            End If
            pResponse = mobjSession1G.SendTerminalCommand("*" & pPNR)
            pResponse = mobjSession1G.SendTerminalCommand("IR")
            CloseOffPNR1G = pPNR
        Else
            Throw New Exception("Error in PNR Update. Please check your PNR and try again" & vbCrLf & pResponse(0))
        End If
    End Function
    Private Sub SendGDSElement1A(ByVal pElement As GDSNewItem)

        If Not pElement Is Nothing Then
            SendGDSItemsNoDuplicate1A(pElement.GDSCommand)
        End If
        Exit Sub

        IsAmadeus()

        If pElement.GDSCommand <> "" Then
            mobjSession1A.Send(pElement.GDSCommand)
        End If

    End Sub

    Private Function SendGDSElement1G(ByVal pElement As GDSNewItem, ByVal ShowResponse As Boolean) As String
        IsGalileo()
        SendGDSElement1G = ""
        Dim pResponse As ObjectModel.ReadOnlyCollection(Of String)
        If pElement.GDSCommand <> "" Then
            pResponse = mobjSession1G.SendTerminalCommand(pElement.GDSCommand)
            If pResponse.Count >= 2 AndAlso pResponse(0) & pResponse(1) <> " *>" AndAlso pResponse(pResponse.Count - 2).ToString.IndexOf(" T ") <> 3 Then
                SendGDSElement1G = vbCrLf & pElement.GDSCommand
                For i As Integer = 0 To pResponse.Count - 1
                    SendGDSElement1G &= vbCrLf & pResponse(i)
                Next
                If ShowResponse Then
                    MessageBox.Show(pElement.GDSCommand & vbCrLf & pResponse(0) & pResponse(1))
                End If
            End If
        End If

    End Function
    Private Sub SendGDSItemsNoDuplicate1A(ByVal pItemToSend As String)
        IsAmadeus()

        If mstrPNRResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(pItemToSend.Replace(" ", "")) = -1 Then

            If pItemToSend.Length > 3 AndAlso pItemToSend.StartsWith("OS ") Then
                If mstrPNRResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(("OSI " & pItemToSend.Substring(3)).Replace(" ", "")) = -1 Then
                    mobjSession1A.Send(pItemToSend)
                End If
            ElseIf pItemToSend.StartsWith("R") Then
                If mstrPNRResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(pItemToSend.Replace(" ", "")) = -1 Then
                    mobjSession1A.Send(pItemToSend)
                End If
            ElseIf pItemToSend.StartsWith("SRCTC") Then
                Dim pString As String = pItemToSend.Substring(pItemToSend.IndexOf("-") + 1).Replace(vbCrLf, "").Replace(" ", "")
                If mstrPNRResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(pString) = -1 Then
                    mobjSession1A.Send(pItemToSend)
                End If
            ElseIf pItemToSend.StartsWith("S") Then
                Dim pString As String
                pString = pItemToSend.Replace("SR", "SSR ").Replace(" ", "").Replace("-", "")
                If pString.StartsWith("SSR CTC") Then
                    If mstrPNRResponse.IndexOf("SSR CTC") = -1 Then
                        mobjSession1A.Send(pItemToSend)
                    End If
                ElseIf mstrPNRResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(pString) = -1 Then
                    mobjSession1A.Send(pItemToSend)
                End If
            ElseIf pItemToSend.Trim <> "" Then
                mobjSession1A.Send(pItemToSend)
            End If
        End If

    End Sub
    Private Function SendGDSAirlineItems1G(ByVal pItemToSend As String) As String
        IsGalileo()
        SendGDSAirlineItems1G = ""
        Dim pResponse
        If pItemToSend <> "" Then
            If pItemToSend.StartsWith("DI.") Then
                For Each pElement As DIItem In mobjPNR1GRaw.DIElements.Values
                    If pElement.Category & pElement.Remark = pItemToSend.Replace(" ", "") Then
                        pItemToSend = ""
                        Exit For
                    End If
                Next
            ElseIf pItemToSend.StartsWith("SI.") Then
                For Each pElement As SSRitem In mobjPNR1GRaw.SSR.Values
                    If ("SI." & pElement.CarrierCode & "*" & pElement.Text).Replace(" ", "") = pItemToSend.Replace(" ", "") Or "SI.SSR" & pElement.SSRCode & pElement.CarrierCode & pElement.StatusCode & "1" & pElement.Text = pItemToSend Then
                        pItemToSend = ""
                        Exit For
                    End If
                Next
            End If
            If pItemToSend <> "" Then
                pResponse = mobjSession1G.SendTerminalCommand(pItemToSend)
                If pResponse(0) <> "DUPLICATE SSRS MUST BE COMBINED" And pResponse(0) & pResponse(1) <> " *>" Then
                    SendGDSAirlineItems1G = vbCrLf & pItemToSend
                    For i As Integer = 0 To pResponse.count - 1
                        SendGDSAirlineItems1G &= vbCrLf & pResponse(i)
                    Next
                    If pResponse(0) & pResponse(1) <> " *>" Then
                        MessageBox.Show(pItemToSend & vbCrLf & pResponse(0) & pResponse(1))
                    End If
                End If
            End If
        End If

    End Function

    Private Sub GetPnrNumber1A()

        Try
            PnrNumber = mobjPNR1A.Header.RecordLocator
        Catch ex As Exception
            PnrNumber = ""
        End Try

        If PnrNumber = "" Then
            PnrNumber = "NewPNR"
            NewPNR = True
        End If
    End Sub
    Private Function setRecordLocator1A() As String
        Try
            setRecordLocator1A = mobjPNR1A.Header.RecordLocator
        Catch ex As Exception
            setRecordLocator1A = UCase(RequestedPNR)
        End Try
    End Function
    Private Sub GetOfficeOfResponsibility1A()

        Try
            OfficeOfResponsibility = mobjPNR1A.Header.OfficeOfResponsability
        Catch ex As Exception
            OfficeOfResponsibility = MySettings.GDSPcc
        End Try

    End Sub
    Private Sub GetGroup1A()

        GroupName = ""
        GroupNamesCount = 0

        For Each pGroup As s1aPNR.GroupNameElement In mobjPNR1A.GroupNameElements
            GroupName = pGroup.GroupName
            GroupNamesCount = pGroup.NbrOfAssignedNames + pGroup.NbrNamesMissing
            Exit For
        Next
        If mobjPNR1A.GroupNameElements.Count > 1 Then
            GroupName &= "x" & mobjPNR1A.GroupNameElements.Count
        End If

    End Sub
    Private Sub GetSegs1AFinisher()
        ' Finisher
        mobjSegments.Clear()
        ' TODO
        Dim pMealFlight As String = ""
        Dim pMealSSR As String = ""

        For Each pSeg As s1aPNR.AirFlownSegment In mobjPNR1A.AirFlownSegments
            With pSeg
                mobjSegments.AddItem(airAirline1A(pSeg), airBoardPoint1A(pSeg), airClass1A(pSeg), airDepartureDate1A(pSeg), airArrivalDate1A(pSeg), .ElementNo, airFlightNo1A(pSeg), airOffPoint1A(pSeg), airStatus1A(pSeg), airDepartTime1A(pSeg), airArriveTime1A(pSeg), Equipment(pSeg), pMealFlight, pMealSSR, airText1A(pSeg), "", "")
            End With
        Next

        For Each pSeg As s1aPNR.AirSegment In mobjPNR1A.AirSegments
            With pSeg
                mobjSegments.AddItem(airAirline1A(pSeg), airBoardPoint1A(pSeg), airClass1A(pSeg), airDepartureDate1A(pSeg), airArrivalDate1A(pSeg), .ElementNo, airFlightNo1A(pSeg), airOffPoint1A(pSeg), airStatus1A(pSeg), airDepartTime1A(pSeg), airArriveTime1A(pSeg), Equipment(pSeg), pMealFlight, pMealSSR, airText1A(pSeg), "", "")
            End With
        Next

    End Sub
    Private Sub GetSegs1AItinerary()
        ' Itinerary
        Dim pSeg As Object
        Dim pPrevElement As Integer = 0
        Dim pstrConnectingTime As String = ""
        Dim pdtePrevArrivalDate As Date
        Dim pdtePrevArrivalTime As Date
        ' TODO
        Dim pMealFlight As String = ""
        Dim pMealSSR As String = ""

        mobjSegments.Clear()
        'mSegsLastElement = -1
        'mSegsFirstElement = -1

        For Each pSeg In mobjPNR1A.AllAirSegments
            If pSeg.Tag.Indexof(".AirFlownSegment.") = -1 Then
                'End If
                'If Not pobjSeg.Text.ToString.EndsWith("FLWN") Then
                Dim pElementNo As Integer = airElementNo1A(pSeg)
                Dim pSegDoTemp As k1aHostToolKit.CHostResponse = mobjSession1A.Send("DO" & pSeg.ElementNo)
                Dim pSegDo As String = ""
                If Not pSegDoTemp.Text Is Nothing Then
                    pSegDo = pSegDoTemp.Text
                    Do While pSegDo.IndexOf(")>") > 0
                        pSegDoTemp = mobjSession1A.Send("MDR")
                        pSegDo = pSegDo.Replace(")>" & vbCrLf, "") & pSegDoTemp.Text
                    Loop
                End If
                If pPrevElement <> 0 Then
                    Dim pSegDMTemp As k1aHostToolKit.CHostResponse
                    pSegDMTemp = mobjSession1A.Send("DM" & pPrevElement & "/" & pSeg.ElementNo)
                    If pSegDMTemp.Text.IndexOf("INVALID PRIOR DISPLAY") > -1 Then
                        mobjSession1A.Send("RTI")
                        pSegDMTemp = mobjSession1A.Send("DM" & pPrevElement & "/" & pSeg.ElementNo)
                    End If
                    Dim pSegDm() As String
                    If Not pSegDMTemp.Text Is Nothing Then
                        pSegDm = pSegDMTemp.Text.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                        For i As Integer = 0 To pSegDm.GetUpperBound(0)
                            If pSegDm(i).IndexOf("ACTUAL CONNECTING TIME IS") > -1 Then
                                Dim pSegDmTemp2() As String = pSegDm(i).Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                                pstrConnectingTime = ("0000" & pSegDmTemp2(pSegDmTemp2.GetUpperBound(0)))
                                pstrConnectingTime = pstrConnectingTime.Substring(pstrConnectingTime.Length - 4)
                                pstrConnectingTime = pstrConnectingTime.Substring(0, 2) & ":" & pstrConnectingTime.Substring(2)
                                Exit For
                            ElseIf pSegDm(i).IndexOf("CONNECT TIME GREATER THAN LARGEST MCT") > -1 Then
                                pstrConnectingTime = pSegDm(i)
                            End If
                        Next i
                    End If

                    Dim pTempDiff As Integer
                    Try
                        pTempDiff = DateDiff(DateInterval.Day, pdtePrevArrivalDate, pSeg.DepartureDate) * 24 * 60 + DateDiff(DateInterval.Minute, pdtePrevArrivalTime, pSeg.DepartureTime)
                    Catch ex As Exception
                        pTempDiff = 0
                    End Try
                    Dim pTempDiffConnect As String = ""
                    If pTempDiff >= 24 * 60 Then ' connection is more than 1 day
                        Dim pDays As Integer = CInt(Int(pTempDiff / (24 * 60)))
                        pTempDiff = pTempDiff - pDays * 24 * 60
                        pTempDiffConnect = pDays & " days:" & Format(Int(pTempDiff / 60), "00") & ":" & Format(pTempDiff - Int(pTempDiff / 60) * 60, "00")
                    Else
                        pTempDiffConnect = Format(Int(pTempDiff / 60), "00") & ":" & Format(pTempDiff - Int(pTempDiff / 60) * 60, "00")
                    End If
                    pstrConnectingTime = pTempDiffConnect
                End If

                mobjSegments.AddItem(airAirline1A(pSeg), airBoardPoint1A(pSeg), airClass1A(pSeg), airDepartureDate1A(pSeg), airArrivalDate1A(pSeg), pElementNo, airFlightNo1A(pSeg), airOffPoint1A(pSeg), airStatus1A(pSeg), airDepartTime1A(pSeg), airArriveTime1A(pSeg), Equipment(pSeg), pMealFlight, pMealSSR, airText1A(pSeg), pSegDo, pstrConnectingTime)

                'If mSegsFirstElement = -1 Then
                '    mSegsFirstElement = pElementNo
                'End If
                'If pElementNo > mSegsLastElement Then
                '    mSegsLastElement = pElementNo
                'End If

                pPrevElement = pSeg.ElementNo
                pdtePrevArrivalDate = airArrivalDate1A(pSeg) ' pobjSeg.ArrivalDate
                pdtePrevArrivalTime = airArriveTime1A(pSeg) ' pobjSeg.ArrivalTime
            End If
        Next pSeg

    End Sub

    Private Sub GetTickets1A()
        mobjTickets = New GDSTicketCollection(mobjPNR1A)
    End Sub
    Private Sub GetItinRemarks1A()
        mobjItinRemarks.Load1A(mobjPNR1A)
    End Sub
    Private Sub GetPassengers1A()
        mobjPassengers.Clear()
        For Each Pax As s1aPNR.NameElement In mobjPNR1A.NameElements
            With Pax
                mobjPassengers.AddItem(If(IsNothing(.ElementNo), 0, .ElementNo), If(IsNothing(.Initial), "", .Initial), If(IsNothing(.LastName), "", .LastName), If(IsNothing(.ID), "", .ID))
            End With
        Next
    End Sub
    Private Sub GetPax1A()

        Dim i As Integer
        Dim j As Integer
        Dim pstrID As String
        Dim pobjPax As s1aPNR.NameElement

        mobjPassengers.Clear()

        For Each pobjPax In mobjPNR1A.NameElements
            With pobjPax
                i = InStr(.Text, "(")
                If i > 0 Then
                    j = InStrRev(.Text, ")")
                    If j = 0 Then
                        j = .Text.Length + 1
                    End If
                    pstrID = .Text.Substring(i - 1, j - i + 1)
                Else
                    pstrID = ""
                End If
                If .Initial Is Nothing And Not .CabinBaggage Is Nothing Then
                    mobjPassengers.AddItem(.ElementNo, "CABIN BAGGAGE", .LastName, pstrID)
                Else
                    mobjPassengers.AddItem(.ElementNo, .Initial, .LastName, pstrID)
                End If
            End With
        Next pobjPax

    End Sub
    Private Sub GetAutoTickets1A()

        Dim pobjFareAutoTktElement As s1aPNR.FareAutoTktElement
        Dim pobjFareOriginalIssueElement As s1aPNR.FareOriginalIssueElement

        For Each pobjFareOriginalIssueElement In mobjPNR1A.FareOriginalIssueElements
            parseFareOriginal(pobjFareOriginalIssueElement)
        Next pobjFareOriginalIssueElement

        For Each pobjFareAutoTktElement In mobjPNR1A.FareAutoTktElements
            parseFareAutoTktElement(pobjFareAutoTktElement)
        Next pobjFareAutoTktElement

    End Sub
    Private Sub parseFareOriginal(ByVal Element As s1aPNR.FareOriginalIssueElement)

        Dim i As Integer
        Dim pflgIATAFound As Boolean
        Dim pstrText As String
        Dim pstrSplit1() As String
        Dim pstrSplit2() As String

        Try

            Dim SegAssociations As String = ""
            Dim PaxAssociations As String = ""

            Dim objSeg As Object
            Dim objPax As Object

            If Element.Associations.Segments.Count > 0 Then
                For Each objSeg In Element.Associations.segments
                    SegAssociations &= mobjSegments(objSeg.ElementNo).Origin.AirportCode & " " & mobjSegments(objSeg.ElementNo).Airline & " " & mobjSegments(objSeg.ElementNo).Destination.AirportCode & vbCrLf
                Next
            Else
                For Each pSeg As GDSSegItem In mobjSegments.Values
                    SegAssociations &= pSeg.Origin.AirportCode & " " & pSeg.Airline & " " & pSeg.Destination.AirportCode & vbCrLf
                Next
            End If

            If Element.Associations.Passengers.Count > 0 Then
                For Each objPax In Element.Associations.Passengers
                    PaxAssociations &= mobjPassengers(objPax.ElementNo).PaxName & vbCrLf
                Next
            Else
                For Each pPax As GDSPaxItem In mobjPassengers.Values
                    PaxAssociations &= pPax.PaxName & vbCrLf
                Next
            End If

            pstrText = ConcatenateText(Element.Text)

            pstrSplit1 = pstrText.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            pstrSplit2 = pstrText.Split({"/"}, StringSplitOptions.RemoveEmptyEntries)

            pflgIATAFound = False
            If IsArray(pstrSplit2) Then
                For i = pstrSplit2.GetLowerBound(0) To pstrSplit2.GetUpperBound(0)
                    If InStr(pstrSplit2(i), MySettings.IATANumber) > 0 Then
                        pflgIATAFound = True
                        Exit For
                    End If
                    If pflgIATAFound Then
                        Exit For
                    End If
                Next i
            End If

            If pflgIATAFound Then
                If IsArray(pstrSplit1) Then
                    For i = pstrSplit1.GetLowerBound(0) To pstrSplit1.GetUpperBound(0)
                        If pstrSplit1(i).Length >= 13 Then
                            With mobjNumberParser
                                If .TicketNumberText(pstrSplit1(i)) Then
                                    mobjTickets.addTicket("FO", .StockType, .DocumentNumber, .Books, .AirlineNumber, .AirlineNumber, False, SegAssociations, PaxAssociations, pstrSplit2(2), "")
                                End If
                            End With
                        End If
                    Next i
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub parseFareAutoTktElement(ByVal Element As s1aPNR.FareAutoTktElement)

        Dim pstrSplit2() As String
        Dim pflgETicket As Boolean
        Dim pstrTicketType As String = ""
        Dim pstrServicesDescription As String = ""
        Try

            Dim SegAssociations As String = ""
            Dim PaxAssociations As String = ""

            Dim objSeg As Object
            Dim objPax As Object

            If Element.Associations.Segments.Count > 0 Then
                For Each objSeg In Element.Associations.segments
                    SegAssociations &= mobjSegments(objSeg.ElementNo).Origin.AirportCode & " " & mobjSegments(objSeg.ElementNo).Airline & " " & mobjSegments(objSeg.ElementNo).Destination.AirportCode & vbCrLf
                Next
            Else
                For Each pSeg As GDSSegItem In mobjSegments.Values
                    SegAssociations &= pSeg.Origin.AirportCode & " " & pSeg.Airline & " " & pSeg.Destination.AirportCode & vbCrLf
                Next
            End If

            If Element.Associations.Passengers.Count > 0 Then
                For Each objPax In Element.Associations.Passengers
                    PaxAssociations &= mobjPassengers(objPax.ElementNo).PaxName & vbCrLf
                Next
            Else
                For Each pPax As GDSPaxItem In mobjPassengers.Values
                    PaxAssociations &= pPax.PaxName & vbCrLf
                Next
            End If


            Dim pstrText As String = Element.Text

            Dim pstrSplit1() As String = Split(pstrText, "/")
            pflgETicket = False
            pstrTicketType = ""
            pstrServicesDescription = ""

            If IsArray(pstrSplit1) Then

                pstrSplit2 = Split(pstrSplit1(0), " ")
                If pstrSplit1.GetUpperBound(0) >= 2 Then
                    pstrTicketType = pstrSplit2(2)
                    If pstrSplit1(1).Length = 4 Then
                        If pstrSplit1(1).StartsWith("ET") Then
                            pflgETicket = True
                        ElseIf pstrSplit1(1).StartsWith("DT") Then
                            For i1 As Integer = pstrSplit1.GetUpperBound(0) To 2 Step -1
                                If pstrSplit1(i1).Length > 1 AndAlso pstrSplit1(i1).StartsWith("E") AndAlso IsNumeric(pstrSplit1(i1).Substring(1)) Then
                                    Dim iElem As Integer = CInt(pstrSplit1(i1).Substring(1))
                                    For Each objSSR As s1aPNR.SSRElement In mobjPNR1A.SSRElements
                                        If objSSR.ElementNo = iElem Then
                                            pstrTicketType = objSSR.Code
                                            pstrServicesDescription = objSSR.Text.Trim
                                            If pstrServicesDescription.IndexOf(pstrTicketType) > -1 Then
                                                pstrServicesDescription = pstrServicesDescription.Substring(pstrServicesDescription.IndexOf(pstrTicketType) + pstrTicketType.Length)
                                            End If
                                            Do While pstrServicesDescription.IndexOf("  ") > -1
                                                pstrServicesDescription = pstrServicesDescription.Replace("  ", " ")
                                            Loop
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                End If
                If IsArray(pstrSplit2) Then
                    If pstrSplit2.GetUpperBound(0) >= 3 Then
                        With mobjNumberParser
                            If .TicketNumberText(pstrSplit2(3)) Then
                                mobjTickets.addTicket("FA", .StockType, .DocumentNumber, .Books, .AirlineNumber, pstrSplit1(1).Substring(2, 2), pflgETicket, SegAssociations, PaxAssociations, pstrTicketType, pstrServicesDescription)
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetTQT1A()

        Dim pTQTtext As k1aHostToolKit.CHostResponse = mobjSession1A.Send("TQT")
        Dim pTQT() As String = pTQTtext.Text.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)

        mobjBaggageAllowance.Clear()
        If pTQT(0).StartsWith("T     P/S  NAME") Then
            For i As Integer = 1 To pTQT.GetUpperBound(0)
                If pTQT(i).Length > 62 AndAlso pTQT(i).Substring(0) <> " " Then
                    If pTQT(i).Substring(0, pTQT(i).IndexOf(" ")) <> pTQT(i - 1).Substring(0, pTQT(i - 1).IndexOf(" ")) AndAlso IsNumeric(pTQT(i).Substring(0, pTQT(i).IndexOf(" "))) Then
                        If i < pTQT.GetUpperBound(0) AndAlso pTQT(i + 1).Length > 2 AndAlso pTQT(i + 1).Substring(0, 1) = " " Then
                            pTQT(i) &= pTQT(i + 1).Trim
                        End If
                    End If

                    Dim pTSTText As k1aHostToolKit.CHostResponse = mobjSession1A.Send("TQT/T" & pTQT(i).Substring(0, pTQT(i).IndexOf(" ")))
                    Dim pTST() As String = pTSTText.Text.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                    SplitTQT1A(pTST)

                End If
            Next
        ElseIf pTQT(0).StartsWith("TST") Then
            SplitTQT1A(pTQT)
        End If

    End Sub
    Private Sub SplitTQT1A(ByVal pTQT() As String)

        Dim iSeg As Integer = 0
        For i As Integer = 0 To pTQT.GetUpperBound(0)
            If pTQT(i).Length > 3 AndAlso pTQT(i).Substring(4, 1) = "." Then
                iSeg = i + 1
            ElseIf iSeg > 0 Then
                Exit For
            End If
        Next
        If iSeg > 0 Then
            For i As Integer = iSeg To pTQT.GetUpperBound(0) - 1
                If pTQT(i).Length > 1 AndAlso IsNumeric(pTQT(i).Substring(1, 1)) Then
                    If pTQT(i).Length > 60 Then
                        mobjBaggageAllowance.AddItem(pTQT(i), pTQT(i + 1))
                    End If
                Else
                    Exit For
                End If
            Next
        End If

    End Sub
    Private Shared Function ConcatenateText(ByVal Text As String) As String

        Dim i As Integer
        Dim j As Integer
        Dim pintLen As Integer
        Dim pstrTemp As String

        Try
            j = -1
            pintLen = Text.Length
            For i = 1 To pintLen
                pstrTemp = Text.Substring(i - 1, 1)
                If pstrTemp <> " " And (pstrTemp < "0" Or pstrTemp > "9") Then
                    j = i
                    Exit For
                End If
            Next i

            If j = -1 Then
                ConcatenateText = Text
            Else
                pstrTemp = Text.Substring(j - 1, 60)
                j = j + 60
                Do While j <= pintLen
                    If Text.Substring(j - 1, Math.Min(23, pintLen - j + 1)) & " " = " " & Text.Substring(j - 1, Math.Min(23, pintLen - j + 1)) Then
                        j = j + 23
                        If j <= pintLen - 57 Then
                            pstrTemp &= Text.Substring(j - 1, 57)
                            j = j + 57
                        ElseIf j <= pintLen Then
                            pstrTemp &= Text.Substring(j - 1)
                            j = j + pintLen
                        End If
                    End If
                Loop
                ConcatenateText = pstrTemp
            End If
        Catch ex As Exception
            ConcatenateText = Text
        End Try

    End Function

    Private Sub mobjNewGDSElements_NewItemCreated() Handles mobjNewGDSElements.NewItemCreated
        RaiseEvent NewItemCreated()
    End Sub
End Class
