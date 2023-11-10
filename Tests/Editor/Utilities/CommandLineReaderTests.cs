using NUnit.Framework;
using UnityBuildHub.Editor.Utilities;

// ReSharper disable once CheckNamespace
namespace UnityBuildHub.Tests.Editor.Utilities
{
    internal sealed class CommandLineReaderTests
    {
        [Test]
        public void ArgumentNotFound()
        {
            var commandLineReader = new CommandLineReader();
            commandLineReader.FetchArgumentFromCommandLine("-commandLineArgument", out var value);
            Assert.AreEqual(string.Empty, value);
        }
    }
}