using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Debugger
{
    internal static class Logging
    {
        internal static void Message(string context, LogCategory logCategory = LogCategory.Unknown)
        {
            Debug.Assert(!string.IsNullOrEmpty(context));

            var tag = string.Concat('[', "Unit Build Hub Logging", ']');
            var log = string.Concat(tag, ' ', context);

            switch (logCategory)
            {
                case LogCategory.Critical:
                    Debug.LogError(string.Concat("<color=red>", log, "</color>"));
                    break;
                case LogCategory.Exception:
                    throw new Exception(log);
                case LogCategory.Trace:
                    Debug.Log(string.Concat("<color=white>", log, "</color>"));
                    break;
                case LogCategory.Unknown:
                    Debug.Log(string.Concat("<color=gray>", log, "</color>"));
                    break;
                case LogCategory.Warning:
                    Debug.LogWarning(string.Concat("<color=red>", log, "</color>"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logCategory), logCategory, null);
            }
        }
    }
}