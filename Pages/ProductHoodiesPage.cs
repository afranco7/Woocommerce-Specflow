using OpenQA.Selenium;
using System.Collections.Generic;
using WOOCOMMERCE_SPECFLOW.BrowserActions;

namespace WOOCOMMERCE_SPECFLOW.Pages
{
    public class ProductHoodiesPage
    {
        private IWebDriver driver;
        private string baseUrl;
        public ProductHoodiesPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "http://34.205.174.166/product-category/hoodies/";
        }

        private readonly By FoundResultsCountBy = By.XPath("//p[@class='woocommerce-result-count']");
        public IWebElement FoundResultsCount => driver.FindElements(FoundResultsCountBy)[0];

        private readonly By HoodieWithPocketBy = By.XPath("//h2[@class='woocommerce-loop-product__title' and text()='Hoodie with Pocket']");
        public IWebElement HoodieWithPocketProduct => driver.FindElement(HoodieWithPocketBy);

        private readonly By HoodiesProductsBy = By.XPath("//ul[@class='products columns-3']/li");
        public IReadOnlyCollection<IWebElement> HoodiesProducts => driver.FindElements(HoodiesProductsBy);

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public string GetFoundResultsCountText()
        {
            return FoundResultsCount.Text;
        }

        public void ClickHoodieWithPocketProduct()
        {
            Actions.ClickOn(driver, HoodieWithPocketProduct);
            JavaScriptActions.VerifyPageCompleteStateJs(driver);
        }

        public int GetCountOfHoodiesProducts()
        {
            return HoodiesProducts.Count;
        }
    }
}
