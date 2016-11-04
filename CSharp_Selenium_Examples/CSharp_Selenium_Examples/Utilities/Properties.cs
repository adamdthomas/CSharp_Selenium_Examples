using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Examples.Utilities
{
    enum ProtpertyType
    {
        ID,
        Name,
        LinkText,
        CSSName,
        ClassName
    }

    public class Properties
    {
        public static IWebDriver driver { get; set; }
    }
}
