using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackathonCrossBrowser.PageObjects;
using OpenQA.Selenium.Remote;
using System.IO;
using OpenQA.Selenium;

namespace HackathonCrossBrowser.TraditionalApproachTests
{
    [TestClass]
    public class TraditionalTestsV1 : BaseTests
    {
        static RemoteWebDriver driver;
        static string fileName = "Traditional-V1-TestResults.txt";
        static string appURL = appliFashionV1URL; 

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext testContext)
        {
            Utils.DeleteFile(Path.Combine(Utils.projectFolder, fileName));
        }

        [DataTestMethod()]
        [Description("Test to validate the display of element in laptop mode")]
        [DataRow(BrowserType.Chrome, 1200, 700)]
        [DataRow(BrowserType.FireFox, 1200, 700)]
        [DataRow(BrowserType.Edge, 1200, 700)]
        public void ElementDisplayInLaptopModeTest(BrowserType browserType, int width, int height)
        {
            Console.WriteLine($"Browser type - {browserType}, Width - {width}, Height - {height}");
            string deviceType = "Laptop";
            driver = OpenBrowser(browserType);
            driver.Url = appliFashionV1URL;
            Console.WriteLine(driver.Manage().Window.Size);
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);
            Console.WriteLine(driver.Manage().Window.Size);

            InduceDelay(3); 

            //Display of top menu - Home, Men Women etc
            //Display of banner
            //Display of Search text box
            //Display of Filter panel on the left
            //Display of Wishlist image on top right
            //Display of view mode - grid (or) list mode
            //No Display of Filter symbol

            int i = 1;

            Utils.HackathonReport($"---------- Validation for Cross Device Element in LAPTOP mode starts ---------- ", fileName);

            bool topMenuResult = driver.FindElementByXPath(HomePage.topMenuList).Displayed;
            Utils.HackathonReport(i, "Cross Device Element Test - Display of Top Menu", HomePage.topMenuList, browserType.ToString(), width, height, deviceType, (topMenuResult ? "Pass" : "Fail"), fileName);

            bool searchTextBoxResult = driver.FindElementByXPath(HomePage.searchInputField).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of Search text box", HomePage.searchInputField, browserType.ToString(), width, height, deviceType, (searchTextBoxResult ? "Pass" : "Fail"), fileName);

            bool filterPanelResult = driver.FindElementByXPath(HomePage.filterPanel).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of Filter panel on the left", HomePage.filterPanel, browserType.ToString(), width, height, deviceType, (filterPanelResult ? "Pass" : "Fail"), fileName);

            bool wishlistImageResult = driver.FindElementByXPath(HomePage.wishListIcon).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of Wishlist", HomePage.wishListIcon, browserType.ToString(), width, height, deviceType, (wishlistImageResult ? "Pass" : "Fail"), fileName);

            bool viewListResult = driver.FindElementByXPath(HomePage.viewList).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of View Mode - List", HomePage.viewList, browserType.ToString(), width, height, deviceType, (viewListResult ? "Pass" : "Fail"), fileName);

            bool viewGridResult = driver.FindElementByXPath(HomePage.viewGrid).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of View Mode - Grid", HomePage.viewGrid, browserType.ToString(), width, height, deviceType, (viewGridResult ? "Pass" : "Fail"), fileName);

            bool filterSymbolInTableModeResult = !driver.FindElementByXPath(HomePage.filtersAnchorInTabletMode).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - No Display of Filter symbol", HomePage.filtersAnchorInTabletMode, browserType.ToString(), width, height, deviceType, (filterSymbolInTableModeResult ? "Pass" : "Fail"), fileName);

            bool bannerDisplayResult = driver.FindElementByXPath(HomePage.bannerLocator).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of Banner", HomePage.bannerLocator, browserType.ToString(), width, height, deviceType, (bannerDisplayResult ? "Pass" : "Fail"), fileName);

            FooterValidation(browserType, width, height, deviceType, "Cross Device Element Test", i);

            Utils.HackathonReport($"---------- Validation for Cross Device Element in LAPTOP mode ends ---------- ", fileName);

            Assert.IsTrue(topMenuResult
                && bannerDisplayResult
                && searchTextBoxResult
                && filterPanelResult
                && wishlistImageResult
                && viewListResult
                && viewGridResult
                && filterSymbolInTableModeResult);
        }

        [DataTestMethod()]
        [Description("Test to validate the display of element in tablet mode")]
        [DataRow(BrowserType.Chrome, 768, 700)]
        [DataRow(BrowserType.FireFox, 768, 700)]
        [DataRow(BrowserType.Edge, 768, 700)]
        public void ElementDisplayInTabletModeTest(BrowserType browserType, int width, int height)
        {
            Console.WriteLine($"Browser type - {browserType}, Width - {width}, Height - {height}");
            string deviceType = "Tablet";
            driver = OpenBrowser(browserType);
            driver.Url = appliFashionV1URL;
            Console.WriteLine(driver.Manage().Window.Size);
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);
            Console.WriteLine(driver.Manage().Window.Size);
            InduceDelay(3); 

            //No Display of top menu - Home, Men Women etc
            //Display of banner
            //No Display of Filter panel on the left
            //No Display of Wishlist image on top right
            //No Display of view mode - grid (or) list mode
            //Display of Filter symbol

            int i = 1;

            Utils.HackathonReport($"---------- Validation for Cross Device Element in TABLET mode starts ---------- ", fileName);

            bool topMenuResult = !driver.FindElementByXPath(HomePage.topMenuList).Displayed;
            Utils.HackathonReport(i, "Cross Device Element Test - No Display of Top Menu", HomePage.topMenuList, browserType.ToString(), width, height, deviceType, (topMenuResult ? "Pass" : "Fail"), fileName);

            bool searchTextBoxResult = !driver.FindElementByXPath(HomePage.searchInputField).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - No Display of Search text box", HomePage.searchInputField, browserType.ToString(), width, height, deviceType, (searchTextBoxResult ? "Pass" : "Fail"), fileName);

            bool filterPanelResult = !driver.FindElementByXPath(HomePage.filterPanel).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - No Display of Filter panel on the left", HomePage.filterPanel, browserType.ToString(), width, height, deviceType, (filterPanelResult ? "Pass" : "Fail"), fileName);

            bool wishlistImageResult = !driver.FindElementByXPath(HomePage.wishListIcon).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - No Display of Wishlist", HomePage.wishListIcon, browserType.ToString(), width, height, deviceType, (wishlistImageResult ? "Pass" : "Fail"), fileName);

            bool viewListResult = !driver.FindElementByXPath(HomePage.viewList).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - No Display of View Mode - List", HomePage.viewList, browserType.ToString(), width, height, deviceType, (viewListResult ? "Pass" : "Fail"), fileName);

            bool viewGridResult = !driver.FindElementByXPath(HomePage.viewGrid).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - No Display of View Mode - Grid", HomePage.viewGrid, browserType.ToString(), width, height, deviceType, (viewGridResult ? "Pass" : "Fail"), fileName);

            bool filterSymbolInTableModeResult = driver.FindElementByXPath(HomePage.filtersAnchorInTabletMode).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of Filter symbol", HomePage.filtersAnchorInTabletMode, browserType.ToString(), width, height, deviceType, (filterSymbolInTableModeResult ? "Pass" : "Fail"), fileName);

            bool bannerDisplayResult = driver.FindElementByXPath(HomePage.bannerLocator).Displayed;
            Utils.HackathonReport(i++, "Cross Device Element Test - Display of Banner", HomePage.bannerLocator, browserType.ToString(), width, height, deviceType, (bannerDisplayResult ? "Pass" : "Fail"), fileName);

            FooterValidation(browserType, width, height, deviceType, "Cross Device Element Test", i);

            Utils.HackathonReport($"---------- Validation for Cross Device Element in TABLET mode ends ---------- ", fileName);

            Assert.IsTrue(topMenuResult
                && searchTextBoxResult
                && bannerDisplayResult
                && filterPanelResult
                && wishlistImageResult
                && viewListResult
                && viewGridResult
                && filterSymbolInTableModeResult);
        }

        [DataTestMethod]
        [Description("Test to validate the shopping experience in laptop mode")]
        [DataRow(BrowserType.Chrome, 1200, 700)]
        [DataRow(BrowserType.FireFox, 1200, 700)]
        [DataRow(BrowserType.Edge, 1200, 700)]
        public void ShoppingExperienceInLaptopModeTest(BrowserType browserType, int width, int height)
        {
            Console.WriteLine($"Browser type - {browserType}, Width - {width}, Height - {height}");
            string deviceType = "Laptop";
            driver = OpenBrowser(browserType);
            driver.Url = appliFashionV1URL;
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);
            Console.WriteLine(driver.Manage().Window.Size);
            InduceDelay(3);

            //Click the Black check box in filter panel
            driver.FindElementByXPath(HomePage.blackColorCheckbox).Click();
            InduceDelay(2);
            //Click on Filter button
            driver.FindElementByXPath(HomePage.filterButton).Click();
            InduceDelay(2);

            //Validate two products are displayed
            List<IWebElement> productElements = driver.FindElementsByXPath(PLPage.productListDiv).ToList();
            int numberOfProductsDisplayed = productElements.Count;

            Console.WriteLine($"Number of products displayed - {numberOfProductsDisplayed}");
            bool numberOfProductDisplayedResult;

            if (numberOfProductsDisplayed.Equals(2))
                numberOfProductDisplayedResult = true;
            else
                numberOfProductDisplayedResult = false;
            int taskCount = 1;

            Utils.HackathonReport($"---------- Validation for Shopping Experience task in LAPTOP mode starts ---------- ", fileName);
            Utils.HackathonReport(taskCount, "Shopping Experience Test - Display of two products", PLPage.productListDiv, browserType.ToString(), width, height, deviceType, (numberOfProductDisplayedResult ? "Pass" : "Fail"), fileName);


            if (numberOfProductDisplayedResult)
            {
                ValidateProductListElement(productElements, browserType, width, height, deviceType, taskCount);
            }

            Utils.HackathonReport($"---------- Validation for Shopping Experience task in LAPTOP mode ends ---------- ", fileName);

            //Since multiple objects are checked in this test, please look into the test report file for the validation details. 
            Assert.IsTrue(true, $"Please check the hackathon report for detailed results");
        }

        [DataTestMethod]
        [Description("Test to validate the shopping experience in tablet mode")]
        [DataRow(BrowserType.Chrome, 768, 700)]
        [DataRow(BrowserType.FireFox, 768, 700)]
        [DataRow(BrowserType.Edge, 768, 700)]
        public void ShoppingExperienceInTabletModeTest(BrowserType browserType, int width, int height)
        {
            Console.WriteLine($"Browser type - {browserType}, Width - {width}, Height - {height}");
            string deviceType = "Tablet";
            driver = OpenBrowser(browserType);
            driver.Url = appliFashionV1URL;
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);
            Console.WriteLine(driver.Manage().Window.Size);
            InduceDelay(3);

            //Click on the filter menu
            driver.FindElementByXPath(HomePage.filtersAnchorInTabletMode).Click();
            InduceDelay(2);
            //Click the Black check box in filter panel
            driver.FindElementByXPath(HomePage.blackColorCheckBoxInTableMode).Click();
            InduceDelay(2);
            //Click on Filter button
            driver.FindElementByXPath(HomePage.filterButton).Click();
            InduceDelay(2);

            //Validate two products are displayed
            List<IWebElement> productElements = driver.FindElementsByXPath(PLPage.productListDiv).ToList();
            int numberOfProductsDisplayed = productElements.Count;

            Console.WriteLine($"Number of products displayed - {numberOfProductsDisplayed}");
            bool numberOfProductDisplayedResult;

            if (numberOfProductsDisplayed.Equals(2))
                numberOfProductDisplayedResult = true;
            else
                numberOfProductDisplayedResult = false;
            int taskCount = 1;

            Utils.HackathonReport($"---------- Validation for Shopping Experience task in TABLET mode starts ---------- ", fileName);
            Utils.HackathonReport(taskCount, "Shopping Experience Test - Display of two products", PLPage.productListDiv, browserType.ToString(), width, height, deviceType, (numberOfProductDisplayedResult ? "Pass" : "Fail"), fileName);

            if (numberOfProductDisplayedResult)
            {
                ValidateProductListElement(productElements, browserType, width, height, deviceType, taskCount);
            }

            Utils.HackathonReport($"---------- Validation for Shopping Experience task in TABLET mode ends ---------- ", fileName);

            //Since multiple objects are checked in this test, please look into the test report file for the validation details. 
            Assert.IsTrue(true, $"Please check the hackathon report for detailed results");
        }

        [DataTestMethod]
        [Description("Test to validate the product details page in laptop mode")]
        [DataRow(BrowserType.Chrome, 1200, 700)]
        [DataRow(BrowserType.FireFox, 1200, 700)]
        [DataRow(BrowserType.Edge, 1200, 700)]
        public void ProductDetailsInLaptopModeTest(BrowserType browserType, int width, int height)
        {
            Console.WriteLine($"Browser type - {browserType}, Width - {width}, Height - {height}");
            string deviceType = "Laptop";
            driver = OpenBrowser(browserType);
            driver.Url = appliFashionV1URL;
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);
            Console.WriteLine(driver.Manage().Window.Size);
            InduceDelay(3);

            //Click the Black check box in filter panel
            driver.FindElementByXPath(HomePage.blackColorCheckbox).Click();
            InduceDelay(2);
            //Click on Filter button
            driver.FindElementByXPath(HomePage.filterButton).Click();
            InduceDelay(2);
            //Click on the Appli Air Night shoe
            driver.FindElementByXPath(PLPage.appliAirNightShoeAnchorTagLocator).Click();
            InduceDelay(2);

            Utils.HackathonReport($"---------- Validation for Product Details task in LAPTOP mode starts ---------- ", fileName);

            ValidateProductDetailsPage(browserType, width, height, deviceType);

            Utils.HackathonReport($"---------- Validation for Product Details task in LAPTOP mode ends ---------- ", fileName);

            //Assert.IsTrue(
            //       nameResult
            //    && imageResult
            //    && ratingResult
            //    && descriptionResult
            //    && sizeLabelResult
            //    && sizeDropdownResult
            //    && qtyLabelResult
            //    && qtyIncBtnResult
            //    && qtyDecBtnResult
            //    && addToCartBtnResult
            //    && newPriceResult
            //    && oldPriceResult
            //    && discountResult
            //    );

            //Since multiple objects are checked in this test, please look into the test report file for the validation details. 
            Assert.IsTrue(true, $"Please check the hackathon report for detailed results");
        }

        [DataTestMethod]
        [Description("Test to validate the product details page in tablet mode")]
        [DataRow(BrowserType.Chrome, 1200, 700)]
        [DataRow(BrowserType.FireFox, 1200, 700)]
        [DataRow(BrowserType.Edge, 1200, 700)]
        public void ProductDetailsInTabletModeTest(BrowserType browserType, int width, int height)
        {
            Console.WriteLine($"Browser type - {browserType}, Width - {width}, Height - {height}");
            string deviceType = "Tablet";
            driver = OpenBrowser(browserType);
            driver.Url = appliFashionV1URL;
            driver.Manage().Window.Size = new System.Drawing.Size(width, height);
            Console.WriteLine(driver.Manage().Window.Size);
            InduceDelay(3);

            //Click the Black check box in filter panel
            driver.FindElementByXPath(HomePage.blackColorCheckbox).Click();
            InduceDelay(2);
            //Click on Filter button
            driver.FindElementByXPath(HomePage.filterButton).Click();
            InduceDelay(2);
            //Click on the Appli Air Night shoe
            driver.FindElementByXPath(PLPage.appliAirNightShoeAnchorTagLocator).Click();
            InduceDelay(2);

            Utils.HackathonReport($"---------- Validation for Product Details task in TABLET mode starts ---------- ", fileName);
            ValidateProductDetailsPage(browserType, width, height, deviceType);
            Utils.HackathonReport($"---------- Validation for Product Details task in TABLET mode ends ---------- ", fileName);

            //Assert.IsTrue(
            //       nameResult
            //    && imageResult
            //    && ratingResult
            //    && descriptionResult
            //    && sizeLabelResult
            //    && sizeDropdownResult
            //    && qtyLabelResult
            //    && qtyIncBtnResult
            //    && qtyDecBtnResult
            //    && addToCartBtnResult
            //    && newPriceResult
            //    && oldPriceResult
            //    && discountResult
            //    );

            //Since multiple objects are checked in this test, please look into the test report file for the validation details. 
            Assert.IsTrue(true, $"Please check the hackathon report for detailed results");
        }

        public void ValidateProductDetailsPage(BrowserType browserType, int width, int height, string deviceType)
        {
            //Validate the below points
            //Display of Product Name
            //Display of Product Image
            //Display of Product Rating
            //Display of Product Description
            //Display of Size label and Size dropdown
            //Display of Quantity label, Quantity text box
            //Display of Quantity increment and decrement buttons
            //Display of new price, old price and discount percentage
            //Display of Add to cart button

            int i = 1;

            bool nameResult = driver.FindElementByXPath(PDPage.h1Locator).Displayed;
            Utils.HackathonReport(i, "Product Details Test - Display of Product Name", PDPage.h1Locator, browserType.ToString(), width, height, deviceType, (nameResult ? "Pass" : "Fail"), fileName);

            bool imageResult = driver.FindElementByXPath(PDPage.shoeImageLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Product Image", PDPage.shoeImageLocator, browserType.ToString(), width, height, deviceType, (imageResult ? "Pass" : "Fail"), fileName);

            bool ratingResult = driver.FindElementByXPath(PDPage.ratingLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Product Rating", PDPage.ratingLocator, browserType.ToString(), width, height, deviceType, (ratingResult ? "Pass" : "Fail"), fileName);

            bool descriptionResult = driver.FindElementByXPath(PDPage.productDescriptionLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Product Description", PDPage.productDescriptionLocator, browserType.ToString(), width, height, deviceType, (descriptionResult ? "Pass" : "Fail"), fileName);

            bool sizeLabelResult = driver.FindElementByXPath(PDPage.sizeLabelLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Size label", PDPage.sizeLabelLocator, browserType.ToString(), width, height, deviceType, (sizeLabelResult ? "Pass" : "Fail"), fileName);

            //Click on the dropdown
            driver.FindElementByXPath(PDPage.sizeDropdownLocator).Click();
            bool sizeDropdownResult = driver.FindElementByXPath(PDPage.sizeDropdownListLocator).Displayed;
            driver.FindElementByXPath(PDPage.sizeDropdownLocator).Click();
            Utils.HackathonReport(i++, "Product Details Test - Display of Size Dropdown", PDPage.sizeDropdownListLocator, browserType.ToString(), width, height, deviceType, (sizeDropdownResult ? "Pass" : "Fail"), fileName);

            bool qtyLabelResult = driver.FindElementByXPath(PDPage.quantityLabelLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Quantity Label", PDPage.quantityLabelLocator, browserType.ToString(), width, height, deviceType, (qtyLabelResult ? "Pass" : "Fail"), fileName);

            bool qtyIncBtnResult = driver.FindElementByXPath(PDPage.quantityIncBtnLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Quantity Increment Button", PDPage.quantityLabelLocator, browserType.ToString(), width, height, deviceType, (qtyIncBtnResult ? "Pass" : "Fail"), fileName);

            bool qtyDecBtnResult = driver.FindElementByXPath(PDPage.quantityDecBtnLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Quantity Decrement Button", PDPage.quantityDecBtnLocator, browserType.ToString(), width, height, deviceType, (qtyDecBtnResult ? "Pass" : "Fail"), fileName);

            bool addToCartBtnResult = driver.FindElementByXPath(PDPage.addToCartAnchorLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Add To Cart Button", PDPage.addToCartAnchorLocator, browserType.ToString(), width, height, deviceType, (addToCartBtnResult ? "Pass" : "Fail"), fileName);

            bool newPriceResult = driver.FindElementByXPath(PDPage.newPriceLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of New Price", PDPage.newPriceLocator, browserType.ToString(), width, height, deviceType, (newPriceResult ? "Pass" : "Fail"), fileName);

            bool oldPriceResult = driver.FindElementByXPath(PDPage.oldPriceLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Old Price", PDPage.newPriceLocator, browserType.ToString(), width, height, deviceType, (oldPriceResult ? "Pass" : "Fail"), fileName);

            bool discountResult = driver.FindElementByXPath(PDPage.discountLocator).Displayed;
            Utils.HackathonReport(i++, "Product Details Test - Display of Discount", PDPage.newPriceLocator, browserType.ToString(), width, height, deviceType, (discountResult ? "Pass" : "Fail"), fileName);

            FooterValidation(browserType, width, height, deviceType, "Product Details Test", i); 
        }


        public void ValidateProductListElement(List<IWebElement> productElements, BrowserType browserType, int width, int height, string deviceType, int i)
        {
            bool tempResult;
            IWebElement tempWebElement;
            int prodNumber = 1;
            foreach (var item in productElements)
            {
                //Validate the product image, name and price tag are displayed for both the products
                tempWebElement = item.FindElement(By.XPath(PLPage.productImageLocator));
                tempResult = tempWebElement.Displayed;
                Utils.HackathonReport(i++, $"Shopping Experience Test - Display of image for product - {prodNumber}", tempWebElement.GetAttribute("id"), browserType.ToString(), width, height, deviceType, (tempResult ? "Pass" : "Fail"), fileName);

                tempWebElement = item.FindElement(By.XPath(PLPage.productNameLocator));
                tempResult = tempWebElement.Displayed;
                Utils.HackathonReport(i++, $"Shopping Experience Test - Display of name for product - {prodNumber}", tempWebElement.GetAttribute("id"), browserType.ToString(), width, height, deviceType, (tempResult ? "Pass" : "Fail"), fileName);

                tempWebElement = item.FindElement(By.XPath(PLPage.productPriceLocator));
                tempResult = tempWebElement.Displayed;
                Utils.HackathonReport(i++, $"Shopping Experience Test - Display of price for product - {prodNumber}", tempWebElement.GetAttribute("id"), browserType.ToString(), width, height, deviceType, (tempResult ? "Pass" : "Fail"), fileName);

                //Using actions class to hover the mouse on the product, which will display the add to favorite/cart/compare button
                if(deviceType.Equals("Laptop"))
                {
                    MouseHoverAction(tempWebElement, driver); 
                }

                //Validate the presence of tooltip - Add to Favorites, Add to Cart, Add to compare
                tempWebElement = item.FindElement(By.XPath(PLPage.addToFavoriteLocator));
                tempResult = tempWebElement.Displayed;
                Utils.HackathonReport(i++, $"Shopping Experience Test - Display of Add to favorite tag - {prodNumber}", tempWebElement.GetAttribute("id"), browserType.ToString(), width, height, deviceType, (tempResult ? "Pass" : "Fail"), fileName);

                //Validate the presence of tooltip - Add to Favorites, Add to Cart, Add to compare
                tempWebElement = item.FindElement(By.XPath(PLPage.addToCartLocator));
                tempResult = tempWebElement.Displayed;
                Utils.HackathonReport(i++, $"Shopping Experience Test - Display of Add to cart tag - {prodNumber}", tempWebElement.GetAttribute("id"), browserType.ToString(), width, height, deviceType, (tempResult ? "Pass" : "Fail"), fileName);

                //Validate the presence of tooltip - Add to Favorites, Add to Cart, Add to compare
                tempWebElement = item.FindElement(By.XPath(PLPage.addToCompareLocator));
                tempResult = tempWebElement.Displayed;
                Utils.HackathonReport(i++, $"Shopping Experience Test - Display of Add to compare tag - {prodNumber}", tempWebElement.GetAttribute("id"), browserType.ToString(), width, height, deviceType, (tempResult ? "Pass" : "Fail"), fileName);

                prodNumber++;
            }

            FooterValidation(browserType, width, height, deviceType, "Shopping Experience Test", i);
        }


        public void FooterValidation(BrowserType browserType, int width, int height, string deviceType, string testName, int i)
        {
            Console.WriteLine($"Task count for Footer validation for {testName} is {i}");
            Utils.HackathonReport($"---------- Footer Validation for the test - {testName} in {deviceType} starts ---------- ",fileName); 

            bool quickLinksHdrResult = driver.FindElementByXPath(HomePage.quickLinksHeader).Displayed;
            Utils.HackathonReport(i, $"{testName} - Footer Validation - Display of Quick Links Header", HomePage.quickLinksHeader, browserType.ToString(), width, height, deviceType, (quickLinksHdrResult ? "Pass" : "Fail"), fileName);

            if(deviceType.Equals("Tablet"))
            {
                driver.FindElementByXPath(HomePage.quickLinksHeader).Click(); 
            }
            bool aboutUsResult = driver.FindElementByXPath(HomePage.aboutUs).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of About Us", HomePage.aboutUs, browserType.ToString(), width, height, deviceType, (aboutUsResult ? "Pass" : "Fail"), fileName);

            bool faqResult = driver.FindElementByXPath(HomePage.faq).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of FAQ", HomePage.faq, browserType.ToString(), width, height, deviceType, (faqResult ? "Pass" : "Fail"), fileName);

            bool helpResult = driver.FindElementByXPath(HomePage.help).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Help", HomePage.help, browserType.ToString(), width, height, deviceType, (helpResult ? "Pass" : "Fail"), fileName);

            bool myAccountResult = driver.FindElementByXPath(HomePage.myAccount).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of My Account", HomePage.myAccount, browserType.ToString(), width, height, deviceType, (myAccountResult ? "Pass" : "Fail"), fileName);

            bool blogResult = driver.FindElementByXPath(HomePage.blog).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Blog", HomePage.blog, browserType.ToString(), width, height, deviceType, (blogResult ? "Pass" : "Fail"), fileName);

            bool contactsResult = driver.FindElementByXPath(HomePage.contacts).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Contacts under Quick Links", HomePage.contacts, browserType.ToString(), width, height, deviceType, (contactsResult ? "Pass" : "Fail"), fileName);

            if (deviceType.Equals("Tablet"))
            {
                driver.FindElementByXPath(HomePage.quickLinksHeader).Click();
            }

            InduceDelay(2);

            if (deviceType.Equals("Tablet"))
            {
                driver.FindElementByXPath(HomePage.contactsHeader).Click();
            }

            bool contactHomeAddrResult = driver.FindElementByXPath(HomePage.contactsHomeAddress).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Contacts - Home Address", HomePage.contactsHomeAddress, browserType.ToString(), width, height, deviceType, (contactHomeAddrResult ? "Pass" : "Fail"), fileName);

            bool contactEmailAddrResult = driver.FindElementByXPath(HomePage.contactsEmailAddress).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Contacts - Email Address", HomePage.contactsEmailAddress, browserType.ToString(), width, height, deviceType, (contactEmailAddrResult ? "Pass" : "Fail"), fileName);

            if (deviceType.Equals("Tablet"))
            {
                driver.FindElementByXPath(HomePage.contactsHeader).Click();
            }

            InduceDelay(2);

            if (deviceType.Equals("Tablet"))
            {
                driver.FindElementByXPath(HomePage.keepInTouchHeader).Click();
            }

            bool keepInTouchHdrResult = driver.FindElementByXPath(HomePage.keepInTouchHeader).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Keep In Touch Header", HomePage.keepInTouchHeader, browserType.ToString(), width, height, deviceType, (keepInTouchHdrResult ? "Pass" : "Fail"), fileName);

            bool keepInTouchTxtBoxResult = driver.FindElementByXPath(HomePage.keepInTouchTextBox).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Keep In Touch Textbox", HomePage.keepInTouchTextBox, browserType.ToString(), width, height, deviceType, (keepInTouchTxtBoxResult ? "Pass" : "Fail"), fileName);

            bool keepInTouchSubmitBtnResult = driver.FindElementByXPath(HomePage.keepInTouchSubmitBtn).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Keep In Touch Submit button", HomePage.keepInTouchSubmitBtn, browserType.ToString(), width, height, deviceType, (keepInTouchSubmitBtnResult ? "Pass" : "Fail"), fileName);

            if (deviceType.Equals("Tablet"))
            {
                driver.FindElementByXPath(HomePage.keepInTouchHeader).Click();
            }

            bool langSelectorResult = driver.FindElementByXPath(HomePage.languageLocator).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Language Selector", HomePage.languageLocator, browserType.ToString(), width, height, deviceType, (langSelectorResult ? "Pass" : "Fail"), fileName);

            bool currencySelectorResult = driver.FindElementByXPath(HomePage.currencySelectorLocator).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Currency Selector", HomePage.currencySelectorLocator, browserType.ToString(), width, height, deviceType, (currencySelectorResult ? "Pass" : "Fail"), fileName);

            bool termsAndCondnResult = driver.FindElementByXPath(HomePage.termsAndConditionLocator).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Terms and Conditions", HomePage.termsAndConditionLocator, browserType.ToString(), width, height, deviceType, (termsAndCondnResult ? "Pass" : "Fail"), fileName);

            bool privacyResult = driver.FindElementByXPath(HomePage.privacyLocator).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Privacy", HomePage.privacyLocator, browserType.ToString(), width, height, deviceType, (privacyResult ? "Pass" : "Fail"), fileName);

            bool trademarkResult = driver.FindElementByXPath(HomePage.trademarkLocator).Displayed;
            Utils.HackathonReport(i++, $"{testName} - Footer Validation - Display of Trademark", HomePage.trademarkLocator, browserType.ToString(), width, height, deviceType, (trademarkResult ? "Pass" : "Fail"), fileName);
        }



        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
