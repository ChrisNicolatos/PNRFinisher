﻿Option Strict Off
Option Explicit On
Module mod1A
    Public Function airStatus1A(ByRef pSegment As Object) As String

        Try
            airStatus1A = pSegment.Text.substring(27, 2)
        Catch ex As Exception
            airStatus1A = ""
        End Try

    End Function
    Public Function airAirline1A(ByRef pSegment As Object) As String

        Try
            airAirline1A = pSegment.Airline
        Catch ex As Exception
            airAirline1A = ""
        End Try

    End Function

    Public Function airBoardPoint1A(ByRef pSegment As Object) As String

        Try
            airBoardPoint1A = pSegment.BoardPoint
        Catch ex As Exception
            airBoardPoint1A = ""
        End Try

    End Function

    Public Function airClass1A(ByRef pSegment As Object) As String

        Try
            airClass1A = pSegment.Class
        Catch ex As Exception
            airClass1A = ""
        End Try

    End Function

    Public Function airDepartureDate1A(ByRef pSegment As Object) As Date

        Dim pdteDate As Date

        Try
            pdteDate = pSegment.DepartureDate
            Do While pdteDate > DateAdd(Microsoft.VisualBasic.DateInterval.Year, 1, Today)
                pdteDate = DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, pdteDate)
            Loop

            airDepartureDate1A = pdteDate
        Catch ex As Exception
            airDepartureDate1A = Date.MinValue
        End Try

    End Function

    Public Function airArrivalDate1A(ByRef pSegment As Object) As Date

        Dim pdteDate As Date

        Try
            pdteDate = pSegment.ArrivalDate
            Do While pdteDate > DateAdd(Microsoft.VisualBasic.DateInterval.Year, 1, Today)
                pdteDate = DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, pdteDate)
            Loop

            airArrivalDate1A = pdteDate
        Catch ex As Exception
            airArrivalDate1A = Date.MinValue
        End Try

    End Function
    Public Function airElementNo1A(ByRef pSegment As Object) As Integer

        Try
            airElementNo1A = pSegment.ElementNo
        Catch ex As Exception
            airElementNo1A = CShort("")
        End Try

    End Function

    Public Function airFlightNo1A(ByRef pSegment As Object) As String

        Try
            airFlightNo1A = pSegment.FlightNo
        Catch ex As Exception
            airFlightNo1A = ""
        End Try

    End Function

    Public Function airOffPoint1A(ByRef pSegment As Object) As String

        Try
            airOffPoint1A = pSegment.OffPoint
        Catch ex As Exception
            airOffPoint1A = ""
        End Try

    End Function
    Public Function airDepartTime1A(ByRef pSegment As Object) As Date

        Try
            airDepartTime1A = pSegment.DepartureTime
        Catch ex As Exception
            airDepartTime1A = Date.MinValue
        End Try

    End Function

    Public Function airArriveTime1A(ByRef pSegment As Object) As Date

        Try
            airArriveTime1A = pSegment.ArrivalTime
        Catch ex As Exception
            airArriveTime1A = Date.MinValue
        End Try

    End Function

    Public Function airText1A(ByRef pSegment As Object) As String

        Try
            airText1A = pSegment.Text
        Catch ex As Exception
            airText1A = ""
        End Try

    End Function
    Public Function Equipment(ByRef pSegment As Object) As String
        Try
            Equipment = pSegment.Equipment
            If Equipment Is Nothing Then
                Equipment = ""
            End If
        Catch ex As Exception
            Equipment = ""
        End Try

    End Function
    Public Sub PrepareLineNumbers1A(ByVal ExistingItem As GDSExistingItem, ByRef pLineNumbers() As Integer)
        If ExistingItem.Exists Then
            ReDim Preserve pLineNumbers(pLineNumbers.GetUpperBound(0) + 1)
            pLineNumbers(pLineNumbers.GetUpperBound(0)) = ExistingItem.LineNumber
        End If
    End Sub

End Module
