Option Strict On
Option Explicit On
Public Class GDSItineraryRemarksItem
    Public ReadOnly Property ElementNo As Integer = 0
    Public ReadOnly Property FreeFlow As String = ""
    Public ReadOnly Property PassengerType As String = ""
    Public ReadOnly Property Text As String = ""
    Public ReadOnly Property Association As GDSAssociationsCollection
    Public Sub New(ByVal pItem As s1aPNR.ItineraryRemarkElement)
        ElementNo = pItem.ElementNo
        FreeFlow = IsNothingToString(pItem.FreeFlow)
        PassengerType = IsNothingToString(pItem.PassengerType)
        Text = IsNothingToString(pItem.Text)
        Association = New GDSAssociationsCollection
        Association.LoadAssociations(pItem)
    End Sub
    Public Sub New(ByVal pRI As String)
        If pRI.IndexOf(".") > 0 Then
            If pRI.IndexOf(".") < pRI.Length - 1 AndAlso IsNumeric(pRI.Substring(0, pRI.IndexOf("."))) Then
                ElementNo = CInt(pRI.Substring(0, pRI.IndexOf(".")))
                FreeFlow = pRI.Substring(pRI.IndexOf(".") + 1)
                Text = pRI
                PassengerType = ""
                Association = New GDSAssociationsCollection
            End If
        End If
    End Sub
End Class
