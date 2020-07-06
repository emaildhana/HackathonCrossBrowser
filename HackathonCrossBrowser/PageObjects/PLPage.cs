using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonCrossBrowser.PageObjects
{
    public class PLPage
    {
        #region Locators for the web objects in product listing page
        public static string productGridDiv = "//div[@id='product_grid']";
        public static string productListDiv = "//div[@id='product_grid']/div";
        public static string productImageLocator = ".//figure";
        public static string productNameLocator = ".//a/h3";
        public static string productPriceLocator = ".//div[@class='price_box']";
        public static string addToFavoriteLocator = ".//div/ul/li/a[@title='Add to favorites']";
        public static string addToCompareLocator = ".//div/ul/li/a[@title='Add to compare']";
        public static string addToCartLocator = ".//div/ul/li/a[@title='Add to cart']";
        public static string appliAirNightShoeAnchorTagLocator = "//figure[@id='FIGURE____213']/a[contains(@href,'gridHackathonProductDetailsV1.html?id=1')]";

        public static string appliAirNightShoeAnchorTagV2Locator = "//figure/a[contains(@href,'gridHackathonProductDetailsV2.html?id=1')]";


        #endregion

    }

}
