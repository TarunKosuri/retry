using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RETRY.Utilities
{
    public class drivers
    {
        public static AppiumDriver<AndroidElement> _driver
        {
            get; set;
        }
    }
}
