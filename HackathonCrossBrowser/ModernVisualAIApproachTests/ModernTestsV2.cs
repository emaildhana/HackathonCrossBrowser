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
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;
using HackathonCrossBrowser.PageObjects;
using System.IO;

namespace HackathonCrossBrowser.ModernVisualAIApproachTests
{
    [TestClass]
    public class ModernTestsV2 
    {
        private static int concurrentSessions = 7;
        private static string appliFashionV1URL = "https://demo.applitools.com/gridHackathonV2.html";
        private static string batchName = "UFG Hackathon";

        static VisualGridRunner runner = new VisualGridRunner(concurrentSessions);
        static Configuration suiteConfig;
        //private static Eyes eyes;
        private IWebDriver webDriver;

        static TestContext _testContext;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext testContext)
        {
            _testContext = testContext;
            suiteConfig = new Configuration();
            suiteConfig.SetApiKey("xIWisbt6NECuLEfxj99i7tQD5MTm2fwXlK3X8Xwek578110");
            suiteConfig.SetBatch(new BatchInfo(batchName));

            // Visual Grid configurations
            suiteConfig.AddBrowser(1200, 700, BrowserType.CHROME);
            suiteConfig.AddBrowser(1200, 700, BrowserType.FIREFOX);
            suiteConfig.AddBrowser(1200, 700, BrowserType.EDGE_CHROMIUM);
            suiteConfig.AddBrowser(768, 700, BrowserType.CHROME);
            suiteConfig.AddBrowser(768, 700, BrowserType.FIREFOX);
            suiteConfig.AddBrowser(768, 700, BrowserType.EDGE_CHROMIUM);
            suiteConfig.AddDeviceEmulation(DeviceName.iPhone_X, Applitools.VisualGrid.ScreenOrientation.Portrait);

            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string eyesLogFile = Path.Combine(projectPath, "eyesLogFile.txt");
            //eyes = new Eyes(runner);
            //eyes.SetConfiguration(suiteConfig);
            //eyes.SetLogHandler(new FileLogHandler(eyesLogFile, true, true));
        }

        [TestInitialize]
        public void BeforeTestMethod()
        {
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            webDriver.Url = appliFashionV1URL;
        }

        [TestMethod]
        public void CrossDeviceElementDisplayTest()
        {
            Eyes eyes = new Eyes(runner);
            eyes.SetConfiguration(suiteConfig);
            eyes.Open(webDriver, "Cross Device Elements Test", "Task 1", new System.Drawing.Size(800, 600));

            InduceDelay(2);
            eyes.CheckWindow();

            eyes.Close();

            eyes.AbortIfNotClosed();
        }

        [TestMethod]
        public void ShoppingExperienceTest()
        {
            Eyes eyes = new Eyes(runner);
            eyes.SetConfiguration(suiteConfig);
            eyes.Open(webDriver, "Filter Results", "Task 2", new System.Drawing.Size(800, 600));

            //Click on the filter menu
            webDriver.FindElement(By.XPath(HomePage.filtersAnchorInTabletMode)).Click();
            InduceDelay(2);
            //Click the Black check box in filter panel
            webDriver.FindElement(By.XPath(HomePage.blackColorCheckBoxInTableMode)).Click();
            InduceDelay(2);
            //Click on Filter button
            webDriver.FindElement(By.XPath(HomePage.filterButton)).Click();
            InduceDelay(2);
            eyes.CheckWindow();
            eyes.Check("Product Grid", Target.Region(By.Id("product_grid")));

            eyes.Close();

            eyes.AbortIfNotClosed();
        }

        [TestMethod]
        public void ProductDetailsTest()
        {
            Eyes eyes = new Eyes(runner);
            eyes.SetConfiguration(suiteConfig);
            eyes.Open(webDriver, "Product Details test", "Task 3", new System.Drawing.Size(800, 600));

            //Click on the filter menu
            webDriver.FindElement(By.XPath(HomePage.filtersAnchorInTabletMode)).Click();
            InduceDelay(2);
            //Click the Black check box in filter panel
            webDriver.FindElement(By.XPath(HomePage.blackColorCheckBoxInTableMode)).Click();
            InduceDelay(2);
            //Click on Filter button
            webDriver.FindElement(By.XPath(HomePage.filterButton)).Click();
            InduceDelay(2);

            //Click on the first shoe image
            webDriver.FindElement(By.XPath(PLPage.appliAirNightShoeAnchorTagV2Locator)).Click();
            InduceDelay(2);

            eyes.CheckWindow();

            eyes.Close();

            eyes.AbortIfNotClosed();
        }

        [TestCleanup]
        public void AfterTestMethod()
        {
            webDriver.Quit();
        }

        public void InduceDelay(double timeValue)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeValue));
        }

    }
}
