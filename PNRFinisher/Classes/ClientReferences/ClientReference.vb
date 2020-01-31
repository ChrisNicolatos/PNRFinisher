Option Strict On
Option Explicit On
Public Class ClientReference
    Public ReadOnly Property SequenceNo As Integer = 0
    Public ReadOnly Property Id As String = ""
    Public ReadOnly Property Title As String = ""
    Public ReadOnly Property AmadeusTemplate As String = ""
    Public ReadOnly Property GalileoTemplate As String = ""
    Public ReadOnly Property Mandatory As Boolean = False
    Public ReadOnly Property MandatoryForPax As Boolean = False
    Public ReadOnly Property LookupValues As ClientReferenceItemValuesCollection
    Public ReadOnly Property LimitToLookup As Boolean = False
    Public Property SelectedValue As ClientReferenceItemValue
    Public Property PaxReferences As Collections.Generic.Dictionary(Of Integer, ClientReferencePax)
    Public ReadOnly Property IsVessel As Boolean = False
    Public ReadOnly Property AmadeusEntry As String
        Get
            Return AmadeusTemplate & SelectedValue.Code
        End Get
    End Property
    Public ReadOnly Property GalileoEntry As String
        Get
            Return GalileoTemplate & SelectedValue.Code
        End Get
    End Property
    Public ReadOnly Property AmadeusEntry(ByVal PaxId As Integer) As String
        Get
            Return AmadeusTemplate & PaxReferences(PaxId).Reference & "/P" & CStr(PaxReferences(PaxId).ElementID)
        End Get
    End Property
    Public ReadOnly Property GalileoEntry(ByVal PaxId As Integer) As String
        Get
            Return GalileoTemplate & PaxReferences(PaxId).Reference & "/P" & CStr(PaxReferences(PaxId).ElementID)
        End Get
    End Property
    Public Sub New(ByVal SequenceNo As Integer, ByVal Id As String, ByVal Title As String, ByVal AmadeusTemplate As String, ByVal GalileoTemplate As String, ByVal Mandatory As Boolean, ByVal MandatoryForPax As Boolean, ByVal LookupValues As ClientReferenceItemValuesCollection, ByVal LimitToLookup As Boolean)
        Me.SequenceNo = SequenceNo
        Me.Id = Id
        Me.Title = Title
        Me.AmadeusTemplate = AmadeusTemplate
        Me.GalileoTemplate = GalileoTemplate
        Me.Mandatory = Mandatory
        Me.MandatoryForPax = MandatoryForPax
        Me.LookupValues = LookupValues
        Me.LimitToLookup = LimitToLookup
    End Sub
    Public Sub New(ByVal SequenceNo As Integer, ByVal Id As String, ByVal Title As String, ByVal AmadeusTemplate As String, ByVal GalileoTemplate As String, ByVal Mandatory As Boolean, ByVal MandatoryForPax As Boolean, ByVal LookupValuesString As String, ByVal LimitToLookup As Boolean)
        ' Travel Force
        ' All lookup values
        Me.SequenceNo = SequenceNo
        Me.Id = Id
        Me.Title = Title
        Me.AmadeusTemplate = AmadeusTemplate
        Me.GalileoTemplate = GalileoTemplate
        Me.Mandatory = Mandatory
        Me.MandatoryForPax = MandatoryForPax
        Me.LookupValues = New ClientReferenceItemValuesCollection(LookupValuesString)
        Me.LimitToLookup = LimitToLookup
    End Sub
    Public Sub New(ByVal SequenceNo As Integer, ByVal EntityId As Integer, ByVal Id As String, ByVal AmadeusTemplate As String, ByVal GalileoTemplate As String, ByVal Title As String, ByVal IsVessel As Boolean)
        ' Discovery
        ' PO
        ' CC1 CC2
        ' BBY
        Me.SequenceNo = SequenceNo
        Me.Id = Id.Trim
        Me.Title = Title.Trim
        Me.AmadeusTemplate = AmadeusTemplate
        Me.GalileoTemplate = GalileoTemplate
        Me.LookupValues = New ClientReferenceItemValuesCollection(EntityId, Id)
        Me.LimitToLookup = LookupValues.Count > 0
        Me.IsVessel = IsVessel
        If Me.Title <> "" Or Me.LimitToLookup Then
            Me.Mandatory = True
            Me.MandatoryForPax = False
        End If
        If Me.Mandatory And Me.Title = "" Then
            Me.Title = Title
        End If
        If Me.Title = "" Then
            Me.SequenceNo = 0
        End If
    End Sub

    Public Sub New(ByVal SequenceNo As Integer, ByVal EntityId As Integer, ByVal Id As String, ByVal AmadeusTemplate As String, ByVal GalileoTemplate As String, ByVal Title As String, ByVal Mandatory As Boolean, ByVal MandatoryForPax As Boolean)
        ' Discovery
        ' REFxx
        Me.SequenceNo = SequenceNo
        Me.Id = Id.Trim
        Me.Title = Title.Trim
        Me.AmadeusTemplate = AmadeusTemplate
        Me.GalileoTemplate = GalileoTemplate
        Me.Mandatory = Mandatory
        Me.MandatoryForPax = MandatoryForPax
        Me.LookupValues = New ClientReferenceItemValuesCollection(EntityId, Id)
        Me.LimitToLookup = LookupValues.Count > 0
        If (Me.Mandatory Or Me.MandatoryForPax Or Me.LimitToLookup) And Me.Title = "" Then
            Me.Title = Title
        End If
        If Me.Title = "" Then
            Me.SequenceNo = 0
        End If
    End Sub
End Class
