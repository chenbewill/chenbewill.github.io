using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===無排版===");
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    int number = i * j;
                    Console.Write($"{i}*{j}={number} ");

                }
                Console.WriteLine();
            }

            Console.WriteLine("====正向排版====");
            for(int i=1; i <10; i++) 
            {
                for(int j=1;j<10;j++)
                { 
                    int number = i * j;
                    Console.Write($"{i}*{j}={number}\t");
                                                       
                }
                Console.WriteLine("\r");
            }
            Console.WriteLine("====反向排版====");
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    int number = i * j;
                    Console.Write($"{j}*{i}={number}\t");
                }
                Console.WriteLine("\r");
            }
            Console.ReadLine();
        }
    }
}
