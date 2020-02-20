using OpenQA.Selenium;
using WOOCOMMERCE_SPECFLOW.BrowserActions;

namespace WOOCOMMERCE_SPECFLOW.Pages
{
    public class ProductPage
    {
        private IWebDriver driver;
        private string baseUrl;

        public ProductPage(IWebDriver currentDriver)
        {
            driver = currentDriver;
            baseUrl = "http://34.205.174.166/product/alejandro";
        }

        private readonly By productTitleH1By = By.XPath("//h1[@class='product_title entry-title']");
        public IWebElement ProductTitle => driver.FindElement(productTitleH1By);

        private readonly By quantityInputBy = By.Name("quantity");
        public IWebElement QuantityInput => driver.FindElement(quantityInputBy);

        private readonly By addToCartButtonBy = By.Name("add-to-cart");
        public IWebElement AddToCartButton => driver.FindElement(addToCartButtonBy);

        private readonly By woocommerceMessageAlertBy = By.XPath("//div[@class='woocommerce-message']");
        public IWebElement WoocommerceMessageAlert => driver.FindElement(woocommerceMessageAlertBy);

        private readonly By cartIconBy = By.XPath("//div[@class='woocommerce-message']//a[@class='button wc-forward']");
        public IWebElement CartIconForwardButton => WoocommerceMessageAlert.FindElement(cartIconBy);

        private readonly By productPricingBy = By.XPath("//p[@class='price']//span[@class='woocommerce-Price-amount amount']");
        public IWebElement ProductPricing => driver.FindElement(productPricingBy);

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }        

        public bool ProductPricingIsDisplayed()
        {
            return ProductPricing.Displayed;
        }

        public bool ProductTitleIsDisplayed()
        {
            return ProductTitle.Displayed;
        }

        public string GetQuantityInputValue()
        {
            return QuantityInput.GetAttribute("value").ToString();
        }

        public void TypeQuantityInputValue(string input)
        {
            QuantityInput.Clear();
            Actions.Type(QuantityInput, input);
        }

        public void ClickAddToCartButton()
        {
            Actions.ClickOn(driver, AddToCartButton);
        }

        public void ClickOnCartIcon()
        {
            Actions.ClickOn(driver, CartIconForwardButton);
        }

        public string GetWoocommerceMessage()
        {
            return WoocommerceMessageAlert.Text;
        }
    }
}
