﻿Option Strict On
Option Explicit On
Public Class GDSPaxItem
    Private Structure ClassProps
        Dim ElementNo As Integer
        Dim Initial As String
        Dim LastName As String
        Dim PaxID As String
        Dim IDNo As String
        Dim Department As String
        Dim Nationality As String
    End Structure

    Private mudtProps As ClassProps

    Public ReadOnly Property ElementNo() As Integer
        Get
            Return mudtProps.ElementNo
        End Get
    End Property
    Public ReadOnly Property Initial() As String
        Get
            If mudtProps.Initial Is Nothing Then
                Return ""
            Else
                Return mudtProps.Initial.Trim
            End If

        End Get
    End Property
    Public ReadOnly Property LastName() As String
        Get
            Return mudtProps.LastName.Trim
        End Get
    End Property
    Public ReadOnly Property PaxID() As String
        Get
            Return mudtProps.PaxID.Trim
        End Get
    End Property
    Public ReadOnly Property PaxName() As String
        Get
            Return LastName & "/" & Initial
        End Get
    End Property
    Public ReadOnly Property IdNo As String
        Get
            Return mudtProps.IDNo
        End Get
    End Property
    Public ReadOnly Property Department As String
        Get
            Return mudtProps.Department
        End Get
    End Property
    Public ReadOnly Property Nationality As String
        Get
            Return mudtProps.Nationality
        End Get
    End Property
    Friend Sub SetValues(ByRef pElementNo As Integer, ByRef pInitial As String, ByRef pLastName As String, ByRef pID As String)

        With mudtProps
            .ElementNo = pElementNo
            .Initial = pInitial
            .LastName = pLastName
            .PaxID = pID
            If pID.StartsWith("(") Then
                Dim pSplit() As String = pID.Replace("(", "").Replace(")", "").Split({","}, StringSplitOptions.RemoveEmptyEntries)
                If pSplit.GetUpperBound(0) >= 2 Then
                    .Nationality = pSplit(2)
                End If
                If pSplit.GetUpperBound(0) >= 1 Then
                    .Department = pSplit(1)
                End If
                If pSplit.GetUpperBound(0) >= 0 Then
                    .IDNo = pSplit(0).Replace("ID", "").Trim
                End If
            End If
        End With

    End Sub
End Class
