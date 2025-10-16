using automatedTest.Helpers;
using OpenQA.Selenium;

namespace automatedTest.Pages.Components
{
    public class Navbar
    {
        public Navbar()
        {
            _driver = null;
            _extentReportsHelper = null;
        }

        public Navbar(IWebDriver? webDriver, ExtentReportsHelper? reportsHelper)
        {
            _driver = webDriver;
            _extentReportsHelper = reportsHelper;
        }

        private readonly IWebDriver? _driver;
        private readonly ExtentReportsHelper? _extentReportsHelper;
        private uint TimeoutInSeconds;
        private int Sleep;

        // LOCATOR
        private By Logo => By.XPath("//img[@alt='Website for automation practice']");
        private By BtnHome => By.XPath("//a[@href='/' and contains(normalize-space(.), 'Home')]");
        private By BtnProducts => By.XPath("//a[@href='/products' and contains(normalize-space(.), 'Products')]");
        private By BtnCart => By.XPath("//a[@href='/view_cart']");
        private By BtnSignupLogin => By.XPath("//a[@href='/login']");
        // private By BtnSignup => By.CssSelector("button[data-qa='signup-button']");
        private By BtnTestCases => By.XPath("//a[@href='/test_cases']");
        private By BtnApiTesting => By.XPath("//a[@href='/api_list']");
        private By BtnVideoTutorials => By.XPath("//a[contains(@href, 'youtube')]");
        private By BtnContactUs => By.XPath("//a[@href='/contact_us']");

        //METHOD

        // private IWebElement WaitUntilClickable(By locator)
        // {
        //     return new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(TimeoutInSeconds))
        //            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        // }
        
        public void ClickHome() =>
            _driver.ClickWrapper(BtnHome, _extentReportsHelper, "Klik menu Home", TimeoutInSeconds);

        public void ClickProducts() =>
            _driver.ClickWrapper(BtnProducts, _extentReportsHelper, "Klik menu Products", TimeoutInSeconds);

        public void ClickCart() =>
            _driver.ClickWrapper(BtnCart, _extentReportsHelper, "Klik menu Cart", TimeoutInSeconds);

        public void ClickSignupLogin() =>
            _driver.ClickWrapper(BtnSignupLogin, _extentReportsHelper, "Klik menu Signup/Login", TimeoutInSeconds);

        public void ClickTestCases() =>
            _driver.ClickWrapper(BtnTestCases, _extentReportsHelper, "Klik menu Test Cases", TimeoutInSeconds);

        public void ClickApiTesting() =>
            _driver.ClickWrapper(BtnApiTesting, _extentReportsHelper, "Klik menu API Testing", TimeoutInSeconds);

        public void ClickVideoTutorials() =>
            _driver.ClickWrapper(BtnVideoTutorials, _extentReportsHelper, "Klik menu Video Tutorials", TimeoutInSeconds);

        public void ClickContactUs() =>
            _driver.ClickWrapper(BtnContactUs, _extentReportsHelper, "Klik menu Contact Us", TimeoutInSeconds);

        public void VerifyNavbarVisible()
        {
            _driver.ControlDisplayed(Logo, _extentReportsHelper, "Logo tampil di navbar", true, TimeoutInSeconds);
            _driver.ControlDisplayed(BtnHome, _extentReportsHelper, "Tombol Home tampil di navbar", true, TimeoutInSeconds);
        }
    }
}