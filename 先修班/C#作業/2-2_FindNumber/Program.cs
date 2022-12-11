using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_FindNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入數字");
            string maxNum = Console.ReadLine();
            int[] numbers = Calculate(maxNum);
            int c = 0;
            Console.WriteLine($"\n1 ~ {maxNum} 內非 3 or 5的倍數為");
            for (int i = 0; i < numbers.Length; i++)
            {               
                if (numbers[i] != 0)
                {
                    Console.Write(numbers[i] + "\t");
                    c++;
                    while (c%5==0)
                    {
                        Console.WriteLine();
                        break;
                    }
                }
            }
            Console.ReadLine();
        }
        static int[] Calculate(string data)
        {
            
            int arrayCount = 0;
            int maxNum = int.Parse(data);
            int[] result = new int[maxNum];
            for (int i = 0; i < maxNum; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    result.SetValue(i, arrayCount);
                    arrayCount++;
                }
            }            
            return result;
        }
    }
}
