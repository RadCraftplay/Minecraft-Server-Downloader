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
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader
{
	public partial class DownloadVersionsDialog : MetroForm
	{
		#region Delegates

		public delegate void CloseWindowDelegate();
		public delegate void UpdateProgressDelegate(int current, int max);
		public delegate void ChangeProgressBarStyleDelegate(ProgressBarStyle style);

		#endregion

		#region Variables

		/// <summary>
		/// Url of version info file
		/// </summary>
		const string VersionListDownloadURL = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
		/// <summary>
		/// Thread in which version info is downloaded
		/// </summary>
		Thread downloadThread;
		/// <summary>
		/// List of available server versions
		/// </summary>
		public List<VersionInfoFile> serverVersions = new List<VersionInfoFile>();
		/// <summary>
		/// Reason of closing the window
		/// </summary>
		public CloseReason closeReason;

		#endregion

		public DownloadVersionsDialog()
		{
			InitializeComponent();

			// Create thread that will download required files
			CreateThread();
		}

		#region Control events

		private void cancelButton_Click(object sender, EventArgs e)
		{
			if (downloadThread != null && downloadThread.IsAlive)
				downloadThread.Abort();
		}

		private void DownloadVersionsDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Kill thread downloading files and tell parent that window have been closed by user
			downloadThread.Abort();
			closeReason = CloseReason.UserAction;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Creates a background downloader thread
		/// </summary>
		void CreateThread()
		{
			// Create and run downloadThread
			downloadThread = new Thread(DownloadInfo);
			downloadThread.Start();
		}

		/// <summary>
		/// Processes version list file
		/// </summary>
		/// <returns>Urls of versions</returns>
		string[] ProcessVersionList(string versionListJson)
		{
			VersionListFile f = JsonConvert.DeserializeObject<VersionListFile>(versionListJson);
			return (from x in f.versions
				   select x.url).ToArray();
		}

		void ProcessVersionInfo(string versionInfoJson)
		{
			VersionInfoFile f = JsonConvert.DeserializeObject<VersionInfoFile>(versionInfoJson);

			// If server download is available
			// Add it to list
			if (f.downloads.server != null)
				serverVersions.Add(f);
		}

		#endregion

		#region Tasks

		/// <summary>
		/// Downloads version info
		/// </summary>
		public void DownloadInfo()
		{
			WebClient c = new WebClient();
            string versionListJson = null;

            try
            {
                // Download version list file
                versionListJson = c.DownloadString(VersionListDownloadURL);
            }
            catch
            {
                // Error - Close window
                closeReason = CloseReason.Error;
                CloseWindow();

                // Abort thread
                return;
            }

            //Process list file
            string[] versions = ProcessVersionList(versionListJson);

			// Change progress bar style
			ChangeProgressBarStyle(ProgressBarStyle.Blocks);

			// Download and process all versions
			for (int i = 0; i < versions.Length; i++)
			{
				// Update progress info
				UpdateLabelText(i + 1, versions.Length);
				UpdateProgressBar(i + 1, versions.Length);

				try
				{
					// Download and process version info
					ProcessVersionInfo(c.DownloadString(versions[i]));
				}
				catch
				{
                    //Close window
					closeReason = CloseReason.Error;
					CloseWindow();

                    //Abort thread
                    return;
				}
			}

			// Close window
			closeReason = CloseReason.DownloadingFinished;
			CloseWindow();
		}

		#endregion

		#region Async control actions

		/// <summary>
		/// Updates label text
		/// </summary>
		/// <param name="current"></param>
		/// <param name="all"></param>
		void UpdateLabelText(int current, int all)
		{
			if (downloadInfoLabel.InvokeRequired)
			{
				UpdateProgressDelegate d = new UpdateProgressDelegate(UpdateLabelText);
				this.Invoke(d, new object[] { current, all });
			}
			else
			{
				downloadInfoLabel.Text = $"Downloading file {current} of {all}...";
			}
		}

		/// <summary>
		/// Changes origress bar style
		/// </summary>
		/// <param name="style">progress bar style</param>
		void ChangeProgressBarStyle(ProgressBarStyle style)
		{
			if (dlProgressBar.InvokeRequired)
			{
				ChangeProgressBarStyleDelegate d = new ChangeProgressBarStyleDelegate(ChangeProgressBarStyle);
				this.Invoke(d, new object[] { style });
			}
			else
			{
				dlProgressBar.ProgressBarStyle = style;
			}
		}

		/// <summary>
		/// Updates progress bar
		/// </summary>
		/// <param name="current">Current progress</param>
		/// <param name="all">Maximum</param>
		void UpdateProgressBar(int current, int max)
		{
			if (dlProgressBar.InvokeRequired)
			{
				UpdateProgressDelegate d = new UpdateProgressDelegate(UpdateProgressBar);
				this.Invoke(d, new object[] { current, max });
			}
			else
			{
				dlProgressBar.Maximum = max;
				dlProgressBar.Value = current;
			}
		}

		/// <summary>
		/// Closes window
		/// </summary>
		void CloseWindow()
		{
			if (InvokeRequired)
			{
				CloseWindowDelegate d = new CloseWindowDelegate(CloseWindow);
				this.Invoke(d);
			}
			else
			{
				Close();
			}
		}

		#endregion
	}
}
