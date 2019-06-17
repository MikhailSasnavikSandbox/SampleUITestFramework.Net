using NUnit.Framework;
using System;

namespace BBCTests.Insfrastructure
{
    public class AssertionBuilder
    {
        public string Message { get; private set; } = string.Empty;

        public bool PassStatus { get; private set; } = true;

        public AssertionBuilder AppendAssertion(bool condition, string message)
        {
            if (condition) return this;
            Message += $"> {message} {Environment.NewLine}{Environment.NewLine}";
            PassStatus = false;
            return this;
        }

        public AssertionBuilder AppendAssertion(string expected, string actual, string message)
        {
            return AppendAssertion(expected == actual, $"{message}\nExpected: '{expected}'\nActual  : '{actual}'");
        }

        public AssertionBuilder AppendAssertion(int expected, int actual, string message)
        {
            return AppendAssertion(expected == actual, $"{message}\nExpected: '{expected}'\nActual: '{actual}'");            
        }

        public void Verify()
        {
            if (!PassStatus)
            {
                Assert.Fail($"Verification failed:\n{Message}");
            }
        }

        public void VerifyFalse()
        {
            if (PassStatus)
            {
                Assert.Fail($"Verification failed:\n{Message}");
            }
        }
    }
}
