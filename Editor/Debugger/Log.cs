using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Debugger
{
    internal static class Log
    {
        internal static void Trace(string message)
        {
            Print(message, LogCategory.Trace);
        }

        internal static void Warning(string message)
        {
            Print(message, LogCategory.Warning);
        }

        internal static void Error(string message)
        {
            Print(message, LogCategory.Error);
        }

        private static void Print(string context, LogCategory logCategory)
        {
            Debug.Assert(!string.IsNullOrEmpty(context));

            var tag = string.Concat('[', "Unit Build Hub", ']', ' ', '[', $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}", ']',
                ' ');
            var log = string.Concat(tag, ' ', context);

            switch (logCategory)
            {
                case LogCategory.Trace:
                    Debug.Log(log);
                    break;
                case LogCategory.Warning:
                    Debug.LogWarning(log);
                    break;
                case LogCategory.Error:
                    Debug.LogError(log);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logCategory), logCategory, null);
            }
        }
    }
}