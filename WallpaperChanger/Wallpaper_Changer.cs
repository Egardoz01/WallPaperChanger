using Microsoft.Win32;
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

        public class Options
        {
            public bool ChangeOnStart { get; set; }
            public bool ChangeOnStop { get; set; }
            public bool ChangeOnNewInterval { get; set; }
            public bool RememberSeen { get; set; }
        }

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

        private static readonly int MIN_WIDTH = 500; 
        private static readonly string SOFTWARE_NAME = "Wallpaper_Changer";
        private Interval m_interval;
        private string m_assetsFolder;
        private string m_localFolder;
        private FileSystemWatcher m_watcher = new FileSystemWatcher();
        private Timer m_timer;
        private int m_current;
        private Options m_options;
        public Wallpaper_Changer(Interval interval, Options options)
        {
            m_interval = interval;
            m_assetsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets");
            m_localFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SOFTWARE_NAME);
            if (!Directory.Exists(m_localFolder))
            {
                Directory.CreateDirectory(m_localFolder);
            }
            m_options = options;
        }

        public void Start()
        {
            if (!Directory.Exists(m_assetsFolder))
            {
                throw new FileNotFoundException("Assets folder not found");
            }

            syncFolders();

            if (m_options.ChangeOnStart)
            {
                setImg();
            }

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

            if (m_options.ChangeOnNewInterval)
            {
                setImg();
            }

            setTimer();
        }


        private void M_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            setImg();
        }

        private void setImg()
        {
            string[] files = Directory.GetFiles(m_localFolder);

            int cnt = 0;
            while (true)
            {
                string filename = files[m_current % files.Length];

                if (isValidImage(filename))
                {
                    if (checkImageSeen(filename))
                    {
                        SystemParametersInfo(SetDeskwallpaper, 0, filename, UpdateIniFile | SendwinIniChange);
                        m_current++;
                        return;
                    }
                }

                cnt++;
                m_current++;
                if (cnt > 2 * files.Length)
                {
                    dropFiles();
                }

                if (cnt > 4 * files.Length)
                {
                    break;
                }
            }
        }

        public void Stop()
        {
            if (m_options.ChangeOnStop)
            {
                setImg();
            }

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

        private bool checkImageSeen(string file)
        {
            if(!m_options.RememberSeen)
            {
                return true;
            }

            HashSet<string> files = loadFiles();
            if(files.Contains(file))
            {
                return false;
            }

            files.Add(file);
            saveFiles(files);

            return true;
        }

        private static bool isValidImage(string file)
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

        private static void dropFiles()
        {
            if (Registry.CurrentUser.CreateSubKey("Software").GetSubKeyNames().Contains(SOFTWARE_NAME))
            {
                Registry.CurrentUser.DeleteSubKey(string.Format("Software\\{0}", SOFTWARE_NAME));
            }
        }

        private static HashSet<string> loadFiles()
        {
            HashSet<string> result = new HashSet<string>();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(string.Format("Software\\{0}", SOFTWARE_NAME));
            foreach(var name in key.GetValueNames())
            {
                result.Add(key.GetValue(name).ToString());
            }

            return result;
        }

        private static void saveFiles(HashSet<string> files)
        {
            dropFiles();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(string.Format("Software\\{0}", SOFTWARE_NAME));
            int i = 1;
            foreach(string file in files)
            {
                key.SetValue(string.Format("file{0}", i++), file);
            }
        }

    }
}
