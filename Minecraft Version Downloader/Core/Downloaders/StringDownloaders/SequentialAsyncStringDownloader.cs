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
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Utils;

namespace Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders
{
    public class SequentialAsyncStringDownloader : IAsyncStringDownloader
    {
        private readonly HttpClient _client;
        private readonly CancellationToken _token;

        public SequentialAsyncStringDownloader(CancellationToken token)
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(10);
            _token = token;
        }

        public async Task<IEnumerable<string>> DownloadList(IEnumerable<string> downloadQueue, IProgress<AsyncDownloadProgress> progress)
        {
            var queue = downloadQueue as string[] ?? downloadQueue.ToArray();
            if (queue.Length == 0)
                return new List<string>();
            
            var reporter = new ProgressReporter(progress, queue.Length);
            var downloadedStrings = new List<string>();

            foreach (var url in queue)
                downloadedStrings.Add(await DownloadStringAndReportProgress(url, reporter));

            return downloadedStrings;
        }
        
        private async Task<string> DownloadStringAndReportProgress(string url, ProgressReporter reporter)
        {
            try
            {
                var response = await _client.GetAsync(url, _token);
                var downloadedString = await response.Content.ReadAsStringAsync();
                reporter.Report();

                return downloadedString;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> DownloadString(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}