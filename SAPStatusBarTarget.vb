Imports NLog
Imports NLog.Config
Imports NLog.Targets
Imports SAPbouiCOM

<Target("SAPStatusBar")>
Public NotInheritable Class SAPStatusBarTarget
    Inherits TargetWithLayout

    Public Sub New()
        SBO_Application = Nothing
    End Sub

    Public Sub New(SBO_Application As Application)
        Me.SBO_Application = SBO_Application
    End Sub

    <RequiredParameter>
    Public Property SBO_Application As Application

    Protected Overrides Sub Write(logEvent As LogEventInfo)
        Dim logMessage As String = RenderLogEvent(Me.Layout, logEvent)

        If logEvent.Level = LogLevel.Info Then
            SBO_Application?.StatusBar.SetText(logMessage, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success)
        ElseIf logEvent.Level = LogLevel.Warn Then
            SBO_Application?.StatusBar.SetText(logMessage, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning)
        ElseIf logEvent.Level = LogLevel.Error Then
            SBO_Application?.StatusBar.SetText(logMessage, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error)
        End If

    End Sub

End Class