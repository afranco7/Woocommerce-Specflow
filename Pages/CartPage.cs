using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOOCOMMERCE_SPECFLOW.BrowserActions;

namespace WOOCOMMERCE_SPECFLOW.Pages
{
    class CartPage
    {
        private IWebDriver driver;
        private string baseUrl;
        public CartPage(IWebDriver currentDriver)
        {
            driver = currentDriver;
            baseUrl = "http://34.205.174.166/cart/";
        }

        private readonly By productNameLinkBy = By.XPath("//a[text()='Alejandro']");
        public IWebElement ProductNameLink => driver.FindElement(productNameLinkBy);

        private readonly By productPriceSpanBy = By.XPath("//td[@class='product-price']//span[@class='woocommerce-Price-amount amount']");
        public IWebElement ProductPriceSpan => driver.FindElement(productPriceSpanBy);

        private readonly By productQuantityInputBy = By.XPath("//input[@class='input-text qty text']");
        public IWebElement ProductQuantityInput => driver.FindElement(productQuantityInputBy);

        public bool IsProductShownOnList() 
        {
            return Actions.VerifyElementDisplayed(driver, productNameLinkBy);
        }

        public string GetUrl()
        {
            JavaScriptActions.VerifyPageCompleteStateJs(driver);
            return driver.Url;
        }

        public string GetPriceValue()
        {
            return ProductPriceSpan.Text;
        }

        public string GetCountValue()
        {
            return ProductQuantityInput.GetAttribute("value");
        }
    }
}
