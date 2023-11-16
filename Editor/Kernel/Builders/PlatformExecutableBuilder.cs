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
            if (buildConfiguration.PreBuildTasks.Length == 0)
            {
                Logging.Message("There are no registered pre build tasks for current build configuration",
                    LogCategory.Warning);

                return;
            }

            foreach (var preBuildTask in buildConfiguration.PreBuildTasks)
            {
                Logging.Message($"Starting to perform pre build task: {preBuildTask.Name}", LogCategory.Trace);
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
            if (buildConfiguration.PostBuildTasks.Length == 0)
            {
                Logging.Message("There are no registered post build tasks for current build configuration",
                    LogCategory.Warning);

                return;
            }

            foreach (var postBuildTask in buildConfiguration.PostBuildTasks)
            {
                Logging.Message($"Starting to perform post build task: {postBuildTask.Name}", LogCategory.Trace);
                postBuildTask.Perform();
                Logging.Message($"Completed post build task: {postBuildTask.Name}", LogCategory.Trace);
            }
        }
    }
}