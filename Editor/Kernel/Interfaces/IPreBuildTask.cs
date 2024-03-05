using UnityBuildHub.Editor.Kernel.Configurations;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Interfaces
{
    public interface IPreBuildTask
    {
        string Name { get; }

        void Perform(PlatformExecutableBuildConfiguration platformExecutableBuildConfiguration);
    }
}