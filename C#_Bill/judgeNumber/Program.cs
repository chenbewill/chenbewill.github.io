using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace judgeNumber
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int input=0;
            try
            {
               Console.WriteLine("input Number");
               input =int.Parse(Console.ReadLine());//Tryparse??
               string result = (input % 2 == 0) ? "偶數" : "奇數";
                //var result = (input % 2 == 0) ? "偶數" : 456;//var 雖然是動態轉換

                //bool result2 = IsOdd(input);
                Console.WriteLine(result);
            }
            catch
            {
                Console.WriteLine("please input number");
            }
            finally 
            {
                Console.WriteLine($"input Number is {input}");
                Console.ReadLine();
            }
         }
        static bool IsOdd(int num) 
        {
            return num % 2 != 0;
        }
    }
}
