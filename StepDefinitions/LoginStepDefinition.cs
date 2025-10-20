using NUnit.Framework;
using automatedTest.Helpers;
using automatedTest.PageAssembly;
using TechTalk.SpecFlow;
using static automatedTest.Helpers.TestDataSource;

namespace automatedTest.StepDefinitions
{
    [Binding, Scope(Tag = "Login")]
    public class LoginStepDefinition
    {
        private BasePages? BasePage => BasePagesHelper.GetBasePage;
        

        // ======= NAVIGATION =======
        [Given(@"user on automation exercise web home page")]
        public void ThenUserOnAutomationExerciseWebHomePage()
        {
            Assert.IsTrue(BasePage?.HomePage.IsAt(), "Home page tidak tampil!");
            BasePage?.HomePage.VerifyHomePageComponents();
        }

        // ==== LOGIN FLOW ====
        [When(@"user clicks on Signup / Login button")]
        public void WhenUserClicksOnSignupLoginButton()
        {
            BasePage?.LoginPage.NavigateToLoginPage();
        }

        [Then(@"verify Login to your account is visible")]
        public void ThenVerifyLoginToYourAccountIsVisible()
        {
            Assert.IsTrue(BasePage?.LoginPage.IsLoginTitleVisible(), "\"Login to your account\" tidak tampil!");
        }


        // // LOGIN VALID
        // [When(@"user logs in with valid email and valid password")]
        // public void WhenUserLogsInWithEmailAndPassword()
        // {
        //     BasePage?.LoginPage.EnterEmailAndPassword(Username, Password);
        // }

        [When(@"user logs in with email (.*) and password (.*)")]
        public void WhenUserLogsInWithEmailAndPassword(string email, string password)
        {
            BasePage?.LoginPage.EnterEmailAndPassword(email, password);
        }
        

        [Then(@"user clicks login button")]
        public void ThenUserClicksLoginButton()
        {
            BasePage?.LoginPage.ClickLoginButton();
        }

        [Then(@"verify that Logged in as username is visible")]
        public void ThenVerifyThatLoggedInAsUsernameIsVisible()
        {
            Assert.IsTrue(BasePage?.LoginPage.IsLoggedInAsVisible(), "\"Logged in as username\" tidak tampil!");
        }

        [Then(@"verify login message (.*) is visible")]
        public void ThenVerifyPageIsVisible(string msg)
        {
            if (msg.Contains("Logged"))
                Assert.IsTrue(BasePage?.LoginPage.IsLoggedInAsVisible(), "\"Logged in as username\" tidak tampil!");
            else 
                Assert.IsTrue(BasePage?.LoginPage.IsLoginErrorVisible(), "Pesan error login tidak tampil!");
        }

        // // LOGIN INVALID
        // [When(@"user logs in with invalid email ""(.*)"" and invalid password ""(.*)""")]
        // public void WhenUserLogsInWithInvalidCredentials(string email, string password)
        // {
        //     BasePage?.LoginPage.EnterEmailAndPassword(email, password);
        // }

        // [Then(@"verify error 'Your email or password is incorrect!' is visible")]
        // public void ThenVerifyErrorIsVisible()
        // {
        //     Assert.IsTrue(BasePage?.LoginPage.IsLoginErrorVisible(), "Pesan error login tidak tampil!");
        // }

        // LOGOUT
        [When(@"user clicks Logout button")]
        public void WhenUserClicksLogoutButton()
        {
            BasePage?.LoginPage.ClickLogoutButton();
        }

        [Then(@"verify that user is navigated to login page")]
        public void ThenVerifyThatUserIsNavigatedToLoginPage()
        {
            Assert.IsTrue(BasePage?.LoginPage.IsBackToLoginPage(), "User tidak diarahkan kembali ke halaman login!");
        }
    }
}