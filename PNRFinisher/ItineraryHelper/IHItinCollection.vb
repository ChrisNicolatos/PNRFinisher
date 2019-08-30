Option Strict On
Option Explicit On
Public Class IHItinCollection
    Inherits Collections.Generic.List(Of IHItinItem)
    Private mdblMin() As Double = {Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue, Double.MaxValue}
    Private mintMaxLen() As Integer = {0, 0, 0, 0, 0, 0, 0}
    Public Sub Load(ByVal Origin As String, ByVal Stopover As String, ByVal Destination As String, ByVal FromDate As Date, ByVal FromAirportOnly As Boolean, ByVal StopoverAirportOnly As Boolean, ByVal ToAirportOnly As Boolean, ByVal pBackOffice As Integer)
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@From", SqlDbType.Char, 3).Value = Origin
            .Parameters.Add("@Stopover", SqlDbType.Char, 3).Value = Stopover
            .Parameters.Add("@To", SqlDbType.Char, 3).Value = Destination
            .Parameters.Add("@FromDate", SqlDbType.Date).Value = FromDate
            .Parameters.Add("@FromAirportOnly", SqlDbType.Bit).Value = FromAirportOnly
            .Parameters.Add("@StopoverAirportOnly", SqlDbType.Bit).Value = StopoverAirportOnly
            .Parameters.Add("@ToAirportOnly", SqlDbType.Bit).Value = ToAirportOnly
            .CommandTimeout = 60
            .CommandText = "
USE TravelForceCosmos

If(OBJECT_ID('tempdb..#TempFROM') Is Not Null)
Begin
Drop Table #TempFrom
End

If(OBJECT_ID('tempdb..#TempSTOPOVER') Is Not Null)
Begin
Drop Table #TempSTOPOVER
End

If(OBJECT_ID('tempdb..#TempTO') Is Not Null)
Begin
Drop Table #TempTO
End

If(OBJECT_ID('tempdb..#TempRouting') Is Not Null)
Begin
Drop Table #TempRouting
End

If(OBJECT_ID('tempdb..#TempPNR') Is Not Null)
Begin
Drop Table #TempPNR
End

If(OBJECT_ID('tempdb..#Temp1') Is Not Null)
Begin
Drop Table #Temp1
End

If(OBJECT_ID('tempdb..#Temp2') Is Not Null)
Begin
Drop Table #Temp2
End

If(OBJECT_ID('tempdb..#Temp3') Is Not Null)
Begin
Drop Table #Temp3
End

If(OBJECT_ID('tempdb..#Temp4') Is Not Null)
Begin
Drop Table #Temp4
End

SELECT Id, Abbreviation
INTO #TempFrom
FROM Airports
WHERE Abbreviation = @From 
   OR CityCode = @From
   OR (@FromAirportOnly = 0 AND CityCode = (SELECT CityCode FROM Airports AA WHERE AA.Abbreviation = @From))

SELECT Id, Abbreviation
INTO #TempSTOPOVER
FROM Airports
WHERE Abbreviation = @Stopover 
   OR CityCode = @Stopover
   OR (@StopoverAirportOnly = 0 AND CityCode = (SELECT CityCode FROM Airports AA WHERE AA.Abbreviation = @Stopover))

SELECT Id, Abbreviation
INTO #TempTo
FROM Airports
WHERE Abbreviation = @To 
   OR CityCode = @To
   OR (@ToAirportOnly = 0 AND CityCode = (SELECT CityCode FROM Airports AA WHERE AA.Abbreviation = @To))

SELECT AirTickets.PNRId
INTO #TempPNR
FROM [TravelForceCosmos].[dbo].[AirSegments]
LEFT JOIN AirTicketTransactions
ON AirSegments.AirTicketTransactionID = AirTicketTransactions.Id
LEFT JOIN AirTickets
ON AirTickets.Id = AirTicketTransactions.AirTicketId
WHERE IssueDate >= @FromDate 
AND (@From = '...' OR (SELECT TOP 1 FromAirportID FROM AirSegments ASTo
	LEFT JOIN AirTicketTransactions ATTTo
	ON ATTTo.Id = ASTo.AirTicketTransactionID
	LEFT JOIN AirTickets ATTo
	ON ATTo.Id = ATTTo.AirTicketID   
	WHERE ATTo.PNRId = AirTickets.PNRId
	ORDER BY OriginalPosition ) 
IN (SELECT Id FROM #TempFrom))

AND (@Stopover = '' OR (SELECT COUNT(*) FROM AirSegments ASTo
	LEFT JOIN AirTicketTransactions ATTTo
	ON ATTTo.Id = ASTo.AirTicketTransactionID
	LEFT JOIN AirTickets ATTo
	ON ATTo.Id = ATTTo.AirTicketID   
	LEFT JOIN #TempSTOPOVER
	ON #TempSTOPOVER.Id = AirSegments.FromAirportId
	WHERE ATTo.PNRId = AirTickets.PNRId AND #TempSTOPOVER.Id IS NOT NULL) >0)
  
AND (@To = '...' OR (SELECT TOP 1 ToAirportID FROM AirSegments ASTo
	LEFT JOIN AirTicketTransactions ATTTo
	ON ATTTo.Id = ASTo.AirTicketTransactionID
	LEFT JOIN AirTickets ATTo
	ON ATTo.Id = ATTTo.AirTicketID   
	WHERE ATTo.PNRId = AirTickets.PNRId
	ORDER BY OriginalPosition DESC)
IN (SELECT Id FROM #TempTo))

SELECT LTRIM(RTRIM(PNR.Code))AS Code
	  , LTRIM(RTRIM(Passengers.Name)) AS Name
	  , LTRIM(RTRIM(TicketAirline.IATACode)) AS TicketingAirline
	  , IssueDate
	  , LTRIM(RTRIM(CarrierAirline.IATACode)) AS CarrierAirline
      , FlightNr
	  , AirTicketTypeID
      , LTRIM(RTRIM(ActualClass)) AS ActualClass
	  , LTRIM(RTRIM(FromAirport.Abbreviation)) AS Origin
	  , LTRIM(RTRIM(ToAirport.Abbreviation)) AS Destination
      ,[AirTicketTransactionID]
      ,[OriginalPosition]
  INTO #TempRouting
  FROM [TravelForceCosmos].[dbo].[AirSegments]
  LEFT JOIN AirTicketTransactions
  ON AirSegments.AirTicketTransactionID = AirTicketTransactions.Id
  LEFT JOIN AirTickets
  ON AirTickets.Id = AirTicketTransactions.AirTicketId
  LEFT JOIN PNR
  ON PNR.ID = PNRID
  LEFT JOIN CommercialTransactions
  ON CommercialTransactions.Id = AirTicketTransactions.CommercialTransactionId
  LEFT JOIN Passengers
  ON Passengers.CommercialTransactionId = AirTicketTransactions.CommercialTransactionId
  LEFT OUTER JOIN Airlines TicketAirline
  ON TicketingAirlineId = TicketAirline.Id
  LEFT OUTER JOIN Airlines CarrierAirline
  ON CarrierAirlineId = CarrierAirline.Id
				LEFT OUTER JOIN Airports FromAirport
				ON FromAirportId = FromAirport.Id
				LEFT OUTER JOIN Airports ToAirport
				ON ToAirportID = ToAirport.Id
  WHERE IsRefunded = 0 
    AND Void = 0 
	AND IsReversed = 0
	AND AirTicketTypeID IN (323,325,547) 
	AND CommercialTransactions.ActionTypeId = 335 
	AND AirTickets.PNRId IN (SELECT PNRId FROM #TempPNR)
  ORDER BY AirTickets.PNRId, Passengers.Name, AirSegments.OriginalPosition

  SELECT Code
       , Name
	   , 'YY' AS TicketingAirline
	   , AirTicketTypeID
	   , IssueDate
	   , (SELECT TOP 1 Origin FROM #TempRouting TT1 WHERE TT1.AirTicketTransactionID = #TempRouting.AirTicketTransactionID AND TT1.Name = #TempRouting.Name ORDER BY OriginalPosition) 
	   + STUFF((SELECT ' ' + ' ' + Destination
	            FROM #TempRouting TROUT
				WHERE TROUT.AirTicketTransactionID = #TempRouting.AirTicketTransactionID AND TROUT.Name = #TempRouting.Name
				ORDER BY OriginalPosition
				FOR XML PATH ('')), 1, 1, '') AS Routing
	   , TicketingAirline +'(' + STUFF((SELECT ' ' + Origin + ' ' + CarrierAirline + '/' + ActualClass + ' ' + Destination
	            FROM #TempRouting TROUT
				WHERE TROUT.AirTicketTransactionID = #TempRouting.AirTicketTransactionID AND TROUT.Name = #TempRouting.Name
				ORDER BY OriginalPosition
				FOR XML PATH ('')), 1, 1, '') + ')' AS Ticket
	   , AirTicketTransactionID
	   , OriginalPosition
  INTO #Temp1
  FROM #TempRouting
  ORDER BY Code, Name, AirTicketTransactionID, OriginalPosition

  SELECT Code
       , Name
	   , MIN(IssueDate) AS IssueDate
	   , TicketingAirline
	   , Routing
	   , AirTicketTypeID
	   , Ticket
	   , AirTicketTransactionID	
	   , MIN(OriginalPosition) AS OriginalPosition
  INTO #Temp2
  FROM #Temp1
  GROUP BY Code
         , Name
		 , Routing
		 , TicketingAirline
		 , AirTicketTypeID
		 , Ticket
		 , AirTicketTransactionID
  ORDER BY Code
         , Name		 
		 , OriginalPosition

  SELECT #Temp2.Code AS Code
       , #Temp2.Name
	   , TFEntities.Code + ' ' + TFENtities.Name AS Client
	   , MIN(IssueDate) AS IssueDate
	   , Routing
	   , TicketingAirline
	   , AirTicketTypeID
	   , Ticket
	   , AirTicketTransactionID	
	   , MIN(OriginalPosition) AS OriginalPosition
	   , CONVERT(INT, SUM(-(ISNULL(CommercialTransactionValues.FaceValue, 0)
 					  + ISNULL(CommercialTransactionValues.FVVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.FaceValueExtra, 0)
					  + ISNULL(CommercialTransactionValues.FVXVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.Taxes, 0)
					  + ISNULL(CommercialTransactionValues.TAXVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.TaxesExtra, 0)
					  + ISNULL(CommercialTransactionValues.TAXXVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.DiscountAmount, 0)
					  + ISNULL(CommercialTransactionValues.DISCVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.CommissionAmount, 0)
					  + ISNULL(CommercialTransactionValues.COMVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.ServiceFeeAmount, 0) 
					  + ISNULL(CommercialTransactionValues.SFVatAmount, 0)
					  + ISNULL(CommercialTransactionValues.CancellationFeeAmount, 0)
					  + ISNULL(CommercialTransactionValues.CFVatAmount, 0))* CommercialTransactionValues.Rate /CommercialTransactions.Pax)) AS Cost
  INTO #Temp3
  FROM #Temp2
  LEFT OUTER JOIN AirTicketTransactions 
  ON AirTicketTransactions.Id = #Temp2.AirTicketTransactionId 
  LEFT JOIN CommercialTransactionValues
  LEFT JOIN CommercialTransactions
  ON CommercialTransactionValues.CommercialTransactionID=CommercialTransactions.Id
  ON AirTicketTransactions.CommercialTransactionId = CommercialTransactionValues.CommercialTransactionID AND CommercialTransactionValues.IsCost = 1
  LEFT JOIN CommercialTransactionValues CCSell
  LEFT JOIN TFEntities ON TFEntities.Id = CommercialEntityID
  ON AirTicketTransactions.CommercialTransactionId = CCSell.CommercialTransactionID AND CCSell.IsCost = 0
  GROUP BY #Temp2.Code
         , #Temp2.Name
	     , TFEntities.Code + ' ' + TFENtities.Name
		 , Routing
		 , TicketingAirline
		 , AirTicketTypeID
		 , Ticket
		 , AirTicketTransactionID
  ORDER BY TFEntities.Code + ' ' + TFENtities.Name
         , #Temp2.Code
         , #Temp2.Name		 
		 , OriginalPosition

SELECT Code
     , Name	 
	 , TicketingAirline
	 , AirTicketTypeID
	 , STUFF((SELECT ',' + Routing 
	          FROM #Temp3 TT3
			  WHERE TT3.Code = #Temp3.Code AND TT3.Name = #Temp3.Name
			  ORDER BY OriginalPosition FOR XML PATH ('')), 1, 1, '') AS Routing
	 , STUFF((SELECT ',' + Ticket 
	          FROM #Temp3 TT3
			  WHERE TT3.Code = #Temp3.Code AND TT3.Name = #Temp3.Name
			  ORDER BY OriginalPosition FOR XML PATH ('')), 1, 1, '') AS Ticket
	 , Client
	 , SUM(Cost) AS Cost
INTO #Temp4
FROM #Temp3
GROUP BY Code
       , Name
	   , TicketingAirline
	   , AirTicketTypeID
	   , Client
ORDER BY Code
        , Name
		, Client		 

SELECT ISNULL(Routing, '') AS Routing
     , ISNULL(TicketingAirline, '') AS TicketingAirline
	 , ISNULL(AirTicketTypeID, 0) AS AirTicketTypeID
	 , ISNULL(Ticket, '') AS Ticket
	 , ISNULL(Client, '') AS Client
	 , ISNULL(Code, '') AS PNR
     , ISNULL(Name, '') AS Name
	 , AVG(Cost) AS TotalFarePlusTaxes
	 , COUNT(*) AS Pax
	 , SUM(LEN(Ticket) - LEN(REPLACE(Ticket,'(',''))) AS NumTickets
FROM #Temp4
WHERE CHARINDEX(SUBSTRING(Routing,1,3), SUBSTRING(Routing, 1,LEN(Routing)-2) , 3) = 0
  AND (@From = '...' OR SUBSTRING(Routing,1,3) IN (SELECT Abbreviation FROM #TempFrom))
  AND (@To   = '...' OR SUBSTRING(Routing,LEN(Routing)-2,3) IN (SELECT Abbreviation FROM #TempTo))
GROUP BY GROUPING SETS (
  ()
, (Routing)
--, (Routing, TicketingAirline)
, (Routing, TicketingAirline, AirTicketTypeID, Ticket)
, (Routing, TicketingAirline, AirTicketTypeID, Ticket, Client)
, (Routing, TicketingAirline, AirTicketTypeID, Ticket, Client, Code)
, (Routing, TicketingAirline, AirTicketTypeID, Ticket, Client, Code, Name)
)
ORDER BY Routing
       , TicketingAirline
       , Ticket
	   , Client
	   , Code
	   , Name

If(OBJECT_ID('tempdb..#TempRouting') Is Not Null)
Begin
Drop Table #TempRouting
End

If(OBJECT_ID('tempdb..#TempPNR') Is Not Null)
Begin
Drop Table #TempPNR
End

If(OBJECT_ID('tempdb..#Temp1') Is Not Null)
Begin
Drop Table #Temp1
End

If(OBJECT_ID('tempdb..#Temp2') Is Not Null)
Begin
Drop Table #Temp2
End

If(OBJECT_ID('tempdb..#Temp3') Is Not Null)
Begin
Drop Table #Temp3
End

If(OBJECT_ID('tempdb..#Temp4') Is Not Null)
Begin
Drop Table #Temp4
End

If(OBJECT_ID('tempdb..#TempFROM') Is Not Null)
Begin
Drop Table #TempFrom
End

If(OBJECT_ID('tempdb..#TempTO') Is Not Null)
Begin
Drop Table #TempTO
End

If(OBJECT_ID('tempdb..#TempSTOPOVER') Is Not Null)
Begin
Drop Table #TempSTOPOVER
End

"
            pobjReader = .ExecuteReader
        End With
        With pobjReader
            Do While .Read
                Dim pItem As New IHItinItem
                pItem.SetValues(CStr(.Item("Routing")), CStr(.Item("TicketingAirline")), CStr(.Item("Ticket")), CStr(.Item("Client")), CStr(.Item("PNR")), CStr(.Item("Name")), CDbl(.Item("TotalFarePlusTaxes")), CInt(.Item("Pax")), CInt(.Item("NumTickets")))
                MyBase.Add(pItem)
                If pItem.TotalFarePlusTaxes < mdblMin(pItem.Level) Then
                    mdblMin(pItem.Level) = pItem.TotalFarePlusTaxes
                End If
                If pItem.Key.Length > mintMaxLen(pItem.Level) Then
                    mintMaxLen(pItem.Level) = pItem.Key.Length
                End If
            Loop
        End With
    End Sub
    Public ReadOnly Property MinTotalFare(ByVal Level As Integer) As Double
        Get
            If Level >= 1 And Level <= mdblMin.GetUpperBound(0) Then
                Return mdblMin(Level)
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property MaxDescLen(ByVal Level As Integer) As Integer
        Get
            If Level >= 1 And Level <= mintMaxLen.GetUpperBound(0) Then
                Return mintMaxLen(Level)
            Else
                Return 0
            End If
        End Get
    End Property

End Class
