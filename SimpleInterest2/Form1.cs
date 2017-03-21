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

            DateTime startdate, enddate;
            if (DateTime.TryParse(tStartDate.Text, out startdate) && DateTime.TryParse(tEndDate.Text, out enddate))
            {
                days = (enddate - startdate).TotalDays;
                bool isSameDay = false;
                if (startdate.Day == enddate.Day)
                    isSameDay = true;
                if (IsLastDayOfMonth(startdate) && IsLastDayOfMonth(enddate))
                {
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
            double amt = 0;
            if (double.TryParse(tAmt.Text, out amt))
            {

            }
            double interest = 0;
            if (double.TryParse(tInterest.Text, out interest))
            {
                interest = interest / 100.0;
            }
            double newAmt = amt * interest / 12.0 * months;
            newAmt += days * amt * interest / DaysPerYear;
            tResult.Text = string.Format("{0} month(s); {1} day(s); Interest = {2:c}; Total = {3:c}", months, days, newAmt, amt + newAmt);
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
    }
}
