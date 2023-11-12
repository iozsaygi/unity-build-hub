using System;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel
{
    internal static class BuilderConfigurationRegistry
    {
        // ReSharper disable once IdentifierTypo
        internal static readonly BuilderConfiguration MacOSIL2CPPBuilderConfiguration = new
        (new BuildPlayerOptions
        {
            scenes = BuildOperations.FindAvailableScenesForBuild(),
            locationPathName = BuildOperations.FindTargetBuildFilePath(BuildTarget.StandaloneOSX),
            targetGroup = BuildTargetGroup.Standalone,
            target = BuildTarget.StandaloneOSX,
            options = BuildOptions.StrictMode | BuildOptions.DetailedBuildReport
        }, Array.Empty<IPreBuildTask>());
    }
}