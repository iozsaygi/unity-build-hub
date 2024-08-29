// ReSharper disable once CheckNamespace

namespace UnityBuildHub.Editor.Debugger
{
    internal enum LogCategory : byte
    {
        // Only for debugging nothing wrong going on.
        Trace = 0,

        // Something to take care of, but we can live with it.
        Warning = 1,

        // Take an immediate action.
        Error = 2
    }
}