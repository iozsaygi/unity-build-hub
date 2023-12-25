using UnityBuildHub.Editor.Kernel.Configurations;
using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Tasks
{
    internal sealed class WindowsSetupEditorSettings : IPreBuildTask
    {
        public string Name => "Windows Setup Editor Settings";

        public void Perform(PlatformExecutableBuildConfiguration platformExecutableBuildConfiguration)
        {
            BuildOperations.EnsureActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
            BuildOperations.EnsureScriptingBackend(BuildTargetGroup.Standalone,
                platformExecutableBuildConfiguration.ScriptingImplementation);

            // TODO: Figure out if this is needed for Windows x64 builds.
            // BuildOperations.EnsureArchitectureForBuildTargetGroup(BuildTargetGroup.Standalone, 0);
        }
    }
}