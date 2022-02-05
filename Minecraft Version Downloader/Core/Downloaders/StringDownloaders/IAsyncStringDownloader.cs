using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders
{
    public interface IAsyncStringDownloader
    {
        Task<IEnumerable<string>> DownloadList(IEnumerable<string> downloadQueue, IProgress<AsyncDownloadProgress> progress);
        Task<string> DownloadString(string url);
    }
}