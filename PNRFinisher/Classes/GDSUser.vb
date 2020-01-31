Option Strict Off
Option Explicit On
Public Class GDSUser
    Private Structure ClassProps
        Dim GDSCode As EnumGDSCode
        Dim PCC As String
        Dim User As String
    End Structure
    '    Private mobjSession1G As New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")
    Private mobjSession1G As Travelport.TravelData.Factory.GalileoDesktopFactory
    'Private mudtProps As New ClassProps
    Public ReadOnly Property GDSCode As EnumGDSCode
    '    Get
    '        Return mudtProps.GDSCode
    '    End Get
    'End Property
    Public ReadOnly Property PCC As String
    '    Get
    '        Return mudtProps.PCC.ToUpper
    '    End Get
    'End Property
    Public ReadOnly Property User As String
    '    Get
    '        Return mudtProps.User.ToUpper
    '    End Get
    'End Property
    Public ReadOnly Property GDSCodeAbbreviation As String
        Get
            Select Case GDSCode
                Case EnumGDSCode.Amadeus
                    Return "1A"
                Case EnumGDSCode.Galileo
                    Return "1G"
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Public Sub New(ByVal pGDSCode As EnumGDSCode)

        Try
            GDSCode = pGDSCode
            PCC = ""
            User = ""
            If pGDSCode = EnumGDSCode.Amadeus Then
                Read1AUser()
            ElseIf pGDSCode = EnumGDSCode.Galileo Then
                Read1GUser()
            Else
                Throw New Exception("GDS not available")
            End If

            If PCC = "" Or User = "" Then
                Throw New Exception("Please start " & If(GDSCode = EnumGDSCode.Amadeus, "Amadeus", "Galileo"))
            End If
        Catch ex As Exception
            Throw New Exception("GDS Error" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Read1AUser()

        Dim Sessions As k1aHostToolKit.HostSessions
        Dim Session As k1aHostToolKit.HostSession
        ' To be able to retrieve the PNR that have been created we need to link our '
        ' application to the current session of the FOS                             '
        Sessions = New k1aHostToolKit.HostSessions
        If Sessions.Count > 0 Then
            ' There is at least one session opened.                    '
            ' We link our application to the active session of the FOS '
            Session = Sessions.UIActiveSession
            Session.SendSpecialKey(512 + 282) '(k1aHostConstantsLib.AmaKeyValues.keySHIFT + k1aHostConstantsLib.AmaKeyValues.keyPause)
            Dim pJGD As k1aHostToolKit.CHostResponse = Session.Send("JGD/C")
            Dim pLines() As String = pJGD.Text.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            For i As Integer = 0 To pLines.GetUpperBound(0)
                If pLines(i).Trim.StartsWith("OFFICE") Then
                    _PCC = pLines(i).Substring(pLines(i).IndexOf("-") + 1).Trim
                ElseIf pLines(i).Trim.StartsWith("SIGN ") Then
                    _User = pLines(i).Substring(pLines(i).IndexOf("-") + 1).Trim
                End If
            Next
        End If

    End Sub
    Private Sub Read1GUser()
        Try

            mobjSession1G = New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")

            'Dim pSession As Travelport.TravelData.SessionInformation = mobjSession1G.GetSessionInformation
            '_User = pSession.ActiveArea.SignOnIdentifier.Trim
            '_PCC = pSession.ActiveArea.AgentPcc.Trim

            _User = ""
            _PCC = ""

            If _User = "" Or _PCC = "" Then
                Dim pResponse As ObjectModel.ReadOnlyCollection(Of String) = mobjSession1G.SendTerminalCommand("OP/W*")
                For i As Integer = 0 To pResponse.Count - 1
                    If pResponse(i).Length > 45 AndAlso pResponse(i).Substring(31, 6) = "ACTIVE" Then
                        _User = pResponse(i).Substring(12, 6).Trim
                        _PCC = pResponse(i).Substring(24, 4).Trim
                        Exit For
                    End If
                Next
                If _User = "" Then
                    Throw New Exception(pResponse(0))
                End If
            End If
        Catch ex As Travelport.TravelData.DesktopUserNotSignedOnException
            Throw New Exception("Please start Galileo/Smartpoint")
        Catch ex As Travelport.TravelData.DesktopNotStartedException
            Throw New Exception("Please Sign in to PCC")
        Catch ex As Exception
            Throw New Exception("Please Sign in to PCC")
        End Try

    End Sub
End Class
