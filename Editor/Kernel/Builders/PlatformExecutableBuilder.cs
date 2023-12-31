using System.Diagnostics;
using UnityBuildHub.Editor.Debugger;
using UnityBuildHub.Editor.Kernel.Configurations;
using UnityEditor;
using UnityEditor.Build.Reporting;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Builders
{
    /// <summary>
    /// Builder that actually produces an executable file for target platform.
    /// </summary>
    internal sealed class PlatformExecutableBuilder : Builder
    {
        // ReSharper disable once InconsistentNaming
        private readonly PlatformExecutableBuildConfiguration platformExecutableBuildConfiguration;

        public PlatformExecutableBuilder(
            PlatformExecutableBuildConfiguration platformExecutableBuildConfigurationToBind)
        {
            platformExecutableBuildConfiguration = platformExecutableBuildConfigurationToBind;
        }

        public override void PerformPreBuildTasks()
        {
            if (platformExecutableBuildConfiguration.PreBuildTasks.Length == 0)
            {
                Logging.Print("There are no registered pre-build tasks for current build configuration",
                    LogCategory.Warning);

                return;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var preBuildTask in platformExecutableBuildConfiguration.PreBuildTasks)
            {
                Logging.Print($"Starting to perform pre-build task '{preBuildTask.Name}'", LogCategory.Trace);

                stopwatch.Restart();
                preBuildTask.Perform(platformExecutableBuildConfiguration);
                stopwatch.Stop();

                Logging.Print(
                    $"Completed pre-build task '{preBuildTask.Name}' in {stopwatch.Elapsed.TotalSeconds:F2} seconds",
                    LogCategory.Trace);
            }

            Logging.Print($"{stopwatch.Elapsed.TotalSeconds:F2} seconds spent on pre-build tasks",
                LogCategory.Trace);
        }

        public override BuildReport PerformCoreBuildOperation()
        {
            return BuildPipeline.BuildPlayer(platformExecutableBuildConfiguration.BuildPlayerOptions);
        }

        public override void AnalyzeBuildReport(BuildReport buildReport)
        {
            if (buildReport.summary.totalErrors > 0)
                EditorApplication.Exit(1);
        }

        public override void PerformPostBuildTasks()
        {
            if (platformExecutableBuildConfiguration.PostBuildTasks.Length == 0)
            {
                Logging.Print("There are no registered post-build tasks for current build configuration",
                    LogCategory.Warning);

                return;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var postBuildTask in platformExecutableBuildConfiguration.PostBuildTasks)
            {
                Logging.Print($"Starting to perform post-build task '{postBuildTask.Name}'", LogCategory.Trace);

                stopwatch.Restart();
                postBuildTask.Perform();
                stopwatch.Stop();

                Logging.Print(
                    $"Completed post-build task '{postBuildTask.Name}' in {stopwatch.Elapsed.TotalSeconds:F2} seconds",
                    LogCategory.Trace);
            }

            Logging.Print($"{stopwatch.Elapsed.TotalSeconds:F2} seconds spent on post-build tasks",
                LogCategory.Trace);
        }
    }
}