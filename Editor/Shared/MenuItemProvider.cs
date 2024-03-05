using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Shared
{
    /// <summary>
    /// Simple static class to expose built-int builders to the Unity editor.
    /// </summary>
    internal static class MenuItemProvider
    {
        [MenuItem("Unity Build Hub/Build/Windows x64 Mono")]
        internal static void ExecuteWindowsX64MonoBuild()
        {
            CIEndpointProvider.WindowsX64Mono();
        }

        [MenuItem("Unity Build Hub/Build/Windows x64 IL2CPP")]
        internal static void ExecuteWindowsX64IL2CPPBuild()
        {
            CIEndpointProvider.WindowsX64IL2CPP();
        }

        [MenuItem("Unity Build Hub/Build/MacOS x64 IL2CPP")]
        internal static void ExecuteMacOSX64IL2CPPBuild()
        {
            CIEndpointProvider.MacOSX64IL2CPP();
        }

        [MenuItem("Unity Build Hub/Build/Android Mono")]
        internal static void ExecuteAndroidMonoBuild()
        {
            CIEndpointProvider.AndroidMono();
        }

        [MenuItem("Unity Build Hub/Build/Android IL2CPP")]
        internal static void ExecuteAndroidIL2CPPBuild()
        {
            CIEndpointProvider.AndroidIL2CPP();
        }
    }
}