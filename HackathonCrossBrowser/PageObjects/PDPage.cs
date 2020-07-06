using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonCrossBrowser.PageObjects
{
    public class PDPage
    {
        #region Locator for the web objects in Product Details page
        public static string h1Locator = "//h1[@id='shoe_name']";
        public static string shoeImageLocator = "//div[@id='shoe_img']";
        public static string ratingLocator = "//span[@id='SPAN__rating__76']";
        public static string productDescriptionLocator = "//p[@id='P____83']";
        public static string sizeLabelLocator = "//label[@id='LABEL__colxlcollg__89']";
        public static string sizeDropdownLocator = "//div[@id='DIV__colxlcollg__91']";
        public static string sizeDropdownListLocator = "//div[@id='DIV__customsele__92']/div[contains(@class,'nice-select')]/ul";
        public static string quantityLabelLocator = "//label[@id='LABEL__colxlcollg__99']";
        public static string quantityTextBoxLocator = "//input[@id='quantity_1']";
        public static string quantityIncBtnLocator = "//div[@id='DIV__incbuttoni__104']";
        public static string quantityDecBtnLocator = "//div[@id='DIV__decbuttoni__105']";
        public static string addToCartAnchorLocator = "//a[@id='A__btn__114']";
        public static string newPriceLocator = "//div[@id='DIV__pricemain__108']/span[@id='new_price']";
        public static string oldPriceLocator = "//div[@id='DIV__pricemain__108']/span[@id='old_price']";
        public static string discountLocator = "//div[@id='DIV__pricemain__108']/span[@id='discount']"; 
        #endregion
    }
}
