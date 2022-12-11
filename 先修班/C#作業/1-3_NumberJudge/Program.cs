using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberJudge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("請輸入整數");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine($"{number}為整數");
            }
            else
            {
                Console.WriteLine($"{number}為奇數");
            }
            Console.ReadLine();
        }
    }
}
