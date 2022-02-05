using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders;
using Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionListDownloaders
{
    public class StandardAsyncVersionListDownloader: IAsyncVersionListDownloader
    {
        private readonly AsyncVersionListDownloader _downloader;

        public StandardAsyncVersionListDownloader(CancellationToken token)
        {
            var stringDownloader = new SequentialAsyncStringDownloader(token);
            _downloader = new AsyncVersionListDownloader(
                stringDownloader,
                new StandardVersionFileListDownloader(stringDownloader));
        }
        
        public async Task<IEnumerable<VersionInfoFile>> DownloadListOfVersions(IProgress<AsyncDownloadProgress> progress)
        {
            return await _downloader.DownloadListOfVersions(progress);
        }
    }
}