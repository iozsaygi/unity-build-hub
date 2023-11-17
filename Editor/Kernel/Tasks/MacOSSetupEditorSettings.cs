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

            // TODO: Not sure about this one. Research needed.
            // TODO: Also an utility function to set architecture for specific platform in 'BuildOperations.cs' would be cool.
            // 0 - None, 1 - ARM64, 2 - Universal
            PlayerSettings.SetArchitecture(BuildTargetGroup.Standalone, 1);
        }
    }
}