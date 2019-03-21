using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace EdgeDriverTest1
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver(options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Url = "https://www.bing.com";

            Assert.AreEqual("Bing", _driver.Title);

            var input = _driver.FindElementById("sb_form_q");
            input.SendKeys("helloworld");
            System.Threading.Thread.Sleep(2000);
           var button= _driver.FindElementById("sb_form_go");
            button.Click();

            System.Threading.Thread.Sleep(10000);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }

    [TestClass]
    public class IEDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private OpenQA.Selenium.IE.InternetExplorerDriver  _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new InternetExplorerOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new InternetExplorerDriver(options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Url = "https://www.bing.com";

            Assert.AreEqual("Bing", _driver.Title);

            var input = _driver.FindElementById("sb_form_q");
            input.SendKeys("helloworld");
            System.Threading.Thread.Sleep(2000);
            var button = _driver.FindElementById("sb_form_go");
            button.Click();

            System.Threading.Thread.Sleep(10000);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
