using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4_Triangle
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("請輸入個位數數字，以建立相對應之倒三角形");
            Triangle triangle = new Triangle()
            {
                input = int.Parse(Console.ReadLine())
            };
            Console.WriteLine("輸出顯示");
            //triangle.CalculateOne();
            triangle.CalculateTWO();

            Console.ReadLine();
        }
    }
    public class Triangle
    {
        public int input { get; set; }
        public void CalculateOne()
        {
            //要補的空白   
            string space = "";
            //印出幾層
            for (int i = input; i > 0; i--)
            {
                //印出幾個
                for (int j = i; j > 0; j--)
                {
                    Console.Write($"{i}");
                }
                space += " ";
                Console.WriteLine();
                if (space.Length < 9)
                {
                    Console.Write($"{space}");
                }
            }
        }

        public void CalculateTWO() 
        {
            for(int i = 0; i < input; i++) 
            {
                for(int s= 0; s<i; s++) 
                {
                    Console.Write(" ");
                }
                for(int n=input; n>i; n--) 
                {
                    Console.Write(input-i);
                }
                Console.WriteLine();
            }           
        }
    }
}

