Option Strict On
Option Explicit On
Public Class BackOfficeItem
    Private Structure ClassProps
        Dim ID As Integer
        Dim BOName As String
        Dim DataSource As String
        Dim InitialCatalog As String
        Dim UserId As String
        Dim UserPassword As String
        Dim BranchCode As String
    End Structure
    Private mudtProps As ClassProps
    Public Sub New()
        With mudtProps
            .ID = 0
            .BOName = ""
            .DataSource = ""
            .InitialCatalog = ""
            .UserId = ""
            .UserPassword = ""
            .BranchCode = ""
        End With
    End Sub
    Public ReadOnly Property ID As Integer
        Get
            Return mudtProps.ID
        End Get
    End Property
    Public ReadOnly Property BOName As String
        Get
            Return mudtProps.BOName
        End Get
    End Property
    Public ReadOnly Property DataSource As String
        Get
            Return mudtProps.DataSource
        End Get
    End Property
    Public ReadOnly Property InitialCatalog As String
        Get
            Return mudtProps.InitialCatalog
        End Get
    End Property
    Public ReadOnly Property UserId As String
        Get
            Return mudtProps.UserId
        End Get
    End Property
    Public ReadOnly Property UserPassword As String
        Get
            Return mudtProps.UserPassword
        End Get
    End Property
    Public ReadOnly Property BranchCode As String
        Get
            Return mudtProps.BranchCode
        End Get
    End Property
    Public Sub SetValues(ByVal pID As Integer, ByVal pBOName As String, ByVal pDataSource As String, ByVal pInitialCatalog As String _
                       , ByVal pUserId As String, ByVal pUserPassword As String, ByVal pBranchCode As String)
        With mudtProps
            .ID = pID
            .BOName = pBOName
            .DataSource = pDataSource
            .InitialCatalog = pInitialCatalog
            .UserId = pUserId
            .UserPassword = pUserPassword
            .BranchCode = pBranchCode
        End With
    End Sub
End Class
