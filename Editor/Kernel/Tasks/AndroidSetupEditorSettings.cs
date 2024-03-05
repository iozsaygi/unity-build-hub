using UnityBuildHub.Editor.Kernel.Configurations;
using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;

// ReSharper disable CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Tasks
{
    internal sealed class AndroidSetupEditorSettings : IPreBuildTask
    {
        public string Name => "Android Setup Editor Settings";

        public void Perform(PlatformExecutableBuildConfiguration platformExecutableBuildConfiguration)
        {
            BuildOperations.EnsureActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
            BuildOperations.EnsureScriptingBackend(BuildTargetGroup.Android,
                platformExecutableBuildConfiguration.ScriptingImplementation);
        }
    }
}