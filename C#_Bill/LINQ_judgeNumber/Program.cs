using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_judgeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("請輸入數列");
            //string input = Console.ReadLine();
            Console.WriteLine("2 3 4 5 8 9 10 11 25  12 14");
            string input = "2 3 4 5 8 9 10 11 25  12 14";
            string[] strArray = input.Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            List<string>listOdd =new List<string>();
            List<string>listEven =new List<string>();
            //var data = strArray.Where(x => int.Parse(x) % 2 == 0).OrderBy((x) => int.Parse(x)).Select(x=>x);            
            //foreach (var item in data) 
            //{
            //    listOne.Add(item);
            //}
            //var data2 = strArray.Where(x => int.Parse(x) % 2 != 0).OrderBy((x) => int.Parse(x));
            //foreach (var item in data2)
            //{
            //    listTwo.Add(item);
            //}
            var dataGP = strArray.GroupBy((num) => int.Parse(num) % 2 == 0);
            //listOdd = string.Join("，", dataGP.Select(x => x.Where(n => n == true)));
            Console.WriteLine("偶數列"+String.Join(",", listOdd));
            Console.WriteLine("奇數列"+String.Join(",", listEven));
            Console.ReadLine();
        }
    }
}
