using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using Configuration = Applitools.Selenium.Configuration;
using IConfiguration = Applitools.Selenium.IConfiguration;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;
using HackathonCrossBrowser.PageObjects;

namespace HackathonCrossBrowser.ModernVisualAIApproachTests
{
    [TestClass]
    public class ModernTestsV2
    {
        private static int concurrentSessions = 7;
        private static string apiKey = "xIWisbt6NECuLEfxj99i7tQD5MTm2fwXlK3X8Xwek578110";
        private static string appliFashionV1URL = "https://demo.applitools.com/gridHackathonV2.html";
        private static string batchName = "UFG Hackathon";

        private static int viewPortWidth = 800;
        private static int viewPortHeight = 600;

        static EyesRunner eyesRunner = null;
        static Configuration suiteConfig;
        private Eyes eyes;
        private IWebDriver webDriver;

        static TestContext _testContext;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext testContext)
        {
            _testContext = testContext;
            eyesRunner = new VisualGridRunner(concurrentSessions);
            suiteConfig = new Configuration();
            suiteConfig
                // Visual Grid configurations
                .AddBrowser(1200, 700, BrowserType.CHROME)
                .AddBrowser(1200, 700, BrowserType.FIREFOX)
                .AddBrowser(1200, 700, BrowserType.EDGE_CHROMIUM)
                .AddBrowser(768, 700, BrowserType.CHROME)
                .AddBrowser(768, 700, BrowserType.FIREFOX)
                .AddBrowser(768, 700, BrowserType.EDGE_CHROMIUM)
                .AddDeviceEmulation(DeviceName.iPhone_X, Applitools.VisualGrid.ScreenOrientation.Portrait)
                .SetApiKey("xIWisbt6NECuLEfxj99i7tQD5MTm2fwXlK3X8Xwek578110")
                .SetServerUrl(appliFashionV1URL)
                .SetBatch(new BatchInfo(batchName))
                .SetViewportSize(new Applitools.Utils.Geometry.RectangleSize(viewPortWidth, viewPortHeight));
        }

        [TestInitialize]
        public void BeforeTestMethod()
        {
            eyes = new Eyes(eyesRunner);
            eyes.SetConfiguration(suiteConfig);
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        [TestMethod]
        public void CrossDeviceElementDisplayTest()
        {
            Configuration testConfig = eyes.GetConfiguration();
            testConfig.SetTestName("Task 1");
            testConfig.SetAppName("Cross Device Elements Test");
            eyes.SetConfiguration(testConfig);
            IWebDriver driver = eyes.Open(webDriver);
            driver.Url = appliFashionV1URL;
            InduceDelay(2);
            eyes.CheckWindow();
        }

        [TestMethod]
        public void ShoppingExperienceTest()
        {
            Configuration testConfig = eyes.GetConfiguration();
            testConfig.SetTestName("Task 2");
            testConfig.SetAppName("Filter Results");
            eyes.SetConfiguration(testConfig);

            IWebDriver driver = eyes.Open(webDriver);
            driver.Url = appliFashionV1URL;

            driver.FindElement(By.XPath(HomePage.blackColorCheckbox)).Click();
            InduceDelay(2);

            driver.FindElement(By.XPath(HomePage.filterButton)).Click();
            InduceDelay(1);
            eyes.Check("Product Grid", Target.Region(By.Id("product_grid")));
        }

        [TestMethod]
        public void ProductDetailsTest()
        {
            Configuration testConfig = eyes.GetConfiguration();
            testConfig.SetTestName("Task 3");
            testConfig.SetAppName("Product Details test");
            eyes.SetConfiguration(testConfig);

            IWebDriver driver = eyes.Open(webDriver);
            driver.Url = appliFashionV1URL;

            driver.FindElement(By.XPath(HomePage.blackColorCheckbox)).Click();
            InduceDelay(2);

            driver.FindElement(By.XPath(HomePage.filterButton)).Click();
            InduceDelay(1);

            driver.FindElement(By.XPath(PLPage.appliAirNightShoeAnchorTagLocator)).Click();
            InduceDelay(2);

            eyes.CheckWindow();
        }

        [TestCleanup]
        public void AfterTestMethod()
        {
            if (_testContext.CurrentTestOutcome.Equals(UnitTestOutcome.Passed))
            {
                eyes.CloseAsync();
            }
            else
            {
                eyes.AbortIfNotClosed();
            }
        }

        public void InduceDelay(double timeValue)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeValue));
        }
    }
}
