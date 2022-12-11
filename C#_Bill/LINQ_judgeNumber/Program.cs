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
            Console.WriteLine("請輸入數列");
            string input=Console.ReadLine();
            string[] strArray = input.Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);





            List<string>listOne =new List<string>();
            List<string>listTwo =new List<string>();
            var data = strArray.Where(x => int.Parse(x) % 2 == 0).OrderBy((x) => int.Parse(x)).Select(x=>x);            
            foreach (var item in data) 
            {
                listOne.Add(item);
            }
            var data2 = strArray.Where(x => int.Parse(x) % 2 != 0).OrderBy((x) => int.Parse(x));
            foreach (var item in data2)
            {
                listTwo.Add(item);
            }
            Console.WriteLine("偶數列"+String.Join(",", listOne));
            Console.WriteLine("奇數列"+String.Join(",", listTwo));
            Console.ReadLine();
        }
    }
}
