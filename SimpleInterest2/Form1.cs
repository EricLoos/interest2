using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleInterest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            double months = 0;
            double days = 0;
            int errors = 0;
            string err = "";
            DateTime startdate, enddate;
            if (DateTime.TryParse(tStartDate.Text, out startdate) && DateTime.TryParse(tEndDate.Text, out enddate))
            {
                days = (enddate - startdate).TotalDays;
                bool isSameDay = false;
                if (startdate.Day == enddate.Day)
                    isSameDay = true; // Both of our dates are the same day of the month.
                if (IsLastDayOfMonth(startdate) && IsLastDayOfMonth(enddate))
                {  // Both of our dates are at the end of a month.
                    isSameDay = true;
                }
                if (isSameDay)  // Then calculate based on even months only...
                {  
                    months = enddate.Month - startdate.Month;
                    if (enddate.Year > startdate.Year)
                    {
                        months += (enddate.Year - startdate.Year) * 12;
                    }
                    days = 0;
                    if (IsLastDayOfMonth(enddate))
                    {
                        if (months == 1)
                        {
                            days = DaysFromEndOfMonth(startdate);
                        }
                    }
                }
                else if (IsLastDayOfMonth(startdate) || IsLastDayOfMonth(enddate))
                { // Is one of our dates at the end of a month?
                    if (IsLastDayOfMonth(enddate))
                    {
                        
                    }
                    else
                    {

                    }
                }
                else
                {  // Must get the number of days we are over even months.
                    months = enddate.Month - startdate.Month;
                    if (enddate.Year > startdate.Year)
                    {
                        months += (enddate.Year - startdate.Year) * 12;
                    }
                    if (startdate.Day > enddate.Day)
                        months--;
                    if (months < 0)
                        months = 0;
                    // So, find a new start date that is even with the end date's day.
                    DateTime EvenStartDate = GetEvenStartDate(startdate, enddate);
                    days = (EvenStartDate - startdate).TotalDays;
                }
            }
            else
            {
                err += "Bad start or end date. ";
                errors++;
            }
            days = Math.Round(days);
            months = Math.Round(months);

            double amt = 0;
            if (!double.TryParse(tAmt.Text, out amt))
            {
                err += "Bad amount. ";
                errors++;
            }
            double interest = 0;
            if (double.TryParse(tInterest.Text, out interest))
            {
                interest = interest / 100.0;
            }
            else
            {
                err += "Bad interest entry. ";
                errors++;
            }
            double newAmt = amt * interest / 12.0 * months;
            newAmt += days * amt * interest / DaysPerYear;
            tResult.Text = string.Format("{0} month(s); {1} day(s); Interest = {2:c}; Total = {3:c}; ( {4} error(s): {5} ) ", months, days, newAmt, amt + newAmt, errors, err);
        }
        public double DaysPerYear = 365.0;
        public bool IsLastDayOfMonth(DateTime dt)
        {
            bool result = false;
            if (dt.Month != dt.AddDays(1).Month)
                result = true;
            return result;
        }
        public DateTime GetEvenStartDate(DateTime stdt,DateTime endt)
        {
            DateTime dt = stdt;
            while(dt.Day!=endt.Day)
            {
                dt = dt.AddDays(1.0);
            }

            return dt;
        }

        public int DaysFromEndOfMonth(DateTime dt)
        {
            int r = 0;
            while (!IsLastDayOfMonth(dt))
            {
                r++;
                dt = dt.AddDays(1.0);
            }
            return r;
        }
    }
}
