Option Strict On
Option Explicit On
Public Class AirlineNotesItem
    Private Structure ClassProps
        Dim ID As Integer
        Dim AirlineCode As String
        Dim FlightType As String
        Dim Seaman As Boolean
        Dim SeqNo As Integer
        Dim GDSElement As String
        Dim GDSText As String
        Dim GDSEntry As String
    End Structure
    Private mudtProps As ClassProps

    Public ReadOnly Property ID() As Integer
        Get
            Return mudtProps.ID
        End Get
    End Property
    Public ReadOnly Property AirlineCode() As String
        Get
            Return mudtProps.AirlineCode
        End Get
    End Property
    Public ReadOnly Property FlightType() As String
        Get
            Return mudtProps.FlightType
        End Get
    End Property
    Public ReadOnly Property Seaman() As Boolean
        Get
            Return mudtProps.Seaman
        End Get
    End Property
    Public ReadOnly Property SeqNo() As Integer
        Get
            Return mudtProps.SeqNo
        End Get
    End Property
    Public ReadOnly Property GDSElement() As String
        Get
            Return mudtProps.GDSElement
        End Get
    End Property
    Public ReadOnly Property GDSText() As String
        Get
            Return mudtProps.GDSText
        End Get
    End Property
    Public ReadOnly Property GDSEntry As String
        Get
            Return mudtProps.GDSEntry
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return mudtProps.GDSText
    End Function
    Friend Sub SetValues(ByVal pID As Integer, ByVal pAirlineCode As String, ByVal pFlightType As String, ByVal pSeaman As Boolean,
                         ByVal pSeqNo As Integer, ByVal pGDSElement As String, ByVal pGDSText As String, ByVal pGDSEntry As String)
        With mudtProps
            .ID = pID
            .AirlineCode = pAirlineCode
            .FlightType = pFlightType
            .Seaman = pSeaman
            .SeqNo = pSeqNo
            .GDSElement = pGDSElement
            .GDSText = pGDSText
            .GDSEntry = pGDSEntry
        End With
    End Sub
End Class
