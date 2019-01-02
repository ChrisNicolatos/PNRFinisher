﻿Option Strict On
Option Explicit On
Friend Class Config
    Private Structure ClassProps
        Dim PCCId As Integer
        Dim OfficeCityCode As String
        Dim CountryCode As String
        Dim OfficeName As String
        Dim CityName As String
        Dim Phone As String
        Dim AOHPhone As String
        Dim PCCBackOffice As Integer
        Dim pCCDBDataSource As String
        Dim pCCDBInitialCatalog As String
        Dim pCCDBUserId As String
        Dim pCCDBUserPassword As String
        Dim pCCDBBranchCode As String
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
        Dim ShowitinRemarks As Boolean
        Dim Administrator As Boolean
        Dim FormatStyle As EnumItnFormat
        Dim LastVersionTextShown As Integer
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
    Private mflgIsDirtyPCC As Boolean
    Private mflgIsDirtyUser As Boolean
    Private mGDSReferences As New ConfigGDSReferenceCollection
    Public Sub New()

    End Sub
    Public Sub New(mGDSUser As GDSUser)
        Try
            mobjGDSUser = mGDSUser
            mflgIsDirtyPCC = False
            mflgIsDirtyUser = False
            mGDSReferences.Clear()
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
            mGDSReferences.Read(PCCBackOffice, mobjGDSUser.GDSCode)

        Catch ex As Exception
            Throw New Exception(ex.Message)
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
            Return mudtProps.ShowitinRemarks
        End Get
        Set(value As Boolean)
            If value <> mudtProps.ShowitinRemarks Then
                mflgIsDirtyUser = True
            End If
            mudtProps.ShowitinRemarks = value
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
    Public ReadOnly Property CountryCode As String
        Get
            Return mudtProps.CountryCode.ToUpper
        End Get
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
    Public ReadOnly Property PCCBackOffice As Integer
        Get
            Return mudtProps.PCCBackOffice
        End Get
    End Property
    Public ReadOnly Property PCCDBDataSource As String
        Get
            Return mudtProps.pCCDBDataSource
        End Get
    End Property
    Public ReadOnly Property PCCDBInitialCatalog As String
        Get
            Return mudtProps.pCCDBInitialCatalog
        End Get
    End Property
    Public ReadOnly Property PCCDBUserId As String
        Get
            Return mudtProps.pCCDBUserId
        End Get
    End Property

    Public ReadOnly Property PCCDBUserPassword As String
        Get
            Return mudtProps.pCCDBUserPassword
        End Get
    End Property
    Public ReadOnly Property PCCBranchCode As String
        Get
            Return mudtProps.pCCDBBranchCode
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

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR) ' ActiveConnection)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@PCC", SqlDbType.NVarChar, 9).Value = mobjGDSUser.PCC
            .CommandText = " SELECT pfpId " &
                           " ,pfpOfficeCityCode " &
                           " ,pfpCountryCode " &
                           " ,pfpOfficeName " &
                           " ,pfpCityName " &
                           " ,pfpOfficePhone " &
                           " ,pfpAOHPhone " &
                           " ,pfpBO_fkey " &
                           " ,coalesce(pfrBODBDataSource,'') AS pfpDBDataSource " &
                           " ,coalesce(pfrBODBInitialCatalog, '') AS pfpDBInitialCatalog " &
                           " ,coalesce(pfrBODBUserId, '') AS pfpDBUserId " &
                           " ,coalesce(pfrBODBUserPassword, '') AS pfpDBUserPassword " &
                           " ,coalesce(pfrBODBBranchCode, '') AS pfrBODBBranchCode " &
                           " ,pfpIATANumber " &
                           " ,pfpFormalOfficeName " &
                           " FROM [AmadeusReports].[dbo].[PNRFinisherPCC] " &
                           " LEFT JOIN AmadeusReports.dbo.PNRFinisherBackOffice " &
                           " ON pfpBO_fkey = pfrBOId " &
                           " WHERE pfpPCC = @PCC"

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
                mudtProps.PCCBackOffice = CInt(.Item("pfpBO_fkey"))
                mudtProps.pCCDBDataSource = CStr(.Item("pfpDBDataSource"))
                mudtProps.pCCDBInitialCatalog = CStr(.Item("pfpDBInitialCatalog"))
                mudtProps.pCCDBUserId = CStr(.Item("pfpDBUserId"))
                mudtProps.pCCDBUserPassword = CStr(.Item("pfpDBUserPassword"))
                mudtProps.pCCDBBranchCode = CStr(.Item("pfrBODBBranchCode"))
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
                mudtProps.pCCDBDataSource = ""
                mudtProps.pCCDBInitialCatalog = ""
                mudtProps.pCCDBUserId = ""
                mudtProps.pCCDBUserPassword = ""
                mudtProps.pCCDBBranchCode = ""
                mudtProps.pCCIATANumber = ""
                mudtProps.PCCFormalOfficeName = ""
            End If
            .Close()
        End With
        pobjConn.Close()

    End Sub
    Private Sub DBUpdatePCC()

        If mudtProps.PCCId > 0 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR) ' ActiveConnection)
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
                .CommandText = " UPDATE [AmadeusReports].[dbo].[PNRFinisherPCC]" &
                               "  SET pfpOfficeCityCode =@pfpOfficeCityCode " &
                               " ,pfpCountryCode =@pfpCountryCode " &
                               " ,pfpOfficeName =@pfpOfficeName " &
                               " ,pfpCityName =@pfpCityName " &
                               " ,pfpOfficePhone =@pfpOfficePhone " &
                               " ,pfpAOHPhone =@pfpAOHPhone " &
                               " WHERE pfpId = @PCCId"
            End With
        Else
            Throw New Exception("Cannot update PCC")
        End If
    End Sub
    Private Sub DBUpdateUser()

        If mudtProps.AgentId > 0 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = " UPDATE AmadeusReports.dbo.PNRFinisherUsers" &
                               "  SET pfAgentQueue ='" & AgentQueue & "'" &
                               "     ,pfAgentOPQueue ='" & AgentOPQueue & "'" &
                               "     ,pfAgentName ='" & AgentName & "'" &
                               "     ,pfAgentEmail ='" & AgentEmail & "'" &
                               "     ,pfAirportName =" & AirportName &
                               "     ,pfAirlineLocator =" & If(ShowAirlineLocator, 1, 0) &
                               "     ,pfClassOfService =" & If(ShowClassOfService, 1, 0) &
                               "     ,pfBanElectricalEquipment = 0" &
                               "     ,pfBrazilText = 0" &
                               "     ,pfUSAText = 0" &
                               "     ,pfShowEMD =" & If(ShowEMD, 1, 0) &
                               "     ,pfPaxSegPerTkt =" & If(ShowPaxSegPerTkt, 1, 0) &
                               "     ,pfShowStopovers =" & If(ShowStopovers, 1, 0) &
                               "     ,pfShowTerminal =" & If(ShowTerminal, 1, 0) &
                               "     ,pfFlyingTime =" & If(ShowFlyingTime, 1, 0) &
                               "     ,pfCostCentre =" & If(ShowCostCentre, 1, 0) &
                               "     ,pfShowCabinDescription =" & If(ShowCabinDescription, 1, 0) &
                               "     ,pfShowItinRemarks =" & If(ShowItinRemarks, 1, 0) &
                               "     ,pfTickets =" & If(ShowTickets, 1, 0) &
                               "     ,pfSeating =" & If(ShowSeating, 1, 0) &
                               "     ,pfVessel =" & If(ShowVessel, 1, 0) &
                               "     ,pfPlainFormat = 0" &
                               "     ,pfFormatStyle =" & FormatStyle &
                               "     ,pfOSMVesselGroup = " & OSMVesselGroup &
                               "     ,pfOSMLOGPerPax = " & If(OSMLoGPerPax, 1, 0) &
                               "     ,pfOSMLOGOnSigner = " & If(OSMLoGOnSigner, 1, 0) &
                               "     ,pfOSMLOGPath = '" & OSMLoGPath & "' " &
                               "   WHERE pfPCC = '" & mobjGDSUser.PCC & "' AND pfUser = '" & mobjGDSUser.User & "'"
                .ExecuteNonQuery()
            End With
            pobjConn.Close()
        Else
            Throw New Exception("Cannot update User")
        End If
    End Sub
    Private Sub DBReadUser()

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR) ' ActiveConnection)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .CommandText = " SELECT [pfID] " &
                           "       ,[pfPCC] " &
                           "       ,[pfUser] " &
                           "       ,[pfAgentQueue] " &
                           "       ,[pfAgentOPQueue] " &
                           "       ,[pfAgentName] " &
                           "       ,[pfAgentEmail] " &
                           "       ,[pfAirportName] " &
                           "       ,[pfAirlineLocator] " &
                           "       ,[pfClassOfService] " &
                           "       ,[pfTickets] " &
                           "       ,[pfPaxSegPerTkt] " &
                           "       ,[pfShowStopovers] " &
                           "       ,[pfShowTerminal] " &
                           "       ,[pfFlyingTime] " &
                           "       ,[pfCostCentre] " &
                           "       ,[pfSeating] " &
                           "       ,[pfVessel] " &
                           "       ,[pfPlainFormat] " &
                           "       ,[pfAdministrator] " &
                           "       ,[pfFormatStyle] " &
                           "       ,ISNULL(pfOSMVesselGroup,0) AS pfOSMVesselGroup " &
                           "       ,ISNULL(pfOSMLOGPerPax,0) AS pfOSMLOGPerPax " &
                           "       ,ISNULL(pfOSMLOGOnSigner,0) AS pfOSMLOGOnSigner " &
                           "       ,ISNULL(pfOSMLOGPath,'') AS pfOSMLOGPath " &
                           "       ,ISNULL(pfnLocation,'') AS pfnLocation " &
                           "       ,ISNULL(pfnPriceOptimiser,0) AS pfnPriceOptimiser " &
                           "       ,ISNULL(pfShowCabinDescription,0) AS pfShowCabinDescription " &
                           "       ,ISNULL(pfShowItinRemarks, 0) AS pfShowItinRemarks " &
                           "       ,ISNULL(pfShowEMD, 0) AS pfShowEMD " &
                           "   FROM [AmadeusReports].[dbo].[PNRFinisherUsers] " &
                           "   LEFT JOIN [AmadeusReports].[dbo].[PNRFinisherUserName] ON pfnID = pfUserName_fk " &
                           "   WHERE pfPCC = '" & mobjGDSUser.PCC & "' AND pfUser = '" & mobjGDSUser.User & "'"
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
                mudtProps.ShowitinRemarks = CBool(.Item("pfShowItinRemarks"))
                mudtProps.ShowSeating = CBool(.Item("pfSeating"))
                mudtProps.ShowVessel = CBool(.Item("pfVessel"))
                mudtProps.Administrator = CBool(.Item("pfAdministrator"))
                mudtProps.FormatStyle = CType(.Item("pfFormatStyle"), EnumItnFormat)
                mudtProps.OSMVesselGroup = CInt(.Item("pfOSMVesselGroup"))
                mudtProps.OSMLoGPerPax = CBool(.Item("pfOSMLOGPerPax"))
                mudtProps.OSMLoGOnsigner = CBool(.Item("pfOSMLOGOnSigner"))
                mudtProps.OSMLoGPath = CStr(.Item("pfOSMLOGPath"))
                mudtProps.LastVersionTextShown = 0 ' .Item("pfLastVersionTextShown_fk")
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
                mudtProps.ShowCabinDescription = False
                mudtProps.ShowitinRemarks = False
                mudtProps.ShowSeating = False
                mudtProps.ShowVessel = False
                mudtProps.Administrator = False
                mudtProps.FormatStyle = 0
                mudtProps.LastVersionTextShown = 0
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
    Public ReadOnly Property GDSValue(ByVal Key As String) As String
        Get
            Try
                Return ConvertGDSValue(mGDSReferences.Item(Key).Value)
            Catch ex As Exception
                Throw New Exception("Key:" & Key & " not found in the collection")
            End Try
        End Get

    End Property
    Public ReadOnly Property GDSElement(ByVal Key As String) As String
        Get
            Try
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

        ConvertGDSValue = ValueToConvert

        If ConvertGDSValue.IndexOf("%") >= 0 Then
            If AgentQueue.IndexOf("/") >= 0 Then
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%PCC-AGENTQ%", "/" & AgentQueue)
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTQ%", "/" & AgentQueue)
            ElseIf AgentQueue.IndexOf("*") > 0 Then
                Dim pQueue As String = AgentQueue.Substring(0, AgentQueue.IndexOf("*"))
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%PCC-AGENTQ%", mobjGDSUser.PCC & "/" & pQueue)
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTQ%", pQueue)
            Else
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%PCC-AGENTQ%", mobjGDSUser.PCC & "/" & AgentQueue)
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTQ%", AgentQueue)
            End If
            If AgentOPQueue.IndexOf("/") >= 0 Then
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTOPQ%", "/" & AgentOPQueue)
            Else
                ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTOPQ%", AgentOPQueue)
            End If
            Do While ConvertGDSValue.IndexOf("//") >= 0
                ConvertGDSValue.Replace("//", "/")
            Loop
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%PCC%", mobjGDSUser.PCC)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AgentID%", mobjGDSUser.User)

            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%MID%", CountryCode)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTNAME%", AgentName)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AGENTEMAIL%", AgentEmail)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%CITYCODE%", OfficeCityCode)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%CITYNAME%", CityName)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%AOHP%", AOHPhone)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%PHONE%", Phone)
            ConvertGDSValue = ReplaceReference(ConvertGDSValue, "%OFFICENAME%", OfficeName)

        End If

    End Function
    Public ReadOnly Property isValid As Boolean
        Get
            With mudtProps
                isValid = mobjGDSUser.PCC <> "" And
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
                          .pCCDBDataSource <> "" And
                          .pCCDBInitialCatalog <> "" And
                          .pCCDBUserId <> "" And
                          .pCCDBUserPassword <> "" And
                          .Phone <> ""
            End With
        End Get
    End Property

    Private Function ReplaceReference(ByVal InputValue As String, ByVal RefKey As String, ByVal RefValue As String) As String
        If InputValue.IndexOf(RefKey) >= 0 Then
            Return InputValue.Replace(RefKey, RefValue)
        Else
            Return InputValue
        End If
    End Function
End Class
