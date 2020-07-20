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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Minecraft_Server_Downloader.Core.Downloaders;

namespace Minecraft_Server_Downloader.Core.VersionListDownloaders
{
    public class AsyncStringDownloader
    {
        private readonly HttpClient _client;
        private readonly CancellationToken _token;

        public AsyncStringDownloader(CancellationToken token)
        {
            _client = new HttpClient();
            _token = token;
        }

        public async Task<ImmutableArray<string>> DownloadList(IEnumerable<string> downloadQueue, IProgress<AsyncDownloadProgress> progress)
        {
            var queue = downloadQueue as string[] ?? downloadQueue.ToArray();
            var downloadedVersions = new List<string>();
            int current = 0;

            foreach (var url in queue)
            {
                progress.Report(new AsyncDownloadProgress(current++, queue.Count()));

                if (_token.IsCancellationRequested)
                    break;

                var downloadedString = await _client.GetStringAsync(url);
                downloadedVersions.Add(downloadedString);
            }

            return ImmutableArray.CreateRange(downloadedVersions);
        }

        public async Task<string> DownloadString(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}
