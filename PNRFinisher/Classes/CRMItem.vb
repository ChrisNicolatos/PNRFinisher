﻿Option Strict On
Option Explicit On
Public Class CRMItem
    Private Structure ClassProps
        Dim ID As Integer
        Dim Code As String
        Dim Name As String
        Dim Alert As String
    End Structure
    Private mudtProps As ClassProps
    Private mobjAlerts As New AlertsCollection()
    Public Overrides Function ToString() As String
        With mudtProps
            Return .Code & " " & .Name
        End With
    End Function
    Public ReadOnly Property ID() As Integer
        Get
            Return mudtProps.ID
        End Get
    End Property
    Public ReadOnly Property Code() As String
        Get
            Return mudtProps.Code
        End Get
    End Property
    Public ReadOnly Property Name() As String
        Get
            Return mudtProps.Name
        End Get
    End Property
    Public ReadOnly Property Alert As String
        Get
            Return mudtProps.Alert
        End Get
    End Property
    Friend Sub SetValues(ByVal pID As Integer, ByVal pCode As String, ByVal pName As String, ByVal pAlert As String)
        With mudtProps
            .ID = pID
            .Code = pCode
            .Name = pName
            .Alert = pAlert
        End With
    End Sub

    Public Sub Load(ByVal pSubCode As String)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringACC) ' ActiveConnection)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        mobjAlerts.Load()

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = " SELECT [Id] " &
                           " ,[Code] " &
                           " ,[Name] " &
                           " FROM [TravelForceCosmos].[dbo].[TFEntities] " &
                           " WHERE Code = '" & pSubCode & "'  " &
                           " ORDER BY Name "


            pobjReader = .ExecuteReader
        End With

        With pobjReader
            Do While .Read
                SetValues(CInt(.Item("Id")), CStr(.Item("Code")), CStr(.Item("Name")), mobjAlerts.AlertForFinisher(MySettings.PCCBackOffice, CStr(.Item("Code"))))
            Loop
            .Close()
        End With
        pobjConn.Close()
    End Sub
End Class
