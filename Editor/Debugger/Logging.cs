using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Debugger
{
    internal static class Logging
    {
        internal static void Print(string context, LogCategory logCategory = LogCategory.Unknown)
        {
            Debug.Assert(!string.IsNullOrEmpty(context));

            var tag = string.Concat('[', "Unit Build Hub", ']', ' ', '[', $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}", ']',
                ' ');
            var log = string.Concat(tag, ' ', context);

            switch (logCategory)
            {
                case LogCategory.Critical:
                    Debug.LogError(log);
                    break;
                case LogCategory.Trace:
                    Debug.Log(log);
                    break;
                case LogCategory.Unknown:
                    Debug.Log(log);
                    break;
                case LogCategory.Warning:
                    Debug.LogWarning(log);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logCategory), logCategory, null);
            }
        }
    }
}