﻿Option Strict On
Option Explicit On
Public Class FrequentFlyerItem
    Private Structure ClassProps
        Dim PaxName As String
        Dim Airline As String
        Dim FrequentTravelerNo As String
        Dim CrossAccrual As String
    End Structure
    Dim mudtProps As ClassProps
    Public ReadOnly Property PaxName As String
        Get
            Return mudtProps.PaxName
        End Get
    End Property
    Public ReadOnly Property Airline As String
        Get
            Return mudtProps.Airline
        End Get
    End Property
    Public ReadOnly Property FrequentTravelerNo As String
        Get
            Return mudtProps.FrequentTravelerNo
        End Get
    End Property
    Public ReadOnly Property CrossAccrual As String
        Get
            Return mudtProps.CrossAccrual
        End Get
    End Property
    Public Sub SetValues(ByVal pPaxName As String, ByVal pAirline As String, ByVal pFrequentTravelerNo As String, ByVal pCrossAccrual As String)
        With mudtProps
            .PaxName = pPaxName
            .Airline = pAirline
            .FrequentTravelerNo = pFrequentTravelerNo
            .CrossAccrual = pCrossAccrual
        End With
    End Sub
End Class