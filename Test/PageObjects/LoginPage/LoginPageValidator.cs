using Test.BaseFramework;
using Test.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using Test.PageObjects.LoginPage;

namespace Test.PageObjects.LoginPage
{
    public class LoginPageValidator : BasePageValidator<LoginPageElementMap>
    {
        private readonly LoginPage _loginPage = new LoginPage();

        public void CheckUserloggedIn()
        {
            Thread.Sleep(3000);
            Driver.ImplicitWait();
            Helpers.Wait_Till_Visibility_of_Element(By.XPath(Map.WelcomeMessageXpath), 3);
            string URL = "http://cafetownsend-angular-rails.herokuapp.com/employees";
            Assert.AreEqual(URL, Driver.Browser.Url,"Invalid Login");
        }

        public void FailureUserLogin()
        {
            Thread.Sleep(3000);
            Driver.ImplicitWait();
            Helpers.Wait_Till_Visibility_of_Element(By.XPath(Map.WelcomeMessageXpath), 3);
            string URL = "http://cafetownsend-angular-rails.herokuapp.com/login";
            Assert.AreEqual(URL, Driver.Browser.Url, "Invalid Login");
        }


        public void LoggedInUsername()
        {
            Thread.Sleep(3000);
            Driver.ImplicitWait();
            string WelcomeMessage = "Hello Luke";
            Assert.AreEqual(WelcomeMessage, _loginPage.GetWelcomeMessageText(), "Failed Login");
        }

    }
}
