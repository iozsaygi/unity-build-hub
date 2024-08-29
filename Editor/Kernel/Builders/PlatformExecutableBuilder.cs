using System.Diagnostics;
using UnityBuildHub.Editor.Debugger;
using UnityBuildHub.Editor.Kernel.Configurations;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

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
                // Not sure if this should be 'Warning' but it is also not fit for 'Trace'.
                Log.Warning("There are no registered pre-build tasks for current build configuration");
                return;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var preBuildTask in platformExecutableBuildConfiguration.PreBuildTasks)
            {
                Log.Trace($"Starting to perform pre-build task '{preBuildTask.Name}'");

                stopwatch.Restart();
                preBuildTask.Perform(platformExecutableBuildConfiguration);
                stopwatch.Stop();

                Log.Trace(
                    $"Completed pre-build task '{preBuildTask.Name}' in {stopwatch.Elapsed.TotalSeconds:F2} seconds");
            }

            Log.Trace($"{stopwatch.Elapsed.TotalSeconds:F2} seconds spent on pre-build tasks");
        }

        public override BuildReport PerformCoreBuildOperation()
        {
            return BuildPipeline.BuildPlayer(platformExecutableBuildConfiguration.BuildPlayerOptions);
        }

        public override void AnalyzeBuildReport(BuildReport buildReport)
        {
            foreach (var step in buildReport.steps)
            {
                Log.Trace($"Starting to analyze '{step.name}' build step.");

                foreach (var message in step.messages)
                {
                    if (message.type.Equals(LogType.Error) || message.type.Equals(LogType.Warning))
                    {
                        Log.Error($"{message.type} found, the full log is: {message.content}");
                    }
                }

                Log.Trace($"'{step.name}' took {step.duration.Seconds} seconds to complete.");
            }

            // Terminate the build by looking at two separate condition:
            // 1. If there are errors in the build -> terminate
            // 2. If build configuration allows to fail builds for any warnings detected and there are warnings in the build log -> terminate
            if (buildReport.summary.totalErrors > 0 || (platformExecutableBuildConfiguration.FailBuildForAnyWarning &&
                                                        buildReport.summary.totalWarnings > 0))
            {
                EditorApplication.Exit(1);
            }
        }

        public override void PerformPostBuildTasks()
        {
            if (platformExecutableBuildConfiguration.PostBuildTasks.Length == 0)
            {
                // Not sure if this should be 'Warning' but it is also not fit for 'Trace'.
                Log.Warning("There are no registered post-build tasks for current build configuration");
                return;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var postBuildTask in platformExecutableBuildConfiguration.PostBuildTasks)
            {
                Log.Trace($"Starting to perform post-build task '{postBuildTask.Name}'");

                stopwatch.Restart();
                postBuildTask.Perform();
                stopwatch.Stop();

                Log.Trace(
                    $"Completed post-build task '{postBuildTask.Name}' in {stopwatch.Elapsed.TotalSeconds:F2} seconds");
            }

            Log.Trace($"{stopwatch.Elapsed.TotalSeconds:F2} seconds spent on post-build tasks");
        }
    }
}