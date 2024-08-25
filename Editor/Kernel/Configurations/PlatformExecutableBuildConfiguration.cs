using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Configurations
{
    public readonly struct PlatformExecutableBuildConfiguration
    {
        // Native options for Unity's build pipeline.
        public readonly BuildPlayerOptions BuildPlayerOptions;

        // The type of scripting backend for the build. (Mono, IL2CPP etc.)
        public readonly ScriptingImplementation ScriptingImplementation;

        // Set of tasks that are going to be executed before actual Unity build.
        public readonly IPreBuildTask[] PreBuildTasks;

        // Set of tasks that are going to be executed after actual Unity build completes.
        public readonly IPostBuildTask[] PostBuildTasks;

        // Should builds fail if any warning detected in the Unity generated build log?
        public readonly bool FailBuildForAnyWarning;

        public PlatformExecutableBuildConfiguration(BuildPlayerOptions buildPlayerOptions,
            ScriptingImplementation scriptingImplementation, IPreBuildTask[] preBuildTasks,
            IPostBuildTask[] postBuildTasks, bool failBuildForAnyWarning)
        {
            BuildPlayerOptions = buildPlayerOptions;
            ScriptingImplementation = scriptingImplementation;
            PreBuildTasks = preBuildTasks;
            PostBuildTasks = postBuildTasks;
            FailBuildForAnyWarning = failBuildForAnyWarning;
        }
    }
}