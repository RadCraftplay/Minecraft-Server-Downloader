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
