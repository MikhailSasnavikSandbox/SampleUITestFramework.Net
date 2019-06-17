using BBCTests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Concurrent;

namespace BBCTests.Insfrastructure
{
    public static class WebDriverManager
    {
        private static ConcurrentDictionary<string, IWebDriver> driverDictionary =
                    new ConcurrentDictionary<string, IWebDriver>();

        public static IWebDriver Driver
        {
            get
            {
                if (driverDictionary.ContainsKey(DriverID))
                {
                    return driverDictionary[DriverID];
                }
                throw new Exception("Driver is not initialized");
            }
        }

        private static string DriverID => NUnitHelper.CurrentTestName;

        public static void CleanupDriver()
        {
            driverDictionary.TryRemove(DriverID, out IWebDriver tempDriver);
            tempDriver.Quit();
        }

        public static void InitDriver(Browser browser)
        {
            var driver = ConfigreDriver(GetDriverInstance(browser));
            driverDictionary.TryAdd(DriverID, driver);
        }

        private static IWebDriver GetDriverInstance(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    return GetChromeDriver();
                case Browser.Firefox:
                    return GetFirefoxDriver();
                default:
                    throw new Exception("Unsupported browser");
            }
        }

        private static IWebDriver GetChromeDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver GetFirefoxDriver()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        private static IWebDriver ConfigreDriver(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            return driver;
        }
    }
}
