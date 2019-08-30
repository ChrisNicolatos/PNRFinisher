Option Strict On
Option Explicit On
Public Class ClassOfServiceCollection

    Private mClassCollection As New Collections.Generic.Dictionary(Of String, ClassOfServiceItem)

    Public Function Load(ByVal pCarrier As String, ByVal pOrigin As String, ByVal pDestination As String, ByVal pClassOfService As String) As ClassOfServiceItem

        Dim pItem As New ClassOfServiceItem
        pItem.SetValues(pCarrier, pOrigin, pDestination, pClassOfService, "", "", "")
        If mClassCollection.ContainsKey(pItem.Key) Then
            pItem = mClassCollection.Item(pItem.Key)
        Else
            Dim pobjConn As New SqlClient.SqlConnection(UtilitiesDB.ConnectionString("TWS_MIS"))
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@Carrier", SqlDbType.Char, 2).Value = pCarrier
                .Parameters.Add("@ClassCode", SqlDbType.VarChar, 2).Value = pClassOfService
                .Parameters.Add("@OriginCode", SqlDbType.VarChar, 3).Value = pOrigin
                .Parameters.Add("@DestinationCode", SqlDbType.VarChar, 3).Value = pDestination

                .CommandText = "SELECT TOP 1 ISNULL(RTRIM(cabinDescription), '') AS CabinDescription
                                , ISNULL(twref_Air_Classes.Description, '') AS classDescription
                                , ISNULL(twref_Air_Classes.cabinClass, '') AS cabinClass
                                FROM TWS_MIS.mis.twref_Air_Classes
                                LEFT JOIN TWS_MIS.mis.twref_City_Code oCity
                                ON oCity.Code = @OriginCode
                                LEFT JOIN TWS_MIS.mis.twref_City_Code dCity
                                ON dCity.Code = @DestinationCode
                                LEFT JOIN TWS_MIS.mis.twref_Airline_Code
                                ON twref_Airline_Code.Code = @Carrier
                                WHERE @ClassCode = classcode 
                                AND (carrier = '*' OR carrier = @Carrier)                     
                                AND (dep = '*' OR dep = @OriginCode OR dep = '*' + oCity.CountryCode OR dep = oCity.ContinentCode)                     
                                AND (arr = '*' OR arr = @DestinationCode OR arr = '*' + dCity.CountryCode OR arr = dCity.ContinentCode)
                                ORDER BY carrier DESC, dep DESC, arr DESC"
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                If .Read Then
                    pItem.SetValues(pCarrier, pOrigin, pDestination, pClassOfService, CStr(.Item("CabinDescription")), CStr(.Item("classDescription")), CStr(.Item("cabinClass")))
                    mClassCollection.Add(pItem.Key, pItem)
                End If
                .Close()
            End With
            pobjConn.Close()
        End If
        Return pItem

    End Function
End Class
