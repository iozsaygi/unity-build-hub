// ReSharper disable once CheckNamespace

namespace UnityBuildHub.Editor.Kernel.Builders
{
    public abstract class Builder
    {
        public abstract void PerformPreBuildTasks();
        public abstract void PerformCoreBuildOperation();
        public abstract void PerformPostBuildTasks();
    }
}