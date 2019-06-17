using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects.SignUp
{
    public class AccountTypeRegistrationPage : BaseRegistrationBage
    {
        public AccountTypeRegistrationPage(IWebDriver webDriver) : base(webDriver)
        {
            WaitSpinnerToComplete();
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/register/details/guardian')]")]
        public IWebElement Under13Button { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/register/details/age')]")]
        public IWebElement Over13Button { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'page__close-icon']")]
        public IWebElement ExitSignUp { get; private set; }

        public AgeRegistrationPage ClickOver13Button()
        {
            Over13Button.Click();
            return new AgeRegistrationPage(WebDriver);
        }

        public MainPage ClickExitSignUp()
        {
            ExitSignUp.Click();
            return new MainPage(WebDriver);
        }
    }
}
