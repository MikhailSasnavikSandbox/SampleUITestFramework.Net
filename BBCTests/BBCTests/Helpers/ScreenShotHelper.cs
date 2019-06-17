using BBCTests.Insfrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace BBCTests.Helpers
{
    public static class ScreenShotHelper
    {
        /// <summary>
        /// Stores screenshot under Test Project folder
        /// </summary>
        /// <param name="webDriver"></param>
        public static void TakeScreenshot(IWebDriver webDriver)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", "");
            var testName = $"TestResults\\{TestContext.CurrentContext.Test.MethodName}\\";;

            Directory.CreateDirectory($"{directory}{testName}");
            var browserName = ((Browser)TestContext.CurrentContext.Test.Arguments[0]).ToString();

            ((ITakesScreenshot)webDriver)
                .GetScreenshot()
                .SaveAsFile($"{directory}{testName}{browserName}.png"); 
        }
    }
}
