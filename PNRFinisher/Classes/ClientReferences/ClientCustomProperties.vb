Option Strict On
Option Explicit On
Public Class ClientCustomProperties
    Public ReadOnly Property ID As Integer
    Friend ReadOnly Property CustomPropertyID As EnumCustomPropertyID
    Public ReadOnly Property LimitToLookup As Boolean
    Friend ReadOnly Property RequiredType As CustomPropertyRequiredType
    Public ReadOnly Property Label As String
    Public ReadOnly Property TFEntityID As Long
    Public ReadOnly Property ItemValues As Collections.Generic.Dictionary(Of String, CustomPropertiesItemValue)
    Friend Sub New(ByVal pID As Integer, ByVal pCustomPropertyID As EnumCustomPropertyID, ByVal pLookUpValues As String, ByVal pLimitToLookup As Boolean, ByVal pRequiredType As CustomPropertyRequiredType, ByVal pLabel As String, ByVal pTFEntityID As Integer, ByVal pBackoffice As Integer)
        ID = pID
        CustomPropertyID = pCustomPropertyID
        RequiredType = pRequiredType
        LimitToLookup = pLimitToLookup
        Label = pLabel
        TFEntityID = pTFEntityID
        ItemValues = New Collections.Generic.Dictionary(Of String, CustomPropertiesItemValue)
        ItemValues.Clear()

        If pLookUpValues.IndexOf("<") >= 0 Or pBackoffice = 2 Then
            ReadXML(pCustomPropertyID, pTFEntityID, pBackoffice)
        Else
            ReadLookUpValues(pBackoffice)
        End If
    End Sub
    Friend Sub New(ByVal pID As Integer, ByVal pCustomPropertyID As EnumCustomPropertyID, ByVal pLookUpValues As SubDepartmentCollection, ByVal pLimitToLookup As Boolean, ByVal pRequiredType As CustomPropertyRequiredType, ByVal pLabel As String, ByVal pTFEntityID As Integer)
        ID = pID
        CustomPropertyID = pCustomPropertyID
        RequiredType = pRequiredType
        LimitToLookup = pLimitToLookup
        Label = pLabel
        TFEntityID = pTFEntityID
        ItemValues = New Collections.Generic.Dictionary(Of String, CustomPropertiesItemValue)
        ItemValues.Clear()
        For Each pSubItem As SubDepartmentItem In pLookUpValues.Values
            Dim pItem As New CustomPropertiesItemValue(CStr(pSubItem.ID), pSubItem.Code, pSubItem.Name)
            ItemValues.Add(pItem.Id, pItem)
        Next
    End Sub
    Friend Sub New(ByVal pID As Integer, ByVal pCustomPropertyID As EnumCustomPropertyID, ByVal pLookUpValues As CRMCollection, ByVal pLimitToLookup As Boolean, ByVal pRequiredType As CustomPropertyRequiredType, ByVal pLabel As String, ByVal pTFEntityID As Integer)
        ID = pID
        CustomPropertyID = pCustomPropertyID
        RequiredType = pRequiredType
        LimitToLookup = pLimitToLookup
        Label = pLabel
        TFEntityID = pTFEntityID
        ItemValues = New Collections.Generic.Dictionary(Of String, CustomPropertiesItemValue)
        ItemValues.Clear()
        For Each pSubItem As CRMItem In pLookUpValues.Values
            Dim pItem As New CustomPropertiesItemValue(CStr(pSubItem.ID), pSubItem.Code, pSubItem.Name)
            ItemValues.Add(pItem.Id, pItem)
        Next
    End Sub

    Private Sub ReadXML(ByVal pCustomPropertyID As Integer, ByVal pTfEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pobjXMLValues As New CustomPropertiesXMLValues(pCustomPropertyID, pTfEntityID, pBackOffice)
        Dim pValues() As String = pobjXMLValues.ToArray
        For i As Integer = 0 To pValues.GetUpperBound(0)
            Dim pItem As New CustomPropertiesItemValue(CStr(i), "", pValues(i))
            ItemValues.Add(pItem.Id, pItem)
        Next

    End Sub

    Private Sub ReadLookUpValues(ByVal pBackOffice As Integer)

        If pBackOffice > 0 Then
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@CustomPropertyID", SqlDbType.Int).Value = CustomPropertyID
                .Parameters.Add("@TFEntityID", SqlDbType.Int).Value = TFEntityID
                .CommandText = "SELECT Value  
                             FROM TravelForceCosmos.dbo.CustomPropertyValues  
                             WHERE CustomPropertyID = @CustomPropertyID And TFEntityID = @TFEntityID    
                             GROUP BY Value  
                             ORDER BY Value"
                pobjReader = .ExecuteReader
            End With
            Dim pItem As CustomPropertiesItemValue
            With pobjReader
                Dim iCount As Integer = 0
                pItem = New CustomPropertiesItemValue("0", "", "")
                ItemValues.Add(pItem.Id, pItem)
                Do While .Read
                    iCount += 1
                    pItem = New CustomPropertiesItemValue(CStr(iCount), "", CStr(.Item("Value")))
                    ItemValues.Add(pItem.Id, pItem)
                Loop
                .Close()
            End With
            pobjConn.Close()
        End If
    End Sub

End Class