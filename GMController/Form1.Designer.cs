namespace GMController
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
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnNorth = new System.Windows.Forms.Button();
            this.BtnSouth = new System.Windows.Forms.Button();
            this.BtnEast = new System.Windows.Forms.Button();
            this.BtnWest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnNW = new System.Windows.Forms.Button();
            this.BtnNE = new System.Windows.Forms.Button();
            this.BtnSE = new System.Windows.Forms.Button();
            this.BtnSW = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnAuto = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 22);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(1, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Latitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Longitude";
            // 
            // BtnNorth
            // 
            this.BtnNorth.Location = new System.Drawing.Point(72, 131);
            this.BtnNorth.Name = "BtnNorth";
            this.BtnNorth.Size = new System.Drawing.Size(48, 23);
            this.BtnNorth.TabIndex = 4;
            this.BtnNorth.Text = "N";
            this.BtnNorth.UseVisualStyleBackColor = true;
            this.BtnNorth.Click += new System.EventHandler(this.BtnNorth_Click);
            // 
            // BtnSouth
            // 
            this.BtnSouth.Location = new System.Drawing.Point(72, 189);
            this.BtnSouth.Name = "BtnSouth";
            this.BtnSouth.Size = new System.Drawing.Size(48, 23);
            this.BtnSouth.TabIndex = 5;
            this.BtnSouth.Text = "S";
            this.BtnSouth.UseVisualStyleBackColor = true;
            this.BtnSouth.Click += new System.EventHandler(this.BtnSouth_Click);
            // 
            // BtnEast
            // 
            this.BtnEast.Location = new System.Drawing.Point(126, 160);
            this.BtnEast.Name = "BtnEast";
            this.BtnEast.Size = new System.Drawing.Size(48, 23);
            this.BtnEast.TabIndex = 6;
            this.BtnEast.Text = "E";
            this.BtnEast.UseVisualStyleBackColor = true;
            this.BtnEast.Click += new System.EventHandler(this.BtnEast_Click);
            // 
            // BtnWest
            // 
            this.BtnWest.Location = new System.Drawing.Point(18, 160);
            this.BtnWest.Name = "BtnWest";
            this.BtnWest.Size = new System.Drawing.Size(48, 23);
            this.BtnWest.TabIndex = 7;
            this.BtnWest.Text = "W";
            this.BtnWest.UseVisualStyleBackColor = true;
            this.BtnWest.Click += new System.EventHandler(this.BtnWest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(156, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "初始定位";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(4, 240);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(279, 70);
            this.textBox3.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "我家",
            "政大",
            "北投公園",
            "碧湖公園",
            "大湖公園",
            "逢甲公園",
            "前港公園",
            "梧棲漁港",
            "南寮漁港",
            "信義區",
            "道館-杏花林",
            "道館-Overlook Deck",
            "道館-神奇大石龜",
            "道館-聖恩宮",
            "道館-政大研究總中心",
            "道館-指南茶路石碑",
            "道館-親水文學步道",
            "道館-指南宮天門長廊",
            "道館-指南宮纜車站",
            "道館-指南宮大雄寶殿",
            "道館-兩隻小鹿",
            "道館-樟湖步道",
            "道館-喵嗚",
            "道館-貓空纜車站",
            "道館-路標",
            "道館-茶研發推廣中心*2",
            "道館-銀河洞*2",
            "道館-靈山媽祖廟*2"});
            this.comboBox1.Location = new System.Drawing.Point(158, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 20);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "請選擇";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnNW
            // 
            this.BtnNW.Location = new System.Drawing.Point(18, 131);
            this.BtnNW.Name = "BtnNW";
            this.BtnNW.Size = new System.Drawing.Size(48, 23);
            this.BtnNW.TabIndex = 12;
            this.BtnNW.Text = "NW";
            this.BtnNW.UseVisualStyleBackColor = true;
            this.BtnNW.Click += new System.EventHandler(this.BtnNW_Click);
            // 
            // BtnNE
            // 
            this.BtnNE.Location = new System.Drawing.Point(126, 131);
            this.BtnNE.Name = "BtnNE";
            this.BtnNE.Size = new System.Drawing.Size(48, 23);
            this.BtnNE.TabIndex = 13;
            this.BtnNE.Text = "NE";
            this.BtnNE.UseVisualStyleBackColor = true;
            this.BtnNE.Click += new System.EventHandler(this.BtnNE_Click);
            // 
            // BtnSE
            // 
            this.BtnSE.Location = new System.Drawing.Point(126, 189);
            this.BtnSE.Name = "BtnSE";
            this.BtnSE.Size = new System.Drawing.Size(48, 23);
            this.BtnSE.TabIndex = 14;
            this.BtnSE.Text = "SE";
            this.BtnSE.UseVisualStyleBackColor = true;
            this.BtnSE.Click += new System.EventHandler(this.BtnSE_Click);
            // 
            // BtnSW
            // 
            this.BtnSW.Location = new System.Drawing.Point(18, 189);
            this.BtnSW.Name = "BtnSW";
            this.BtnSW.Size = new System.Drawing.Size(48, 23);
            this.BtnSW.TabIndex = 15;
            this.BtnSW.Text = "SW";
            this.BtnSW.UseVisualStyleBackColor = true;
            this.BtnSW.Click += new System.EventHandler(this.BtnSW_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BtnAuto
            // 
            this.BtnAuto.Location = new System.Drawing.Point(72, 160);
            this.BtnAuto.Name = "BtnAuto";
            this.BtnAuto.Size = new System.Drawing.Size(48, 23);
            this.BtnAuto.TabIndex = 16;
            this.BtnAuto.Text = "Start";
            this.BtnAuto.UseVisualStyleBackColor = true;
            this.BtnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 218);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Fast mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(72, 74);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(78, 22);
            this.textBox4.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(72, 103);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(78, 22);
            this.textBox5.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(1, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "TLatitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(1, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "TLongitude";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(156, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "導航";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownWidth = 73;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "我家",
            "政大",
            "北投公園",
            "碧湖公園",
            "大湖公園",
            "逢甲公園",
            "前港公園",
            "梧棲漁港",
            "南寮漁港",
            "信義區",
            "道館-杏花林",
            "道館-Overlook Deck",
            "道館-神奇大石龜",
            "道館-聖恩宮",
            "道館-政大研究總中心",
            "道館-指南茶路石碑",
            "道館-親水文學步道",
            "道館-指南宮天門長廊",
            "道館-指南宮纜車站",
            "道館-指南宮大雄寶殿",
            "道館-兩隻小鹿",
            "道館-樟湖步道",
            "道館-喵嗚",
            "道館-貓空纜車站",
            "道館-路標",
            "道館-茶研發推廣中心*2",
            "道館-銀河洞*2",
            "道館-靈山媽祖廟*2"});
            this.comboBox2.Location = new System.Drawing.Point(159, 105);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(125, 20);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.Text = "請選擇";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 322);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BtnAuto);
            this.Controls.Add(this.BtnSW);
            this.Controls.Add(this.BtnSE);
            this.Controls.Add(this.BtnNE);
            this.Controls.Add(this.BtnNW);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnWest);
            this.Controls.Add(this.BtnEast);
            this.Controls.Add(this.BtnSouth);
            this.Controls.Add(this.BtnNorth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "GenyMotion Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnNorth;
        private System.Windows.Forms.Button BtnSouth;
        private System.Windows.Forms.Button BtnEast;
        private System.Windows.Forms.Button BtnWest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnNW;
        private System.Windows.Forms.Button BtnNE;
        private System.Windows.Forms.Button BtnSE;
        private System.Windows.Forms.Button BtnSW;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BtnAuto;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

