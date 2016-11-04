using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;

namespace CSharp_Selenium_Examples.Tests 
{
    [TestFixture]
    public class HeadlessSimpleTest
    {

        IWebDriver driver;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
           
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            driver = new PhantomJSDriver(driverService);
        }

        [Test]
        public void HeadlessTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Cookies.DeleteAllCookies();

            IWebElement searchBar = driver.FindElement(By.Name("q"));
            searchBar.SendKeys("Selenium");

            IWebElement searchBtn = driver.FindElement(By.Name("btnG"));
            searchBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.PartialLinkText("Selenium")));

            var firstResults = driver.FindElements(By.PartialLinkText("Selenium"));
            string firstResultText = firstResults[0].Text;

            Assert.NotNull(firstResultText);
            Assert.IsTrue(firstResultText.Contains("Selenium"));


        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            driver.Quit();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
