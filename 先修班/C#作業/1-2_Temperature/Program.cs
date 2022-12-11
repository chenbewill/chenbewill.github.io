using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入華氏溫度");
            float fah = float.Parse(Console.ReadLine());
            float celsius =(fah-32)*5/9 ;
            Console.WriteLine(celsius);
            Console.ReadLine();
        }
    }
}
