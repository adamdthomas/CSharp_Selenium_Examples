using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using CSharp_Selenium_Examples.Utilities;
using CSharp_Selenium_Examples.Applications.TheInternetApp;

namespace CSharp_Selenium_Examples.Tests 
{
    [TestFixture]
    public class LeanFtTest1 : BaseTest
    {

        HomePage Home;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
            Properties.driver = new ChromeDriver();
            Properties.driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Home = new HomePage();
        }

        [Test]
        public void NavigationTest()
        {
            Home.Navigate("Checkboxes");
        }

        [Test]
        public void BannerTest()
        {
            Assert.IsTrue(Home.readBanner("Welcome to the Internet"));
        }


        [Test]
        public void TableTest()
        {
            Home.Navigate("Sortable Data Tables");
            Assert.IsTrue(Home.validateTable(2, 2, "John"));
        }
        

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            Properties.driver.Quit();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
