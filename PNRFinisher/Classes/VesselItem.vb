Option Strict On
Option Explicit On
Public Class VesselItem
    Private Const TextREG As String = " REG "
    Private Structure ClassProps
        Dim Name As String
        Dim Flag As String
    End Structure
    Private mudtProps As ClassProps
    Public Overrides Function ToString() As String
        With mudtProps
            If Flag = "" Then
                Return Name
            Else
                If Not MySettings Is Nothing AndAlso Flag <> "" Then
                    Return Name & TextREG & Flag
                Else
                    Return Name
                End If

            End If
        End With
    End Function

    Public ReadOnly Property Name() As String
        Get
            If mudtProps.Name Is Nothing Then
                mudtProps.Name = ""
            End If
            Return mudtProps.Name
        End Get
    End Property

    Public ReadOnly Property Flag() As String
        Get
            If mudtProps.Flag Is Nothing Then
                mudtProps.Flag = ""
            End If
            Return mudtProps.Flag
        End Get
    End Property
    Friend Sub SetValues(ByVal pName As String, ByVal pFlag As String)
        With mudtProps
            If Not MySettings Is Nothing AndAlso pName.ToUpper.Contains(TextREG) Then
                If pFlag.Trim = "" Then
                    pFlag = pName.Substring(pName.ToUpper.IndexOf(TextREG) + 6).Trim
                    pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TextREG)).Trim
                Else
                    pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TextREG)).Trim
                End If
            End If
            .Name = pName.Trim
            .Flag = pFlag.Trim
        End With
    End Sub
    Public Function Load(ByVal pCustCode As String, ByVal pVesselName As String, ByVal pBackOffice As Integer) As Boolean
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@CustCode", SqlDbType.NVarChar, 50).Value = pCustCode
            .Parameters.Add("@VesselName", SqlDbType.NVarChar, 255).Value = pVesselName
            .CommandText = PrepareVesselSelectCommand(pBackOffice)
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
    Private Shared Function PrepareVesselSelectCommand(ByVal pBackOffice As Integer) As String
        Select Case pBackOffice
            Case 1
                PrepareVesselSelectCommand = " SELECT DISTINCT 
                                            RTRIM(LTRIM(TFEntityDepartments.Name)) AS Name 
                                            ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag 
                                            FROM [TravelForceCosmos].[dbo].[TFEntityDepartments] 
                                            		LEFT OUTER JOIN TravelForceCosmos.dbo.TFEntities  
                                            			ON TravelForceCosmos.dbo.TFEntityDepartments.EntityID = TravelForceCosmos.dbo.TFEntities.Id 
                                            WHERE InUse = 1  
                                            AND (TravelForceCosmos.dbo.TFEntityDepartments.Name = @VesselName) 
                                            AND (TravelForceCosmos.dbo.TFEntities.Code = @CustCode) 
                                            ORDER BY Name "
            Case 2
                PrepareVesselSelectCommand = "SELECT [Child_Value] AS Name 
                                             , '' AS Flag 
                                             FROM [Disco_Instone_EU].[dbo].[Costcen] 
                                             LEFT JOIN Company 
                                             ON Costcen.Account_Id=Company.Account_Id 
                                             WHERE Company.Account_Abbriviation =  @CustCode AND Child_Name = 'CC1' AND Child_Value = @VesselName "
            Case Else
                PrepareVesselSelectCommand = ""
        End Select
    End Function
End Class