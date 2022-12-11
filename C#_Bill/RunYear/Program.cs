using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunYear
{
    internal class Program
    {
        //若要判斷年份是否為閏年，請依照下列步驟執行：
        //1.如果年份被 4 整除，則移至步驟 2。 否則，請跳至步驟 5。
        //2.如果年份被 100 整除，則移至步驟 3。 否則，請跳至步驟 4。
        //3.如果年份被 400 整除，則移至步驟 4。 否則，請跳至步驟 5。
        //4.該年份為閏年(有 366 天)。
        //5.該年分不是閏年(有 365 天)。
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入年分");
            int input = int.Parse(Console.ReadLine());
            string result = DateTime.IsLeapYear(input) ? "該年份為閏年" : "該年分不是閏年";
            Console.WriteLine(result);
            Console.ReadLine();



        }


    }
}
