using UnityEditor.Build.Reporting;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Builders
{
    public abstract class Builder
    {
        public abstract void PerformPreBuildTasks();
        public abstract BuildReport PerformCoreBuildOperation();
        public abstract void AnalyzeBuildReport(BuildReport buildReport);
        public abstract void PerformPostBuildTasks();
    }
}