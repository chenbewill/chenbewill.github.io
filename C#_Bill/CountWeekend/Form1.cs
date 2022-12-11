using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Runtime.InteropServices;

namespace CountWeekend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //noloop
            int input = int.Parse(textBox1.Text);
            int number = TaiwanTurnAC(input);
            Year year = new Year() { InputYear = number };
            GetWeekend(year);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //forloop
            int input = int.Parse(textBox1.Text);
            int number = TaiwanTurnAC(input);
            Year year = new Year() { InputYear = number };
            GetWeekend(year);
        }
        public bool IsLeap(int year)
        {
            bool isLeap = DateTime.IsLeapYear(year) ? true : false;
            return isLeap;
        }
        public string GetFirstDay(int year)
        {
            DateTime dateTime = new DateTime(year, 1, 1);
            string firstDay = dateTime.DayOfWeek.ToString();
            return firstDay;
        }
        public void GetWeekend(Year year)
        {
            bool leap = IsLeap(year.InputYear);
            year.FirstDay = GetFirstDay(year.InputYear);

            if (this.Name == "button2")
            {
                int satdayCounter = 0;
                int sundayCounter = 0;
                #region 助教解法 
                ////不使用迴圈一天一天加
                //DateTime dt = new DateTime(year.InputYear, 1, 1);
                //while (dt < new DateTime(year.InputYear + 1, 1, 1))
                //{
                //    if (dt.DayOfWeek == DayOfWeek.Saturday)
                //    {
                //        satdayCounter++;
                //    }

                //    if (dt.DayOfWeek == DayOfWeek.Sunday)
                //    {
                //        sundayCounter++;
                //    }

                //    dt = dt.AddDays(1);

                //}
                #endregion
                //月份
                for (int i = 0; i < 12; i++)
                {
                    //該月天數
                    int monthDays = DateTime.DaysInMonth(year.InputYear, i);
                    for (int j = 0; j < monthDays; j++)
                    {
                        DateTime datetime = new DateTime(year.InputYear, i, j);
                        string day = datetime.DayOfWeek.ToString();
                        if (day == "Saturday")
                        {
                            satdayCounter++;
                        }
                        else if (day == "Sunday")
                        {
                            sundayCounter++;
                        }
                    }
                }
                year.Sat = satdayCounter;
                year.Sun = sundayCounter;
            }
            else
            {
                switch (year.FirstDay)
                {

                    case "Friday":
                        if (leap)
                        {
                            year.Sat += 1;
                        }
                        break;
                    case "Saturday":
                        year.Sat += 1;
                        if (leap)
                        {
                            year.Sun += 1;
                        }
                        break;
                    case "Sunday":
                        year.Sun += 1;
                        break;
                    default:
                        break;
                }
            }
            label1.Text = $"{year.Sat.ToString()} 個星期六";
            label2.Text = $"{year.Sun.ToString()} 個星期日";
            MessageBox.Show("該月第一天為 : " + year.FirstDay);

        }
        static int TaiwanTurnAC(int input)
        {
            int result = input > 1991 ? input : input + 1991;
            return result;
        }
        static int CalculateDays(int year, DayOfWeek dayOfWeek)
        {
            DateTime firstDay = new DateTime(year, 1, 1);
            int days = 52;
            if (!DateTime.IsLeapYear(year))
            {
                if (firstDay.DayOfWeek == dayOfWeek)
                { 
                    days++; 
                }
            }
            else
            {
                DateTime lastDay = new DateTime(year, 12, 31);
                if (firstDay.DayOfWeek == dayOfWeek || lastDay.DayOfWeek == dayOfWeek)
                {
                    days++;
                }
            }
            return days;
        }
        static int CalculateDaysV2(int year, DayOfWeek dayOfWeek)
        {
            DateTime firstDay = new DateTime(year, 1, 1);
            int days = 52;
            DateTime lastDay = new DateTime(year, 12, 31);
            if (firstDay.DayOfWeek == dayOfWeek || lastDay.DayOfWeek == dayOfWeek)
            {
                days++;
                //若是閏年，最後一天也有可能是該日,因此要計算
            }
            return days;
        }

    }


}
public class Year
{
    public int Sat { get; set; }
    public int Sun { get; set; }
    public int InputYear { get; set; }
    public string FirstDay { get; set; }
    public Year()
    {
        Sat = 52;
        Sun = 52;
    }
}

