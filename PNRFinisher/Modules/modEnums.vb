Option Strict On
Option Explicit On
Public Module modEnums
    Public Enum EnumItnFormat
        DefaultFormat = 0
        Plain = 1
        SeaChefs = 2
        SeaChefsWithCode = 3
        Euronav = 4
        Fleet = 5
        AimeryMoxie = 6
    End Enum
    Public Enum EnumGDSCode
        Unknown = 0
        Amadeus = 1
        Galileo = 2
    End Enum
    Public Enum EnumBOCode
        Unknown = 0
        ATH = 1
        QLI = 2
    End Enum
    'Public Enum EnumClientReferenceID As Integer
    '    None = 0
    '    BookedBy = 1
    '    Department = 2
    '    ReasonFortravel = 4
    '    CostCentre = 5
    '    Savings = 6
    '    Losses = 7
    '    SavingsLossesReason = 8
    '    TravelDefinition = 9
    '    VesselCostCentre = 10
    '    RequisitionNumber = 11
    '    PassengerID = 12
    '    OPT = 13
    '    TRId = 14
    '    SubDepartment = 901
    '    CRM = 902
    '    Reference = 903
    'End Enum
    Public Enum EnumTicketDocType
        NONE = 0
        ETKT = 1
        VCHR = 2
        INTR = 3
    End Enum
    Public Enum ClientReferenceRequiredType
        PropertyNone = 0
        PropertyOptional = 613
        PropertyReqToSave = 614
        PropertyReqToInv = 615
    End Enum
    Public Enum EnumLoGLanguage
        English = 0
        Brazil = 1
    End Enum
End Module
