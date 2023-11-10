using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Editor.Utilities
{
    internal sealed class CommandLineReader
    {
        // ReSharper disable once InconsistentNaming
        private readonly string[] commandLineArguments = Environment.GetCommandLineArgs();

        internal void FetchArgumentFromCommandLine(string desiredCommandLineArgument, out string value)
        {
            Debug.Assert(!string.IsNullOrEmpty(desiredCommandLineArgument));

            value = string.Empty;
            for (var i = 1; i < commandLineArguments.Length; i++)
            {
                if (!string.Equals(commandLineArguments[i], desiredCommandLineArgument,
                        StringComparison.OrdinalIgnoreCase)) continue;

                if (i + 1 >= commandLineArguments.Length)
                {
                    throw new Exception(
                        $"Error: {desiredCommandLineArgument} argument is present but has no value.");
                }

                value = commandLineArguments[i + 1];
                break;
            }
        }
    }
}