using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HackathonCrossBrowser.TraditionalApproachTests
{
    public enum BrowserType
    {
        Chrome
        , FireFox
        , Edge
    }

    public class BaseTests
    {
        public static string appliFashionV1URL = "https://demo.applitools.com/gridHackathonV1.html";
        public static string appliFashionV2URL = "https://demo.applitools.com/gridHackathonV2.html";

        public static RemoteWebDriver OpenBrowser(BrowserType browserType)
        {
            {

                switch (browserType)
                {
                    case BrowserType.Chrome:
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--start-maximized");
                        return new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(2));
                    case BrowserType.FireFox:
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.SetPreference("capability.policy.default.Window.frameElement.get", "allAccess"); 
                        return new FirefoxDriver(firefoxOptions);
                    case BrowserType.Edge:
                        EdgeOptions edgeOptions = new EdgeOptions();
                        string edgeWebDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "MicrosoftWebDriver.exe" );  
                        return new EdgeDriver(Directory.GetCurrentDirectory());
                    default:
                        return null;
                }
            }
        }

        public static void InduceDelay(double secondsValue)
        {
            Thread.Sleep(TimeSpan.FromSeconds(secondsValue)); 
        }

        public void MouseHoverAction(IWebElement webElement, RemoteWebDriver remoteWebDriver)
        {
            Actions action = new Actions(remoteWebDriver);
            action.MoveToElement(webElement);
            action.Perform();
        }
    }
}
