using LifeNumber.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeNumber
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> _dictionary;
        List<LifeData> _lifeNumberList;
        List<StarData> _starDatas;

        public Form1()
        {
            InitializeComponent();
            _lifeNumberList = LifeNum.GetLifeData();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var input = dateTimePicker1.Text;
            GetLifeNumber(input);
            GetConstellation(input);
            GetData();
        }
        private void GetData()
        {
            string path = "../生命靈數.txt";
            if (File.Exists(path))
            {
                string file = File.ReadAllText(path,Encoding.UTF8);
                var dataSource = file.Split(new char[] { '【', '】' }, StringSplitOptions.RemoveEmptyEntries);
                var dataSelection = dataSource.Where(c => c.Contains($"{_dictionary["星座"]}")).Select(s => s.Split(new string[] { $"{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries));
                var dataConstellation = dataSelection.First();
                textBox1.Text = String.Join(Environment.NewLine, dataConstellation);
                textBox1.Text += String.Join(Environment.NewLine, dataSelection.Select(c => String.Join(String.Empty, c.Where(y => y.Contains($"生命靈數{_dictionary["生命靈數"]}")))));

                MessageBox.Show("讀取完畢");
            }
            else
            {
                MessageBox.Show("無資料來源");
            }
        }
        public void GetLifeNumber(string input)
        {
            _dictionary = new Dictionary<string, string>();
            string[] newStr = input.Split(new string[] { "年" }, StringSplitOptions.RemoveEmptyEntries);

            var newInput = input.Replace("月", String.Empty).Replace("日", String.Empty).Replace("年", String.Empty);
            char[] chars = newInput.ToCharArray();//2,0,2,2,1,2,1,9
            int sum = chars.Sum(i => int.Parse(i.ToString()));
            while (sum >= 10)
            {
                sum = sum.ToString().ToCharArray().Sum(x => int.Parse(x.ToString()));
                break;
            }
            _dictionary.Add("出生月日", $"{newStr[1]}");
            _dictionary.Add("生命靈數", $"{sum}");
        }
        public void GetConstellation(string input)
        {
            var newInput = input.Replace("月", ",").Replace("日", ",").Replace("年", ",");
            var days = newInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            DateTime dt = new DateTime(days[0], days[1], days[2]);

            float fBirthDay = Convert.ToSingle(dt.ToString("M.dd"));
            float[] atomBound = { 1.20F, 2.20F, 3.21F, 4.21F, 5.21F, 6.22F, 7.23F, 8.23F, 9.23F, 10.23F, 11.21F, 12.22F, 13.20F };
            string[] atoms = { "水瓶座", "雙魚座", "牡羊座", "金牛座", "雙子座", "巨蟹座", "獅子座", "處女座", "天秤座", "天蠍座", "射手座", "魔羯座" };
            string ret = string.Empty;
            for (int i = 0; i < atomBound.Length - 1; i++)
            {
                if (atomBound[i] <= fBirthDay && atomBound[i + 1] > fBirthDay)
                {
                    ret = atoms[i];
                    break;
                }
            }
            _dictionary.Add("星座", ret);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            var birthday = dateTimePicker1.Value.Date;
            _starDatas = Star.GetStars(birthday.Year);
            //取得生命靈數
            int lifeNum = GetLifeNum(birthday.ToString("yyyyMMdd"));//格式化輸出字串
            //取得星座
            //var conName = _starDatas.Find(x => x.StartDay <= birthday && birthday < x.EndDay).ConsName;
            var conData = _starDatas.Where(x => x.StartDay <= birthday && birthday < x.EndDay).Select(x => x.ConsName);
            var conName = string.Join(String.Empty, conData);
            //顯示對應星座描述內容
            var desc = _lifeNumberList.Find((x) =>x.Constellation.Contains(conName)&& x.Number == lifeNum).Description;

            //組合資料
            textBox1.Text = $"你的星座是 {conName}{Environment.NewLine}你的生命靈數為 {lifeNum}{Environment.NewLine}{desc}";
        }

        private int GetLifeNum(string birthday)
        {
            int splitStr = birthday.ToCharArray().Sum((x) => int.Parse(x.ToString()));
            if (splitStr >= 10)
            {
                do 
                {
                    splitStr = splitStr.ToString().ToCharArray().Sum((x)=>int.Parse(x.ToString()));
                }
                while (splitStr > 10);
            }           
            return splitStr;
        }

    }
}
