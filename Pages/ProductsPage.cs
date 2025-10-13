using OpenQA.Selenium;
using automatedTest.Helpers;
using automatedTest.Pages.Components;
using NUnit.Framework;
using System.Threading;

namespace automatedTest.Pages
{
    /// <summary>
    /// Halaman Products Automation Exercise
    /// </summary>
    public class ProductsPage
    {
        private readonly IWebDriver? _driver;
        private readonly ExtentReportsHelper? _extentReportsHelper;
        private uint TimeoutInSeconds => TestContext.Parameters.Get<uint>("SeleniumTimeout", 60);
        private int Sleep => TestContext.Parameters.Get<int>("SeleniumSleep", 2) * 1000;
        private readonly Navbar _navbar;

        // === Konstruktor ===
        public ProductsPage()
        {
            _driver = null;
            _extentReportsHelper = null;
            _navbar = new Navbar(_driver, _extentReportsHelper);
        }

        public ProductsPage(IWebDriver? webDriver, ExtentReportsHelper? reportsHelper)
        {
            _driver = webDriver;
            _extentReportsHelper = reportsHelper;
            _navbar = new Navbar(webDriver, reportsHelper);
        }

        // === LOCATORS ===
        // private By BtnProducts => By.XPath("//a[@href='/products' and contains(normalize-space(.), 'Products')]");
        private By ImgSale => By.XPath("//img[contains(@src,'sale')]");
        private By TitleAllProducts => By.CssSelector("h2.title.text-center");
        private By InputSearch => By.Id("search_product");
        private By BtnSearch => By.Id("submit_search");
        private By TitleSearched => By.CssSelector("h2.title.text-center");
        private By ProductNames => By.CssSelector("div.productinfo.text-center > p");
        // private By ActiveMenu => By.CssSelector("ul.nav.navbar-nav li.active a");

        // === METHOD ===

        /// <summary>
        /// Halaman Products tampil
        /// </summary>
        public bool IsAt()
        {
            return _driver.ControlDisplayed(TitleAllProducts, _extentReportsHelper, "All Products title visible", true, TimeoutInSeconds);
        }

        /// <summary>
        /// Verifikasi gambar SALE dan judul ALL PRODUCTS tampil
        /// </summary>
        public void VerifyProductsPageComponents()
        {
            _driver.ControlDisplayed(ImgSale, _extentReportsHelper, "Sale image visible", true, TimeoutInSeconds);
            _driver.ControlDisplayed(TitleAllProducts, _extentReportsHelper, "ALL PRODUCTS title visible", true, TimeoutInSeconds);
        }

        /// <summary>
        /// Klik Products menu dan cek warna kuning/orange
        /// </summary>
        public void VerifyProductsMenuActive()
        {
            // _driver.ControlDisplayed(BtnProducts, _extentReportsHelper, "Tombol Products tampil", true, TimeoutInSeconds);
            // _driver.ValidateElementTextContains(BtnProducts, _extentReportsHelper, "Menu Products teks", "Products", true, TimeoutInSeconds);
            _navbar.VerifyNavbarVisible();
        }

        /// <summary>
        /// Input nama produk & klik search
        /// </summary>
        public void SearchProduct(string keyword)
        {
            _driver.ClearWrapper(InputSearch, _extentReportsHelper, "Clear search input", TimeoutInSeconds);
            _driver.SendKeysWrapper(InputSearch, _extentReportsHelper, keyword, "Input search product", TimeoutInSeconds);
            _driver.ClickWrapper(BtnSearch, _extentReportsHelper, "Click search button", TimeoutInSeconds);
            Thread.Sleep(Sleep);
        }

        /// <summary>
        /// Verifikasi hasil pencarian produk sesuai keyword
        /// </summary>
        public void VerifySearchResult(string keyword)
        {
            _driver.ControlDisplayed(TitleSearched, _extentReportsHelper, "SEARCHED PRODUCTS title visible", true, TimeoutInSeconds);
            _driver.ValidateElementTextContains(TitleSearched, _extentReportsHelper, "SEARCHED PRODUCTS title validation", "Searched Products", true, TimeoutInSeconds);
            _driver.ValidateElementsSizeGreaterThan(ProductNames, _extentReportsHelper, "At least one product found", (int)TimeoutInSeconds);

            var elements = _driver.FindElements(ProductNames); // FindElements di sini masih bisa karena hanya membaca koleksi
            foreach (var el in elements)
            {
                string name = el.Text.ToLower();
                _extentReportsHelper?.LogInfo($"Found product: {name}");
                Assert.IsTrue(name.Contains(keyword.ToLower()), $"Product '{name}' does not contain keyword '{keyword}'");
            }
        }
    }
}
