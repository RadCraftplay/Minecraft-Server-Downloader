using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders.Incremental
{
    public class IncrementalAsyncVersionListDownloader : IAsyncVersionListDownloader
    {
        private readonly AsyncStringDownloader _downloader;
        private readonly IVersionFileListDownloader _versionListFileDownloader;

        public IncrementalAsyncVersionListDownloader(CancellationToken token, List<VersionInfoFile> localVersions)
        {
            _downloader = new AsyncStringDownloader(token);
            _versionListFileDownloader = new IncrementalVersionListDownloader(
                _downloader, 
                localVersions.Select(version => version.id).ToList());
        }
        
        public async Task<IEnumerable<VersionInfoFile>> DownloadListOfVersions(IProgress<AsyncDownloadProgress> progress)
        {
            var versions = await _versionListFileDownloader.GetVersionInfoFileUrls();
            var versionInfoFileUrls = versions.Select(version => version.url);
            var versionInfoFileContents = await _downloader.DownloadList(versionInfoFileUrls, progress);
            return versionInfoFileContents
                .Select(JsonConvert.DeserializeObject<VersionInfoFile>)
                .Where(info => info.downloads.server != null);
        }
    }
}