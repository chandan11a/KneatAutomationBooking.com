using KneatAutomationChallenge.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace KneatAutomationChallenge.Pages
{
    class Driver
    {
         public IWebDriver driver;
        public Driver()
        {

        }
        public void InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Config.BaseUrl);
            driver.Manage().Window.Maximize();


        }
        public void type(String inputText, By locator)
        {
            find(locator).SendKeys(inputText);
        }
        public IWebElement find(By locator)
        {
            return driver.FindElement(locator);
        }
        
        public void Wait(By loc)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(loc));

        }
        public void click(By locator)
        {
            find(locator).Click();
        }

        public String getText(By locator)
        {
            return find(locator).Text;
        }

        public Boolean isDisplayed(By locator)
        {
            try
            {
                return find(locator).Displayed && find(locator).Enabled;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Exception caught: {0}", ex); 
                return false;
            }
        }
        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        public void submit(By locator)
        {
            find(locator).Submit();
        }
    }

}

