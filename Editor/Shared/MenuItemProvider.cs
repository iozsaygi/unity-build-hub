using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Shared
{
    /// <summary>
    /// Simple static class to expose built-int builders to the Unity editor.
    /// </summary>
    internal static class MenuItemProvider
    {
        [MenuItem("Unity Build Hub/Build/MacOS x64 IL2CPP")]
        internal static void ExecuteMacOSX64IL2CPPBuild()
        {
            CIEndpointProvider.MacOSX64IL2CPP();
        }
    }
}