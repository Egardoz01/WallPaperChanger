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
        private class Interval
        {
            public Wallpaper_Changer.Interval Value { get; set; }
            public string Label { get; set; }

            public override string ToString()
            {
                return Label;
            }
        }

        Wallpaper_Changer m_changer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.OneSecond, Label = "1 second" });
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.OneMinute, Label = "1 minute" });
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.HalfHour, Label = "30 minutes" });
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.Hour, Label = "1 hour" });
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.ThreeHours, Label = "3 hours" });
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.SixHours, Label = "6 hours" });
            cbInterval.Items.Add(new Interval() { Value = Wallpaper_Changer.Interval.HalfDay, Label = "12 hours" });

            cbInterval.SelectedIndex = 2;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            m_changer = new Wallpaper_Changer((cbInterval.SelectedItem as Interval).Value);
            m_changer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(m_changer != null)
            {
                m_changer.Stop();
                m_changer = null;
            }
        }

        private void cbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_changer != null)
            {
                m_changer.ChangeInterval((cbInterval.SelectedItem as Interval).Value);
            }
        }
    }
}
