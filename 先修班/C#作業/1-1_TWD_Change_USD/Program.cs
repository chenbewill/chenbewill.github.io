using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWD_Change_USD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入新台幣數值");
            float twd = float.Parse(Console.ReadLine());
            float usd = twd / 28;
            Console.WriteLine(usd);
            Console.ReadLine();
        }
    }
}
