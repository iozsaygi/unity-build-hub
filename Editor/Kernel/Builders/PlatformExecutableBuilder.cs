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
        private readonly PlatformExecutableBuildConfiguration _platformExecutableBuildConfiguration;

        public PlatformExecutableBuilder(PlatformExecutableBuildConfiguration platformExecutableBuildConfigurationToBind)
        {
            _platformExecutableBuildConfiguration = platformExecutableBuildConfigurationToBind;
        }

        public override void PerformPreBuildTasks()
        {
            if (_platformExecutableBuildConfiguration.PreBuildTasks.Length == 0)
            {
                Logging.Message("There are no registered pre build tasks for current build configuration",
                    LogCategory.Warning);

                return;
            }

            foreach (var preBuildTask in _platformExecutableBuildConfiguration.PreBuildTasks)
            {
                Logging.Message($"Starting to perform pre build task: {preBuildTask.Name}", LogCategory.Trace);
                preBuildTask.Perform(_platformExecutableBuildConfiguration);
                Logging.Message($"Completed pre build task: {preBuildTask.Name}", LogCategory.Trace);
            }
        }

        public override void PerformCoreBuildOperation()
        {
            BuildPipeline.BuildPlayer(_platformExecutableBuildConfiguration.BuildPlayerOptions);
        }

        public override void PerformPostBuildTasks()
        {
            if (_platformExecutableBuildConfiguration.PostBuildTasks.Length == 0)
            {
                Logging.Message("There are no registered post build tasks for current build configuration",
                    LogCategory.Warning);

                return;
            }

            foreach (var postBuildTask in _platformExecutableBuildConfiguration.PostBuildTasks)
            {
                Logging.Message($"Starting to perform post build task: {postBuildTask.Name}", LogCategory.Trace);
                postBuildTask.Perform();
                Logging.Message($"Completed post build task: {postBuildTask.Name}", LogCategory.Trace);
            }
        }
    }
}