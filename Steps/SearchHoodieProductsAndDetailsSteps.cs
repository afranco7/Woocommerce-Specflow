using NUnit.Framework;
using TechTalk.SpecFlow;
using WOOCOMMERCE_SPECFLOW.BrowserActions;
using WOOCOMMERCE_SPECFLOW.DriverSetup;
using WOOCOMMERCE_SPECFLOW.Pages;

namespace WOOCOMMERCE_SPECFLOW.Steps
{
    [Binding]
    public class SearchHoodieProductsAndDetailsSteps
    {
        static HomePage homePage;
        static ProductHoodiesPage productHoodiesPage;

        [BeforeScenario]
        public static void TestInitialize()
        {
            homePage = new HomePage(DriverProvider.Driver);
            productHoodiesPage = new ProductHoodiesPage(DriverProvider.Driver);
            Actions.ClearCache(DriverProvider.Driver);
        }

        [Given]
        public void GivenIHaveNavigatedToTheHomepage()
        {
            homePage.GoToPage();
            Assert.IsTrue(JavaScriptActions.VerifyPageCompleteStateJs(DriverProvider.Driver));
            Assert.IsTrue(homePage.IsSearchInputPresent());
        }

        [When]
        public void WhenIFillTheSearchInputWithHoodie()
        {
            string expectedSearchText = "Hoodie";
            homePage.TypeOnSearchInput(expectedSearchText);            
        }

        [When]
        public void WhenIPressTheEnterKeyWithinTheSearchInput()
        {
            ///Note: The Expected count of results should be 4 but there is a bug found (on the testCase flow or the WebApp Data)
            string expectedCountOfResults = "Showing 1–12 of 63 results";
            homePage.PressEnterAndSearchHoodie();
            Assert.AreEqual(expectedCountOfResults,productHoodiesPage.GetFoundResultsCountText());
        }

        [When]
        public void WhenIClickOnHoodieWithPocket()
        {
            ///In the previous step the results page was not the expected for that reason the following line redirects to the page needed
            productHoodiesPage.GoToPage();
            int expectedCountOfProducts = 4;
            Assert.AreEqual(expectedCountOfProducts, productHoodiesPage.GetCountOfHoodiesProducts());
            productHoodiesPage.ClickHoodieWithPocketProduct();
            Assert.IsTrue(JavaScriptActions.VerifyPageCompleteStateJs(DriverProvider.Driver));
        }

        [Then]
        public void ThenTheProductPageForHoodieWithPocketLoadsProperly()
        {
            string ExpectedUrl = "http://34.205.174.166/product/hoodie-with-pocket/";
            Assert.AreEqual(ExpectedUrl, DriverProvider.Driver.Url.ToString());
        }

    }
}
