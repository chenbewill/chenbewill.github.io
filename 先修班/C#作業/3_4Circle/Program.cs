using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cicle cicle = new Cicle();
            Console.WriteLine("請輸入圓形半徑");
            cicle.Radius = int.Parse(Console.ReadLine());
            double perimeter =double.Parse( cicle.Perimeter());
            double area = double.Parse(cicle.Area());                   
            Console.WriteLine($"圓周長{perimeter}，圓形面積為{area}");
            Console.ReadLine();

        }
    }
    public class Cicle
    {
        private double PI = 3.141592653;
        public int Radius { get; set; }
        /// <summary>
        /// 計算圓周長
        /// </summary>
        /// <returns></returns>
        public string Perimeter()
        {
            double result = Radius * 2 * PI;
            return result.ToString("#.##");
        }
        /// <summary>
        /// 計算圓面積
        /// </summary>
        /// <returns></returns>
        public string Area()
        {
            double result=Radius*Radius*PI;
            return result.ToString("#.##");
        }
    }
}
