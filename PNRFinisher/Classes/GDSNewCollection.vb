Option Strict On
Option Explicit On
Public Class GDSNewCollection
    Public Event NewItemCreated()

    Private mstrClientQueue As String

    Private ReadOnly mstrOfficeOfResponsibility As String
    Private ReadOnly mdteDepartureDate As Date
    Private ReadOnly mintNumberOfPax As Integer
    Private ReadOnly mGDSCode As EnumGDSCode
    Public Property OpenSegment As GDSNewItem
    Public Property PhoneElement As GDSNewItem
    Public Property EmailElement As GDSNewItem
    Public Property TicketElement As GDSNewItem
    Public Property OptionQueueElement As GDSNewItem
    Public Property AOH As GDSNewItem
    Public Property AgentID As GDSNewItem
    Public Property ClientCodeAIItem As GDSNewItem
    Public Property ClientCodeItem As GDSNewItem
    Public Property SavingsElement As GDSNewItem
    Public Property LossElement As GDSNewItem
    Public Property ClientNameItem As GDSNewItem
    Public Property SubDepartmentCode As GDSNewItem
    Public Property SubDepartmentName As GDSNewItem
    Public Property CRMCode As GDSNewItem
    Public Property CRMName As GDSNewItem
    Public Property VesselName As GDSNewItem
    Public Property VesselFlag As GDSNewItem
    Public Property VesselOSI As GDSNewItem
    Public Property VesselNameForPNR As GDSNewItem
    Public Property VesselFlagForPNR As GDSNewItem
    Public Property Reference As GDSNewItem
    Public Property GalileoTrackingCode As GDSNewItem
    'Public ReadOnly Property BookedBy As New GDSNewItem
    'Public ReadOnly Property Department As New GDSNewItem
    'Public ReadOnly Property ReasonForTravel As New GDSNewItem
    'Public ReadOnly Property CostCentre As New GDSNewItem
    'Public ReadOnly Property TRId As New GDSNewItem
    Public ReadOnly Property ClientQueue As String
        Get
            Return mstrClientQueue
        End Get
    End Property

    Public Sub New(ByVal pOfficeOfResponsibility As String, ByVal pDepartureDate As Date, ByVal pNumberOfPax As Integer, ByVal pGDSCode As EnumGDSCode, ByVal pBackOffice As Integer)
        mstrOfficeOfResponsibility = pOfficeOfResponsibility
        mdteDepartureDate = pDepartureDate
        mintNumberOfPax = pNumberOfPax
        mGDSCode = pGDSCode
        PrepareCommands(pBackOffice)
    End Sub
    Public Sub New()
        mstrOfficeOfResponsibility = ""
        mdteDepartureDate = Date.MinValue
        mintNumberOfPax = 0
        mGDSCode = EnumGDSCode.Unknown
    End Sub

    Public Sub SetClient(ByVal pBackOffice As Integer, ByVal Item As Client)

        mstrClientQueue = ""
        If Not Item Is Nothing Then
            ClientCodeItem = New GDSNewItem(Item.Code, MySettings.GDSValue(pBackOffice, "TextCLN") & Item.Code)
            ClientCodeAIItem = New GDSNewItem(Item.Code, MySettings.GDSValue(pBackOffice, "TextAI") & Item.Code)
            ClientNameItem = New GDSNewItem(Item.Name, MySettings.GDSValue(pBackOffice, "TextCLA") & GreekToLatin.Convert(Item.Name))
            GalileoTrackingCode = New GDSNewItem(Item.GalileoTrackingCode, MySettings.GDSValue(pBackOffice, "TextGalTrackingCode") & Item.GalileoTrackingCode)
            ReadClientQueue(Item.Code, pBackOffice)
            RaiseEvent NewItemCreated()
        Else
            ClientCodeItem = New GDSNewItem()
            ClientCodeAIItem = New GDSNewItem
            ClientNameItem = New GDSNewItem
            GalileoTrackingCode = New GDSNewItem
        End If

    End Sub
    Private Sub ReadClientQueue(ByVal ClientCode As String, ByVal pBackOffice As Integer)

        Dim pAlerts As New AlertsCollection
        If mGDSCode = EnumGDSCode.Amadeus Then
            mstrClientQueue = pAlerts.AmadeusAlertForClientQueue(pBackOffice, ClientCode)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            mstrClientQueue = pAlerts.GalileoAlertForClientQueue(pBackOffice, ClientCode)
        Else
            mstrClientQueue = ""
        End If


    End Sub
    Public Sub SetSubDepartment(ByVal pBackOffice As Integer, ByVal Id As Integer, ByVal Code As String, ByVal Name As String)
        If Id > 0 And Name <> "" Then
            SubDepartmentCode = New GDSNewItem(Code, MySettings.GDSValue(pBackOffice, "TextSBN") & Id)
            SubDepartmentName = New GDSNewItem(Name, MySettings.GDSValue(pBackOffice, "TextSBA") & GreekToLatin.Convert(Name))
            RaiseEvent NewItemCreated()
        Else
            SubDepartmentCode = New GDSNewItem
            SubDepartmentName = New GDSNewItem
        End If
    End Sub
    Public Sub SetCRM(ByVal pBackOffice As Integer, ByVal Id As Integer, ByVal Code As String, ByVal Name As String)

        If Id > 0 And Name <> "" Then
            CRMCode = New GDSNewItem(Code, MySettings.GDSValue(pBackOffice, "TextCRN") & Code)
            CRMName = New GDSNewItem(Name, MySettings.GDSValue(pBackOffice, "TextCRA") & GreekToLatin.Convert(Name))
            RaiseEvent NewItemCreated()
        Else
            CRMCode = New GDSNewItem
            CRMName = New GDSNewItem
        End If

    End Sub
    Public Sub SetVessel(ByVal pBackOffice As Integer, ByVal Item As VesselItem)

        If Not Item Is Nothing Then
            VesselName = New GDSNewItem(Item.VesselName, MySettings.GDSValue(pBackOffice, "TextVSL") & Item.VesselName)
            If Item.VesselRegistration <> "" Then
                VesselFlag = New GDSNewItem(Item.VesselRegistration, MySettings.GDSValue(pBackOffice, "TextVSR") & Item.VesselRegistration)
            End If
            VesselOSI = New GDSNewItem("OSI", MySettings.GDSValue(pBackOffice, "TextVOS") & Item.VesselName)
            VesselNameForPNR = New GDSNewItem
            VesselFlagForPNR = New GDSNewItem
            RaiseEvent NewItemCreated()
        Else
            VesselName = New GDSNewItem
            VesselFlag = New GDSNewItem

        End If

    End Sub
    Public Sub SetVesselForPNR(ByVal pBackOffice As Integer, ByVal pVesselName As String, ByVal pVesselFlag As String)


        If pVesselName <> "" Then
            VesselName = New GDSNewItem("VSL", MySettings.GDSValue(pBackOffice, "TextVSL") & VesselNameForPNR.TextRequested)
            VesselOSI = New GDSNewItem("VOS", MySettings.GDSValue(pBackOffice, "TextVOS") & VesselNameForPNR.TextRequested)
            If pVesselFlag <> "" Then
                VesselFlag = New GDSNewItem("VSR", MySettings.GDSValue(pBackOffice, "TextVSR") & VesselFlagForPNR.TextRequested)
                If VesselOSI.GDSCommand <> "" Then
                    VesselOSI = New GDSNewItem("VOS", MySettings.GDSValue(pBackOffice, "TextVOS") & VesselFlagForPNR.TextRequested)
                End If
            End If
        Else
            VesselName = New GDSNewItem
            VesselFlag = New GDSNewItem
        End If

        VesselNameForPNR.SetText(pVesselName)
        VesselFlagForPNR.SetText(pVesselFlag)
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetReference(ByVal pBackOffice As Integer, ByVal Text As String)
        Text = Text.Trim
        Reference = New GDSNewItem(Text, MySettings.GDSValue(pBackOffice, "TextREF") & Text)
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetGalileoTracking(ByVal pBackOffice As Integer, ByVal Text As String)
        Text = Text.Trim
        GalileoTrackingCode = New GDSNewItem(Text, MySettings.GDSValue(pBackOffice, "TextGalTrackingCode") & Text)
        RaiseEvent NewItemCreated()
    End Sub
    'Public Sub SetBookedBy(ByVal pBackOffice As Integer, ByVal Text As String)
    '    Text = Text.Trim
    '    If Text <> "" Then
    '        BookedBy.SetText(Text, MySettings.GDSValue(pBackOffice, "TextBBY") & Text)
    '    Else
    '        BookedBy.Clear()
    '    End If
    '    RaiseEvent NewItemCreated()
    'End Sub
    'Public Sub SetDepartment(ByVal pBackOffice As Integer, ByVal Text As String)
    '    Text = Text.Trim
    '    If Text <> "" Then
    '        Department.SetText(Text, MySettings.GDSValue(pBackOffice, "TextDPT") & Text)
    '    Else
    '        Department.Clear()
    '    End If
    '    RaiseEvent NewItemCreated()
    'End Sub
    'Public Sub SetReasonForTravel(ByVal pBackOffice As Integer, ByVal Text As String)
    '    Text = Text.Trim
    '    If Text <> "" Then
    '        ReasonForTravel.SetText(Text, MySettings.GDSValue(pBackOffice, "TextRFT") & Text)
    '    Else
    '        ReasonForTravel.Clear()
    '    End If
    '    RaiseEvent NewItemCreated()
    'End Sub
    'Public Sub SetCostCentre(ByVal pBackOffice As Integer, ByVal Text As String)
    '    Text = Text.Trim
    '    If Text <> "" Then
    '        CostCentre.SetText(Text, MySettings.GDSValue(pBackOffice, "TextCC") & Text)
    '    Else
    '        CostCentre.Clear()
    '    End If
    '    RaiseEvent NewItemCreated()
    'End Sub
    'Public Sub SetTRId(ByVal pBackOffice As Integer, ByVal Text As String)
    '    Text = Text.Trim
    '    If Text <> "" Then
    '        TRId.SetText(Text, MySettings.GDSValue(pBackOffice, "TextTRID") & Text)
    '    Else
    '        TRId.Clear()
    '    End If
    '    RaiseEvent NewItemCreated()
    'End Sub
    Private Sub PrepareCommands(ByVal pbackOffice As Integer)

        Dim pDateTimeLimit As New s1aAirlineDate.clsAirlineDate
        Dim pDateReminder As New s1aAirlineDate.clsAirlineDate
        Dim pDateRetain As New s1aAirlineDate.clsAirlineDate

        If mdteDepartureDate > DateAdd(DateInterval.Day, 3, Today) Then
            Try
                pDateTimeLimit.VBDate = DateAdd(DateInterval.Day, -3, mdteDepartureDate)
            Catch ex As Exception
                pDateTimeLimit.VBDate = Today
            End Try
        Else
            pDateTimeLimit.VBDate = Today
        End If

        If mdteDepartureDate > Today Then
            Try
                pDateReminder.VBDate = DateAdd(DateInterval.Day, 1, mdteDepartureDate)
            Catch ex As Exception
                pDateReminder.VBDate = Today
            End Try
        Else
            pDateReminder.VBDate = Today
        End If

        Try
            pDateRetain.VBDate = DateAdd(DateInterval.Month, 11, Today)
        Catch ex As Exception
            pDateRetain.VBDate = Today
        End Try

        PhoneElement = New GDSNewItem("AP", (MySettings.GDSValue(pbackOffice, "TextAP").Replace("  ", " ")))
        EmailElement = New GDSNewItem("APE", MySettings.GDSValue(pbackOffice, "TextAPE"))
        AgentID = New GDSNewItem("AGT", MySettings.GDSValue(pbackOffice, "TextAGT"))

        If mGDSCode = EnumGDSCode.Amadeus Then
            Dim pTTLString As String
            If mstrOfficeOfResponsibility <> MySettings.GDSPcc Then
                pTTLString = MySettings.GDSValue(pbackOffice, "TextTTL") & pDateTimeLimit.IATA & "/" & MySettings.GDSPcc
            Else
                pTTLString = MySettings.GDSValue(pbackOffice, "TextTTL") & pDateTimeLimit.IATA
            End If
            TicketElement = New GDSNewItem("TTL", pTTLString)
            OpenSegment = New GDSNewItem("MIS",
                                MySettings.GDSValue(pbackOffice, "TextMISSegmentCommand") &
                                IIf(mintNumberOfPax = 0, 1, mintNumberOfPax).ToString & " " &
                                MySettings.OfficeCityCode & " " &
                                pDateRetain.IATA & "-" & MySettings.GDSValue(pbackOffice, "TextMISSegmentText"))
            OptionQueueElement = New GDSNewItem("OP", MySettings.GDSValue(pbackOffice, "TextOP") & MySettings.GDSPcc & "/" & pDateReminder.IATA & "/" & MySettings.AgentOPQueue)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            TicketElement = New GDSNewItem("TTL", MySettings.GDSValue(pbackOffice, "TextTTL") & pDateTimeLimit.IATA)
            OpenSegment = New GDSNewItem("MIS", MySettings.GDSValue(pbackOffice, "TextMISSegmentCommand") & pDateRetain.IATA & "*" & MySettings.GDSValue(pbackOffice, "TextMISSegmentText"))
            OptionQueueElement = New GDSNewItem("OP", MySettings.GDSValue(pbackOffice, "TextOP") & "/" & pDateReminder.IATA & "/0001/Q" & MySettings.AgentOPQueue)
        Else
            Throw New Exception("GDSNew.PrepareCommands()" & vbCrLf & "GDS Not selected")
        End If
        AOH = New GDSNewItem("AOH", MySettings.GDSValue(pbackOffice, "TextAOH"))

    End Sub
    Public Sub Clear()

        OpenSegment = New GDSNewItem
        PhoneElement = New GDSNewItem
        EmailElement = New GDSNewItem
        TicketElement = New GDSNewItem

        OptionQueueElement = New GDSNewItem
        AOH = New GDSNewItem
        AgentID = New GDSNewItem
        SavingsElement = New GDSNewItem
        LossElement = New GDSNewItem

        ClearClientElements()

    End Sub
    Public Sub ClearClientElements()
        ClientCodeAIItem = New GDSNewItem
        ClientCodeItem = New GDSNewItem
        mstrClientQueue = ""
        ClientNameItem = New GDSNewItem
        SubDepartmentCode = New GDSNewItem
        SubDepartmentName = New GDSNewItem
        CRMCode = New GDSNewItem
        CRMName = New GDSNewItem
        VesselName = New GDSNewItem
        VesselFlag = New GDSNewItem
        VesselOSI = New GDSNewItem
        Reference = New GDSNewItem
        GalileoTrackingCode = New GDSNewItem
        VesselNameForPNR = New GDSNewItem
        VesselFlagForPNR = New GDSNewItem
    End Sub
End Class
