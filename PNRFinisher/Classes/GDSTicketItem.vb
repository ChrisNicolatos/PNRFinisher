Option Strict On
Option Explicit On
Public Class GDSTicketItem

    Public ReadOnly Property DocType As EnumTicketDocType = EnumTicketDocType.NONE ' 1=ETKT 2= VCHR 3=Interoffice ticket
    Public ReadOnly Property TicketNumber As String = ""
    Public ReadOnly Property Document As Decimal = 0
    Public ReadOnly Property LastDocument As Decimal = 0
    Public ReadOnly Property Conjunction As String = ""
    Public ReadOnly Property Books As Integer = 0
    Public ReadOnly Property AirlineCode As String = ""
    Public ReadOnly Property eTicket As Boolean = False
    Public ReadOnly Property Segs As String = ""
    Public ReadOnly Property Pax As String = ""
    Public ReadOnly Property TicketType As String = ""
    Public ReadOnly Property ServicesDescription As String = ""
    Public ReadOnly Property ID As String = ""
    Public ReadOnly Property PaxType As String = ""
    Public ReadOnly Property IssuingAirline As String = ""
    Public ReadOnly Property Price As String = ""
    Public ReadOnly Property IssueDate As String = ""
    Public ReadOnly Property PCC As String = ""
    Public ReadOnly Property IATA As String = ""
    Public ReadOnly Property RawText As String = ""
    Public ReadOnly Property PaxID As String = ""
    Public Property SegsElementNo As String = ""
    Public Property SegsDescription As String = ""
    Public Property ClassAir As String = ""
    Public Property SellingPrice As Decimal = 0
    Public ReadOnly Property GDSLine As String = ""
    Public ReadOnly Property StockType As Integer = 0

    Public Sub New(ByVal pGDSLine As String, ByVal pStockType As Integer, ByVal pDocument As Decimal, ByVal pBooks As Integer, ByVal pIssuingAirline As String, ByVal AirlineCode As String, ByVal peTicket As Boolean, ByVal pSegs As String, ByVal pPax As String, ByVal pTicketType As String, ByVal pServicesDescription As String)

        GDSLine = pGDSLine
        StockType = pStockType
        Document = pDocument
        Books = pBooks
        IssuingAirline = pIssuingAirline
        AirlineCode = AirlineCode.Trim
        eTicket = peTicket
        Segs = pSegs
        Pax = pPax
        TicketType = pTicketType
        ServicesDescription = pServicesDescription
        LastDocument = Document + Books - 1
        Dim pTemp As String = LastDocument.ToString
        If pTemp.Length = 10 Then
            Conjunction = "-" & pTemp.Substring(7)
        End If
    End Sub

    Public Sub New(ByVal RawText As String, ByVal DocType As EnumTicketDocType, ByVal PaxID As String, ByVal SegsElementNo As String) ', ByVal SegsDescription As String) ', ByVal ClassAir As String)

        ' 2 examples of RawText
        ' 30 FA PAX 724-4175946315/ETLX/EUR369.39/13SEP13/ATHG42100/27280                
        '       573/S5-8/P4
        '28 FA PAX 157-4175946329/ETQR/13SEP13/ATHG42100/27280573                       
        '       /S6-7/P1 
        ' after the split we can have:
        '(0) - 30FAPAX724-4175946315
        '(1) - ETLX
        '(2) - EUR369.39
        '(3) - 13SEP13
        '(4) - ATHG42100'
        '(5) - 27280573
        '(6) - S5-8
        '(7) - P4
        '
        ' or
        '
        '(0) - 28FAPAX157-4175946329
        '(1) - ETQR
        '(2) - 13SEP13
        '(3) - ATHG42100
        '(4) - 27280573
        '(5) - S6-7
        '(6) - P1 
        '
        ' or for a voucher
        '
        ' 21 OSI YY ATH VCHR 9783035 AL.O/SG4   
        '

        RawText = RawText
        DocType = DocType
        PaxID = PaxID
        Dim pSegs() As String = Split(SegsElementNo, ":")
        If pSegs.GetUpperBound(0) = 2 Then
            SegsElementNo = pSegs(0).Trim
            SegsDescription = pSegs(1).Trim
            ClassAir = pSegs(2).Trim
        End If

        If DocType = EnumTicketDocType.VCHR Then
            Dim iVchrFrom As Integer = -1
            Dim iALFrom As Integer = -1
            Dim iSGFrom As Integer = -1
            PaxType = "Voucher"
            iVchrFrom = RawText.IndexOf("VCHR")
            If iVchrFrom > 0 And iVchrFrom < RawText.Length + 5 Then
                iALFrom = RawText.IndexOf("AL", iVchrFrom + 4)
                If iALFrom > 0 And iALFrom < RawText.Length + 5 Then
                    iSGFrom = RawText.IndexOf("/SG", iALFrom + 4)
                Else
                    iSGFrom = RawText.IndexOf("/SG", iVchrFrom + 4)
                End If
                If iALFrom = -1 Then
                    iALFrom = RawText.Length
                End If
                If iSGFrom = -1 Then
                    iSGFrom = RawText.Length
                End If
                If iALFrom <= iSGFrom Then
                    TicketNumber = RawText.Substring(iVchrFrom + 4, iALFrom - iVchrFrom - 5)
                Else
                    TicketNumber = RawText.Substring(iVchrFrom + 4, iSGFrom - iVchrFrom - 5)
                End If
                If iALFrom < RawText.Length - 4 Then
                    IssuingAirline = RawText.Substring(iALFrom + 2, iSGFrom - iALFrom - 2)
                End If
                If iSGFrom < RawText.Length - 3 Then
                    SegsElementNo = "S" & RawText.Substring(iSGFrom + 3, RawText.Length - iSGFrom - 3)
                End If
            Else
                TicketNumber = RawText
            End If

        Else
            Dim pItems() As String = Split(RawText.Replace(" ", ""), "/")
            If pItems.GetUpperBound(0) >= 4 Then
                TicketNumber = pItems(0)
                Dim i1 As Integer = pItems(0).IndexOf("FA")
                If i1 > 0 Then
                    ID = pItems(0).Substring(0, i1)
                    PaxType = pItems(0).Substring(i1 + 2, 3)
                    TicketNumber = pItems(0).Substring(i1 + 5)
                End If
                IssuingAirline = pItems(1).Substring(2)
                Dim pPriceIndex As Integer = 2
                If IsNumeric(("0" & pItems(2)).Substring(0, 1)) Then
                    pPriceIndex = 1
                    Price = ""
                Else
                    Price = pItems(pPriceIndex)
                End If
                IssueDate = pItems(pPriceIndex + 1)
                PCC = pItems(pPriceIndex + 2)
                IATA = pItems(pPriceIndex + 3)
            Else
                TicketNumber = RawText
                ID = PaxID
            End If
        End If

    End Sub
End Class