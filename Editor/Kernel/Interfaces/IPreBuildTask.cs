using UnityBuildHub.Editor.Kernel.Configurations;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Interfaces
{
    internal interface IPreBuildTask
    {
        void Perform(BuildConfiguration buildConfiguration);
    }
}