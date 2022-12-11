using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1_StringReplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入最大數字範圍");
            // Replace replace = new Replace();
            int range = int.Parse(Console.ReadLine());


            Console.WriteLine($"1~{range}內有~~");
            for (int i = 1; i < range; i++)
            {
                //replace.Str = i.ToString();
                Replace.ConvertString(i);
            }
            Console.ReadLine();
        }
    }
    public static class Replace
    {
        //public string Str { get; set; }
        public static void ConvertString(int str)
        {
            Calculate(str);
        }
        private static void Calculate(int num)
        {
            if (num % 2 == 0 && num % 3 == 0)
                Console.WriteLine("金槍魚");
            else if (num % 2 == 0)
                Console.WriteLine("螃蟹");
            else if (num % 3 == 0)
                Console.WriteLine("章魚");
            else
                Console.WriteLine(num);
        }
    }
}
