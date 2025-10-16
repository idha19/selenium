using NUnit.Framework;
using automatedTest.Helpers;
using automatedTest.Pages;
using TechTalk.SpecFlow;
using automatedTest.PageAssembly;

namespace automatedTest.StepDefinitions
{
    [Binding, Scope(Tag = "SearchProduct")]
    public class SearchProductStepDefinitions
    {
        private BasePages? BasePage => BasePagesHelper.GetBasePage;
        private string _searchedKeyword = "";

        [Given(@"user on automation exercise web home page")]
        public void ThenUserOnAutomationExerciseWebHomePage()
        {
            Assert.IsTrue(BasePage?.HomePage.IsAt(), "Home page tidak tampil!");
            BasePage?.HomePage.VerifyHomePageComponents();
        }

        // -----------------------------
        // WHEN: Klik tombol Products
        // -----------------------------
        [When(@"user clicks on Products button")]
        public void WhenUserClicksOnProductsButton()
        {
            BasePage?.HomePage.ClickProducts();
        }

        // -----------------------------
        // THEN: Verifikasi ProductsPage tampil
        // -----------------------------
        [Then(@"products page title ""(.*)"" should be visible")]
        public void ThenProductsPageTitleShouldBeVisible(string title)
        {
            Assert.IsTrue(BasePage?.ProductsPage.IsAt(), "Products page tidak tampil!");
            BasePage?.ProductsPage.VerifyProductsMenuActive();
            BasePage?.ProductsPage.VerifyProductsPageComponents();
        }

        [Then(@"user should see sale images")]
        public void ThenUserShouldSeeSaleImages()
        {
            BasePage?.ProductsPage.VerifyProductsPageComponents();
        }

        // -----------------------------
        // WHEN: Input keyword pencarian
        // -----------------------------
        [When(@"user enters a product name in the search input")]
        public void WhenUserEntersAProductNameInTheSearchInput()
        {
            _searchedKeyword = "Blue Top"; // contoh keyword
            BasePage?.ProductsPage.SearchProduct(_searchedKeyword); // sudah include klik search
        }

        [When(@"clicks the search button")]
        public void WhenClicksTheSearchButton()
        {
            // Tidak perlu implementasi karena SearchProduct() sudah klik
        }

        // -----------------------------
        // THEN: Verifikasi search results
        // -----------------------------
        [Then(@"user should be navigated to the search results page")]
        public void ThenUserShouldBeNavigatedToTheSearchResultsPage()
        {
            Assert.IsTrue(BasePage?.ProductsPage.IsAt(), "Search results page tidak tampil");
        }

        [Then(@"title ""(.*)"" should be visible")]
        public void ThenTitleShouldBeVisible(string expectedTitle)
        {
            BasePage?.ProductsPage.VerifySearchResult(_searchedKeyword);
        }

        [Then(@"all products related to the searched keyword should be displayed")]
        public void ThenAllProductsRelatedToTheSearchedKeywordShouldBeDisplayed()
        {
            BasePage?.ProductsPage.VerifySearchResult(_searchedKeyword);
        }
    }
}
