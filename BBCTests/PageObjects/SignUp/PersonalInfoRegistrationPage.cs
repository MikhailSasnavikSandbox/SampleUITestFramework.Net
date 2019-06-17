using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects.SignUp
{
    public class PersonalInfoRegistrationPage : BaseRegistrationBage
    {
        public PersonalInfoRegistrationPage(IWebDriver webDriver) : base(webDriver)
        {
            WaitSpinnerToComplete();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id ='user-identifier-input']")]
        public IWebElement EmailInput { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='password-input']")]
        public IWebElement PasswordInput { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='location-select']")]
        public IWebElement CountryDropdown { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='location-select']/option")]
        public IList<IWebElement> CountryDropdownOptions { get; private set; }

        [FindsBy(How = How.XPath, Using = "//*[@id ='submit-button']")]
        public IWebElement SubmitButton { get; private set; }

        public PersonalInfoRegistrationPage EnterUserEmail(string userIdentifier)
        {
            EmailInput.SendKeys(userIdentifier);
            return this;
        }

        public PersonalInfoRegistrationPage EnterUserPassword(string password)
        {
            PasswordInput.SendKeys(password);
            return this;
        }

        public PersonalInfoRegistrationPage SelectDropdown(int index)
        {
            CountryDropdown.Click();
            CountryDropdownOptions[index].Click();
            return this;
        }

        public PersonalInfoRegistrationPage SelectDropdown(string value)
        {
            
            CountryDropdown.Click();
            CountryDropdownOptions.Single(option => option.GetAttribute("value") == value).Click();
            return this;
        }

        public RegistrationCompletedPage Submit()
        {
            SubmitButton.Click();
            return new RegistrationCompletedPage(WebDriver);
        }
    }
}
