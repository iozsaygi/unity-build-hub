using UnityBuildHub.Editor.Debugger;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Utilities
{
    /// <summary>
    /// Contains several utility functions to ease build process for builders.
    /// </summary>
    public static class BuildOperations
    {
        public static void EnsureActiveBuildTarget(BuildTargetGroup desiredBuildTargetGroup,
            BuildTarget desiredBuildTarget)
        {
            if (EditorUserBuildSettings.activeBuildTarget != desiredBuildTarget)
                EditorUserBuildSettings.SwitchActiveBuildTarget(desiredBuildTargetGroup, desiredBuildTarget);
        }

        public static void EnsureScriptingBackend(BuildTargetGroup buildTargetGroup,
            ScriptingImplementation desiredScriptingImplementation)
        {
            var currentScriptingBackend = PlayerSettings.GetScriptingBackend(buildTargetGroup);
            if (currentScriptingBackend != desiredScriptingImplementation)
                PlayerSettings.SetScriptingBackend(buildTargetGroup, desiredScriptingImplementation);
        }

        public static void FindAvailableScenesForBuild(out string[] scenePaths)
        {
            var sceneCountInBuildSettings = (byte)EditorBuildSettings.scenes.Length;
            scenePaths = new string[sceneCountInBuildSettings];

            if (sceneCountInBuildSettings == 0)
            {
                Logging.Message(
                    "There are no scenes added to build, make sure to add scenes before invoking new build.",
                    LogCategory.Exception);
            }

            for (byte i = 0; i < scenePaths.Length; i++)
                scenePaths[i] = EditorBuildSettings.scenes[i].path;
        }

        public static void FindTargetBuildFilePath(BuildTarget buildTarget, out string targetBuildDirectory)
        {
            var productName = Application.productName;

            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows64:
                    targetBuildDirectory = $"Builds/{buildTarget.ToString()}/{productName}.exe";
                    break;
                case BuildTarget.StandaloneOSX:
                    targetBuildDirectory = $"Builds/{buildTarget.ToString()}/{productName}.app";
                    break;
                default:
                    targetBuildDirectory = string.Empty;
                    Logging.Message("Failed to figure out executable name for current platform.",
                        LogCategory.Exception);
                    break;
            }
        }
    }
}