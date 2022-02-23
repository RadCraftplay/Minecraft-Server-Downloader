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