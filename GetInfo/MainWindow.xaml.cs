using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Net;
using System.Collections.Specialized;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace GetInfo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string machineName = Environment.MachineName;
            bl1.Text = machineName;//PCName

            try
                {
                    using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                    {
                        using (ManagementObjectCollection moc = mc.GetInstances())
                        {
                            string macAddress = "";
                            foreach (ManagementObject mo in moc)
                            {
                                if ((bool)mo["IPEnabled"] == true)
                                {
                                    macAddress = mo["MacAddress"].ToString();
                                    break;
                                }
                            }
                        bl2.Text = macAddress;
                        }
                    }
                }
                catch
                {
                bl2.Text = "unknown";
                }
                finally
                {
                }//MacAddress

            bool is64OS = Environment.Is64BitOperatingSystem;
            if (is64OS == true)
                bl3.Text = "64 bits OS";//64位
            else
                bl3.Text = "32 bits OS";//32位

#region
            string HDSN = "";
            ManagementClass cimobject = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject.GetInstances();
            foreach (ManagementObject mo in moc1)
            {
                HDSN = (string)mo.Properties["Model"].Value;
            }
            ManagementClass mc1 = new ManagementClass("Win32_PhysicalMedia"); 
            ManagementObjectCollection moc2 = mc1.GetInstances();
            string HDID = "";
            foreach (ManagementObject mo in moc2)
            {
                HDID = mo.Properties["SerialNumber"].Value.ToString().Trim();
                break;
            }
            bl4.Text = HDSN;
            bl5.Text = HDID;
#endregion
#region 
            string ip =  "";
            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                ip = addressList[i].ToString();
            }
            bl7.Text = ip;//IPV6

            ShowIP();
            #endregion
            ManagementClass mc2 = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc3 = mc2.GetInstances();
            if (moc3.Count != 0)
            {
                foreach (ManagementObject mo in mc2.GetInstances())
                {
                    bl1.Text =mo["Manufacturer"].ToString();
                }
            }//Manufacturer
            string PCV = "";
            ManagementClass mc3 = new ManagementClass("win32_ComputerSystem");
            ManagementObjectCollection moc4 = mc3.GetInstances();
            foreach (ManagementObject m in moc4)
            {
                PCV = m["model"].ToString ();
            }
            bl2.Text = PCV;
        }
        void ShowIP()
        { 
            foreach (string ip in GetLocalIpv4())
            {
                bl6.Text = ip.ToString();
            }
            return;
        }
        string[] GetLocalIpv4()
        {
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    IpCollection.Add(ip.ToString());
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            return IpArray;
        }

        public bool isbl1c = false;
        public bool isbl2c = false;
        public bool isbl3c = false;
        public bool isbl4c = false;
        public bool isbl5c = false;
        public bool isbl6c = false;
        public bool isbl7c = false;

        private void bl1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl1c = !isbl1c;
            if (isbl1c == true)
            {
                bl1.Foreground = Brushes.Red;
                textBlock.Text += bl1.Text+"\n";
            }
            else
            {
                bl1.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl1.Text+"\n" ,"");
            }
        }

        private void bl2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl2c = !isbl2c;
            if (isbl2c == true)
            {
                bl2.Foreground = Brushes.Red;
                textBlock.Text += bl2.Text + "\n";
            }
            else
            {
                bl2.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl2.Text + "\n", "");
            }
        }

        private void bl3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl3c = !isbl3c;
            if (isbl3c == true)
            {
                bl3.Foreground = Brushes.Red;
                textBlock.Text += bl3.Text + "\n";
            }
            else
            {
                bl3.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl3.Text + "\n", "");
            }
        }

        private void bl4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl4c = !isbl4c;
            if (isbl4c == true)
            {
                bl4.Foreground = Brushes.Red;
                textBlock.Text += bl4.Text + "\n";
            }
            else
            {
                bl4.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl4.Text + "\n", "");
            }
        }

        private void bl5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl5c = !isbl5c;
            if (isbl5c == true)
            {
                bl5.Foreground = Brushes.Red;
                textBlock.Text += bl5.Text + "\n";
            }
            else
            {
                bl5.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl5.Text + "\n", "");
            }
        }

        private void bl6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl6c = !isbl6c;
            if (isbl6c == true)
            {
                bl6.Foreground = Brushes.Red;
                textBlock.Text += bl6.Text + "\n";
            }
            else
            {
                bl6.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl6.Text + "\n", "");
            }
        }

        private void bl7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isbl7c = !isbl7c;
            if (isbl7c == true)
            {
                bl7.Foreground = Brushes.Red;
                textBlock.Text += bl7.Text + "\n";
            }
            else
            {
                bl7.Foreground = Brushes.Black;
                textBlock.Text = textBlock.Text.Replace(bl7.Text + "\n", "");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter info = new StreamWriter(System.Windows.Forms.Application .StartupPath + "\\" + "1.txt");
            info.Write(textBlock.Text.Replace("\n","\r\n"));
            info.Flush();
            info.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            About about = new About ();
            about.ShowDialog();
        }
    }
}
