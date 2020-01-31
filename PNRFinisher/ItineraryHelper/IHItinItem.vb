Option Strict On
Option Explicit On
Public Class IHItinItem
    Private Structure ClassProps
        Dim Level As Integer
        Dim Routing As String
        Dim TicketingAirline As String
        Dim Ticket As String
        Dim Client As String
        Dim PNR As String
        Dim PassengerName As String
        Dim TotalFarePlusTaxes As Double
        Dim Pax As Integer
        Dim NumTickets As Integer
    End Structure
    Private mudtProps As ClassProps
    Public ReadOnly Property Routing As String
        Get
            Return mudtProps.Routing
        End Get
    End Property
    Public ReadOnly Property TicketingAirline As String
        Get
            Return mudtProps.TicketingAirline
        End Get
    End Property
    Public ReadOnly Property Ticket As String
        Get
            Return mudtProps.Ticket
        End Get
    End Property
    Public ReadOnly Property Client As String
        Get
            Return mudtProps.Client
        End Get
    End Property
    Public ReadOnly Property PNR As String
        Get
            Return mudtProps.PNR
        End Get
    End Property
    Public ReadOnly Property PassengerName As String
        Get
            Return mudtProps.PassengerName
        End Get
    End Property
    Public ReadOnly Property TotalFarePlusTaxes As Double
        Get
            Return mudtProps.TotalFarePlusTaxes
        End Get
    End Property
    Public ReadOnly Property Pax As Integer
        Get
            Return mudtProps.Pax
        End Get
    End Property
    Public ReadOnly Property NumTickets As Integer
        Get
            Return mudtProps.NumTickets
        End Get
    End Property
    Public ReadOnly Property Key As String
        Get
            Dim pKey As String = Routing
            If PassengerName <> "" Then
                pKey = PassengerName
            ElseIf PNR <> "" Then
                pKey = PNR
            ElseIf Client <> "" Then
                pKey = Client
            ElseIf Ticket <> "" Then
                pKey = Ticket
            ElseIf TicketingAirline <> "" Then
                pKey = TicketingAirline
            End If
            Return pKey
        End Get
    End Property
    Public ReadOnly Property Value(ByVal MaxLen As Integer) As String
        Get
            Return Key.PadRight(MaxLen, "."c) & " ( " & Format(TotalFarePlusTaxes, "#,##0").PadLeft(7) & " EUR / " & Format(Pax, "#,##0").PadLeft(7) & " Pax / " & Format(NumTickets, "#,##0").PadLeft(7) & " Tkts )"
        End Get
    End Property
    Public ReadOnly Property Level As Integer
        Get
            Return mudtProps.Level
        End Get
    End Property
    Public Sub SetValues(ByVal pRouting As String, ByVal pTicket As String, ByVal pClient As String, ByVal pPNR As String _
                         , ByVal pPassengerName As String, ByVal pTotalFarePlusTaxes As Double, ByVal pPax As Integer, ByVal pNumTickets As Integer)
        With mudtProps
            .Routing = pRouting
            .TicketingAirline = ""
            Dim i As Integer = pTicket.IndexOf("(")
            Do While i > 1
                .TicketingAirline &= pTicket.Substring(i - 2, 2) & " "
                i = pTicket.IndexOf("(", i + 1)
            Loop
            .TicketingAirline = .TicketingAirline.Trim
            .Ticket = pTicket
            .Client = pClient
            .PNR = pPNR
            .PassengerName = pPassengerName
            .TotalFarePlusTaxes = pTotalFarePlusTaxes
            .Pax = pPax
            .NumTickets = pNumTickets
            .Level = 0
            If PassengerName <> "" Then
                .Level = 5
            ElseIf PNR <> "" Then
                .Level = 4
            ElseIf Client <> "" Then
                .Level = 3
            ElseIf Ticket <> "" Then
                .Level = 2
            ElseIf Routing <> "" Then
                .Level = 1
            End If
        End With
    End Sub
End Class
