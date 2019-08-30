Option Strict On
Option Explicit On
Public Class CTCPax
    Event isDirty()
    Event isValid()
    Private Structure ClassProps
        Dim Id As Integer
        Dim BackOfficeID As Integer
        Dim ClientId As Integer
        Dim Vesselname As String
        Dim FirstName As String
        Dim Lastname As String
        Dim Email As String
        Dim Mobile As String
        Dim Refused As Boolean
        Dim isDirty As Boolean
        Dim EmailValid As Boolean
        Dim MobileValid As Boolean
        Dim RefusedValid As Boolean
    End Structure
    Dim mudtProps As ClassProps
    Public Overrides Function ToString() As String
        Return FirstName & " " & Lastname
    End Function
    Public Sub New(ByVal pBackOfficeID As Integer, pClientID As Integer)
        With mudtProps
            .Id = 0
            .BackOfficeID = pBackOfficeID
            .ClientId = pClientID
            .Vesselname = ""
            .FirstName = ""
            .Lastname = ""
            .Email = ""
            .Mobile = ""
            .Refused = False
            .isDirty = False
        End With
    End Sub
    Public Sub New(ByVal pBackOfficeID As Integer, pClientID As Integer, ByVal pFirstName As String, ByVal pLastName As String)
        With mudtProps
            .Id = 0
            .BackOfficeID = pBackOfficeID
            .ClientId = pClientID
            .Vesselname = ""
            .FirstName = pFirstName
            .Lastname = pLastName
            .Email = ""
            .Mobile = ""
            .Refused = False
            .isDirty = False
        End With
    End Sub
    Public ReadOnly Property Id As Integer
        Get
            Return mudtProps.Id
        End Get
    End Property
    Public Property BackOfficeID As Integer
        Get
            Return mudtProps.BackOfficeID
        End Get
        Set(value As Integer)
            mudtProps.BackOfficeID = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property ClientId As Integer
        Get
            Return mudtProps.ClientId
        End Get
        Set(value As Integer)
            mudtProps.ClientId = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property Vesselname As String
        Get
            Return mudtProps.Vesselname
        End Get
        Set(value As String)
            mudtProps.Vesselname = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property FirstName As String
        Get
            Return mudtProps.FirstName
        End Get
        Set(value As String)
            mudtProps.FirstName = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property Lastname As String
        Get
            Return mudtProps.Lastname
        End Get
        Set(value As String)
            mudtProps.Lastname = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property Email As String
        Get
            Return mudtProps.Email
        End Get
        Set(value As String)
            mudtProps.Email = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property Mobile As String
        Get
            Return mudtProps.Mobile
        End Get
        Set(value As String)
            mudtProps.Mobile = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public Property Refused As Boolean
        Get
            Return mudtProps.Refused
        End Get
        Set(value As Boolean)
            mudtProps.Refused = value
            ValidateOptions()
            mudtProps.isDirty = True
            RaiseEvent isDirty()
        End Set
    End Property
    Public ReadOnly Property Dirty As Boolean
        Get
            Return mudtProps.isDirty
        End Get
    End Property
    Public ReadOnly Property EmailValid As Boolean
        Get
            Return mudtProps.EmailValid
        End Get
    End Property
    Public ReadOnly Property MobileValid As Boolean
        Get
            Return mudtProps.MobileValid
        End Get
    End Property
    Public ReadOnly Property RefusedValid As Boolean
        Get
            Return mudtProps.RefusedValid
        End Get
    End Property
    Public ReadOnly Property Valid As Boolean
        Get
            Return EmailValid And MobileValid And RefusedValid
        End Get
    End Property
    Public Sub SetValues(ByVal pId As Integer, ByVal pBackOfficeID As Integer, ByVal pClientId As Integer, ByVal pVesselname As String _
                        , ByVal pFirstName As String, ByVal pLastname As String, ByVal pEmail As String, ByVal pMobile As String _
                        , ByVal pRefused As Boolean)
        With mudtProps
            .Id = pId
            .BackOfficeID = pBackOfficeID
            .ClientId = pClientId
            .Vesselname = pVesselname
            .FirstName = pFirstName
            .Lastname = pLastname
            .Email = pEmail
            .Mobile = pMobile
            .Refused = pRefused
            .isDirty = False
        End With
        ValidateOptions()
    End Sub
    Public Sub Update()
        If Dirty And valid Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand
            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@BackOfficeKey", SqlDbType.Int).Value = BackOfficeID
                .Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientId
                .Parameters.Add("@VesselName", SqlDbType.NVarChar, 254).Value = Vesselname
                .Parameters.Add("@FirstName", SqlDbType.NVarChar, 254).Value = FirstName
                .Parameters.Add("@LastName", SqlDbType.NVarChar, 254).Value = Lastname
                .Parameters.Add("@Email", SqlDbType.NVarChar, 254).Value = Email
                .Parameters.Add("@Mobile", SqlDbType.NVarChar, 254).Value = Mobile
                .Parameters.Add("@Refused", SqlDbType.Bit).Value = Refused
                .CommandText = "USE AmadeusReports
DECLARE @Id INT
SET @Id = (SELECT ctcID 
           FROM PaxCTC 
		   WHERE ctcBackOffice_fkey    = @BackOfficeKey
		     AND ctcClientId_fkey      = @ClientID
			 AND ISNULL(ctcVesselName, '')         = @VesselName
			 AND ISNULL(ctcPassengerFirstName, '') = @FirstName
			 AND ISNULL(ctcPassengerLastName, '')  = @LastName)

IF @Id IS NOT NULL 
BEGIN
	IF @Email <> '' OR @Mobile <> '' OR @Refused = 1
		UPDATE PaxCTC
		SET ctcEmail            = @Email
		, ctcMobile             = @Mobile
		, ctcRefused            = @Refused
		WHERE ctcID = @Id
	ELSE
		DELETE FROM PaxCTC
		WHERE ctcID = @Id
END
ELSE
	IF @Email <> '' OR @Mobile <> '' OR @Refused = 1
		INSERT INTO PaxCTC
				   (ctcBackOffice_fkey
				   ,ctcClientId_fkey
				   ,ctcVesselName
				   ,ctcPassengerFirstName
				   ,ctcPassengerLastName
				   ,ctcEmail
				   ,ctcMobile
				   ,ctcRefused)
			 VALUES
				   (@BackOfficeKey
				   ,@ClientID
				   ,@VesselName
				   ,@FirstName
				   ,@LastName
				   ,@Email
				   ,@Mobile
				   ,@Refused)
  "
                .ExecuteNonQuery()
                mudtProps.isDirty = False
            End With
        End If
    End Sub
    Private Sub ValidateOptions()
        mudtProps.EmailValid = (Email = "" OrElse System.Text.RegularExpressions.Regex.IsMatch(Email, "(?i)^(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+\/=\?\^`{}|~\w])*)(?<=[0-9a-z])@)(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][-a-z0-9]{0,22}[a-z0-9])$"))
        mudtProps.MobileValid = (Mobile = "" OrElse IsNumeric(Mobile))
        mudtProps.RefusedValid = ((Refused And Email = "" And Mobile = "") Or (Not Refused And (Email <> "" Or Mobile <> "")))
        RaiseEvent isValid()
    End Sub
End Class
