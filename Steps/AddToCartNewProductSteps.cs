using NUnit.Framework;
using TechTalk.SpecFlow;
using WOOCOMMERCE_SPECFLOW.Api.Provider;
using WOOCOMMERCE_SPECFLOW.BrowserActions;
using WOOCOMMERCE_SPECFLOW.DriverSetup;
using WOOCOMMERCE_SPECFLOW.Pages;

namespace WOOCOMMERCE_SPECFLOW.Steps
{
    [Binding]
    class AddToCartNewProductSteps
    {
        static ProductPage productPage;
        static CartPage cartPage;
        static ProductProvider product = new ProductProvider();
        static string id;

        [BeforeScenario]
        public static void TestInitialize()
        {            
            productPage = new ProductPage(DriverProvider.Driver);
            cartPage = new CartPage(DriverProvider.Driver);           
        }

        [AfterScenario]
        public static void DeleteProduct()
        {
            Assert.IsTrue(product.DeleteProduct(id));           
        }

        [Given]
        public void GivenIHaveCreatedAProductInTheShoppingSiteViaAPI()
        {
            id = product.CreateProductAlejandro();
        }

        [When]
        public void WhenINavigateToThePageOfTheCreatedProduct()
        {
            productPage.GoToPage();
            Assert.IsTrue(JavaScriptActions.VerifyPageCompleteStateJs(DriverProvider.Driver),"Page is not loaded properly");
            Assert.IsTrue(productPage.ProductTitleIsDisplayed(), "The product Title is not displayed");
            Assert.IsTrue(productPage.ProductPricingIsDisplayed(), "Product pricing is not displayed");
        }

        [When(@"I increase the quantity number to (.*)")]
        public void WhenIIncreaseTheQuantityNumberTo_P0(string number)
        {
            string expectedNumber = "7";
            productPage.TypeQuantityInputValue(number);
            Assert.AreEqual(expectedNumber, productPage.GetQuantityInputValue());
        }

        [When]
        public void WhenIClickAddToCartButton()
        {
            productPage.ClickAddToCartButton();
            Assert.AreEqual("View cart\r\n7 × “Alejandro” have been added to your cart.", productPage.GetWoocommerceMessage());
        }

        [When]
        public void WhenIClickOnTheCartIcon()
        {            
            productPage.ClickOnCartIcon();            
        }

        [Then]
        public void ThenIVerifyThatTheUserNavigatesToCartPage()
        {
            string expectedUrl = "http://34.205.174.166/cart/";
            Assert.AreEqual(expectedUrl, cartPage.GetUrl());
        }

        [Then]
        public void ThenIValidateThatTheProductShowsInTheList()
        {
            Assert.IsTrue(cartPage.IsProductShownOnList());
        }

        [Then]
        public void ThenIValidateThatThePriceAndCountAreCorrect()
        {
            Assert.AreEqual("$21.99", cartPage.GetPriceValue());
            Assert.AreEqual("7", cartPage.GetCountValue());
        }

    }
}
