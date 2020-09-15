using KneatAutomationChallenge.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace KneatAutomationChallenge.Pages
{
    class Filters

    {
        Driver Sel;
        public Filters(Driver Sel)
        {
            this.Sel = Sel;
        }
        By FitnessCenter = By.XPath("//span[contains(text(),'Fitness centre')]");
        By LnkShowAll = By.XPath("//button[@class='collapsed_partly_link collapsed_partly_more']");
        By HotelResults = By.XPath("//div[@class='sr-hotel__title-wrap']/h3/a/span[1]");

        public void ValidateHotelYes(string hotel)
        {
            Thread.Sleep(4000);
            IList<IWebElement> hotels = Sel.driver.FindElements(HotelResults);
            int num = hotels.Count();
            List<string> AllHotel = new List<string>();

            for (int i = 0; i < num; i++)
            {

                string h = hotels.ElementAt(i).Text;
                Console.WriteLine(h);
                AllHotel.Add(h);

            }
            Assert.True(AllHotel.Contains(hotel));

       
        }
        public void ValidateHotelNo(string hotel)
        {
            Thread.Sleep(4000);
            IList<IWebElement> hotels = Sel.driver.FindElements(HotelResults);
            int num = hotels.Count();
            List<string> AllHotel = new List<string>();

            for (int i = 0; i < num; i++)
            {

                string h = hotels.ElementAt(i).Text;
                AllHotel.Add(h);

            }
            
            Assert.False(AllHotel.Contains(hotel));


        }
        public void TOView(IWebElement element)
        {
            Actions actions = new Actions(Sel.driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    public void ShowAll()
        {

            Sel.Wait(LnkShowAll);
            var element = Sel.driver.FindElement(LnkShowAll);
            TOView(element);
            IList<IWebElement> s=Sel.driver.FindElements(LnkShowAll);
            for(int i=0;i<s.Count;i++)
            {
                JavaScriptClick(s.ElementAt(i));
              // s.ElementAt(i).Click();
            }
        }

        public void FilterSaunaUnderFunThingsToDo(string sauna)
        {
            //Sauna
            Thread.Sleep(4000);
            IWebElement Sauna = Sel.driver.FindElement(By.XPath("//a[@data-name='popular_activities']/label/div//span[contains(text(),'"+ sauna + "')]"));
            
            JavaScriptClick(Sauna);
        }

        public void FilterStarRating(string star)
        {
            //5
            By str = By.XPath("//a[@data-name='class']/label/div//span[contains(text(),'"+star+"')]");
            Sel.Wait(str);
            Sel.click(str);
        }
        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Sel.driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
        public void FilterSpaAndWellNessUnderFacilities(string spa)
        {
            //Spa and wellness centre
            By SpaWellNess = By.XPath("//a[@data-name='hotelfacility']/label/div//span[contains(text(),'"+spa+"')]");
            var element = Sel.driver.FindElement(SpaWellNess);
            TOView(element);
            Sel.Wait(SpaWellNess);
            JavaScriptClick(element);
        }
    }
}
