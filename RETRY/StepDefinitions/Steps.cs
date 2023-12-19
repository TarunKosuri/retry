using NUnit.Framework;
using RETRY.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RETRY.StepDefinitions
{
    [Binding]
    public class Steps
    {
        //   private AppiumDriver<AndroidElement>    driver;
        private Demo demo;

        private AllAround allaround;



      
        public Steps()
        {

            demo = new Demo();

            allaround = new AllAround();

        }


        /*[Given(@"Launch the app")]
        public void GivenLaunchTheApp()
        {
            
            demo.demomode();
        }*/

        
        [When(@"when app opens click on No,take me to demo mode")]
        public void WhenWhenAppOpensClickOnNoTakeMeToDemoMode()
        {
            demo.demomode();
        }
     
        [Then(@"click on ok button or else click on yes button")]
        public void ThenClickOnOkButtonOrElseClickOnYesButton()
        {
            demo.popups();

        }


    }
}
