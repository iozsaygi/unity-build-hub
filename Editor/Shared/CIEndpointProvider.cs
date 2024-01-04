using UnityBuildHub.Editor.Kernel.Builders;
using UnityBuildHub.Editor.Kernel.Configurations;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Shared
{
    /// <summary>
    /// Acts as a connection between Unity Build Hub and CI tools such as Jenkins and TeamCity.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal static class CIEndpointProvider
    {
        internal static void WindowsX64Mono()
        {
            var platformExecutableBuilder = new PlatformExecutableBuilder(PlatformExecutableBuildConfigurationRegistry
                .WindowsX64MonoPlatformExecutableBuildConfiguration);

            platformExecutableBuilder.PerformPreBuildTasks();
            platformExecutableBuilder.AnalyzeBuildReport(platformExecutableBuilder.PerformCoreBuildOperation());
            platformExecutableBuilder.PerformPostBuildTasks();
        }

        internal static void WindowsX64IL2CPP()
        {
            var platformExecutableBuilder = new PlatformExecutableBuilder(PlatformExecutableBuildConfigurationRegistry
                .WindowsX64IL2CPPPlatformExecutableBuildConfiguration);

            platformExecutableBuilder.PerformPreBuildTasks();
            platformExecutableBuilder.AnalyzeBuildReport(platformExecutableBuilder.PerformCoreBuildOperation());
            platformExecutableBuilder.PerformPostBuildTasks();
        }

        internal static void MacOSX64IL2CPP()
        {
            var platformExecutableBuilder =
                new PlatformExecutableBuilder(PlatformExecutableBuildConfigurationRegistry
                    .MacOSX64IL2CPPPlatformExecutableBuildConfiguration);

            platformExecutableBuilder.PerformPreBuildTasks();
            platformExecutableBuilder.AnalyzeBuildReport(platformExecutableBuilder.PerformCoreBuildOperation());
            platformExecutableBuilder.PerformPostBuildTasks();
        }
    }
}