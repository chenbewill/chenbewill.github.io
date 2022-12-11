using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _7_CalculateNumbers
{
    internal class Program
    {
        //Convent.parse class
        //字串特性..可以使用foreach 但是取出是char

        static void Main(string[] args)
        {
            Console.WriteLine("請輸入數字");
            string num = Console.ReadLine();
            char[] chars = num.ToCharArray();
            int[] result_SwitchLoop = SwitchLoop(chars);
            Console.WriteLine("Switch判斷");
            for (int i = 0; i < result_SwitchLoop.Length; i++)
            {
                Console.WriteLine($"數字{i}出現了{result_SwitchLoop[i]}次");
            }
            Console.WriteLine("For迴圈判斷");
            int[] result = ForLoop(chars);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"數字{i}出現了{result[i]}次");
            }
            Console.ReadLine();
        }
        static int[] ForLoop(char[] data)
        {
            //int[]無法與 char[]進行運算 ，先進行轉化
            int[] arrayInt = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                arrayInt[i] = int.Parse(data[i].ToString());
            }
            int[] template = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = new int[10];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int count = 0;
                    if (arrayInt[i] == template[j])
                    {
                        count += 1;//等效 count = count + 1;
                    }
                    result[j] += count;//等效result[j]=result[j]+count;
                }
            }
            return result;
        }
        static int[] SwitchLoop(char[] data)
        {
            int[] result = new int[10];
            for (int i = 0; i < data.Length; i++)
            {
                switch (int.Parse(data[i].ToString()))
                {
                    case 0:
                        result[0] += 1;
                        break;
                    case 1:
                        result[1] += 1;
                        break;
                    case 2:
                        result[2] += 1;
                        break;
                    case 3:
                        result[3] += 1;
                        break;
                    case 4:
                        result[4] += 1;
                        break;
                    case 5:
                        result[5] += 1;
                        break;
                    case 6:
                        result[6] += 1;
                        break;
                    case 7:
                        result[7] += 1;
                        break;
                    case 8:
                        result[8] += 1;
                        break;
                    case 9:
                        result[9] += 1;
                        break;
                    default:                          
                        break;
                }
            }
            return result;
        }

    }
}
