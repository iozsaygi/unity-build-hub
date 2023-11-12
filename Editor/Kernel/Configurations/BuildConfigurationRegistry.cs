using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityBuildHub.Editor.Kernel.Tasks;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Configurations
{
    internal static class BuildConfigurationRegistry
    {
        // ReSharper disable once IdentifierTypo
        internal static readonly BuildConfiguration MacOSX64IL2CPPBuildConfiguration = new
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
            }
        );
    }
}