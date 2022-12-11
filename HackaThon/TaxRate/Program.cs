using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxRate
{
    internal class Program
    {
        private static List<TaxExample> levels = new List<TaxExample>
        {
            new TaxExample(){Money=540000m,Rate=0.05m},
            new TaxExample(){Money=1210000m,Rate=0.12m},
            new TaxExample(){Money=2420000m,Rate=0.2m},
            new TaxExample(){Money=4530000m,Rate=0.3m},
            new TaxExample(){Money=10310000m,Rate=0.4m},
            new TaxExample(){Money=decimal.MaxValue,Rate=0.5m}
        };
        //        年收入 0         ~    540,000 : 5%
        //        年收入 540,001   ~  1,210,000 : 12%==37800   (540,000*(12%-5%))
        //        年收入 1,210,001 ~  2,420,000 : 20%==134600  (1210000*(20%-12*)
        //        年收入 2,420,001 ~  4,530,000 : 30%==376600
        //        年收入 4,530,001 ~ 10,310,000 : 40%==829600
        //        年收入 10,310,001~            : 50%==1860600
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入年收入");
            decimal money = decimal.Parse(Console.ReadLine());
            decimal rate = GetTaxRate1(money);

            //測試用
            List<decimal> temp = new List<decimal>
            {
                 100000,
                 540000,
                 540001,
                 1210000,
                 1218000,
                 2420000,
                 2500000,
                 4530000,
                 5530000,
                 10310000,
                 10710000
            };
            for (int i = 0; i < temp.Count; i++)
            {
                rate = GetTaxRate1(temp[i]);
                //rate = GetTaxRateExamples(temp[i]);
                Console.WriteLine($"收入為{temp[i]}，稅金為${rate:#,#.##}");

            }
            //Console.WriteLine($"${rate:#,#.##}");

            Console.ReadLine();
        }

        static decimal GetTaxRate1(decimal money)
        {
            decimal result;
            if (money >= 10310001m)
            {
                result = money * 0.5m - 1860600m;
                return result;
            }
            else if (money >= 4530001m)
            {
                result = money * 0.4m - 829600m;

                return result;
            }
            else if (money >= 2420001m)
            {
                result = money * 0.3m - 376600;

                return result;
            }
            else if (money >= 1210001m)
            {
                result = money * 0.2m - 134600m;

                return result;
            }
            else if (money >= 540001m)
            {
                result = money * 0.12m - 37800m;

                return result;
            }
            else
            {
                result = money * 0.05m;
                return result;
            }
        }
        //助教寫法
        static void GetTaxRateExamples(decimal input)
        {
            var money = input;
            var target = levels.Take(levels
                .IndexOf(levels
                .First(x => money - x.Money <= 0)));            
        }
        static void GetTaxRate3( decimal input) 
        {
            var _taxRateList = TaxRateDataList.GetTaxRaxList();
            


        }

    }


    class TaxExample
    {
        public decimal Money { get; set; }
        public decimal Rate { get; set; }
    }
}
