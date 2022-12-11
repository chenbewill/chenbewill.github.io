using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" 輸入一串以逗號分隔的字串");
            string str = Console.ReadLine();
            string[] strArray = str.Split(',');
            string[] reverseArray=new string[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                reverseArray[i]=strArray[strArray.Length-1-i];
            }
            //Array.Reverse(strArray)
            string result = String.Join(",", reverseArray);
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}
