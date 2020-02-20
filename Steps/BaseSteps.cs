using TechTalk.SpecFlow;
using WOOCOMMERCE_SPECFLOW.DriverSetup;

namespace WOOCOMMERCE_SPECFLOW.Steps
{
    [Binding]
    class BaseSteps
    {
        [AfterTestRun]
        public static void Cleanup()
        {
            DriverProvider.Driver.Quit();
        }
    }
}
