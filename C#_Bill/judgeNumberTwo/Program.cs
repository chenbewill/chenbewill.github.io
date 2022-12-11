using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace judgeNumberTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input Numbers split with ,");
            string input = Console.ReadLine();//converter  converterall
            string[] inputArray = input.Split(',');
            int[] intArray = new int[] { };
            intArray = Array.ConvertAll(inputArray, int.Parse);

            string A = "";
            string B = "";
            //請死背
            //等效 
            //for (int i = 0; i < inputArray.Length; i++)
            //{
            //    intArray[i] = int.Parse(inputArray[i]);
            //}


            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] % 2 == 0)
                    A = A + intArray[i] + ",";
                else
                    B = B + intArray[i] + ",";
            }
            //sol.1
            A = A.Substring(0, A.Length - 1);
            B = B.Substring(0, B.Length - 1);
            //sol.2

            Console.WriteLine($"偶數列 : {A}");
            Console.WriteLine($"奇數列 : {B}");
            Console.ReadLine();
        }
    }
}
