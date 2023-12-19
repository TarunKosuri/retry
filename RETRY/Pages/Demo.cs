using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using RETRY.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RETRY.Pages
{
    public class Demo
    {
        //private AppiumDriver<AndroidElement> driver;
        private ControlHelper controlHelper;

        public Demo()
        {
            //driver = drivers._driver;
            controlHelper = new ControlHelper(); // Create an instance of ControlHelper
        }

        By clickdemo = By.Id("dk.resound.smart3d:id");
        By yes = By.ClassName("android.view.ViewGroup");
        By ok = By.ClassName("android.widget.TextView");
        public void demomode()
        {
            controlHelper.ButtonClick(clickdemo); // Call the method on the instance
        }

       
        
        public void popups()//used to handle popups
        {
            if (drivers._driver.FindElementByClassName("android.view.ViewGroup").Displayed)
            {
                controlHelper.ButtonClick(yes);
            }
            else
            {
                controlHelper.ButtonClick(ok);
            }
            AndroidElement yess = drivers._driver.FindElement(By.ClassName("android.view.ViewGroup"));
            yess.Click();
        }
    }

}
