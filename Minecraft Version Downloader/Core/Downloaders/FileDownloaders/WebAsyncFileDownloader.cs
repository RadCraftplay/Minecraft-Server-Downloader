// This file is part of Minecraft Server Downloader.
// 
// Copyright (C) 2016-2022 Distroir
// 
// Minecraft Server Downloader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Minecraft Server Downloader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// Email: radcraftplay2@gmail.com

using System;
using System.Net;
using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.Downloaders.FileDownloaders
{
    public class WebAsyncFileDownloader : IAsyncFileDownloader
    {
        private readonly WebClient _client;
        private readonly IProgress<AsyncDownloadProgress> _progress;

        public WebAsyncFileDownloader(IProgress<AsyncDownloadProgress> fileDownloadProgress)
        {
            _client = new WebClient();
            _client.DownloadProgressChanged += ClientOnDownloadProgressChanged;
            _progress = fileDownloadProgress;
        }
        
        private void ClientOnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _progress.Report(new AsyncDownloadProgress(e.ProgressPercentage, 100));
        }

        public async Task DownloadFileAsync(string url, string filename)
        {
            await _client.DownloadFileTaskAsync(url, filename);
            _progress.Report(new AsyncDownloadProgress(100, 100, true));
        }

        public async Task CancelAsync()
        {
            await Task.Run(() => _client.CancelAsync());
        }
    }
}