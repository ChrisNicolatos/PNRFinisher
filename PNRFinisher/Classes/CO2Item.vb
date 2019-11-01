Option Strict On
Option Explicit On
Public Class CO2Item
    ' Amadeus
    ' 4.ATH FRA   -  CO2/PAX* 155.40 KG ECO, 155.40 KG PRE                           
    ' Galileo
    '    CO2 ATHFCO ECONOMY     185.58 KG PREMIUM     185.58 KG     
    Private Structure ClassProps
        Dim Routing As String
        Dim Economy As Decimal
        Dim Premium As Decimal
        Dim Text As String
    End Structure
    Private mudtProps As ClassProps
    Public ReadOnly Property Routing As String
        Get
            Return mudtProps.Routing
        End Get
    End Property
    Public ReadOnly Property Economy As Decimal
        Get
            Return mudtProps.Economy
        End Get
    End Property
    Public ReadOnly Property Premium As Decimal
        Get
            Return mudtProps.Premium
        End Get
    End Property
    Public ReadOnly Property Text As String
        Get
            Return mudtProps.Text
        End Get
    End Property
    Public Sub SetValue(ByVal pText As String)
        With mudtProps
            .Text = pText
            If pText.Length > 14 AndAlso pText.Substring(3, 5) = " CO2 " AndAlso pText.Substring(7, 7) <> " TOTAL " Then
                ' Galileo
                .Routing = pText.Substring(8, 3) & " " & pText.Substring(11, 3)
                .Economy = CDec(pText.Substring(22, 11).Replace(",", "").Replace(".", ","))
                .Premium = CDec(pText.Substring(44, 11).Replace(",", "").Replace(".", ","))
            ElseIf pText.Length > 22 AndAlso ptext.Substring(15, 8) = " CO2/PAX" Then
                ' Amadeus
                Dim pItems() As String = pText.Substring(24).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                .Routing = pText.Substring(3, 7)
                If pItems.GetUpperBound(0) = 5 Then
                    .Economy = CDec(pItems(0).Replace(",", "").Replace(".", ","))
                    .Premium = CDec(pItems(3).Replace(",", "").Replace(".", ","))
                Else
                    .Economy = 0
                    .Premium = 0
                End If
            End If
        End With
    End Sub

End Class
