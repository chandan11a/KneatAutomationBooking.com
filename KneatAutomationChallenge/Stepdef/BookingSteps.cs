using OpenQA.Selenium;
using KneatAutomationChallenge.Pages;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace KneatAutomationChallenge.Stepdef
{
    [Binding, Parallelizable]
    public class BookingSteps 
    {
        Driver Sel=null;
        [TearDown]
        public void close_Browser()
        {
            Sel.driver.Quit();
        }

        [When(@"Traveler searches to Book Hotel in '(.*)'")]
        public void WhenTravelerSearchesToBookHotelIn(string p0)
        {
            HomePage page = new HomePage(Sel);

            page.SearchForHotel(p0);
        }

        [Then(@"Traveler selects the Date after '(.*)' Months along with number of person with room and make a Search")]
        public void ThenTravelerSelectsTheDateAfterMonthsAlongWithNumberOfPersonWithRoomAndMakeASearch(int p0)
        {
            HomePage page = new HomePage(Sel);
            
            page.CheckInDate(p0);
            page.SelectRoomAndPax("1","2");
            page.SubmitButton();
          
        }

        [Given(@"Traveler wants to Book Hotel")]
        public void GivenTravelerwantsToBookHotel()
        {
            Sel = new Driver();
            Sel.InitializeDriver();

        }
       
        [Then(@"Traveler Filters by '(.*)' and Validate Results '(.*)' with result as '(.*)'")]
        public void ThenTravelerFiltersByAndValidateResults(string p0, string p1,string p2)
        {
            if(p0.Contains("Sauna"))
            {
                Filters page = new Filters(Sel);
                page.ShowAll();
                page.FilterSpaAndWellNessUnderFacilities("Spa");
                page.FilterSaunaUnderFunThingsToDo(p0);
                if (p2.Contains("passed"))
                { page.ValidateHotelYes(p1); }
                else
                {
                    page.ValidateHotelNo(p1);
                }
            }
            else
            {
                Filters page = new Filters(Sel);
                page.ShowAll();
                page.FilterStarRating(p0);
                if (p2.Contains("passed")) { page.ValidateHotelYes(p1); } else { page.ValidateHotelNo(p1); }
               
                

            }
           
            


        }

    }
}
