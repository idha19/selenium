// -----------------------------------------------------------------------
// <copyright file="Browsers.cs" company="PT United Tractos Tbk.">
// Copyright (c) 2021 Ahmad Ilman Fadilah. All rights reserved.
// </copyright>
// <author>Ahmad Ilman Fadilah, ahmadilmanfadilah@gmail.com</author>
// -----------------------------------------------------------------------

using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using automatedTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Appium;

namespace automatedTest.PageAssembly
{

    // https://github.com/SeleniumHQ/selenium/issues/8229
    internal class RemoteWebDriverWithLogs : RemoteWebDriver, ISupportsLogs
    {
        public RemoteWebDriverWithLogs(Uri remoteAddress, DriverOptions options) : base(remoteAddress, options)
        {
        }
    }

    /// <summary>
    /// Browsers
    /// </summary>
    public class Browsers
    {
        private readonly bool _isNewArchitecture;
        private readonly string _serverUrl;
        private readonly string _username;
        private readonly string _password;
        private readonly string _baseUrl;
        private readonly bool _isSelenoid;
        private readonly bool _isMobile;
        private readonly string _logLevel;
        private readonly string _browser;
        private readonly string _browserVersion;
        private readonly string _remoteWebDriverUrl;
        private readonly ExtentReportsHelper? _extentReportsHelper;
        private readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Browsers
        /// </summary>
        /// <param name="scenarioContext"></param>
        /// <param name="reportsHelper"></param>
        public Browsers(ScenarioContext scenarioContext, ExtentReportsHelper reportsHelper)
        {
            _extentReportsHelper = reportsHelper;
            _scenarioContext = scenarioContext;
            _isNewArchitecture = TestContext.Parameters.Get<bool>("IsNewArchitecture", true);
            _serverUrl = TestContext.Parameters.Get<string>("SeleniumRemote", "http://192.168.43.38:5555");
            _username = TestContext.Parameters.Get<string>("SeleniumUsername", "admin");
            _password = TestContext.Parameters.Get<string>("SeleniumPassword", "Admin123");

            if (_isNewArchitecture)
                _remoteWebDriverUrl = URLHelper.GetTestServer(_serverUrl, _username, _password);
            else
                _remoteWebDriverUrl = URLHelper.GetTestServer(_serverUrl);

            _browser = TestContext.Parameters.Get<string>("SeleniumBrowser", "chrome");
            _browserVersion = TestContext.Parameters.Get<string>("SeleniumBrowserVersion", "1");
            _baseUrl = TestContext.Parameters.Get<string>("AppBaseURL", "https://www.google.co.id/");
            _isSelenoid = TestContext.Parameters.Get<bool>("IsSelenoid", false);
            _isMobile = TestContext.Parameters.Get<bool>("IsMobile", false);
            _logLevel = TestContext.Parameters.Get<string>("LogLevel", "All");
        }

        /// <summary>
        /// Init
        /// </summary>
        public void Init()
        {
            GetDriver = GetWebDriver();
            //_scenarioContext.Set(GetDriver, "SeleniumDriver");
            if (GetDriver is IAllowsFileDetection allowsDetection)
            {
                allowsDetection.FileDetector = new LocalFileDetector();
            }

            Goto("");
        }

        private DriverOptions DetectWebDriver()

        {
            switch (_browser.ToLower())
            {
                case "chrome":
                    return new ChromeOptions { AcceptInsecureCertificates = true };
                case "firefox":
                    return new FirefoxOptions { AcceptInsecureCertificates = true };
                case "safari":
                    if (_isMobile)
                    {
                        var appiumOptions = new AppiumOptions();
                        appiumOptions.PlatformName = "IOS";
                        appiumOptions.AddAdditionalAppiumOption("udid", TestContext.Parameters.Get<string>("SeleniumUdid", "xxxxxxxxx"));
                        appiumOptions.DeviceName = TestContext.Parameters.Get<string>("SeleniumDeviceName", "iPhone 13 Pro Max");
                        appiumOptions.PlatformVersion = TestContext.Parameters.Get<string>("SeleniumPlatformVersion", "15.4"); ;
                        appiumOptions.BrowserName = _browser.ToLower();
                        return appiumOptions;
                    }
                    else
                    {
                        var safari = new SafariOptions();
                        return new SafariOptions { PlatformName = "MAC" };

                    }
                case "microsoftedge":
                    return new EdgeOptions();
                default:
                    throw new Exception($"Browser {_browser} is not supported");
            }

        }

        /// <summary>
        /// GetDriver
        /// </summary>
        public IWebDriver? GetDriver { get; private set; }

        private IWebDriver? GetWebDriver()
        {
            DriverOptions options = DetectWebDriver();

            var logLevel = _logLevel.ToLower() switch
            {
                "all" => LogLevel.All,
                "info" => LogLevel.Info,
                "warning" => LogLevel.Warning,
                "severe" => LogLevel.Severe,
                "off" => LogLevel.Off,
                "debug" => LogLevel.Debug,
                _ => LogLevel.All
            };

            options.SetLoggingPreference(LogType.Browser, logLevel);

            if (_isSelenoid)
            {
                var runName = GetType().Assembly.GetName().Name ?? "";
                var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";
                var testCase = TestContext.CurrentContext.Test.Name;
                var appName = TestContext.Parameters.Get<string>("AppName", "PartOnlineTransaction");
                var appVersion = TestContext.Parameters.Get<string>("AppVersion", "2.0.0");
                var isEnableVideo = TestContext.Parameters.Get<bool>("IsEnableVideo", true);

                options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
                {
                    ["name"] = runName,
                    ["videoName"] = $"{runName}.{appName}.{testCase}.{appVersion}.{_browser}.{timestamp}.mp4",
                    ["logName"] = $"{runName}.{appName}.{testCase}.{appVersion}.{_browser}.{timestamp}.log",
                    ["enableVnc"] = true,
                    ["enableLog"] = true,
                    ["enableVideo"] = isEnableVideo,
                    ["screenResolution"] = "1920x1080x24",
                    ["timeZone"] = "Asia/Jakarta",
                });

                if (_browserVersion.ToLower() != "1")
                {
                    options.BrowserVersion = _browserVersion;
                }

                if (_browser.ToLower() == "firefox")
                {
                    var firefoxOptions = (FirefoxOptions)options;
                    firefoxOptions.SetEnvironmentVariable("VERBOSE", "true");
                }
                else
                {
                    options.AddAdditionalOption("env", new Dictionary<string, object>
                    {
                        ["VERBOSE"] = true,
                    });
                }
            }
            else
            {
                if (!_isMobile)
                {
                    options.PlatformName = TestContext.Parameters.Get<string>("SeleniumPlatformName", "MAC");
                }
            }

            Func<IWebDriver?> webDriverFunc = () => new RemoteWebDriverWithLogs(new Uri(_remoteWebDriverUrl), options);
            var webDriver = webDriverFunc.Invoke();

            // Set scenario context driver
            //_scenarioContext.Set(webDriver, "WebDriver");
            //_extentReportsHelper?.SetStepStatusPass("Browser started.");

            if (!_isMobile)
            {
                webDriver?.Manage().Window.Maximize();
                //_extentReportsHelper?.SetStepStatusPass("Browser maximized.");
            }
            return webDriver;
        }


        /// <summary>
        /// Goto
        /// </summary>
        /// <param name="path"></param>
        public void Goto(string path)
        {
            if (GetDriver == null) return;
            GetDriver.Url = Path.Combine(_baseUrl, path);
            //_extentReportsHelper?.SetStepStatusPass($"Browser navigated to the url [{GetDriver.Url}].");
        }

        /// <summary>
        /// Close
        /// </summary>
        public void Close()
        {
            GetDriver?.Quit();
            //_extentReportsHelper?.SetStepStatusPass($"Browser closed.");
        }
    }
}