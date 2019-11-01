Option Strict On
Option Explicit On
Public Class OSMPaxCollection
    Inherits Collections.Generic.Dictionary(Of Integer, OSMPaxItem)
    Public Sub Load(ByVal pText As String)
        Dim pId As Integer = 0
        Dim pJoiner As String = ""
        Dim pPax As String = ""
        Dim pPaxLoading As Boolean = False
        Dim pLines() As String = pText.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        MyBase.Clear()
        For i As Integer = 0 To pLines.GetUpperBound(0)
            If Not pPaxLoading Then
                If pLines(i).ToUpper.IndexOf("SIGN") >= 0 AndAlso pLines(i).ToUpper.IndexOf("OFF") >= 0 Then
                    pJoiner = "OFFSIGNER"
                ElseIf pLines(i).ToUpper.IndexOf("SIGN") >= 0 AndAlso pLines(i).ToUpper.IndexOf("ON") >= 0 Then
                    pJoiner = "ONSIGNER"
                End If
            End If
            If pLines(i).ToUpper.StartsWith("LAST NAME") Then
                If pPaxLoading Then
                    pId += 1
                    Dim pItem As New OSMPaxItem(pId, pJoiner, pPax)
                    MyBase.Add(pItem.Id, pItem)
                End If
                pPax = pLines(i) & vbCrLf
                pPaxLoading = True
            ElseIf pLines(i).ToUpper.StartsWith("CLOSEST AIRPORT") Then
                pPax &= pLines(i)
                pId += 1
                Dim pItem As New OSMPaxItem(pId, pJoiner, pPax)
                MyBase.Add(pItem.Id, pItem)
                pPaxLoading = False
            ElseIf pPaxLoading Then
                pPax &= pLines(i) & vbCrLf
            End If
        Next
        If pPaxLoading Then
            pId += 1
            Dim pItem As New OSMPaxItem(pId, pJoiner, pPax)
            MyBase.Add(pItem.Id, pItem)
        End If
    End Sub
End Class