Option Strict On
Option Explicit On
Public Class FrequentFlyerCollection
    Inherits Collections.Generic.List(Of FrequentFlyerItem)
    Friend Sub AddItem(ByVal pPaxName As String, ByVal pAirline As String, ByVal pFrequentTravelerNo As String, ByVal pCrossAccrual As String)
        Dim pobjClass As FrequentFlyerItem

        pobjClass = New FrequentFlyerItem
        pobjClass.SetValues(pPaxName, pAirline, pFrequentTravelerNo, pCrossAccrual)
        If Not MyBase.Contains(pobjClass) Then
            MyBase.Add(pobjClass)
        End If

    End Sub
End Class
