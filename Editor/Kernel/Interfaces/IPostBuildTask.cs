// ReSharper disable once CheckNamespace

namespace UnityBuildHub.Editor.Kernel.Interfaces
{
    public interface IPostBuildTask
    {
        string Name { get; }

        // TODO: We should be able to pass build configurations into this method.
        void Perform();
    }
}