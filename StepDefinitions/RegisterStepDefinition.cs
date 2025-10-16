using NUnit.Framework;
using automatedTest.Helpers;
using automatedTest.PageAssembly;
using TechTalk.SpecFlow;

namespace automatedTest.StepDefinitions
{
    [Binding, Scope(Tag = "Register")]
    public class RegisterStepDefinitions
    {
        private BasePages? BasePage => BasePagesHelper.GetBasePage;


        [Given(@"user on automation exercise web home page")]
        public void ThenUserOnAutomationExerciseWebHomePage()
        {
            Assert.IsTrue(BasePage?.HomePage.IsAt(), "Home page tidak tampil!");
            BasePage?.HomePage.VerifyHomePageComponents();
        }

        // ======= SIGNUP FLOW =======
        [When(@"user clicks on ""Signup / Login"" button")]
        public void WhenUserClicksOnSignupLoginButton()
        {
            BasePage?.RegisterPage.NavigateToSignupPage();
        }

        [Then(@"verify ""New User Signup!"" is visible")]
        public void ThenVerifyNewUserSignupIsVisible()
        {
            Assert.IsTrue(BasePage?.RegisterPage.IsNewUserSignupVisible(), "\"New User Signup!\" tidak tampil!");
        }

        [When(@"user enters name and email address")]
        public void WhenUserEntersNameAndEmailAddress()
        {
            BasePage?.RegisterPage.EnterNameAndEmail();
        }

        [When(@"clicks ""Signup"" button")]
        public void WhenClicksSignupButton()
        {
            BasePage?.RegisterPage.ClickSignupButton();
        }

        [Then(@"verify that ""ENTER ACCOUNT INFORMATION"" is visible")]
        public void ThenVerifyThatEnterAccountInformationIsVisible()
        {
            Assert.IsTrue(BasePage?.RegisterPage.IsEnterAccountInfoVisible(), "\"ENTER ACCOUNT INFORMATION\" tidak tampil!");
        }

        // ======= ACCOUNT CREATION =======
        [When(@"user fills account details with valid data")]
        public void WhenUserFillsAccountDetailsWithValidData()
        {
            BasePage?.RegisterPage.FillAccountDetails();
        }

        [When(@"selects newsletter and offers checkboxes")]
        public void WhenSelectsNewsletterAndOffersCheckboxes()
        {
            BasePage?.RegisterPage.SelectCheckboxes();
        }

        [When(@"fills address details")]
        public void WhenFillsAddressDetails()
        {
            BasePage?.RegisterPage.FillAddressDetails();
        }

        [When(@"clicks ""Create Account"" button")]
        public void WhenClicksCreateAccountButton()
        {
            BasePage?.RegisterPage.ClickCreateAccount();
        }

        [Then(@"verify that ""ACCOUNT CREATED!"" is visible")]
        public void ThenVerifyThatAccountCreatedIsVisible()
        {
            Assert.IsTrue(BasePage?.RegisterPage.IsAccountCreatedVisible(), "\"ACCOUNT CREATED!\" tidak tampil!");
        }

        // ======= LOGIN POST-CREATION =======
        [When(@"user clicks ""Continue"" button")]
        public void WhenUserClicksContinueButton()
        {
            BasePage?.RegisterPage.ClickContinueButton();
        }

        [Then(@"verify that ""Logged in as username"" is visible")]
        public void ThenVerifyThatLoggedInAsUsernameIsVisible()
        {
            Assert.IsTrue(BasePage?.RegisterPage.IsLoggedInAsVisible(), "\"Logged in as username\" tidak tampil!");
        }

        // ======= DELETE ACCOUNT =======
        [When(@"user clicks ""Delete Account"" button")]
        public void WhenUserClicksDeleteAccountButton()
        {
            BasePage?.RegisterPage.ClickDeleteAccount();
        }

        [Then(@"verify that ""ACCOUNT DELETED!"" is visible")]
        public void ThenVerifyThatAccountDeletedIsVisible()
        {
            Assert.IsTrue(BasePage?.RegisterPage.IsAccountDeletedVisible(), "\"ACCOUNT DELETED!\" tidak tampil!");
        }

        [Then(@"clicks ""Continue"" button after delete")]
        public void ThenClicksContinueButtonAfterDelete()
        {
            BasePage?.RegisterPage.ClickContinueButton();
        }
    }
}