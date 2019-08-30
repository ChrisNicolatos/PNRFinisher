Option Strict On
Option Explicit On
Public Class CustomPropertiesXMLValues

    Inherits Collections.Generic.List(Of String)

    Private mstrID As String

    Public Sub ReadValues(ByVal pCustomPropertyID As Integer, ByVal pTfEntityID As Integer, ByVal pBackOffice As Integer)

        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(pBackOffice))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        MyBase.Clear()
        mstrID = ""

        If pBackOffice = 1 Then

            Do While pTfEntityID <> 0 And mstrID.IndexOf("," & pTfEntityID & ",") < 0
                With pobjComm
                    .CommandType = CommandType.Text
                    .Parameters.Add("@CustomPropertyId", SqlDbType.Int).Value = pCustomPropertyID
                    .Parameters.Add("@TFEntityId", SqlDbType.Int).Value = pTfEntityID
                    .CommandText = "SELECT LookUpValues, ISNULL(RelatedEntityID, 0) AS RelatedEntityID 
                                    FROM TravelForceCosmos.dbo.ClientCustomProperties 
                                    LEFT JOIN TravelForceCosmos.dbo.TFEntities 
                                	    ON TFEntityID=TFEntities.Id 
                                    WHERE CustomPropertyID = @CustomPropertyId And TFEntityID = @TFEntityId"
                    pobjReader = .ExecuteReader
                End With
                With pobjReader
                    Do While .Read
                        ParseXML(CStr(.Item("LookUpValues")))
                        mstrID &= "," & pTfEntityID & ","
                        pTfEntityID = CInt(.Item("RelatedEntityID"))
                    Loop
                End With
                pobjReader.Close()
            Loop
            MyBase.Sort()
        ElseIf pBackOffice = 2 Then
            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@EntityID", SqlDbType.Int).Value = pTfEntityID
                .CommandText = ""
                Select Case pCustomPropertyID
                    Case 1 ' booked by
                        .CommandText = "SELECT Child_Value AS Name  
                                        From Disco_Instone_EU.dbo.Costcen  
                                        LEFT JOIN Company  
                                        ON Costcen.Account_Id=Company.Account_Id  
                                        WHERE CostCen.Account_id = @EntityID AND Child_Name = 'BBY'  
                                        ORDER BY Child_Value"
                    Case 4 ' reason for travel
                        .CommandText = "SELECT Child_Value AS Name  
                                        From Disco_Instone_EU.dbo.Costcen  
                                        LEFT JOIN Company  
                                        ON Costcen.Account_Id=Company.Account_Id  
                                        WHERE CostCen.Account_id = @EntityID AND Child_Name = 'REF2'  
                                        ORDER BY Child_Value"
                    Case 5 ' cost centre
                        .CommandText = "SELECT Child_Value AS Name  
                                        From Disco_Instone_EU.dbo.Costcen  
                                        LEFT JOIN Company  
                                        ON Costcen.Account_Id=Company.Account_Id  
                                        WHERE CostCen.Account_id = @EntityID AND Child_Name = 'CC2'  
                                        ORDER BY Child_Value"
                End Select

                If .CommandText <> "" Then
                    pobjReader = .ExecuteReader
                    Do While pobjReader.Read
                        If Not MyBase.Contains(CStr(pobjReader.Item("Name"))) Then
                            MyBase.Add(CStr(pobjReader.Item("Name")))
                        End If
                    Loop
                End If
            End With
        End If

    End Sub
    Private Sub ParseXML(ByVal pXMLString As String)

        Try
            Dim xmlString As String = pXMLString
            Dim sr As New System.IO.StringReader(xmlString)
            Dim doc As New Xml.XmlDocument
            doc.Load(sr)
            'or just in this case doc.LoadXML(xmlString)
            Dim reader As New Xml.XmlNodeReader(doc)

            While reader.Read()
                Select Case reader.NodeType
                    Case Xml.XmlNodeType.Element
                        If reader.Name = "CustomPropertyLookupValue" Then
                            'Dim pFound As Boolean = False
                            Dim pText As String = ""
                            pText = reader.GetAttribute("Value").ToUpper.Trim
                            If reader.GetAttribute("Description").ToUpper.Trim <> "" And reader.GetAttribute("Description").ToUpper.Trim <> pText Then
                                If pText <> "" Then
                                    pText &= "/"
                                End If
                                pText &= reader.GetAttribute("Description").ToUpper.Trim
                            End If
                            If pText <> "" Then
                                If Not MyBase.Contains(pText) Then
                                    MyBase.Add(pText)
                                End If
                            End If
                        End If
                End Select
            End While
        Catch ex As Exception

        End Try

    End Sub

End Class