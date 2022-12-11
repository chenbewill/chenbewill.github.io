using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_PrintTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //range，repeat
            Console.WriteLine("請輸入數字");
            int inputNum = int.Parse(Console.ReadLine());
            Version1(inputNum);



            Console.ReadLine();
        }
        static void SharerVersion(int sender)
        {
            int num = sender;
            var numList = Enumerable.Range(1, num).Reverse();
            //String.JOIN 多載
            var rplist =
                numList.Select(
                x => String.Join(null, Enumerable.Repeat(x, num - x + 1))
                );
            Console.WriteLine(String.Join(",", rplist));
            Console.ReadLine();

        }

        static void Version1(int inputNum )
        { 
            
            var stackList = Enumerable.Range(1, inputNum + 1).Reverse().ToList();
            var data2 = stackList.Select((value, index) => Enumerable.Repeat(value, index + 1));
            for (int i = 1; i <= inputNum; i++)
            {
                var num = Enumerable.Repeat(stackList[i], i);
                //foreach (var item in num)
                //{
                //    Console.Write(item);
                //}                
                //Console.WriteLine();
                Console.WriteLine(String.Join(String.Empty, num));//String.Empty==null
            }
        }
        

        
 
    }
}
