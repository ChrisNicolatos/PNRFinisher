Option Strict On
Option Explicit On
Public Class CO2Item
    ' Amadeus
    ' 4.ATH FRA   -  CO2/PAX* 155.40 KG ECO, 155.40 KG PRE                           
    ' Galileo
    '    CO2 ATHFCO ECONOMY     185.58 KG PREMIUM     185.58 KG     
    Public ReadOnly Property Routing As String
    Public ReadOnly Property Economy As Decimal
    Public ReadOnly Property Premium As Decimal
    Public ReadOnly Property Text As String
    Public Sub New(ByVal pText As String)
        Text = pText
        If pText.Length > 14 AndAlso pText.Substring(3, 5) = " CO2 " AndAlso pText.Substring(7, 7) <> " TOTAL " Then
            ' Galileo
            Routing = pText.Substring(8, 3) & " " & pText.Substring(11, 3)
            Economy = CDec(pText.Substring(22, 11).Replace(",", "").Replace(".", ","))
            Premium = CDec(pText.Substring(44, 11).Replace(",", "").Replace(".", ","))
        ElseIf pText.Length > 22 AndAlso pText.Substring(15, 8) = " CO2/PAX" Then
            ' Amadeus
            Dim pItems() As String = pText.Substring(24).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Routing = pText.Substring(3, 7)
            If pItems.GetUpperBound(0) = 5 Then
                Economy = CDec(pItems(0).Replace(",", "").Replace(".", ","))
                Premium = CDec(pItems(3).Replace(",", "").Replace(".", ","))
            Else
                Economy = 0
                Premium = 0
            End If
        End If
    End Sub

End Class
