using UnityBuildHub.Editor.Kernel.Configurations;
using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityEditor;

// ReSharper disable CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Tasks
{
    internal sealed class AndroidSignKeystore : IPreBuildTask
    {
        public string Name => "Android Sign Keystore";

        public void Perform(PlatformExecutableBuildConfiguration platformExecutableBuildConfiguration)
        {
            // Update with your keystore values.
            PlayerSettings.Android.keystoreName = string.Empty;
            PlayerSettings.Android.keystorePass = string.Empty;
            PlayerSettings.Android.keyaliasName = string.Empty;
            PlayerSettings.Android.keyaliasPass = string.Empty;
        }
    }
}