using NUnit.Framework;
using automatedTest.Helpers;
using automatedTest.Pages;
using TechTalk.SpecFlow;

namespace automatedTest.StepDefinitions
{
    [Binding]
    public class SearchProductStepDefinitions
    {
        private readonly HomePage _homePage = BasePagesHelper.GetBasePage.HomePage
            ?? throw new ArgumentNullException(nameof(BasePagesHelper.GetBasePage.HomePage));

        private readonly ProductsPage _productsPage = BasePagesHelper.GetBasePage.ProductsPage
            ?? throw new ArgumentNullException(nameof(BasePagesHelper.GetBasePage.ProductsPage));

        private string _searchedKeyword = "";

        // -----------------------------
        // GIVEN: Browser sudah terbuka
        // -----------------------------
        [Given(@"user launches the browser")]
        public void GivenUserLaunchesTheBrowser()
        {
            // Browser sudah dikelola di BasePagesHelper
        }

        // -----------------------------
        // WHEN: Navigate ke halaman
        // -----------------------------
        [When(@"user navigates to ""(.*)""")]
        public void WhenUserNavigatesTo(string url)
        {
            _homePage.Navigate(url);
        }

        // -----------------------------
        // THEN: Verifikasi HomePage tampil
        // -----------------------------
        [Then(@"home page title ""(.*)"" should be visible")]
        public void ThenHomePageTitleShouldBeVisible(string title)
        {
            Assert.IsTrue(_homePage.IsAt(), "Home page tidak tampil");
            _homePage.VerifyHomePageComponents();
            _homePage.VerifyHomeMenu(); // cek teks Home saja
        }

        // -----------------------------
        // WHEN: Klik tombol Products
        // -----------------------------
        [When(@"user clicks on ""(.*)"" button")]
        public void WhenUserClicksOnButton(string buttonName)
        {
            if (buttonName.Equals("Products", System.StringComparison.OrdinalIgnoreCase))
            {
                _homePage.ClickProducts();
            }
        }

        // -----------------------------
        // THEN: Verifikasi ProductsPage tampil
        // -----------------------------
        [Then(@"products page title ""(.*)"" should be visible")]
        public void ThenProductsPageTitleShouldBeVisible(string title)
        {
            Assert.IsTrue(_productsPage.IsAt(), "Products page tidak tampil");
            _productsPage.VerifyProductsMenuActive(); // cek teks Products saja
        }

        [Then(@"user should see sale images")]
        public void ThenUserShouldSeeSaleImages()
        {
            _productsPage.VerifyProductsPageComponents();
        }

        // -----------------------------
        // WHEN: Input keyword pencarian
        // -----------------------------
        [When(@"user enters a product name in the search input")]
        public void WhenUserEntersAProductNameInTheSearchInput()
        {
            _searchedKeyword = "Blue Top"; // contoh keyword
            _productsPage.SearchProduct(_searchedKeyword); // sudah include klik search
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
            Assert.IsTrue(_productsPage.IsAt(), "Search results page tidak tampil");
        }

        [Then(@"title ""(.*)"" should be visible")]
        public void ThenTitleShouldBeVisible(string expectedTitle)
        {
            _productsPage.VerifySearchResult(_searchedKeyword);
        }

        [Then(@"all products related to the searched keyword should be displayed")]
        public void ThenAllProductsRelatedToTheSearchedKeywordShouldBeDisplayed()
        {
            _productsPage.VerifySearchResult(_searchedKeyword);
        }
    }
}
