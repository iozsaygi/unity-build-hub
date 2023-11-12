using UnityBuildHub.Editor.Debugger;
using UnityBuildHub.Editor.Kernel.Configurations;
using UnityBuildHub.Editor.Kernel.Interfaces;
using UnityEditor;
using UnityEditor.Build.Reporting;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Builders
{
    internal sealed class MacOSX64IL2CPPBuilder : IBuilder
    {
        public void PreBuild(BuildConfiguration buildConfiguration)
        {
            foreach (var preBuildTask in buildConfiguration.PreBuildTasks)
            {
                preBuildTask.Perform(buildConfiguration);

                // TODO: Find a way to display actual name of the pre build task.
                Logging.Message($"Completed performing {nameof(preBuildTask)}", LogCategory.Trace);
            }
        }

        public void Execute(BuildConfiguration buildConfiguration)
        {
            BuildPipeline.BuildPlayer(buildConfiguration.BuildPlayerOptions);
        }

        public void PostBuild(BuildReport buildReport)
        {
        }
    }
}