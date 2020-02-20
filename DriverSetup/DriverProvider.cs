using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WOOCOMMERCE_SPECFLOW.DriverSetup
{
    static class DriverProvider
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                    _driver.Manage().Window.Maximize();
                }

                return _driver;
            }
        }

    }
}
