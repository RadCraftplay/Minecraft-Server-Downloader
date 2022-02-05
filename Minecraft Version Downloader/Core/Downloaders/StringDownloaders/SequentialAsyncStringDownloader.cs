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