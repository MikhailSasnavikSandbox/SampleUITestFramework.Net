using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects.SignUp
{
    public class AgeRegistrationPage : BaseRegistrationBage
    {
        public AgeRegistrationPage(IWebDriver webDriver) : base(webDriver)
        {
            WaitSpinnerToComplete();
        }        

        [FindsBy(How = How.XPath, Using = "//*[@id ='day-input']")]
        public IWebElement DayInput { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='month-input']")]
        public IWebElement MonthInput { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='year-input']")]
        public IWebElement YearInput { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='submit-button']")]
        public IWebElement SubmitButton { get; private set; }

        public AgeRegistrationPage SetDay(string value)
        {
            DayInput.SendKeys(value);
            return this;
        }

        public AgeRegistrationPage SetMonth(string value)
        {
            MonthInput.SendKeys(value);
            return this;
        }

        public AgeRegistrationPage SetYear(string value)
        {
            YearInput.SendKeys(value);
            return this;
        }

        public PersonalInfoRegistrationPage Submit()
        {
            SubmitButton.Click();
            return new PersonalInfoRegistrationPage(WebDriver);
        }
    }
}
