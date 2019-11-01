Option Strict On
Option Explicit On
Public Class CustomPropertiesCollection
    Inherits Collections.Generic.Dictionary(Of Integer, CustomPropertiesItem)

    Private Const MyXMLString As String = "<?xml version='1.0' encoding='utf-8'?><LookUpValues xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><CustomPropertyLookupValue Description='Crew' Value='Crew' IsDefault='false' /><CustomPropertyLookupValue Description='Technical' Value='Technical' IsDefault='false' /><CustomPropertyLookupValue Description='Marine' Value='Marine' IsDefault='false' /><CustomPropertyLookupValue Description='HSQE' Value='HSQE' IsDefault='false' /><CustomPropertyLookupValue Description='Finance' Value='Finance' IsDefault='false' /></LookUpValues>"
    Private mflgBookedBy As Boolean
    Private mflgDepartment As Boolean
    Private mflgReasonForTravel As Boolean
    Private mflgCostCentre As Boolean
    Private mflgSubDepartment As Boolean
    Private mflgCRM As Boolean
    Private mflgReference As Boolean

    Public Sub Load(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        mflgBookedBy = False
        mflgDepartment = False
        mflgReasonForTravel = False
        mflgCostCentre = False
        mflgSubDepartment = False
        mflgCRM = False
        mflgReference = False

        MyBase.Clear()

        ReadCustomPropertiesTF(pEntityID, pBackOffice)
        ReadSubDepartments(pEntityID, pBackOffice)
        AddReference(pEntityID, pBackOffice)
        ReadCRM(pEntityID, pBackOffice)

    End Sub
    Private Sub ReadSubDepartments(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pSubDepartments As New SubDepartmentCollection
        Dim pobjClass As CustomPropertiesItem

        pSubDepartments.Load(pEntityID, pBackOffice)
        If pSubDepartments.Count > 0 Then
            pobjClass = New CustomPropertiesItem(901, EnumCustomPropertyID.SubDepartment, pSubDepartments, True, CustomPropertyRequiredType.PropertyReqToSave, "SubDepartment", pEntityID, pBackOffice)
            If pobjClass.Values.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
                mflgSubDepartment = True
            Else
                mflgSubDepartment = False
            End If
        End If

    End Sub
    Private Sub ReadCRM(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)
        Dim pCRM As New CRMCollection
        Dim pobjClass As CustomPropertiesItem

        pCRM.Load(pEntityID, pBackOffice)
        If pCRM.Count > 0 Then
            pobjClass = New CustomPropertiesItem(902, EnumCustomPropertyID.CRM, pCRM, True, CustomPropertyRequiredType.PropertyOptional, "CRM Invoicing Address", pEntityID, pBackOffice)
            If pobjClass.Values.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
                mflgCRM = True
            Else
                mflgCRM = False
            End If
        End If
    End Sub
    Private Sub AddReference(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pobjClass As New CustomPropertiesItem(903, EnumCustomPropertyID.Reference, "", False, CustomPropertyRequiredType.PropertyOptional, "Reference", pEntityID, pBackOffice)
        MyBase.Add(pobjClass.ID, pobjClass)
        mflgCRM = True

    End Sub
    Private Sub ReadCustomPropertiesTF(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        If pBackOffice = 1 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As CustomPropertiesItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@EntityID", SqlDbType.Int).Value = pEntityID
                .CommandText = " SELECT Id  
                                ,CustomPropertyID  
                                ,LookUpValues  
                                ,LimitToLookUp  
                                ,Label  
                                ,TFEntityID  
                                ,LTRequiredTypeID  
                                FROM TravelForceCosmos.dbo.ClientCustomProperties  
                                WHERE TFEntityID = @EntityID    
                                AND IsDisabled = 0"
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pobjClass = New CustomPropertiesItem(CInt(.Item("Id")), CType(.Item("CustomPropertyID"), EnumCustomPropertyID), CStr(.Item("LookUpValues")), CBool(.Item("LimitToLookUp")), CType(.Item("LTRequiredTypeID"), CustomPropertyRequiredType), CStr(.Item("Label")), CInt(.Item("TFEntityID")), pBackOffice)
                    MyBase.Add(pobjClass.ID, pobjClass)
                    If pobjClass.CustomPropertyID = EnumCustomPropertyID.BookedBy Then
                        mflgBookedBy = True
                    ElseIf pobjClass.CustomPropertyID = EnumCustomPropertyID.Department Then
                        mflgDepartment = True
                    ElseIf pobjClass.CustomPropertyID = EnumCustomPropertyID.ReasonFortravel Then
                        mflgReasonForTravel = True
                    ElseIf pobjClass.CustomPropertyID = EnumCustomPropertyID.CostCentre Then
                        mflgCostCentre = True
                    End If
                Loop
                .Close()
            End With
            pobjConn.Close()
        Else
            Dim pobjClass As CustomPropertiesItem
            pobjClass = New CustomPropertiesItem(1, EnumCustomPropertyID.BookedBy, "", True, CustomPropertyRequiredType.PropertyReqToSave, "BookedBy", pEntityID, pBackOffice)
            If pobjClass.Values.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
                mflgBookedBy = True
            Else
                mflgBookedBy = False
            End If
            pobjClass = New CustomPropertiesItem(4, EnumCustomPropertyID.ReasonFortravel, "", True, CustomPropertyRequiredType.PropertyReqToSave, "ReasonFortravel", pEntityID, pBackOffice)
            If pobjClass.Values.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
                mflgReasonForTravel = True
            Else
                mflgReasonForTravel = False
            End If
            pobjClass = New CustomPropertiesItem(5, EnumCustomPropertyID.CostCentre, "", True, CustomPropertyRequiredType.PropertyReqToSave, "CostCentre", pEntityID, pBackOffice)
            If pobjClass.Values.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
                mflgCostCentre = True
            Else
                mflgCostCentre = False
            End If

        End If
    End Sub
    Public ReadOnly Property BookedBy As Boolean
        Get
            Return mflgBookedBy
        End Get
    End Property
    Public ReadOnly Property Department As Boolean
        Get
            Return mflgDepartment
        End Get
    End Property
    Public ReadOnly Property ReasonForTravel As Boolean
        Get
            Return mflgReasonForTravel
        End Get
    End Property
    Public ReadOnly Property CostCentre As Boolean
        Get
            Return mflgCostCentre
        End Get
    End Property
    Public ReadOnly Property SubDepartment As Boolean
        Get
            Return mflgSubDepartment
        End Get
    End Property
    Public ReadOnly Property CRM As Boolean
        Get
            Return mflgCRM
        End Get
    End Property
    Public ReadOnly Property Reference As Boolean
        Get
            Return mflgReference
        End Get
    End Property
End Class
