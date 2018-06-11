using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
namespace WallpaperChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Interval.Items.Add("1 sec");
            Interval.Items.Add("3 hours");
            Interval.Items.Add("6 hours");
            Interval.Items.Add("24 hours");
        }
        string Filename;
        const  int SetDeskwallpaper=20;
        const int UpdateIniFile = 0x01;
        const int SendwinIniChange = 0x02;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        int i=0;
        public void Set()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            Filename = labelfilename.Text;
            string[] files = Directory.GetFiles("C:\\Users\\Егардоз\\Pictures\\обои");
            Filename = files[i % files.Length];

            Image img = Image.FromFile(Filename);
            while (!(img.Size.Height > 0 && img.Size.Width > img.Size.Height))
            {
                i++;
                Filename = files[i % files.Length];
                img = Image.FromFile(Filename);
            }
            labelfilename.Text = Filename;
            SystemParametersInfo(SetDeskwallpaper, 0, Filename, UpdateIniFile | SendwinIniChange);
            i++;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Set();
        }

        private void labelfilename_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Set();
        }

        private void Interval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Interval.Text == "1 sec")
            {
                Timer.Interval = 1000;
            }
            if (Interval.Text == "3 hours")
            {
                Timer.Interval = 10800000;
            }
            if (Interval.Text == "6 hours")
            {
                Timer.Interval = 21600000;
            }
            if (Interval.Text == "24 hours")
            {
                Timer.Interval = 86400000;
            }

        }
    }
}
