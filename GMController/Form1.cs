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
            textBox3.Text = "Move N done.";
        }

        private void BtnWest_Click(object sender, EventArgs e)
        {
            MoveWest();
            textBox3.Text = "Move W done.";
        }

        private void BtnSouth_Click(object sender, EventArgs e)
        {
            MoveSouth();
            textBox3.Text = "Move S done.";
        }

        private void BtnEast_Click(object sender, EventArgs e)
        {
            MoveEast();
            textBox3.Text = "Move E done.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "25.136257";
            textBox2.Text = "121.506297";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string logFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace(@"\Roaming", "") + @"\Local\Genymobile\genymotion-shell.log";
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
            string arg = "-c \"gps setstatus enabled\"";
            RunGMShell(arg);
            arg = "-c \"gps setlatitude " + textBox1.Text + "\"";
            RunGMShell(arg);
            arg = "-c \"gps setlongitude " + textBox2.Text + "\"";
            RunGMShell(arg);
            arg = "-c \"gps setaccuracy 20\"";
            RunGMShell(arg);
            textBox3.Text = "初始化定位完成";
        }

        private void RunGMShell(string arg)
        {
            textBox3.Text = "";
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
            textBox3.Text = arg;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 2:
                    //北投公園
                    textBox1.Text = "25.136257";
                    textBox2.Text = "121.506297";
                    break;
                case 1:
                    //政大
                    textBox1.Text = "24.986457";
                    textBox2.Text = "121.574303";
                    break;
                case 0:
                    //我家
                    textBox1.Text = "24.990560";
                    textBox2.Text = "121.576179";
                    break;
                case 3:
                    //碧湖公園
                    textBox1.Text = "25.082187";
                    textBox2.Text = "121.585623";
                    break;
                case 4:
                    //大湖公園
                    textBox1.Text = "25.083767";
                    textBox2.Text = "121.602133";
                    break;
                case 5:
                    //逢甲公園
                    textBox1.Text = "24.176785";
                    textBox2.Text = "120.640227";
                    break;
                case 6:
                    //前港公園
                    textBox1.Text = "25.084933";
                    textBox2.Text = "121.520553";
                    break;
                case 7:
                    //梧棲漁港
                    textBox1.Text = "24.293521";
                    textBox2.Text = "120.521296";
                    break;
                case 8:
                    //南寮漁港
                    textBox1.Text = "24.849308";
                    textBox2.Text = "120.928755";
                    break;
                case 9:
                    //信義區
                    textBox1.Text = "25.036400";
                    textBox2.Text = "121.567165";
                    break;
                case 10:
                    //杏花林
                    textBox1.Text = "24.969199";
                    textBox2.Text = "121.576663";
                    break;
                case 11:
                    //OVERLOOK DECK
                    textBox4.Text = "24.970347";
                    textBox5.Text = "121.577785";
                    break;
                case 12:
                    //神奇大石龜
                    textBox1.Text = "24.974221";
                    textBox2.Text = "121.574857";
                    break;
                case 13:
                    //聖恩宮
                    textBox1.Text = "24.973455";
                    textBox2.Text = "121.569619";
                    break;
                case 14:
                    //政大研究總中心
                    textBox1.Text = "24.979015";
                    textBox2.Text = "121.575183";
                    break;
                case 15:
                    //指南茶路石碑
                    textBox1.Text = "24.979015";
                    textBox2.Text = "121.577195";
                    break;
                case 16:
                    //親水文學步道
                    textBox1.Text = "24.985321";
                    textBox2.Text = "121.580413";
                    break;
                case 17:
                    //指南宮天門長廊
                    textBox1.Text = "24.980339";
                    textBox2.Text = "121.587169";
                    break;
                case 18:
                    //指南宮纜車站
                    textBox1.Text = "24.979023";
                    textBox2.Text = "121.589893";
                    break;
                case 19:
                    //指南宮大雄寶殿
                    textBox1.Text = "24.978565";
                    textBox2.Text = "121.586923";
                    break;
                case 20:
                    //兩隻小鹿
                    textBox1.Text = "24.971323";
                    textBox2.Text = "121.567771";
                    break;
                case 21:
                    //樟湖步道
                    textBox1.Text = "24.965303";
                    textBox2.Text = "121.581481";
                    break;
                case 22:
                    //喵嗚
                    textBox1.Text = "24.967299";
                    textBox2.Text = "121.587170";
                    break;
                case 23:
                    //貓空纜車站
                    textBox1.Text = "24.968294";
                    textBox2.Text = "121.587819";
                    break;
                case 24:
                    //路標
                    textBox1.Text = "24.966704";
                    textBox2.Text = "121.589388";
                    break;
                case 25:
                    //茶研發推廣中心*2
                    textBox1.Text = "24.969249";
                    textBox2.Text = "121.594096";
                    break;
                case 26:
                    //銀河洞*2
                    textBox1.Text = "24.958323";
                    textBox2.Text = "121.583281";
                    break;
                case 27:
                    //靈山媽祖廟*2
                    textBox1.Text = "24.958871";
                    textBox2.Text = "121.580869";
                    break;
                default:
                    break;
            }
        }

        private void BtnNW_Click(object sender, EventArgs e)
        {
            MoveNorth();
            MoveWest();
            textBox3.Text = "Move NW done.";
        }

        private void BtnNE_Click(object sender, EventArgs e)
        {
            MoveNorth();
            MoveEast();
            textBox3.Text = "Move NE done.";
        }

        private void BtnSE_Click(object sender, EventArgs e)
        {
            MoveSouth();
            MoveEast();
            textBox3.Text = "Move SE done.";
        }

        private void BtnSW_Click(object sender, EventArgs e)
        {
            MoveSouth();
            MoveWest();
            textBox3.Text = "Move SW done.";
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
                if (checkBox1.Checked == true)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    System.Threading.Thread.Sleep(4000);
                }
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
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 2:
                    //北投公園
                    textBox4.Text = "25.136257";
                    textBox5.Text = "121.506297";
                    break;
                case 1:
                    //政大
                    textBox4.Text = "24.986457";
                    textBox5.Text = "121.574303";
                    break;
                case 0:
                    //我家
                    textBox4.Text = "24.990560";
                    textBox5.Text = "121.576179";
                    break;
                case 3:
                    //碧湖公園
                    textBox4.Text = "25.082187";
                    textBox5.Text = "121.585623";
                    break;
                case 4:
                    //大湖公園
                    textBox4.Text = "25.083767";
                    textBox5.Text = "121.602133";
                    break;
                case 5:
                    //逢甲公園
                    textBox4.Text = "24.176785";
                    textBox5.Text = "120.640227";
                    break;
                case 6:
                    //前港公園
                    textBox4.Text = "25.084933";
                    textBox5.Text = "121.520553";
                    break;
                case 7:
                    //梧棲漁港
                    textBox4.Text = "24.293521";
                    textBox5.Text = "120.521296";
                    break;
                case 8:
                    //南寮漁港
                    textBox4.Text = "24.849308";
                    textBox5.Text = "120.928755";
                    break;
                case 9:
                    //信義區
                    textBox4.Text = "25.036400";
                    textBox5.Text = "121.567165";
                    break;
                case 10:
                    //杏花林
                    textBox4.Text = "24.969199";
                    textBox5.Text = "121.576663";
                    break;
                case 11:
                    //OVERLOOK DECK
                    textBox4.Text = "24.970347";
                    textBox5.Text = "121.577785";
                    break;
                case 12:
                    //神奇大石龜
                    textBox4.Text = "24.974221";
                    textBox5.Text = "121.574857";
                    break;
                case 13:
                    //聖恩宮
                    textBox4.Text = "24.973455";
                    textBox5.Text = "121.569619";
                    break;
                case 14:
                    //政大研究總中心
                    textBox4.Text = "24.979015";
                    textBox5.Text = "121.575183";
                    break;
                case 15:
                    //指南茶路石碑
                    textBox4.Text = "24.979015";
                    textBox5.Text = "121.577195";
                    break;
                case 16:
                    //親水文學步道
                    textBox4.Text = "24.985321";
                    textBox5.Text = "121.580413";
                    break;
                case 17:
                    //指南宮天門長廊
                    textBox4.Text = "24.980339";
                    textBox5.Text = "121.587169";
                    break;
                case 18:
                    //指南宮纜車站
                    textBox4.Text = "24.979023";
                    textBox5.Text = "121.589893";
                    break;
                case 19:
                    //指南宮大雄寶殿
                    textBox4.Text = "24.978565";
                    textBox5.Text = "121.586923";
                    break;
                case 20:
                    //兩隻小鹿
                    textBox4.Text = "24.971323";
                    textBox5.Text = "121.567771";
                    break;
                case 21:
                    //樟湖步道
                    textBox4.Text = "24.965303";
                    textBox5.Text = "121.581481";
                    break;
                case 22:
                    //喵嗚
                    textBox4.Text = "24.967299";
                    textBox5.Text = "121.587170";
                    break;
                case 23:
                    //貓空纜車站
                    textBox4.Text = "24.968294";
                    textBox5.Text = "121.587819";
                    break;
                case 24:
                    //路標
                    textBox4.Text = "24.966704";
                    textBox5.Text = "121.589388";
                    break;
                case 25:
                    //茶研發推廣中心*2
                    textBox4.Text = "24.969249";
                    textBox5.Text = "121.594096";
                    break;
                case 26:
                    //銀河洞*2
                    textBox4.Text = "24.958323";
                    textBox5.Text = "121.583281";
                    break;
                case 27:
                    //靈山媽祖廟*2
                    textBox4.Text = "24.958871";
                    textBox5.Text = "121.580869";
                    break;
                default:
                    break;
            }
        }
    }
}
