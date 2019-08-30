Option Strict Off
Option Explicit On
Public Class GDSAssociationsCollection
    Dim mPaxCollection As Collections.ObjectModel.ReadOnlyCollection(Of Integer)
    Dim mSegCollection As Collections.ObjectModel.ReadOnlyCollection(Of Integer)
    Public Sub LoadAssociations(ByVal PNRElement As Object)

        Dim pPaxCollection As New Collections.Generic.List(Of Integer)
        Dim pSegCollection As New Collections.Generic.List(Of Integer)

        pPaxCollection.Clear()
        pSegCollection.Clear()

        Try
            If PNRElement.Associations.Passengers.Count > 0 Then
                For Each objPax In PNRElement.Associations.Passengers
                    pPaxCollection.Add(objPax.ElementNo)
                Next
            End If
            If PNRElement.Associations.Segments.Count > 0 Then
                For Each objPax In PNRElement.Associations.Segments
                    pSegCollection.Add(objPax.ElementNo)
                Next
            End If
            mPaxCollection = New Collections.ObjectModel.ReadOnlyCollection(Of Integer)(pPaxCollection)

        Catch ex As Exception
        End Try
    End Sub
    Public ReadOnly Property PaxAssociations As Collections.ObjectModel.ReadOnlyCollection(Of Integer)
        Get
            Return mPaxCollection
        End Get
    End Property
    Public ReadOnly Property SegAssociation As Collections.ObjectModel.ReadOnlyCollection(Of Integer)
        Get
            Return mSegCollection
        End Get
    End Property
End Class
