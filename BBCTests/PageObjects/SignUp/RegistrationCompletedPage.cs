using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects.SignUp
{
    public class RegistrationCompletedPage : BaseRegistrationBage
    {
        public RegistrationCompletedPage(IWebDriver webDriver) : base(webDriver) { }

        [FindsBy(How = How.XPath, Using = "//*[@id = 'optIn'/..]")]
        public IWebElement AcceptEmailRecommendationsButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='optOut']/..")]
        public IWebElement DeclineEmailRecommendationsButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='submit-button']")]
        public IWebElement SubmitButton { get; private set; }

        public RegistrationCompletedPage AcceptEmailRecommendations()
        {
            AcceptEmailRecommendationsButton.Click();
            return this;
        }

        public RegistrationCompletedPage DeclineEmailRecommendations()
        {
            DeclineEmailRecommendationsButton.Click();
            return this;
        }

        public MainPage Submit()
        {
            SubmitButton.Click();
            return new MainPage(WebDriver);
        }
    }
}
