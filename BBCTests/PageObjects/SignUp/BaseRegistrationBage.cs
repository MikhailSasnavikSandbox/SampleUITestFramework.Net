using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Diagnostics;

namespace PageObjects.SignUp
{
    public abstract class BaseRegistrationBage : BBCBasePage
    {
        public static string Uri => $"{BaseUri}register";

        public BaseRegistrationBage(IWebDriver webDriver) : base(webDriver) { }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'page__grid-wrapper']//*[@class = 'header__logo-link']")]
        public IWebElement BBCLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'spinner')]")]
        private IWebElement Spinner { get; set; }

        protected void WaitSpinnerToComplete(int timeoutMS = 5000)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds <= timeoutMS)
            {
                if (Spinner.Displayed)
                {
                    continue;
                }
                return;
            }
        }
    }
}
