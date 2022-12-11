using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeNumber.Model
{
    internal class LifeNum
    {
        //類別呼叫靜態方法 LifeNum.GetLifeData
        public static List<LifeData> GetLifeData()
        {
            var lines = File.ReadLines("生命靈數.txt");
            List<LifeData> dataList = new List<LifeData>() { };
            string constellation = "";
            foreach (string line in lines)
            {
                //處裡空白行
                if (!String.IsNullOrEmpty(line))
                {                   
                    //星座行 特點 &生命靈數文字行 特點，只要沒有空白就是兩者
                    if (line.Contains("】"))
                    {
                        //星座文字 特點 
                        string[] splitLine = line.Split(new string[] { "【", "】" }, StringSplitOptions.RemoveEmptyEntries);
                        constellation = splitLine.First(x => x.Contains("座"));
                    }
                    //生命靈數文字 特點
                    else
                    {
                        string[] splitNum = line.Split('：');
                        LifeData data = new LifeData()
                        {
                            Constellation = constellation,
                            Number = int.Parse(splitNum.First().Last().ToString()),
                            Description = splitNum.Last()
                        };
                        //資料內容分析完加入list
                        dataList.Add(data);
                    };
                }
            }
            return dataList;
        }

       

    }
    public class LifeData
    {
        public string Constellation { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
    }
}
