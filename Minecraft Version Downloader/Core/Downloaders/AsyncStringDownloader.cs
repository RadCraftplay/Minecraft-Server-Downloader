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
        private readonly ImmutableArray<string> _downloadQueue;
        private readonly HttpClient _client;
        private readonly CancellationToken _token;

        public AsyncStringDownloader(IEnumerable<string> downloadQueue, CancellationToken token)
        {
            _downloadQueue = ImmutableArray.CreateRange(downloadQueue);
            _client = new HttpClient();
        }

        public async Task<ImmutableList<string>> DownloadList(IProgress<AsyncDownloadProgress> progress)
        {
            var downloadedVersions = new List<string>();
            int completed = 0;

            foreach (var url in _downloadQueue)
            {
                if (_token.IsCancellationRequested)
                    break;

                var downloadedString = await _client.GetStringAsync(url);
                downloadedVersions.Add(downloadedString);

                progress.Report(new AsyncDownloadProgress(++completed, _downloadQueue.Count()));
            }

            return ImmutableList.CreateRange(downloadedVersions);
        }
    }
}
