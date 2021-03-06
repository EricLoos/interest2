﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        
        /// <summary>
        /// Library calculate months and days method. The months and days result will allow you to next, accurately calculate interest $.
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="days"></param>
        /// <param name="months"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// Calculate amount paid in interest over months and days. Will be library method. Call Calculate() to get months and days first.
        /// </summary>
        /// <param name="interest"></param>
        /// <param name="amount"></param>
        /// <param name="months"></param>
        /// <param name="days"></param>
        /// <returns></returns>
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
        public DateTime GetEvenStartDate(DateTime stdt, DateTime endt)
        {
            DateTime dt = stdt.Date;
            while (dt.Day != endt.Day)
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

        public double PMT(double MonthlyInterestRate, double nper, double pv)
        {
            double result = 0;
            /*
            DevExpress.Spreadsheet.Functions.IFinancialFunctions fin;
            return fin.Pmt(rate, per, pv);*/
            result = Microsoft.VisualBasic.Financial.Pmt(MonthlyInterestRate, nper, pv);
            if (WeCalcPmt)
            {
                //result = Math.Pow(MonthlyInterestRate * (1 + MonthlyInterestRate), nper) / (Math.Pow(1 + MonthlyInterestRate, nper) - 1) * pv;

                result = (MonthlyInterestRate + (MonthlyInterestRate / (Math.Pow((1 + MonthlyInterestRate), nper) - 1))) * pv;
            }
            result = Round(result);
            if (result > 0)
                result = result * -1;
            return result;
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
            PresentValue = 10000;
            Payment = PMT(interest/12.0, payments, PresentValue);
            Payment = Round(Payment);
            tResult.Text = string.Format("Payment = {0:c}", Payment);
        }

        int payments = 60;
        double interest = 0.12;
        double Payment = 0;
        double PresentValue = 0;
        private void calculatePPMTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pmt = Math.Abs(pmt);
            if (Payment < 0)
            {
                double principal = PPMT(interest/12.0, 1, payments, PresentValue);
                principal = Round(principal);
                tResult.Text = string.Format("Payment = {0:c}; Interest = {1:c}, Principal = {2:c}; Balance = {3:c}", Payment, Payment - principal, principal, PresentValue + principal);
            }
            else
            {
                tResult.Text = "You must do PMT first.";
            }
        }

        private void amortizationScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime StartDate;
            DateTime.TryParse("3/22/17", out StartDate);
            double principal, interestAmt;
            string ln;
            if (Payment < 0)
            {
                string path = @"\\nas4\ark2\_ab HealthcareFinanceDirect\TValue\AmortizationSchedule\sched.csv";
                if (Directory.Exists(Path.GetDirectoryName(path)))
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path))
                    {
                        double Balance = PresentValue;
                        for (int i = 1; i <= payments; i++)
                        { /* Do not use PPMT() since it is off by a few pennies.
                        principal = PPMT(interest / 12.0, i, payments, PresentValue);
                        principal = Round(principal); // Math.Round(principal, 2, MidpointRounding.ToEven);
                        */
                            interestAmt = -Round(Balance * interest / 12.0);
                            principal = Payment - interestAmt;
                            if (i == payments)
                            { // Pay-off
                                principal = -Round(Balance);
                                if (principal < Payment)
                                {
                                    principal = -Balance;
                                    interestAmt = 0;
                                }
                                else
                                    interestAmt = Payment - principal;
                            }
                            Balance += principal;

                            ln = string.Format("{5}, {0:MM/dd/yyyy}, {1:0.00}, {2:0.00}, {3:0.00}, {4:0.00}", StartDate.AddMonths(i), Payment, interestAmt, principal, Balance, i);
                            sw.WriteLine(ln);
                        }
                    }
                    tResult.Text = string.Format("Completed {0} payment(s) to the CSV text file.", payments);
                } 
                else
                {
                    tResult.Text = "The NAS directory does not exist.";
                }
            }
            else
            {
                tResult.Text = "You must do PMT first.";
            }
        }



        public bool WeCalcPmt = true;
        public bool RoundUp = true;
        public double Round(double v)
        {
            if (RoundUp)
            { // Round to the next penny.
                v = Math.Round(v, 2);
            }
            else
            { // Truncate.
                int i = (int)(v * 100);
                v = (double)i / 100.0;
            }
            return v;
        }

        private void randomDates(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DateTime StartDate, EndDate;
            double days, months;
            double pv = 10000;
            double intr = 0.12;
            double InterestAmount;
            string path = @"\\nas4\ark2\_ab HealthcareFinanceDirect\TValue\AmortizationSchedule\random.csv";
            string ln;
            int n = 100;
            if (Directory.Exists(Path.GetDirectoryName(path)))
            {
                using (System.IO.StreamWriter wr = new System.IO.StreamWriter(path))
                {
                    for (int i = 0; i < n; i++)
                    {
                        StartDate = DateTime.Now.Date.AddDays(rnd.Next(100));
                        EndDate = StartDate.AddDays(rnd.Next(365 * 2));
                        Calculate(StartDate, EndDate, out days, out months);
                        InterestAmount = GetInterestAmount(intr, pv, months, days);

                        ln = string.Format("{0}, {1:M/d/yyyy}, {2:M/d/yyyy}, {3}, {4}, {5:0.00}, {6:0.00}, {7:0.00}", i + 1, StartDate, EndDate, (int)months, (int)days, pv, intr, InterestAmount);
                        wr.WriteLine(ln);
                    }
                }
                tResult.Text = string.Format("Completed {0} random dates to CSV text file.", n);
            }
            else
            {
                tResult.Text = "The NAS directory does not exist.";
            }
        }

        private void randomDatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            randomDates(sender, e);
        }
    }
}
