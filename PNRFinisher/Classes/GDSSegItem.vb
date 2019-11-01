Option Strict On
Option Explicit On
Public Class GDSSegItem

    Public Event Valid(ByRef Status As Boolean)
    Private mobjAirlineDate As New s1aAirlineDate.clsAirlineDate
    Public Sub New()
        ElementNo = 0
        Airline = ""
        AirlineName = ""
        FlightNo = ""
        ClassOfService = ""
        DepartureDate = Date.MinValue
        DepartureDateIATA = ""
        ArrivalDate = Date.MinValue
        ArrivalDateIATA = ""
        BoardAirportShortName = ""
        BoardCountryName = ""
        BoardCountryCode = ""
        OffPoint = ""
        OffPointAirportName = ""
        OffPointCityName = ""
        OffPointAirportShortName = ""
        OffPointCountryName = ""
        OffPointCountryCode = ""
        DepartTime = Date.MinValue
        ArriveTime = Date.MinValue
        EstimatedFlyingTime = ""
        AirlineLocator = ""
        Text = ""
        OperatedBy = ""
        Stopovers = ""
        DepartTerminal = ""
        ArriveTerminal = ""
        Status = ""
        Equipment = ""
        MealFlight = ""
        MealSSR = ""
        ConnectTimeFromPrevious = ""
        SurfaceSegment = False
        CO2 = New Collections.Generic.List(Of CO2Item)
    End Sub
    Public ReadOnly Property ElementNo As Integer = 0
    Public ReadOnly Property Airline As String = ""
    Public ReadOnly Property AirlineName As String = ""
    Public ReadOnly Property FlightNo As String = ""
    Public ReadOnly Property DepartTime As Date = Date.MinValue
    Public ReadOnly Property ArriveTime As Date = Date.MinValue
    Public ReadOnly Property AirlineLocator As String = ""
    Public ReadOnly Property Text As String = ""

    Public ReadOnly Property BoardPoint As String = ""
    Public ReadOnly Property BoardAirportName As String = ""
    Public ReadOnly Property BoardCityName As String = ""
    Public ReadOnly Property BoardAirportShortName As String = ""
    Public ReadOnly Property BoardCountryName As String = ""
    Public ReadOnly Property BoardCountryCode As String = ""

    Public ReadOnly Property OffPoint As String = ""
    Public ReadOnly Property OffPointAirportName As String = ""
    Public ReadOnly Property OffPointCityName As String = ""
    Public ReadOnly Property OffPointAirportShortName As String
    Public ReadOnly Property OffPointCountryName As String = ""
    Public ReadOnly Property OffPointCountryCode As String = ""
    Public ReadOnly Property Status As String = ""
    Public ReadOnly Property ClassOfService As String = ""
    Public ReadOnly Property DepartureDate As Date = Date.MinValue
    Public ReadOnly Property DepartureDateIATA As String = ""
    Public ReadOnly Property ArrivalDate As Date = Date.MinValue
    Public ReadOnly Property ArrivalDateIATA As String = ""
    Public ReadOnly Property Equipment As String = ""
    Public ReadOnly Property MealFlight As String = ""
    Public ReadOnly Property MealSSR As String = ""
    Public ReadOnly Property EstimatedFlyingTime As String = ""
    Public ReadOnly Property Stopovers As String = ""
    Public ReadOnly Property ArriveTerminal As String = ""
    Public ReadOnly Property DepartTerminal As String = ""
    Public ReadOnly Property ArriveTerminalShort As String = "."
    Public ReadOnly Property DepartTerminalShort As String = "."
    Public ReadOnly Property OperatedBy As String = ""

    Public ReadOnly Property ConnectTimeFromPrevious As String = ""
    Public ReadOnly Property SurfaceSegment As Boolean = False
    Public ReadOnly Property CO2 As Collections.Generic.List(Of CO2Item) = New List(Of CO2Item)
    Public ReadOnly Property ClassOfServiceDescription As ClassOfServiceItem
    Public ReadOnly Property DepartureDay As String
        Get
            Return WeekDaySeg(DepartureDate)
        End Get
    End Property
    Public ReadOnly Property ArrivalDay As String
        Get
            Return WeekDaySeg(ArrivalDate)
        End Get
    End Property
    Public ReadOnly Property DepartTimeShort As String
        Get
            Return Format(DepartTime, "HHmm")
        End Get
    End Property
    Public ReadOnly Property DepartTimeShort(ByVal Separator As String) As String
        Get
            Return Format(DepartTime, "HH") & Separator & Format(DepartTime, "mm")
        End Get
    End Property
    Public ReadOnly Property ArriveTimeShort As String
        Get
            Return Format(ArriveTime, "HHmm")
        End Get
    End Property
    Public ReadOnly Property ArriveTimeShort(ByVal Separator As String) As String
        Get
            Return Format(ArriveTime, "HH") & Separator & Format(ArriveTime, "mm")
        End Get
    End Property
    ''' <summary>
    ''' Surface Segment
    ''' </summary>
    ''' <param name="pElementNo"></param>
    Friend Sub New(ByVal pElementNo As Integer)
        ElementNo = pElementNo
        SurfaceSegment = True
    End Sub
    Friend Sub New(ByVal pAirline As String _
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
        SurfaceSegment = False
        ElementNo = pElementNo
        Airline = pAirline
        AirlineName = Airlines.AirlineName(Airline)
        FlightNo = pFlightNo
        ClassOfService = pClass
        DepartureDate = pDepartureDate
        ArrivalDate = pArrivalDate
        BoardPoint = pBoardPoint
        BoardAirportName = Airport.CityAirportName(BoardPoint)
        BoardCityName = Airport.CityName(BoardPoint)
        BoardAirportShortName = Airport.AirportShortname(BoardPoint)
        If BoardAirportShortName = "" Then
            BoardAirportShortName = BoardCityName.Trim
        End If

        BoardCountryName = Airport.CountryName(BoardPoint)
        BoardCountryCode = Airport.CountryCode(BoardPoint)
        OffPoint = pOffPoint
        OffPointAirportName = Airport.CityAirportName(OffPoint)
        OffPointCityName = Airport.CityName(OffPoint)
        OffPointAirportShortName = Airport.AirportShortname(OffPoint)
        If OffPointAirportShortName = "" Then
            OffPointAirportShortName = OffPointCityName.Trim
        End If
        OffPointCountryName = Airport.CountryName(OffPoint)
        OffPointCountryCode = Airport.CountryCode(OffPoint)
        Status = pStatus
        DepartTime = pDepartTime
        ArriveTime = pArriveTime
        Equipment = pEquipment
        MealFlight = pMealFlight
        MealSSR = pMealSSR
        AirlineLocator = ""
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
        OperatedBy = OperatedByBuilder(pOperatedBy)

        Try
            mobjAirlineDate.IgnoreAmadeusRange = True
            mobjAirlineDate.VBDate = DepartureDate
        Catch ex As Exception
            mobjAirlineDate.VBDate = DateAdd(DateInterval.Year, -1, DepartureDate)
        End Try
        DepartureDateIATA = mobjAirlineDate.IATA

        Try
            mobjAirlineDate.IgnoreAmadeusRange = True
            mobjAirlineDate.VBDate = ArrivalDate
        Catch ex As Exception
            mobjAirlineDate.VBDate = DateAdd(DateInterval.Year, -1, ArrivalDate)
        End Try
        ArrivalDateIATA = mobjAirlineDate.IATA
        AnalyzeSVC1G(SVC)
        ConnectTimeFromPrevious = pConnectTimeFromPrevious
        ClassOfServiceDescription = ReadClassOfService(Airline, BoardPoint, OffPoint, ClassOfService)
    End Sub
    Private Function OperatedByBuilder(ByVal pOperatedBy As String) As String
        Dim pResult As String = pOperatedBy
        If pResult = "" Then
            For i = 81 To Text.Length Step 80
                If (Text & StrDup(80, " ")).Substring(i, 80).IndexOf("OPERATED BY") >= 0 Then
                    If pResult <> "" Then
                        pResult &= vbCrLf
                    End If
                    pResult &= (Text.Trim & StrDup(80, " ")).Substring(i, 80)
                End If
            Next
        End If
        Return pResult
    End Function
    Friend Sub New(ByVal pAirline As String _
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
        SurfaceSegment = False
        ElementNo = pElementNo
        Airline = pAirline
        AirlineName = Airlines.AirlineName(Airline)
        FlightNo = pFlightNo
        ClassOfService = pClass
        DepartureDate = pDepartureDate
        ArrivalDate = pArrivalDate
        BoardPoint = pBoardPoint
        BoardAirportName = Airport.CityAirportName(BoardPoint)
        BoardCityName = Airport.CityName(BoardPoint)
        BoardAirportShortName = Airport.AirportShortname(BoardPoint)
        If BoardAirportShortName = "" Then
            BoardAirportShortName = BoardCityName.Trim
        End If
        BoardCountryName = Airport.CountryName(BoardPoint)
        BoardCountryCode = Airport.CountryCode(BoardPoint)

        OffPoint = pOffPoint
        OffPointAirportName = Airport.CityAirportName(OffPoint)
        OffPointCityName = Airport.CityName(OffPoint)
        OffPointAirportShortName = Airport.AirportShortname(OffPoint)
        If OffPointAirportShortName = "" Then
            OffPointAirportShortName = OffPointCityName.Trim
        End If
        OffPointCountryName = Airport.CountryName(OffPoint)
        OffPointCountryCode = Airport.CountryCode(OffPoint)

        Status = pStatus
        DepartTime = pDepartTime
        ArriveTime = pArriveTime
        Equipment = pEquipment
        MealFlight = pMealFlight
        MealSSR = pMealSSR
        If pText.Length > 63 Then
            AirlineLocator = pText.Substring(53, 10).Trim
        ElseIf pText.Length > 53 Then
            AirlineLocator = pText.Substring(53).Trim
        Else
            AirlineLocator = ""
        End If
        Text = pText
        OperatedBy = OperatedByBuilder("")
        Try
            mobjAirlineDate.IgnoreAmadeusRange = True
            mobjAirlineDate.VBDate = DepartureDate
        Catch ex As Exception
            mobjAirlineDate.VBDate = DateAdd(DateInterval.Year, -1, DepartureDate)
        End Try
        DepartureDateIATA = mobjAirlineDate.IATA

        Try
            mobjAirlineDate.IgnoreAmadeusRange = True
            mobjAirlineDate.VBDate = ArrivalDate
        Catch ex As Exception
            mobjAirlineDate.VBDate = DateAdd(DateInterval.Year, -1, ArrivalDate)
        End Try
        ArrivalDateIATA = mobjAirlineDate.IATA
        AnalyseSegDo1A(SegDo)
        ConnectTimeFromPrevious = pConnectTimeFromPrevious
        ClassOfServiceDescription = ReadClassOfService(Airline, BoardPoint, OffPoint, ClassOfService)
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
                If pSegDo(i).Length > 3 AndAlso pSegDo(i).Substring(0, 3) = BoardPoint Then
                    pBoardStarts = i
                    If pSegDo(i).Length >= 44 Then
                        _Equipment = pSegDo(i).Substring(42, 3)
                        ' TODO -Find And Decode Meal Codes also from SSR
                    End If
                    Exit For
                End If
            Next
        End If
        Dim pOffStarts As Integer = -1
        If pBoardStarts >= 0 Then
            For i As Integer = pBoardStarts + 1 To pSegDo.GetUpperBound(0)
                If pSegDo(i).Length > 3 AndAlso pSegDo(i).Substring(0, 3) = OffPoint Then
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
                If pSegDo(i).Length > 16 AndAlso pSegDo(i).Substring(3, 3) = BoardPoint AndAlso pSegDo(i).IndexOf("- DEPARTS") > 0 Then
                    _DepartTerminal = pSegDo(i).Substring(pSegDo(i).IndexOf("- DEPARTS") + 2)
                    _DepartTerminalShort = _DepartTerminal.Replace("DEPARTS TERMINAL ", "").Trim
                ElseIf pSegDo(i).Length > 16 AndAlso pSegDo(i).Substring(7, 3) = OffPoint AndAlso pSegDo(i).IndexOf("- ARRIVES") > 0 Then
                    _ArriveTerminal = pSegDo(i).Substring(pSegDo(i).IndexOf("- ARRIVES") + 2)
                    _ArriveTerminalShort = _ArriveTerminal.Replace("ARRIVES TERMINAL ", "").Trim
                ElseIf pSegDo(i).Length > 22 AndAlso pSegDo(i).Substring(15, 8) = " CO2/PAX" Then
                    Dim pCO2Item As New CO2Item(pSegDo(i))
                    If Not _CO2.Contains(pCO2Item) Then
                        _CO2.Add(pCO2Item)
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
        _ArriveTerminalShort = "."
        _DepartTerminalShort = "."
        _EstimatedFlyingTime = ""
        _Equipment = ""
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
                Dim pCO2Item As New CO2Item(pSVC(iSVC))
                If Not _CO2.Contains(pCO2Item) Then
                    _CO2.Add(pCO2Item)
                End If
            ElseIf pSeg > 0 Then
                If pSVC(iSVC).StartsWith(Space(14)) AndAlso pSVC(iSVC).Length > 20 AndAlso pSVC(iSVC).Substring(14, 6).Replace(" ", "").Length = 6 AndAlso pSVC(iSVC).Substring(20, 1) = Space(1) Then
                    If _Stopovers <> "" Then
                        _Stopovers &= vbCrLf
                    End If
                    _Stopovers &= pOffPoint & "-" & Airport.CityAirportName(pOffPoint)
                    pOffPoint = pSVC(iSVC).Substring(17, 3)
                    Dim pTime As String = pSVC(iSVC).Trim.Substring(pSVC(iSVC).Trim.LastIndexOf(" ") + 1).PadLeft(5, "0"c)
                    pFlyingTime = DateAdd(DateInterval.Hour, CDbl(pTime.Substring(0, pTime.IndexOf(":"))), pFlyingTime)
                    pFlyingTime = DateAdd(DateInterval.Minute, CDbl(pTime.Substring(pTime.IndexOf(":") + 1, 2)), pFlyingTime)
                    _EstimatedFlyingTime = Format(pFlyingTime, "HH:mm")
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