using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CSharp_Selenium_Examples.Utilities;
using CSharp_Selenium_Examples.Core;

namespace CSharp_Selenium_Examples.Applications.TheInternetApp
{
    public class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(Properties.driver, this);
            Properties.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Properties.TimeoutInSeconds));
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1")] public IWebElement topBanner { get; set; }

        public Boolean readBanner(string expectedBanner)
        {
            string actualBanner = topBanner.Text;

            return actualBanner == expectedBanner;
        }

        public IWebDriver Navigate(string linkText)
        {
            Properties.driver.FindElement(By.LinkText(linkText)).Click();
            return Properties.driver;
        }

        public bool validateTable(int row, int col, string expectedValue)
        {
            string cellVal = WebTable.FindRecordWithRowCol(row, col, PropertyType.ID, "table1");
            return cellVal == expectedValue;
        }



    }
}
