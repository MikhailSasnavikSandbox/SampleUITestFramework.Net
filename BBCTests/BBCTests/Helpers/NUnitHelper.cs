using NUnit.Framework;

namespace BBCTests.Helpers
{
    public static class NUnitHelper
    {
        public static string CurrentTestName => TestContext.CurrentContext.Test.FullName;
    }
}
