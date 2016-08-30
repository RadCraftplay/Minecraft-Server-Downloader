using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Minecraft_Version_Downloader
{
    [Obsolete("Form1 is deprecated, please use MainForm instead.")]
    public partial class Form1 : Form
    {
        static string versionUrl(string version)
        {
            return "https://s3.amazonaws.com/Minecraft.Download/versions/" + version + "/" + version + ".jar";
        }
        static string versionServerUrl(string version)
        {
            return "https://s3.amazonaws.com/Minecraft.Download/versions/" + version + "/minecraft_server." + version + ".jar";
        }
        static string minecraftDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft";

        static WebClient client = new WebClient();

        public Form1()
        {
            InitializeComponent();

            MainForm f = new MainForm();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
                MessageBox.Show("Nothing selected!");
            else
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                string Url = versionUrl(listBox1.SelectedItem.ToString());
                client.DownloadFileAsync(new Uri(Url), minecraftDirectory + "\\bin\\" + "minecraft.jar");
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "Done!";
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = "Downloading... (" + e.ProgressPercentage + "%)";
        }

        private void changeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                minecraftDirectory = fbd.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
                MessageBox.Show("Nothing selected!");
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Java executable|*.jar";
                sfd.FileName = "minecraft_server";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    string Url = versionServerUrl(listBox1.SelectedItem.ToString());
                    client.DownloadFileAsync(new Uri(Url), sfd.FileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            WebClient c = new WebClient();
            c.DownloadFileCompleted += C_DownloadFileCompleted;
            c.DownloadProgressChanged += C_DownloadProgressChanged;
            c.DownloadFileAsync(new Uri("https://www.dropbox.com/s/emvqu0rch0kabbp/versions.txt?dl=1"), System.Reflection.Assembly.GetExecutingAssembly().Location + "versions.txt");
        }

        private void C_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void C_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            TextReader r = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().Location + "versions.txt");
            string[] s = r.ReadToEnd().Split('|');

            listBox1.Items.Clear();
            foreach (string str in s)
                listBox1.Items.Add(str);

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
