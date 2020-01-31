Option Strict On
Option Explicit On
Public Class GDSDateTime
    Private mobjAirlineDate As New s1aAirlineDate.clsAirlineDate
    Public ReadOnly Property SegDate As Date = Date.MinValue
    Public ReadOnly Property DateIATA As String = ""
    Public ReadOnly Property DayOfTheWeek As String
        Get
            Return WeekDaySeg(SegDate)
        End Get
    End Property
    Private Shared Function WeekDaySeg(ByVal InputDate As Date) As String

        Try
            Select Case Weekday(InputDate)
                Case 1
                    WeekDaySeg = "Sunday"
                Case 2
                    WeekDaySeg = "Monday"
                Case 3
                    WeekDaySeg = "Tuesday"
                Case 4
                    WeekDaySeg = "Wednesday"
                Case 5
                    WeekDaySeg = "Thursday"
                Case 6
                    WeekDaySeg = "Friday"
                Case 7
                    WeekDaySeg = "Saturday"
                Case Else
                    WeekDaySeg = ""
            End Select
        Catch ex As Exception
            WeekDaySeg = ""
        End Try

    End Function
    Public ReadOnly Property SegTime As Date
    Public ReadOnly Property TimeShort As String
        Get
            Return Format(SegTime, "HHmm")
        End Get
    End Property
    Public ReadOnly Property TimeShort(ByVal Separator As String) As String
        Get
            Return Format(SegTime, "HH") & Separator & Format(SegTime, "mm")
        End Get
    End Property
    Public Sub New(ByVal GDSDate As Date, ByVal GDSTime As Date)
        SegDate = GDSDate
        SegTime = GDSTime

        Try
            mobjAirlineDate.IgnoreAmadeusRange = True
            mobjAirlineDate.VBDate = SegDate
        Catch ex As Exception
            mobjAirlineDate.VBDate = DateAdd(DateInterval.Year, -1, SegDate)
        End Try
        DateIATA = mobjAirlineDate.IATA

    End Sub
End Class
