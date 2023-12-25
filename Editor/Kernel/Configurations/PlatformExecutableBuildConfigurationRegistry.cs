using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityBuildHub.Editor.Kernel.Tasks;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Configurations
{
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
    }
}