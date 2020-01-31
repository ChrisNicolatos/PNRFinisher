Option Strict On
Option Explicit On
Public Class GDSSegCollection
    Inherits Collections.Generic.Dictionary(Of Integer, GDSSegItem)

    Private mMaxAirportNameLength As Integer = 15
    Private mMaxCityNameLength As Integer = 15
    Private mAirlineAlert As String = ""
    Private mAirlineAlerts As AlertsCollection
    Private mAmadeusQueue As String
    Private mGalileoQueue As String

    Public Overloads Sub Clear()
        MyBase.Clear()
        mMaxAirportNameLength = 15
        mMaxCityNameLength = 15
        mAirlineAlert = ""
        mAirlineAlerts = New AlertsCollection()
        mAmadeusQueue = ""
        mGalileoQueue = ""
    End Sub
    Public Sub AddItem(ByVal pAirline As String, ByVal pBoardPoint As String, ByVal pClass As String, ByVal pDepartureDate As Date, ByVal pArrivalDate As Date, ByVal pElementNo As Integer, ByVal pFlightNo As String, ByVal pOffPoint As String, ByVal pStatus As String, ByVal pDepartTime As Date, ByVal pArriveTime As Date, ByVal pEquipment As String, ByVal pMealFlight As String, ByVal pMealSSR As String, ByVal pText As String, ByVal SegDo As String, ByVal pConnectTimeFromPrevious As String)
        ' For Amadeus
        Dim pobjClass As GDSSegItem

        pobjClass = New GDSSegItem(pAirline, pBoardPoint, pClass, pDepartureDate, pArrivalDate, pElementNo, pFlightNo, pOffPoint, pStatus, pDepartTime, pArriveTime, pEquipment, pMealFlight, pMealSSR, pText, SegDo, pConnectTimeFromPrevious)
        MyBase.Add(pElementNo, pobjClass)
        MyBase.First()
        SetItinValues(pobjClass)

    End Sub
    Public Function AddSurfaceSegment(ByVal pElementNo As Integer) As GDSSegItem
        Dim pobjClass As GDSSegItem
        pobjClass = New GDSSegItem(pElementNo)
        MyBase.Add(pElementNo, pobjClass)
        Return pobjClass
    End Function
    Public Function AddItem(ByVal pAirline As String, ByVal pBoardPoint As String, ByVal pClass As String, ByVal pDepartureDate As Date, ByVal pArrivalDate As Date, ByVal pElementNo As Integer, ByVal pFlightNo As String, ByVal pOffPoint As String, ByVal pStatus As String, ByVal pDepartTime As Date, ByVal pArriveTime As Date, ByVal pEquipment As String, ByVal pMealFlight As String, ByVal pMealSSR As String, ByVal pVL() As String, ByVal pText As String, ByVal pOperatedBy As String, ByVal SVC() As String, ByVal pConnectTimeFromPrevious As String) As GDSSegItem
        ' For Galileo
        Dim pobjClass As GDSSegItem

        pobjClass = New GDSSegItem(pAirline, pBoardPoint, pClass, pDepartureDate, pArrivalDate, pElementNo, pFlightNo, pOffPoint, pStatus, pDepartTime, pArriveTime, pEquipment, pMealFlight, pMealSSR, pVL, pText, pOperatedBy, SVC, pConnectTimeFromPrevious)
        MyBase.Add(pElementNo, pobjClass)

        SetItinValues(pobjClass)

        Return pobjClass

    End Function
    Private Sub SetItinValues(ByVal pobjClass As GDSSegItem)

        mMaxAirportNameLength = Math.Max(pobjClass.Origin.AirportName.Length, mMaxAirportNameLength)
        mMaxAirportNameLength = Math.Max(pobjClass.Destination.AirportName.Length, mMaxAirportNameLength)
        mMaxCityNameLength = Math.Max(pobjClass.Origin.CityName.Length, mMaxCityNameLength)
        mMaxCityNameLength = Math.Max(pobjClass.Destination.CityName.Length, mMaxCityNameLength)

        Dim pAirlineAlert As String = ""
        If mAirlineAlerts Is Nothing Then
            mAirlineAlerts = New AlertsCollection()
        End If
        pAirlineAlert = mAirlineAlerts.AirlineAlert(pobjClass.Airline)
        If pAirlineAlert <> "" And mAirlineAlert.IndexOf(pAirlineAlert) = -1 Then
            mAirlineAlert &= pAirlineAlert & vbCrLf
        End If
        mAmadeusQueue = mAirlineAlerts.AmadeusQueueForAirline(pobjClass.Airline)
        mGalileoQueue = mAirlineAlerts.GalileoQueueForAirline(pobjClass.Airline)

    End Sub
    Public ReadOnly Property MaxAirportNameLength As Integer
        Get
            Return mMaxAirportNameLength
        End Get
    End Property
    Public ReadOnly Property MaxCityNameLength As Integer
        Get
            Return mMaxCityNameLength
        End Get
    End Property
    Public ReadOnly Property MaxAirportShortNameLength As Integer = 15
    Public Property DepartureDate As Date = Date.MinValue
    Public ReadOnly Property SegmentsExist As Boolean
        Get
            Return (MyBase.Count > 0)
        End Get
    End Property
    Public ReadOnly Property Itinerary As String
        Get
            Dim pDate As New s1aAirlineDate.clsAirlineDate
            Dim PrevOff As String = ""
            Itinerary = ""
            For Each pSeg As GDSSegItem In MyBase.Values
                With pSeg
                    If Itinerary = "" Then
                        Itinerary = .Origin.AirportCode & "-" & .Destination.AirportCode
                    Else
                        If .Origin.AirportCode = PrevOff Then
                            Itinerary &= "-" & .Destination.AirportCode
                        Else
                            Itinerary &= "-***-" & .Origin.AirportCode & "-" & .Destination.AirportCode
                        End If
                    End If
                    PrevOff = .Destination.AirportCode
                    If DepartureDate = Date.MinValue Then
                        DepartureDate = .Departure.SegDate
                    End If
                End With
            Next

            If DepartureDate > Date.MinValue Then
                pDate.VBDate = DepartureDate
                Itinerary &= " (" & pDate.IATA & ")"
            End If
        End Get
    End Property
    Public ReadOnly Property FullItinerary As String
        Get
            Dim pItin As String = ""
            Dim pClasses As String = ""
            Dim pDates As String = ""
            Dim pFlights As String = ""
            Dim PrevOff As String = ""

            For Each Seg As GDSSegItem In MyBase.Values
                With Seg
                    If PrevOff = .Origin.AirportCode Then
                        pItin &= " " & .Airline & " " & .Destination.AirportCode
                    Else
                        If pItin <> "" Then
                            pItin &= " *** "
                        End If
                        pItin &= .Origin.AirportCode & " " & .Airline & " " & .Destination.AirportCode
                    End If
                    PrevOff = .Destination.AirportCode
                    pClasses &= .ClassOfService
                    pDates &= .Departure.DateIATA & " "
                    pFlights &= .Airline & .FlightNo & " "
                End With
            Next
            Return pItin.Trim & "|" & pClasses.Trim & "|" & pDates.Trim & "|" & pFlights.Trim
        End Get
    End Property
    Public ReadOnly Property AirlineAlert As String
        Get
            Return mAirlineAlert
        End Get
    End Property
    Public ReadOnly Property AmadeusQueue As String
        Get
            Return mAmadeusQueue
        End Get
    End Property
    Public ReadOnly Property GalileoQueue As String
        Get
            Return mGalileoQueue
        End Get
    End Property
End Class