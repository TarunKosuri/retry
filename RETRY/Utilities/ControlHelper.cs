using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RETRY.Utilities
{
    public class ControlHelper
    {
        public void ButtonClick(By Locator)
        {
            drivers._driver.FindElement(Locator).Click();
        }
    }
}