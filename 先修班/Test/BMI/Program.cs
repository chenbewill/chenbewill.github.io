using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入姓名 : ");
            string name = Console.ReadLine();
            Console.Write("請輸入身高 : ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("請輸入體重 : ");
            double weight = float.Parse(Console.ReadLine());
            string str = Bmi(name, height, weight);
            Console.WriteLine(str);
            Console.ReadLine();
        }
        static string Bmi(string name, double height,double weight)
        {
            string result = (weight / (Math.Pow(height / 100, 2))).ToString();
            return result;
        }
    }
}
