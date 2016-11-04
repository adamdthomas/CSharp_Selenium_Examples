using CSharp_Selenium_Examples.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium_Examples.Core
{
    class WebTable
    {
        // Finds and returns information in a table cell
        public static string FindRecordWithRowCol(int row, int col, PropertyType type, string property)
        {
            try
            {
                IWebElement table = Properties.driver.FindElement(Properties.GetBy(type,property));
                ReadOnlyCollection<IWebElement> allRows = table.FindElements(By.TagName("tr"));
                IWebElement CurRow = allRows[row - 1];
                ReadOnlyCollection<IWebElement> CurCells = CurRow.FindElements(By.TagName("td"));
                IWebElement CurCell = CurCells[col - 1];
                return CurCell.Text;
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
        }
    }
}
