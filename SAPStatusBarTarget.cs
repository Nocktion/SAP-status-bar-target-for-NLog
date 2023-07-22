using NLog;
using NLog.Config;
using NLog.Targets;
using SAPbouiCOM;

[Target("SAPStatusBar")]
public sealed class SAPStatusBarTarget : TargetWithLayout
{
	public SAPStatusBarTarget() 
	{
		SBO_Application = null;
	}
	
	public SAPStatusBarTarget(Application SBO_Application)
	{
		this.SBO_Application = SBO_Application;
	}
	
	[RequiredParameter]
	public Application SBO_Application { get; set; }
	
	protected override void Write(LogEventInfo logEvent)
	{
		string logMessage = RenderLogEvent(this.Layout, logEvent);
		
		if (logEvent.Level == LogLevel.Info) {
			SBO_Application?.StatusBar.SetText(logMessage, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
		} else if (logEvent.Level == logLevel.Warn) {
			SBO_Application?.StatusBar.SetText(logMessage, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Warning);
		} else if (logEvent.Level == logLevel.Error) {
			SBO_Application?.StatusBar.SetText(logMessage, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
		}
	}
}