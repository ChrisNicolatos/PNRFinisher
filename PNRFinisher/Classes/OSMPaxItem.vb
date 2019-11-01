Option Strict On
Option Explicit On
Public Class OSMPaxItem
    Public ReadOnly Property Id As Integer
    Public ReadOnly Property LastName As String
    Public ReadOnly Property FirstName As String
    Public ReadOnly Property Nationality As String
    Public ReadOnly Property Text As String
    Public ReadOnly Property TextFullDetails As String
    Public Property JoinerLeaver As String
    Public Sub New(ByVal pId As Integer, ByVal pJoiner As String, ByVal pText As String)
        Id = pId
        TextFullDetails = pText
        Text = ""
        Dim pLines() As String = pText.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        For i As Integer = 0 To pLines.GetUpperBound(0)
            If pLines(i).ToUpper.StartsWith("LAST NAME") Then
                Text &= pLines(i) & vbCrLf
                Dim pN() As String = pLines(i).Split(":"c)
                LastName = pN(1).Trim
            ElseIf pLines(i).ToUpper.StartsWith("FIRST AND MIDDLE NAMES") Then
                Text &= pLines(i) & vbCrLf
                Dim pN() As String = pLines(i).Split(":"c)
                FirstName = pN(1).Trim
            ElseIf pLines(i).ToUpper.StartsWith("NATIONALITY") Then
                Dim pN() As String = pLines(i).Split(":"c)
                Nationality = pN(1).Trim
            ElseIf pLines(i).ToUpper.StartsWith("POSITION") Then
                Text &= pLines(i) & vbCrLf & vbCrLf
            End If
        Next
        JoinerLeaver = pJoiner
    End Sub
End Class