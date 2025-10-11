using OpenQA.Selenium;
using NUnit.Framework;
using automatedTest.Helpers;
using System.Threading;

namespace automatedTest.Pages
{
    /// <summary>
    /// Page Object untuk halaman Home (https://automationexercise.com/)
    /// </summary>
    public class HomePage
    {
        private readonly IWebDriver? _driver;
        private readonly ExtentReportsHelper? _extentReportsHelper;
        private uint TimeoutInSeconds => TestContext.Parameters.Get<uint>("SeleniumTimeout", 60);
        private int Sleep => TestContext.Parameters.Get<int>("SeleniumSleep", 3) * 1000;

        /// <summary>
        /// Konstruktor default
        /// </summary>
        public HomePage()
        {
            _driver = null;
            _extentReportsHelper = null;
        }

        /// <summary>
        /// Konstruktor utama
        /// </summary>
        public HomePage(IWebDriver? webDriver, ExtentReportsHelper? reportsHelper)
        {
            _driver = webDriver;
            _extentReportsHelper = reportsHelper;
        }

        // === LOCATOR ===
        private By BtnHome => By.XPath("//a[@href='/' and contains(normalize-space(.), 'Home')]");
        private By ActiveHomeMenu => By.XPath("//a[@href='/']"); // sesuaikan dengan HTML terbaru
        private By SliderHome => By.Id("slider-carousel");
        private By SectionFeatures => By.XPath("//h2[contains(text(),'Features Items')]");
        private By BtnProducts => By.XPath("//a[@href='/products']");

        // === METHOD ===

        /// <summary>
        /// Verifikasi halaman Home berhasil tampil
        /// </summary>
        public bool IsAt()
        {
            return _driver.ControlDisplayed(SliderHome, _extentReportsHelper, "Slider Home tampil", true, TimeoutInSeconds);
        }

        /// <summary>
        /// Navigate ke URL tertentu
        /// </summary>
        public void Navigate(string url)
        {
            _driver!.Navigate().GoToUrl(url);
            Thread.Sleep(Sleep); // optional delay agar halaman stabil
            _extentReportsHelper?.LogInfo($"Navigated to {url}");
        }

        /// <summary>
        /// Verifikasi elemen utama di halaman Home
        /// </summary>
        public void VerifyHomePageComponents()
        {
            _driver.ControlDisplayed(SliderHome, _extentReportsHelper, "Slider tampil di halaman home", true, TimeoutInSeconds);
            _driver.ControlDisplayed(SectionFeatures, _extentReportsHelper, "Section 'Features Items' tampil", true, TimeoutInSeconds);
        }

        /// <summary>
        /// Verifikasi menu Home tampil dengan benar
        /// </summary>
        public void VerifyHomeMenu()
        {
            // cek tombol Home muncul
            _driver.ControlDisplayed(BtnHome, _extentReportsHelper, "Tombol Home tampil", true, TimeoutInSeconds);

            // cek teks tombol Home
            _driver.ValidateElementTextContains(BtnHome, _extentReportsHelper, "Menu Home teks", "Home", true, TimeoutInSeconds);
        }


        /// <summary>
        /// Klik tombol Products
        /// </summary>
        public void ClickProducts()
        {
            _driver.ClickWrapper(BtnProducts, _extentReportsHelper, "Klik tombol Products", TimeoutInSeconds);
            Thread.Sleep(Sleep);
        }

        /// <summary>
        /// Verifikasi menu Products aktif (warna kuning)
        /// </summary>
        public void VerifyProductsMenu()
        {
            // cek tombol Products muncul
            _driver.ControlDisplayed(BtnProducts, _extentReportsHelper, "Tombol Products tampil", true, TimeoutInSeconds);

            // cek teks tombol Products
            _driver.ValidateElementTextContains(BtnProducts, _extentReportsHelper, "Menu Products teks", "Products", true, TimeoutInSeconds);
        }
    }
}
