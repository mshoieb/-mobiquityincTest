using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test.BaseFramework
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser;
        protected WebDriverWait BrowserWait;

        public BasePageElementMap()
        {
            Browser = Driver.Browser;
            BrowserWait = Driver.BrowserWait;
        }
    }
}
