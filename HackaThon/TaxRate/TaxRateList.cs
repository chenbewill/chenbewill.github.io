using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxRate
{
    internal  class TaxRateDataList
    {
       public static List<TaxRate> GetTaxRaxList()
        {
            var taxRatesdata = new List<TaxRate>()
            {
            new TaxRate {Income=0m,Rate=0.05m },
            new TaxRate {Income=540000m,Rate=0.12m },
            new TaxRate {Income=1210000m,Rate=0.2m },
            new TaxRate {Income=2420000m,Rate=0.3m },
            new TaxRate {Income=4530000m,Rate=0.4m },
            new TaxRate {Income=10310000,Rate=0.5m }
            };
            return taxRatesdata;
        }

    }
    public class TaxRate
    {
        public decimal Income { get; set; }
        public decimal Rate { get; set; }
    }
}
