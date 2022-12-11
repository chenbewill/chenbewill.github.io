using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //影片資料集合
            List<Video> videoList = new List<Video>() {
                new Video()
                {
                    Name = "天竺鼠車車",
                    Country = "日本",
                    Duration = 2.6,
                    Type = "動漫"
                },
                new Video() { Name = "鬼滅之刃", Country = "日本", Duration = 25, Type = "動漫" },
                new Video() { Name = "鬼滅之刃-無限列車", Country = "日本", Duration = 100, Type = "電影" },
                new Video() { Name = "甜蜜家園SweetHome", Country = "韓國", Duration = 50, Type = "影集" },
                new Video() { Name = "The 100 地球百子", Country = "歐美", Duration = 48, Type = "影集" },
                new Video() { Name = "冰與火之歌Game of thrones", Country = "歐美", Duration = 60, Type = "影集" },
                new Video() { Name = "半澤直樹", Country = "日本", Duration = 40, Type = "影集" },
                new Video() { Name = "古魯家族：新石代", Country = "歐美", Duration = 90, Type = "電影" },
                new Video() { Name = "角落小夥伴電影版：魔法繪本裡的新朋友", Country = "日本", Duration = 77, Type = "電影" },
                new Video() { Name = "TENET天能", Country = "歐美", Duration = 80, Type = "電影" },
                new Video() { Name = "倚天屠龍記2019", Country = "中國", Duration = 58, Type = "影集" },
                new Video() { Name = "下一站是幸福", Country = "中國", Duration = 45, Type = "影集" },
            };
            //人物資料集合
            List<Person> personList = new List<Person>()
            {
                new Person()
                {
                    CountryPrefer = new List<string>()
                    {
                        "中國",
                        "日本"
                    },
                    Name = "Bill",
                    TypePrefer = new List<string>() { "影集" }
                },
                new Person() { Name = "Jimmy", CountryPrefer = new List<string>() { "日本" }, TypePrefer = new List<string>() { "動漫", "電影" } },
                new Person() { Name = "Andy", CountryPrefer = new List<string>() { "歐美", "日本" }, TypePrefer = new List<string>() { "影集", "電影" } },
            };


            // 1. 找出所有日本的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q1: 找出所有日本的影片名稱");


            #region Method Expression + Console.Write 合併前
            //var data = videoList.Where(x => x.Country == "日本").Select(x => x.Name).ToList();
            //Console.WriteLine(String.Join(",",data));
            #endregion
            Console.WriteLine(String.Join("，", videoList.Where(x => x.Country == "日本").Select(x => x.Name)));//Join(String, IEnumerable<String>)多載

            // 2. 找出所有歐美的影片且類型為"影集"的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q2: 找出所有歐美的影片且類型為'影集'的影片名稱");
            #region Query Expression
            //var items =
            //    from data in videoList
            //    where data.Country == "歐美" && data.Type == "影集"
            //    select data.Name;       
            //Console.WriteLine(String.Join("，",items));
            #endregion
            //Method Exprssion
            Console.WriteLine(String.Join("，", videoList.Where(x => x.Type == "影集" && x.Country == "歐美").Select(x => x.Name)));

            // 3. 是否有影片片長超過120分鐘的影片
            Console.WriteLine($"{Environment.NewLine}Q3: 是否有影片片長超過120分鐘的影片");
            //Console.WriteLine(String.Join("，",from data in videoList where data.Duration>120 select data.Name));//Query Expression  答案為null不行一行寫完
            //IEnueramble  判斷null (問助教)  使用NULL

            var data3 = videoList.Where(condition => condition.Duration >= 120).FirstOrDefault();
            //if (data.Count != 0)
            //    Console.WriteLine(String.Join("，", data));
            //else
            //    Console.WriteLine("查無資料");
            if (data3 == null)
            {
                Console.WriteLine("查無資料");
            }
            else
            {
                Console.WriteLine(String.Join("，", data3));
            }


            #region 合併三元運算，完全看不懂自己在寫甚麼
            //Console.WriteLine
            //    (videoList.Where(
            //        condition => condition.Duration >= 120).Select(x => x.Name).ToList().Count != 0 ?
            //        String.Join("，", videoList.Where(condition => condition.Duration >= 120).Select(x => x.Name)) :
            //        "查無資料");
            #endregion

            // 4. 請列出所有人的名稱，並且用大寫英文表示，ex: Bill -> BILL
            Console.WriteLine($"{Environment.NewLine}Q4: 請列出所有人的名稱，並且用大寫英文表示");
            //Console.WriteLine(String.Join("，",from items in personList select items.Name.ToUpper()));//Query Expression
            Console.WriteLine(String.Join("，", personList.Select(x => x.Name.ToUpper())));

            // 5. 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名，ex: No1: 天竺鼠車車
            Console.WriteLine($"{Environment.NewLine}Q5: 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名");
            //var data2 =videoList.OrderByDescending(x=>x.Duration);
            //foreach (var item in data2) 
            //{
            //    Console.WriteLine($"{item.Name}，片長為{item.Duration}分鐘");   
            //}
            Console.WriteLine(String.Join(Environment.NewLine, videoList.OrderByDescending(x => x.Duration).Select((x, index) => $"No{index + 1}。{x.Name}，片長為{x.Duration}分鐘")));

            // 6. 將所有影片進行以"類型"分類，並顯示以下樣式(注意縮排)
            /* 
            動漫:
                天竺鼠車車
                鬼滅之刃
            */
            Console.WriteLine($"{Environment.NewLine}Q6: 將所有影片進行以'類型'分類");
            #region QueryExpression
            //var queryExpression6 =
            //    from data6 in videoList
            //    group data6 by data6.Type into VdType
            //    select VdType;
            //foreach (var keyType in queryExpression6)
            //{
            //    Console.WriteLine(keyType.Key+":");
            //    foreach(var obj in keyType) 
            //    {
            //        Console.WriteLine("\t" + obj.Name);
            //    }
            //}
            #endregion
            var Method6 = videoList.GroupBy(x => x.Type);
            //var result6 = Method6.Select(gpk => $"{gpk.Key}:{Environment.NewLine}{String.Join(Environment.NewLine, gpk.Select(n => $"\t{n.Name}"))}");
            //Console.WriteLine(String.Join(Environment.NewLine, result6));
            foreach (var obj in Method6)
            {
                Console.WriteLine(obj.Key + " : ");
                foreach (var item2 in obj)
                {
                    Console.WriteLine("\t" + item2.Name);
                }
            }
            // 7. 找到第一個喜歡歐美影片的人
            Console.WriteLine($"{Environment.NewLine}Q7: 找到第一個喜歡歐美影片的人");
            Console.WriteLine(personList.FirstOrDefault(x => x.CountryPrefer.Contains("歐美")).Name);

            // 8. 找到每個人喜歡的影片(根據國家以及類型)，ex: Bill: 天竺鼠車車, 倚天屠龍記2019
            Console.WriteLine($"{Environment.NewLine}Q8: 找到每個人喜歡的影片");
            var dataSource2 =
                from pl in personList
                from vl in videoList
                where pl.CountryPrefer.Contains(vl.Country) || pl.TypePrefer.Contains(vl.Type)
                group new { pl, vl } by pl.Name;
            var gpPeople = dataSource2.Select(p => p.Key);
            //Console.WriteLine(String.Join(Environment.NewLine, ));

            


            foreach (var item in dataSource2)
            {
                Console.WriteLine($"{item.Key}喜好為");
                foreach (var item2 in item)
                {
                    Console.WriteLine($"\t{item2.vl.Name}，國家:{item2.vl.Country}，類型:{item2.vl.Type}");
                }
            }
            // 9. 列出所有類型的影片總時長，ex: 動漫: 100min
            Console.WriteLine($"{Environment.NewLine}Q9: 列出所有類型的影片總時長");
            var data9 =
                from vl in videoList
                group vl by vl.Type into newGp
                select newGp;

            foreach (var item in data9)
            {
                Console.WriteLine("類型:" + item.Key);
                double duration = 0;
                foreach (var item2 in item)
                {
                    Console.WriteLine($"\t{item2.Name}，片長{item2.Duration}分鐘");
                    duration += item2.Duration;
                }
                Console.WriteLine($"總時間長度為{duration}分鐘");
            }
            // 10. 列出所有國家出產的影片數量，ex: 日本: 3部
            Console.WriteLine($"{Environment.NewLine}Q10: 列出所有國家出產的影片數量");
            var data10 = videoList.GroupBy(x => x.Country);
            foreach (var item in data10)
            {
                Console.WriteLine("國家:" + item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine($"\t{item2.Name}");
                }
            }
            Console.ReadLine();
        }
    }
}
