# SAP Status Bar target for NLog

A simple NLog target that writes out messages to the status bar in SAP

# Usage

Register the target in the LogManager
```c#
NLog.LogManager.Setup().SetupExtensions(s =>
   s.RegisterTarget<SAPStatusBarTarget>("SAPStatusBar")
);
```

Once you have connected to the SBOGui and have the Application, add the rule to your LoggingConfiguration
```c#
var logSapStatusBar = new SAPStatusBarTarget(SBO_Application)
logSapStatusBar.Layout = "${logger}: ${message:withexception=false}"

config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Error, logSapStatusBar)
```

And there you have it. The 3 LogLevels will be reflected in the status bar messages as well, Info will be written out as a Success, Warn as a Warning and Error as an Error.
