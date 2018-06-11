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

        }
        string Filename;
        const  int SetDeskwallpaper=20;
        const int UpdateIniFile = 0x01;
        const int SendwinIniChange = 0x02;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public void Set()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            Filename = labelfilename.Text;

            SystemParametersInfo(SetDeskwallpaper, 0, Filename, UpdateIniFile | SendwinIniChange);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Set();
        }

        private void labelfilename_Click(object sender, EventArgs e)
        {

        }
    }
}
