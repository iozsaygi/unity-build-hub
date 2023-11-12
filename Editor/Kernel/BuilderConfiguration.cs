using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel
{
    internal readonly struct BuilderConfiguration
    {
        public readonly BuildPlayerOptions BuildPlayerOptions;
        public readonly IPreBuildTask[] PreBuildTasks;

        public BuilderConfiguration(BuildPlayerOptions buildPlayerOptions, IPreBuildTask[] preBuildTasks)
        {
            BuildPlayerOptions = buildPlayerOptions;
            PreBuildTasks = preBuildTasks;
        }
    }
}