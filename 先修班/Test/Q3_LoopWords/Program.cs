using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3_LoopWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入一段文字");
            Paragraph paragraph = new Paragraph();
            {
                paragraph.Text = Console.ReadLine();
            }
            paragraph.IsEcho();
            if (paragraph.IsEcho())
            {
                Console.WriteLine("是回文"); 
            }
            else
            {
                Console.WriteLine("不是回文"); 
            }
            Console.ReadLine();
        }
    }
    public class Paragraph
    {
        public string Text { get; set; }
        public bool IsEcho()
        {
            return Calculate() ? true : false;
        }
        private bool Calculate()
        {
            string data = Text;
            int max = data.Length - 1;
            for (int i = 0; i <= max /2 ; i++)
            {
                if (data[i]  != data[max-i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

