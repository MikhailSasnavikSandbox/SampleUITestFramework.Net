using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects
{
    public class MainPage : BBCBasePage
    {
        public MainPage(IWebDriver webDriver) : base(webDriver) { }

        public static string Uri => BaseUri;
        public static string Title => "BBC - Homepage";

        [FindsBy(How = How.XPath, Using = "//*[@id = 'idcta-username']")]
        public IWebElement AccountStatusBar { get; private set; }
    }
}
