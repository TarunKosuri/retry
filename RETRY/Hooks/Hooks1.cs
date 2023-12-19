using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using BoDi;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using RETRY.Utilities;
using System.Net.Sockets;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using System.Net.Http;

namespace RETRY.Hooks
{
    [Binding]
    public sealed class Hooks1 : ExtentReport
    {


       
        private static AppiumLocalService _appiumLocalService;//line declares a private static variable named _appiumLocalService of type AppiumLocalService,static keyword means that this variable is shared among all instances of the class
        private AppiumDriver<AndroidElement> driver;//line declares a private variable nameed driver of type appiumdriver<AndroidElement>
        private readonly IObjectContainer _container;//declares a private field named _container of type IObjectContainer
        /*
         It represents a container for managing and sharing instances of objects
         or dependencies across different parts of your application. In the provided code,
         it's used to share objects (specifically, the AppiumDriver<AndroidElement>) between different SpecFlow scenarios.
        */
        public Hooks1(IObjectContainer container)//iobject container allows sharing of objects within specflow scenarios ,Constructor for the "Hooks1" class which takes an "IObjectContainer" parameter
        {
            _container = container;//initializing the container variable
        }
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            StartAppiumServer();//line calls the "StartAppiumServer" method to start the Appium server
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("platformName", "Android");
            //appiumOptions.AddAdditionalCapability("deviceName", "OnePlus 9R");
            //appiumOptions.AddAdditionalCapability("platform Version", "12");
            appiumOptions.AddAdditionalCapability("udid", "RZ8R30NVQCF");
            appiumOptions.AddAdditionalCapability("Appium Server Address", "127.0.0.1:4723");
            appiumOptions.AddAdditionalCapability("app", "C:\\Users\\iray3\\Desktop\\apk\\dk.resound.smart3d-Signed.apk");
            appiumOptions.AddAdditionalCapability("appPackage", "dk.resound.smart3d");
            var httpClient = new HttpClient();//line creates a new instance of HttpClient,which can be used for making HTTP requests
            httpClient.Timeout = TimeSpan.FromSeconds(120);// line sets the timeout for the HTTP client to 120 seconds.
            /*
            The CommandExecutor is a component in the Appium framework 
            that handles the communication between your test script and the Appium server. 
            CommandExecutor is a interface for handling HTTP requests.
            It communicates with the Appium server via HTTP using the specified URI (Uniform Resource Identifier) and timeout settings.
            */
            var commandExecutor = new HttpCommandExecutor(new Uri("http://localhost:4723/wd/hub"), TimeSpan.FromSeconds(180));// creates a new instance of the "AndroidDriver" class with the specified command executor and Appium options
            driver = new AndroidDriver<AndroidElement>(commandExecutor, appiumOptions);
            _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driver);//This allows other parts of the code to access and use the registered driver instance 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            drivers._driver = driver;
            
        }

        private void StartAppiumServer()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingPort(4723).Build();
            _appiumLocalService.Start();
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
      
        
    }
}