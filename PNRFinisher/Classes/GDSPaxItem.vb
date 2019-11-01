Option Strict On
Option Explicit On
Public Class GDSPaxItem
    Public ReadOnly Property ElementNo As Integer
    Public ReadOnly Property FirstName As String
    Public ReadOnly Property Initial As String
    Public ReadOnly Property LastName As String
    Public ReadOnly Property PaxID As String
    Public ReadOnly Property PaxName As String
    Public ReadOnly Property IdNo As String
    Public ReadOnly Property Department As String
    Public ReadOnly Property Nationality As String
    Friend Sub New(ByRef pElementNo As Integer, ByRef pInitial As String, ByRef pLastName As String, ByRef pID As String)

        ElementNo = pElementNo
        Initial = IsNothingToString(pInitial).Trim
        FirstName = ModifyFirstName(Initial)
        LastName = pLastName.Trim
        PaxName = LastName & "/" & Initial
        PaxID = pID
        If PaxID.StartsWith("(") Then
            Dim pSplit() As String = PaxID.Replace("(", "").Replace(")", "").Split({","}, StringSplitOptions.RemoveEmptyEntries)
            If pSplit.GetUpperBound(0) >= 2 Then
                Nationality = pSplit(2)
            End If
            If pSplit.GetUpperBound(0) >= 1 Then
                Department = pSplit(1)
            End If
            If pSplit.GetUpperBound(0) >= 0 Then
                IdNo = pSplit(0).Replace("ID", "").Trim
            End If
        End If
    End Sub
    Private Function ModifyFirstName(ByVal FirstName As String) As String
        Dim pSalutations As New ReferenceSalutationsCollection
        Dim pintFindPos As Integer
        If FirstName Is Nothing Then
            FirstName = ""
        End If
        FirstName = FirstName.Trim
        For Each pItem As ReferenceItem In pSalutations.Values
            pintFindPos = FirstName.IndexOf(pItem.Code)
            If pintFindPos > 0 And pintFindPos = FirstName.Length - pItem.Code.Length Then
                FirstName = FirstName.Substring(0, pintFindPos).Trim
            End If
        Next
        Return FirstName
    End Function
End Class
