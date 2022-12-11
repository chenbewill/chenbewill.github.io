using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Random random = new Random();
            Console.WriteLine("請輸入最小數字範圍");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入最大數字範圍");
            int max = int.Parse(Console.ReadLine());
            int num = random.Next(min, max+1);
            //int num =new Random().Next(min,max+1);
            int ans;
            do //先執行迴圈才判斷條件,若為T則繼續執行F跳出
            {
                do
                {
                    Console.WriteLine($"請輸入{min}~{max}範圍內數字，答案為{num}");
                    ans = int.Parse(Console.ReadLine());
                }
                while (ans > max || ans < min);
                count++;
                if (ans > num)
                {
                    max = ans;
                }
                else if (ans < num)
                {
                    min = ans;
                }
            }
            while (!(ans == num));
            Console.WriteLine($"答案為{num}，共使用{count}次");
            Console.ReadLine();

            //先使用while 再用if 判斷
        }
    }
    public class Numbers
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int SetNumber { get; set; }
        public int Answer { get; set; }
    }

}
