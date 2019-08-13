/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016 Distroir

	Minecraft Server Downloader is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	Minecraft Server Downloader is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.

	Email: radcraftplay2@gmail.com
*/
using MetroFramework;
using MetroFramework.Forms;
using Minecraft_Server_Downloader.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Minecraft_Server_Downloader
{
	public partial class MainForm : MetroForm
	{
        #region Variables

        /// <summary>
        /// WebClient used for downloading server
        /// </summary>
        WebClient client = new WebClient();

        /// <summary>
        /// File containing list of Minecraft server versions
        /// </summary>
        string VersionListFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader", "server_versions.txt");

        /// <summary>
        /// Full, unfiltered list of server versions
        /// </summary>
        private List<VersionInfoFile> serverVersions = new List<VersionInfoFile>();

        #endregion

        public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
			client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            LoadVersionListFile();
		}

        #region Button events

        /// <summary>
        /// Refreshes list of minecraft server versions
        /// </summary>s
        private void refreshButton_Click(object sender, EventArgs e)
		{
			var d = new DownloadVersionsDialog();
			d.ShowDialog();

			if (d.closeReason == CloseReason.Error)
			{
				// Some kind of an error
				MessageBox.Show("Unable to download required files probably due to network error", "Minecraft Server Downloader", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (d.closeReason == CloseReason.DownloadingFinished)
			{
                // Save version list
                SaveVersionListFile(d.serverVersions);
                // Reload version list
                LoadVersionListFile();
			}
		}

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (metroListView1.SelectedItems.Count == 0)
                MessageBox.Show("Nothing selected!");

            else
            {
                refreshButton.Enabled = false;
                metroListView1.Enabled = false;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Java executable|*.jar";
                sfd.FileName = "minecraft_server";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    VersionInfoFile info = (VersionInfoFile)metroListView1.SelectedItems[0].Tag;

                    downloadButton.Text = "Cancel";
                    downloadButton.Click -= downloadButton_Click;
                    downloadButton.Click += cancelButton_Click;

                    client.DownloadFileAsync(new Uri(info.downloads.server.url), sfd.FileName);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if program data directories exist
        /// </summary>
        void checkDirectories()
		{
			if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir")))
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir"));
			if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader")))
				Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader"));
		}

        /// <summary>
        /// Saves version list file
        /// </summary>
        void SaveVersionListFile(List<Structures.VersionInfoFile> versions)
        {
            using (TextWriter w = new StreamWriter(VersionListFilePath))
            {
                foreach (Structures.VersionInfoFile version in versions)
                {
                    w.WriteLine($"{version.id}|{version.downloads.server.url}|{version.type}");
                }
            }
        }

        /// <summary>
        /// Loads version list file from disc
        /// </summary>
        void LoadVersionListFile()
        {
            if (!File.Exists(VersionListFilePath))
                return;

            // Clear lists
            metroListView1.Items.Clear();
            serverVersions.Clear();

            // Read file
            using (TextReader r = new StreamReader(VersionListFilePath))
            {
                while (true)
                {
                    string line = r.ReadLine();

                    // If line is empty, break loop
                    if (line == null)
                        break;

                    // Read server info
                    string[] info = line.Split('|');
                    VersionInfoFile versionInfo = ParseVersionInfo(info);

                    AddVersionToListView(versionInfo);
                    serverVersions.Add(versionInfo);
                }
            }
        }

        private void AddVersionToListView(VersionInfoFile info)
        {
            metroListView1.Items.Add(CreateListViewItem(info));
        }

        private ListViewItem CreateListViewItem(VersionInfoFile info)
        {
            return new ListViewItem(info.id)
            {
                Tag = info
            };
        }

        private VersionInfoFile ParseVersionInfo(string[] unparsedInfo)
        {
            return new VersionInfoFile()
            {
                id = unparsedInfo[0],
                type = unparsedInfo.Length >= 3 ? unparsedInfo[2] : "unknown",
                downloads = new VersionInfoFile.MinecraftDownloads()
                {
                    server = new VersionInfoFile.MinecraftDownloads.MinecraftDownloadInfo()
                    {
                        size = -1,
                        url = unparsedInfo[1]
                    }
                }
            };
        }

        #endregion

        #region WebClient events

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			MetroMessageBox.Show(this, "Downloading finished!");

			downloadButton.Text = "Download";
			downloadButton.Click += downloadButton_Click;
			downloadButton.Click -= cancelButton_Click;

			metroProgressBar1.Value = 0;
			refreshButton.Enabled = true;
			metroListView1.Enabled = true;
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			metroProgressBar1.Value = e.ProgressPercentage;
		}

        #endregion

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<string> selectedVersions = new List<string>();
            
            foreach (Control control in serverVersionFiltersGroupBox.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    if (checkBox.Tag == null || checkBox.Checked == false)
                        continue;

                    string selectedType = (string)checkBox.Tag;
                    selectedVersions.Add(selectedType);
                }
            }

            var lvItems = from version in serverVersions
                          where selectedVersions.Contains(version.type)
                          select CreateListViewItem(version);

            metroListView1.Clear();
            foreach (var item in lvItems)
            {
                metroListView1.Items.Add(item);
            }
        }
    }
}
