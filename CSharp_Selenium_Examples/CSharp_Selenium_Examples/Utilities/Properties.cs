using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Examples.Utilities
{
    public enum PropertyType
    {
        ID,
        Name,
        LinkText,
        CSS,
        XPath,
        ClassName
    }

    public class Properties
    {
        public static IWebDriver driver { get; set; }
        public static int TimeoutInSeconds = 30;

        public static By GetBy(PropertyType type, string property)
        {
            By curBy = null;

            switch (type)
            {

                case PropertyType.ID:
                    curBy = By.Id(property);
                    break;
                case PropertyType.Name:
                    curBy = By.Name(property);
                    break;
                case PropertyType.LinkText:
                    curBy = By.LinkText(property);
                    break;
                case PropertyType.CSS:
                    curBy = By.CssSelector(property);
                    break;
                case PropertyType.XPath:
                    curBy = By.XPath(property);
                    break;
                case PropertyType.ClassName:
                    curBy = By.Id(property);
                    break;
                default:
                    break;
            }

            return curBy;
        }

    }

    
}
