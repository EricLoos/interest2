﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


#region History
/// <summary>
/// 2017-03-22 el: Prepare to move some methods into a library.
/// </summary>
#endregion


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

        // Library calculate months and days method
        public bool Calculate(DateTime startdate, DateTime enddate, out double days, out double months)
        {
            bool result = false;

            days = (enddate - startdate).TotalDays;
            months = 0;
            bool isSameDay = false;
            if (startdate.Day == enddate.Day)
                isSameDay = true; // Both of our dates are the same day of the month.
            if (IsLastDayOfMonth(startdate) && (IsLastDayOfMonth(enddate) || enddate.Day > startdate.Day))
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
                    if (true) // months == 1)
                    {
                        days = DaysFromEndOfMonth(startdate);
                    }
                }
            }
            else if (IsLastDayOfMonth(startdate) || IsLastDayOfMonth(enddate))
            { // Is one of our dates at the end of a month?
                if (IsLastDayOfMonth(enddate))
                {  // Only enddate is end of month
                    days = DaysFromEndOfMonth(startdate);
                    months = enddate.Month - startdate.Month;
                    if (enddate.Year > startdate.Year)
                    {
                        months += (enddate.Year - startdate.Year) * 12;
                    }
                }
                else
                { // Only startdate is end of month
                    DateTime EvenStartDate = GetEvenStartDate(startdate, enddate);
                    days = (EvenStartDate - startdate).TotalDays;
                    months = enddate.Month - startdate.Month;
                    if (enddate.Year > startdate.Year)
                    {
                        months += (enddate.Year - startdate.Year) * 12;
                    }
                    if (startdate.Day > enddate.Day)
                        months--;
                    if (months < 0)
                        months = 0;
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
            result = days > 0.0 || months > 0.0;
            return result;
        }

        // Main form calculate method.
        private void Calculate()
        {
            double months = 0;
            double days = 0;
            int errors = 0;
            string err = "";
            DateTime startdate, enddate;
            if (DateTime.TryParse(tStartDate.Text, out startdate) && DateTime.TryParse(tEndDate.Text, out enddate))
            {
                if (!Calculate(startdate, enddate, out days, out months))
                {
                    err += "Unable to calculate days or months. ";
                    errors++;
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
            /*
            double newAmt = amt * interest / 12.0 * months;
            newAmt += days * amt * interest / DaysPerYear;
            */
            double interestAmount = GetInterestAmount(interest, amt, months, days);
            tResult.Text = string.Format("{0} month(s); {1} day(s); Interest = {2:c}; Total = {3:c}; ( {4} error(s): {5} ) ", months, days, interestAmount, amt + interestAmount, errors, err);
        }
        public double DaysPerYear = 365.0;

        // Calculate amount paid in interest over months and days. Will be library method. Call Calculate() to get months and days first.
        public double GetInterestAmount(double interest, double amount, double months, double days)
        {
            double interestAmount = months * amount * interest / 12.0;
            interestAmount += days * amount * interest / DaysPerYear;
            return interestAmount;
        }

        // Is this date the last day of a month?
        public bool IsLastDayOfMonth(DateTime dt)
        {
            bool result = false;
            if (dt.Month != dt.AddDays(1).Month)
                result = true;
            return result;
        }

        // Find next date that is same day of month as end date's day.
        public DateTime GetEvenStartDate(DateTime stdt,DateTime endt)
        {
            DateTime dt = stdt.Date;
            while(dt.Day!=endt.Day)
            {
                dt = dt.AddDays(1.0);
            }

            return dt;
        }

        // Find number of days from end of the month.
        public int DaysFromEndOfMonth(DateTime dt)
        {
            int r = 0;
            dt = dt.Date;
            while (!IsLastDayOfMonth(dt))
            {
                r++;
                dt = dt.AddDays(1.0);
            }
            return r;
        }

        public double PMT(double rate, double nper, double pv)
        {/*
            DevExpress.Spreadsheet.Functions.IFinancialFunctions fin;
            return fin.Pmt(rate, per, pv);*/
            return Microsoft.VisualBasic.Financial.Pmt(rate, nper, pv);
        }

        public double PPMT(double rate, double per, double nper, double pv)
        {
            return Microsoft.VisualBasic.Financial.PPmt(rate, per, nper, pv);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void calculatePMTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pv = 10000;
            pmt = PMT(0.01, 60, pv);
            tResult.Text = string.Format("Payment = {0:c}", pmt);
        }
        double pmt=0;
        double pv = 0;
        private void calculatePPMTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pmt = Math.Abs(pmt);
            if (pmt < 0)
            {
                double principal = PPMT(0.01, 1, 60, pv);
                tResult.Text = string.Format("Payment = {0:c}; Interest = {1:c}, Principal = {2:c}; Balance = {3:c}", pmt, pmt - principal, principal, pv + principal);
            }
            else
            {
                tResult.Text = "You must do PMT first.";
            }
        }
    }
}
