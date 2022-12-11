using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2_PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入最大範圍數字");
            int maxRange = int.Parse(Console.ReadLine());
            PrimeNumber primeNumber = new PrimeNumber();
            primeNumber.Max = maxRange;
            Console.WriteLine($"1~{maxRange}內為質數的是");
            primeNumber.Max = maxRange;
            primeNumber.Calculate();
            Console.ReadLine();
        }
    }
    public class PrimeNumber
    {
        public int Max { get; set; }
        public void Calculate()
        {
            //將範圍內數字逐個確定因數個數
            for (int i = 1; i <= this.Max; i++)
            {
                if (CheckNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        private bool CheckNumber(int num)
        {
            bool result = false;
            int count = 0;
            //1可以診除所有診數
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }
        private static bool IsPrime(int number)
        {  
            if (number % 2 == 0 && number != 2) 
            {
                return false;
            }
            //while (number > 2 && number % 2 == 0)  //true
            //{
                
            //    return false;
            //}
            int count = 0;
            for(int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                    if (count > 2)
                    {
                       
                    }
                }
            }

            if (count == 2)
            {
                return true;
            }
            else { return false; }
        }
    }
}

