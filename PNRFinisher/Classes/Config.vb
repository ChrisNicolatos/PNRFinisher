Option Strict On
Option Explicit On
Public Class Config
    Private Structure ClassProps
        Dim PCCId As Integer
        Dim OfficeCityCode As String
        Dim CountryCode As String
        Dim OfficeName As String
        Dim CityName As String
        Dim Phone As String
        Dim AOHPhone As String
        Dim PCCBackOffice As EnumBOCode
        Dim pCCIATANumber As String
        Dim PCCFormalOfficeName As String
        Dim AgentId As Integer
        Dim AgentQueue As String
        Dim AgentOPQueue As String
        Dim AgentName As String
        Dim AgentEmail As String
        Dim AirportName As Integer
        Dim ShowAirlineLocator As Boolean
        Dim ShowClassOfService As Boolean
        Dim ShowTickets As Boolean
        Dim ShowEMD As Boolean
        Dim ShowPaxSegPerTkt As Boolean
        Dim ShowStopovers As Boolean
        Dim ShowTerminal As Boolean
        Dim ShowFlyingTime As Boolean
        Dim ShowCostCentre As Boolean
        Dim ShowCabinDescription As Boolean
        Dim ShowSeating As Boolean
        Dim ShowVessel As Boolean
        Dim ShowItinRemarks As Boolean
        Dim ShowEquipmentCode As Boolean
        Dim ShowCO2 As Boolean
        Dim Administrator As Boolean
        Dim FormatStyle As EnumItnFormat

        Dim OSMVesselGroup As Integer
        Dim OSMLoGPerPax As Boolean
        Dim OSMLoGOnsigner As Boolean
        Dim OSMLoGPath As String
        Dim OSMLoGLanguage As EnumLoGLanguage
        Dim Location As String
        Dim PriceOptimiser As Boolean
    End Structure

    Private mudtProps As ClassProps
    Private mobjGDSUser As GDSUser
    Private ReadOnly mflgIsDirtyPCC As Boolean
    Private mflgIsDirtyUser As Boolean
    Private mGDSReferences As GDS_BOReferenceCollection
    Public Sub New()
    End Sub
    Public Sub New(mGDSUser As GDSUser)
        Try
            mobjGDSUser = mGDSUser
            mflgIsDirtyPCC = False
            mflgIsDirtyUser = False
            DBReadPCC()
            If PCCId = 0 Then
                If mobjGDSUser.GDSCode = EnumGDSCode.Amadeus Then
                    Throw New Exception("You are signed in to Amadeus PCC : " & mobjGDSUser.PCC & vbCrLf & "This PCC is not registered in the PNR FInisher" & vbCrLf & "Please contact your system administrator")
                ElseIf mobjGDSUser.GDSCode = EnumGDSCode.Galileo Then
                    Throw New Exception("You are signed in to Galileo PCC : " & mobjGDSUser.PCC & vbCrLf & "This PCC is not registered in the PNR FInisher" & vbCrLf & "Please contact your system administrator")
                Else
                    Throw New Exception("You are signed in to PCC : " & mobjGDSUser.PCC & vbCrLf & "This PCC is not registered in the PNR FInisher" & vbCrLf & "Please contact your system administrator")
                End If
            End If
            Dim pReadUser As DialogResult = DialogResult.OK
            Do While pReadUser = DialogResult.OK
                pReadUser = DialogResult.Cancel
                DBReadUser()
                If AgentID = 0 Then
                    Dim pfrm As New frmUser(mGDSUser.GDSCode, mobjGDSUser.PCC, mobjGDSUser.User)
                    pReadUser = pfrm.ShowDialog()
                End If
            Loop
            If AgentID = 0 Then
                If mobjGDSUser.GDSCode = EnumGDSCode.Amadeus Then
                    Throw New Exception("You are signed in to Amadeus PCC : " & mobjGDSUser.PCC & " as user : " & mobjGDSUser.User & vbCrLf & "This user is not registered in the PNR FInisher" & vbCrLf & "Please contact your system administrator")
                ElseIf mobjGDSUser.GDSCode = EnumGDSCode.Galileo Then
                    Throw New Exception("You are signed in to Galileo PCC : " & mobjGDSUser.PCC & " as user : " & mobjGDSUser.User & vbCrLf & "This user is not registered in the PNR FInisher" & vbCrLf & "Please contact your system administrator")
                Else
                    Throw New Exception("You are signed in to PCC : " & mobjGDSUser.PCC & " as user : " & mobjGDSUser.User & vbCrLf & "This user is not registered in the PNR FInisher" & vbCrLf & "Please contact your system administrator")
                End If
            End If
            'LoadGDSReferences(PCCBackOffice, mobjGDSUser.GDSCode)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LoadGDSReferences(ByVal pBackOffice As Integer, ByVal pGDSCode As EnumGDSCode)
        Try
            If mGDSReferences Is Nothing Then
                mGDSReferences = New GDS_BOReferenceCollection
            End If
            mGDSReferences.Read(pBackOffice, pGDSCode)
        Catch ex As Exception
            Throw New Exception("Config.LoadGDSReference()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public ReadOnly Property Administrator As Boolean
        Get
            Return mudtProps.Administrator
        End Get
    End Property
    Public Property FormatStyle As EnumItnFormat
        Get
            Return mudtProps.FormatStyle
        End Get
        Set(value As EnumItnFormat)
            If value <> mudtProps.FormatStyle Then
                mflgIsDirtyUser = True
            End If
            mudtProps.FormatStyle = value
        End Set
    End Property
    Public Property OSMVesselGroup As Integer
        Get
            Return mudtProps.OSMVesselGroup
        End Get
        Set(value As Integer)
            If value <> mudtProps.OSMVesselGroup Then
                mflgIsDirtyUser = True
            End If
            mudtProps.OSMVesselGroup = value
        End Set
    End Property
    Public Property ShowAirlineLocator As Boolean
        Get
            Return mudtProps.ShowAirlineLocator
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowAirlineLocator Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowAirlineLocator = value
        End Set
    End Property
    Public Property ShowClassOfService As Boolean
        Get
            Return mudtProps.ShowClassOfService
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowClassOfService Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowClassOfService = value
        End Set
    End Property
    Public Property ShowTickets As Boolean
        Get
            Return mudtProps.ShowTickets
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowTickets Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowTickets = value
        End Set
    End Property
    Public Property ShowEMD As Boolean
        Get
            Return mudtProps.ShowEMD
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowEMD Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowEMD = value
        End Set
    End Property
    Public Property ShowItinRemarks As Boolean
        Get
            Return mudtProps.ShowItinRemarks
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowItinRemarks Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowItinRemarks = value
        End Set
    End Property
    Public Property ShowEquipmentCode As Boolean
        Get
            Return mudtProps.ShowEquipmentCode
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowEquipmentCode Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowEquipmentCode = value
        End Set
    End Property
    Public Property ShowCO2 As Boolean
        Get
            Return mudtProps.ShowCO2
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowCO2 Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowCO2 = value
        End Set
    End Property
    Public Property ShowPaxSegPerTkt As Boolean
        Get
            Return mudtProps.ShowPaxSegPerTkt
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowPaxSegPerTkt Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowPaxSegPerTkt = value
        End Set
    End Property
    Public Property ShowStopovers As Boolean
        Get
            Return mudtProps.ShowStopovers
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowStopovers Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowStopovers = value
        End Set
    End Property
    Public Property ShowTerminal As Boolean
        Get
            Return mudtProps.ShowTerminal
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowTerminal Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowTerminal = value
        End Set
    End Property
    Public Property ShowFlyingTime As Boolean
        Get
            Return mudtProps.ShowFlyingTime
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowFlyingTime Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowFlyingTime = value
        End Set
    End Property
    Public Property ShowCostCentre As Boolean
        Get
            Return mudtProps.ShowCostCentre
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowCostCentre Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowCostCentre = value
        End Set
    End Property
    Public Property ShowCabinDescription As Boolean
        Get
            Return mudtProps.ShowCabinDescription
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowCabinDescription Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowCabinDescription = value
        End Set
    End Property
    Public Property ShowSeating As Boolean
        Get
            Return mudtProps.ShowSeating
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowSeating Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowSeating = value
        End Set
    End Property
    Public Property ShowVessel As Boolean
        Get
            Return mudtProps.ShowVessel
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowVessel Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowVessel = value
        End Set
    End Property
    Public Property OSMLoGPerPax As Boolean
        Get
            Return mudtProps.OSMLoGPerPax
        End Get
        Set(value As Boolean)
            If value <> mudtProps.OSMLoGPerPax Then
                mflgIsDirtyUser = True
            End If
            mudtProps.OSMLoGPerPax = value
        End Set
    End Property
    Public Property OSMLoGOnSigner As Boolean
        Get
            Return mudtProps.OSMLoGOnsigner
        End Get
        Set(value As Boolean)
            If value <> mudtProps.OSMLoGOnsigner Then
                mflgIsDirtyUser = True
            End If
            mudtProps.OSMLoGOnsigner = value
        End Set
    End Property
    Public Property OSMLoGPath As String
        Get
            Return mudtProps.OSMLoGPath
        End Get
        Set(value As String)
            If value <> mudtProps.OSMLoGPath Then
                mflgIsDirtyUser = True
            End If
            mudtProps.OSMLoGPath = value
        End Set
    End Property
    Public Property OSMLoGLanguage As EnumLoGLanguage
        Get
            Return mudtProps.OSMLoGLanguage
        End Get
        Set(value As EnumLoGLanguage)
            mudtProps.OSMLoGLanguage = value
        End Set
    End Property
    Public ReadOnly Property PCCId As Integer
        Get
            Return mudtProps.PCCId
        End Get
    End Property
    Public ReadOnly Property OfficeCityCode As String
        Get
            Return mudtProps.OfficeCityCode.ToUpper
        End Get
    End Property
    Public Property CountryCode As String
        Get
            Return mudtProps.CountryCode.ToUpper
        End Get
        Set(value As String)
            mudtProps.CountryCode = value.ToUpper
        End Set
    End Property
    Public ReadOnly Property OfficeName As String
        Get
            Return mudtProps.OfficeName.ToUpper
        End Get
    End Property
    Public ReadOnly Property FormalOfficeName As String
        Get
            Return mudtProps.PCCFormalOfficeName
        End Get
    End Property
    Public ReadOnly Property CityName As String
        Get
            Return mudtProps.CityName.ToUpper
        End Get
    End Property
    Public ReadOnly Property Phone As String
        Get
            Return mudtProps.Phone.ToUpper
        End Get
    End Property
    Public ReadOnly Property AOHPhone As String
        Get
            Return mudtProps.AOHPhone.ToUpper
        End Get
    End Property
    Public ReadOnly Property PCCBackOffice As EnumBOCode
        Get
            Return mudtProps.PCCBackOffice
        End Get
    End Property
    Public ReadOnly Property IATANumber As String
        Get
            Return mudtProps.pCCIATANumber
        End Get
    End Property
    Public ReadOnly Property AgentID As Integer
        Get
            Return mudtProps.AgentId
        End Get
    End Property
    Public ReadOnly Property AgentQueue As String
        Get
            Return mudtProps.AgentQueue.ToUpper
        End Get
    End Property
    Public ReadOnly Property AgentOPQueue As String
        Get
            Return mudtProps.AgentOPQueue.ToUpper
        End Get
    End Property
    Public ReadOnly Property AgentName As String
        Get
            Return mudtProps.AgentName.ToUpper
        End Get
    End Property
    Public Property Location As String
        Get
            Return mudtProps.Location
        End Get
        Set(value As String)
            mudtProps.Location = value
        End Set
    End Property
    Public ReadOnly Property PriceOptimiser As Boolean
        Get
            Return mudtProps.PriceOptimiser
        End Get
    End Property
    Public ReadOnly Property AgentEmail As String
        Get
            Return mudtProps.AgentEmail.ToUpper
        End Get
    End Property
    Public Property AirportName As Integer
        Get
            Return mudtProps.AirportName
        End Get
        Set(value As Integer)
            If value <> mudtProps.AirportName Then
                mflgIsDirtyUser = True
            End If
            mudtProps.AirportName = value
        End Set
    End Property

    Public ReadOnly Property GDSPcc As String
        Get
            Return mobjGDSUser.PCC.ToUpper
        End Get
    End Property
    Public ReadOnly Property GDSUser As String
        Get
            Return mobjGDSUser.User.ToUpper
        End Get
    End Property
    Public ReadOnly Property GDSAbbreviation As String
        Get
            Return mobjGDSUser.GDSCodeAbbreviation
        End Get
    End Property
    Private Sub DBReadPCC()

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@PCC", SqlDbType.NVarChar, 9).Value = mobjGDSUser.PCC
            .CommandText = " SELECT pfpId 
                             ,pfpOfficeCityCode  
                             ,pfpCountryCode  
                             ,pfpOfficeName  
                             ,pfpCityName  
                             ,pfpOfficePhone  
                             ,pfpAOHPhone  
                             ,pfpBO_fkey  
                             ,pfpIATANumber  
                             ,pfpFormalOfficeName  
                             FROM [AmadeusReports].[dbo].[PNRFinisherPCC]  
                             WHERE pfpPCC = @PCC"
            pobjReader = .ExecuteReader
        End With
        With pobjReader
            If pobjReader.Read Then
                mudtProps.PCCId = CInt(.Item("pfpId"))
                mudtProps.OfficeCityCode = CStr(.Item("pfpOfficeCityCode"))
                mudtProps.CountryCode = CStr(.Item("pfpCountryCode"))
                mudtProps.OfficeName = CStr(.Item("pfpOfficeName"))
                mudtProps.CityName = CStr(.Item("pfpCityName"))
                mudtProps.Phone = CStr(.Item("pfpOfficePhone"))
                mudtProps.AOHPhone = CStr(.Item("pfpAOHPhone"))
                mudtProps.PCCBackOffice = CType(.Item("pfpBO_fkey"), EnumBOCode)
                mudtProps.pCCIATANumber = CStr(.Item("pfpIATANumber"))
                mudtProps.PCCFormalOfficeName = CStr(.Item("pfpFormalOfficeName"))
            Else
                mudtProps.PCCId = 0
                mudtProps.OfficeCityCode = ""
                mudtProps.CountryCode = ""
                mudtProps.OfficeName = ""
                mudtProps.CityName = ""
                mudtProps.Phone = ""
                mudtProps.AOHPhone = ""
                mudtProps.PCCBackOffice = 0
                mudtProps.pCCIATANumber = ""
                mudtProps.PCCFormalOfficeName = ""
            End If
            .Close()
        End With
        pobjConn.Close()

    End Sub
    Private Sub DBUpdatePCC()

        If mudtProps.PCCId > 0 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@PCCId", SqlDbType.Int).Value = mudtProps.PCCId
                .Parameters.Add("@pfpOfficeCityCode", SqlDbType.NChar, 3).Value = OfficeCityCode
                .Parameters.Add("@pfpCountryCode", SqlDbType.NChar, 2).Value = CountryCode
                .Parameters.Add("@pfpOfficeName", SqlDbType.NVarChar, 254).Value = OfficeName
                .Parameters.Add("@pfpCityName", SqlDbType.NVarChar, 254).Value = CityName
                .Parameters.Add("@pfpOfficePhone", SqlDbType.NVarChar, 254).Value = Phone
                .Parameters.Add("@pfpAOHPhone", SqlDbType.NVarChar, 254).Value = AOHPhone
                .CommandText = " UPDATE [AmadeusReports].[dbo].[PNRFinisherPCC]
                                SET pfpOfficeCityCode =@pfpOfficeCityCode 
                                ,pfpCountryCode =@pfpCountryCode 
                                ,pfpOfficeName =@pfpOfficeName 
                                ,pfpCityName =@pfpCityName 
                                ,pfpOfficePhone =@pfpOfficePhone 
                                ,pfpAOHPhone =@pfpAOHPhone 
                                WHERE pfpId = @PCCId"
            End With
        Else
            Throw New Exception("Cannot update PCC")
        End If
    End Sub
    Private Sub DBUpdateUser()

        If mudtProps.AgentId > 0 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@PCC", SqlDbType.NVarChar, 9).Value = mobjGDSUser.PCC
                .Parameters.Add("@User", SqlDbType.NVarChar, 254).Value = mobjGDSUser.User

                .Parameters.Add("@AgentQueue", SqlDbType.NVarChar, 20).Value = AgentQueue
                .Parameters.Add("@AgentOPQueue", SqlDbType.NVarChar, 20).Value = AgentOPQueue
                .Parameters.Add("@AgentName", SqlDbType.NVarChar, 50).Value = AgentName
                .Parameters.Add("@AgentEmail", SqlDbType.NVarChar, 255).Value = AgentEmail
                .Parameters.Add("@AirportName", SqlDbType.Int).Value = AirportName
                .Parameters.Add("@AirlineLocator", SqlDbType.Bit).Value = If(ShowAirlineLocator, 1, 0)
                .Parameters.Add("@ClassOfService", SqlDbType.Bit).Value = If(ShowClassOfService, 1, 0)
                .Parameters.Add("@ShowEMD", SqlDbType.Bit).Value = If(ShowEMD, 1, 0)
                .Parameters.Add("@PaxSegPerTkt", SqlDbType.Bit).Value = If(ShowPaxSegPerTkt, 1, 0)
                .Parameters.Add("@ShowStopovers", SqlDbType.Bit).Value = If(ShowStopovers, 1, 0)
                .Parameters.Add("@ShowTerminal", SqlDbType.Bit).Value = If(ShowTerminal, 1, 0)
                .Parameters.Add("@FlyingTime", SqlDbType.Bit).Value = If(ShowFlyingTime, 1, 0)
                .Parameters.Add("@CostCentre", SqlDbType.Bit).Value = If(ShowCostCentre, 1, 0)
                .Parameters.Add("@ShowCabinDescription", SqlDbType.Bit).Value = If(ShowCabinDescription, 1, 0)
                .Parameters.Add("@ShowItinRemarks", SqlDbType.Bit).Value = If(ShowItinRemarks, 1, 0)
                .Parameters.Add("@ShowEquipmentCode", SqlDbType.Bit).Value = If(ShowEquipmentCode, 1, 0)
                .Parameters.Add("@Tickets", SqlDbType.Bit).Value = If(ShowTickets, 1, 0)
                .Parameters.Add("@Seating", SqlDbType.Bit).Value = If(ShowSeating, 1, 0)
                .Parameters.Add("@Vessel", SqlDbType.Bit).Value = If(ShowVessel, 1, 0)
                .Parameters.Add("@FormatStyle", SqlDbType.Int).Value = FormatStyle
                .Parameters.Add("@OSMVesselGroup", SqlDbType.Int).Value = OSMVesselGroup
                .Parameters.Add("@OSMLOGPerPax", SqlDbType.Bit).Value = If(OSMLoGPerPax, 1, 0)
                .Parameters.Add("@OSMLOGOnSigner", SqlDbType.Bit).Value = If(OSMLoGOnSigner, 1, 0)
                .Parameters.Add("@OSMLOGPath", SqlDbType.NVarChar, 255).Value = OSMLoGPath
                .CommandText = " UPDATE AmadeusReports.dbo.PNRFinisherUsers
                                  SET pfAgentQueue =  @AgentQueue    
                                     ,pfAgentOPQueue =  @AgentOPQueue   
                                     ,pfAgentName =  @AgentName   
                                     ,pfAgentEmail =  @AgentEmail   
                                     ,pfAirportName = @AirportName  
                                     ,pfAirlineLocator = @AirlineLocator   
                                     ,pfClassOfService = @ClassOfService   
                                     ,pfBanElectricalEquipment = 0
                                     ,pfBrazilText = 0
                                     ,pfUSAText = 0
                                     ,pfShowEMD = @ShowEMD   
                                     ,pfPaxSegPerTkt = @PaxSegPerTkt   
                                     ,pfShowStopovers = @ShowStopovers   
                                     ,pfShowTerminal = @ShowTerminal   
                                     ,pfFlyingTime = @FlyingTime   
                                     ,pfCostCentre = @CostCentre   
                                     ,pfShowCabinDescription = @ShowCabinDescription   
                                     ,pfShowItinRemarks = @ShowItinRemarks   
                                     ,pfShowEquipmentCode = @ShowEquipmentCode   
                                     ,pfTickets = @Tickets   
                                     ,pfSeating = @Seating   
                                     ,pfVessel = @Vessel   
                                     ,pfPlainFormat = 0
                                     ,pfFormatStyle = @FormatStyle  
                                     ,pfOSMVesselGroup =  @OSMVesselGroup  
                                     ,pfOSMLOGPerPax =  @OSMLoGPerPax   
                                     ,pfOSMLOGOnSigner =  @OSMLoGOnSigner   
                                     ,pfOSMLOGPath =   @OSMLoGPath    
                                  WHERE pfPCC = @PCC AND pfUser = @User"
                .ExecuteNonQuery()
            End With
            pobjConn.Close()
        Else
            Throw New Exception("Cannot update User")
        End If
    End Sub
    Private Sub DBReadUser()

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader
        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@PCC", SqlDbType.NVarChar, 9).Value = mobjGDSUser.PCC
            .Parameters.Add("@User", SqlDbType.NVarChar, 254).Value = mobjGDSUser.User
            .CommandText = " SELECT [pfID] 
                                  ,[pfPCC] 
                                  ,[pfUser] 
                                  ,[pfAgentQueue] 
                                  ,[pfAgentOPQueue] 
                                  ,[pfAgentName] 
                                  ,[pfAgentEmail] 
                                  ,[pfAirportName] 
                                  ,[pfAirlineLocator] 
                                  ,[pfClassOfService] 
                                  ,[pfTickets] 
                                  ,[pfPaxSegPerTkt] 
                                  ,[pfShowStopovers] 
                                  ,[pfShowTerminal] 
                                  ,[pfFlyingTime] 
                                  ,[pfCostCentre] 
                                  ,[pfSeating] 
                                  ,[pfVessel] 
                                  ,[pfPlainFormat] 
                                  ,[pfAdministrator] 
                                  ,[pfFormatStyle] 
                                  ,ISNULL(pfOSMVesselGroup,0) AS pfOSMVesselGroup 
                                  ,ISNULL(pfOSMLOGPerPax,0) AS pfOSMLOGPerPax 
                                  ,ISNULL(pfOSMLOGOnSigner,0) AS pfOSMLOGOnSigner 
                                  ,ISNULL(pfOSMLOGPath,'') AS pfOSMLOGPath 
                                  ,ISNULL(pfnLocation,'') AS pfnLocation 
                                  ,ISNULL(pfnPriceOptimiser,0) AS pfnPriceOptimiser 
                                  ,ISNULL(pfShowCabinDescription,0) AS pfShowCabinDescription 
                                  ,ISNULL(pfShowItinRemarks, 0) AS pfShowItinRemarks 
                                  ,ISNULL(pfShowEMD, 0) AS pfShowEMD 
                                  ,ISNULL(pfShowEquipmentCode,0) AS pfShowEquipmentCode 
                              FROM [AmadeusReports].[dbo].[PNRFinisherUsers] 
                              LEFT JOIN [AmadeusReports].[dbo].[PNRFinisherUserName] ON pfnID = pfUserName_fk 
                              WHERE pfPCC = @PCC AND pfUser = @User"
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            If pobjReader.Read Then
                mudtProps.AgentId = CInt(.Item("pfID"))
                mudtProps.AgentQueue = CStr(.Item("pfAgentQueue"))
                mudtProps.AgentOPQueue = CStr(.Item("pfAgentOPQueue"))
                mudtProps.AgentName = CStr(.Item("pfAgentName"))
                mudtProps.AgentEmail = CStr(.Item("pfAgentEmail"))
                mudtProps.AirportName = CInt(.Item("pfAirportName"))
                mudtProps.ShowAirlineLocator = CBool(.Item("pfAirlineLocator"))
                mudtProps.ShowClassOfService = CBool(.Item("pfClassOfService"))
                mudtProps.ShowTickets = CBool(.Item("pfTickets"))
                mudtProps.ShowEMD = CBool(.Item("pfShowEMD"))
                mudtProps.ShowPaxSegPerTkt = CBool(.Item("pfPaxSegPerTkt"))
                mudtProps.ShowStopovers = CBool(.Item("pfShowStopovers"))
                mudtProps.ShowTerminal = CBool(.Item("pfShowTerminal"))
                mudtProps.ShowFlyingTime = CBool(.Item("pfFlyingTime"))
                mudtProps.ShowCostCentre = CBool(.Item("pfCostCentre"))
                mudtProps.ShowCabinDescription = CBool(.Item("pfShowCabinDescription"))
                mudtProps.ShowItinRemarks = CBool(.Item("pfShowItinRemarks"))
                mudtProps.ShowEquipmentCode = CBool(.Item("pfShowEquipmentCode"))
                mudtProps.ShowSeating = CBool(.Item("pfSeating"))
                mudtProps.ShowVessel = CBool(.Item("pfVessel"))
                mudtProps.Administrator = CBool(.Item("pfAdministrator"))
                mudtProps.FormatStyle = CType(.Item("pfFormatStyle"), EnumItnFormat)
                mudtProps.OSMVesselGroup = CInt(.Item("pfOSMVesselGroup"))
                mudtProps.OSMLoGPerPax = CBool(.Item("pfOSMLOGPerPax"))
                mudtProps.OSMLoGOnsigner = CBool(.Item("pfOSMLOGOnSigner"))
                mudtProps.OSMLoGPath = CStr(.Item("pfOSMLOGPath"))
                'mudtProps.LastVersionTextShown = 0 ' .Item("pfLastVersionTextShown_fk")
                mudtProps.OSMLoGLanguage = EnumLoGLanguage.English
                mudtProps.Location = CStr(.Item("pfnLocation"))
                mudtProps.PriceOptimiser = CBool(.Item("pfnPriceOptimiser"))
            Else
                mudtProps.AgentId = 0
                mudtProps.AgentQueue = ""
                mudtProps.AgentOPQueue = ""
                mudtProps.AgentName = ""
                mudtProps.AgentEmail = ""
                mudtProps.AirportName = 0
                mudtProps.ShowAirlineLocator = False
                mudtProps.ShowClassOfService = False
                mudtProps.ShowTickets = False
                mudtProps.ShowEMD = False
                mudtProps.ShowPaxSegPerTkt = False
                mudtProps.ShowStopovers = False
                mudtProps.ShowTerminal = False
                mudtProps.ShowFlyingTime = False
                mudtProps.ShowCostCentre = False
                mudtProps.ShowEquipmentCode = False
                mudtProps.ShowCO2 = False
                mudtProps.ShowCabinDescription = False
                mudtProps.ShowItinRemarks = False
                mudtProps.ShowSeating = False
                mudtProps.ShowVessel = False
                mudtProps.Administrator = False
                mudtProps.FormatStyle = 0
                'mudtProps.LastVersionTextShown = 0
                mudtProps.OSMVesselGroup = 0
                mudtProps.OSMLoGPerPax = False
                mudtProps.OSMLoGOnsigner = False
                mudtProps.OSMLoGPath = ""
                mudtProps.OSMLoGLanguage = EnumLoGLanguage.English
                mudtProps.Location = ""
                mudtProps.PriceOptimiser = False
            End If
            .Close()
        End With
        pobjConn.Close()
    End Sub
    Public Sub Save()
        Try
            If mflgIsDirtyPCC Then
                DBUpdatePCC()
            End If
            If mflgIsDirtyUser Then
                DBUpdateUser()
            End If
        Catch ex As Exception
            Throw New Exception("Config.Save()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public ReadOnly Property GDSValue(ByVal pBackOffice As Integer, ByVal Key As String) As String
        Get
            Try
                If mGDSReferences Is Nothing OrElse pBackOffice <> mGDSReferences.BackOffice Then
                    LoadGDSReferences(pBackOffice, mobjGDSUser.GDSCode)
                End If
                If mGDSReferences.ContainsKey(Key) Then
                    Return ConvertGDSValue(mGDSReferences.Item(Key).Value)
                Else
                    Return ""
                End If
            Catch ex As Exception
                Throw New Exception("Key:" & Key & " not found in the collection")
            End Try
        End Get
    End Property
    Public ReadOnly Property GDSElement(ByVal pBackOffice As Integer, ByVal Key As String) As String
        Get
            Try
                If mGDSReferences Is Nothing OrElse pBackOffice <> mGDSReferences.BackOffice Then
                    LoadGDSReferences(pBackOffice, mobjGDSUser.GDSCode)
                End If
                Return ConvertGDSValue(mGDSReferences.Item(Key).Element)
            Catch ex As Exception
                Throw New Exception("Key:" & Key & " not found in the collection")
            End Try
        End Get
    End Property
    Public Function ConvertGDSValue(ByVal ValueToConvert As String) As String

        ' "CountryCode"           ' %MID%
        ' "OfficePCC"             ' %PCC%
        ' "AgentQueue"            ' %AGENTQ%
        ' "AgentOPQueue"          ' %AGENTOPQ%
        ' "AgentName"             ' %AGENTNAME%
        ' "AgentEmail"            ' %AGENTEMAIL%
        ' "OfficeCityCode"        ' %CITYCODE%
        ' "AOHPhone"              ' %AOHP%
        ' "Phone"                 ' %PHONE%
        ' "AgentID"               ' %AgentID%
        ' "CityName"              ' %CITYNAME%
        ' GalileoTrackingCode     ' %GALTRACK%

        If ValueToConvert.IndexOf("%") >= 0 Then
            If AgentQueue.IndexOf("/") >= 0 Then
                ValueToConvert = ReplaceReference(ValueToConvert, "%PCC-AGENTQ%", "/" & AgentQueue)
                ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTQ%", "/" & AgentQueue)
            ElseIf AgentQueue.IndexOf("*") > 0 Then
                Dim pQueue As String = AgentQueue.Substring(0, AgentQueue.IndexOf("*"))
                ValueToConvert = ReplaceReference(ValueToConvert, "%PCC-AGENTQ%", mobjGDSUser.PCC & "/" & pQueue)
                ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTQ%", pQueue)
            Else
                ValueToConvert = ReplaceReference(ValueToConvert, "%PCC-AGENTQ%", mobjGDSUser.PCC & "/" & AgentQueue)
                ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTQ%", AgentQueue)
            End If
            If AgentOPQueue.IndexOf("/") >= 0 Then
                ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTOPQ%", "/" & AgentOPQueue)
            Else
                ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTOPQ%", AgentOPQueue)
            End If
            Do While ValueToConvert.IndexOf("//") >= 0
                ValueToConvert.Replace("//", "/")
            Loop
            ValueToConvert = ReplaceReference(ValueToConvert, "%PCC%", mobjGDSUser.PCC)
            ValueToConvert = ReplaceReference(ValueToConvert, "%AgentID%", mobjGDSUser.User)
            ValueToConvert = ReplaceReference(ValueToConvert, "%MID%", CountryCode)
            ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTNAME%", AgentName)
            ValueToConvert = ReplaceReference(ValueToConvert, "%AGENTEMAIL%", AgentEmail)
            ValueToConvert = ReplaceReference(ValueToConvert, "%CITYCODE%", OfficeCityCode)
            ValueToConvert = ReplaceReference(ValueToConvert, "%CITYNAME%", CityName)
            ValueToConvert = ReplaceReference(ValueToConvert, "%AOHP%", AOHPhone)
            ValueToConvert = ReplaceReference(ValueToConvert, "%PHONE%", Phone)
            ValueToConvert = ReplaceReference(ValueToConvert, "%OFFICENAME%", OfficeName)
        End If
        Return ValueToConvert

    End Function
    Public ReadOnly Property isValid As Boolean
        Get
            With mudtProps
                Return mobjGDSUser.PCC <> "" And
                          mobjGDSUser.User <> "" And
                          .AgentQueue <> "" And
                          .AgentOPQueue <> "" And
                          .CountryCode <> "" And
                          .AgentName <> "" And
                          .AgentEmail <> "" And
                          .OfficeCityCode <> "" And
                          .CityName <> "" And
                          .OfficeName <> "" And
                          .AOHPhone <> "" And
                          .PCCBackOffice <> 0 And
                          .Phone <> ""
            End With
        End Get
    End Property
    Private Shared Function ReplaceReference(ByVal InputValue As String, ByVal RefKey As String, ByVal RefValue As String) As String
        If InputValue.IndexOf(RefKey) >= 0 Then
            Return InputValue.Replace(RefKey, RefValue)
        Else
            Return InputValue
        End If
    End Function
End Class
