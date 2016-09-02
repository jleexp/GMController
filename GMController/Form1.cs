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
        decimal latSelected;
        decimal lngSelected;
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
            switch (comboBox1.SelectedIndex)
            {
                case 2:
                    //北投公園
                    latSelected = (decimal)25.136257;
                    lngSelected = (decimal)121.506297;
                    break;
                case 1:
                    //政大
                    latSelected = (decimal)24.986457;
                    lngSelected = (decimal)121.574303;
                    break;
                case 0:
                    //我家
                    latSelected = (decimal)24.990560;
                    lngSelected = (decimal)121.576179;
                    break;
                case 3:
                    //碧湖公園
                    latSelected = (decimal)25.082187;
                    lngSelected = (decimal)121.585623;
                    break;
                case 4:
                    //大湖公園
                    latSelected = (decimal)25.083320;
                    lngSelected = (decimal)121.601942;
                    break;
                case 5:
                    //逢甲公園
                    latSelected = (decimal)24.176785;
                    lngSelected = (decimal)120.640227;
                    break;
                case 6:
                    //前港公園
                    latSelected = (decimal)25.084933;
                    lngSelected = (decimal)121.520553;
                    break;
                case 7:
                    //青年公園
                    latSelected = (decimal)25.025426;
                    lngSelected = (decimal)121.506716;
                    break;
                case 8:
                    //南寮漁港
                    latSelected = (decimal)24.849308;
                    lngSelected = (decimal)120.928755;
                    break;
                case 9:
                    //信義區
                    latSelected = (decimal)25.036400;
                    lngSelected = (decimal)121.567165;
                    break;
                case 10:
                    //杏花林
                    latSelected = (decimal)24.969199;
                    lngSelected = (decimal)121.576663;
                    break;
                case 11:
                    //OVERLOOK DECK
                    latSelected = (decimal)24.970347;
                    lngSelected = (decimal)121.577785;
                    break;
                case 12:
                    //神奇大石龜
                    latSelected = (decimal)24.974221;
                    lngSelected = (decimal)121.574857;
                    break;
                case 13:
                    //聖恩宮
                    latSelected = (decimal)24.973455;
                    lngSelected = (decimal)121.569619;
                    break;
                case 14:
                    //政大研究總中心
                    latSelected = (decimal)24.979015;
                    lngSelected = (decimal)121.575183;
                    break;
                case 15:
                    //指南茶路石碑
                    latSelected = (decimal)24.979015;
                    lngSelected = (decimal)121.577195;
                    break;
                case 16:
                    //親水文學步道
                    latSelected = (decimal)24.985321;
                    lngSelected = (decimal)121.580413;
                    break;
                case 17:
                    //指南宮天門長廊
                    latSelected = (decimal)24.980339;
                    lngSelected = (decimal)121.587169;
                    break;
                case 18:
                    //指南宮纜車站
                    latSelected = (decimal)24.979023;
                    lngSelected = (decimal)121.589893;
                    break;
                case 19:
                    //指南宮大雄寶殿
                    latSelected = (decimal)24.978565;
                    lngSelected = (decimal)121.586923;
                    break;
                case 20:
                    //兩隻小鹿
                    latSelected = (decimal)24.971323;
                    lngSelected = (decimal)121.567771;
                    break;
                case 21:
                    //樟湖步道
                    latSelected = (decimal)24.965303;
                    lngSelected = (decimal)121.581481;
                    break;
                case 22:
                    //喵嗚
                    latSelected = (decimal)24.967299;
                    lngSelected = (decimal)121.587170;
                    break;
                case 23:
                    //貓空纜車站
                    latSelected = (decimal)24.968294;
                    lngSelected = (decimal)121.587819;
                    break;
                case 24:
                    //路標
                    latSelected = (decimal)24.966704;
                    lngSelected = (decimal)121.589388;
                    break;
                case 25:
                    //茶研發推廣中心*2
                    latSelected = (decimal)24.969249;
                    lngSelected = (decimal)121.594096;
                    break;
                case 26:
                    //銀河洞*2
                    latSelected = (decimal)24.958323;
                    lngSelected = (decimal)121.583281;
                    break;
                case 27:
                    //靈山媽祖廟*2
                    latSelected = (decimal)24.958871;
                    lngSelected = (decimal)121.580869;
                    break;
                case 28:
                    //福德宮
                    latSelected = (decimal)24.978328;
                    lngSelected = (decimal)121.563430;
                    break;
                case 29:
                    //銀河土地公
                    latSelected = (decimal)24.956907;
                    lngSelected = (decimal)121.575389;
                    break;
                case 30:
                    //儒釋道
                    latSelected = (decimal)24.972672;
                    lngSelected = (decimal)121.598248;
                    break;
                case 31:
                    //茗華園牌樓
                    latSelected = (decimal)24.970426;
                    lngSelected = (decimal)121.601473;
                    break;
                case 32:
                    //福德宮天公爐
                    latSelected = (decimal)24.970275;
                    lngSelected = (decimal)121.606985;
                    break;
                case 33:
                    //濟公禪師開示
                    latSelected = (decimal)24.978199;
                    lngSelected = (decimal)121.597492;
                    break;
                case 34:
                    //廣恩獅
                    latSelected = (decimal)24.955585;
                    lngSelected = (decimal)121.565262;
                    break;
                case 35:
                    //竹雲寺
                    latSelected = (decimal)24.949740;
                    lngSelected = (decimal)121.567416;
                    break;
                case 36:
                    //六份仔福德宮
                    latSelected = (decimal)24.950554;
                    lngSelected = (decimal)121.584998;
                    break;
                case 37:
                    //筆架山二格山路牌
                    latSelected = (decimal)24.969655;
                    lngSelected = (decimal)121.620569;
                    break;
                case 38:
                    //蔣公騎馬雕像
                    latSelected = (decimal)24.980059;
                    lngSelected = (decimal)121.569471;
                    break;
                case 39:
                    //大香山慈音巌
                    latSelected = (decimal)24.961442;
                    lngSelected = (decimal)121.560163;
                    break;
                case 40:
                    //被囚禁的變電箱
                    latSelected = (decimal)24.954271;
                    lngSelected = (decimal)121.559148;
                    break;
                case 41:
                    //新店福澤宮
                    latSelected = (decimal)24.953836;
                    lngSelected = (decimal)121.554643;
                    break;
                case 42:
                    //青潭竹林路口
                    latSelected = (decimal)24.951671;
                    lngSelected = (decimal)121.550707;
                    break;
                case 43:
                    //新店神召會
                    latSelected = (decimal)24.951537;
                    lngSelected = (decimal)121.547355;
                    break;
                case 44:
                    //喜如意餐廳
                    latSelected = (decimal)24.949574;
                    lngSelected = (decimal)121.545571;
                    break;
                case 45:
                    //名人鄉村小公園
                    latSelected = (decimal)24.957607;
                    lngSelected = (decimal)121.550053;
                    break;
                default:
                    break;
            }
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
            if (comboBox1.SelectedIndex == -1)
            {
                //MessageBox.Show("請先選擇地點!");
                textBox3.Text = "請先選擇地點!";
            }
            else
            {
                textBox1.Text = latSelected.ToString();
                textBox2.Text = lngSelected.ToString();
            }
        }

        private void Set2Btn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                //MessageBox.Show("請先選擇地點!");
                textBox3.Text = "請先選擇地點!";
            }
            else
            {
                textBox4.Text = latSelected.ToString();
                textBox5.Text = lngSelected.ToString();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            comboBox2.SelectedIndex = 2;
        }
    }
}
