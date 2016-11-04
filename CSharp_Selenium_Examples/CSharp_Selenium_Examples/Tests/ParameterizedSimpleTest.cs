using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium_Examples.Tests 
{
    [TestFixture]
    public class ParameterizedSimpleTest
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
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        [Test]
        public void ParamTest([Values("Selenium", "Test Automation", "Open Source")] string searchTerm)
        {
            

            driver.Manage().Cookies.DeleteAllCookies();

            IWebElement searchBar = driver.FindElement(By.Name("q"));

            searchBar.SendKeys(searchTerm);

            IWebElement searchBtn = driver.FindElement(By.Name("btnG"));
            searchBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.PartialLinkText(searchTerm)));


            var firstResults = driver.FindElements(By.PartialLinkText(searchTerm));
            string firstResultText = firstResults[0].Text;

            Assert.IsTrue(firstResultText.Contains(searchTerm));


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
