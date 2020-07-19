using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.VersionListDownloaders;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders
{
    public class AsyncVersionListDownloader
    {
        private readonly AsyncStringDownloader _downloader;

        public AsyncVersionListDownloader(IEnumerable<string> downloadQueue, CancellationToken token)
        {
            _downloader = new AsyncStringDownloader(downloadQueue, token);
        }

        private async Task<ImmutableArray<VersionInfoFile>> DownloadVersions(IProgress<AsyncDownloadProgress> progress)
        {
            var fileContents = await _downloader.DownloadList(progress);
            return ImmutableArray.CreateRange(GetVersions(fileContents));
        }

        private IEnumerable<VersionInfoFile> GetVersions(ImmutableArray<string> fileContents)
        {
            foreach (var content in fileContents)
                yield return ProcessVersionInfo(content);
        }

        private VersionInfoFile ProcessVersionInfo(string versionInfoJson)
        {
            VersionInfoFile f = JsonConvert.DeserializeObject<VersionInfoFile>(versionInfoJson);

            if (f.downloads.server != null)
                return f;
            else
                return null;
        }
    }
}
