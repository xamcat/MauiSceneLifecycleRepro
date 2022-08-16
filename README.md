# MauiSceneLifecycleRepro

Looking at Apple's [UISceneDelegate Documentation](https://developer.apple.com/documentation/uikit/uiscenedelegate) and comparing it to current .NET MAUI implementation of [MAUISceneDelegate](https://github.com/dotnet/maui/blob/main/src/Core/src/Platform/iOS/MauiUISceneDelegate.cs), there are a few missing UISceneDelegate Lifecycle events. 

## Expected Behavior

All Life Cycle events for SceneDelegate to fire :

- scene(_:willConnectTo:options:)

-  sceneDidDisconnect(_:)

- sceneDidBecomeActive(_:)
	
- sceneWillResignActive(_:)
	
- sceneWillEnterForeground(_:)
	
- sceneDidEnterBackground(_:)

- sceneWilLConnect(_:)


## Current Behavior

Only 2 of the implemented life cycle events work,

- WillConnect
	
- DidDisconnect

other life cycle events do not fire. 
