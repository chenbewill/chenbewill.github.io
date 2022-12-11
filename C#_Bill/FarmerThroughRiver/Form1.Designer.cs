namespace FarmerThroughRiver
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
            this.GoBTN = new System.Windows.Forms.Button();
            this.BackBTN = new System.Windows.Forms.Button();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.Reset = new System.Windows.Forms.Button();
            this.ReturnBTN = new System.Windows.Forms.Button();
            this.rightBox = new System.Windows.Forms.ListBox();
            this.leftBox = new System.Windows.Forms.ListBox();
            this.ActionBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBTN
            // 
            this.GoBTN.Location = new System.Drawing.Point(193, 66);
            this.GoBTN.Name = "GoBTN";
            this.GoBTN.Size = new System.Drawing.Size(129, 85);
            this.GoBTN.TabIndex = 0;
            this.GoBTN.Text = "過河";
            this.GoBTN.UseVisualStyleBackColor = true;
            this.GoBTN.Click += new System.EventHandler(this.GoBTN_Click);
            // 
            // BackBTN
            // 
            this.BackBTN.Location = new System.Drawing.Point(193, 300);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(129, 85);
            this.BackBTN.TabIndex = 3;
            this.BackBTN.Text = "返回";
            this.BackBTN.UseVisualStyleBackColor = true;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // LogListBox
            // 
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.ItemHeight = 15;
            this.LogListBox.Location = new System.Drawing.Point(532, 66);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(200, 319);
            this.LogListBox.TabIndex = 4;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(532, 391);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 5;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // ReturnBTN
            // 
            this.ReturnBTN.Location = new System.Drawing.Point(657, 391);
            this.ReturnBTN.Name = "ReturnBTN";
            this.ReturnBTN.Size = new System.Drawing.Size(75, 23);
            this.ReturnBTN.TabIndex = 6;
            this.ReturnBTN.Text = "Return";
            this.ReturnBTN.UseVisualStyleBackColor = true;
            this.ReturnBTN.Click += new System.EventHandler(this.ReturnBTN_Click);
            // 
            // rightBox
            // 
            this.rightBox.FormattingEnabled = true;
            this.rightBox.ItemHeight = 15;
            this.rightBox.Location = new System.Drawing.Point(341, 66);
            this.rightBox.Name = "rightBox";
            this.rightBox.Size = new System.Drawing.Size(126, 319);
            this.rightBox.TabIndex = 2;
            // 
            // leftBox
            // 
            this.leftBox.FormattingEnabled = true;
            this.leftBox.ItemHeight = 15;
            this.leftBox.Location = new System.Drawing.Point(50, 66);
            this.leftBox.Name = "leftBox";
            this.leftBox.Size = new System.Drawing.Size(126, 319);
            this.leftBox.TabIndex = 1;
            // 
            // ActionBTN
            // 
            this.ActionBTN.Location = new System.Drawing.Point(193, 179);
            this.ActionBTN.Name = "ActionBTN";
            this.ActionBTN.Size = new System.Drawing.Size(129, 85);
            this.ActionBTN.TabIndex = 7;
            this.ActionBTN.Text = "行動";
            this.ActionBTN.UseVisualStyleBackColor = true;
            this.ActionBTN.Click += new System.EventHandler(this.ActionBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ActionBTN);
            this.Controls.Add(this.ReturnBTN);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.BackBTN);
            this.Controls.Add(this.rightBox);
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.GoBTN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBTN;
        private System.Windows.Forms.Button BackBTN;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button ReturnBTN;
        private System.Windows.Forms.ListBox rightBox;
        private System.Windows.Forms.ListBox leftBox;
        private System.Windows.Forms.Button ActionBTN;
    }
}

