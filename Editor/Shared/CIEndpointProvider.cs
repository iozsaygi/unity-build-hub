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
        // TODO: See if we need to declare static functions as 'public' instead of 'internal'.
        // TODO: Figure out how we can write unit tests for this.

        internal static void MacOSX64IL2CPP()
        {
            var platformExecutableBuilder =
                new PlatformExecutableBuilder(BuildConfigurationRegistry.MacOSX64IL2CPPBuildConfiguration);

            platformExecutableBuilder.PerformPreBuildTasks();
            platformExecutableBuilder.PerformCoreBuildOperation();
            platformExecutableBuilder.PerformPostBuildTasks();
        }
    }
}