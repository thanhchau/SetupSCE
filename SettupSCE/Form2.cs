using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettupSCE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "msiexec";
            p.StartInfo.Arguments = "/i putty.msi";
            p.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MyBatchFile = @"lib.bat";
            var process = new Process();
            process.StartInfo.FileName = MyBatchFile;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //unzip File
            try
            {
                string zipPath = @"cml.zip";
                string extractPath = @"c:\cml";
                string zipPath1 = @"cs.zip";
                string extractPath1 = @"c:\cs\123";
                string zipPath2 = @"cs.zip";
                string extractPath2 = @"c:\cs\456";
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                //CreateShortcut("Check Machine Status", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"c:\cml\cml\CheckMachineLine.exe", "logo1.ico");
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath1, extractPath1);
                //CreateShortcut("SE Monitor 1", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"c:\cs\123\cs\SEMonitor.exe", "logo2.ico");
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath2, extractPath2);
                //CreateShortcut("SE Monitor 2", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"c:\cs\456\cs\SEMonitor.exe", "logo2.ico");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phần Mềm đã được cài đặt");
                Application.Exit();
            }

            //End unzip File
            process.Start();
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string logo)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "My shortcut description";   // The description of the shortcut
            shortcut.IconLocation = @"c:\\imgc\" + logo;       // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
