using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceContent
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int inputNum;
            while (true)
            {                
                Console.WriteLine("請輸入大於90之整數");
                if(int.TryParse(Console.ReadLine(),out inputNum) && inputNum >= 90) 
                {
                    break;
                }
                continue;
            }             
            //修改do while?
            //連續使用三元??
            for (int i = 1; i < inputNum; i++) 
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Dann");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("School");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Build");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
