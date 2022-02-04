using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionListDownloaders
{
    public class IncrementalAsyncVersionListDownloader : IAsyncVersionListDownloader
    {
        private readonly AsyncVersionListDownloader _downloader;

        public IncrementalAsyncVersionListDownloader(CancellationToken token, List<VersionInfoFile> localVersions)
        {
            var stringDownloader = new AsyncStringDownloader(token);
            _downloader = new AsyncVersionListDownloader(
                stringDownloader,
                new IncrementalVersionListDownloader(
                    stringDownloader, 
                    localVersions.Select(version => version.id).ToList()));
        }
        
        public async Task<IEnumerable<VersionInfoFile>> DownloadListOfVersions(IProgress<AsyncDownloadProgress> progress)
        {
            return await _downloader.DownloadListOfVersions(progress);
        }
    }
}