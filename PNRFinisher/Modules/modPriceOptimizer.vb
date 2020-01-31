Option Strict On
Option Explicit On
    Module modPriceOptimizer
    Public Sub ShowPriceOptimiser(ByRef mParent As Form, ByVal ForceShow As Boolean)
        Dim mGDSUser As GDSUser
        Dim mflgCanContinune As Boolean = True
        Dim mSelectedGDSCode As EnumGDSCode = EnumGDSCode.Unknown
        If MySettings Is Nothing Then
            Try
                mSelectedGDSCode = EnumGDSCode.Amadeus
                mGDSUser = New GDSUser(mSelectedGDSCode)
                InitSettings(mGDSUser)
            Catch ex As Exception
                mflgCanContinune = False
            End Try
            If Not mflgCanContinune Then
                Try
                    mSelectedGDSCode = EnumGDSCode.Galileo
                    mGDSUser = New GDSUser(mSelectedGDSCode)
                    InitSettings(mGDSUser)
                Catch ex As Exception
                    mflgCanContinune = False
                End Try
            End If
        End If
        If mflgCanContinune Then
            Static Dim mfrmOptimiser As frmPriceOptimiser
            If MySettings.PriceOptimiser Then
                If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                    Dim pPCC As String = MySettings.GDSPcc
                    Dim pUserId As String = MySettings.GDSUser
                    ' for testing only
                    '#If DEBUG Then
                    '                    pPCC = "ATHG42100"
                    '                    pUserId = "0306NA"
                    '#End If
                    If mfrmOptimiser Is Nothing OrElse mfrmOptimiser.IsDisposed Then
                        mfrmOptimiser = New frmPriceOptimiser With {
                            .MdiParent = mParent}
                    End If
                    Dim pDisplay As Boolean = mfrmOptimiser.DisplayItems(pPCC, pUserId)
                    If pDisplay Or ForceShow Then ', pHeight, pWidth) 
                        mfrmOptimiser.Show()
                        mfrmOptimiser.BringToFront()
                    End If
                End If
            End If
        End If
    End Sub
End Module
