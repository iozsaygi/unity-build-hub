# Unity Build Hub

Unity Build Hub is a DevOps and continuous integration utility for the Unity engine to provide built-in build operations
to third-party tools such as [Jenkins](https://www.jenkins.io/) and [TeamCity](https://www.jetbrains.com/teamcity/).

## Prerequisites

* [Unity](https://unity.com/) 2022.3 or higher
* Build server running Jenkins or TeamCity

## Supported build operations

* MacOS x64 IL2CPP
* Windows x64 Mono
* Windows x64 IL2CPP
* Android Mono
* Android IL2CPP

## Installation

* Add package from git URL ``https://github.com/iozsaygi/unity-build-hub.git`` or download
  the [latest release](https://github.com/iozsaygi/unity-build-hub/releases/latest)

## Jenkins item configuration

Assuming the Jenkins instance Unity Build Hub is working on already has
the [Unity3d](https://plugins.jenkins.io/unity3d-plugin/) plugin installed, this is how Unity Build Hub can be linked to
the Jenkins item that produces builds by using the Unity engine.
![Jenkins Item Configuration](https://github.com/iozsaygi/unity-build-hub/blob/main/Images/JenkinsItemConfiguration.png?raw=true)
Notice how we exactly added the path to the function that triggers macOS builds in the command line arguments for
Jenkins item configuration.

## Injecting custom build configurations

Unity Build Hub primarily works on top of custom build configurations to allow full editing of the build's behavior,
including pre- and post-build time. The API also allows developers to pass their custom build configurations with custom
pre-build and post-build tasks.

See the basic example below for using custom build configuration:

```csharp
// Create the custom build configuration.
var platformExecutableBuildConfiguration = new PlatformExecutableBuildConfiguration
(
    // Custom options for Unity's internal build pipeline.
    new BuildPlayerOptions()
    {
        scenes = BuildOperations.FindAvailableScenesForBuild(),
        locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.StandaloneWindows64),
        targetGroup = BuildTargetGroup.Standalone,
        target = BuildTarget.StandaloneWindows64,
        options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
    },

    // Desired scripting backend for your build platform. (Mono, IL2CPP etc.)
    ScriptingImplementation.Mono2x,

    // Custom pre-build tasks that you want to trigger before actual Unity build.
    new IPreBuildTask[]
    {
        // Example pre-build task.
        new WindowsSetupEditorSettings()
    },

    // Custom post-build tasks that you want to trigger after actual Unity build.
    new IPostBuildTask[]
    {
    },

    // Should builds also fail if any warnings are detected in the build log generated by Unity?
    true
);

// Create the actual builder with the custom build configuration we just created.
var platformExecutableBuilder = new PlatformExecutableBuilder(platformExecutableBuildConfiguration);

// Execute the registered pre-build tasks first.
platformExecutableBuilder.PerformPreBuildTasks();

// Execute the actual Unity build and directly analyze its result.
platformExecutableBuilder.AnalyzeBuildReport(platformExecutableBuilder.PerformCoreBuildOperation());

// Execute the registered post-build tasks.
platformExecutableBuilder.PerformPostBuildTasks();
```

## Further customizing the build pipeline

Unity Build Hub already comes with a default builder that builds executable files for specified platforms, but if you
like to take more control over it, you can always implement your own builders.

For instance, you can create different types of builders by implementing the `Builder` abstract class.

See the example below:

```csharp
// Implement this class for your builder.
public abstract class Builder
{
    // Define how builder is going to perform attached pre-build tasks.
    public abstract void PerformPreBuildTasks();

    // Define what is the core build operation for the builder.
    public abstract BuildReport PerformCoreBuildOperation();

    // Define way of analyzing Unity produced build report for the builder.
    public abstract void AnalyzeBuildReport(BuildReport buildReport);

    // Define how builder is going to perform attached post-build tasks.
    public abstract void PerformPostBuildTasks();
}

// Create your own custom builder.
public class CustomBuilderImplementation : Builder
{
    public override void PerformPreBuildTasks()
    {
        // Your custom way of performing pre-build tasks goes here.
    }

    public override BuildReport PerformCoreBuildOperations()
    {
        // Your custom way of performing core build operations goes here.
    }

    public override void AnalyzeBuildReport(BuildReport buildReport)
    {
        // Your custom way to analyze build reports produced by Unity.
    }

    public override void PerformPostBuildTasks()
    {
        // Your custom way of performing post-build tasks goes here.
    }
}
```

## Changelog

Please see [CHANGELOG](https://github.com/iozsaygi/unity-build-hub/blob/main/CHANGELOG.md) for detailed information.

## License

[MIT License](https://github.com/iozsaygi/unity-build-hub/blob/main/LICENSE)