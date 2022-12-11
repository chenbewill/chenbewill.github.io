using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Number to bulid Triangle");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("印出三角形");


            for (int i = 0; i < input; i++)
            {
                //for (int j = 0; j <= i; j++)
                //{
                //    Console.Write(input - i);
                //}
                //Console.WriteLine();
                char c = char.Parse((input-i).ToString());
                string str = new string(c, i + 1);
               
                Console.WriteLine(str);


            }
            Console.ReadLine();
        }
    }
}
