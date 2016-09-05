using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace GMController
{
    public partial class Form1 : Form
    {
        Random Rnd = new Random();
        string GMShell = @"C:\Program Files\Genymobile\Genymotion\genyshell";
        //decimal latSelected;
        //decimal lngSelected;
        List<GeoSpot> list_GeoGym_MZ;          //木柵道館
        List<GeoSpot> list_GeoGym_XD;          //新店道館
        List<GeoSpot> list_GeoGym_SD;          //石碇道館
        List<GeoSpot> list_GeoSpot;
        public Form1()
        {
            InitializeComponent();
        }

        private void MoveNorth()
        {
            decimal lat = Convert.ToDecimal(textBox1.Text);
            decimal move = ((decimal)100 + (decimal)Rnd.Next(99)) / (decimal)1000000;
            if (checkBox1.Checked == true)
            {
                move = move * 2;
            }
            lat += move;
            textBox1.Text = lat.ToString();
            string arg = "-c \"gps setlatitude " + textBox1.Text + "\"";
            RunGMShell(arg);
        }

        private void MoveSouth()
        {
            decimal lat = Convert.ToDecimal(textBox1.Text);
            decimal move = ((decimal)100 + (decimal)Rnd.Next(99)) / (decimal)1000000;
            if (checkBox1.Checked == true)
            {
                move = move * 2;
            }
            lat -= move;
            textBox1.Text = lat.ToString();
            string arg = "-c \"gps setlatitude " + textBox1.Text + "\"";
            RunGMShell(arg);
        }

        private void MoveEast()
        {
            decimal lng = Convert.ToDecimal(textBox2.Text);
            decimal move = ((decimal)100 + (decimal)Rnd.Next(99)) / (decimal)1000000;
            if (checkBox1.Checked == true)
            {
                move = move * 2;
            }
            lng += move;
            textBox2.Text = lng.ToString();
            string arg = "-c \"gps setlongitude " + textBox2.Text + "\"";
            RunGMShell(arg);
        }

        private void MoveWest()
        {
            decimal lng = Convert.ToDecimal(textBox2.Text);
            decimal move = ((decimal)100 + (decimal)Rnd.Next(99)) / (decimal)1000000;
            if (checkBox1.Checked == true)
            {
                move = move * 2;
            }
            lng -= move;
            textBox2.Text = lng.ToString();
            string arg = "-c \"gps setlongitude " + textBox2.Text + "\"";
            RunGMShell(arg);
        }
        private void BtnNorth_Click(object sender, EventArgs e)
        {
            MoveNorth();
            //textBox3.Text = "Move N done.";
        }

        private void BtnWest_Click(object sender, EventArgs e)
        {
            MoveWest();
            //textBox3.Text = "Move W done.";
        }

        private void BtnSouth_Click(object sender, EventArgs e)
        {
            MoveSouth();
            //textBox3.Text = "Move S done.";
        }

        private void BtnEast_Click(object sender, EventArgs e)
        {
            MoveEast();
            //textBox3.Text = "Move E done.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string logFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace(@"\Roaming", "") + @"\Local\Genymobile\genymotion-shell.log";
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                //MessageBox.Show("請先定位座標!");
                textBox3.Text = "請先定位座標!";
            }
            else if (checkBox2.Checked == true)
            {
                //MessageBox.Show("已鎖定, 請先解除!");
                textBox3.Text = "已鎖定, 請先解除!";
            }
            else
            {
                string arg = "-c \"gps setstatus enabled\"";
                RunGMShell(arg);
                arg = "-c \"gps setlatitude " + textBox1.Text + "\"";
                RunGMShell(arg);
                arg = "-c \"gps setlongitude " + textBox2.Text + "\"";
                RunGMShell(arg);
                arg = "-c \"gps setaccuracy 20\"";
                RunGMShell(arg);
                checkBox2.Checked = true;
                textBox3.Text = "初始化定位完成";
            }
        }

        private void RunGMShell(string arg)
        {
            //textBox3.Text = "";
            ProcessStartInfo pinfo = new ProcessStartInfo();
            pinfo.FileName = GMShell;
            pinfo.Arguments = arg;
            pinfo.UseShellExecute = false;
            pinfo.CreateNoWindow = true;
            Process p = new Process();
            p.StartInfo = pinfo;
            p.EnableRaisingEvents = true;
            p.Start();
            p.WaitForExit();
            //textBox3.Text = arg;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxBind();
        }

        private void ComboBoxBind()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox3.DataSource = list_GeoSpot;
                    break;
                case 1:
                    comboBox3.DataSource = list_GeoGym_MZ;
                    break;
                case 2:
                    comboBox3.DataSource = list_GeoGym_XD;
                    break;
                case 3:
                    comboBox3.DataSource = list_GeoGym_SD;
                    break;
                default:
                    comboBox3.DataSource = list_GeoSpot;
                    break;
            }
            comboBox3.DisplayMember = "Name";
        }

        private void BtnNW_Click(object sender, EventArgs e)
        {
            MoveNorth();
            MoveWest();
            //textBox3.Text = "Move NW done.";
        }

        private void BtnNE_Click(object sender, EventArgs e)
        {
            MoveNorth();
            MoveEast();
            //textBox3.Text = "Move NE done.";
        }

        private void BtnSE_Click(object sender, EventArgs e)
        {
            MoveSouth();
            MoveEast();
            //textBox3.Text = "Move SE done.";
        }

        private void BtnSW_Click(object sender, EventArgs e)
        {
            MoveSouth();
            MoveWest();
            //textBox3.Text = "Move SW done.";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            decimal lat = 0;
            decimal lng = 0;
            decimal tlat = 0;
            decimal tlng = 0;
            decimal diff_lat = 0;
            decimal diff_lng = 0;
            decimal diff_max = 200;
            if (checkBox1.Checked == true)
            {
                //diff_max = 400;
            }
            do {
                lat = Convert.ToDecimal(textBox1.Text);
                tlat = Convert.ToDecimal(textBox4.Text);
                diff_lat = (tlat - lat) * 1000000;
                lng = Convert.ToDecimal(textBox2.Text);
                tlng = Convert.ToDecimal(textBox5.Text);
                diff_lng = (tlng - lng) * 1000000;
                if (Math.Abs(diff_lat) > diff_max)
                {
                    //296251        295371
                    if (diff_lat > 0)
                    {
                        MoveNorth();
                    }
                    else
                    {
                        MoveSouth();
                    }
                }
                if (Math.Abs(diff_lng) > diff_max)
                {
                    //518743    520430
                    if (diff_lng > 0)
                    {
                        MoveEast();
                    }
                    else
                    {
                        MoveWest();
                    }
                }
                int SleepTime = Convert.ToInt16(comboBox2.SelectedIndex) * 1000;
                System.Threading.Thread.Sleep(SleepTime);
            } while ((Math.Abs(diff_lat) > diff_max || Math.Abs(diff_lng) > diff_max) && backgroundWorker1.CancellationPending == false);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                textBox3.Text = "自動導航停止";
            }
            else
            {
                textBox3.Text = "到達目的地";
            }
            BtnAuto.Text = "Start";
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                BtnAuto.Text = "Stop";
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                BtnAuto.Text = "Start";
                backgroundWorker1.CancelAsync();
            }
            textBox3.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Set1Btn_Click(object sender, EventArgs e)
        {
            GeoSpot spotSelected = comboBox3.SelectedItem as GeoSpot;
            textBox1.Text = spotSelected.Latitue.ToString();
            textBox2.Text = spotSelected.Longitude.ToString();
        }

        private void Set2Btn_Click(object sender, EventArgs e)
        {
            GeoSpot spotSelected = comboBox3.SelectedItem as GeoSpot;
            textBox4.Text = spotSelected.Latitue.ToString();
            textBox5.Text = spotSelected.Longitude.ToString();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            comboBox2.SelectedIndex = 2;
            comboBox1.SelectedIndex = 0;
            ComboBoxBind();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //設定景點
            list_GeoSpot = new List<GeoSpot>()
            {
                new GeoSpot { Name = "政大", Latitue = (decimal)24.986457, Longitude = (decimal)121.574303 },
                new GeoSpot { Name = "信義區", Latitue = (decimal)25.036400, Longitude = (decimal)121.567165 },
                new GeoSpot { Name = "北投公園", Latitue = (decimal)25.136257, Longitude = (decimal)121.506297 },
                new GeoSpot { Name = "碧湖公園", Latitue = (decimal)25.082187, Longitude = (decimal)121.585623 },
                new GeoSpot { Name = "大湖公園", Latitue = (decimal)25.083320, Longitude = (decimal)121.601942 },
                new GeoSpot { Name = "逢甲公園", Latitue = (decimal)24.176785, Longitude = (decimal)120.640227 },
                new GeoSpot { Name = "青年公園", Latitue = (decimal)25.025426, Longitude = (decimal)121.506716 },
                new GeoSpot { Name = "南寮漁港", Latitue = (decimal)24.849308, Longitude = (decimal)120.928755 },
            };
            //設定木柵道館
            list_GeoGym_MZ = new List<GeoSpot>()
            {
                new GeoSpot { Name = "杏花林", Latitue = (decimal)24.969199, Longitude = (decimal)121.576663 },
                new GeoSpot { Name = "OVERLOOK DECK", Latitue = (decimal)24.970347, Longitude = (decimal)121.577785 },
                new GeoSpot { Name = "神奇大石龜", Latitue = (decimal)24.974221, Longitude = (decimal)121.574857 },
                new GeoSpot { Name = "聖恩宮", Latitue = (decimal)24.973455, Longitude = (decimal)121.569619 },
                new GeoSpot { Name = "政大研究總中心", Latitue = (decimal)24.979015, Longitude = (decimal)121.575183 },
                new GeoSpot { Name = "指南茶路石碑", Latitue = (decimal)24.979015, Longitude = (decimal)121.577195 },
                new GeoSpot { Name = "親水文學步道", Latitue = (decimal)24.985321, Longitude = (decimal)121.580413 },
                new GeoSpot { Name = "指南宮天門長廊", Latitue = (decimal)24.980339, Longitude = (decimal)121.587169 },
                new GeoSpot { Name = "指南宮纜車站", Latitue = (decimal)24.979023, Longitude = (decimal)121.589893 },
                new GeoSpot { Name = "指南宮大雄寶殿", Latitue = (decimal)24.978565, Longitude = (decimal)121.586923 },
                new GeoSpot { Name = "兩隻小鹿", Latitue = (decimal)24.971323, Longitude = (decimal)121.567771 },
                new GeoSpot { Name = "樟湖步道", Latitue = (decimal)24.965303, Longitude = (decimal)121.581481 },
                new GeoSpot { Name = "喵嗚", Latitue = (decimal)24.967299, Longitude = (decimal)121.587170 },
                new GeoSpot { Name = "貓空纜車站", Latitue = (decimal)24.968294, Longitude = (decimal)121.587819 },
                new GeoSpot { Name = "路標", Latitue = (decimal)24.966704, Longitude = (decimal)121.589388 },
                new GeoSpot { Name = "茶研發推廣中心*2", Latitue = (decimal)24.969249, Longitude = (decimal)121.594096 },
                new GeoSpot { Name = "福德宮", Latitue = (decimal)24.978328, Longitude = (decimal)121.563430 },
                new GeoSpot { Name = "儒釋道", Latitue = (decimal)24.972672, Longitude = (decimal)121.598248 },
                new GeoSpot { Name = "茗華園牌樓", Latitue = (decimal)24.970426, Longitude = (decimal)121.601473 },
                new GeoSpot { Name = "福德宮天公爐", Latitue = (decimal)24.970275, Longitude = (decimal)121.606985 },
                new GeoSpot { Name = "濟公禪師開示", Latitue = (decimal)24.978199, Longitude = (decimal)121.597492 },
                new GeoSpot { Name = "蔣公騎馬雕像", Latitue = (decimal)24.980059, Longitude = (decimal)121.569471 },
            };
            //設定新店道館
            list_GeoGym_XD = new List<GeoSpot>()
            {
                new GeoSpot { Name = "銀河洞*2", Latitue = (decimal)24.958323, Longitude = (decimal)121.583281 },
                new GeoSpot { Name = "靈山媽祖廟*2", Latitue = (decimal)24.958871, Longitude = (decimal)121.580869 },
                new GeoSpot { Name = "銀河土地公", Latitue = (decimal)24.956907, Longitude = (decimal)121.575389 },
                new GeoSpot { Name = "廣恩獅", Latitue = (decimal)24.955585, Longitude = (decimal)121.565262 },
                new GeoSpot { Name = "竹雲寺", Latitue = (decimal)24.949740, Longitude = (decimal)121.567416 },
                new GeoSpot { Name = "大香山慈音巌", Latitue = (decimal)24.961442, Longitude = (decimal)121.560163 },
                new GeoSpot { Name = "被囚禁的變電箱", Latitue = (decimal)24.954271, Longitude = (decimal)121.559148 },
                new GeoSpot { Name = "新店福澤宮", Latitue = (decimal)24.953836, Longitude = (decimal)121.554643 },
                new GeoSpot { Name = "青潭竹林路口", Latitue = (decimal)24.951671, Longitude = (decimal)121.550707 },
                new GeoSpot { Name = "新店神召會", Latitue = (decimal)24.951537, Longitude = (decimal)121.547355 },
                new GeoSpot { Name = "喜如意餐廳", Latitue = (decimal)24.949574, Longitude = (decimal)121.545571 },
                new GeoSpot { Name = "名人鄉村小公園", Latitue = (decimal)24.957607, Longitude = (decimal)121.550053 },
                new GeoSpot { Name = "李合豐銅像", Latitue = (decimal)24.945348, Longitude = (decimal)121.546019 },
                new GeoSpot { Name = "GE00變電箱", Latitue = (decimal)24.935384, Longitude = (decimal)121.545098 },
                new GeoSpot { Name = "雙流溜滑梯", Latitue = (decimal)24.934948, Longitude = (decimal)121.541722 },
                new GeoSpot { Name = "蔡依林限量瓶", Latitue = (decimal)24.938577, Longitude = (decimal)121.543427 },
                new GeoSpot { Name = "感恩橋修建誌", Latitue = (decimal)24.938054, Longitude = (decimal)121.541862 },
                new GeoSpot { Name = "貓巡坑土地公", Latitue = (decimal)24.936595, Longitude = (decimal)121.536152 },
                new GeoSpot { Name = "桂林山水", Latitue = (decimal)24.942480, Longitude = (decimal)121.533392 },
                new GeoSpot { Name = "青潭58號基石", Latitue = (decimal)24.947923, Longitude = (decimal)121.534513 },
                new GeoSpot { Name = "和美山步道", Latitue = (decimal)24.952003, Longitude = (decimal)121.534050 },
                new GeoSpot { Name = "潭之鄉涼亭", Latitue = (decimal)24.950137, Longitude = (decimal)121.528974 },
                new GeoSpot { Name = "風月老人休息區", Latitue = (decimal)24.949237, Longitude = (decimal)121.529628 },
            };
            //設定石碇道館
            list_GeoGym_SD = new List<GeoSpot>()
            {
                new GeoSpot { Name = "筆架山二格山路牌", Latitue = (decimal)24.969655, Longitude = (decimal)121.620569 },
                new GeoSpot { Name = "六份仔福德宮", Latitue = (decimal)24.950554, Longitude = (decimal)121.584998 },
                new GeoSpot { Name = "蕃薯坑福德正神", Latitue = (decimal)24.958805, Longitude = (decimal)121.610064 },
                new GeoSpot { Name = "二格公園", Latitue = (decimal)24.957894, Longitude = (decimal)121.623222 },
                new GeoSpot { Name = "正襟危坐看風景", Latitue = (decimal)24.962996, Longitude = (decimal)121.624876 },
                new GeoSpot { Name = "石碇大茶壺", Latitue = (decimal)24.953190, Longitude = (decimal)121.633768 },
                new GeoSpot { Name = "雲海國小", Latitue = (decimal)24.952906, Longitude = (decimal)121.635204 },
                new GeoSpot { Name = "生活咖啡吧", Latitue = (decimal)24.957972, Longitude = (decimal)121.639176 },
            };
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
    public class GeoSpot
    {
        public string Name { get; set; }
        public decimal Latitue { get; set; }
        public decimal Longitude { get; set; }
    }
}
