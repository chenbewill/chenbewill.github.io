using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3_5RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person John = new Person() { Name = "John", HP = 100, STR = 10, AGI = 5, };
            Person Andy = new Person() { Name = "Andy", HP = 100, STR = 10, AGI = 5, };
            Console.WriteLine($"{John.Name}，HP:{John.HP}，力量:{John.STR},速度:{John.AGI}");
            Console.WriteLine($"{Andy.Name}，HP:{Andy.HP}，力量:{Andy.STR},速度:{Andy.AGI}");
            string result = John.Fight(John, Andy);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int STR { get; set; }
        public int AGI { get; set; }

        public string Fight(Person A, Person B)
        {
            Console.WriteLine($"{A.Name}向{B.Name}發起戰鬥");
            string result;
            do
            {
                //死亡即跳出迴圈
                while ((A.CheckHP() == 0) == (B.CheckHP() == 0))
                {
                    result = $"{A.Name}，{B.Name}同時死亡";
                    break;
                }
                if (A.CheckHP() <= 0)
                {
                    result = $"{A.Name}已經死亡";
                    break;
                }
                else if (B.CheckHP() <= 0)
                {
                    result = $"{B.Name}已經死亡";
                    break;
                }
                result = A.Attack(A, B);
                Console.WriteLine(result);
            }
            while (true);
            return result;
        }
        private int CheckHP()
        {
            while (this.HP <= 0)
            {
                this.HP = 0;
                this.STR = 0;
                break;
            }
            return this.HP;
        }

        public string Attack(Person A, Person B)
        {
            string result;
            if (A.AGI > B.AGI)
            {
                B.HP = B.HP - A.STR;
                result = $"{A.Name}攻擊了{B.Name}造成{A.STR}傷害\n" + $"{B.Name}剩餘{B.HP}HP";
            }
            else if (A.AGI < B.AGI)
            {
                A.HP = A.HP - B.STR;
                result = $"{B.Name}攻擊了{A.Name}造成{B.STR}傷害\n" + $"{A.Name}剩餘{A.HP}HP";
            }
            else
            {
                A.HP = A.HP - B.STR;
                B.HP = B.HP - A.STR;
                result = $"{B.Name}{A.Name}同時互相攻擊\n" + $"{A.Name}剩餘{A.HP}HP，" + $"{B.Name}剩餘{B.HP}HP";
            }
            return result;
        }

    }

}
