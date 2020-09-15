using KneatAutomationChallenge.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KneatAutomationChallenge.Pages
{
    class HomePage 

    {
        Driver Sel;
        public HomePage(Driver Sel)
        {
            this.Sel = Sel;
        }
      

        By Location = By.XPath("//input[@type='search']");

        By Submit = By.XPath("//button[@type='submit']");

        By RoomsOccupancy = By.XPath("//span[text()='Rooms and occupancy']");


        public void SearchForHotel(string loc)
        {
             Sel.type(loc, Location);
           

        }
       
        public String DateAfterSeveralMonths(int month)
        {
            DateTime ago = DateTime.Now.AddMonths(month);
            string date = ago.Day.ToString();
            return date;
        }
        public String MonthAfterSeveralMonths(int months)
        {
            DateTime ago = DateTime.Now.AddMonths(months);
            string month = ago.ToString("MMMM");
            return month;
        }
        public String MonthYearAfterSeveralMonths(int months)
        {
            DateTime ago = DateTime.Now.AddMonths(months);
            string monthYear = ago.ToString("Y");
            return monthYear;
        }

        public void SubmitButton()
        {
            Sel.click(Submit);
        }

        public void SelectRoomAndPax(string room, string pax)
        {
            Sel.Wait(RoomsOccupancy);

        }
        public void CheckInDate(int months)
        {
            By Checkin = By.XPath("//div[@data-mode='checkin']");
            string Date = DateAfterSeveralMonths(months);
            string monthYear = MonthYearAfterSeveralMonths(months);
         

            Sel.click(Checkin);
            IWebElement dateWidgetFrom = Sel.driver.FindElement(By.XPath("(//table[@class='bui-calendar__dates'])[1]/tbody"));

            //IList<IWebElement> x= driver.FindElements(By.XPath("//div[@class='bui-calendar__month']"));

            int count = 0;

            do
            {
                string month = Sel.driver.FindElement(By.XPath("(//div[@class='bui-calendar__month'])[2]")).Text;

                if (month.Equals(monthYear))
                {
                    By CheckinDate = By.XPath("(//table[@class='bui-calendar__dates'])[2]/tbody/tr/td//span[text()='" + Date + "']");
                    int _date = Int32.Parse(Date);
                    int d = _date + 1;
                    string _day = d.ToString();


                    By CheckOutDate = By.XPath("(//table[@class='bui-calendar__dates'])[2]/tbody/tr/td//span[text()='" + _day + "']");
                  
                    Sel.click(CheckinDate);
                    Sel.click(CheckOutDate);
                    count = 1;
                }
                else
                {
                    Sel.click(By.XPath("//div[@data-bui-ref='calendar-next']"));
                }
            } while (count == 0);
        }

    }
}
