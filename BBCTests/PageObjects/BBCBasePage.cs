using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects
{
    public abstract class BBCBasePage
    {
        public BBCBasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            PageFactory.InitElements(WebDriver, this);
        }

        protected static string BaseUri => "https://www.bbc.com/";
        protected IWebDriver WebDriver { get; private set; }       
    }
}
