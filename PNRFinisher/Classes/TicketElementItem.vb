﻿Option Strict On
Option Explicit On
Public Class TicketElementItem
    Private Structure ClassProps
        Dim ElementNo As Integer
        Dim PCC As String
        Dim ActionDateTime As Date
        Dim Remark As String
    End Structure
    Private mudtProps As ClassProps
    Public ReadOnly Property ElementNo As Integer
        Get
            Return mudtProps.ElementNo
        End Get
    End Property
    Public ReadOnly Property PCC As String
        Get
            Return mudtProps.PCC
        End Get
    End Property
    Public ReadOnly Property ActionDateTime As Date
        Get
            Return mudtProps.ActionDateTime
        End Get
    End Property
    Public ReadOnly Property Remark As String
        Get
            Return mudtProps.Remark
        End Get
    End Property
    Public Sub SetValues(ByVal pElementNo As Integer, ByVal pPCC As String, ByVal pActionDateTime As Date, ByVal pRemark As String)
        With mudtProps
            .ElementNo = pElementNo
            .PCC = pPCC
            .ActionDateTime = pActionDateTime
            .Remark = pRemark
        End With
    End Sub
End Class