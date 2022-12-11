using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1Rounding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rounding rounding = new Rounding();
            Console.WriteLine("請輸入數字");
            rounding.Number=double.Parse(Console.ReadLine());
            Console.WriteLine("請輸入小數點位數");
            rounding.Location = int.Parse(Console.ReadLine());
            Console.WriteLine(rounding.Calculate());
            Console.ReadLine();
        }
    }
    public class Rounding
    {
        public double Number { get; set; }
        public int Location { get; set; }
        public Rounding ()
        {
            Number = 10;
            Location = 1;
        }
        public string Calculate() 
        {
            string result =$"無條件進位{Ceiling(Number)}\n無條件捨去{Floor(Number)}\n四捨五入到小數點第{Location}位{Round(Number,Location)}"; 
            return result;
        }
        private string Ceiling(double data) 
        {
            string result = $"{Math.Ceiling(data)}";
            return result;
        }
        private string Floor(double data) 
        {
            //Truncate僅計算整數類別
            string result = $"{Math.Floor(data)}";
            return result;
        }
        private string Round(double data, int Location)
        {
            string result = $"{Math.Round(data,Location, MidpointRounding.AwayFromZero)}";
            //使用指定的舍入慣例，將十進位值四捨五入為指定的小數位數。
            return result;
        }


    }

}
