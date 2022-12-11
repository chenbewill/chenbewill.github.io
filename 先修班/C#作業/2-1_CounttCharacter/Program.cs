using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_CounttCharacter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入句子");
            string str = Console.ReadLine();
            int count = Calculate(str);
            Console.WriteLine($"{str}內有{count}個單字");
            Console.ReadLine();            
        }
        static int Calculate(string str) 
        {            
            string[] stringStr = str.Split(' ' , ',' , '.' );           

            int result=stringStr.Length;

            return result;
        }
    }
}
