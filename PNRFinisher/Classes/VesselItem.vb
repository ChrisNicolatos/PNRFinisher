Option Strict On
Option Explicit On
Public Class VesselItem
    Private Const TextREG As String = " REG "
    Public ReadOnly Property VesselName As String = ""
    Public ReadOnly Property VesselRegistration As String = ""
    Public ReadOnly Property Loaded As Boolean = False
    Public Overrides Function ToString() As String
        If VesselRegistration = "" Then
            Return VesselName
        Else
            If VesselRegistration <> "" Then
                Return VesselName & TextREG & VesselRegistration
            Else
                Return VesselName
            End If
        End If
    End Function
    Public Sub New()
        VesselName = ""
        VesselRegistration = ""
    End Sub
    Public Sub New(ByVal pName As String, ByVal pFlag As String)
        If pName.ToUpper.Contains(TextREG) Then
            If pFlag.Trim = "" Then
                pFlag = pName.Substring(pName.ToUpper.IndexOf(TextREG) + 6).Trim
                pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TextREG)).Trim
            Else
                pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TextREG)).Trim
            End If
        End If
        VesselName = pName.Trim
        VesselRegistration = pFlag.Trim
    End Sub
    Public Sub New(ByVal pClientCode As String, ByVal pVesselName As String, ByVal pBackOffice As Integer)
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@ClientCode", SqlDbType.NVarChar, 50).Value = pClientCode
            .Parameters.Add("@VesselName", SqlDbType.NVarChar, 255).Value = pVesselName
            .CommandText = PrepareVesselSelectCommand(pBackOffice)
            pobjReader = .ExecuteReader
        End With

        Loaded = False
        With pobjReader
            If .Read Then
                VesselName = CStr(.Item("Name"))
                VesselRegistration = CStr(.Item("Flag"))
                Loaded = True
            End If
            .Close()
        End With
        pobjConn.Close()
    End Sub
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
                                            AND (TravelForceCosmos.dbo.TFEntities.Code = @ClientCode) 
                                            ORDER BY Name "
            Case 2
                PrepareVesselSelectCommand = "SELECT [Child_Value] AS Name 
                                             , '' AS Flag 
                                             FROM [Disco_Instone_EU].[dbo].[Costcen] 
                                             LEFT JOIN Company 
                                             ON Costcen.Account_Id=Company.Account_Id 
                                             WHERE Company.Account_Abbriviation =  @ClientCode AND Child_Name = 'CC1' AND Child_Value = @VesselName "
            Case Else
                PrepareVesselSelectCommand = ""
        End Select
    End Function
End Class