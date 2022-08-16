using Microsoft.Maui.LifecycleEvents;

namespace ReproLifecycleEventsCrash;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureLifecycleEvents(events =>
            {
#if MACCATALYST
                    events.AddiOS(ios => ios
                        .OnActivated((scene) => LogEvent("OnActivated"))
                        .OnResignActivation((scene) => LogEvent("OnResignActivation"))
                        .DidEnterBackground((scene) => LogEvent("DidEnterBackground"))
                        .WillTerminate((scene) => LogEvent("WillTerminate"))
                        .SceneDidDisconnect((scene) => LogEvent("SceneDidDisconnect"))
                        .SceneWillConnect((scene, session, connectionOptions) => LogEvent("SceneWillConnect")));
#endif
                static void LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                }
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

