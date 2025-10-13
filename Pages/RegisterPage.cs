using automatedTest.Helpers;
using OpenQA.Selenium;
using automatedTest.Pages.Components;
using System;
using System.Threading;

namespace automatedTest.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentReportsHelper _extentReportsHelper;
        private readonly Navbar _navbar;

        private uint TimeoutInSeconds => TestContext.Parameters.Get<uint>("SeleniumTimeout", 60);
        private int Sleep => TestContext.Parameters.Get<int>("SeleniumSleep", 3) * 1000;

        public RegisterPage()
        {
            _driver = null;
            _extentReportsHelper = null;
            _navbar = new Navbar(_driver, _extentReportsHelper);
        }

        public RegisterPage(IWebDriver driver, ExtentReportsHelper reportsHelper)
        {
            _driver = driver;
            _extentReportsHelper = reportsHelper;
            _navbar = new Navbar(driver, reportsHelper);
        }

        // === LOCATORS ===
        private By TxtNewUserSignup => By.XPath("//h2[contains(text(),'New User Signup')]");
        private By InputName => By.CssSelector("input[data-qa='signup-name']");
        private By InputEmail => By.CssSelector("input[data-qa='signup-email']");
        private By BtnSignup => By.CssSelector("button[data-qa='signup-button']");
        private By TitleEnterAccountInfo => By.XPath("//b[text()='Enter Account Information']");
        private By RadioTitleMr => By.Id("id_gender1");
        private By InputPassword => By.Id("password");
        private By SelectDays => By.Id("days");
        private By SelectMonths => By.Id("months");
        private By SelectYears => By.Id("years");
        private By CheckboxNewsletter => By.Id("newsletter");
        private By CheckboxOffers => By.Id("optin");
        private By InputFirstName => By.Id("first_name");
        private By InputLastName => By.Id("last_name");
        private By InputCompany => By.Id("company");
        private By InputAddress1 => By.Id("address1");
        private By InputAddress2 => By.Id("address2");
        private By SelectCountry => By.Id("country");
        private By InputState => By.Id("state");
        private By InputCity => By.Id("city");
        private By InputZipcode => By.Id("zipcode");
        private By InputMobile => By.Id("mobile_number");
        private By BtnCreateAccount => By.XPath("//button[@data-qa='create-account']");
        private By TxtAccountCreated => By.XPath("//b[text()='Account Created!']");
        private By BtnContinue => By.XPath("//a[@data-qa='continue-button']");
        private By TxtLoggedInAs => By.XPath("//a[contains(text(),'Logged in as')]");
        private By BtnDeleteAccount => By.XPath("//a[contains(text(),'Delete Account')]");
        private By TxtAccountDeleted => By.XPath("//b[text()='Account Deleted!']");

        // ======== METHODS ========
        public void NavigateToSignupPage()
        {
            _navbar.ClickSignupLogin();
            Thread.Sleep(Sleep);
            _driver.ControlDisplayed(TxtNewUserSignup, _extentReportsHelper, "New User Signup visible", true, TimeoutInSeconds);
        }

        public void EnterNameAndEmail()
        {
            string name = "Automation Tester";
            Random random = new Random();
            string email = $"automation{random.Next(1000, 9999)}@example.com";

            _driver.SendKeysWrapper(InputName, _extentReportsHelper, name, "Input name", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputEmail, _extentReportsHelper, email, "Input email", TimeoutInSeconds);
            _extentReportsHelper?.LogInfo($"Generated email: {email}");
        }

        public void ClickSignupButton()
        {
            _driver.ClickWrapper(BtnSignup, _extentReportsHelper, "Click signup button", TimeoutInSeconds);
            Thread.Sleep(Sleep);
        }

        public bool IsNewUserSignupVisible()
        {
            return _driver.ControlDisplayed(TxtNewUserSignup, _extentReportsHelper, "New User Signup visible", true, TimeoutInSeconds);
        }

        public bool IsEnterAccountInfoVisible()
        {
            return _driver.ControlDisplayed(TitleEnterAccountInfo, _extentReportsHelper, "ENTER ACCOUNT INFORMATION visible", true, TimeoutInSeconds);
        }

        public void FillAccountDetails()
        {
            _driver.ClickWrapper(RadioTitleMr, _extentReportsHelper, "Select title Mr", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputPassword, _extentReportsHelper, "Password123!", "Input password", TimeoutInSeconds);
            _driver.SelectByTextWrapper(SelectDays, _extentReportsHelper, "10", "Select day", TimeoutInSeconds);
            _driver.SelectByTextWrapper(SelectMonths, _extentReportsHelper, "June", "Select month", TimeoutInSeconds);
            _driver.SelectByTextWrapper(SelectYears, _extentReportsHelper, "1998", "Select year", TimeoutInSeconds);
        }

        public void SelectCheckboxes()
        {
            _driver.ClickWrapper(CheckboxNewsletter, _extentReportsHelper, "Select newsletter", TimeoutInSeconds);
            _driver.ClickWrapper(CheckboxOffers, _extentReportsHelper, "Select special offers", TimeoutInSeconds);
        }

        public void FillAddressDetails()
        {
            _driver.SendKeysWrapper(InputFirstName, _extentReportsHelper, "Ahmad", "First Name", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputLastName, _extentReportsHelper, "Fadilah", "Last Name", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputCompany, _extentReportsHelper, "PT Automation", "Company", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputAddress1, _extentReportsHelper, "Jl. Mawar 12", "Address1", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputAddress2, _extentReportsHelper, "Kecamatan Cikupa", "Address2", TimeoutInSeconds);
            _driver.SelectByTextWrapper(SelectCountry, _extentReportsHelper, "Canada", "Select Country", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputState, _extentReportsHelper, "Banten", "State", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputCity, _extentReportsHelper, "Tangerang", "City", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputZipcode, _extentReportsHelper, "15810", "Zipcode", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputMobile, _extentReportsHelper, "08123456789", "Mobile", TimeoutInSeconds);
        }

        public void ClickCreateAccount()
        {
            _driver.ClickWrapper(BtnCreateAccount, _extentReportsHelper, "Click Create Account", TimeoutInSeconds);
            Thread.Sleep(Sleep);
        }

        public bool IsAccountCreatedVisible()
        {
            return _driver.ControlDisplayed(TxtAccountCreated, _extentReportsHelper, "ACCOUNT CREATED visible", true, TimeoutInSeconds);
        }

        public void ClickContinueButton()
        {
            _driver.ClickWrapper(BtnContinue, _extentReportsHelper, "Click Continue button", TimeoutInSeconds);
        }

        public bool IsLoggedInAsVisible()
        {
            return _driver.ControlDisplayed(TxtLoggedInAs, _extentReportsHelper, "Logged in as username visible", true, TimeoutInSeconds);
        }

        public void ClickDeleteAccount()
        {
            _driver.ClickWrapper(BtnDeleteAccount, _extentReportsHelper, "Click Delete Account", TimeoutInSeconds);
        }

        public bool IsAccountDeletedVisible()
        {
            return _driver.ControlDisplayed(TxtAccountDeleted, _extentReportsHelper, "ACCOUNT DELETED visible", true, TimeoutInSeconds);
        }
    }
}
