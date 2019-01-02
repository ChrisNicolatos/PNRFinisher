﻿Option Strict On
Option Explicit On
Public Class VesselItem
    Private Structure ClassProps
        Dim Name As String
        Dim Flag As String
    End Structure
    Private mudtProps As ClassProps
    Public Overrides Function ToString() As String
        With mudtProps
            If .Flag = "" Then
                Return .Name
            Else
                Return .Name & MySettings.GDSValue("TextREG") & .Flag
            End If
        End With
    End Function

    Public ReadOnly Property Name() As String
        Get
            Return mudtProps.Name
        End Get
    End Property

    Public ReadOnly Property Flag() As String
        Get
            Return mudtProps.Flag
        End Get
    End Property

    Friend Sub SetValues(ByVal pName As String, ByVal pFlag As String)
        With mudtProps
            If pName.ToUpper.Contains(MySettings.GDSValue("TextREG")) Then
                If pFlag.Trim = "" Then
                    pFlag = pName.Substring(pName.ToUpper.IndexOf(MySettings.GDSValue("TextREG")) + 6).Trim
                    pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(MySettings.GDSValue("TextREG"))).Trim
                Else
                    pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(MySettings.GDSValue("TextREG"))).Trim
                End If
            End If
            .Name = pName.Trim
            .Flag = pFlag.Trim
        End With
    End Sub

    Public Function Load(ByVal pCustCode As String, ByVal pVesselName As String) As Boolean
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringACC)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = PrepareVesselSelectCommand(pCustCode, pVesselName)
            pobjReader = .ExecuteReader
        End With

        Load = False
        With pobjReader
            If .Read Then
                SetValues(CStr(.Item("Name")), CStr(.Item("Flag")))
                Load = True
            End If
            .Close()
        End With
        pobjConn.Close()
    End Function
    Private Function PrepareVesselSelectCommand(ByVal pCustCode As String, ByVal pVesselName As String) As String
        Select Case MySettings.PCCBackOffice
            Case 1
                PrepareVesselSelectCommand = " SELECT DISTINCT " &
                                           " RTRIM(LTRIM(TFEntityDepartments.Name)) AS Name " &
                                           " ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag " &
                                           " FROM [TravelForceCosmos].[dbo].[TFEntityDepartments] " &
                                           " 		LEFT OUTER JOIN TravelForceCosmos.dbo.TFEntities  " &
                                           " 			ON TravelForceCosmos.dbo.TFEntityDepartments.EntityID = TravelForceCosmos.dbo.TFEntities.Id " &
                                           " WHERE InUse = 1  " &
                                           " AND (TravelForceCosmos.dbo.TFEntityDepartments.Name = '" & pVesselName & "') " &
                                           " AND (TravelForceCosmos.dbo.TFEntities.Code = '" & pCustCode & "') " &
                                           " ORDER BY Name "
            Case 2
                PrepareVesselSelectCommand = "SELECT [Child_Value] AS Name " &
                                            " , '' AS Flag " &
                                            " FROM [Disco_Instone_EU].[dbo].[Costcen] " &
                                            " LEFT JOIN Company " &
                                            " ON Costcen.Account_Id=Company.Account_Id " &
                                            " WHERE Company.Account_Abbriviation = '" & pCustCode & "' AND Child_Name = 'CC1' AND Child_Value = '" & pVesselName & "' "
            Case Else
                PrepareVesselSelectCommand = ""
        End Select
    End Function
End Class