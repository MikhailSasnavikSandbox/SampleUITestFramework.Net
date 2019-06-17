using BBCTests.Helpers;
using BBCTests.Insfrastructure;
using Models;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using PageObjects.SignUp;
using SeleniumExtras.WaitHelpers;
using System;

namespace BBCTests.Tests.SignUpTests
{
    //Signup feature Test Suite
    [TestFixture]
    class SignUpTests : BaseTest
    {
        //Start page for Signup feature Test Suite
        private AccountTypeRegistrationPage accountTypeRegistrationPage;

        //User object binded to the current Test
        private User UnregisteredUser => UserAccountManager.User;

        //Execute before each Test of Signup feature Test Suite
        [SetUp]
        public void SignUpTestsSetup()
        {
            //Init User object binded to the current Test with some unique values as Email and Password
            UserAccountManager.InitUser(
                new User
                {
                    Email = $"autotestEmail{RandomHelper.GetGuidString()}@gmail.com",
                    Password = $"Password!{RandomHelper.GetGuidString()}"
                });

            //Navigate to the start page for Signup feature Suite
            WebDriver.Navigate().GoToUrl(BaseRegistrationBage.Uri);
            accountTypeRegistrationPage = new AccountTypeRegistrationPage(WebDriver);
        }

        //Execute after each Test of Signup feature Test Suite
        [TearDown]
        public void SignUpTestsTearDown()
        {
            //Dispose User object binded to the current Test
            UserAccountManager.CleanupUser();
        }


        [TestCase(Browser.Chrome)]
        [TestCase(Browser.Firefox)]
        //TestCaseNumber_FeatureName_TestInput_ExpectedResult
        public void TC200_Signup_ValidCredentials_Success(Browser browser)
        {
            //Proceed with initial registration page
            var ageRegistrationPage = accountTypeRegistrationPage.ClickOver13Button();

            //Fill birth date fields. Then proceed
            var personalInfoRegistrationPage = ageRegistrationPage
                .SetDay("29")
                .SetMonth("01")
                .SetYear("1997")
                .Submit();

            //Set email, password, choose your country. Then proceed
            var registrationCompletedPage = personalInfoRegistrationPage
                .EnterUserEmail(UnregisteredUser.Email)
                .EnterUserPassword(UnregisteredUser.Password)
                .SelectDropdown("it") //Italy
                .Submit();

            //Decline email recommendation. Then proceed
            var mainPage = registrationCompletedPage
                .DeclineEmailRecommendations()
                .Submit();

            //Wait some domain redirections to be completed
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.UrlContains("bbc.com"));

            //Assert Uri and page Title
            new AssertionBuilder()
                .AppendAssertion(MainPage.Uri, WebDriver.Url, "Wrong Url")
                .AppendAssertion(MainPage.Title, WebDriver.Title, "Page title wrong text")
                .Verify();
        }

        [TestCase(Browser.Chrome)]
        [TestCase(Browser.Firefox)]
        //TestCaseNumber_FeatureName_TestInput_ExpectedResult
        public void TC201_Signup_ExitClicked_NavigatedtoSignInPage(Browser browser)
        {
            //Click "Exit" on initial registration page
            var mainPage = accountTypeRegistrationPage.ClickExitSignUp();

            //Wait some domain redirections to be completed
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5))
                .Until(ExpectedConditions.UrlContains("bbc.com"));

            //Assert Uri and page Title
            new AssertionBuilder()
                .AppendAssertion(MainPage.Uri, WebDriver.Url, "Wrong Url")
                .AppendAssertion(MainPage.Title, WebDriver.Title, "Page title wrong text")
                .Verify();
        }
    }
}
