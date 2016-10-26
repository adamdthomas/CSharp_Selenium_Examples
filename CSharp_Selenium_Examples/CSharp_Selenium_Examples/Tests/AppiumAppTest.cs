using System;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;

namespace CSharp_Selenium_Examples
{
    [TestFixture]
    public class AppiumAppTest : UnitTestClassBase
    {

        AndroidDriver<IWebElement> driver;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "LGLS9805e4f920a");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "21");
            capabilities.SetCapability("appPackage", "com.android.calculator2");
            capabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));

        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test]
        public void Test()
        {
            var ac = driver.FindElement(By.Name("All clear"));
            ac.Click();
            var two = driver.FindElement(By.Name("2"));
            two.Click();
            var plus = driver.FindElement(By.Name("Addition"));
            plus.Click();
            var four = driver.FindElement(By.Name("4"));
            four.Click();
            var equalTo = driver.FindElement(By.Name("equal"));
            equalTo.Click();

            var results = driver.FindElement(By.ClassName("com.android.calculator2.CalculatorEditText"));
            string result = results.Text;
            string[] aRes = result.Split(' ');

            Assert.AreEqual("6", aRes[1]);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
              // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
