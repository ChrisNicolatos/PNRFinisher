Option Strict Off
Option Explicit On
Module mod1A
    '
    ' THIS MODULE IS COMPILED WITH OPTION STRICT OFF
    '
    ' ALL REQUIREMENTS FROM GDS APIs THAT USE OBJECTS MUST BE ENTERED HERE
    ' AND MUST BE STRICTLY VERIFIED MANUALLY
    '
    Public Function airStatus1A(ByVal pSegment As Object) As String
        Try
            Return pSegment.Text.substring(27, 2)
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function airAirline1A(ByVal pSegment As Object) As String
        Try
            Return pSegment.Airline
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function airAirline1A(ByVal pSegment As s1aPNR.AirFlownSegment) As String
        Try
            Return pSegment.Airline
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function airAirline1A(ByVal pSegment As s1aPNR.AirSegment) As String
        Try
            Return pSegment.Airline
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function airBoardPoint1A(ByVal pSegment As Object) As String

        Try
            Return pSegment.Boardpoint
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function airClass1A(ByVal pSegment As Object) As String

        Try
            Return pSegment.Class
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function airDepartureDate1A(ByVal pSegment As Object) As Date

        Dim pdteDate As Date

        Try
            pdteDate = pSegment.DepartureDate
            Do While pdteDate > DateAdd(Microsoft.VisualBasic.DateInterval.Year, 1, Today)
                pdteDate = DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, pdteDate)
            Loop
            Return pdteDate
        Catch exMissingMember As System.MissingMemberException
            Return Date.MinValue
        Catch ex As Exception
            Return Date.MinValue
        End Try

    End Function

    Public Function airArrivalDate1A(ByVal pSegment As Object) As Date

        Dim pdteDate As Date

        Try
            pdteDate = pSegment.ArrivalDate
            Do While pdteDate > DateAdd(Microsoft.VisualBasic.DateInterval.Year, 1, Today)
                pdteDate = DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, pdteDate)
            Loop
            Return pdteDate
        Catch exMissingMember As System.MissingMemberException
            Return Date.MinValue
        Catch ex As Exception
            Return Date.MinValue
        End Try

    End Function
    Public Function airElementNo1A(ByVal pSegment As Object) As Integer

        Try
            Return CInt(pSegment.ElementNo)
        Catch exMissingMember As System.MissingMemberException
            Return 0
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function airFlightNo1A(ByVal pSegment As Object) As String

        Try
            Return pSegment.FlightNo
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function airOffPoint1A(ByVal pSegment As Object) As String

        Try
            Return pSegment.Offpoint
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Function airDepartTime1A(ByVal pSegment As Object) As Date

        Try
            Return pSegment.DepartureTime
        Catch exMissingMember As System.MissingMemberException
            Return Date.MinValue
        Catch ex As Exception
            Return Date.MinValue
        End Try

    End Function

    Public Function airArriveTime1A(ByVal pSegment As Object) As Date

        Try
            Return pSegment.ArrivalTime
        Catch exMissingMember As System.MissingMemberException
            Return Date.MinValue
        Catch ex As Exception
            Return Date.MinValue
        End Try

    End Function

    Public Function airText1A(ByVal pSegment As Object) As String

        Try
            Return pSegment.Text
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Function Equipment(ByVal pSegment As Object) As String
        Try
            If pSegment.Equipment Is Nothing Then
                Return ""
            Else
                Return pSegment.Equipment
            End If
        Catch exMissingMember As System.MissingMemberException
            Return ""
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Sub PrepareLineNumbers1A(ByVal ExistingItem As GDSExistingItem, ByRef pLineNumbers() As Integer)
        If ExistingItem.Exists Then
            ReDim Preserve pLineNumbers(pLineNumbers.GetUpperBound(0) + 1)
            pLineNumbers(pLineNumbers.GetUpperBound(0)) = ExistingItem.LineNumber
        End If
    End Sub

End Module
