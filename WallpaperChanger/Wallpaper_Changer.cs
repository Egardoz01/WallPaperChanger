using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WallpaperChanger
{
    public class Wallpaper_Changer
    {
        const int SetDeskwallpaper = 20;
        const int UpdateIniFile = 0x01;
        const int SendwinIniChange = 0x02;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        
        public enum Interval
        {
            OneSecond = 1,
            OneMinute = 60,
            HalfHour = 30 * 60,
            Hour = 60 * 60,
            ThreeHours = 3 * 60 * 60,
            SixHours = 6 * 60 * 60,
            HalfDay = 12 * 60 * 60
        }

        private const int MIN_WIDTH = 500; 
        private const string SOFTWARE_NAME = "Wallpaper_Changer";
        private Interval m_interval;
        private string m_assetsFolder;
        private string m_localFolder;
        private FileSystemWatcher m_watcher = new FileSystemWatcher();
        private Timer m_timer;
        private int m_current;

        public Wallpaper_Changer(Interval interval)
        {
            m_interval = interval;
            m_assetsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets");
            m_localFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SOFTWARE_NAME);
            if (!Directory.Exists(m_localFolder))
            {
                Directory.CreateDirectory(m_localFolder);
            }
        }

        public void Start()
        {
            if (!Directory.Exists(m_assetsFolder))
            {
                throw new FileNotFoundException("Assets folder not found");
            }
            syncFolders();

            m_watcher.Path = m_assetsFolder;
            m_watcher.Changed += M_watcher_Changed;
            m_watcher.EnableRaisingEvents = true;

            setTimer();


        }

        private void setTimer()
        {
            m_timer = new Timer((int)m_interval * 1000);
            m_timer.Elapsed += M_timer_Elapsed;
            m_timer.Start();
        }

        public void ChangeInterval(Interval interval)
        {
            m_timer.Stop();
            m_interval = interval;
            setTimer();
        }


        private void M_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string[] files = Directory.GetFiles(m_localFolder);
            
            int cnt = 0;
            while (true)
            {
                string filename = files[m_current % files.Length];

                if (isValidImage(filename))
                {
                    SystemParametersInfo(SetDeskwallpaper, 0, filename, UpdateIniFile | SendwinIniChange);
                    m_current++;
                    return;
                }

                cnt++;
                m_current++;
                if (cnt > 3 * files.Length)
                {
                    break;
                }
            }
        }
        
        public void Stop()
        {
            m_watcher.EnableRaisingEvents = false;
            m_timer.Stop();
        }

        private void M_watcher_Changed(object sender, FileSystemEventArgs e)
        {
            syncFolders();
        }

        private void syncFolders()
        {
            if (!Directory.Exists(m_assetsFolder))
            {
                return;
            }

            if (!Directory.Exists(m_localFolder))
            {
                Directory.CreateDirectory(m_localFolder);
            }

            string[] files = Directory.GetFiles(m_assetsFolder);

            foreach (string file in files)
            {
                string newFileName= Path.Combine(m_localFolder, Path.GetFileNameWithoutExtension(file)+".jpg");
                if (File.Exists(newFileName))
                {
                    continue;
                }

                if(isValidImage(file))
                {
                    File.Copy(file, newFileName);
                }
            }
            
        }

        private bool isValidImage(string file)
        {
            try
            {
                Image img = Image.FromFile(file);
                return (img.Size.Width > MIN_WIDTH && img.Size.Width > img.Size.Height);
            }
            catch (Exception ex)
            {
            }

            return false;
        }
    }
}
