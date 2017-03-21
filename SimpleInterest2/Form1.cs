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
                if (isSameDay)
                {
                    months = enddate.Month - startdate.Month;
                    if (enddate.Year > startdate.Year)
                    {
                        months += (enddate.Year - startdate.Year) * 12;
                    }
                    days = 0;
                }
                else
                {
                    months = enddate.Month - startdate.Month;
                    if (enddate.Year > startdate.Year)
                    {
                        months += (enddate.Year - startdate.Year) * 12;
                    }
                    string sDate = string.Format("{0}/{1}/{2}", enddate.Month, startdate.Day, enddate.Year);
                    DateTime dt;
                    if (DateTime.TryParse(sDate, out dt))
                    {
                        if ((enddate - dt).TotalDays >= 0.5)
                            days = Math.Abs((enddate - dt).TotalDays);
                        else
                        {
                            //MessageBox.Show(string.Format("Date: {0:d};  End Date: {1:d}.", dt, enddate));
                            days = (enddate - startdate).TotalDays;
                            months = enddate.Month - startdate.Month;
                            // CAUTION: Year?
                            if (months <= 1)
                                months = 0;
                            else
                            {
                                months--;
                                sDate = string.Format("{0}/{1}/{2}", startdate.Month+1, enddate.Day, enddate.Year);
                                if (DateTime.TryParse(sDate, out dt))
                                {
                                    days = Math.Abs((startdate - dt).TotalDays);
                                    //days = days + 1.0;
                                }
                            }
                        }
                    }
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
    }
}
