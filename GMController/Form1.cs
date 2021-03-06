﻿using System;
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
        List<GeoSpot> list_GeoGym_MZ;           //木柵道館
        List<GeoSpot> list_GeoGym_XD;           //新店道館
        List<GeoSpot> list_GeoGym_SD;           //石碇道館
        List<GeoSpot> list_GeoSpot;
        List<GeoSpot> list_GeoPath;             //巡航路徑
        bool bIsPatrol = false;                 //巡航執行中
        int iPatrolIdx = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //移動距離
        private decimal getDistance()
        {
            decimal Distance = 0;
            Distance = ((decimal)100 + (decimal)Rnd.Next(99)) / (decimal)1000000;
            // Fast Mode
            if (checkBox1.Checked == true)
            {
                Distance = Distance * 2;
            }
            return Distance;
        }

        //設定 GenyMotion 座標
        private void setGPS(decimal latitude, decimal longitude)
        {
            string sFileName = Path.GetTempPath() + Path.GetRandomFileName().Replace(".", "");
            string arg = "";
            if (latitude > 0 && longitude > 0)
            {
                textBox1.Text = latitude.ToString();
                textBox2.Text = longitude.ToString();
                StreamWriter fw = new StreamWriter(sFileName);
                fw.WriteLine("gps setlatitude " + textBox1.Text);
                fw.WriteLine("gps setlongitude " + textBox2.Text);
                fw.Close();
                arg = "-f \"" + sFileName + "\"";
            } else if (latitude > 0 && longitude == 0)
            {
                textBox1.Text = latitude.ToString();
                arg = "-c \"gps setlatitude " + textBox1.Text + "\"";
            } else if (longitude > 0 && latitude == 0)
            {
                textBox2.Text = longitude.ToString();
                arg = "-c \"gps setlongitude " + textBox2.Text + "\"";
            }
            if (!string.IsNullOrEmpty(arg))
            {
                RunGMShell(arg);
            }

            if (File.Exists(sFileName))
            {
                File.Delete(sFileName);
            }
        }

        //初始化定位
        private void initGPS()
        {
            string sFileName = Path.GetTempPath() + Path.GetRandomFileName().Replace(".", "");
            string arg = "";
            
            StreamWriter fw = new StreamWriter(sFileName);
            fw.WriteLine("gps setstatus enabled");
            fw.WriteLine("gps setlatitude " + textBox1.Text);
            fw.WriteLine("gps setlongitude " + textBox2.Text);
            fw.WriteLine("gps setaccuracy 20");
            fw.Close();
            arg = "-f \"" + sFileName + "\"";

            RunGMShell(arg);
            
            if (File.Exists(sFileName))
            {
                File.Delete(sFileName);
            }
        }

        //執行 GenyMotion Shell
        private void RunGMShell(string arg)
        {
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
        }

        private void MoveNorth()
        {
            decimal move = getDistance();
            decimal lat = Convert.ToDecimal(textBox1.Text) + move;
            setGPS(lat, 0);
        }

        private void MoveSouth()
        {
            decimal move = getDistance();
            decimal lat = Convert.ToDecimal(textBox1.Text) - move;
            setGPS(lat, 0);
        }

        private void MoveEast()
        {
            decimal move = getDistance();
            decimal lng = Convert.ToDecimal(textBox2.Text) + move;
            setGPS(0, lng);
        }

        private void MoveWest()
        {
            decimal move = getDistance();
            decimal lng = Convert.ToDecimal(textBox2.Text) - move;
            setGPS(0, lng);
        }

        private void MoveNorthWest()
        {
            decimal move = getDistance();
            decimal lng = Convert.ToDecimal(textBox2.Text) - move;
            decimal lat = Convert.ToDecimal(textBox1.Text) + move;
            setGPS(lat, lng);
        }

        private void MoveSouthWest()
        {
            decimal move = getDistance();
            decimal lng = Convert.ToDecimal(textBox2.Text) - move;
            decimal lat = Convert.ToDecimal(textBox1.Text) - move;
            setGPS(lat, lng);
        }

        private void MoveNorthEast()
        {
            decimal move = getDistance();
            decimal lng = Convert.ToDecimal(textBox2.Text) + move;
            decimal lat = Convert.ToDecimal(textBox1.Text) + move;
            setGPS(lat, lng);
        }

        private void MoveSouthEast()
        {
            decimal move = getDistance();
            decimal lng = Convert.ToDecimal(textBox2.Text) + move;
            decimal lat = Convert.ToDecimal(textBox1.Text) - move;
            setGPS(lat, lng);
        }

        private void BtnNorth_Click(object sender, EventArgs e)
        {
            MoveNorth();
        }

        private void BtnWest_Click(object sender, EventArgs e)
        {
            MoveWest();
        }

        private void BtnSouth_Click(object sender, EventArgs e)
        {
            MoveSouth();
        }

        private void BtnEast_Click(object sender, EventArgs e)
        {
            MoveEast();
        }

        private void BtnNW_Click(object sender, EventArgs e)
        {
            MoveNorthWest();
        }

        private void BtnNE_Click(object sender, EventArgs e)
        {
            MoveNorthEast();
        }

        private void BtnSE_Click(object sender, EventArgs e)
        {
            MoveSouthEast();
        }

        private void BtnSW_Click(object sender, EventArgs e)
        {
            MoveSouthWest();
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
                textBox3.Text = "請先定位座標!";
            }
            else if (checkBox2.Checked == true)
            {
                textBox3.Text = "已鎖定, 請先解除!";
            }
            else
            {
                initGPS();
                checkBox2.Checked = true;
                textBox3.Text = "初始定位完成";
            }
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            decimal lat = 0;            //Current
            decimal lng = 0;            //Current
            decimal tlat = 0;           //Target
            decimal tlng = 0;           //Target
            decimal slat = 0;           //Set to
            decimal slng = 0;           //Set to
            decimal distance = 0;
            decimal diff_lat = 0;
            decimal diff_lng = 0;
            decimal diff_max = 200;

            do {
                distance = getDistance();
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
                        slat = lat + distance;
                    }
                    else
                    {
                        slat = lat - distance;
                    }
                }
                else
                {
                    slat = 0;
                }
                if (Math.Abs(diff_lng) > diff_max)
                {
                    //518743    520430
                    if (diff_lng > 0)
                    {
                        slng = lng + distance;
                    }
                    else
                    {
                        slng = lng - distance;
                    }
                }
                else
                {
                    slng = 0;
                }
                if (slat > 0 || slng > 0)
                {
                    setGPS(slat, slng);
                    int SleepTime = Convert.ToInt16(comboBox2.SelectedIndex) * 1000;
                    System.Threading.Thread.Sleep(SleepTime);
                }
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
            } while ((Math.Abs(diff_lat) > diff_max || Math.Abs(diff_lng) > diff_max));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                textBox3.Text = "自動導航停止";
            }
            else
            {
                setGPS(Convert.ToDecimal(textBox4.Text), Convert.ToDecimal(textBox5.Text));
                if (bIsPatrol)
                {
                    textBox3.Text = "到達" + list_GeoPath[iPatrolIdx].Name + Environment.NewLine;
                    iPatrolIdx++;
                    if (iPatrolIdx == list_GeoPath.Count)
                    {
                        iPatrolIdx = 0;
                    }
                    textBox3.AppendText("下一個目的地是" + list_GeoPath[iPatrolIdx].Name);
                    textBox4.Text = list_GeoPath[iPatrolIdx].Latitue.ToString();
                    textBox5.Text = list_GeoPath[iPatrolIdx].Longitude.ToString();
                    if (checkBox3.Checked == false)
                    {
                        BtnAuto.PerformClick();
                        return;
                    }
                }
                else
                {
                    textBox3.Text = "到達目的地";
                }
            }
            BtnAuto.Text = "Start";
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                textBox3.Text = "請先設定導航目標!";
                return;
            }
            if (backgroundWorker1.IsBusy != true)
            {
                BtnAuto.Text = "Stop";
                backgroundWorker1.RunWorkerAsync();
                if (bIsPatrol)
                {
                    textBox3.Text = "自動巡航開始, 往" + list_GeoPath[iPatrolIdx].Name + "前進。";
                }
                else
                {
                    textBox3.Text = "自動導航開始";
                }
            }
            else
            {
                BtnAuto.Text = "Start";
                backgroundWorker1.CancelAsync();
            }
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
            comboBox4.SelectedIndex = 0;
            checkBox3.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //設定景點
            list_GeoSpot = new List<GeoSpot>()
            {
                new GeoSpot { Name = "政大", Latitue = (decimal)24.986457, Longitude = (decimal)121.574303 },
                new GeoSpot { Name = "信義區", Latitue = (decimal)25.036401, Longitude = (decimal)121.567165 },
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
                new GeoSpot { Name = "隱修院", Latitue = (decimal)24.988574, Longitude = (decimal)121.621379 },
                new GeoSpot { Name = "大吉嶺步道導覽圖", Latitue = (decimal)24.983498, Longitude = (decimal)121.614809 },
                new GeoSpot { Name = "伴山農莊", Latitue = (decimal)24.987938, Longitude = (decimal)121.605146 },

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

        private void BtnPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                textBox3.Text = "請先定位座標!";
                return;
            }
            if (bIsPatrol == false)
            {
                if (backgroundWorker1.IsBusy)
                {
                    textBox3.Text = "自動導航執行中, 請先停止導航!";
                    return;
                }
                if (comboBox4.SelectedIndex == 0)
                {
                    list_GeoPath = new List<GeoSpot>()
                    {
                        new GeoSpot { Name = "蕃薯坑福德正神", Latitue = (decimal)24.958805, Longitude = (decimal)121.610064 },
                        new GeoSpot { Name = "二格公園", Latitue = (decimal)24.957894, Longitude = (decimal)121.623222 },
                        new GeoSpot { Name = "正襟危坐看風景", Latitue = (decimal)24.962996, Longitude = (decimal)121.624876 },
                        new GeoSpot { Name = "筆架山二格山路牌", Latitue = (decimal)24.969655, Longitude = (decimal)121.620569 },
                        new GeoSpot { Name = "隱修院", Latitue = (decimal)24.988574, Longitude = (decimal)121.621379 },
                        new GeoSpot { Name = "大吉嶺步道導覽圖", Latitue = (decimal)24.983498, Longitude = (decimal)121.614809 },
                        new GeoSpot { Name = "伴山農莊", Latitue = (decimal)24.987938, Longitude = (decimal)121.605146 },
                        new GeoSpot { Name = "濟公禪師開示", Latitue = (decimal)24.978199, Longitude = (decimal)121.597492 },
                        new GeoSpot { Name = "福德宮天公爐", Latitue = (decimal)24.970275, Longitude = (decimal)121.606985 },
                        new GeoSpot { Name = "茗華園牌樓", Latitue = (decimal)24.970426, Longitude = (decimal)121.601473 },
                        new GeoSpot { Name = "儒釋道", Latitue = (decimal)24.972672, Longitude = (decimal)121.598248 },
                        new GeoSpot { Name = "茶研發推廣中心*2", Latitue = (decimal)24.969249, Longitude = (decimal)121.594096 },
                        new GeoSpot { Name = "路標", Latitue = (decimal)24.966704, Longitude = (decimal)121.589388 },
                        new GeoSpot { Name = "喵嗚", Latitue = (decimal)24.967299, Longitude = (decimal)121.587170 },
                        new GeoSpot { Name = "樟湖步道", Latitue = (decimal)24.965303, Longitude = (decimal)121.581481 },
                        new GeoSpot { Name = "杏花林", Latitue = (decimal)24.969199, Longitude = (decimal)121.576663 },
                        new GeoSpot { Name = "神奇大石龜", Latitue = (decimal)24.974221, Longitude = (decimal)121.574857 },
                        new GeoSpot { Name = "聖恩宮", Latitue = (decimal)24.973455, Longitude = (decimal)121.569619 },
                        new GeoSpot { Name = "兩隻小鹿", Latitue = (decimal)24.971323, Longitude = (decimal)121.567771 },
                        new GeoSpot { Name = "政大研究總中心", Latitue = (decimal)24.979015, Longitude = (decimal)121.575183 },
                        new GeoSpot { Name = "指南茶路石碑", Latitue = (decimal)24.979015, Longitude = (decimal)121.577195 },
                        new GeoSpot { Name = "指南宮天門長廊", Latitue = (decimal)24.980339, Longitude = (decimal)121.587169 },
                        new GeoSpot { Name = "指南宮大雄寶殿", Latitue = (decimal)24.978565, Longitude = (decimal)121.586923 },
                    };
                }
                else if (comboBox4.SelectedIndex == 1)
                {
                    list_GeoPath = new List<GeoSpot>()
                    {
                        new GeoSpot { Name = "羅馬廣場01", Latitue = (decimal)24.986283, Longitude = (decimal)121.574129 },
                        new GeoSpot { Name = "羅馬廣場02", Latitue = (decimal)24.986114, Longitude = (decimal)121.573836 },
                        new GeoSpot { Name = "田徑場", Latitue = (decimal)24.985261, Longitude = (decimal)121.574363 },
                        new GeoSpot { Name = "八角亭", Latitue = (decimal)24.985478, Longitude = (decimal)121.574907 },
                        new GeoSpot { Name = "行政大樓", Latitue = (decimal)24.986731, Longitude = (decimal)121.575549 },
                        new GeoSpot { Name = "志希樓", Latitue = (decimal)24.986616, Longitude = (decimal)121.576200 },
                        new GeoSpot { Name = "中正圖書館", Latitue = (decimal)24.986394, Longitude = (decimal)121.576939 },
                        new GeoSpot { Name = "憩賢樓", Latitue = (decimal)24.985857, Longitude = (decimal)121.577226 },
                        new GeoSpot { Name = "北政國中", Latitue = (decimal)24.985112, Longitude = (decimal)121.578682 },
                        new GeoSpot { Name = "教育學院", Latitue = (decimal)24.985782, Longitude = (decimal)121.578682 },
                        new GeoSpot { Name = "六然居", Latitue = (decimal)24.985782, Longitude = (decimal)121.579598 },
                        new GeoSpot { Name = "澄館", Latitue = (decimal)24.984814, Longitude = (decimal)121.579740 },
                        new GeoSpot { Name = "和墅", Latitue = (decimal)24.985311, Longitude = (decimal)121.582058 },
                        new GeoSpot { Name = "山坡", Latitue = (decimal)24.985579, Longitude = (decimal)121.582452 },
                        new GeoSpot { Name = "政大藝境", Latitue = (decimal)24.986344, Longitude = (decimal)121.583481 },
                        new GeoSpot { Name = "日出大地", Latitue = (decimal)24.987140, Longitude = (decimal)121.583647 },
                        new GeoSpot { Name = "政大附中後門", Latitue = (decimal)24.988062, Longitude = (decimal)121.584039 },
                        new GeoSpot { Name = "政大附中", Latitue = (decimal)24.987473, Longitude = (decimal)121.585101 },
                        new GeoSpot { Name = "政大附中校門", Latitue = (decimal)24.987473, Longitude = (decimal)121.585782 },
                        new GeoSpot { Name = "綠野山莊", Latitue = (decimal)24.987104, Longitude = (decimal)121.587527 },
                        new GeoSpot { Name = "Zoo藝術裝置", Latitue = (decimal)24.989908, Longitude = (decimal)121.586286 },
                        new GeoSpot { Name = "夏木漱石", Latitue = (decimal)24.989437, Longitude = (decimal)121.584692 },
                        new GeoSpot { Name = "醇心找茶", Latitue = (decimal)24.989072, Longitude = (decimal)121.578729 },
                        new GeoSpot { Name = "萬興", Latitue = (decimal)24.989130, Longitude = (decimal)121.577019 },
                        new GeoSpot { Name = "名人錄", Latitue = (decimal)24.989130, Longitude = (decimal)121.575852 },
                        new GeoSpot { Name = "奇異果", Latitue = (decimal)24.989285, Longitude = (decimal)121.575188 },
                        new GeoSpot { Name = "麥側", Latitue = (decimal)24.988001, Longitude = (decimal)121.575006 },
                        new GeoSpot { Name = "政大書城", Latitue = (decimal)24.987350, Longitude = (decimal)121.574680 },
                    };
                }
                else if (comboBox4.SelectedIndex == 2)
                {
                    list_GeoPath = new List<GeoSpot>()
                    {
                        new GeoSpot { Name = "北投圖書館", Latitue = (decimal)25.136256, Longitude = (decimal)121.506298 },
                        new GeoSpot { Name = "溫泉博物館", Latitue = (decimal)25.136585, Longitude = (decimal)121.507087 },
                        new GeoSpot { Name = "溫泉煙霧迷宮", Latitue = (decimal)25.137146, Longitude = (decimal)121.507968 },
                        new GeoSpot { Name = "溫泉澡堂", Latitue = (decimal)25.137140, Longitude = (decimal)121.508636 },
                        new GeoSpot { Name = "獨眼史萊姆", Latitue = (decimal)25.137352, Longitude = (decimal)121.509232 },
                        new GeoSpot { Name = "樂園涼亭", Latitue = (decimal)25.136922, Longitude = (decimal)121.507026 },
                        new GeoSpot { Name = "凱達格蘭壁畫", Latitue = (decimal)25.136922, Longitude = (decimal)121.506268 },
                        new GeoSpot { Name = "Lotus Box", Latitue = (decimal)25.136795, Longitude = (decimal)121.504822 },
                        new GeoSpot { Name = "捷運新北投站", Latitue = (decimal)25.136774, Longitude = (decimal)121.503523 },
                        new GeoSpot { Name = "Global Box", Latitue = (decimal)25.136088, Longitude = (decimal)121.503337 },
                        new GeoSpot { Name = "北投地標", Latitue = (decimal)25.136185, Longitude = (decimal)121.504212 },
                        new GeoSpot { Name = "櫻花變電箱", Latitue = (decimal)25.136013, Longitude = (decimal)121.505131 },
                        new GeoSpot { Name = "綠園裝飾品", Latitue = (decimal)25.135584, Longitude = (decimal)121.505784 },
                    };
                }
                else if (comboBox4.SelectedIndex == 3)
                {
                    list_GeoPath = new List<GeoSpot>()
                    {
                        new GeoSpot { Name = "就只是一條路", Latitue = (decimal)25.025426, Longitude = (decimal)121.506600 },
                        new GeoSpot { Name = "高方塔", Latitue = (decimal)25.025606, Longitude = (decimal)121.505966 },
                        new GeoSpot { Name = "健康步道", Latitue = (decimal)25.025312, Longitude = (decimal)121.504840 },
                        new GeoSpot { Name = "西北門", Latitue = (decimal)25.025118, Longitude = (decimal)121.504123 },
                        new GeoSpot { Name = "天使花盆", Latitue = (decimal)25.024512, Longitude = (decimal)121.504251 },
                        new GeoSpot { Name = "停車場入口", Latitue = (decimal)25.024258, Longitude = (decimal)121.503655 },
                        new GeoSpot { Name = "彩色玻璃藝術", Latitue = (decimal)25.023892, Longitude = (decimal)121.502974 },
                        new GeoSpot { Name = "百合亭", Latitue = (decimal)25.023392, Longitude = (decimal)121.502860 },
                        new GeoSpot { Name = "民族亭", Latitue = (decimal)25.022452, Longitude = (decimal)121.503293 },
                        new GeoSpot { Name = "方尖遊樂場", Latitue = (decimal)25.021800, Longitude = (decimal)121.502801 },
                        new GeoSpot { Name = "花鐘彩繪", Latitue = (decimal)25.021432, Longitude = (decimal)121.502654 },
                        new GeoSpot { Name = "苗圃", Latitue = (decimal)25.021048, Longitude = (decimal)121.503546 },
                        new GeoSpot { Name = "造形屋頂", Latitue = (decimal)25.020656, Longitude = (decimal)121.503546 },
                        new GeoSpot { Name = "南角", Latitue = (decimal)25.020433, Longitude = (decimal)121.504414 },
                        new GeoSpot { Name = "數喔", Latitue = (decimal)25.020841, Longitude = (decimal)121.504988 },
                        new GeoSpot { Name = "方向石碑", Latitue = (decimal)25.021456, Longitude = (decimal)121.505440 },
                        new GeoSpot { Name = "蔣介石", Latitue = (decimal)25.022164, Longitude = (decimal)121.505593 },
                        new GeoSpot { Name = "810", Latitue = (decimal)25.021608, Longitude = (decimal)121.504752 },
                        new GeoSpot { Name = "古樹亭", Latitue = (decimal)25.021861, Longitude = (decimal)121.504113 },
                        new GeoSpot { Name = "794", Latitue = (decimal)25.022459, Longitude = (decimal)121.504711 },
                        new GeoSpot { Name = "771", Latitue = (decimal)25.023178, Longitude = (decimal)121.505747 },
                        new GeoSpot { Name = "游泳池", Latitue = (decimal)25.023178, Longitude = (decimal)121.506174 },
                        new GeoSpot { Name = "羅比親王海棗", Latitue = (decimal)25.022808, Longitude = (decimal)121.506824 },
                        new GeoSpot { Name = "西南角", Latitue = (decimal)25.022808, Longitude = (decimal)121.507356 },
                        new GeoSpot { Name = "三花點1", Latitue = (decimal)25.024508, Longitude = (decimal)121.506974 },
                        new GeoSpot { Name = "三花點2", Latitue = (decimal)25.024935, Longitude = (decimal)121.507709 },
                    };
                }
                else if (comboBox4.SelectedIndex == 4)
                {
                    list_GeoPath = new List<GeoSpot>()
                    {
                        new GeoSpot { Name = "旅遊服務中心", Latitue = (decimal)24.849422, Longitude = (decimal)120.928641 },
                        new GeoSpot { Name = "俄式鐘樓2", Latitue = (decimal)24.850101, Longitude = (decimal)120.929320 },
                        new GeoSpot { Name = "和平鐘", Latitue = (decimal)24.850908, Longitude = (decimal)120.929340 },
                        new GeoSpot { Name = "俄式鐘樓3", Latitue = (decimal)24.850361, Longitude = (decimal)120.930044 },
                        new GeoSpot { Name = "彩虹橋", Latitue = (decimal)24.849123, Longitude = (decimal)120.930629 },
                        new GeoSpot { Name = "木馬病毒", Latitue = (decimal)24.847693, Longitude = (decimal)120.930134 },
                        new GeoSpot { Name = "海之女神", Latitue = (decimal)24.848098, Longitude = (decimal)120.929479 },
                        new GeoSpot { Name = "地中海一號", Latitue = (decimal)24.848695, Longitude = (decimal)120.929583 },
                        new GeoSpot { Name = "三山國王", Latitue = (decimal)24.848421, Longitude = (decimal)120.928889 },
                        new GeoSpot { Name = "大水塔", Latitue = (decimal)24.848722, Longitude = (decimal)120.928889 },
                        new GeoSpot { Name = "俄式鐘樓1", Latitue = (decimal)24.849130, Longitude = (decimal)120.928333 },
                        new GeoSpot { Name = "貝殼公園", Latitue = (decimal)24.850759, Longitude = (decimal)120.928303 },
                    };
                }
                else if (comboBox4.SelectedIndex == 5)
                {
                    list_GeoPath = new List<GeoSpot>()
                    {
                        new GeoSpot { Name = "旅遊服務中心", Latitue = (decimal)24.849422, Longitude = (decimal)120.928641 },
                        new GeoSpot { Name = "俄式鐘樓2", Latitue = (decimal)24.850101, Longitude = (decimal)120.929320 },
                        new GeoSpot { Name = "和平鐘", Latitue = (decimal)24.850908, Longitude = (decimal)120.929340 },
                        new GeoSpot { Name = "俄式鐘樓3", Latitue = (decimal)24.850361, Longitude = (decimal)120.930044 },
                        new GeoSpot { Name = "彩虹橋", Latitue = (decimal)24.849123, Longitude = (decimal)120.930629 },
                        new GeoSpot { Name = "木馬病毒", Latitue = (decimal)24.847693, Longitude = (decimal)120.930134 },
                        new GeoSpot { Name = "海之女神", Latitue = (decimal)24.848098, Longitude = (decimal)120.929479 },
                        new GeoSpot { Name = "地中海一號", Latitue = (decimal)24.848695, Longitude = (decimal)120.929583 },
                        new GeoSpot { Name = "三山國王", Latitue = (decimal)24.848421, Longitude = (decimal)120.928889 },
                        new GeoSpot { Name = "大水塔", Latitue = (decimal)24.848722, Longitude = (decimal)120.928889 },
                        new GeoSpot { Name = "俄式鐘樓1", Latitue = (decimal)24.849130, Longitude = (decimal)120.928333 },
                        new GeoSpot { Name = "貝殼公園", Latitue = (decimal)24.850759, Longitude = (decimal)120.928303 },
                        
                        new GeoSpot { Name = "瑪莎咖啡", Latitue = (decimal)24.849782, Longitude = (decimal)120.927167 },
                        new GeoSpot { Name = "風箏要扯一下", Latitue = (decimal)24.849782, Longitude = (decimal)120.926343 },
                        new GeoSpot { Name = "雙人合唱螺", Latitue = (decimal)24.850152, Longitude = (decimal)120.925087 },
                        new GeoSpot { Name = "褪色的神仙魚", Latitue = (decimal)24.850721, Longitude = (decimal)120.924146 },
                        new GeoSpot { Name = "道館", Latitue = (decimal)24.851485, Longitude = (decimal)120.923189 },
                        new GeoSpot { Name = "龍蝦洞", Latitue = (decimal)24.848409, Longitude = (decimal)120.925255 },
                        new GeoSpot { Name = "石螃蟹", Latitue = (decimal)24.846849, Longitude = (decimal)120.925699 },
                        new GeoSpot { Name = "環保公園", Latitue = (decimal)24.846363, Longitude = (decimal)120.926645 },

                        new GeoSpot { Name = "木馬病毒", Latitue = (decimal)24.847693, Longitude = (decimal)120.930134 },
                        new GeoSpot { Name = "海之女神", Latitue = (decimal)24.848098, Longitude = (decimal)120.929479 },
                        new GeoSpot { Name = "地中海一號", Latitue = (decimal)24.848695, Longitude = (decimal)120.929583 },
                        new GeoSpot { Name = "三山國王", Latitue = (decimal)24.848421, Longitude = (decimal)120.928889 },
                        new GeoSpot { Name = "大水塔", Latitue = (decimal)24.848722, Longitude = (decimal)120.928889 },
                        new GeoSpot { Name = "俄式鐘樓1", Latitue = (decimal)24.849130, Longitude = (decimal)120.928333 },
                        
                    };
                }
                if (list_GeoPath.Count == 0)
                {
                    textBox3.Text = "巡航路徑未設定!";
                    return;
                }

                iPatrolIdx = 0;
                decimal lat = Convert.ToDecimal(textBox1.Text);
                decimal lng = Convert.ToDecimal(textBox2.Text);
                for (int i = 0; i < list_GeoPath.Count; i++)
                {
                    if (i == iPatrolIdx) continue;
                    decimal diff_idx = Math.Abs(list_GeoPath[iPatrolIdx].Latitue - lat) + Math.Abs(list_GeoPath[iPatrolIdx].Longitude - lng);
                    decimal diff_new = Math.Abs(list_GeoPath[i].Latitue - lat) + Math.Abs(list_GeoPath[i].Longitude - lng);
                    if (diff_new < diff_idx)
                    {
                        iPatrolIdx = i;
                    }
                }
                textBox4.Text = list_GeoPath[iPatrolIdx].Latitue.ToString();
                textBox5.Text = list_GeoPath[iPatrolIdx].Longitude.ToString();
                bIsPatrol = true;
                BtnPath.Text = "停止巡航";
                BtnAuto.PerformClick();
            }
            else
            {
                bIsPatrol = false;
                BtnPath.Text = "開始巡航";
                list_GeoPath = new List<GeoSpot>()
                {
                };
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            iPatrolIdx--;
            if (iPatrolIdx < 0)
            {
                iPatrolIdx = (list_GeoPath.Count-1);
            }
            textBox3.Text = "變更目的地前往" + list_GeoPath[iPatrolIdx].Name;
            textBox4.Text = list_GeoPath[iPatrolIdx].Latitue.ToString();
            textBox5.Text = list_GeoPath[iPatrolIdx].Longitude.ToString();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            iPatrolIdx++;
            if (iPatrolIdx == list_GeoPath.Count)
            {
                iPatrolIdx = 0;
            }
            textBox3.Text = "變更目的地前往" + list_GeoPath[iPatrolIdx].Name;
            textBox4.Text = list_GeoPath[iPatrolIdx].Latitue.ToString();
            textBox5.Text = list_GeoPath[iPatrolIdx].Longitude.ToString();
        }
    }
    public class GeoSpot
    {
        public string Name { get; set; }
        public decimal Latitue { get; set; }
        public decimal Longitude { get; set; }
    }
}
