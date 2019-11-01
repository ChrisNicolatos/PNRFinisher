Option Strict On
Option Explicit On
Public Class GDSNewCollection
    Public Event NewItemCreated()
    'Private mobjOpenSegment As New GDSNewItem
    'Private mobjPhoneElement As New GDSNewItem
    'Private mobjEmailElement As New GDSNewItem
    'Private mobjTicketElement As New GDSNewItem

    'Private mobjOptionQueueElement As New GDSNewItem
    'Private mobjAOH As New GDSNewItem
    'Private mobjAgentID As New GDSNewItem
    'Private mobjSavingsElement As New GDSNewItem
    'Private mobjLossElement As New GDSNewItem

    'Private mobjCustomerCodeAI As New GDSNewItem
    'Private mobjCustomerCode As New GDSNewItem
    'Private mobjCustomerName As New GDSNewItem
    'Private mstrCustomerQueue As String
    'Private mobjSubDepartmentCode As New GDSNewItem
    'Private mobjSubDepartmentName As New GDSNewItem
    'Private mobjCRMCode As New GDSNewItem
    'Private mobjCRMName As New GDSNewItem
    'Private mobjVesselFlag As New GDSNewItem
    'Private mobjVesselOSI As New GDSNewItem
    'Private mobjReference As New GDSNewItem
    'Private mobjBookedBy As New GDSNewItem
    'Private mobjDepartment As New GDSNewItem
    'Private mobjReasonForTravel As New GDSNewItem
    'Private mobjCostCentre As New GDSNewItem
    'Private mobjTRId As New GDSNewItem

    'Private mobjGalTracking As New GDSNewItem

    Private ReadOnly mstrOfficeOfResponsibility As String
    Private ReadOnly mdteDepartureDate As Date
    Private ReadOnly mintNumberOfPax As Integer
    Private ReadOnly mGDSCode As EnumGDSCode
    Friend Sub New(ByVal pOfficeOfResponsibility As String, ByVal pDepartureDate As Date, ByVal pNumberOfPax As Integer, ByVal pGDSCode As EnumGDSCode)
        mstrOfficeOfResponsibility = pOfficeOfResponsibility
        mdteDepartureDate = pDepartureDate
        mintNumberOfPax = pNumberOfPax
        mGDSCode = pGDSCode
        PrepareCommands()
    End Sub
    Public Sub New()
        mstrOfficeOfResponsibility = ""
        mdteDepartureDate = Date.MinValue
        mintNumberOfPax = 0
        mGDSCode = EnumGDSCode.Unknown
    End Sub
    Public Property VesselName As GDSNewItem = New GDSNewItem
    Public Property VesselNameForPNR As GDSNewItem = New GDSNewItem
    Public Property VesselFlagForPNR As GDSNewItem = New GDSNewItem
    Public ReadOnly Property OpenSegment As GDSNewItem = New GDSNewItem
    Public ReadOnly Property PhoneElement As GDSNewItem = New GDSNewItem
    Public ReadOnly Property EmailElement As GDSNewItem = New GDSNewItem
    Public ReadOnly Property TicketElement As GDSNewItem = New GDSNewItem
    Public ReadOnly Property OptionQueueElement As GDSNewItem = New GDSNewItem
    Public ReadOnly Property AOH As GDSNewItem = New GDSNewItem
    Public ReadOnly Property AgentID As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CustomerCodeAI As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CustomerCode As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CustomerQueue As String = ""
    Public ReadOnly Property SavingsElement As GDSNewItem = New GDSNewItem
    Public ReadOnly Property LossElement As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CustomerName As GDSNewItem = New GDSNewItem
    Public ReadOnly Property SubDepartmentCode As GDSNewItem = New GDSNewItem
    Public ReadOnly Property SubDepartmentName As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CRMCode As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CRMName As GDSNewItem = New GDSNewItem
    Public ReadOnly Property VesselFlag As GDSNewItem = New GDSNewItem
    Public ReadOnly Property VesselOSI As GDSNewItem = New GDSNewItem
    Public ReadOnly Property Reference As GDSNewItem = New GDSNewItem
    Public ReadOnly Property BookedBy As GDSNewItem = New GDSNewItem
    Public ReadOnly Property GalileoTrackingCode As GDSNewItem = New GDSNewItem
    Public ReadOnly Property Department As GDSNewItem = New GDSNewItem
    Public ReadOnly Property ReasonForTravel As GDSNewItem = New GDSNewItem
    Public ReadOnly Property CostCentre As GDSNewItem = New GDSNewItem
    Public ReadOnly Property TRId As GDSNewItem = New GDSNewItem

    Public Sub SetItem(ByVal Item As CustomerItem, ByVal pBackOffice As Integer)

        _CustomerCodeAI = New GDSNewItem
        _CustomerCode = New GDSNewItem
        _CustomerName = New GDSNewItem
        _CustomerQueue = ""
        If Not Item Is Nothing Then
            If Item.Code <> "" Then
                _CustomerCode = New GDSNewItem(Item.Code, MySettings.GDSValue("TextCLN") & Item.Code)
                _CustomerCodeAI = New GDSNewItem(Item.Code, MySettings.GDSValue("TextAI") & Item.Code)
            End If
            If Item.Name <> "" Then
                _CustomerName = New GDSNewItem(Item.Name, MySettings.GDSValue("TextCLA") & GreekToLatin.Convert(Item.Name))
            End If
            If Item.GalileoTrackingCode <> "" Then
                _GalileoTrackingCode = New GDSNewItem(Item.GalileoTrackingCode, MySettings.GDSValue("TextGalTrackingCode") & Item.GalileoTrackingCode)
            End If
            ReadCustomerQueue(Item.Code, pBackOffice)
            RaiseEvent NewItemCreated()
        End If

    End Sub
    Private Sub ReadCustomerQueue(ByVal ClientCode As String, ByVal pBackOffice As Integer)

        Dim pAlerts As New AlertsCollection
        If mGDSCode = EnumGDSCode.Amadeus Then
            _CustomerQueue = pAlerts.AmadeusAlertForClientQueue(pBackOffice, ClientCode)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            _CustomerQueue = pAlerts.GalileoAlertForClientQueue(pBackOffice, ClientCode)
        Else
            _CustomerQueue = ""
        End If


    End Sub
    Public Sub SetSubDepartment(ByVal Id As Integer, ByVal Code As String, ByVal Name As String)
        _SubDepartmentCode = New GDSNewItem
        _SubDepartmentName = New GDSNewItem
        If Id > 0 And Name <> "" Then
            _SubDepartmentCode = New GDSNewItem(Code, MySettings.GDSValue("TextSBN") & Id)
            _SubDepartmentName = New GDSNewItem(Name, MySettings.GDSValue("TextSBA") & GreekToLatin.Convert(Name))
            RaiseEvent NewItemCreated()
        End If
    End Sub
    Public Sub SetCRM(ByVal Id As Integer, ByVal Code As String, ByVal Name As String)

        _CRMCode = New GDSNewItem
        _CRMName = New GDSNewItem
        If Id > 0 And Name <> "" Then
            _CRMCode = New GDSNewItem(Code, MySettings.GDSValue("TextCRN") & Code)
            _CRMName = New GDSNewItem(Name, MySettings.GDSValue("TextCRA") & GreekToLatin.Convert(Name))
            RaiseEvent NewItemCreated()
        End If

    End Sub
    Public Sub SetItem(ByVal Item As VesselItem)

        VesselName = New GDSNewItem
        _VesselFlag = New GDSNewItem
        If Not Item Is Nothing Then
            VesselName = New GDSNewItem(Item.Name, MySettings.GDSValue("TextVSL") & Item.Name)
            If Item.Flag <> "" Then
                _VesselFlag = New GDSNewItem(Item.Flag, MySettings.GDSValue("TextVSR") & Item.Flag)
            End If
            _VesselOSI = New GDSNewItem("", MySettings.GDSValue("TextVOS") & Item.Name)
            VesselNameForPNR = New GDSNewItem
            VesselFlagForPNR = New GDSNewItem
            RaiseEvent NewItemCreated()
        End If

    End Sub
    Public Sub SetVesselForPNR(ByVal pVesselName As String, ByVal pVesselFlag As String)

        VesselName = New GDSNewItem
        _VesselFlag = New GDSNewItem
        If pVesselName <> "" Then
            VesselName = New GDSNewItem("", MySettings.GDSValue("TextVSL") & VesselNameForPNR.TextRequested)
            _VesselOSI = New GDSNewItem("", MySettings.GDSValue("TextVOS") & VesselNameForPNR.TextRequested)
            If pVesselFlag <> "" Then
                _VesselFlag = New GDSNewItem("", MySettings.GDSValue("TextVSR") & VesselFlagForPNR.TextRequested)
                If _VesselOSI.GDSCommand <> "" Then
                    _VesselOSI = New GDSNewItem("", MySettings.GDSValue("TextVOS") & VesselFlagForPNR.TextRequested)
                End If
            End If
        End If

        VesselNameForPNR = New GDSNewItem(pVesselName)
        VesselFlagForPNR = New GDSNewItem(pVesselFlag)
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetReference(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _Reference = New GDSNewItem(Text, MySettings.GDSValue("TextREF") & Text)
        Else
            _Reference = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetBookedBy(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _BookedBy = New GDSNewItem(Text, MySettings.GDSValue("TextBBY") & Text)
        Else
            _BookedBy = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetGalileoTracking(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _GalileoTrackingCode = New GDSNewItem(Text, MySettings.GDSValue("TextGalTrackingCode") & Text)
        Else
            _GalileoTrackingCode = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetDepartment(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _Department = New GDSNewItem(Text, MySettings.GDSValue("TextDPT") & Text)
        Else
            _Department = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetReasonForTravel(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _ReasonForTravel = New GDSNewItem(Text, MySettings.GDSValue("TextRFT") & Text)
        Else
            _ReasonForTravel = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetCostCentre(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _CostCentre = New GDSNewItem(Text, MySettings.GDSValue("TextCC") & Text)
        Else
            _CostCentre = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Public Sub SetTRId(ByVal Text As String)
        Text = Text.Trim
        If Text <> "" Then
            _TRId = New GDSNewItem(Text, MySettings.GDSValue("TextTRID") & Text)
        Else
            _TRId = New GDSNewItem
        End If
        RaiseEvent NewItemCreated()
    End Sub
    Private Sub PrepareCommands()

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

        _PhoneElement = New GDSNewItem("", (MySettings.GDSValue("TextAP").Replace("  ", " ")))
        _EmailElement = New GDSNewItem("", MySettings.GDSValue("TextAPE"))
        _AgentID = New GDSNewItem("", MySettings.GDSValue("TextAGT"))

        If mGDSCode = EnumGDSCode.Amadeus Then
            Dim pTTLString As String
            If mstrOfficeOfResponsibility <> MySettings.GDSPcc Then
                pTTLString = MySettings.GDSValue("TextTTL") & pDateTimeLimit.IATA & "/" & MySettings.GDSPcc
            Else
                pTTLString = MySettings.GDSValue("TextTTL") & pDateTimeLimit.IATA
            End If
            _TicketElement = New GDSNewItem("", pTTLString)
            _OpenSegment = New GDSNewItem("",
                                MySettings.GDSValue("TextMISSegmentCommand") &
                                IIf(mintNumberOfPax = 0, 1, mintNumberOfPax).ToString & " " &
                                MySettings.OfficeCityCode & " " &
                                pDateRetain.IATA & "-" & MySettings.GDSValue("TextMISSegmentText"))
            _OptionQueueElement = New GDSNewItem("", MySettings.GDSValue("TextOP") & MySettings.GDSPcc & "/" & pDateReminder.IATA & "/" & MySettings.AgentOPQueue)
        ElseIf mGDSCode = EnumGDSCode.Galileo Then
            _TicketElement = New GDSNewItem("", MySettings.GDSValue("TextTTL") & pDateTimeLimit.IATA)
            _OpenSegment = New GDSNewItem("", MySettings.GDSValue("TextMISSegmentCommand") & pDateRetain.IATA & "*" & MySettings.GDSValue("TextMISSegmentText"))
            _OptionQueueElement = New GDSNewItem("", MySettings.GDSValue("TextOP") & "/" & pDateReminder.IATA & "/0001/Q" & MySettings.AgentOPQueue)
        Else
            Throw New Exception("GDSNew.PrepareCommands()" & vbCrLf & "GDS Not selected")
        End If
        _AOH = New GDSNewItem("", MySettings.GDSValue("TextAOH"))

    End Sub
    Public Sub Clear()

        _OpenSegment = New GDSNewItem
        _PhoneElement = New GDSNewItem
        _EmailElement = New GDSNewItem
        _TicketElement = New GDSNewItem

        _OptionQueueElement = New GDSNewItem
        _AOH = New GDSNewItem
        _AgentID = New GDSNewItem
        _SavingsElement = New GDSNewItem
        _LossElement = New GDSNewItem

        ClearCustomerElements()

    End Sub
    Public Sub ClearCustomerElements()
        _CustomerCodeAI = New GDSNewItem
        _CustomerCode = New GDSNewItem
        _CustomerQueue = ""
        _CustomerName = New GDSNewItem
        _SubDepartmentCode = New GDSNewItem
        _SubDepartmentName = New GDSNewItem
        _CRMCode = New GDSNewItem
        _CRMName = New GDSNewItem
        VesselName = New GDSNewItem
        _VesselFlag = New GDSNewItem
        _VesselOSI = New GDSNewItem
        _Reference = New GDSNewItem
        _BookedBy = New GDSNewItem
        _GalileoTrackingCode = New GDSNewItem
        _Department = New GDSNewItem
        _ReasonForTravel = New GDSNewItem
        _CostCentre = New GDSNewItem
        VesselNameForPNR = New GDSNewItem
        VesselFlagForPNR = New GDSNewItem
        _TRId = New GDSNewItem
    End Sub
End Class
