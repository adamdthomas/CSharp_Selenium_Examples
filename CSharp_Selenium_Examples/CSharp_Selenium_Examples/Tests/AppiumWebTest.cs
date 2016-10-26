using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;

namespace CSharp_Selenium_Examples
{
    [TestFixture]
    public class AppiumWebTest : UnitTestClassBase
    {

        IWebDriver driver;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("browserName", "chrome");
            capabilities.SetCapability("deviceName", "LGLS9805e4f920a");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "21");

            driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));

        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test]
        public void Test()
        {

            driver.Navigate().GoToUrl("http://www.google.com");
            Assert.IsTrue(driver.Title.Equals("Google"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
           //driver.Close();
           // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
