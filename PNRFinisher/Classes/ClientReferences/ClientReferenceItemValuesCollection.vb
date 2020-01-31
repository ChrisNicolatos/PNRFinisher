Option Strict On
Option Explicit On
Public Class ClientReferenceItemValuesCollection
    Inherits Collections.Generic.List(Of ClientReferenceItemValue)

    Public Sub New(ByVal pXMLString As String)

        Try
            If pXMLString <> "" Then


                Dim xmlString As String = pXMLString
                Dim sr As New System.IO.StringReader(xmlString)
                Dim doc As New Xml.XmlDocument
                doc.Load(sr)
                'or just in this case doc.LoadXML(xmlString)
                Dim reader As New Xml.XmlNodeReader(doc)
                Dim pCount As Integer = 0
                While reader.Read()
                    Select Case reader.NodeType
                        Case Xml.XmlNodeType.Element
                            If reader.Name = "CustomPropertyLookupValue" Then
                                pCount += 1
                                Dim pId As String = CStr(pCount)
                                Dim pCode As String = ""
                                Dim pValue As String = ""
                                pCode = reader.GetAttribute("Value").ToUpper.Trim
                                pValue = reader.GetAttribute("Description").ToUpper.Trim
                                Dim pItem As New ClientReferenceItemValue(pId, pCode, pValue)
                                If Not MyBase.Contains(pItem) Then
                                    MyBase.Add(pItem)
                                End If
                            End If
                    End Select
                End While
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Sub New(ByVal EntityId As Integer, ByVal ClientRef As String)
        Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(2))
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand
        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@EntityID", SqlDbType.Int).Value = EntityId
            .Parameters.Add("@ChildName", SqlDbType.VarChar, 30).Value = ClientRef
            .CommandText = "SELECT ISN
                              ,Child_Value
	                          ,Child_Description      
                          FROM [Disco_Instone_EU].[dbo].[Costcen]
                          WHERE Account_id=@EntityID AND Child_Name = @ChildName
                          ORDER BY Account_id, Child_Name, Child_Value"
            pobjReader = .ExecuteReader
        End With
        With pobjReader
            Do While .Read
                Dim pItem As New ClientReferenceItemValue(CStr(.Item("ISN")), CStr(.Item("Child_Value")), CStr(.Item("Child_Description")))
                If Not MyBase.Contains(pItem) Then
                    MyBase.Add(pItem)
                End If
            Loop
        End With

    End Sub
End Class
