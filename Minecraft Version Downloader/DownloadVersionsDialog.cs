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
using System.Collections.Immutable;
using System.Windows.Forms;
using System.Threading;
using Minecraft_Server_Downloader.Core.Downloaders;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader
{
    public partial class DownloadVersionsDialog : MetroForm
	{
        #region Variables

        private readonly AsyncVersionListDownloader _downloader;
        private readonly Progress<AsyncDownloadProgress> _progress;
        private readonly CancellationTokenSource _source;

		public CloseReason DialogCloseReason { get; private set; } = CloseReason.UserAction;
        public ImmutableArray<VersionInfoFile> ServerVersions { get; private set; }

        #endregion

		public DownloadVersionsDialog()
		{
			InitializeComponent();

            ServerVersions = ImmutableArray<VersionInfoFile>.Empty;
            _source = new CancellationTokenSource();
            _downloader = new AsyncVersionListDownloader(_source.Token);
            _progress = new Progress<AsyncDownloadProgress>();
            _progress.ProgressChanged += DownloadProgressChanged;
		}

		#region Events

		private void DownloadProgressChanged(object sender, AsyncDownloadProgress e)
        {
            dlProgressBar.ProgressBarStyle = ProgressBarStyle.Continuous;
            dlProgressBar.Maximum = e.All;
            dlProgressBar.Value = e.Current;
            downloadInfoLabel.Text = $"Downloading file {e.Current} of {e.All}...";
        }

        private async void DownloadVersionsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                ServerVersions = await _downloader.DownloadVersions(_progress);
                DialogCloseReason = CloseReason.DownloadingFinished;
            }
            catch
            {
                DialogCloseReason = CloseReason.Error;
            }
            finally
            {
                Close();
            }
        }

		private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogCloseReason = CloseReason.UserAction;
            Close();
        }

		private void DownloadVersionsDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			_source.Cancel();
		}

        #endregion
    }
}
