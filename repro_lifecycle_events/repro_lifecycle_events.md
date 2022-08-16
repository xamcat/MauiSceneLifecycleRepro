# Repro: Application Lifecycle Events Crash
This solution attempts to reproduce a crash on macOS as a result of configuring platform-specific lifecycle event handlers in accordance with the official [App lifecycle documentation](https://docs.microsoft.com/dotnet/maui/fundamentals/app-lifecycle#ios).

Primary issue:
- [FIDELITY POC REPO] [Hooking to macOS Application Lifecycle events](https://github.com/xamcat/fid-nxt-gen-dsktp/issues/201)

Related issues:
- [.NET MAUI REPO] [Hooking to macOS Application Lifecycle events](https://github.com/dotnet/maui/issues/5840)

## Repro Setup
The [ReproLifecycleEventsCrash repro solution](ReproLifecycleEventsCrash.sln) represents a file -> new .NET MAUI App with the following configuration applied via the **ConfigureLifecycleEvents** builder method in MauiProgram.cs:

```csharp
public static MauiApp CreateMauiApp()
{
	var builder = MauiApp.CreateBuilder();
	builder
		.UseMauiApp<App>()
		.ConfigureLifecycleEvents(events =>
        {
#if IOS || MACCATALYST
            events.AddiOS(ios => ios
                .OnActivated((app) => LogEvent("OnActivated"))
                .OnResignActivation((app) => LogEvent("OnResignActivation"))
                .DidEnterBackground((app) => LogEvent("DidEnterBackground"))
                .WillTerminate((app) => LogEvent("WillTerminate")));
#endif
            static void LogEvent(string eventName, string type = null)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
            }
        })
	    .ConfigureFonts(fonts =>
	    {
		    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
		    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
	    });

	return builder.Build();
}
```

## Outcomes and Recommendations

Unable to reproduce when testing using **.NET 6.0.302** with the following workloads:

| Installed Workload Ids      | Installation Source |
| --------------------------- | ------------------- |
| wasm-tools                  | SDK 6.0.300         |
| macos                       | SDK 6.0.300         |
| maui-ios                    | SDK 6.0.300         |
| maui-android                | SDK 6.0.300         |
| ios                         | SDK 6.0.300         |
| maccatalyst                 | SDK 6.0.300         |
| maui                        | SDK 6.0.300         |
| tvos                        | SDK 6.0.300         |
| android                     | SDK 6.0.300         |