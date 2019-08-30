Option Strict On
Option Explicit On
Imports System.IO
Imports System.Text
Public NotInheritable Class UtilitiesDB
    '
    ' Prepares the SQL connection string for the Travel Force Cosmos database
    '
    ' The SQL connection string for the Travel Force Cosmos database
    ' Returns the connection string to be used for SQLConnection
    ' The options for the connection string are bound to the application and cannot be modified by the user
    ' 

    Private Const mstrDBConnectionsFileGT As String = "\\192.168.102.223\Common\Click-Once Applications\PNR Finisher ATH V2\Config\PNRFinisher.txt"
    Private Const mstrDBConnectionsFile As String = "\\192.168.102.223\Common\Click-Once Applications\PNR Finisher ATH V2\Config\PNRFinisher.txt"
    Private Const msrtConfigFolder As String = "\\192.168.102.223\Common\Click-Once Applications\PNR Finisher ATH V2\Config"
    Private Shared mstrDBConnectionFileActual As String

    Private Shared mobjPNRConnection As New BackOfficeItem
    Private Shared mobjBackOffice As New BackOfficeCollection
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property PNRDataSource As String
        Get
            Return mobjPNRConnection.DataSource
        End Get
    End Property
    Public Shared ReadOnly Property PNRInitialCatalog As String
        Get
            Return mobjPNRConnection.InitialCatalog
        End Get
    End Property
    Public Shared ReadOnly Property PNRUserID As String
        Get
            Return mobjPNRConnection.UserId
        End Get
    End Property
    Public Shared ReadOnly Property MyConfigPath As String
        Get
            Return msrtConfigFolder
        End Get
    End Property
    Public Shared ReadOnly Property DBConnectionsFile As String
        Get
            Return mstrDBConnectionFileActual
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionStringPNR() As String
        Get
            If mobjPNRConnection.DataSource = "" Then
                ReadDBConnections()
            End If
            Return "Data Source=" & mobjPNRConnection.DataSource & ";Initial Catalog=" & mobjPNRConnection.InitialCatalog & ";User ID=" & mobjPNRConnection.UserId & ";Password=" & mobjPNRConnection.UserPassword
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionString(ByVal pBackOffice As Integer) As String
        Get
            Try
                If UtilitiesDB.BackOfficeDB(pBackOffice) Is Nothing Then
                    ReadDBConnections()
                End If
                With UtilitiesDB.BackOfficeDB(pBackOffice)
                    Return "Data Source=" & .DataSource & ";Initial Catalog=" & .InitialCatalog & ";User ID=" & .UserId & ";Password=" & .UserPassword
                End With
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property ConnectionString(ByVal DBName As String) As String
        Get
            Try
                If UtilitiesDB.BackOfficeDB(DBName) Is Nothing Then
                    ReadDBConnections()
                End If
                With UtilitiesDB.BackOfficeDB(DBName)
                    Return "Data Source=" & .DataSource & ";Initial Catalog=" & .InitialCatalog & ";User ID=" & .UserId & ";Password=" & .UserPassword
                End With
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Private Shared Sub ReadDBConnections()

        Dim pDataSource As String = ""
        Dim pDataCatalog As String = ""
        Dim pUserName As String = ""
        Dim pPassword As String = ""
        Dim pFileExists As Boolean = False

        If File.Exists(mstrDBConnectionsFile) Then
            mstrDBConnectionFileActual = mstrDBConnectionsFile
            pFileExists = True
        ElseIf File.Exists(mstrDBConnectionsFileGT) Then
            mstrDBConnectionFileActual = mstrDBConnectionsFileGT
            pFileExists = True
        End If

        If pFileExists Then
            Dim GDSData As StreamReader = File.OpenText(mstrDBConnectionFileActual)
            Dim xLine() As String = Split(GDSData.ReadToEnd, vbCrLf)
            GDSData.Close()
            If IsArray(xLine) Then
                For i As Integer = xLine.GetLowerBound(0) To xLine.GetUpperBound(0)
                    Dim pValues() As String = xLine(i).Split("="c)
                    Select Case pValues(0).Trim.ToUpper
                        Case "DATASOURCEPNR"
                            pDataSource = pValues(1).Trim
                        Case "DATACATALOGPNR"
                            pDataCatalog = pValues(1).Trim
                        Case "DATAUSERNAMEPNR"
                            pUserName = pValues(1).Trim
                        Case "DATAUSERPASSWORDPNR"
                            pPassword = pValues(1).Trim
                    End Select
                Next
                mobjPNRConnection.SetValues(0, "PNR", pDataSource, pDataCatalog, pUserName, pPassword, "")
                mobjBackOffice.Load(0)
                'GetTWS_MISCredentials()
            Else
                Throw New Exception("Settings File Error" & vbCrLf & mstrDBConnectionFileActual)
            End If
        Else
            Throw New Exception("DB Connection file does not exist. Please contact you system administrator" & vbCrLf & mstrDBConnectionFileActual)
        End If

    End Sub
    Public Shared ReadOnly Property BackOfficeDB(ByVal BOName As String) As BackOfficeItem
        Get
            Return mobjBackOffice.Load(BOName)
        End Get
    End Property
    Public Shared ReadOnly Property BackOfficeDB(ByVal BOId As Integer) As BackOfficeItem
        Get
            Return mobjBackOffice.Load(BOId)
        End Get
    End Property
    Public Shared ReadOnly Property BackOfficeDB As BackOfficeCollection
        Get
            Return mobjBackOffice
        End Get
    End Property
End Class
