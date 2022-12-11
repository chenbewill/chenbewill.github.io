using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyCalculate
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("輸入一個有意義的英文敘述字串");
            string inputStr = "To be or not to be".ToLower();//測試用
            //string inputStr = Console.ReadLine().ToLower();
            string[] strings = inputStr.Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var data =
                from dt in strings
                group dt by dt; //將個體轉為Key
            Dictionary<string, int> diction = new Dictionary<string, int> { };
            //List<List>
            //List<> list = new List<Dictionary<string, int>>();

            foreach(var item in strings)
            {
                //var name = strings.Where(x => x == item);
                var count = strings.Where(x => x == item).Count();
                if (!diction.ContainsKey(item))
                {
                    diction.Add(item, count);
                }

            }
            


            Console.WriteLine(String.Join(Environment.NewLine,data.Select(g=>$"{g.Key}，{g.Count()}")));
            Console.ReadLine();            
        }     
    }

}
