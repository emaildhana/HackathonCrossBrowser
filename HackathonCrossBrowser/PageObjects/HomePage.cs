using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonCrossBrowser.PageObjects
{
    public class HomePage
    {
        #region Locators for the web objects in home page
        public static string topMenuList = "//ul[@id='UL____21']";
        //public static string bannerLocator = "//div[@id='DIV__topbanner__187']";
        public static string bannerLocator = "//div[@class='top_banner']";
        public static string wishListIcon = "//a[@class='wishlist']";
        public static string filterPanel = "//div[@class='filter_col']";
        //public static string viewList = "//li[@id='LI____200']";
        public static string viewGrid = "//li//i[@class='ti-view-grid']"; 
            public static string viewList = "//li//i[@class='ti-view-list']";
        public static string blackColorCheckbox = "//input[@id='colors__Black']";
        public static string blackColorCheckBoxInTableMode = "//span[@id='SPAN__checkmark__107']";
        public static string filterButton = "//button[@id='filterBtn']";
        //public static string filtersAnchorInTabletMode = "//a[@id='A__openfilter__206']";
        public static string filtersAnchorInTabletMode = "//li/a[@class='open_filters']";
        public static string searchInputField = "//input[@id='INPUTtext____42']";
        #endregion

        #region Locators for the page footer
        public static string quickLinksHeader = "//h3[text()='Quick Links']";
        public static string aboutUs = "//li/a[contains(@href,'applitools.com/about')]";
        public static string faq = "//li/a[text()='Faq']";
        public static string help = "//li/a[text()='Help']";
        public static string myAccount = "//li/a[contains(@href,'applitools.com/login')]";
        public static string blog = "//li/a[contains(@href,'applitools.com/blog')]";
        public static string contacts = "//li/a[contains(@href,'applitools.com/support')]";

        public static string contactsHeader = "//h3[text()='Contacts']";
        public static string contactsEmailAddress = "//li/a[text()='srd@applitools.com']";
        public static string contactsHomeAddress = "//li[contains(text(),'155 Bovet Rd #600')]";

        public static string keepInTouchSubmitBtn = "//button[@id='submit-newsletter']";
        public static string keepInTouchTextBox = "//input[@id='email_newsletter']";
        public static string keepInTouchHeader = "//h3[text()='Keep in touch']";

        public static string languageLocator = "//div[contains(@class,'styled-select lang-selector')]";
        public static string currencySelectorLocator = "//div[contains(@class,'styled-select currency-selector')]";

        public static string termsAndConditionLocator = "//li/a[text()='Terms and conditions']";
        public static string privacyLocator = "//li/a[text()='Privacy']";
        public static string trademarkLocator = "//li/span[contains(text(), '2020 Applitools')]";

        #endregion
    }
}
