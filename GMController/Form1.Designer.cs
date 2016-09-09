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
            this.Set1Btn = new System.Windows.Forms.Button();
            this.Set2Btn = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.BtnPath = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 22);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(1, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "定位緯度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "定位經度";
            // 
            // BtnNorth
            // 
            this.BtnNorth.Location = new System.Drawing.Point(58, 167);
            this.BtnNorth.Name = "BtnNorth";
            this.BtnNorth.Size = new System.Drawing.Size(48, 23);
            this.BtnNorth.TabIndex = 4;
            this.BtnNorth.Text = "N";
            this.BtnNorth.UseVisualStyleBackColor = true;
            this.BtnNorth.Click += new System.EventHandler(this.BtnNorth_Click);
            // 
            // BtnSouth
            // 
            this.BtnSouth.Location = new System.Drawing.Point(58, 225);
            this.BtnSouth.Name = "BtnSouth";
            this.BtnSouth.Size = new System.Drawing.Size(48, 23);
            this.BtnSouth.TabIndex = 5;
            this.BtnSouth.Text = "S";
            this.BtnSouth.UseVisualStyleBackColor = true;
            this.BtnSouth.Click += new System.EventHandler(this.BtnSouth_Click);
            // 
            // BtnEast
            // 
            this.BtnEast.Location = new System.Drawing.Point(112, 196);
            this.BtnEast.Name = "BtnEast";
            this.BtnEast.Size = new System.Drawing.Size(48, 23);
            this.BtnEast.TabIndex = 6;
            this.BtnEast.Text = "E";
            this.BtnEast.UseVisualStyleBackColor = true;
            this.BtnEast.Click += new System.EventHandler(this.BtnEast_Click);
            // 
            // BtnWest
            // 
            this.BtnWest.Location = new System.Drawing.Point(4, 196);
            this.BtnWest.Name = "BtnWest";
            this.BtnWest.Size = new System.Drawing.Size(48, 23);
            this.BtnWest.TabIndex = 7;
            this.BtnWest.Text = "W";
            this.BtnWest.UseVisualStyleBackColor = true;
            this.BtnWest.Click += new System.EventHandler(this.BtnWest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "初始定位";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(4, 254);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(298, 56);
            this.textBox3.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "景點",
            "木柵道館",
            "新店道館"});
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 12;
            this.comboBox1.Items.AddRange(new object[] {
            "景點",
            "木柵道館",
            "新店道館",
            "石碇道館"});
            this.comboBox1.Location = new System.Drawing.Point(172, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 20);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnNW
            // 
            this.BtnNW.Location = new System.Drawing.Point(4, 167);
            this.BtnNW.Name = "BtnNW";
            this.BtnNW.Size = new System.Drawing.Size(48, 23);
            this.BtnNW.TabIndex = 12;
            this.BtnNW.Text = "NW";
            this.BtnNW.UseVisualStyleBackColor = true;
            this.BtnNW.Click += new System.EventHandler(this.BtnNW_Click);
            // 
            // BtnNE
            // 
            this.BtnNE.Location = new System.Drawing.Point(112, 167);
            this.BtnNE.Name = "BtnNE";
            this.BtnNE.Size = new System.Drawing.Size(48, 23);
            this.BtnNE.TabIndex = 13;
            this.BtnNE.Text = "NE";
            this.BtnNE.UseVisualStyleBackColor = true;
            this.BtnNE.Click += new System.EventHandler(this.BtnNE_Click);
            // 
            // BtnSE
            // 
            this.BtnSE.Location = new System.Drawing.Point(112, 225);
            this.BtnSE.Name = "BtnSE";
            this.BtnSE.Size = new System.Drawing.Size(48, 23);
            this.BtnSE.TabIndex = 14;
            this.BtnSE.Text = "SE";
            this.BtnSE.UseVisualStyleBackColor = true;
            this.BtnSE.Click += new System.EventHandler(this.BtnSE_Click);
            // 
            // BtnSW
            // 
            this.BtnSW.Location = new System.Drawing.Point(4, 225);
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
            this.BtnAuto.Location = new System.Drawing.Point(58, 196);
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
            this.checkBox1.Location = new System.Drawing.Point(89, 141);
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
            this.textBox4.Size = new System.Drawing.Size(88, 22);
            this.textBox4.TabIndex = 18;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(72, 103);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 22);
            this.textBox5.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(1, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "目標緯度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(1, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "目標經度";
            // 
            // Set1Btn
            // 
            this.Set1Btn.Location = new System.Drawing.Point(172, 74);
            this.Set1Btn.Name = "Set1Btn";
            this.Set1Btn.Size = new System.Drawing.Size(62, 23);
            this.Set1Btn.TabIndex = 22;
            this.Set1Btn.Text = "定位座標";
            this.Set1Btn.UseVisualStyleBackColor = true;
            this.Set1Btn.Click += new System.EventHandler(this.Set1Btn_Click);
            // 
            // Set2Btn
            // 
            this.Set2Btn.Location = new System.Drawing.Point(240, 74);
            this.Set2Btn.Name = "Set2Btn";
            this.Set2Btn.Size = new System.Drawing.Size(61, 23);
            this.Set2Btn.TabIndex = 23;
            this.Set2Btn.Text = "導航座標";
            this.Set2Btn.UseVisualStyleBackColor = true;
            this.Set2Btn.Click += new System.EventHandler(this.Set2Btn_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(240, 105);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "Lock";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox2.Location = new System.Drawing.Point(37, 139);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(29, 20);
            this.comboBox2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "間隔";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(172, 48);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(130, 20);
            this.comboBox3.TabIndex = 27;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "道館巡航",
            "政大補給巡航",
            "北投公園巡航"});
            this.comboBox4.Location = new System.Drawing.Point(172, 138);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(129, 20);
            this.comboBox4.TabIndex = 28;
            // 
            // BtnPath
            // 
            this.BtnPath.Location = new System.Drawing.Point(172, 166);
            this.BtnPath.Name = "BtnPath";
            this.BtnPath.Size = new System.Drawing.Size(62, 23);
            this.BtnPath.TabIndex = 29;
            this.BtnPath.Text = "開始巡航";
            this.BtnPath.UseVisualStyleBackColor = true;
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(240, 171);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 30;
            this.checkBox3.Text = "停靠";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Location = new System.Drawing.Point(172, 196);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(62, 23);
            this.BtnPrev.TabIndex = 31;
            this.BtnPrev.Text = "前一目標";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(240, 196);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(61, 23);
            this.BtnNext.TabIndex = 32;
            this.BtnNext.Text = "下一目標";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 322);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.BtnPath);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.Set2Btn);
            this.Controls.Add(this.Set1Btn);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
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
        private System.Windows.Forms.Button Set1Btn;
        private System.Windows.Forms.Button Set2Btn;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button BtnPath;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnNext;
    }
}

