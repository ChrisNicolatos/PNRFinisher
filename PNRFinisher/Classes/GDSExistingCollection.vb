Option Strict On
Option Explicit On
Public Class GDSExistingCollection
    Private mobjOpenSegment As New GDSExistingItem
    Private mobjPhoneElement As New GDSExistingItem
    Private mobjAgentElement As New GDSExistingItem
    Private mobjEmailElement As New GDSExistingItem
    Private mobjTicketElement As New GDSExistingItem
    Private mobjOptionQueueElement As New GDSExistingItem
    Private mobjAOH As New GDSExistingItem
    Private mobjAgentID As New GDSExistingItem
    Private mobjSavingsElement As New GDSExistingItem
    Private mobjLossElement As New GDSExistingItem

    Private mobjCustomerCodeAI As New GDSExistingItem
    Private mobjCustomerCode As New GDSExistingItem
    Private mobjCustomerName As New GDSExistingItem
    Private mobjSubDepartmentCode As New GDSExistingItem
    Private mobjSubDepartmentName As New GDSExistingItem
    Private mobjCRMCode As New GDSExistingItem
    Private mobjCRMName As New GDSExistingItem
    Private mobjVesselName As New GDSExistingItem
    Private mobjVesselFlag As New GDSExistingItem
    Private mobjVesselOSI As New GDSExistingItem
    Private mobjReference As New GDSExistingItem
    Private mobjBookedBy As New GDSExistingItem
    Private mobjDepartment As New GDSExistingItem
    Private mobjReasonForTravel As New GDSExistingItem
    Private mobjCostCentre As New GDSExistingItem
    Private mobjTRId As New GDSExistingItem

    Public ReadOnly Property OpenSegment As GDSExistingItem
        Get
            Return mobjOpenSegment
        End Get
    End Property
    Public ReadOnly Property PhoneElement As GDSExistingItem
        Get
            Return mobjPhoneElement
        End Get
    End Property
    Public ReadOnly Property AgentElement As GDSExistingItem
        Get
            Return mobjAgentElement
        End Get
    End Property
    Public ReadOnly Property EmailElement As GDSExistingItem
        Get
            Return mobjEmailElement
        End Get
    End Property
    Public ReadOnly Property TicketElement As GDSExistingItem
        Get
            Return mobjTicketElement
        End Get
    End Property
    Public ReadOnly Property OptionQueueElement As GDSExistingItem
        Get
            Return mobjOptionQueueElement
        End Get
    End Property
    Public ReadOnly Property AOH As GDSExistingItem
        Get
            Return mobjAOH
        End Get
    End Property
    Public ReadOnly Property AgentID As GDSExistingItem
        Get
            Return mobjAgentID
        End Get
    End Property
    Public ReadOnly Property SavingsElement As GDSExistingItem
        Get
            Return mobjSavingsElement
        End Get
    End Property
    Public ReadOnly Property LossElement As GDSExistingItem
        Get
            Return mobjLossElement
        End Get
    End Property
    Public ReadOnly Property CustomerCodeAI As GDSExistingItem
        Get
            Return mobjCustomerCodeAI
        End Get
    End Property
    Public ReadOnly Property CustomerCode As GDSExistingItem
        Get
            Return mobjCustomerCode
        End Get
    End Property
    Public ReadOnly Property CustomerName As GDSExistingItem
        Get
            Return mobjCustomerName
        End Get
    End Property
    Public ReadOnly Property SubDepartmentCode As GDSExistingItem
        Get
            Return mobjSubDepartmentCode
        End Get
    End Property
    Public ReadOnly Property SubDepartmentName As GDSExistingItem
        Get
            Return mobjSubDepartmentName
        End Get
    End Property
    Public ReadOnly Property CRMCode As GDSExistingItem
        Get
            Return mobjCRMCode
        End Get
    End Property
    Public ReadOnly Property CRMName As GDSExistingItem
        Get
            Return mobjCRMName
        End Get
    End Property
    Public ReadOnly Property VesselName As GDSExistingItem
        Get
            Return mobjVesselName
        End Get
    End Property
    Public ReadOnly Property VesselFlag As GDSExistingItem
        Get
            Return mobjVesselFlag
        End Get
    End Property
    Public ReadOnly Property VesselOSI As GDSExistingItem
        Get
            Return mobjVesselOSI
        End Get
    End Property
    Public ReadOnly Property Reference As GDSExistingItem
        Get
            Return mobjReference
        End Get
    End Property
    Public ReadOnly Property BookedBy As GDSExistingItem
        Get
            Return mobjBookedBy
        End Get
    End Property
    Public ReadOnly Property Department As GDSExistingItem
        Get
            Return mobjDepartment
        End Get
    End Property
    Public ReadOnly Property ReasonForTravel As GDSExistingItem
        Get
            Return mobjReasonForTravel
        End Get
    End Property
    Public ReadOnly Property CostCentre As GDSExistingItem
        Get
            Return mobjCostCentre
        End Get
    End Property
    Public ReadOnly Property TRId As GDSExistingItem
        Get
            Return mobjTRId
        End Get
    End Property
    Public Sub Clear()
        mobjOpenSegment.Clear()
        mobjPhoneElement.Clear()
        mobjAgentElement.Clear()
        mobjEmailElement.Clear()
        mobjTicketElement.Clear()
        mobjOptionQueueElement.Clear()
        mobjAOH.Clear()
        mobjAgentID.Clear()
        mobjSavingsElement.Clear()
        mobjLossElement.Clear()

        mobjCustomerCodeAI.Clear()
        mobjCustomerCode.Clear()
        mobjCustomerName.Clear()
        mobjSubDepartmentCode.Clear()
        mobjSubDepartmentName.Clear()
        mobjCRMCode.Clear()
        mobjCRMName.Clear()
        mobjVesselName.Clear()
        mobjVesselFlag.Clear()
        mobjVesselOSI.Clear()
        mobjReference.Clear()
        mobjBookedBy.Clear()
        mobjDepartment.Clear()
        mobjReasonForTravel.Clear()
        mobjCostCentre.Clear()
    End Sub

End Class