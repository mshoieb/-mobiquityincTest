using Test.BaseFramework;
using Test.PageObjects.LoginPage;
using Test.Utilities;
using NUnit.Framework;

namespace Test.Tests
{
    [TestFixture]
    public class LoginTests:BaseTest
    {
        [Test]
        public void InvalidLoginWithEmptyUsernameAndPassword()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate();
            loginPage.Login("","Test");
            loginPage.Validate().FailureUserLogin();
            loginPage.Login("Test", "");
            loginPage.Validate().FailureUserLogin();

        }


        [Test]
        public void ValidLogin()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate();
       
            loginPage.Login("Luke", "Skywalker");
            loginPage.Validate().CheckUserloggedIn();
            loginPage.Validate().LoggedInUsername();
        }

        [Test]
        public void LoginWithInvalidUsernameAndPassword()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate();

            loginPage.Login("Test", "test");
            var ErrorMessage= loginPage.GetError();
            Assert.AreEqual("Invalid username or password!", ErrorMessage, "Invalid Error Message");
            loginPage.Validate().FailureUserLogin();
        }


        [Test]
        public void InvalidLoginWithEmptyUsernameAndValidPassword()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate();
            loginPage.Login("", "Skywalker");
            loginPage.Validate().FailureUserLogin();

        }
        [Test]
        public void InvalidLoginWithValidUsernameAndEmptyPassword()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate();
            loginPage.Login("Luke", "");
            loginPage.Validate().FailureUserLogin();

        }

    }
}
