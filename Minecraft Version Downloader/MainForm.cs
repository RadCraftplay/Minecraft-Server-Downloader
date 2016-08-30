using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Minecraft_Version_Downloader
{
    public partial class MainForm : MetroForm
    {
        WebClient client = new WebClient();

        static string versionServerUrl(string version)
        {
            return "https://s3.amazonaws.com/Minecraft.Download/versions/" + version + "/minecraft_server." + version + ".jar";
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
            downloadButton.Enabled = false;
            metroListView1.Enabled = false;

            WebClient c = new WebClient();
            c.DownloadFileCompleted += C_DownloadFileCompleted;
            c.DownloadFileAsync(new Uri("https://www.dropbox.com/s/emvqu0rch0kabbp/versions.txt?dl=1"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader", "versions.txt"));
        }

        void checkdirs()
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir"));
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader"));
        }

        private void C_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            checkdirs();

            TextReader r = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader", "versions.txt"));
            string[] s = r.ReadToEnd().Split('|');

            metroListView1.Items.Clear();
            foreach (string str in s)
                metroListView1.Items.Add(str);

            refreshButton.Enabled = true;
            downloadButton.Enabled = true;
            metroListView1.Enabled = true;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
            downloadButton.Enabled = false;
            metroListView1.Enabled = false;

            if (metroListView1.SelectedItems.Count == 0)
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
                    string Url = versionServerUrl(metroListView1.SelectedItems[0].Text);
                    client.DownloadFileAsync(new Uri(Url), sfd.FileName);
                }
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MetroMessageBox.Show(this, "Downloading finished!");

            metroProgressBar1.Value = 0;
            refreshButton.Enabled = true;
            downloadButton.Enabled = true;
            metroListView1.Enabled = true;
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            metroProgressBar1.Value = e.ProgressPercentage;
        }
    }
}
