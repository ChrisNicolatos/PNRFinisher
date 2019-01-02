Option Strict On
Option Explicit On
Public Class TQTItem
    Private Structure ClassProps
        Dim TQTElement As Integer
        Dim Segment As Integer
        Dim Itin As String
        Dim Allowance As String
        Dim Pax As String
        Dim Status As String
        Dim TicketNumber As String
    End Structure
    Private mudtProps As ClassProps
    Public Property TQTElement As Integer
        Get
            Return mudtProps.TQTElement
        End Get
        Set(value As Integer)
            mudtProps.TQTElement = value
        End Set
    End Property
    Public Property Segment As Integer
        Get
            Return mudtProps.Segment
        End Get
        Set(value As Integer)
            mudtProps.Segment = value
        End Set
    End Property
    Public Property Itin As String
        Get
            Return mudtProps.Itin
        End Get
        Set(value As String)
            mudtProps.Itin = value
        End Set
    End Property
    Public Property Allowance As String
        Get
            Return mudtProps.Allowance
        End Get
        Set(value As String)
            mudtProps.Allowance = value
        End Set
    End Property
    Public Property Pax As String
        Get
            Return mudtProps.Pax
        End Get
        Set(value As String)
            mudtProps.Pax = value
        End Set
    End Property
    Public Property Status As String
        Get
            Return mudtProps.Status
        End Get
        Set(value As String)
            mudtProps.Status = value
        End Set
    End Property
    Public Property TicketNumber As String
        Get
            Return mudtProps.TicketNumber
        End Get
        Set(value As String)
            mudtProps.TicketNumber = value
        End Set
    End Property
End Class
