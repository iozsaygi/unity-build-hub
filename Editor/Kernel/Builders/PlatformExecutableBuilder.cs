using UnityBuildHub.Editor.Debugger;
using UnityBuildHub.Editor.Kernel.Configurations;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Builders
{
    /// <summary>
    /// Builder that actually produces an executable file for target platform.
    /// </summary>
    internal sealed class PlatformExecutableBuilder
    {
        // ReSharper disable once InconsistentNaming
        private readonly BuildConfiguration buildConfiguration;

        public PlatformExecutableBuilder(BuildConfiguration buildConfigurationToBind)
        {
            buildConfiguration = buildConfigurationToBind;
        }

        public void PerformPreBuildTasks()
        {
            foreach (var preBuildTask in buildConfiguration.PreBuildTasks)
            {
                preBuildTask.Perform(buildConfiguration);
                Logging.Message($"Completed pre build task: {preBuildTask.Name}", LogCategory.Trace);
            }
        }

        public void PerformUnityBuild()
        {
            BuildPipeline.BuildPlayer(buildConfiguration.BuildPlayerOptions);
        }
    }
}