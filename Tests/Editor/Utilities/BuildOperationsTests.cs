using NUnit.Framework;
using UnityBuildHub.Editor.Utilities;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Tests.Editor.Utilities
{
    internal sealed class BuildOperationsTest
    {
        [Test]
        public void EnsureActiveBuildTarget()
        {
            const BuildTargetGroup desiredBuildTargetGroup = BuildTargetGroup.Standalone;
            const BuildTarget desiredBuildTarget = BuildTarget.StandaloneWindows64;

            BuildOperations.EnsureActiveBuildTarget(desiredBuildTargetGroup, desiredBuildTarget);

            Assert.AreEqual(desiredBuildTarget, EditorUserBuildSettings.activeBuildTarget);
            Assert.AreEqual(desiredBuildTargetGroup, EditorUserBuildSettings.selectedBuildTargetGroup);
        }

        [Test]
        public void EnsureScriptingBackend()
        {
            const BuildTargetGroup desiredBuildTargetGroup = BuildTargetGroup.Standalone;
            const ScriptingImplementation desiredScriptingImplementation = ScriptingImplementation.IL2CPP;

            BuildOperations.EnsureScriptingBackend(desiredBuildTargetGroup, desiredScriptingImplementation);

            Assert.AreEqual(desiredScriptingImplementation,
                PlayerSettings.GetScriptingBackend(desiredBuildTargetGroup));
        }

        [Test]
        public void EnsureArchitectureForBuildTargetGroup()
        {
            const BuildTargetGroup buildTargetGroup = BuildTargetGroup.Standalone;
            BuildOperations.EnsureArchitectureForBuildTargetGroup(buildTargetGroup, 1);
            Assert.AreEqual(1, PlayerSettings.GetArchitecture(buildTargetGroup));
        }

        [Test]
        public void FindAvailableScenesForBuild()
        {
            var scenePaths = BuildOperations.FindAvailableScenesForBuild();

            // Not returning 'null' from the API is enough for now.
            Assert.IsNotNull(scenePaths);
        }

        [Test]
        public void FindTargetBuildFilePath()
        {
            var productName = Application.productName;
            var buildTarget = BuildTarget.NoTarget;

            // ReSharper disable once RedundantAssignment
            var expectedTargetFilePath = string.Empty;

#if UNITY_STANDALONE_WIN
            buildTarget = BuildTarget.StandaloneWindows64;
            expectedTargetFilePath = $"Builds/{buildTarget.ToString()}/{productName}.exe";
#endif // UNITY_STANDALONE_WIN

            var targetBuildDirectory = BuildOperations.FindTargetBuildFilePath(buildTarget);

            Assert.AreEqual(expectedTargetFilePath, targetBuildDirectory);
        }
    }
}