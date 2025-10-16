using automatedTest.Helpers;
using OpenQA.Selenium;
using automatedTest.Pages.Components;

namespace automatedTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentReportsHelper _extentReportsHelper;
        private readonly Navbar _navbar;

        private uint TimeoutInSeconds;
        private int Sleep;

        public LoginPage()
        {
            _driver = null;
            _extentReportsHelper = null;
            _navbar = new Navbar(_driver, _extentReportsHelper);
        }

        public LoginPage(IWebDriver driver, ExtentReportsHelper reportsHelper)
        {
            _driver = driver;
            _extentReportsHelper = reportsHelper;
            _navbar = new Navbar(driver, reportsHelper);
        }

        // LOCATOR
        private By TxtLoginTitle => By.XPath("//h2[contains(text(),'Login to your account')]");
        private By InputEmail => By.CssSelector("input[data-qa='login-email']");
        private By InputPassword => By.CssSelector("input[data-qa='login-password']");
        private By BtnLogin => By.CssSelector("button[data-qa='login-button']");
        private By TxtLoggedIn => By.XPath("//a[contains(text(),'Logged in as')]");
        private By BtnLogout => By.XPath("//a[@href='/logout']");
        private By TxtLoginPage => By.XPath("//h2[contains(text(),'Login to your account')]");
        private By TxtLoginError => By.XPath("//p[contains(text(),'Your email or password is incorrect!')]");

        // methods
        public void NavigateToLoginPage()
        {
            _navbar.ClickSignupLogin();
            Thread.Sleep(Sleep);
            _driver.ControlDisplayed(TxtLoginTitle, _extentReportsHelper, "Login title visible", true, TimeoutInSeconds);
        }

        public bool IsLoginTitleVisible()
        {
            return _driver.ControlDisplayed(TxtLoginTitle, _extentReportsHelper, "Login title visible", true, TimeoutInSeconds);
        }

        public void EnterEmailAndPassword(string email, string password)
        {
            _driver.SendKeysWrapper(InputEmail, _extentReportsHelper, email, "Enter email", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputPassword, _extentReportsHelper, password, "Enter password", TimeoutInSeconds);
        }
        public void ClickLoginButton()
        {
            _driver.ClickWrapper(BtnLogin, _extentReportsHelper, "Click login button", TimeoutInSeconds);
            Thread.Sleep(Sleep);
        }

        public bool IsLoggedInAsVisible()
        {
            return _driver.ControlDisplayed(TxtLoggedIn, _extentReportsHelper, "Logged in as username visible", true, TimeoutInSeconds);
        }

        public void ClickLogoutButton()
        {
            _driver.ControlDisplayed(BtnLogout, _extentReportsHelper, "Logout button visible", true, TimeoutInSeconds);
            _driver.ClickWrapper(BtnLogout, _extentReportsHelper, "Click Logout Button", TimeoutInSeconds);
            Thread.Sleep(Sleep);
        }

        public bool IsBackToLoginPage()
        {
            return _driver.ControlDisplayed(TxtLoginPage, _extentReportsHelper, "Login page visible", true, TimeoutInSeconds);
        }

        public bool IsLoginErrorVisible()
        {
            return _driver.ControlDisplayed(TxtLoginError, _extentReportsHelper, "Login error message visible", true, TimeoutInSeconds);
        }
    }
}