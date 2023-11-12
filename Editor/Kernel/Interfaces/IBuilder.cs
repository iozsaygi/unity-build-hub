using UnityBuildHub.Editor.Kernel.Configurations;
using UnityEditor.Build.Reporting;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Interfaces
{
    internal interface IBuilder
    {
        void PreBuild(BuildConfiguration buildConfiguration);
        void Execute(BuildConfiguration buildConfiguration);
        void PostBuild(BuildReport buildReport);
    }
}