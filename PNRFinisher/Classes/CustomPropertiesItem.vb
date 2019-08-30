Option Strict On
Option Explicit On
Public Class CustomPropertiesItem
    Private Structure ClassProps
        Dim ID As Integer
        Dim CustomPropertyID As EnumCustomPropertyID
        Dim LookUpValues As String
        Dim LimitToLookup As Boolean
        Dim RequiredType As CustomPropertyRequiredType
        Dim Label As String
        Dim TFEntityID As Long
        Dim Values As Collections.Generic.Dictionary(Of String, CustomPropertiesValues)
    End Structure
    Private mudtProps As ClassProps

    Public ReadOnly Property ID() As Integer
        Get
            Return mudtProps.ID
        End Get
    End Property

    Friend ReadOnly Property CustomPropertyID() As EnumCustomPropertyID
        Get
            Return mudtProps.CustomPropertyID
        End Get
    End Property

    Public ReadOnly Property LookUpValues() As String
        Get
            Return mudtProps.LookUpValues
        End Get
    End Property

    Public ReadOnly Property LimitToLookup() As Boolean
        Get
            Return mudtProps.LimitToLookup
        End Get
    End Property
    Friend ReadOnly Property RequiredType As CustomPropertyRequiredType
        Get
            Return mudtProps.RequiredType
        End Get
    End Property
    Public ReadOnly Property Label() As String
        Get
            Return mudtProps.Label
        End Get
    End Property

    Public ReadOnly Property TFEntityID() As Long
        Get
            Return mudtProps.TFEntityID
        End Get
    End Property
    'Public ReadOnly Property ValuesCount As Integer
    '    Get
    '        Return mudtProps.Values.Length
    '    End Get
    'End Property
    Public ReadOnly Property Value As Collections.Generic.Dictionary(Of String, CustomPropertiesValues)
        Get
            Return mudtProps.Values
        End Get
    End Property
    'Public ReadOnly Property Value(ByVal Index As Integer) As String
    '    Get
    '        If Index >= 0 And Index <= mudtProps.Values.GetUpperBound(0) Then
    '            Return mudtProps.Values(Index)
    '        Else
    '            Throw New Exception("Index out of bounds")
    '        End If
    '    End Get
    'End Property

    Friend Sub SetValues(ByVal pID As Integer, ByVal pCustomPropertyID As EnumCustomPropertyID, ByVal pLookUpValues As String, ByVal pLimitToLookup As Boolean, ByVal pRequiredType As CustomPropertyRequiredType, ByVal pLabel As String, ByVal pTFEntityID As Integer, ByVal pBackoffice As Integer)
        With mudtProps
            .ID = pID
            .CustomPropertyID = pCustomPropertyID
            .LookUpValues = pLookUpValues
            .RequiredType = pRequiredType
            .LimitToLookup = pLimitToLookup
            .Label = pLabel
            .TFEntityID = pTFEntityID
            .Values = New Collections.Generic.Dictionary(Of String, CustomPropertiesValues)
            .Values.Clear()

            If .LookUpValues.IndexOf("<") >= 0 Or pBackoffice = 2 Then
                ReadXML(pCustomPropertyID, pTFEntityID, pBackoffice)
            Else
                ReadLookUpValues(pBackoffice)
            End If
        End With
    End Sub
    Friend Sub SetValues(ByVal pID As Integer, ByVal pCustomPropertyID As EnumCustomPropertyID, ByVal pLookUpValues As SubDepartmentCollection, ByVal pLimitToLookup As Boolean, ByVal pRequiredType As CustomPropertyRequiredType, ByVal pLabel As String, ByVal pTFEntityID As Integer, ByVal pBackoffice As Integer)
        With mudtProps
            .ID = pID
            .CustomPropertyID = pCustomPropertyID
            .LookUpValues = ""
            .RequiredType = pRequiredType
            .LimitToLookup = pLimitToLookup
            .Label = pLabel
            .TFEntityID = pTFEntityID
            .Values = New Collections.Generic.Dictionary(Of String, CustomPropertiesValues)
            .Values.Clear()
            For Each pSubItem As SubDepartmentItem In pLookUpValues.Values
                Dim pItem As New CustomPropertiesValues(CStr(pSubItem.ID), pSubItem.Code, pSubItem.Name)
                mudtProps.Values.Add(pItem.Id, pItem)
            Next
        End With
    End Sub
    Friend Sub SetValues(ByVal pID As Integer, ByVal pCustomPropertyID As EnumCustomPropertyID, ByVal pLookUpValues As CRMCollection, ByVal pLimitToLookup As Boolean, ByVal pRequiredType As CustomPropertyRequiredType, ByVal pLabel As String, ByVal pTFEntityID As Integer, ByVal pBackoffice As Integer)
        With mudtProps
            .ID = pID
            .CustomPropertyID = pCustomPropertyID
            .LookUpValues = ""
            .RequiredType = pRequiredType
            .LimitToLookup = pLimitToLookup
            .Label = pLabel
            .TFEntityID = pTFEntityID
            .Values = New Collections.Generic.Dictionary(Of String, CustomPropertiesValues)
            .Values.Clear()
            For Each pSubItem As CRMItem In pLookUpValues.Values
                Dim pItem As New CustomPropertiesValues(CStr(pSubItem.ID), pSubItem.Code, pSubItem.Name)
                mudtProps.Values.Add(pItem.Id, pItem)
            Next
        End With
    End Sub

    Private Sub ReadXML(ByVal pCustomPropertyID As Integer, ByVal pTfEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pobjXMLValues As New CustomPropertiesXMLValues
        pobjXMLValues.ReadValues(pCustomPropertyID, pTfEntityID, pBackOffice)
        Dim pValues() As String = pobjXMLValues.ToArray
        For i As Integer = 0 To pValues.GetUpperBound(0)
            Dim pItem As New CustomPropertiesValues(CStr(i), "", pValues(i))
            mudtProps.Values.Add(pItem.Id, pItem)
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
            .Parameters.Add("@CustomPropertyID", SqlDbType.Int).Value = mudtProps.CustomPropertyID
            .Parameters.Add("@TFEntityID", SqlDbType.Int).Value = mudtProps.TFEntityID
            .CommandText = "SELECT Value  
                             FROM TravelForceCosmos.dbo.CustomPropertyValues  
                             WHERE CustomPropertyID = @CustomPropertyID And TFEntityID = @TFEntityID    
                             GROUP BY Value  
                             ORDER BY Value"
            pobjReader = .ExecuteReader
        End With
        Dim pItem As CustomPropertiesValues
        With pobjReader
            Dim iCount As Integer = 0
            pItem = New CustomPropertiesValues("0", "", "")
            mudtProps.Values.Add(pItem.Id, pItem)
            Do While .Read
                iCount += 1
                pItem = New CustomPropertiesValues(CStr(iCount), "", CStr(.Item("Value")))
                mudtProps.Values.Add(pItem.Id, pItem)
            Loop
            .Close()
        End With
            pobjConn.Close()
        End If
    End Sub

End Class