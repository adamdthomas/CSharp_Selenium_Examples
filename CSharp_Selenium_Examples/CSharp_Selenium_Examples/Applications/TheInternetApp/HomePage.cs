using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CSharp_Selenium_Examples.Utilities;

namespace CSharp_Selenium_Examples.Applications.TheInternetApp
{
    class HomePage
    {
      
        HomePage()
        {
            PageFactory.InitElements(Properties.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/h1")] public IWebElement topBanner { get; set; }

        public Boolean readBanner(string expectedBanner)
        {
            string actualBanner = topBanner.Text;

            return actualBanner == expectedBanner;
        }



    }
}
