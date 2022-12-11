namespace GuestNumber
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.SeeAns = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CheckAns = new System.Windows.Forms.Button();
            this.GiveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TextBox();
            this.TestAns = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(52, 51);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(215, 65);
            this.Start.TabIndex = 0;
            this.Start.Text = "開始遊戲";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // SeeAns
            // 
            this.SeeAns.Enabled = false;
            this.SeeAns.Location = new System.Drawing.Point(52, 154);
            this.SeeAns.Name = "SeeAns";
            this.SeeAns.Size = new System.Drawing.Size(215, 65);
            this.SeeAns.TabIndex = 1;
            this.SeeAns.Text = "看答案";
            this.SeeAns.UseVisualStyleBackColor = true;
            this.SeeAns.Click += new System.EventHandler(this.SeeAns_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 331);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 25);
            this.textBox1.TabIndex = 2;
            // 
            // CheckAns
            // 
            this.CheckAns.Location = new System.Drawing.Point(52, 362);
            this.CheckAns.Name = "CheckAns";
            this.CheckAns.Size = new System.Drawing.Size(101, 76);
            this.CheckAns.TabIndex = 4;
            this.CheckAns.Text = "檢查答案";
            this.CheckAns.UseVisualStyleBackColor = true;
            this.CheckAns.Click += new System.EventHandler(this.CheckAns_Click);
            // 
            // GiveUp
            // 
            this.GiveUp.Location = new System.Drawing.Point(159, 362);
            this.GiveUp.Name = "GiveUp";
            this.GiveUp.Size = new System.Drawing.Size(108, 76);
            this.GiveUp.TabIndex = 5;
            this.GiveUp.Text = "放棄重新";
            this.GiveUp.UseVisualStyleBackColor = true;
            this.GiveUp.Click += new System.EventHandler(this.GiveUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "輸入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "遊戲歷程";
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(418, 51);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(330, 334);
            this.Log.TabIndex = 8;
            // 
            // TestAns
            // 
            this.TestAns.AutoSize = true;
            this.TestAns.Location = new System.Drawing.Point(52, 251);
            this.TestAns.Name = "TestAns";
            this.TestAns.Size = new System.Drawing.Size(37, 15);
            this.TestAns.TabIndex = 9;
            this.TestAns.Text = "答案";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TestAns);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GiveUp);
            this.Controls.Add(this.CheckAns);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SeeAns);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button SeeAns;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CheckAns;
        private System.Windows.Forms.Button GiveUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label TestAns;
        private System.Windows.Forms.Button button1;
    }
}

