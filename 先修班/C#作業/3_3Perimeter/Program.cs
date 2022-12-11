using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3_1Perimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectganle cal = new Rectganle();
            Console.WriteLine("請出入長度");
            cal.Length =int.Parse( Console.ReadLine());
            Console.WriteLine("請輸入寬度");
            cal.Width = int.Parse(Console.ReadLine());
            Console.Write(cal.Calculate());                 
           Console.ReadLine();
        }
    }
    public class Rectganle
    {
        public int High { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public Rectganle()
        {
            High=1;
            Width=100;
            Length = 100;
        }
        public string Calculate()
        {
            string result = $"長度為{Length}，寬度為{Width}周長為{Perimeter(Length,Width)}，面積為{Area(Length,Width)}";
            return result;
        }
        private string Area(int length,int width) 
        {
            string result = $"{length*width}";
            return result;
        }
        private string Perimeter(int length, int width) 
        {
            string result = $"{length*2+width*2}";
            return result;
        }        
        //方法通常是動詞+行為
    }
        
}
