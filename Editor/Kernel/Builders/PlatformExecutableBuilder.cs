using UnityBuildHub.Editor.Debugger;
using UnityBuildHub.Editor.Kernel.Configurations;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Builders
{
    /// <summary>
    /// Builder that actually produces an executable file for target platform.
    /// </summary>
    internal sealed class PlatformExecutableBuilder : Builder
    {
        // ReSharper disable once InconsistentNaming
        private readonly BuildConfiguration buildConfiguration;

        public PlatformExecutableBuilder(BuildConfiguration buildConfigurationToBind)
        {
            buildConfiguration = buildConfigurationToBind;
        }

        public override void PerformPreBuildTasks()
        {
            foreach (var preBuildTask in buildConfiguration.PreBuildTasks)
            {
                Logging.Message($"Starting to perform build task: {preBuildTask.Name}", LogCategory.Trace);
                preBuildTask.Perform(buildConfiguration);
                Logging.Message($"Completed pre build task: {preBuildTask.Name}", LogCategory.Trace);
            }
        }

        public override void PerformCoreBuildOperation()
        {
            BuildPipeline.BuildPlayer(buildConfiguration.BuildPlayerOptions);
        }

        public override void PerformPostBuildTasks()
        {
            // TODO: Implement post build tasks.
        }
    }
}