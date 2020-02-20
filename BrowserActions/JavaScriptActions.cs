using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WOOCOMMERCE_SPECFLOW.BrowserActions
{
    public class JavaScriptActions
    {
        public static bool VerifyPageCompleteStateJs(IWebDriver driver, double secondsToWait = 15)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
