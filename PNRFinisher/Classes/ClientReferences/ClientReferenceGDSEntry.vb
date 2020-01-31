Option Strict On
Option Explicit On
Public Class ClientReferenceGDSEntry
    Public ReadOnly Property BackOffice As EnumBOCode
    Public ReadOnly Property ID As String = ""
    Public ReadOnly Property Amadeus As String = ""
    Public ReadOnly Property Galileo As String = ""
    Public ReadOnly Property IsVessel As Boolean
    Public ReadOnly Property IsBookedBy As Boolean
    Public ReadOnly Property IsCostCentre As Boolean

    Public Sub New(ByVal BackOffice As EnumBOCode, ByVal Id As String, ByVal Amadeus As String, ByVal Galileo As String, ByVal IsVessel As Boolean, ByVal IsBookedBy As Boolean, ByVal IsCostCentre As Boolean)
        Me.BackOffice = BackOffice
        Me.ID = Id
        Me.Amadeus = Amadeus
        Me.Galileo = Galileo
        Me.IsVessel = IsVessel
        Me.IsBookedBy = IsBookedBy
        Me.IsCostCentre = IsCostCentre
    End Sub
End Class
