using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q5_StudentObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  Finish
            Random rand = new Random();
            Student student1 = new Student()
            {
                Id = "S110001",
                Name = "小明",
            };
            student1.Elective = new OldLession()
            {
                OldLessionName = new string[] { "體育", "國文", "英文", "數學" },
                Credit = new int[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) }
            };
            //等效
            Student student2 = new Student()
            {
                Id = "S110002",
                Name = "小王",
                Elective = new OldLession()
                {
                    OldLessionName = new string[] { "社會", "美術", "英文", "繪畫" },
                    Credit = new int[] { rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10) }
                }
            };
            Student[] students = new Student[] { student1, student2 };
            #region foreach的迴圈           
            foreach (Student studentForeach in students)
            {
                Console.WriteLine($"學號: {studentForeach.Id}");
                Console.WriteLine($"姓名: {studentForeach.Name}");
                Console.WriteLine($"選修課程:");
                int credit = 0;
                for (int i = 0; i < studentForeach.Elective.OldLessionName.Length; i++)
                {
                    Console.WriteLine($"\t" + $"{studentForeach.Elective.OldLessionName[i]}，學分為{studentForeach.Elective.Credit[i]}");
                    credit += studentForeach.Elective.Credit[i];
                }
                Console.WriteLine($"總共學分數為{credit}個");
                Console.WriteLine("-------------------------------------------------------------");

            }
            #endregion
            Console.WriteLine("ForLoop");
            Console.WriteLine("-------------------------------------------------------------");
            for (int c = 0; c < students.Length; c++)
            {
                Console.WriteLine($"學號: {students[c].Id}");
                Console.WriteLine($"姓名: {students[c].Name}");
                Console.WriteLine($"選修課程:");
                int credit = 0;
                for (int i = 0; i < students[c].Elective.OldLessionName.Length; i++)
                {
                    Console.WriteLine($"\t" + $"{students[c].Elective.OldLessionName[i]}，學分為{students[c].Elective.Credit[i]}");
                    credit += students[c].Elective.Credit[i];
                }
                Console.WriteLine($"總共學分數為{credit}個");
                Console.WriteLine("-------------------------------------------------------------");
            }
            Console.ReadLine();
            #endregion

            #region 測試亂數產生課程
            Random random = new Random();
            Console.WriteLine("請輸入姓名");
            string name = Console.ReadLine();
            Console.WriteLine("輸入選修數字");
            string classNum = Console.ReadLine();            
            CreateObj createObj = new CreateObj();
            Student student = new Student();
            student.Name = name;
            student.Id = createObj.CreateID();
            student.Elective = new OldLession();
            student.Elective.OldLessionName = createObj.CreateClass(int.Parse(classNum));
            student.Elective.Credit = createObj.CreateCredit(int.Parse(classNum));
            Console.WriteLine($"姓名:{student.Name}");
            Console.WriteLine($"學號:{student.Id}");
            Console.WriteLine($"課程:");
            int creditCount = 0;
            for (int i = 0; i < student.Elective.OldLessionName.Length; i++)
            {
                Console.WriteLine($"\t{student.Elective.OldLessionName[i]}:{student.Elective.Credit[i]}學分");
                creditCount += student.Elective.Credit[i];
            }           
            Console.WriteLine($"總共{creditCount}學分");
            Console.ReadLine();
            #endregion

        }
    }
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public OldLession Elective { get; set; }
        //public NewLession[] NewElective { get; set; }
    }
    public class OldLession
    {
        public string[] OldLessionName { get; set; }
        public int[] Credit { get; set; }
    }
    public class NewLession
    {
        public string LessionName { get; set;   }
        public int Credit { get; set; }
    }

    public class CreateObj
    {
        public string CreateID()
        {
            Random random = new Random();
            string[] arraId = new string[] { "S11001", "S11002", "S11003", "S11004", "S11005", "S11006", "S11007", "S11008", "S11009", "S11010" };
            int num = random.Next(1, 10);
            return arraId[num];
        }
        public string[] CreateClass(int count)
        {
            string[] result = new string[count];
            Random random = new Random();
            string[] className = new string[] { "國文", "英文", "數學", "社會", "地理", "歷史", "自然", "人文", "健康教育", "體育" };
            for (int i = 0; i < count; i++)
            {
                result[i] = className[random.Next(0, 10)];
                for (int j = 0; j < result.Length; j++)
                {
                    while (result[i] == result[j] && i != j)
                    {
                        result[j] = className[random.Next(0, 10)];
                        j = 0;
                        
                    }


                }
            }
            return result;


        }
        public int[] CreateCredit(int count)
        {
            int[] result = new int[count];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                result[i] = random.Next(1, 10);
            }
            return result;
        }
    }
}
