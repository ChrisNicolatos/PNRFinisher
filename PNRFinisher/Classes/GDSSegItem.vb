Option Strict On
Option Explicit On
Public Class GDSSegItem

    Public Event Valid(ByRef Status As Boolean)

    Public ReadOnly Property ElementNo As Integer = 0
    Public ReadOnly Property Airline As String = ""
    Public ReadOnly Property AirlineName As String = ""
    Public ReadOnly Property Origin As GDSGeography
    Public ReadOnly Property Destination As GDSGeography
    Public ReadOnly Property Departure As GDSDateTime
    Public ReadOnly Property Arrival As GDSDateTime
    Public ReadOnly Property Status As String
    Public ReadOnly Property ClassOfService As String = ""
    Public ReadOnly Property Equipment As String
    Public ReadOnly Property MealFlight As String
    Public ReadOnly Property MealSSR As String
    Public ReadOnly Property FlightNo As String = ""
    Public ReadOnly Property EstimatedFlyingTime As String
    Public ReadOnly Property AirlineLocator As String
    Public ReadOnly Property Text As String
    Public ReadOnly Property Stopovers As String
    Public ReadOnly Property ArriveTerminal As String
    Public ReadOnly Property DepartTerminal As String
    Public ReadOnly Property ArriveTerminalShort As String
    Public ReadOnly Property DepartTerminalShort As String
    Public ReadOnly Property OperatedBy As String
    Public ReadOnly Property ConnectTimeFromPrevious As String
    Public ReadOnly Property SurfaceSegment As Boolean
    Public ReadOnly Property CO2 As Collections.Generic.List(Of CO2Item)
    Public ReadOnly Property ClassOfServiceDescription As ClassOfServiceItem
    Public Sub New(ByVal pElementNo As Integer)
        ElementNo = pElementNo
        SurfaceSegment = True
        Airline = ""
        AirlineName = ""
        FlightNo = ""
        ClassOfService = ""
        Departure = New GDSDateTime(Date.MinValue, Date.MinValue)
        Arrival = New GDSDateTime(Date.MinValue, Date.MinValue)
        Origin = New GDSGeography("")
        Destination = New GDSGeography("")
        Status = ""
        AirlineLocator = ""
        Equipment = ""
        MealFlight = ""
        MealSSR = ""
        AirlineLocator = ""
        Text = ""
        OperatedBy = ""
        Stopovers = ""
        ArriveTerminal = ""
        DepartTerminal = ""
        EstimatedFlyingTime = ""
        ConnectTimeFromPrevious = ""
        CO2 = New List(Of CO2Item)
        ClassOfServiceDescription = New ClassOfServiceItem
    End Sub
    Public Sub New(ByVal pAirline As String _
                       , ByVal pBoardPoint As String _
                       , ByVal pClass As String _
                       , ByVal pDepartureDate As Date _
                       , ByVal pArrivalDate As Date _
                       , ByVal pElementNo As Integer _
                       , ByVal pFlightNo As String _
                       , ByVal pOffPoint As String _
                       , ByVal pStatus As String _
                       , ByVal pDepartTime As Date _
                       , ByVal pArriveTime As Date _
                       , ByVal pEquipment As String _
                       , ByVal pMealFlight As String _
                       , ByVal pMealSSR As String _
                       , ByVal pVL() As String _
                       , ByVal pText As String _
                       , ByVal pOperatedBy As String _
                       , ByVal SVC As String() _
                       , ByVal pConnectTimeFromPrevious As String)
        ' Galileo
        ElementNo = pElementNo
        Airline = pAirline.Trim
        AirlineName = Airlines.AirlineName(Airline)
        FlightNo = pFlightNo.Trim
        ClassOfService = pClass.Trim

        Origin = New GDSGeography(pBoardPoint)
        Destination = New GDSGeography(pOffPoint)

        Departure = New GDSDateTime(pDepartureDate, pDepartTime)
        Arrival = New GDSDateTime(pArrivalDate, pArriveTime)

        Status = pStatus
        AirlineLocator = ""
        Equipment = pEquipment
        MealFlight = pMealFlight
        MealSSR = pMealSSR
        If pVL.GetUpperBound(0) = 1 Then
            If pVL(1).IndexOf("/") > 0 Then
                AirlineLocator = pVL(1).Substring(5, pVL(1).IndexOf("/") - 5)
            Else
                AirlineLocator = pVL(1).Substring(5)
            End If
        Else
            For iVL As Integer = 1 To pVL.GetUpperBound(0)
                If pVL(iVL).Substring(5, 2) = Airline Then
                    If pVL(iVL).IndexOf("/") > 0 Then
                        AirlineLocator = pVL(iVL).Substring(5, pVL(iVL).IndexOf("/") - 5)
                    Else
                        AirlineLocator = pVL(iVL).Substring(5)
                    End If
                End If
            Next
            If AirlineLocator = "" Then
                For iVL As Integer = 1 To pVL.GetUpperBound(0)
                    If pVL(iVL).Substring(5, 2) = "1A" Then
                        If pVL(iVL).IndexOf("/") > 0 Then
                            AirlineLocator = pVL(iVL).Substring(5, pVL(iVL).IndexOf("/") - 5)
                        Else
                            AirlineLocator = pVL(iVL).Substring(5)
                        End If
                    End If
                Next
            End If
        End If
        Text = pText
        OperatedBy = pOperatedBy

        If OperatedBy = "" Then
            OperatedBy = ""
            For i = 81 To Text.Length Step 80
                If (Text & StrDup(80, " ")).Substring(i, 80).IndexOf("OPERATED BY") >= 0 Then
                    If OperatedBy <> "" Then
                        OperatedBy &= vbCrLf
                    End If
                    OperatedBy &= (Text.Trim & StrDup(80, " ")).Substring(i, 80)
                End If
            Next
        End If


        Stopovers = ""
        ArriveTerminal = ""
        DepartTerminal = ""
        EstimatedFlyingTime = ""
        CO2 = New List(Of CO2Item)
        AnalyzeSVC1G(SVC)
        ConnectTimeFromPrevious = pConnectTimeFromPrevious
        SurfaceSegment = False
        ClassOfServiceDescription = ReadClassOfService(Airline, Origin.AirportCode, Destination.AirportCode, ClassOfService)
    End Sub

    Public Sub New(ByVal pAirline As String _
                    , ByVal pBoardPoint As String _
                    , ByVal pClass As String _
                    , ByVal pDepartureDate As Date _
                    , ByVal pArrivalDate As Date _
                    , ByVal pElementNo As Integer _
                    , ByVal pFlightNo As String _
                    , ByVal pOffPoint As String _
                    , ByVal pStatus As String _
                    , ByVal pDepartTime As Date _
                    , ByVal pArriveTime As Date _
                    , ByVal pEquipment As String _
                    , ByVal pMealFlight As String _
                    , ByVal pMealSSR As String _
                    , ByVal pText As String _
                    , ByVal SegDo As String _
                    , ByVal pConnectTimeFromPrevious As String)
        ' Amadeus
        ElementNo = pElementNo
        Airline = pAirline.Trim
        AirlineName = Airlines.AirlineName(Airline)
        FlightNo = pFlightNo.Trim
        ClassOfService = pClass.Trim
        Origin = New GDSGeography(pBoardPoint)
        Destination = New GDSGeography(pOffPoint)

        Departure = New GDSDateTime(pDepartureDate, pDepartTime)
        Arrival = New GDSDateTime(pArrivalDate, pArriveTime)

        Status = pStatus
        Equipment = pEquipment
        MealFlight = pMealFlight
        MealSSR = pMealSSR
        Dim pTemp As Integer = 54
        AirlineLocator = ""
        If pText.Length > 53 Then
            pTemp = pText.IndexOf(" ", 54)
            If pTemp > 56 Then
                AirlineLocator = pText.Substring(53, pTemp - 52).Trim
            ElseIf pTemp = -1 Then
                AirlineLocator = pText.Substring(53)
            End If
        End If
        Text = pText
        OperatedBy = ""
        Stopovers = ""
        ArriveTerminal = ""
        DepartTerminal = ""
        EstimatedFlyingTime = ""
        CO2 = New List(Of CO2Item)
        AnalyseSegDo1A(SegDo)
        ConnectTimeFromPrevious = pConnectTimeFromPrevious
        SurfaceSegment = False
        ClassOfServiceDescription = ReadClassOfService(Airline, Origin.AirportCode, Destination.AirportCode, ClassOfService)
    End Sub
    Private Sub AnalyseSegDo1A(ByVal SegDo As String)

        Dim pSegDo() As String = SegDo.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)

        Dim pItinStarts As Integer = -1
        For i As Integer = 0 To pSegDo.GetUpperBound(0) - 1
            If pSegDo(i).IndexOf("*1A PLANNED FLIGHT INFO*") >= 0 And pSegDo(i + 1).IndexOf("APT") >= 0 Then
                pItinStarts = i + 2
                Exit For
            End If
        Next
        Dim pBoardStarts As Integer = -1
        If pItinStarts >= 0 Then
            For i As Integer = pItinStarts To pSegDo.GetUpperBound(0)
                If pSegDo(i).Length > 3 AndAlso pSegDo(i).Substring(0, 3) = Origin.AirportCode Then
                    pBoardStarts = i
                    If pSegDo(i).Length >= 44 Then
                        _Equipment = pSegDo(i).Substring(42, 3).Trim.PadRight(3)
                        ' TODO -Find And Decode Meal Codes also from SSR
                    End If
                    Exit For
                End If
            Next
        End If
        Dim pOffStarts As Integer = -1
        If pBoardStarts >= 0 Then
            For i As Integer = pBoardStarts + 1 To pSegDo.GetUpperBound(0)
                If pSegDo(i).Length > 3 AndAlso pSegDo(i).Substring(0, 3) = Destination.AirportCode Then
                    pOffStarts = i
                    Exit For
                End If
                If pSegDo(i).Length > 3 AndAlso pSegDo(i).Substring(0, 3) <> "   " Then
                    If _Stopovers <> "" Then
                        _Stopovers &= vbCrLf
                    End If
                    _Stopovers &= pSegDo(i).Substring(0, 3) & "-" & Airport.CityAirportName(pSegDo(i).Substring(0, 3))
                End If
            Next
        End If
        If pOffStarts >= 0 Then
            If pSegDo(pOffStarts).Length > 63 Then
                _EstimatedFlyingTime = pSegDo(pOffStarts).Substring(pSegDo(pOffStarts).LastIndexOf(" ")).Trim.PadLeft(5)
            Else
                _EstimatedFlyingTime = ""
            End If
            For i As Integer = pOffStarts To pSegDo.GetUpperBound(0)
                If pSegDo(i).Length > 16 AndAlso pSegDo(i).Substring(3, 3) = Origin.AirportCode AndAlso pSegDo(i).IndexOf("- DEPARTS") > 0 Then
                    _DepartTerminal = pSegDo(i).Substring(pSegDo(i).IndexOf("- DEPARTS") + 2)
                    _DepartTerminalShort = DepartTerminal.Replace("DEPARTS TERMINAL ", "").Trim
                    If DepartTerminalShort = "" Then
                        _DepartTerminalShort = "."
                    ElseIf pSegDo(i).Length > 16 AndAlso pSegDo(i).Substring(7, 3) = Destination.AirportCode AndAlso pSegDo(i).IndexOf("- ARRIVES") > 0 Then
                        _ArriveTerminal = pSegDo(i).Substring(pSegDo(i).IndexOf("- ARRIVES") + 2)
                        _ArriveTerminalShort = ArriveTerminal.Replace("ARRIVES TERMINAL ", "").Trim
                        If ArriveTerminalShort = "" Then
                            _ArriveTerminalShort = "."
                        End If
                    ElseIf pSegDo(i).Length > 22 AndAlso pSegDo(i).Substring(15, 8) = " CO2/PAX" Then
                        Dim pCO2Item As New CO2Item
                        pCO2Item.SetValue(pSegDo(i))
                        If Not CO2.Contains(pCO2Item) Then
                            CO2.Add(pCO2Item)
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub AnalyzeSVC1G(ByVal pSVC() As String)
        '
        ' *SVC for specific FF entry
        ' 
        _Stopovers = ""
        _ArriveTerminal = ""
        _DepartTerminal = ""
        _ArriveTerminalShort = ""
        _DepartTerminalShort = ""
        _EstimatedFlyingTime = ""
        _Equipment = "   "
        _MealFlight = ""
        _MealSSR = ""

        Dim pSeg As Integer = 0
        Dim pOffPoint As String = ""
        Dim pFlyingTime As Date = TimeSerial(0, 0, 0)
        For iSVC As Integer = 0 To pSVC.GetUpperBound(0)
            If pSVC(iSVC).Substring(2, 1) = " " AndAlso (IsNumeric(pSVC(iSVC).Substring(0, 2)) Or IsNumeric(pSVC(iSVC).Substring(1, 1))) Then
                If pSeg > 0 Then
                    ' add new entry to tickets
                    pSeg = 0
                    _EstimatedFlyingTime = ""
                    _DepartTerminal = ""
                    _ArriveTerminal = ""
                End If

                pSeg = CInt(pSVC(iSVC).Trim.Substring(0, pSVC(iSVC).Trim.IndexOf(" ")))
                _EstimatedFlyingTime = pSVC(iSVC).Trim.Substring(pSVC(iSVC).Trim.LastIndexOf(" ") + 1).PadLeft(5, "0"c)
                pOffPoint = pSVC(iSVC).Substring(17, 3)
                pFlyingTime = TimeSerial(CInt(EstimatedFlyingTime.Substring(0, EstimatedFlyingTime.IndexOf(":"))), CInt(EstimatedFlyingTime.Substring(EstimatedFlyingTime.IndexOf(":") + 1, 2)), 0)
                _Equipment = pSVC(iSVC).Substring(21, 5).Trim
                ' TODO -Find Equipment Code And Meal Code And dcecode meal - Also From SSR
            ElseIf pSVC(iSVC).Length > 14 AndAlso pSVC(iSVC).Substring(3, 5) = " CO2 " AndAlso pSVC(iSVC).Substring(7, 7) <> " TOTAL " Then
                Dim pCO2Item As New CO2Item
                pCO2Item.SetValue(pSVC(iSVC))
                If Not CO2.Contains(pCO2Item) Then
                    CO2.Add(pCO2Item)
                End If
            ElseIf pSeg > 0 Then
                If pSVC(iSVC).Length > 20 AndAlso (pSVC(iSVC).StartsWith(Space(14)) And pSVC(iSVC).Substring(14, 6).Replace(" ", "").Length = 6 And pSVC(iSVC).Substring(20, 1) = Space(1)) Then
                    If Stopovers <> "" Then
                        _Stopovers &= vbCrLf
                    End If
                    _Stopovers &= pOffPoint & "-" & Airport.CityAirportName(pOffPoint)
                    pOffPoint = pSVC(iSVC).Substring(17, 3)
                    If pSVC(iSVC).Trim.LastIndexOf(" ") > -1 Then
                        Dim pTime As String = pSVC(iSVC).Trim.Substring(pSVC(iSVC).Trim.LastIndexOf(" ") + 1).PadLeft(5, "0"c)
                        If pTime.IndexOf(":") > 0 Then
                            pFlyingTime = DateAdd(DateInterval.Hour, CDbl(pTime.Substring(0, pTime.IndexOf(":"))), pFlyingTime)
                            pFlyingTime = DateAdd(DateInterval.Minute, CDbl(pTime.Substring(pTime.IndexOf(":") + 1, 2)), pFlyingTime)
                            _EstimatedFlyingTime = Format(pFlyingTime, "HH:mm")
                        End If
                    End If
                End If
                    If pSVC(iSVC).IndexOf("DEPARTS") > 0 Or pSVC(iSVC).IndexOf("ARRIVES") > 0 Then
                    Dim pTerm() As String = pSVC(iSVC).Split({"-"}, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To pTerm.GetUpperBound(0)
                        Dim pElem() As String = pTerm(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                        For j = 0 To pElem.GetUpperBound(0) - 1
                            If pElem(j) = "TERMINAL" Then
                                If pElem(0) = "DEPARTS" Then
                                    _DepartTerminal = pTerm(i).Trim
                                    _DepartTerminalShort = pElem(j + 1).Trim
                                ElseIf pElem(0) = "ARRIVES" Then
                                    _ArriveTerminal = pTerm(i).Trim
                                    _ArriveTerminalShort = pElem(j + 1).Trim
                                End If
                            End If
                        Next
                    Next
                End If
            ElseIf pSVC(iSVC).Substring(0, 1) <> " " Then
                Exit For
            End If
        Next
    End Sub
End Class