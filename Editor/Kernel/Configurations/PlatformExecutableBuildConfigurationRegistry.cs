using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityBuildHub.Editor.Kernel.Tasks;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Configurations
{
    /// <summary>
    /// Baked configuration registry for faster usage.
    /// Provides several build configurations for following platforms:
    /// Windows, macOS and Android.
    /// </summary>
    internal static class PlatformExecutableBuildConfigurationRegistry
    {
        // Windows x64 Mono configuration.
        internal static readonly PlatformExecutableBuildConfiguration
            WindowsX64MonoPlatformExecutableBuildConfiguration = new
            (
                new BuildPlayerOptions()
                {
                    scenes = BuildOperations.FindAvailableScenesForBuild(),
                    locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.StandaloneWindows64),
                    targetGroup = BuildTargetGroup.Standalone,
                    target = BuildTarget.StandaloneWindows64,
                    options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
                },
                ScriptingImplementation.Mono2x,
                new IPreBuildTask[]
                {
                    new WindowsSetupEditorSettings()
                },
                new IPostBuildTask[]
                {
                }
            );

        // Windows x64 IL2CPP configuration.
        internal static readonly PlatformExecutableBuildConfiguration
            WindowsX64IL2CPPPlatformExecutableBuildConfiguration = new
            (
                new BuildPlayerOptions()
                {
                    scenes = BuildOperations.FindAvailableScenesForBuild(),
                    locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.StandaloneWindows64),
                    targetGroup = BuildTargetGroup.Standalone,
                    target = BuildTarget.StandaloneWindows64,
                    options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
                },
                ScriptingImplementation.IL2CPP,
                new IPreBuildTask[]
                {
                    new WindowsSetupEditorSettings()
                },
                new IPostBuildTask[]
                {
                }
            );

        // MacOS x64 IL2CPP configuration.
        internal static readonly PlatformExecutableBuildConfiguration
            MacOSX64IL2CPPPlatformExecutableBuildConfiguration = new
            (
                new BuildPlayerOptions
                {
                    scenes = BuildOperations.FindAvailableScenesForBuild(),
                    locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.StandaloneOSX),
                    targetGroup = BuildTargetGroup.Standalone,
                    target = BuildTarget.StandaloneOSX,
                    options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
                },
                ScriptingImplementation.IL2CPP,
                new IPreBuildTask[]
                {
                    new MacOSSetupEditorSettings()
                },
                new IPostBuildTask[]
                {
                }
            );

        // Android Mono configuration.
        internal static readonly PlatformExecutableBuildConfiguration
            AndroidMonoPlatformExecutableBuildConfiguration = new
            (
                new BuildPlayerOptions
                {
                    scenes = BuildOperations.FindAvailableScenesForBuild(),
                    locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.Android),
                    targetGroup = BuildTargetGroup.Android,
                    target = BuildTarget.Android,
                    options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
                },
                ScriptingImplementation.Mono2x,
                new IPreBuildTask[]
                {
                    new AndroidSetupEditorSettings(),
                    new AndroidSignKeystore()
                },
                new IPostBuildTask[]
                {
                }
            );

        // Android IL2CPP configuration.
        internal static readonly PlatformExecutableBuildConfiguration
            // ReSharper disable once IdentifierTypo
            AndroidIL2CPPPlatformExecutableBuildConfiguration = new
            (
                new BuildPlayerOptions
                {
                    scenes = BuildOperations.FindAvailableScenesForBuild(),
                    locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.Android),
                    targetGroup = BuildTargetGroup.Android,
                    target = BuildTarget.Android,
                    options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
                },
                ScriptingImplementation.IL2CPP,
                new IPreBuildTask[]
                {
                    new AndroidSetupEditorSettings(),
                    new AndroidSignKeystore()
                },
                new IPostBuildTask[]
                {
                }
            );
    }
}