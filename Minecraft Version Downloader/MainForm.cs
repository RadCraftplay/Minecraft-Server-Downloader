/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016-2020 Distroir

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
using System.Linq;
using System.Windows.Forms;
using Minecraft_Server_Downloader.Core;
using Minecraft_Server_Downloader.Core.Downloaders;

namespace Minecraft_Server_Downloader
{
	public partial class MainForm : MetroForm
	{
        #region Variables

        private readonly MinecraftServerDownloader _facade;
        private readonly IProgress<AsyncDownloadProgress> _progress;

        #endregion

        public MainForm()
		{
			InitializeComponent();
			_facade = new MinecraftServerDownloader();
            _progress = new Progress<AsyncDownloadProgress>(DownloadProgressChanged);
		}

        #region Events
        
        private async void MainForm_Load(object sender, EventArgs e)
        {
	        await _facade.Init();
	        UpdateListOfVersions(await _facade.GetAllLocalServerVersions());
        }
        
        private async void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
	        var selectedVersions = new List<string>();

	        foreach (Control control in serverVersionFiltersGroupBox.Controls)
	        {
		        if (!(control is CheckBox checkBox) || checkBox.Tag == null || checkBox.Checked == false)
			        continue;

		        var selectedType = (string)checkBox.Tag;
		        selectedVersions.Add(selectedType);
	        }

	        var serverVersions = await _facade
		        .GetLocalServerVersionsThat(version => selectedVersions
			        .Contains(version.type));
            
	        UpdateListOfVersions(serverVersions);
        }

        #region Button events

        /// <summary>
        /// Refreshes list of minecraft server versions
        /// </summary>s
        private async void refreshButton_Click(object sender, EventArgs e)
        {
	        var d = new DownloadVersionsDialog(_facade);
			d.ShowDialog();

			if (d.DialogCloseReason == CloseReason.Error)
			{
				// Some kind of an error
				MessageBox.Show("Unable to download required files probably due to network error", "Minecraft Server Downloader", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (d.DialogCloseReason == CloseReason.DownloadingFinished)
			{
				// Reload version list
                UpdateListOfVersions(await _facade.GetAllLocalServerVersions());
			}
		}

        private async void downloadButton_Click(object sender, EventArgs e)
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
	                var versionId = metroListView1.SelectedItems[0].Text;

                    downloadButton.Text = "Cancel";
                    downloadButton.Click -= downloadButton_Click;
                    downloadButton.Click += cancelButton_Click;

                    await _facade.DownloadServer(versionId, sfd.FileName, _progress);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
	        _facade.CancelDownloadingServer();
	        
	        downloadButton.Text = "Download";
	        downloadButton.Click -= cancelButton_Click;
	        downloadButton.Click += downloadButton_Click;
	        
	        metroProgressBar1.Value = 0;
	        refreshButton.Enabled = true;
	        metroListView1.Enabled = true;
        }

        #endregion

        #region Downloader events
        
        private void DownloadProgressChanged(AsyncDownloadProgress progress)
        {
	        if (!progress.Completed)
	        {
		        metroProgressBar1.Value = progress.Current;
		        return;
	        }
	        
	        MetroMessageBox.Show(this, "Downloading finished!");

	        downloadButton.Text = "Download";
	        downloadButton.Click += downloadButton_Click;
	        downloadButton.Click -= cancelButton_Click;

	        metroProgressBar1.Value = 0;
	        refreshButton.Enabled = true;
	        metroListView1.Enabled = true;
        }

        #endregion
        
        #endregion
        
        #region Methods

        private void UpdateListOfVersions(IEnumerable<VersionInfoFile> versions)
        {
	        var items = versions
		        .Select(version => new ListViewItem(version.id))
		        .ToArray();
	        metroListView1.Clear();
	        metroListView1.Items.AddRange(items);
        }

        #endregion
	}
}
