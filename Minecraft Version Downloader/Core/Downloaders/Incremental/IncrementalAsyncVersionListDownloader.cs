using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders.Incremental
{
    public class IncrementalAsyncVersionListDownloader : IAsyncVersionListDownloader
    {
        private readonly AsyncStringDownloader _downloader;
        private readonly List<VersionInfoFile> _localVersions;

        public IncrementalAsyncVersionListDownloader(CancellationToken token, List <VersionInfoFile> localVersions)
        {
            _downloader = new AsyncStringDownloader(token);
            _localVersions = localVersions;
        }
        
        public async Task<ImmutableArray<VersionInfoFile>> DownloadVersions(IProgress<AsyncDownloadProgress> progress)
        {
            throw new NotImplementedException();
        }
    }
}