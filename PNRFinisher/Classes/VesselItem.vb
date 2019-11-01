Option Strict On
Option Explicit On
Public Class VesselItem
    Private Const SQL1 As String = " SELECT DISTINCT 
                                            RTRIM(LTRIM(TFEntityDepartments.Name)) AS Name 
                                            ,ISNULL(RTRIM(LTRIM(Flag)), '') AS Flag 
                                            FROM [TravelForceCosmos].[dbo].[TFEntityDepartments] 
                                            		LEFT OUTER JOIN TravelForceCosmos.dbo.TFEntities  
                                            			ON TravelForceCosmos.dbo.TFEntityDepartments.EntityID = TravelForceCosmos.dbo.TFEntities.Id 
                                            WHERE InUse = 1  
                                            AND (TravelForceCosmos.dbo.TFEntityDepartments.Name = @VesselName) 
                                            AND (TravelForceCosmos.dbo.TFEntities.Code = @CustCode) 
                                            ORDER BY Name "
    Private Const SQL2 As String = "SELECT [Child_Value] AS Name 
                                             , '' AS Flag 
                                             FROM [Disco_Instone_EU].[dbo].[Costcen] 
                                             LEFT JOIN Company 
                                             ON Costcen.Account_Id=Company.Account_Id 
                                             WHERE Company.Account_Abbriviation =  @CustCode AND Child_Name = 'CC1' AND Child_Value = @VesselName "
    Private Const TextREG As String = " REG "
    Public Overrides Function ToString() As String
        If Flag = "" Then
            Return Name
        Else
            If Not MySettings Is Nothing AndAlso Flag <> "" Then
                Return Name & TextREG & Flag
            Else
                Return Name
            End If
        End If
    End Function
    Public ReadOnly Property Name As String = ""
    Public ReadOnly Property Flag As String = ""
    Public ReadOnly Property Loaded As Boolean = False
    Public Sub New(ByVal pName As String, ByVal pFlag As String)
        If Not MySettings Is Nothing AndAlso pName.ToUpper.Contains(TextREG) Then
            If pFlag.Trim = "" Then
                pFlag = pName.Substring(pName.ToUpper.IndexOf(TextREG) + 6).Trim
                pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TextREG)).Trim
            Else
                pName = (" " & pName).Substring(0, (" " & pName).ToUpper.IndexOf(TextREG)).Trim
            End If
        End If
        Name = pName.Trim
        Flag = pFlag.Trim
        Loaded = True
    End Sub
    Public Sub New(ByVal pCustCode As String, ByVal pVesselName As String, ByVal pBackOffice As Integer)
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@CustCode", SqlDbType.NVarChar, 50).Value = pCustCode
            .Parameters.Add("@VesselName", SqlDbType.NVarChar, 255).Value = pVesselName
            If pBackOffice = 1 Then
                .CommandText = SQL1
            ElseIf pBackOffice = 2 Then
                .CommandText = SQL2
            End If
            pobjReader = .ExecuteReader
        End With

        Loaded = False
        With pobjReader
            If .Read Then
                Name = IsNothingToString(CStr(.Item("Name")))
                Flag = IsNothingToString(CStr(.Item("Flag")))
                Loaded = True
            End If
            .Close()
        End With
        pobjConn.Close()
    End Sub
End Class