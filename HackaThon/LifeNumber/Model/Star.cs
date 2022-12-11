using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeNumber.Model
{

    public static class Star
    {
        //類別呼叫靜態方法 Star.GetStars();
        public static List<StarData> GetStars(int year)
        {
            return new List<StarData>
            {
                new StarData(){ ConsName="摩羯座" ,StartDay=new DateTime(year ,1,1),EndDay=new DateTime(year,1,20) },
                new StarData(){ ConsName="水瓶座" ,StartDay=new DateTime(year ,1,21),EndDay=new DateTime(year,2,19)},
                new StarData(){ ConsName="雙魚座" ,StartDay=new DateTime(year ,2,20),EndDay=new DateTime(year,3,20)},
                new StarData(){ ConsName="牡羊座" ,StartDay=new DateTime(year ,3,21),EndDay=new DateTime(year,4,20)},
                new StarData(){ ConsName="金牛座" ,StartDay=new DateTime(year ,4,21),EndDay=new DateTime(year,5,21)},
                new StarData(){ ConsName="雙子座" ,StartDay=new DateTime(year ,5,22),EndDay=new DateTime(year,6,21)},
                new StarData(){ ConsName="巨蟹座" ,StartDay=new DateTime(year ,6,22),EndDay=new DateTime(year,7,22)},
                new StarData(){ ConsName="獅子座" ,StartDay=new DateTime(year ,7,23),EndDay=new DateTime(year,8,23)},
                new StarData(){ ConsName="處女座" ,StartDay=new DateTime(year ,8,24),EndDay=new DateTime(year,9,23)},
                new StarData(){ ConsName="天秤座" ,StartDay=new DateTime(year ,9,24),EndDay=new DateTime(year,10,23)},
                new StarData(){ ConsName="天蠍座" ,StartDay=new DateTime(year ,10,24),EndDay=new DateTime(year,11,22)},
                new StarData(){ ConsName="射手座" ,StartDay=new DateTime(year ,11,23),EndDay=new DateTime(year,12,21)},
                new StarData(){ ConsName="摩羯座" ,StartDay=new DateTime(year ,12,22),EndDay=new DateTime(year,12,31)},
            };
        }
    }
    public class StarData
    {
        public string ConsName { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}
