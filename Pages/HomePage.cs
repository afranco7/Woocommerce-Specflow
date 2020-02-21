using OpenQA.Selenium;
using WOOCOMMERCE_SPECFLOW.BrowserActions;

namespace WOOCOMMERCE_SPECFLOW.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private string baseUrl;

        public HomePage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "http://34.205.174.166/";
        }

        private readonly By searchInputBy = By.Id("woocommerce-product-search-field-0");
        public IWebElement SearchInput => driver.FindElement(searchInputBy);

        public void GoToPage()
        {           
            Actions.GoToPage(driver, baseUrl);            
        }

        public bool IsSearchInputPresent()
        {
            return Actions.VerifyElementDisplayed(driver, searchInputBy);
        }

        public void TypeOnSearchInput(string input)
        {
            SearchInput.Clear();
            Actions.Type(SearchInput, input);
        }

        public string GetTextOfSearchInput()
        {
            return SearchInput.Text;
        }

        public void PressEnterAndSearchHoodie()
        {            
            SearchInput.SendKeys(Keys.Enter);            
        }
    }
}
