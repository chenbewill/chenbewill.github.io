using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmerThroughRiver
{
    public partial class Form1 : Form
    {
        private List<string> _leftList;
        private List<string> _rightList;
        private List<string> _logList;
        private List<string> _returnList;

        private List<string> _famerList;
        private List<string> _noFamerList;
        private ListBox _famerListBox;
        private ListBox _noFamerListBox;
        public Form1()
        {
            InitializeComponent();
            AddListItems();
            SetListBoxSelectionMode();
            RefreshList();
            LogListBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
        }

        private void GetFamerList()
        {
            if (_leftList.Contains("農夫"))
            {
                _famerListBox = leftBox;
                _famerList = _leftList;
                _noFamerList = _rightList;
                _noFamerListBox = rightBox;
            }
            else
            {
                _famerListBox = rightBox;
                _famerList = _rightList;
                _noFamerList = _leftList;
                _noFamerListBox = leftBox;
            }
        }
        private void GoBTN_Click( object  sender, EventArgs e)
        {
            string person = "農夫";
            string item = null;
            while (!leftBox.Items.Contains("農夫"))
            {
                MessageBox.Show("必須要有農夫駕駛船隻");
                return;
            }
            if ((string)leftBox.SelectedItem != "農夫" && leftBox.SelectedItem != null)
            {
                item = (string)leftBox.SelectedItem;
                _leftList.Remove(item);
                _rightList.Add(item);
                //將農夫添加進移動
                _leftList.Remove(person);
                _rightList.Add(person);
            }
            else
            {
                leftBox.SelectedItem = person;
                _leftList.Remove(person);
                _rightList.Add(person);
            }
            Log(person, item);
            
            RefreshList();
            SetListBoxSelectionMode();
            CheckListState();
        }
        private void BackBTN_Click(object sender, EventArgs e)
        {
            string person = "農夫";
            string item = null;
            while (!rightBox.Items.Contains("農夫"))
            {
                MessageBox.Show("必須要有農夫駕駛船隻");
                return;
            }
            if ((string)rightBox.SelectedItem != "農夫" && rightBox.SelectedItem != null)
            {
                item = (string)rightBox.SelectedItem;
                _rightList.Remove(item);
                _leftList.Add(item);
                //將農夫加入移動
                _rightList.Remove(person);
                _leftList.Add(person);
            }
            else
            {
                rightBox.SelectedItem = person;
                _rightList.Remove(person);
                _leftList.Add(person);
            }
            Log(person, item);
            RefreshList();
            CheckListState();
            SetListBoxSelectionMode();
        }
        private void ActionBTN_Click(object sender, EventArgs e)
        {
            if (_leftList.Contains("農夫"))
                GoBTN_Click(sender, e);
            else
                BackBTN_Click(sender, e);
        }
        private void ReturnBTN_Click(object sender, EventArgs e)
        {
            GetFamerList();
            while (_logList.Count == 0)
            {
                MessageBox.Show("無法再繼續返回上一部");
                return;
            }
            string[] array = _returnList[_returnList.Count - 1].Split(',');
            if (array.Length > 1)
            {
                _famerList.Remove(array[1]);
                _noFamerList.Add(array[1]);
            }
            _famerList.Remove("農夫");
            _noFamerList.Add("農夫");
            _logList.RemoveAt(_logList.Count - 1);
            _returnList.RemoveAt(_returnList.Count - 1);
            SetListBoxSelectionMode();
            RefreshList();
        }
        // 檢查勝敗條件
        private void CheckListState()
        {
            GetFamerList();
            //失敗條件
            if (_noFamerList.Contains("野狼") && _noFamerList.Contains("綿羊"))
            {
                MessageBox.Show("遊戲結束，野狼吃掉綿羊了");
                GameOver();
                return;
            }
            else if (_noFamerList.Contains("綿羊") && _noFamerList.Contains("青菜"))
            {
                MessageBox.Show("遊戲結束，綿羊吃掉青菜了");
                GameOver();
                return;
            }
        }
        // 將過河動作寫入_logList&_returnList
        private void Log(string farmer, string item = null)
        {
            _logList.Add((item != null) ? $"{farmer}攜帶{item}過河" : $"{farmer}獨自過河");
            _returnList.Add((item != null) ? $"{farmer},{item}" : $"{farmer}");
        }
        // 重新開始遊戲
        private void Reset_Click(object sender, EventArgs e)
        {
            _leftList.Clear();
            _rightList.Clear();
            _logList.Clear();
            _returnList.Clear();
            AddListItems();
            RefreshList();
            SetListBoxSelectionMode();
            NewGame();
        }
        //鎖住對應的ListBox
        private void SetListBoxSelectionMode() 
        {
            GetFamerList();
            _noFamerListBox.SelectionMode= SelectionMode.None;
            _famerListBox.SelectionMode= SelectionMode.One;
        }
        /// ListBox畫面進行更新        
        private void RefreshList()
        {
            LogListBox.DataSource = null;
            LogListBox.DataSource = _logList;
            leftBox.DataSource = null;
            leftBox.DataSource = _leftList;
            rightBox.DataSource = null;
            rightBox.DataSource = _rightList;
        }
        // 集合初始化設定式        
        private void AddListItems()
        {
            _leftList = new List<string> { "綿羊" ,"野狼", "青菜", "農夫" };
            _rightList = new List<string> { };
            _logList = new List<string> { };
            _returnList = new List<string> { };
        }
        // 遊戲結束
        private void GameOver()
        {
            ReturnBTN.Enabled = false;
            GoBTN.Enabled = false;
            BackBTN.Enabled = false;
            ActionBTN.Enabled = false;
        }
        // 新遊戲 
        private void NewGame()
        {
            ReturnBTN.Enabled = true;
            GoBTN.Enabled = true;
            BackBTN.Enabled = true;
            ActionBTN.Enabled = true;
        }
        //監聽LogListBox 有變動後刷新並鎖住
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            LogListBox.SelectionMode = SelectionMode.One;
            LogListBox.SelectionMode = SelectionMode.None;
        }
        
    }
}
