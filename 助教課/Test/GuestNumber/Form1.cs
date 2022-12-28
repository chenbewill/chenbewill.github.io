using System;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> _answer;
        private List<string> _guess;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _answer = new List<string>();            
            var random = new Random();
            
            
        }
    }
}