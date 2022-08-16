using System.Diagnostics;
using Foundation;
using Microsoft.Maui;
using UIKit;

namespace ReproLifecycleEventsCrash;

[Register("SceneDelegate")]
public class SceneDelegate : MauiUISceneDelegate
{
    public SceneDelegate()
    {
    }

    public override void DidDisconnect(UIScene scene)
    {
        base.DidDisconnect(scene);
        Debug.WriteLine("SCENE : DID DISCONNECT");
    }

    public override void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
    {
        base.WillConnect(scene, session, connectionOptions);
        Debug.WriteLine("SCENE : WILL CONNECT");

        var test = GetStateRestorationActivity(scene);
        Debug.WriteLine($"SCENE RESTORATION STATE : {test} ");

    }
}

