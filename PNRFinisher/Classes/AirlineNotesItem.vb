Option Strict On
Option Explicit On
Public Class AirlineNotesItem
    Public ReadOnly Property ID As Integer
    Public ReadOnly Property AirlineCode As String
    Public ReadOnly Property FlightType As String
    Public ReadOnly Property Seaman As Boolean
    Public ReadOnly Property SeqNo As Integer
    Public ReadOnly Property GDSElement As String
    Public ReadOnly Property GDSText As String
    Public ReadOnly Property GDSEntry As String
    Public Overrides Function ToString() As String
        Return GDSText
    End Function
    Public Sub New(ByVal pID As Integer, ByVal pAirlineCode As String, ByVal pFlightType As String, ByVal pSeaman As Boolean,
                         ByVal pSeqNo As Integer, ByVal pGDSElement As String, ByVal pGDSText As String, ByVal pGDSEntry As String)
        ID = pID
        AirlineCode = pAirlineCode
        FlightType = pFlightType
        Seaman = pSeaman
        SeqNo = pSeqNo
        GDSElement = pGDSElement
        GDSText = pGDSText
        GDSEntry = pGDSEntry
    End Sub
End Class
