using UnityBuildHub.Editor.Kernel.Configurations;
using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Tasks
{
    internal sealed class MacOSSetupEditorSettings : IPreBuildTask
    {
        public string Name => "MacOS Setup Editor Settings";

        public void Perform(PlatformExecutableBuildConfiguration platformExecutableBuildConfiguration)
        {
            BuildOperations.EnsureActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX);
            BuildOperations.EnsureScriptingBackend(BuildTargetGroup.Standalone,
                platformExecutableBuildConfiguration.ScriptingImplementation);

            BuildOperations.EnsureArchitectureForBuildTargetGroup(BuildTargetGroup.Standalone, 1);
        }
    }
}