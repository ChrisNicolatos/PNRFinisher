﻿Option Strict Off
Option Explicit On
Imports k1aHostToolKit
Public Class GDSReadPNR
    Public Event NewItemCreated()
    Private Structure LineNumbers
        Dim Category As String
        Dim LineNumber As Integer
    End Structure
    Private Structure ClassProps
        Dim RequestedPNR As String
        Dim UserSignIn As String
        Dim PNRCreationdate As Date
        Dim Seats As String

        Dim isDirty As Boolean
        Dim isValid As Boolean
        Dim isNew As Boolean
        Friend Sub Clear()
            RequestedPNR = ""
            UserSignIn = ""
            PNRCreationdate = Date.MinValue
            Seats = ""
            isDirty = False
            isValid = False
            isNew = True
        End Sub
    End Structure
    Private ReadOnly mGDSCode As EnumGDSCode
    Private mudtProps As ClassProps

    Private mobjHostSessions As k1aHostToolKit.HostSessions
    Private WithEvents mobjSession1A As k1aHostToolKit.HostSession
    Private mobjPNR1A As s1aPNR.PNR

    Private mobjSession1G As Travelport.TravelData.Factory.GalileoDesktopFactory
    Private WithEvents mobjPNR1GRaw As GDSReadPNR1G

    Private mobjPassengers As GDSPaxCollection
    Private mobjSegments As GDSSegCollection
    Private mobjTickets As GDSTicketCollection
    Private mobjItinRemarks As GDSItineraryRemarksCollection

    Private mobjFrequentFlyer As FrequentFlyerCollection
    Private mobjNumberParser As GDSNumberParser

    Private mobjExistingGDSElements As GDSExistingCollection
    Private WithEvents mobjNewGDSElements As GDSNewCollection

    Private mobjBaggageAllowance As BaggageAllowanceCollection

    Private mstrPNRResponse As String
    Private mstrPNRNumber As String
    Private mflgNewPNR As Boolean
    Private mstrGroupName As String
    Private mintGroupNamesCount As Integer
    Private mstrItinerary As String

    Private mstrOfficeOfResponsibility As String
    Private mdteDepartureDate As Date
    Private mflgExistsSegments As Boolean
    Private mflgExistsSSRDocs As Boolean
    Private mstrSSRDocs As String
    Private mobjSSRDocs As ApisPaxCollection
    Private mflgExistsSSRCTC As Boolean

    Private mSegsFirstElement As Integer
    Private mSegsLastElement As Integer
    Private mstrVesselName As String
    Private mstrBookedBy As String
    Private mstrCC As String
    Private mstrCLN As String
    Private mstrCLA As String
    Private mflgCancelError As Boolean

    Private mstrStatus As String
    Friend Sub New(ByVal pGDSCode As modEnums.EnumGDSCode)

        mGDSCode = pGDSCode
        If mGDSCode = EnumGDSCode.Galileo Then
            mobjSession1G = New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")
        End If
        ClearElements()

    End Sub
    Private Sub CheckForAmadeus()
        If mGDSCode <> EnumGDSCode.Amadeus Then
            Throw New Exception("Selected GDS is not Amadeus")
        End If
    End Sub
    Private Sub CheckForGalileo()
        If mGDSCode <> EnumGDSCode.Galileo Then
            Throw New Exception("Selected GDS is not Galileo")
        End If
    End Sub
    Private Sub ClearElements()

        If mGDSCode = EnumGDSCode.Galileo Then
            mobjPNR1GRaw = New GDSReadPNR1G
        End If
        mobjPassengers = New GDSPaxCollection
        mobjSegments = New GDSSegCollection
        mobjTickets = New GDSTicketCollection
        mobjItinRemarks = New GDSItineraryRemarksCollection
        mobjFrequentFlyer = New FrequentFlyerCollection
        mobjNumberParser = New GDSNumberParser
        mobjExistingGDSElements = New GDSExistingCollection
        mobjNewGDSElements = New GDSNewCollection
        mobjBaggageAllowance = New BaggageAllowanceCollection
        mudtProps.Clear()

        mstrPNRResponse = ""
        mstrPNRNumber = ""
        mflgNewPNR = False
        mstrGroupName = ""
        mintGroupNamesCount = 0
        mstrItinerary = ""

        mstrOfficeOfResponsibility = ""
        mdteDepartureDate = Date.MinValue
        mflgExistsSegments = False
        mflgExistsSSRDocs = False
        mflgExistsSSRCTC = False
        mstrSSRDocs = ""
        mobjSSRDocs = New ApisPaxCollection

        mSegsFirstElement = 0
        mSegsLastElement = 0
        mstrVesselName = ""
        mstrBookedBy = ""
        mstrCC = ""
        mstrCLN = ""
        mstrCLA = ""
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

    Public ReadOnly Property GroupName As String
        Get
            Return mstrGroupName
        End Get
    End Property

    Public ReadOnly Property GroupNamesCount As Integer
        Get
            Return mintGroupNamesCount
        End Get
    End Property

    Public ReadOnly Property NumberOfPax As Integer
        Get
            Return mobjPassengers.Count
        End Get
    End Property

    Public ReadOnly Property PaxLeadName As String
        Get
            Return mobjPassengers.LeadName
        End Get
    End Property

    Public ReadOnly Property SSRDocsCollection As ApisPaxCollection
        Get
            Return mobjSSRDocs
        End Get
    End Property

    Public ReadOnly Property IsGroup As Boolean
        Get
            Return (mstrGroupName <> "")
        End Get
    End Property

    Public ReadOnly Property HasSegments As Boolean
        Get
            Return (mSegsLastElement > -1)
        End Get
    End Property

    Public ReadOnly Property FirstSegment As GDSSegItem
        Get
            If mSegsFirstElement = -1 Then
                Return New GDSSegItem
            Else
                Return mobjSegments(Format(mSegsFirstElement))
            End If
        End Get
    End Property

    Public ReadOnly Property LastSegment As GDSSegItem
        Get
            If mSegsLastElement = -1 Then
                Return New GDSSegItem
            Else
                Return mobjSegments(Format(mSegsLastElement))
            End If
        End Get
    End Property

    Public ReadOnly Property Itinerary As String
        Get
            Return mstrItinerary
        End Get
    End Property

    Public ReadOnly Property Tickets() As GDSTicketCollection
        Get
            Return mobjTickets
        End Get
    End Property

    Public ReadOnly Property FrequentFlyerNumber(ByVal Airline As String, ByVal PaxName As String) As String
        Get
            FrequentFlyerNumber = ""
            For Each pItem As FrequentFlyerItem In mobjFrequentFlyer
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
    Public ReadOnly Property FrequentFlyernumberCollection As FrequentFlyerCollection
        Get
            Return mobjFrequentFlyer
        End Get
    End Property
    Public ReadOnly Property VesselName() As String
        Get
            Return mstrVesselName
        End Get
    End Property
    Public ReadOnly Property ClientName As String
        Get
            Return mstrCLA
        End Get
    End Property
    Public ReadOnly Property ClientCode As String
        Get
            Return mstrCLN
        End Get
    End Property
    Public ReadOnly Property BookedBy As String
        Get
            Return mstrBookedBy
        End Get
    End Property
    Public ReadOnly Property CostCentre As String
        Get
            Return mstrCC
        End Get
    End Property
    Public ReadOnly Property RequestedPNR() As String
        Get
            Return mudtProps.RequestedPNR
        End Get
    End Property
    Public ReadOnly Property Seats As String
        Get
            Return mudtProps.Seats
        End Get
    End Property
    Public ReadOnly Property PnrNumber As String
        Get
            Return mstrPNRNumber
        End Get
    End Property
    Public ReadOnly Property OfficeOfResponsibility As String
        Get
            Return mstrOfficeOfResponsibility
        End Get
    End Property
    Public ReadOnly Property DepartureDate As Date
        Get
            Return mdteDepartureDate
        End Get
    End Property
    Public ReadOnly Property ExistingElements As GDSExistingCollection
        Get
            Return mobjExistingGDSElements
        End Get
    End Property
    Public ReadOnly Property NewElements As GDSNewCollection
        Get
            Return mobjNewGDSElements
        End Get
    End Property
    Public ReadOnly Property SegmentsExist As Boolean
        Get
            Return mflgExistsSegments
        End Get
    End Property
    Public ReadOnly Property SSRDocsExists As Boolean
        Get
            Return mflgExistsSSRDocs
        End Get
    End Property
    Public ReadOnly Property SSRCTCExists As Boolean
        Get
            Return mflgExistsSSRCTC
        End Get
    End Property
    Public ReadOnly Property SSRDocs As String
        Get
            Return mstrSSRDocs
        End Get
    End Property
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
    Friend ReadOnly Property GDSCode As EnumGDSCode
        Get
            Return mGDSCode
        End Get
    End Property
    Public ReadOnly Property CancelError() As Boolean
        Get
            Return mflgCancelError
        End Get
    End Property
    Public ReadOnly Property MaxAirportNameLength As Integer
        Get
            Return mobjSegments.MaxAirportNameLength
        End Get
    End Property
    Public ReadOnly Property MaxCityNameLength As Integer
        Get
            Return mobjSegments.MaxCityNameLength
        End Get
    End Property
    Public ReadOnly Property MaxAirportShortNameLength As Integer
        Get
            Return mobjSegments.MaxAirportShortNameLength
        End Get
    End Property

    Public ReadOnly Property NewPNR As Boolean
        Get
            Return mflgNewPNR
        End Get
    End Property
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
    Friend Sub Read(ByVal PNR As String)
        mflgCancelError = (PNR = "")
        ClearElements()
        If mGDSCode = EnumGDSCode.Amadeus Then
            Read1A(PNR)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            ReadPNR1G(PNR)
        Else
            Throw New Exception("Incorrect GDS")
        End If
    End Sub
    Friend Function Read() As String
        Dim pReturnValue As String = ""
        ClearElements()
        If mGDSCode = EnumGDSCode.Amadeus Then
            pReturnValue = Read1A()
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            pReturnValue = Read1G()
        Else
            Throw New Exception("GDSReadPNR.Read()" & vbCrLf & "NO GDS Specified")
        End If
        Return pReturnValue
    End Function
    Private Sub Read1A(ByVal PNR As String)

        Try
            CheckForAmadeus()
            ClearElements()
            mstrStatus = ""
            GetActiveAmadeusSession()
            If PNR <> "" Then
                mobjSession1A.Send("QI")
                mobjSession1A.Send("IG")
            End If
            mudtProps.RequestedPNR = PNR
            Dim pReturnValue As Boolean = RetrievePNR1A()
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
    Private Function Read1A() As String

        Try
            Dim pReturnValue As String = ""
            CheckForAmadeus()
            ClearElements()
            GetActiveAmadeusSession()
            mobjPNR1A = New s1aPNR.PNR
            Dim pStatus As Integer = mobjPNR1A.RetrievePNR(mobjSession1A, "RT")
            mflgNewPNR = False
            If pStatus = 0 Or pStatus = 1005 Then
                GetOfficeOfResponsibility1A()
                GetPnrNumber1A()
                GetGroup1A()
                GetPassengers1A()
                GetSegments1A()
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
                GetTickets1A()
                GetItinRemarks1A()
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

    Private Function RetrievePNR1A() As Boolean

        Dim pintPNRStatus As Integer
        Dim pReturnValue As Boolean = False

        mobjPNR1A = New s1aPNR.PNR
        mobjTickets = New GDSTicketCollection
        mobjItinRemarks = New GDSItineraryRemarksCollection
        mstrVesselName = ""
        mstrBookedBy = ""
        mstrCC = ""
        mstrCLA = ""
        mstrCLN = ""

        With mudtProps

            If .RequestedPNR = "" Then
                pintPNRStatus = mobjPNR1A.RetrieveCurrent(mobjSession1A)
            Else
                pintPNRStatus = mobjPNR1A.RetrievePNR(mobjSession1A, "RT" & .RequestedPNR)
            End If
            .PNRCreationdate = Today

            If pintPNRStatus = 0 Or pintPNRStatus = 1005 Then
                .RequestedPNR = setRecordLocator1A()
                GetTQT1A()
                GetGroup1A()
                GetPax1A()
                GetSegs1A()
                GetAutoTickets1A()
                GetOtherServiceElements1A()
                GetSSRElements1A()
                GetSSR1A()
                GetRMElements1A()
                GetItinRemarks1A()
                pReturnValue = True
            Else
                pReturnValue = False
            End If
        End With
        Return pReturnValue
    End Function

    Private Sub ReadPNR1G(ByVal PNR As String)
        Try
            ClearElements()
            If PNR <> "" Then
                mobjSession1G.SendTerminalCommand("QXI+I")
            End If
            mudtProps.RequestedPNR = PNR
            Read1G()
        Catch ex As Exception
            Throw New Exception("GDSReadPNR.ReadPNR1G()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function Read1G() As String
        ClearElements()
        mobjPNR1GRaw = New GDSReadPNR1G
        Dim pResponse As ObjectModel.ReadOnlyCollection(Of String) = mobjSession1G.SendTerminalCommand("*R")
        If pResponse.Count > 0 AndAlso pResponse(0).Length > 5 AndAlso pResponse(0).Substring(6, 1) = "/" Then
            mudtProps.RequestedPNR = pResponse(0).Substring(0, 6)
        ElseIf pResponse.Count > 1 AndAlso pResponse(1).Length > 5 AndAlso pResponse(1).Substring(6, 1) = "/" Then
            mudtProps.RequestedPNR = pResponse(1).Substring(0, 6)
        ElseIf pResponse.Count > 2 AndAlso pResponse(2).Length > 6 AndAlso pResponse(2).Substring(6, 1) = "/" Then
            mudtProps.RequestedPNR = pResponse(2).Substring(0, 6)
        ElseIf Not pResponse(0).StartsWith(" ") Then
            Throw New Exception(pResponse(0))
        Else
            mudtProps.RequestedPNR = ""
        End If
        Read1G = ""
        If mudtProps.RequestedPNR.Trim <> "" Then
            mobjSession1G.SendTerminalCommand("*" & mudtProps.RequestedPNR)
        End If
        Try
            mobjTickets = New GDSTicketCollection
            mobjItinRemarks = New GDSItineraryRemarksCollection
            mstrVesselName = ""
            mstrBookedBy = ""
            mstrCC = ""
            mstrCLA = ""
            mstrCLN = ""
            mobjPNR1GRaw.ReadRaw(mudtProps.RequestedPNR)
            mudtProps.RequestedPNR = mobjPNR1GRaw.RequestedPNR
            mstrOfficeOfResponsibility = mobjPNR1GRaw.OfficeOfResponsibility
            mobjPassengers = mobjPNR1GRaw.Passengers
            mobjSegments = mobjPNR1GRaw.Segments
            mobjFrequentFlyer = mobjPNR1GRaw.FrequentFlyers
            mobjItinRemarks = mobjPNR1GRaw.ItineraryRemarks
            mstrItinerary = mobjSegments.Itinerary
            mdteDepartureDate = mobjPNR1GRaw.DepartureDate
            mflgExistsSegments = (mobjSegments.Count > 0)
            mSegsFirstElement = mobjPNR1GRaw.SegsFirstElement
            mSegsLastElement = mobjPNR1GRaw.SegsLastElement
            'mudtAllowance = mobjPNR1GRaw.Allowance
            mobjBaggageAllowance = mobjPNR1GRaw.BaggageAllowance
            mobjTickets = mobjPNR1GRaw.Tickets
            mudtProps.Seats = mobjPNR1GRaw.Seats
            mflgExistsSSRCTC = mobjPNR1GRaw.HasCTC
            GetPhoneElement1G()
            GetEmailElement1G()
            GetTicketElement1G()
            GetOpenSegment1G()
            GetOptionQueueElement1G()
            GetSSR1G()
            GetRM1G()
        Catch ex As Exception
            Throw New Exception("GDSReadPNR.Read1G()" & vbCrLf & ex.Message)
        End Try
    End Function
    Public Sub PrepareNewGDSElements()
        Try
            mobjNewGDSElements = New GDSNewCollection(OfficeOfResponsibility, DepartureDate, NumberOfPax, mGDSCode)
        Catch ex As Exception
        End Try
    End Sub
    Private Function CheckDMI1A() As String
        Try
            CheckForAmadeus()
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
        CheckForAmadeus()
        Dim pLineNumbers(0) As Integer
        ' the following elements remain as they are if they already exist in the PNR
        ClearExistingItems(mobjExistingGDSElements.PhoneElement, mobjNewGDSElements.PhoneElement)
        ClearExistingItems(mobjExistingGDSElements.EmailElement, mobjNewGDSElements.EmailElement)
        ClearExistingItems(mobjExistingGDSElements.AOH, mobjNewGDSElements.AOH)
        ClearExistingItems(mobjExistingGDSElements.OpenSegment, mobjNewGDSElements.OpenSegment)
        ClearExistingItems(mobjExistingGDSElements.OptionQueueElement, mobjNewGDSElements.OptionQueueElement)
        ClearExistingItems(mobjExistingGDSElements.TicketElement, mobjNewGDSElements.TicketElement)
        ClearExistingItems(mobjExistingGDSElements.AgentID, mobjNewGDSElements.AgentID)
        ' the following elements are removed and replaced if they exist in the PNR
        PrepareLineNumbers1A(mobjExistingGDSElements.CustomerCodeAI, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.CustomerCode, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.CustomerName, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.SubDepartmentCode, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.SubDepartmentName, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.CRMCode, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.CRMName, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.VesselFlag, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.VesselName, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.VesselOSI, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.Reference, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.BookedBy, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.Department, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.ReasonForTravel, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.CostCentre, pLineNumbers)
        PrepareLineNumbers1A(mobjExistingGDSElements.TRId, pLineNumbers)
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
        CheckForGalileo()
        Dim pLineNumbers(0) As LineNumbers
        ' the following elements remain as they are if they already exist in the PNR
        ClearExistingItems(mobjExistingGDSElements.PhoneElement, mobjNewGDSElements.PhoneElement)
        ClearExistingItems(mobjExistingGDSElements.EmailElement, mobjNewGDSElements.EmailElement)
        ClearExistingItems(mobjExistingGDSElements.AOH, mobjNewGDSElements.AOH)
        ' the following elements are removed and replaced if they exist in the PNR
        PrepareLineNumbers1G(mobjExistingGDSElements.OpenSegment, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.AgentID, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.OptionQueueElement, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.TicketElement, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.CustomerCode, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.CustomerName, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.SubDepartmentCode, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.SubDepartmentName, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.CRMCode, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.CRMName, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.VesselFlag, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.VesselName, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.VesselOSI, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.Reference, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.BookedBy, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.Department, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.ReasonForTravel, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.CostCentre, pLineNumbers)
        PrepareLineNumbers1G(mobjExistingGDSElements.TRId, pLineNumbers)
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
            NewItem.Clear()
        End If
    End Sub
    Private Shared Sub PrepareLineNumbers1G(ByVal ExistingItem As GDSExistingItem, ByRef pLineNumbers() As LineNumbers)
        If ExistingItem.Exists Then
            Dim pItems() As String = ExistingItem.Category.Split(".")
            If IsArray(pItems) AndAlso pItems(0) <> "" Then
                ReDim Preserve pLineNumbers(pLineNumbers.GetUpperBound(0) + 1)
                pLineNumbers(pLineNumbers.GetUpperBound(0)).Category = pItems(0) & "."
                pLineNumbers(pLineNumbers.GetUpperBound(0)).LineNumber = ExistingItem.LineNumber
            End If
        End If
    End Sub
    Public Sub SendGDSEntry1A(ByVal GDSEntry As String)
        CheckForAmadeus()

        If GDSEntry <> "" Then
            mobjSession1A.Send(GDSEntry)
        End If
    End Sub
    Public Sub SendGDSEntry1G(ByVal GDSEntry As String)
        CheckForGalileo()
        If GDSEntry <> "" Then
            mobjSession1G.SendTerminalCommand(GDSEntry)
        End If
    End Sub
    Public Function SendAllGDSEntries(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As CheckedListBox) As String
        Dim pResponse As String = ""
        If mGDSCode = EnumGDSCode.Amadeus Then
            pResponse = SendAllGDSEntries1A(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            pResponse = SendAllGDSEntries1G(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        Else
            Throw New Exception("GDSReadPNR.SendAllGDSEntries()" & vbCrLf & "No GDS Selected")
        End If
        Return pResponse
    End Function
    Public Function SendAllGDSEntriesFromList(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As CheckedListBox) As String
        Dim pResponse As String = ""
        If mGDSCode = EnumGDSCode.Amadeus Then
            pResponse = SendAllGDSEntries1AFromList(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            pResponse = SendAllGDSEntries1GFromList(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, GDSEntries)
        Else
            Throw New Exception("GDSReadPNR.SendAllGDSEntriesFromList()" & vbCrLf & "No GDS Selected")
        End If
        Return pResponse
    End Function
    Private Function SendAllGDSEntries1A(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As CheckedListBox) As String
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
                If mflgNewPNR Then
                    SendGDSElement1A(mobjNewGDSElements.SavingsElement)
                    SendGDSElement1A(mobjNewGDSElements.LossElement)
                End If
                SendGDSElement1A(mobjNewGDSElements.CustomerCodeAI)
                SendGDSElement1A(mobjNewGDSElements.CustomerCode)
                SendGDSElement1A(mobjNewGDSElements.CustomerName)
                SendGDSElement1A(mobjNewGDSElements.SubDepartmentCode)
                SendGDSElement1A(mobjNewGDSElements.SubDepartmentName)
                SendGDSElement1A(mobjNewGDSElements.CRMCode)
                SendGDSElement1A(mobjNewGDSElements.CRMName)
                SendGDSElement1A(mobjNewGDSElements.VesselName)
                SendGDSElement1A(mobjNewGDSElements.VesselFlag)
                SendGDSElement1A(mobjNewGDSElements.VesselOSI)
                SendGDSElement1A(mobjNewGDSElements.Reference)
                SendGDSElement1A(mobjNewGDSElements.BookedBy)
                SendGDSElement1A(mobjNewGDSElements.Department)
                SendGDSElement1A(mobjNewGDSElements.ReasonForTravel)
                SendGDSElement1A(mobjNewGDSElements.CostCentre)
                SendGDSElement1A(mobjNewGDSElements.TRId)
                For i As Integer = 0 To GDSEntries.CheckedItems.Count - 1
                    If GDSEntries.CheckedItems(i).ToString.Trim <> "" Then
                        SendGDSItemsNoDuplicate1A(GDSEntries.CheckedItems(i).ToString.Trim)
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
    Private Function SendAllGDSEntries1AFromList(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As CheckedListBox) As String
        Dim pResponse As String = ""
        Try
            If WritePNR Then
                RemoveOldGDSEntries1A()
                For i As Integer = 0 To GDSEntries.CheckedItems.Count - 1
                    If GDSEntries.CheckedItems(i).ToString.Trim <> "" Then
                        SendGDSItemsNoDuplicate1A(GDSEntries.CheckedItems(i).ToString.Trim)
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
    Private Function SendAllGDSEntries1GFromList(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As CheckedListBox) As String
        Dim pResponse As String = ""
        Try
            If WritePNR Then
                RemoveOldGDSEntries1G()

                For i As Integer = 0 To GDSEntries.CheckedItems.Count - 1
                    If GDSEntries.CheckedItems(i).ToString.Trim <> "" Then
                        pResponse &= SendGDSAirlineItems1G(GDSEntries.CheckedItems(i).ToString.Trim)
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
    Private Function SendAllGDSEntries1G(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean, ByVal mflgExpiryDateOK As Boolean, dgvApis As DataGridView, GDSEntries As CheckedListBox) As String
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

                If mflgNewPNR Then
                    pResponse &= SendGDSElement1G(mobjNewGDSElements.SavingsElement, True)
                    pResponse &= SendGDSElement1G(mobjNewGDSElements.LossElement, True)
                End If

                pResponse &= SendGDSElement1G(mobjNewGDSElements.CustomerCode, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.CustomerName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.SubDepartmentCode, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.SubDepartmentName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.CRMCode, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.CRMName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.VesselName, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.VesselFlag, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.VesselOSI, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.Reference, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.BookedBy, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.Department, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.ReasonForTravel, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.CostCentre, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.GalileoTrackingCode, True)
                pResponse &= SendGDSElement1G(mobjNewGDSElements.TRId, True)

                For i As Integer = 0 To GDSEntries.CheckedItems.Count - 1
                    If GDSEntries.CheckedItems(i).ToString.Trim <> "" Then
                        pResponse &= SendGDSAirlineItems1G(GDSEntries.CheckedItems(i).ToString.Trim)
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
                        Dim pobjItem As New ApisPaxItem(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value,
                                                        DateFromIATA(.Cells(6).Value), .Cells(7).Value, .Cells(3).Value,
                                                        .Cells(4).Value, DateFromIATA(.Cells(8).Value), .Cells(5).Value)
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
            CheckForGalileo()
            Dim pstrCommand As String
            For i = 0 To dgvApis.RowCount - 1
                With dgvApis.Rows(i)
                    If .ErrorText.IndexOf("Birth") = -1 Then
                        Dim pobjItem As New ApisPaxItem(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value,
                                                       DateFromIATA(.Cells(6).Value), .Cells(7).Value, .Cells(3).Value,
                                                     .Cells(4).Value, DateFromIATA(.Cells(8).Value), .Cells(5).Value)

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
                                If pElement.LastName = pobjItem.Surname And pElement.PassportNumber = pobjItem.PassportNumber And pElement.DateOfBirth = DateToIATA(pobjItem.BirthDate) Then
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
    Private Function CloseOffPNR1A(AirlineEntries As CheckedListBox) As String

        CheckForAmadeus()

        Dim pLastCommand As String = ""
        Dim pCloseOffEntries As New CloseOffEntriesCollection

        pCloseOffEntries.Load(MySettings.GDSPcc, mstrOfficeOfResponsibility = MySettings.GDSPcc)

        For Each pCommand As CloseOffEntriesItem In pCloseOffEntries.Values
            Dim pCommandExists As Boolean = False
            pLastCommand = pCommand.CloseOffEntry
            If pLastCommand.StartsWith("SRCTC") Then
                For i As Integer = 0 To AirlineEntries.CheckedItems.Count - 1
                    If AirlineEntries.CheckedItems(i).ToString.Trim.StartsWith("SRCTC") Then
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
            If mobjNewGDSElements.CustomerQueue <> "" Then
                pLastCommand = "QE" & mobjNewGDSElements.CustomerQueue & "-RT"
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
        CheckForGalileo()

        Dim pCloseOffEntries As New CloseOffEntriesCollection
        CloseOffPNR1G = ""
        pCloseOffEntries.Load(MySettings.GDSPcc, mstrOfficeOfResponsibility = MySettings.GDSPcc)

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
            If mobjNewGDSElements.CustomerQueue <> "" Then
                pResponse = mobjSession1G.SendTerminalCommand("*" & pPNR)
                pResponse = mobjSession1G.SendTerminalCommand("QEB/" & mobjNewGDSElements.CustomerQueue)
            End If
            pResponse = mobjSession1G.SendTerminalCommand("*" & pPNR)
            pResponse = mobjSession1G.SendTerminalCommand("IR")
            CloseOffPNR1G = pPNR
        Else
            Throw New Exception("Error in PNR Update. Please check your PNR and try again" & vbCrLf & pResponse(0))
        End If
    End Function
    Private Sub SendGDSElement1A(ByVal pElement As GDSNewItem)
        CheckForAmadeus()

        If pElement.GDSCommand <> "" Then
            mobjSession1A.Send(pElement.GDSCommand)
        End If

    End Sub
    Private Sub SendGDSElement1A(ByVal pElement As String)
        CheckForAmadeus()
        If pElement <> "" Then
            mobjSession1A.Send(pElement)
        End If

    End Sub
    Private Function SendGDSElement1G(ByVal pElement As GDSNewItem, ByVal ShowResponse As Boolean) As String
        CheckForGalileo()
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
        CheckForAmadeus()

        If pItemToSend.Length > 3 AndAlso pItemToSend.StartsWith("OS ") Then
            If mobjPNR1A.RawResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(("OSI " & pItemToSend.Substring(3)).Replace(" ", "")) = -1 Then
                mobjSession1A.Send(pItemToSend)
            End If
        ElseIf pItemToSend.StartsWith("R") Then
            If mobjPNR1A.RawResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(pItemToSend.Replace(" ", "")) = -1 Then
                mobjSession1A.Send(pItemToSend)
            End If
        ElseIf pItemToSend.StartsWith("S") Then
            Dim pString As String
            pString = pItemToSend.Replace(" ", "").Replace("SR", "SSR ")
            If pString.StartsWith("SSR CTC") Then
                If mobjPNR1A.RawResponse.IndexOf("SSR CTC") = -1 Then
                    mobjSession1A.Send(pItemToSend)
                End If
            ElseIf mobjPNR1A.RawResponse.Replace(vbCrLf, "").Replace(" ", "").IndexOf(pString) = -1 Then
                mobjSession1A.Send(pItemToSend)
            End If
        Else
            mobjSession1A.Send(pItemToSend)
        End If

    End Sub
    Private Function SendGDSAirlineItems1G(ByVal pItemToSend As String) As String
        CheckForGalileo()
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
            mstrPNRNumber = mobjPNR1A.Header.RecordLocator
        Catch ex As Exception
            mstrPNRNumber = ""
        End Try

        If mstrPNRNumber = "" Then
            mstrPNRNumber = "New PNR"
            mflgNewPNR = True
        End If
    End Sub
    Private Function setRecordLocator1A() As String
        Try
            setRecordLocator1A = mobjPNR1A.Header.RecordLocator
        Catch ex As Exception
            setRecordLocator1A = UCase(mudtProps.RequestedPNR)
        End Try
    End Function
    Private Sub GetOfficeOfResponsibility1A()

        Try
            mstrOfficeOfResponsibility = mobjPNR1A.Header.OfficeOfResponsability
        Catch ex As Exception
            mstrOfficeOfResponsibility = MySettings.GDSPcc
        End Try

    End Sub
    Private Sub GetGroup1A()

        mstrGroupName = ""
        mintGroupNamesCount = 0

        For Each pGroup As s1aPNR.GroupNameElement In mobjPNR1A.GroupNameElements
            mstrGroupName = pGroup.GroupName
            mintGroupNamesCount = pGroup.NbrOfAssignedNames + pGroup.NbrNamesMissing
            Exit For
        Next
        If mobjPNR1A.GroupNameElements.Count > 1 Then
            mstrGroupName &= "x" & mobjPNR1A.GroupNameElements.Count
        End If

    End Sub
    Private Sub GetSegments1A()

        mobjSegments.Clear()
        mdteDepartureDate = Date.MinValue
        mstrItinerary = ""
        Dim pOff As String = ""
        Dim pPrevElementNo As Integer = 0
        ' TODO
        Dim pMealFlight As String = ""
        Dim pMealSSR As String = ""

        For Each pSeg As s1aPNR.AirFlownSegment In mobjPNR1A.AirFlownSegments
            With pSeg
                If mstrItinerary = "" Then
                    mstrItinerary = .BoardPoint & "-" & .OffPoint
                Else
                    If .BoardPoint = pOff Then
                        mstrItinerary &= "-" & .OffPoint
                    Else
                        mstrItinerary &= "-***-" & .BoardPoint & "-" & .OffPoint
                    End If
                End If
                pOff = .OffPoint
                Dim pDate As New s1aAirlineDate.clsAirlineDate
                pDate.SetFromString(.DepartureDate)
                If mdteDepartureDate = Date.MinValue Then
                    mdteDepartureDate = pDate.VBDate
                End If
                If pPrevElementNo <> 0 Then

                End If
                mobjSegments.AddItem(airAirline1A(pSeg), airBoardPoint1A(pSeg), airClass1A(pSeg), airDepartureDate1A(pSeg), airArrivalDate1A(pSeg), .ElementNo, airFlightNo1A(pSeg), airOffPoint1A(pSeg), airStatus1A(pSeg), airDepartTime1A(pSeg), airArriveTime1A(pSeg), Equipment(pSeg), pMealFlight, pMealSSR, airText1A(pSeg), "", "")
                pPrevElementNo = .ElementNo
            End With
        Next

        For Each pSeg As s1aPNR.AirSegment In mobjPNR1A.AirSegments
            With pSeg
                If mstrItinerary = "" Then
                    mstrItinerary = pSeg.BoardPoint & "-" & pSeg.OffPoint
                Else
                    If pSeg.BoardPoint = pOff Then
                        mstrItinerary &= "-" & pSeg.OffPoint
                    Else
                        mstrItinerary &= "-***-" & pSeg.BoardPoint & "-" & pSeg.OffPoint
                    End If
                End If
                pOff = pSeg.OffPoint
                Dim pDate As New s1aAirlineDate.clsAirlineDate
                pDate.SetFromString(pSeg.DepartureDate)
                If mdteDepartureDate = Date.MinValue Then
                    mdteDepartureDate = pDate.VBDate
                End If
                mobjSegments.AddItem(airAirline1A(pSeg), airBoardPoint1A(pSeg), airClass1A(pSeg), airDepartureDate1A(pSeg), airArrivalDate1A(pSeg), .ElementNo, airFlightNo1A(pSeg), airOffPoint1A(pSeg), airStatus1A(pSeg), airDepartTime1A(pSeg), airArriveTime1A(pSeg), Equipment(pSeg), pMealFlight, pMealSSR, airText1A(pSeg), "", "")
            End With
        Next
        mflgExistsSegments = ((mobjPNR1A.AirFlownSegments.Count + mobjPNR1A.AirSegments.Count) > 0)

        If mdteDepartureDate > Date.MinValue Then
            Dim pDate As New s1aAirlineDate.clsAirlineDate
            pDate.SetFromString(mdteDepartureDate)
            mstrItinerary &= " (" & pDate.IATA & ")"
        End If

    End Sub
    Private Sub GetOpenSegment1A()

        For Each pSeg As s1aPNR.MemoSegment In mobjPNR1A.MemoSegments
            If pSeg.Text.Contains(MySettings.GDSValue("TextMISSegmentLookup") & mobjPNR1A.NameElements.Count & " " & MySettings.OfficeCityCode) Then
                mobjExistingGDSElements.OpenSegment.SetValues(True, pSeg.ElementNo, MySettings.GDSElement("TextMISSegmentLookup"), "", "")
                Exit For
            End If
        Next

    End Sub
    Private Sub GetOpenSegment1G()

        For Each pOpenSeg As OpenSegmentItem In mobjPNR1GRaw.OpenSegments.Values
            If pOpenSeg.SegmentType = "T" Then
                mobjExistingGDSElements.OpenSegment.SetValues(True, pOpenSeg.ElementNo, "Segment", pOpenSeg.Remark.ToString, "")
            End If
        Next
    End Sub
    Private Sub GetPhoneElement1A()

        For Each pField As s1aPNR.PhoneElement In mobjPNR1A.PhoneElements
            If pField.Text.Replace(" ", "").Contains(MySettings.GDSValue("TextAP").Replace(" ", "")) Then
                mobjExistingGDSElements.PhoneElement.SetValues(True, pField.Text.Substring(0, pField.Text.IndexOf(pField.ElementID) - 1), MySettings.GDSElement("TextAP"), "", "")
                Exit For
            End If
        Next

    End Sub
    Private Sub GetPhoneElement1G()

        For Each pPhone As PhoneNumbersItem In mobjPNR1GRaw.PhoneNumbers.Values
            If "P." & pPhone.CityCode & "T*" & pPhone.PhoneNumber = MySettings.GDSValue("TextAP") Then
                mobjExistingGDSElements.PhoneElement.SetValues(True, pPhone.ElementNo, MySettings.GDSElement("TextAP"), pPhone.PhoneNumber, pPhone.PhoneNumber)
            ElseIf "P." & pPhone.CityCode & "T*" & pPhone.PhoneNumber = MySettings.GDSValue("TextAOH") Then
                mobjExistingGDSElements.AOH.SetValues(True, pPhone.ElementNo, MySettings.GDSElement("TextAOH"), pPhone.PhoneNumber, pPhone.PhoneNumber)
            End If
        Next
    End Sub
    Private Sub GetEmailElement1A()

        For Each pField As s1aPNR.PhoneElement In mobjPNR1A.PhoneElements
            If pField.Text.Contains(MySettings.GDSValue("TextAPE_ToFind")) Then
                mobjExistingGDSElements.EmailElement.SetValues(True, pField.Text.Substring(0, pField.Text.IndexOf(pField.ElementID) - 1), MySettings.GDSElement("TextAPE_ToFind"), "", "")
            End If
        Next
    End Sub
    Private Sub GetEmailElement1G()
        For Each pEmail As EmailItem In mobjPNR1GRaw.Emails.Values
            If "MT." & pEmail.EmailAddress = MySettings.GDSValue("TextAPE") Then
                mobjExistingGDSElements.EmailElement.SetValues(True, pEmail.ElementNo, MySettings.GDSElement("TextAPE"), pEmail.EmailAddress, pEmail.EmailAddress)
            End If
        Next
    End Sub
    Private Sub GetAOH1A()
        For Each pElement As s1aPNR.SSRElement In mobjPNR1A.SSRElements
            If pElement.Text.Contains(MySettings.GDSValue("TextAOH_ToFind")) Then
                mobjExistingGDSElements.AOH.SetValues(True, pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1), MySettings.GDSElement("TextAOH_ToFind"), "", "")
            End If
        Next
    End Sub

    Private Sub GetTicketElement1A()
        For Each pElement As s1aPNR.TicketElement In mobjPNR1A.TicketElements
            mobjExistingGDSElements.TicketElement.SetValues(True, pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1), "TKT", "", "")
        Next
    End Sub
    Private Sub GetTicketElement1G()

        If mobjPNR1GRaw.TicketElement.ElementNo = 1 Then
            mobjExistingGDSElements.TicketElement.SetValues(True, 1, "T.", mobjPNR1GRaw.TicketElement.ActionDateTime, "")
        End If
    End Sub

    Private Sub GetOptionQueueElement1A()
        For Each pElement As s1aPNR.OptionQueueElement In mobjPNR1A.OptionQueueElements
            If pElement.Text.Contains(MySettings.GDSValue("TextOP")) Then
                mobjExistingGDSElements.OptionQueueElement.SetValues(True, pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1), MySettings.GDSElement("TextOP"), "", "")
                Exit For
            End If
        Next
    End Sub
    Private Sub GetOptionQueueElement1G()
        For Each pField As OptionQueueItem In mobjPNR1GRaw.OptionQueue.Values
            Dim pFullText As String = MySettings.GDSValue("TextOP") & "/DDMMM/0001/Q" & MySettings.AgentOPQueue
            If pFullText.StartsWith(MySettings.GDSValue("TextOP")) And pFullText.EndsWith("/0001/Q" & MySettings.AgentOPQueue) Then
                mobjExistingGDSElements.OptionQueueElement.SetValues(True, pField.ElementNo, MySettings.GDSElement("TextOP"), pField.QueueNumber, pField.QueueNumber)
            End If
        Next
    End Sub
    Private Sub GetVesselOSI1A()
        For Each pOSI As s1aPNR.OtherServiceElement In mobjPNR1A.OtherServiceElements
            If pOSI.Text.Contains(MySettings.GDSValue("TextVOSI")) Then
                If mobjExistingGDSElements.VesselOSI.Exists Then
                    Throw New Exception("Please check PNR. Duplicate OSI Vessel defined" & vbCrLf & mobjExistingGDSElements.VesselOSI.RawText & vbCrLf & pOSI.Text)
                Else
                    Dim pVesselNameOSI As String = pOSI.Text.Substring(pOSI.Text.IndexOf(MySettings.GDSValue("TextVSL")) + MySettings.GDSValue("TextVSL").Length)
                    mobjExistingGDSElements.VesselOSI.SetValues(True, pOSI.Text.Substring(0, pOSI.Text.IndexOf(pOSI.ElementID) - 1), MySettings.GDSElement("TextVSL"), pOSI.Text, pVesselNameOSI)
                End If
            End If
        Next
    End Sub
    Private Sub GetSSRElements1A()

        Dim pobjSSR As s1aPNR.SSRfqtvElement

        For Each pobjSSR In mobjPNR1A.SSRfqtvElements

            If pobjSSR.Associations.Passengers.Count > 0 Then
                For Each objPax In pobjSSR.Associations.Passengers
                    mobjFrequentFlyer.AddItem(mobjPassengers(objPax.ElementNo).PaxName, pobjSSR.Airline, pobjSSR.FrequentTravelerNo, "")
                Next
            Else
                For Each pPax As GDSPaxItem In mobjPassengers.Values
                    mobjFrequentFlyer.AddItem(pPax.PaxName, pobjSSR.Airline, pobjSSR.FrequentTravelerNo, "")
                Next
            End If

        Next

        Dim pTQTtext As k1aHostToolKit.CHostResponse = mobjSession1A.Send("RTSTR")
        If pTQTtext.Text.IndexOf("NO SEATS") = 0 Then
            mudtProps.Seats = ""
        Else
            Dim pTemp() As String = pTQTtext.Text.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
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
            mudtProps.Seats = pTemp2
        End If

    End Sub

    Private Sub GetSSR1A()
        mflgExistsSSRDocs = False
        mflgExistsSSRCTC = False
        mstrSSRDocs = ""
        mobjSSRDocs.Clear()

        For Each pSSR As s1aPNR.SSRElement In mobjPNR1A.SSRElements
            If pSSR.Text.IndexOf("SSR DOCS") > 0 And pSSR.Text.IndexOf("SSR DOCS") < 10 Then
                mstrSSRDocs &= pSSR.Text & vbCrLf
                mobjSSRDocs.AddSSRDocsItem(pSSR.ElementNo, pSSR.FreeFlow)
                mflgExistsSSRDocs = True
            ElseIf pSSR.Text.IndexOf("SSR CTC") > 0 And pSSR.Text.IndexOf("SSR CTC") < 10 Then
                mflgExistsSSRCTC = True
            End If
        Next
    End Sub
    Private Sub GetSSR1G()
        mflgExistsSSRDocs = False
        mstrSSRDocs = ""
        For Each pobjSSR As SSRitem In mobjPNR1GRaw.SSR.Values
            With pobjSSR
                '"SEMN/VESSEL-CHRISTOS"
                If (("SI." & .CarrierCode & "*" & .Text).StartsWith(MySettings.GDSValue("TextVOSI"))) Then
                    Dim pVesselNameOSI As String = ("SI." & .CarrierCode & "*" & .Text).Substring(MySettings.GDSValue("TextVOSI").Length).Trim
                    mobjExistingGDSElements.VesselOSI.SetValues(True, pobjSSR.ElementNo, MySettings.GDSElement("TextVOSI"), pobjSSR.Text, pVesselNameOSI)
                    mstrVesselName = .Text.Substring(12).Trim
                ElseIf .SSRCode = "DOCS" Then
                    mstrSSRDocs &= "SI.SSR" & .SSRCode & .CarrierCode & .StatusCode & "1" & .Text.Split("-")(0) & vbCrLf
                    mflgExistsSSRDocs = True
                End If
            End With
        Next pobjSSR
    End Sub
    Private Sub GetRMElements1A()

        Dim pobjRMElement As s1aPNR.RemarkElement

        For Each pobjRMElement In mobjPNR1A.RemarkElements
            parseRMElements1A(pobjRMElement)
        Next pobjRMElement

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
    Private Sub parseRMElements1A(ByVal Element As s1aPNR.RemarkElement)

        Dim pintLen As Integer
        Dim pstrText As String
        Dim pstrSplit() As String
        Dim pFound As Boolean = False
        Dim pTemp As String = ""
        pstrText = Element.ElementID & " " & Element.FreeFlow ' ConcatenateText(Element.Text)
        mstrCLA = SplitRM1AElement(mstrCLA, MySettings.GDSValue("TextCLA"), pstrText)
        mstrCC = SplitRM1AElement(mstrCC, MySettings.GDSValue("TextCC"), pstrText)
        mstrCC = SplitRM1AElement(mstrCC, "RM *GRACECRM/COST CENTRE-", pstrText)
        mstrCLN = SplitRM1AElement(mstrCLN, MySettings.GDSValue("TextCLN"), pstrText)
        mstrCLN = SplitRM1AElement(mstrCLN, "RM *GRACECLN/", pstrText)
        mstrCLN = SplitRM1AElement(mstrCLN, "RM *D,AC-", pstrText)
        mstrBookedBy = SplitRM1AElement(mstrBookedBy, MySettings.GDSValue("TextBBY"), pstrText)
        mstrBookedBy = SplitRM1AElement(mstrBookedBy, "RM *GRACECRM/BOOKED BY-", pstrText)
        mstrBookedBy = SplitRM1AElement(mstrBookedBy, "RM *D,BOOKED-", pstrText)
        mstrVesselName = SplitRM1AElement(mstrVesselName, MySettings.GDSValue("TextVSL"), pstrText)
        mstrVesselName = SplitRM1AElement(mstrVesselName, "RM *D,CC1-", pstrText)
        mstrVesselName = SplitRM1AElement(mstrVesselName, "RM *GRACECRM/VESSEL-", pstrText)

        If pstrText.IndexOf(MySettings.GDSValue("TextCLA")) > -1 Then
            mstrCLA = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue("TextCLA")) + MySettings.GDSValue("TextCLA").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue("TextCC")) > -1 Then
            mstrCC = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue("TextCC")) + MySettings.GDSValue("TextCC").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue("TextCLN")) > -1 Then
            mstrCLN = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue("TextCLN")) + MySettings.GDSValue("TextCLN").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue("TextBBY")) > -1 Then
            mstrBookedBy = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue("TextBBY")) + MySettings.GDSValue("TextBBY").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue("TextVSL")) > -1 Then
            mstrVesselName = pstrText.Substring(pstrText.IndexOf(MySettings.GDSValue("TextVSL")) + MySettings.GDSValue("TextVSL").Length)
            pFound = True
        ElseIf pstrText.IndexOf(MySettings.GDSValue("TextTRID")) > -1 Then
            pFound = True
        End If

        If Not pFound Then
            pintLen = pstrText.Length
            pstrSplit = Split(Left(pstrText, pintLen), "/")

            If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
                If pstrText.StartsWith(MySettings.GDSValue("TextCLA")) Then
                    mstrCLA = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextCC")) Then
                    mstrCC = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextCLN")) Then
                    mstrCLN = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextBBY")) Then
                    mstrBookedBy = pstrSplit(2)
                    pFound = True
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextVSL")) Then
                    mstrVesselName = pstrSplit(2)
                    pFound = True
                End If
            ElseIf IsArray(pstrSplit) AndAlso pstrSplit.Length >= 1 Then
                If pstrText.StartsWith(MySettings.GDSValue("TextTRID")) Then
                    pFound = True
                End If
            End If

        End If
        If Not pFound Then
            pstrSplit = Split(Left(pstrText, pintLen), "-")
            If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
                If pstrText.StartsWith(MySettings.GDSValue("TextCLA")) Then
                    mstrCLA = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextCC")) Then
                    mstrCC = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextCLN")) Then
                    mstrCLN = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextBBY")) Then
                    mstrBookedBy = pstrSplit(1)
                ElseIf pstrText.StartsWith(MySettings.GDSValue("TextVSL")) Then
                    mstrVesselName = pstrSplit(1)
                End If

            End If

        End If


    End Sub
    Private Sub GetAI1A()
        For Each pElement As s1aPNR.AccountingAIElement In mobjPNR1A.AccountingAIElements
            If pElement.Text.Contains(MySettings.GDSValue("TextAI")) Then
                mobjExistingGDSElements.CustomerCodeAI.SetValues(True, pElement.Text.Substring(0, pElement.Text.IndexOf(pElement.ElementID) - 1), MySettings.GDSElement("TextAI"), pElement.Text, pElement.AccountNo)
            End If
        Next
    End Sub
    Private Sub GetRM1A()
        For Each pRemark As s1aPNR.RemarkElement In mobjPNR1A.RemarkElements
            If pRemark.Text.Contains(MySettings.GDSValue("TextAGT")) Then
                mobjExistingGDSElements.AgentID.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextAGT"), pRemark.Text, "")
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextCLN")) Then
                If mobjExistingGDSElements.CustomerCode.Exists Then
                    Throw New Exception("Please check PNR. Duplicate customer defined" & vbCrLf & mobjExistingGDSElements.CustomerCode.RawText & vbCrLf & pRemark.Text)
                Else
                    Dim pCustomerCode As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextCLN")) + MySettings.GDSValue("TextCLN").Length)
                    mobjExistingGDSElements.CustomerCode.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextCLN"), pRemark.Text, pCustomerCode)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextSBN")) Then
                If mobjExistingGDSElements.SubDepartmentCode.Exists Then
                    Throw New Exception("Please check PNR. Duplicate subdepartment defined" & vbCrLf & mobjExistingGDSElements.SubDepartmentCode.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pSubDepartment As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextSBN")) + MySettings.GDSValue("TextSBN").Length)
                    mobjExistingGDSElements.SubDepartmentCode.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextSBN"), "", pSubDepartment)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextCRN")) Then
                If mobjExistingGDSElements.CRMCode.Exists Then
                    Throw New Exception("Please check PNR. Duplicate CRM defined" & vbCrLf & mobjExistingGDSElements.CRMCode.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pCRM As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextCRN")) + MySettings.GDSValue("TextCRN").Length)
                    mobjExistingGDSElements.CRMCode.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextCRN"), "", pCRM)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextVSL")) Then
                If mobjExistingGDSElements.VesselName.Exists Then
                    Throw New Exception("Please check PNR. Duplicate vessel defined" & vbCrLf & mobjExistingGDSElements.VesselName.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pVesselName As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextVSL")) + MySettings.GDSValue("TextVSL").Length)
                    mobjExistingGDSElements.VesselName.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextVSL"), "", pVesselName)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextVSR")) Then
                If mobjExistingGDSElements.VesselFlag.Exists Then
                    Throw New Exception("Please check PNR. Duplicate vessel registration defined" & vbCrLf & mobjExistingGDSElements.VesselFlag.LineNumber & vbCrLf & pRemark.Text)
                Else
                    Dim pVesselRegistration As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextVSR")) + MySettings.GDSValue("TextVSR").Length)
                    mobjExistingGDSElements.VesselFlag.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextVSR"), "", pVesselRegistration)
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextREF")) Then
                Dim pReference As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextREF")) + MySettings.GDSValue("TextREF").Length)
                mobjExistingGDSElements.Reference.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextREF"), "", pReference)
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextBBY")) Then
                Dim pBookedBy As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextBBY")) + MySettings.GDSValue("TextBBY").Length)
                mobjExistingGDSElements.BookedBy.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextBBY"), "", pBookedBy)
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextDPT")) Then
                Dim pDepartment As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextDPT")) + MySettings.GDSValue("TextDPT").Length)
                mobjExistingGDSElements.Department.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextDPT"), True, pDepartment)
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextRFT")) Then
                Dim pReasonForTravel As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextRFT")) + MySettings.GDSValue("TextRFT").Length)
                mobjExistingGDSElements.ReasonForTravel.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextRFT"), "", pReasonForTravel)
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextCC")) Then
                Dim pCostCentre As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextCC")) + MySettings.GDSValue("TextCC").Length)
                mobjExistingGDSElements.CostCentre.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextCC"), "", pCostCentre)
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextTRID")) Then
                Dim pReference As String = pRemark.Text.Substring(pRemark.Text.IndexOf(MySettings.GDSValue("TextTRID")) + MySettings.GDSValue("TextTRID").Length)
                mobjExistingGDSElements.TRId.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextTRID"), "", pReference)
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextCLA")) Then
                If mobjExistingGDSElements.CustomerName.Exists Then
                    Throw New Exception("Please check PNR. Duplicate customer name defined" & vbCrLf & mobjExistingGDSElements.CustomerName.LineNumber & vbCrLf & pRemark.Text)
                Else
                    mobjExistingGDSElements.CustomerName.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextCLA"), "", "")
                End If
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextSBA")) Then
                mobjExistingGDSElements.SubDepartmentName.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextSBA"), "", "")
            ElseIf pRemark.Text.Contains(MySettings.GDSValue("TextCRA")) Then
                mobjExistingGDSElements.CRMName.SetValues(True, pRemark.Text.Substring(0, pRemark.Text.IndexOf(pRemark.ElementID) - 1), MySettings.GDSElement("TextCRA"), "", "")
            End If
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
                If pFullText.StartsWith(MySettings.GDSValue("TextAGT")) Then
                    mobjExistingGDSElements.AgentID.SetValues(True, .ElementNo, MySettings.GDSElement("TextAGT"), .Remark, pFullText.Substring(MySettings.GDSValue("TextAGT").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextBBY")) Then
                    Dim pBookedBy As String = pFullText.Substring(MySettings.GDSValue("TextBBY").Length)
                    mstrBookedBy = pBookedBy ' .Remark.Substring(10)
                    mobjExistingGDSElements.BookedBy.SetValues(True, .ElementNo, MySettings.GDSElement("TextBBY"), .Remark, pBookedBy)
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextCC")) Then
                    mstrCC = .Remark.Substring(9)
                    mobjExistingGDSElements.CostCentre.SetValues(True, .ElementNo, MySettings.GDSElement("TextCC"), .Remark, pFullText.Substring(MySettings.GDSValue("TextCC").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextTRID")) Then
                    mobjExistingGDSElements.TRId.SetValues(True, .ElementNo, MySettings.GDSElement("TextTRID"), .Remark, pFullText.Substring(MySettings.GDSValue("TextTRID").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextCLA")) Then
                    If Not mobjExistingGDSElements.CustomerName.Exists Then
                        mstrCLA = .Remark.Substring(10)
                        mobjExistingGDSElements.CustomerName.SetValues(True, .ElementNo, MySettings.GDSElement("TextCLA"), .Remark, pFullText.Substring(MySettings.GDSValue("TextCLA").Length))
                    End If
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextCLN")) Then
                    Dim pCustomerCode As String = pFullText.Substring(MySettings.GDSValue("TextCLN").Length)
                    If mobjExistingGDSElements.CustomerCode.Exists Then
                        Throw New Exception("Please check PNR. Duplicate customer defined" & vbCrLf & mobjExistingGDSElements.CustomerCode.RawText & vbCrLf & .Remark)
                    Else
                        mstrCLN = pCustomerCode
                        mobjExistingGDSElements.CustomerCode.SetValues(True, .ElementNo, MySettings.GDSElement("TextCLN"), .Remark, pCustomerCode)
                    End If
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextCRA")) Then
                    mobjExistingGDSElements.CRMName.SetValues(True, .ElementNo, MySettings.GDSElement("TextCRA"), .Remark, pFullText.Substring(MySettings.GDSValue("TextCRA").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextCRN")) Then
                    mobjExistingGDSElements.CRMCode.SetValues(True, .ElementNo, MySettings.GDSElement("TextCRN"), .Remark, pFullText.Substring(MySettings.GDSValue("TextCRN").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextDPT")) Then
                    mobjExistingGDSElements.Department.SetValues(True, .ElementNo, MySettings.GDSElement("TextDPT"), .Remark, pFullText.Substring(MySettings.GDSValue("TextDPT").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextREF")) Then
                    mobjExistingGDSElements.Reference.SetValues(True, .ElementNo, MySettings.GDSElement("TextREF"), .Remark, pFullText.Substring(MySettings.GDSValue("TextREF").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextRFT")) Then
                    mobjExistingGDSElements.ReasonForTravel.SetValues(True, .ElementNo, MySettings.GDSElement("TextRFT"), .Remark, pFullText.Substring(MySettings.GDSValue("TextRFT").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextSBA")) Then
                    mobjExistingGDSElements.SubDepartmentName.SetValues(True, .ElementNo, MySettings.GDSElement("TextSBA"), .Remark, pFullText.Substring(MySettings.GDSValue("TextSBA").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextSBN")) Then
                    mobjExistingGDSElements.SubDepartmentCode.SetValues(True, .ElementNo, MySettings.GDSElement("TextSBN"), .Remark, pFullText.Substring(MySettings.GDSValue("TextSBN").Length))
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextVSL")) Then
                    mstrVesselName = pFullText.Substring(MySettings.GDSValue("TextVSL").Length)
                    mobjExistingGDSElements.VesselName.SetValues(True, .ElementNo, MySettings.GDSElement("TextVSL"), .Remark, mstrVesselName)
                ElseIf pFullText.StartsWith(MySettings.GDSValue("TextVSR")) Then
                    mobjExistingGDSElements.VesselFlag.SetValues(True, .ElementNo, MySettings.GDSElement("TextVSR"), .Remark, pFullText.Substring(MySettings.GDSValue("TextVSR").Length))
                ElseIf pFullText.StartsWith("D,BOOKED") > 0 Then
                    mobjExistingGDSElements.BookedBy.SetValues(True, .ElementNo, "D,BOOKED", .Remark, "DI.")
                ElseIf pFullText.StartsWith("D,AC") > 0 Then
                    If mobjExistingGDSElements.CustomerCode.Exists Then
                        Throw New Exception("Please check PNR. Duplicate customer defined" & vbCrLf & mobjExistingGDSElements.CustomerCode.RawText & vbCrLf & .Remark)
                    Else
                        mobjExistingGDSElements.CustomerCode.SetValues(True, .ElementNo, "D,AC", .Remark, "DI.")
                    End If
                End If
                If .Remark.StartsWith("D,BOOKED") > 0 Then
                    mstrBookedBy = .Remark.Substring(8)
                ElseIf .Remark.StartsWith("D,AC") > 0 Then
                    mstrCLN = .Remark.Substring(4)
                End If

            End With
        Next
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
    Private Sub GetSegs1A()

        Dim pobjSeg As Object
        Dim pPrevElement As Integer = 0
        Dim pstrConnectingTime As String = ""
        Dim pdtePrevArrivalDate As Date
        Dim pdtePrevArrivalTime As Date
        ' TODO
        Dim pMealFlight As String = ""
        Dim pMealSSR As String = ""

        mobjSegments.Clear()
        mSegsLastElement = -1
        mSegsFirstElement = -1

        For Each pobjSeg In mobjPNR1A.AllAirSegments
            If pobjSeg.Tag.Indexof(".AirFlownSegment.") = -1 Then
                'End If
                'If Not pobjSeg.Text.ToString.EndsWith("FLWN") Then
                Dim pElementNo As Integer = airElementNo1A(pobjSeg)
                Dim pSegDoTemp As k1aHostToolKit.CHostResponse = mobjSession1A.Send("DO" & pobjSeg.ElementNo)
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
                    pSegDMTemp = mobjSession1A.Send("DM" & pPrevElement & "/" & pobjSeg.ElementNo)
                    If pSegDMTemp.Text.IndexOf("INVALID PRIOR DISPLAY") > -1 Then
                        mobjSession1A.Send("RTI")
                        pSegDMTemp = mobjSession1A.Send("DM" & pPrevElement & "/" & pobjSeg.ElementNo)
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
                    ' TODO fix the connecting time
                    Dim pTempDiff As Integer
                    Try
                        pTempDiff = DateDiff(DateInterval.Day, pdtePrevArrivalDate, pobjSeg.DepartureDate) * 24 * 60 + DateDiff(DateInterval.Minute, pdtePrevArrivalTime, pobjSeg.DepartureTime)
                    Catch ex As Exception
                        pTempDiff = 0
                    End Try
                    Dim pTempDiffConnect As String = ""
                    If pTempDiff >= 24 * 60 Then ' connection is more than 1 day
                        Dim pDays As Integer = Int(pTempDiff / (24 * 60))
                        pTempDiff = pTempDiff - pDays * 24 * 60
                        pTempDiffConnect = pDays & " days:" & Format(Int(pTempDiff / 60), "00") & ":" & Format(pTempDiff - Int(pTempDiff / 60) * 60, "00")
                    Else
                        pTempDiffConnect = Format(Int(pTempDiff / 60), "00") & ":" & Format(pTempDiff - Int(pTempDiff / 60) * 60, "00")
                    End If
                    pstrConnectingTime = pTempDiffConnect
                End If

                mobjSegments.AddItem(airAirline1A(pobjSeg), airBoardPoint1A(pobjSeg), airClass1A(pobjSeg), airDepartureDate1A(pobjSeg), airArrivalDate1A(pobjSeg), pElementNo, airFlightNo1A(pobjSeg), airOffPoint1A(pobjSeg), airStatus1A(pobjSeg), airDepartTime1A(pobjSeg), airArriveTime1A(pobjSeg), Equipment(pobjSeg), pMealFlight, pMealSSR, airText1A(pobjSeg), pSegDo, pstrConnectingTime)

                If mSegsFirstElement = -1 Then
                    mSegsFirstElement = pElementNo
                End If
                If pElementNo > mSegsLastElement Then
                    mSegsLastElement = pElementNo
                End If

                pPrevElement = pobjSeg.ElementNo
                pdtePrevArrivalDate = airArrivalDate1A(pobjSeg) ' pobjSeg.ArrivalDate
                pdtePrevArrivalTime = airArriveTime1A(pobjSeg) ' pobjSeg.ArrivalTime
            End If
        Next pobjSeg

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
                    SegAssociations &= mobjSegments(objSeg.ElementNo).BoardPoint & " " & mobjSegments(objSeg.ElementNo).Airline & " " & mobjSegments(objSeg.ElementNo).OffPoint & vbCrLf
                Next
            Else
                For Each pSeg As GDSSegItem In mobjSegments.Values
                    SegAssociations &= pSeg.BoardPoint & " " & pSeg.Airline & " " & pSeg.OffPoint & vbCrLf
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
                    SegAssociations &= mobjSegments(objSeg.ElementNo).BoardPoint & " " & mobjSegments(objSeg.ElementNo).Airline & " " & mobjSegments(objSeg.ElementNo).OffPoint & vbCrLf
                Next
            Else
                For Each pSeg As GDSSegItem In mobjSegments.Values
                    SegAssociations &= pSeg.BoardPoint & " " & pSeg.Airline & " " & pSeg.OffPoint & vbCrLf
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
    Private Sub GetOtherServiceElements1A()

        Dim pobjOtherServiceElement As s1aPNR.OtherServiceElement

        For Each pobjOtherServiceElement In mobjPNR1A.OtherServiceElements
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
                    mstrVesselName = ""
                    For j = i + 1 To pstrSplit.GetUpperBound(0)
                        mstrVesselName = mstrVesselName & " " & pstrSplit(j).Trim
                    Next j
                    Exit For
                ElseIf pstrSplit(i).StartsWith("SEMN/VESSEL") Then
                    mstrVesselName = pstrSplit(i).Substring(12).Trim
                    For j = i + 1 To pstrSplit.GetUpperBound(0)
                        If pstrSplit(j) <> "-" Then
                            mstrVesselName = mstrVesselName & " " & pstrSplit(j).Trim
                        End If
                    Next j
                    Exit For
                End If
            Next i
        End If

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
                        'Dim pAllowance As New TQTItem With {
                        '    .Itin = pTQT(i).Substring(5, 6) & " " & pTQT(i + 1).Substring(5, 3),
                        '    .Allowance = pTQT(i).Substring(60)
                        '}
                        'mudtAllowance.Add(pAllowance)
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
