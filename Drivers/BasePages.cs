using System;
using automatedTest.Helpers;
using automatedTest.Pages;
using SeleniumExtras.PageObjects;

namespace automatedTest.PageAssembly
{
    /// <summary>
    /// BasePages
    /// </summary>
    public class BasePages
    {
        /// <summary>
        /// Konstruktor BasePages
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="extentReportsHelper"></param>
        public BasePages(Browsers? browser, ExtentReportsHelper extentReportsHelper)
        {
            Browser = browser;
            ExtentReportsHelper = extentReportsHelper;
        }

        /// <summary>
        /// Browser
        /// </summary>
        protected Browsers? Browser { get; }

        /// <summary>
        /// ExtentReportsHelper
        /// </summary>
        protected ExtentReportsHelper? ExtentReportsHelper { get; }

        /// <summary>
        /// Generic untuk inisialisasi page object
        /// </summary>
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), Browser?.GetDriver, ExtentReportsHelper)!;
            if (Browser?.GetDriver != null) 
                PageFactory.InitElements(Browser.GetDriver, page);
            return page;
        }

        /// <summary>
        /// HomePage instance
        /// </summary>
        public HomePage HomePage => GetPages<HomePage>();

        /// <summary>
        /// ProductsPage instance
        /// </summary>
        public ProductsPage ProductsPage => GetPages<ProductsPage>();
    }
}
