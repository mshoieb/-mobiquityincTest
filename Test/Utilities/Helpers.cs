using System;
using Test.BaseFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test.Utilities
{
    public class Helpers
    {
        public static IWebElement Wait_Till_Visibility_of_Element(By locator, int timeout)
        {
            var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeout));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

            return element;
        }

        public static string Capture()
        {
            var ts = (ITakesScreenshot)Driver.Browser;
            var screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            var imgName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_FailScreenShot.png";
            var imgPath = projectPath + "Reports\\" + imgName;

            var localpath = new Uri(imgPath).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);

            return imgName;
        }


    }
}
