using UnityBuildHub.Editor.Kernel.Interfaces;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Kernel.Tasks
{
    public class MacOSDummyBuildTask : IPostBuildTask
    {
        public string Name => "MacOS Dummy Post Build Task";

        public void Perform()
        {
        }
    }
}