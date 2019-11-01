Option Strict On
Option Explicit On
Public Class FrequentFlyerCollection
    Inherits Collections.ObjectModel.Collection(Of FrequentFlyerItem)
    Public Sub New()
        MyBase.New
    End Sub
    Friend Sub AddItem(ByVal pPaxName As String, ByVal pAirline As String, ByVal pFrequentTravelerNo As String, ByVal pCrossAccrual As String)
        Dim pobjClass As FrequentFlyerItem

        pobjClass = New FrequentFlyerItem(pPaxName, pAirline, pFrequentTravelerNo, pCrossAccrual)
        If Not MyBase.Contains(pobjClass) Then
            MyBase.Add(pobjClass)
        End If

    End Sub
End Class
