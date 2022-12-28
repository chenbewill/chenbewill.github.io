using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8_SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Array.ConvertAll 方法 將陣列轉型 ! 
            // Regax 方法 字串比對!
            //字串比大小是以第一個數字的Unicode來進行比大小 ， 所以要先轉為int 
            

            Console.WriteLine("請輸入數字");
            string input= Console.ReadLine();            
            string[] arrayNum = SortNumber(input);
            int[] arrayInt = new int[arrayNum.Length]; 
            Console.WriteLine("依序顯示結果");
            //字串比大小是以第一個數字的Unicode來進行比大小 ， 所以要先轉為int 
            for (int i = 0; i < arrayNum.Length; i++)
            {
                arrayInt[i] = int.Parse(arrayNum[i]);
            }
            Array.Sort(arrayInt);
            foreach (int num in arrayInt)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine("反序並重組為String");          
            Console.WriteLine(String.Join(",", arrayInt.Reverse()));
            //使用ConvertAll

            Console.WriteLine("使用ConvertAll將strign[]轉為int[]");
            int[] ints = Array.ConvertAll(arrayNum, s => int.Parse(s));
            Console.WriteLine(String.Join(",", ints));

            Console.ReadLine();
        }
        static string[] SortNumber(string str)
        {
            string[] arrayStr = str.Split(new string[] {","," ","." }, StringSplitOptions.RemoveEmptyEntries);           
            return arrayStr;
        }

        static string UsRegex(string str) 
        {

            return null;
        }
    }
}
