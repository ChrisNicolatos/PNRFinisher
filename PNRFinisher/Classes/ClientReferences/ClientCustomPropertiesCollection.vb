Option Strict On
Option Explicit On
Public Class ClientCustomPropertiesCollection
    Inherits Collections.Generic.Dictionary(Of Integer, ClientCustomProperties)

    Private Const MyXMLString As String = "<?xml version='1.0' encoding='utf-8'?><LookUpValues xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><CustomPropertyLookupValue Description='Crew' Value='Crew' IsDefault='false' /><CustomPropertyLookupValue Description='Technical' Value='Technical' IsDefault='false' /><CustomPropertyLookupValue Description='Marine' Value='Marine' IsDefault='false' /><CustomPropertyLookupValue Description='HSQE' Value='HSQE' IsDefault='false' /><CustomPropertyLookupValue Description='Finance' Value='Finance' IsDefault='false' /></LookUpValues>"

    Public Sub Load(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        MyBase.Clear()

        ReadCustomPropertiesTF(pEntityID, pBackOffice)
        ReadSubDepartments(pEntityID, pBackOffice)
        AddReference(pEntityID, pBackOffice)
        ReadCRM(pEntityID, pBackOffice)

    End Sub
    Private Sub ReadSubDepartments(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pSubDepartments As New SubDepartmentCollection
        Dim pobjClass As ClientCustomProperties

        pSubDepartments.Load(pEntityID, pBackOffice)
        If pSubDepartments.Count > 0 Then
            pobjClass = New ClientCustomProperties(901, EnumCustomPropertyID.SubDepartment, pSubDepartments, True, CustomPropertyRequiredType.PropertyReqToSave, "SubDepartment", pEntityID)
            If pobjClass.ItemValues.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
            End If
        End If

    End Sub
    Private Sub ReadCRM(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)
        Dim pCRM As New CRMCollection
        Dim pobjClass As ClientCustomProperties

        pCRM.Load(pEntityID, pBackOffice)
        If pCRM.Count > 0 Then
            pobjClass = New ClientCustomProperties(902, EnumCustomPropertyID.CRM, pCRM, True, CustomPropertyRequiredType.PropertyOptional, "CRM Invoicing Address", pEntityID)
            If pobjClass.ItemValues.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
            End If
        End If
    End Sub
    Private Sub AddReference(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pobjClass As New ClientCustomProperties(903, EnumCustomPropertyID.Reference, "", False, CustomPropertyRequiredType.PropertyOptional, "Reference", pEntityID, pBackOffice)
        MyBase.Add(pobjClass.ID, pobjClass)

    End Sub
    Private Sub ReadCustomPropertiesTF(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)

        If pBackOffice = 1 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As ClientCustomProperties

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
                    pobjClass = New ClientCustomProperties(CInt(.Item("Id")), CType(.Item("CustomPropertyID"), EnumCustomPropertyID), CStr(.Item("LookUpValues")), CBool(.Item("LimitToLookUp")), CType(.Item("LTRequiredTypeID"), CustomPropertyRequiredType), CStr(.Item("Label")), CInt(.Item("TFEntityID")), pBackOffice)
                    MyBase.Add(pobjClass.ID, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()
        Else
            Dim pobjClass As ClientCustomProperties
            pobjClass = New ClientCustomProperties(1, EnumCustomPropertyID.BookedBy, "", True, CustomPropertyRequiredType.PropertyReqToSave, "BookedBy", pEntityID, pBackOffice)
            If pobjClass.ItemValues.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
            End If
            pobjClass = New ClientCustomProperties(4, EnumCustomPropertyID.ReasonFortravel, "", True, CustomPropertyRequiredType.PropertyReqToSave, "ReasonFortravel", pEntityID, pBackOffice)
            If pobjClass.ItemValues.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
            End If
            pobjClass = New ClientCustomProperties(5, EnumCustomPropertyID.CostCentre, "", True, CustomPropertyRequiredType.PropertyReqToSave, "CostCentre", pEntityID, pBackOffice)
            If pobjClass.ItemValues.Count > 0 Then
                MyBase.Add(pobjClass.ID, pobjClass)
            End If

        End If
    End Sub
End Class
