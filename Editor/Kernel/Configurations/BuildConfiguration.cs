using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Configurations
{
    internal readonly struct BuildConfiguration
    {
        public readonly BuildPlayerOptions BuildPlayerOptions;
        public readonly ScriptingImplementation ScriptingImplementation;
        public readonly IPreBuildTask[] PreBuildTasks;

        public BuildConfiguration(BuildPlayerOptions buildPlayerOptions,
            ScriptingImplementation scriptingImplementation, IPreBuildTask[] preBuildTasks)
        {
            BuildPlayerOptions = buildPlayerOptions;
            ScriptingImplementation = scriptingImplementation;
            PreBuildTasks = preBuildTasks;
        }
    }
}