using NUnit.Framework;
using automatedTest.Helpers;
using automatedTest.PageAssembly;
using TechTalk.SpecFlow;

namespace automatedTest.StepDefinitions
{
    [Binding, Scope(Tag = "Login")]
    public class LoginStepDefinition
    {
        private BasePages? BasePage => BasePagesHelper.GetBasePage;

        // ======= NAVIGATION =======
        [Given(@"user navigates to url ""(.*)""")]
        public void GivenUserNavigatesToUrl(string BaseUrl)
        {
            BasePage?.HomePage.Navigate(BaseUrl);
        }

        [Then(@"verify that home page is visible successfully")]
        public void ThenVerifyThatHomePageIsVisibleSuccessfully()
        {
            Assert.IsTrue(BasePage?.HomePage.IsAt(), "Home page tidak tampil!");
            BasePage?.HomePage.VerifyHomePageComponents();
        }

        // ==== LOGIN FLOW ====
        [When(@"user clicks on ""Signup / Login"" button")]
        public void WhenUserClicksOnSignupLoginButton()
        {
            BasePage?.LoginPage.NavigateToLoginPage();
        }

        [Then(@"verify ""Login to your account"" is visible")]
        public void ThenVerifyLoginToYourAccountIsVisible()
        {
            Assert.IsTrue(BasePage?.LoginPage.IsLoginTitleVisible(), "\"Login to your account\" tidak tampil!");
        }

        [When(@"user logs in with email ""(.*)"" and password ""(.*)""")]
        public void WhenUserLogsInWithEmailAndPassword(string email, string password)
        {
            BasePage?.LoginPage.EnterEmailAndPassword(email, password);
        }

        [Then(@"user clicks ""login"" button")]
        public void ThenUserClicksLoginButton()
        {
            BasePage?.LoginPage.ClickLoginButton();
        }

        [Then(@"verify that ""Logged in as username"" is visible")]
        public void ThenVerifyThatLoggedInAsUsernameIsVisible()
        {
            Assert.IsTrue(BasePage?.LoginPage.IsLoggedInAsVisible(), "\"Logged in as username\" tidak tampil!");
        }

        // ======= DELETE ACCOUNT =======
        [When(@"user clicks ""Delete Account"" button")]
        public void WhenUserClicksDeleteAccountButton()
        {
            BasePage?.LoginPage.ClickDeleteAccount();
        }

        [Then(@"verify that ""ACCOUNT DELETED!"" is visible")]
        public void ThenVerifyThatAccountDeletedIsVisible()
        {
            Assert.IsTrue(BasePage?.LoginPage.IsAccountDeletedVisible(), "\"ACCOUNT DELETED!\" tidak tampil!");
        }
    }
}