using BBCTests.Helpers;
using BBCTests.Insfrastructure;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
namespace BBCTests.Tests
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class BaseTest
    {
        //Driver instance binded to the current Test
        protected IWebDriver WebDriver => WebDriverManager.Driver;

        //Execute before each test
        [SetUp]
        public void Setup()
        {
            //Init driver instance for current test
            var targetBrowser = (Browser)TestContext.CurrentContext.Test.Arguments[0];
            WebDriverManager.InitDriver(targetBrowser);
        }

        //Executed after each test
        [TearDown]
        public void TearDown()
        {
            //Save screenshot if test failed
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenShotHelper.TakeScreenshot(WebDriver);
            }

            //Dispose driver instance which is binded to the current Test
            WebDriverManager.CleanupDriver();
        }
    }
}
