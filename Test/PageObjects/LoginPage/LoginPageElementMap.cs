using Test.BaseFramework;
using OpenQA.Selenium;

namespace Test.PageObjects.LoginPage
{
    public class LoginPageElementMap:BasePageElementMap
    {
        public IWebElement UsernameTxtBx => Browser.FindElement(By.CssSelector("#login-form > fieldset:nth-child(1) > label:nth-child(3) > input:nth-child(2)"));
        public IWebElement PasswordTxtBx => Browser.FindElement(By.CssSelector("#login-form > fieldset:nth-child(1) > label:nth-child(4) > input:nth-child(2)"));
        public IWebElement Loginbtn => Browser.FindElement(By.CssSelector("button.main-button"));
        public IWebElement TestErrorTooltip => Browser.FindElement(By.CssSelector("#login-form > fieldset > p.error-message.ng-binding"));
        public string ErrorMsgCssSelector => "#login-form > fieldset > p.error-message.ng-binding.ng-hide";

        public IWebElement ErrorMsg => Browser.FindElement(By.CssSelector(ErrorMsgCssSelector));
        public IWebElement WelcomeMessage => Browser.FindElement(By.XPath(WelcomeMessageXpath));
        public string WelcomeMessageXpath => "//*[@id='greetings']";
    }
}
