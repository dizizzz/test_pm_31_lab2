using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.StepDefinitions
{
    public class BaseSteps
    {
        protected static WebDriverWait wait;
        protected static IWebDriver driver;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            driver = new ChromeDriver("D:\\chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Quit();
        }
    }
}
