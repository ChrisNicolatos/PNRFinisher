Option Strict On
Option Explicit On
Public Class ClientReferenceCollection
    Inherits Collections.Generic.Dictionary(Of Integer, ClientReference)
    Public Sub New(ByVal pEntityID As Integer, ByVal pBackOffice As Integer)
        Try
            If pBackOffice = 1 Then
                ReadTravelForce(pEntityID)
            ElseIf pBackOffice = 2 Then
                ReadDiscovery(pEntityID)
            End If

        Catch ex As Exception
            Throw New Exception("ClientReferenceCollection.Read()" & ex.Message)
        End Try
    End Sub
    Private Sub ReadTravelForce(ByVal pEntityID As Integer)
        Try

            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(1))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            Dim pobjClass As ClientReference
            Dim pSequenceNumber As Integer = 0
            Dim GDSEntries As New ClientReferenceGDSEntryCollection

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand
            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@EntityID", SqlDbType.Int).Value = pEntityID
                .CommandText = " SELECT ClientCustomProperties.Id  
                                ,ClientCustomProperties.CustomPropertyID  
                                ,ClientCustomProperties.LookUpValues  
                                ,ClientCustomProperties.LimitToLookUp  
                                ,ClientCustomProperties.Label  
                                ,ClientCustomProperties.TFEntityID  
                                ,ClientCustomProperties.LTRequiredTypeID  
                                FROM TravelForceCosmos.dbo.ClientCustomProperties  
                                LEFT JOIN TravelForceCosmos.dbo.CustomProperties
                                ON ClientCustomProperties.CustomPropertyID = CustomProperties.Id
                                WHERE ClientCustomProperties.TFEntityID = @EntityID AND CustomProperties.LTKindID = 691   
                                AND ClientCustomProperties.IsDisabled = 0"
                pobjReader = .ExecuteReader
            End With
            ' Add reference field for Travel Force
            pSequenceNumber += 1
            Dim pGDSRefEntry As ClientReferenceGDSEntry = GDSEntries.Item("199")
            pobjClass = New ClientReference(pSequenceNumber, "99", "Reference", pGDSRefEntry.Amadeus, pGDSRefEntry.Galileo, False, False, "", False)
            MyBase.Add(pobjClass.SequenceNo, pobjClass)
            With pobjReader
                Do While .Read
                    pSequenceNumber += 1
                    Dim Mandatory As Boolean = False
                    If CType(.Item("LTRequiredTypeID"), ClientReferenceRequiredType) = ClientReferenceRequiredType.PropertyReqToSave Then
                        Mandatory = True
                    End If
                    If GDSEntries.ContainsKey(CStr(100 + CInt(.Item("CustomPropertyID")))) Then
                        Dim pGDSEntry As ClientReferenceGDSEntry = GDSEntries.Item(CStr(100 + CInt(.Item("CustomPropertyID"))))
                        pobjClass = New ClientReference(pSequenceNumber, CStr(.Item("CustomPropertyID")), CStr(.Item("Label")), pGDSEntry.Amadeus, pGDSEntry.Galileo, Mandatory, False, CStr(.Item("LookUpValues")), CBool(.Item("LimitToLookUp")))
                        MyBase.Add(pobjClass.SequenceNo, pobjClass)
                    End If
                Loop
                .Close()
            End With
            pobjConn.Close()
        Catch ex As Exception
            Throw New Exception("ClientReferenceCollection.ReadTravelForce()" & ex.Message)
        End Try

    End Sub
    Private Sub ReadDiscovery(ByVal pEntityID As Integer)
        Try

            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString(2))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As ClientReference
            Dim GDSEntries As New ClientReferenceGDSEntryCollection
            Dim pGDSEntry As ClientReferenceGDSEntry
            Dim pSequenceNumber As Integer = 0
            Dim prID As String
            Dim pTitle As String
            Dim pMandatory As Boolean
            Dim pMandatoryForPax As Boolean


            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand
            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@EntityID", SqlDbType.Int).Value = pEntityID
                .CommandText = "SELECT 
 Company.Account_Id
,Company.Account_Abbriviation
,Company.Account_Name
,Purchase_Order_Title AS PO
,Cost_Centre_1_Title AS CC1
,Cost_Centre_2_Title AS CC2

,Ref_1_Title AS T1
,Must_Put_Ref_1 AS M1
,Pax_Must_Enter_Ref1 AS P1
,Ref_2_Title AS T2
,Must_Put_Ref_2 AS M2
,Pax_Must_Enter_Ref2 AS P2
,Ref_3_Title AS T3
,Must_Put_Ref_3 AS M3
,Pax_Must_Enter_Ref3 AS P3
,Ref_4_Title AS T4
,Must_Put_Ref_4 AS M4
,Pax_Must_Enter_Ref4 AS P4
,Ref_5_Title AS T5
,Must_Put_Ref_5 AS M5
,Pax_Must_Enter_Ref5 AS P5
,Ref_6_Title AS T6
,Must_Put_Ref_6 AS M6
,Pax_Must_Enter_Ref6 AS P6
,Ref_7_Title AS T7
,Must_Put_Ref_7 AS M7
,Pax_Must_Enter_Ref7 AS P7
,Ref_8_Title AS T8
,Must_Put_Ref_8 AS M8
,Pax_Must_Enter_Ref8 AS P8
,Ref_9_Title AS T9
,Must_Put_Ref_9 AS M9
,Ref_10_Title AS T10
,Must_Put_Ref_10 AS M10
,Ref_11_Title AS T11
,Must_Put_Ref_11 AS M11
,Ref_12_Title AS T12
,Must_Put_Ref_12 AS M12
,Ref_13_Title AS T13
,Must_Put_Ref_13 AS M13
,Ref_14_Title AS T14
,Must_Put_Ref_14 AS M14
,Ref_15_Title AS T15
,Must_Put_Ref_15 AS M15

,Booked_by_Title AS BBY

FROM Disco_Instone_EU.dbo.CompProfile
LEFT JOIN Disco_Instone_EU.dbo.Company 
ON Company.Account_Id = CompProfile.Account_Id 
--WHERE CompProfile.Branch = 19
WHERE        (CompProfile.Account_Id = @EntityID)"
                pobjReader = .ExecuteReader
            End With
            With pobjReader
                If .Read Then
                    pSequenceNumber += 1
                    pGDSEntry = GDSEntries.Item("2PO")
                    pobjClass = New ClientReference(pSequenceNumber, pEntityID, "PO", pGDSEntry.Amadeus, pGDSEntry.Galileo, CStr(.Item("PO")), False)
                    If pobjClass.SequenceNo > 0 Then
                        MyBase.Add(pobjClass.SequenceNo, pobjClass)
                    Else
                        pSequenceNumber -= 1
                    End If

                    pSequenceNumber += 1
                    pGDSEntry = GDSEntries.Item("2CC1")
                    pobjClass = New ClientReference(pSequenceNumber, pEntityID, "CC1", pGDSEntry.Amadeus, pGDSEntry.Galileo, CStr(.Item("CC1")), True)
                    If pobjClass.SequenceNo > 0 Then
                        MyBase.Add(pobjClass.SequenceNo, pobjClass)
                    Else
                        pSequenceNumber -= 1
                    End If

                    pSequenceNumber += 1
                    pGDSEntry = GDSEntries.Item("2CC2")
                    pobjClass = New ClientReference(pSequenceNumber, pEntityID, "CC2", pGDSEntry.Amadeus, pGDSEntry.Galileo, CStr(.Item("CC2")), False)
                    If pobjClass.SequenceNo > 0 Then
                        MyBase.Add(pobjClass.SequenceNo, pobjClass)
                    Else
                        pSequenceNumber -= 1
                    End If

                    pSequenceNumber += 1
                    pGDSEntry = GDSEntries.Item("2BBY")
                    pobjClass = New ClientReference(pSequenceNumber, pEntityID, "BBY", pGDSEntry.Amadeus, pGDSEntry.Galileo, CStr(.Item("BBY")), False)
                    If pobjClass.SequenceNo > 0 Then
                        MyBase.Add(pobjClass.SequenceNo, pobjClass)
                    Else
                        pSequenceNumber -= 1
                    End If

                    For pRef As Integer = 1 To 15
                        prID = "REF" & CStr(pRef)
                        pTitle = MakeTitle(prID, CStr(.Item("T" & CStr(pRef))))
                        pMandatory = CBool(.Item("M" & CStr(pRef)))
                        If pRef <= 8 Then
                            pMandatoryForPax = CBool(.Item("P" & CStr(pRef)))
                        Else
                            pMandatoryForPax = False
                        End If
                        pGDSEntry = GDSEntries.Item("2" & prID)
                        pSequenceNumber += 1
                        pobjClass = New ClientReference(pSequenceNumber, pEntityID, prID, pGDSEntry.Amadeus, pGDSEntry.Galileo, pTitle, pMandatory, pMandatoryForPax)
                        If pobjClass.SequenceNo > 0 Then
                            MyBase.Add(pobjClass.SequenceNo, pobjClass)
                        Else
                            pSequenceNumber -= 1
                        End If

                    Next

                End If
                .Close()
            End With
            pobjConn.Close()
        Catch ex As Exception
            Throw New Exception("ClientReferenceCollection.ReadDiscovery()" & ex.Message)
        End Try
    End Sub
    Private Function MakeTitle(ByVal DefaultValue As String, ByVal DBValue As String) As String
        Try
            If DBValue.Trim <> "" Then
                Return DBValue
            ElseIf DefaultValue.Trim <> "" Then
                Return DefaultValue
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
