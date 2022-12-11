using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransTemperature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CtoF.Checked = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.ActiveControl.Text;

            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            label1.Text = "結果:";
            CtoF.Checked = true;
            FtoC.Checked = false;
        }

        private void transation_Click(object sender, EventArgs e)
        {
            var radio = CtoF.Checked;
            CalculateTemperture(radio);

        }
        private void CalculateTemperture(bool CtoF_radio)
        {
            
            if(!double.TryParse(textBox1.Text,out double temp))
            {
                MessageBox.Show("請輸入正確溫度");
                return;
            };
            string result;
            if (CtoF_radio)
            {
                result = (temp * 9 / 5   + 32).ToString();
                label1.Text = $"{textBox1.Text}.C 轉換結果 : {result}.F";

            }
            else
            {
                result = ((temp - 32) * 5 / 9).ToString();
                label1.Text = $"{textBox1.Text}.F 轉換結果 : {result}.C";

            }

        }
    }
}
