using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestNumber
{
    public partial class Form1 : Form
    {
        private List<int> _ans;
        private int _countA;
        private int _countB;
        public Form1()
        {
            InitializeComponent();
            Createlist();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            CreatNumber();
        }
        private void Createlist()
        {
            _ans = new List<int> { };
        }
        private void CreatNumber()
        {
            _ans.Clear();
            Random random = new Random();
            _ans.Add(random.Next(0, 10));
            _ans.Add(random.Next(0, 10));
            _ans.Add(random.Next(0, 10));
            _ans.Add(random.Next(0, 10));
            // LINQ 產生???
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    while (_ans[j] == _ans[i])
                    {
                        j = 0;
                        _ans[i] = random.Next(0, 10);
                    }
                }
            }
            TestAns.Text = String.Join(String.Empty, _ans);
        }
        private void CheckAns_Click(object sender, EventArgs e)
        {
            char[] chars = textBox1.Text.ToCharArray();
            var input = chars.Select(x => x.ToString()).ToList();
            CheckNum(input);
            SetLog(_countA, _countB);
            SeeAns.Enabled = true;
            textBox1.Text = String.Empty;
            GameFinish();
        }
        private void GiveUp_Click(object sender, EventArgs e)
        {
            _ans.Clear();
            TestAns.Text = String.Empty;
            Log.Text = String.Empty;
            SeeAns.Enabled = false;
            CheckAns.Enabled = true;
            Start.Enabled = true;
        }
        private void CheckNum(List<string> input)
        {
            _countA = 0;
            _countB = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == _ans[i].ToString())
                {
                    _countA++;
                }
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[i] == _ans[j].ToString() && input[i] != _ans[j].ToString() )
                    {
                        _countB++;
                    }
                }
            }        
        }
        private void SeeAns_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"答案為 : {String.Join(String.Empty, _ans)}");
            CheckAns.Enabled = false;
        }
        private void SetLog(int countA, int countB)
        {
            Log.Text += $"輸入{textBox1.Text}: {countA}A，{countB}B{Environment.NewLine}";
        }
        private void GameFinish()
        {
            if (_countA >= 4)
            {
                CheckAns.Enabled = false;
                Start.Enabled = false;
                MessageBox.Show("恭喜獲勝!");
            }
        }


        //助教寫法
        private List<string> answer;
        private List<string> guess;
        private List<string> GetAnswer()
        {
            var result = new List<string>();
            var random = new Random();
            do
            {
                var n = random.Next(0, 10).ToString();
                if (!result.Contains(n))
                {
                    result.Add(n);
                }
            } while (result.Count != 4);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var random = new Random();
            var ans = Enumerable.Range(0, 10);
            var orderBylist = ans.OrderBy(i =>random.Next());
        }
    }
}
