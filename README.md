CCNetSlackPublisher
===================

Slack.com integration with CruiseControl.NET

To get this to work, add an Incoming WebHooks integration in Slack. You'll need your "Unique Webhook URL" for later when you configure the Slack CCNet publisher.  In the Integration Settings in Slack, set the channel you'd like CCNet to post to (e.g. #ccnet).  Also, change the name of your bot (e.g. CCNet) and the bot icon if you want.

Clone/build the solution (SlackPublisher.sln; Visual Studio 2012). In the build output folder, copy the CCNet.SlackPublisher.plugin.dll assembly and paste it into your CruiseControl.NET\server folder. This is where your ccnet.config, ccnet.exe, ccservice.exe, etc. lives.

Modify your ccnet.config by adding the Slack publisher:

```
<publishers>
 <slackPublisher webhookUrl="<your webhook URL here>" />
</publishers>
```

That's all! Test out everything by doing a few builds and watch Slack for messages.

#### Notes:
* The target framework for the plugin DLL is set to .NET Framework 3.5. When it was .NET 4/4.5, CCNet errored to the Event Viewer with "This assembly is built by a runtime newer than the currently loaded runtime and cannot be loaded." This may be different for different versions of CCNet (I'm on 1.6)
* The CCNet assemblies included and referenced are from v1.6. If you have another version of CCNet, you can try putting its assemblies into the lib folder and updating the project references. The 3 DLLs you'll need to copy from the CruiseControl.NET\server folder are: NetReflector.dll, ThoughtWorks.CruiseControl.Core.dll and ThoughtWorks.CruiseControl.Remote.dll.
