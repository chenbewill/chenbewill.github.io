using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入數字列並分隔開來");
            string intputStr = Console.ReadLine();       
            string[] strArray = intputStr.Split(new char[] { ',',' ', '.'},StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("反轉顯示");
            //var reverseResult = strArray.Select(x => int.Parse(x)).Reverse();
            //Console.WriteLine(String.Join(",", reverseResult));
            Console.WriteLine(String.Join(",", intputStr.Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).Select((x) => int.Parse(x)).Reverse()));

            Console.WriteLine("升冪顯示");//冪ㄇ一ˋ
            var oddResult = strArray.ToList().Select(x => int.Parse(x)).OrderBy(x=>x);
            Console.WriteLine(String.Join(",", oddResult));
            Console.WriteLine("降冪顯示");
            var descResult = strArray.ToList().Select(x => int.Parse(x)).OrderByDescending(x=>x);
            Console.WriteLine(String.Join(",", descResult));

            Console.ReadLine();
        }
    }
}
