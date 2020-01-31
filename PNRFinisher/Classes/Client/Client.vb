Option Strict On
Option Explicit On
Public Class Client
    Private mobjClientReferences As ClientReferenceCollection
    Private mflgClientReferences As Boolean = False
    Private mobjAlerts As AlertsCollection
    Public Overrides Function ToString() As String
        If CTCCount > 0 Then
            Return Code & " " & Logo & " ==>"
        Else
            Return Code & " " & Logo
        End If
    End Function

    Public ReadOnly Property ID As Integer = 0
    Public ReadOnly Property Code As String = ""
    Public ReadOnly Property Name As String = ""
    Public ReadOnly Property Logo As String = ""
    Public ReadOnly Property EntityKindLT As Integer = 0
    Public ReadOnly Property OpsGroup As String = ""
    Public ReadOnly Property CTCCount As Integer = 0
    Public ReadOnly Property HasVessels As Boolean = False
    Public ReadOnly Property HasDepartments As Boolean = False
    Public ReadOnly Property AlertForFinisher As String
        Get
            If mobjAlerts Is Nothing Then
                mobjAlerts = New AlertsCollection
            End If
            Return mobjAlerts.AlertForFinisher(BackOffice, Code)
        End Get
    End Property
    Public ReadOnly Property AlertForDownsell As String
        Get
            If Not mobjAlerts Is Nothing Then
                mobjAlerts = New AlertsCollection
            End If
            Return mobjAlerts.AlertForDownsell(BackOffice, Code)
        End Get
    End Property
    Public ReadOnly Property GalileoTrackingCode As String = ""
    Private ReadOnly Property BackOffice As Integer = 0
    Public ReadOnly Property ClientReferences As ClientReferenceCollection
        Get
            If Not mflgClientReferences Then
                mobjClientReferences = New ClientReferenceCollection(ID, BackOffice)
                mflgClientReferences = True
            End If
            Return mobjClientReferences
        End Get
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal pBackOffice As Integer, ByVal pData As SqlClient.SqlDataReader)

        ID = CInt(pData.Item("Id"))
        Code = CStr(pData.Item("Code"))
        Name = CStr(pData.Item("Name"))
        Logo = CStr(pData.Item("Logo"))
        EntityKindLT = CInt(pData.Item("TFEntityKindLT"))
        GalileoTrackingCode = CStr(pData.Item("GalileoTrackingCode"))
        OpsGroup = CStr(pData.Item("OpsGroup"))
        CTCCount = CInt(pData.Item("CTCCount"))
        BackOffice = pBackOffice
        ' TFEntityKind (from DB table [TravelForceCosmos].[dbo].[LookupTable])
        ' 404 = Other
        ' 405 = Individual
        ' 406 = Corporate
        ' 526 = Shipping Co
        ' 527 = Travel Agency
        Select Case EntityKindLT
            Case 526, 527
                HasDepartments = True
                HasVessels = True
            Case Else
                HasDepartments = False
                HasVessels = False
        End Select
    End Sub
    Public Sub New(ByVal pID As Integer, ByVal pCode As String, ByVal pName As String, ByVal pLogo As String, ByVal pEntityKindLT As Integer, ByVal pAlertForFinisher As String, ByVal pAlertForDownsell As String, ByVal pGalileoTrackingCode As String, ByVal pOpsGroup As String, ByVal pCTCCount As Integer, ByVal pBackOffice As Integer)
        ID = pID
        Code = pCode
        Name = pName
        Logo = pLogo
        EntityKindLT = pEntityKindLT
        'AlertForFinisher = pAlertForFinisher.Trim
        'AlertForDownsell = pAlertForDownsell.Trim
        GalileoTrackingCode = pGalileoTrackingCode
        OpsGroup = pOpsGroup
        CTCCount = pCTCCount
        BackOffice = pBackOffice
        ' TFEntityKind (from DB table [TravelForceCosmos].[dbo].[LookupTable])
        ' 404 = Other
        ' 405 = Individual
        ' 406 = Corporate
        ' 526 = Shipping Co
        ' 527 = Travel Agency
        Select Case pEntityKindLT
            Case 526, 527
                HasDepartments = True
                HasVessels = True
            Case Else
                HasDepartments = False
                HasVessels = False
        End Select
    End Sub

End Class
