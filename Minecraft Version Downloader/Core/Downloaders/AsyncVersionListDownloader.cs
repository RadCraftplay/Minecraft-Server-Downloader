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
        private const string VERSION_LIST_URL = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
        private readonly AsyncStringDownloader _downloader;

        public AsyncVersionListDownloader(CancellationToken token)
        {
            _downloader = new AsyncStringDownloader(token);
        }

        private async Task<ImmutableArray<VersionInfoFile>> DownloadVersions(IProgress<AsyncDownloadProgress> progress)
        {
            var downloadQueue = await GetListOfVersions();
            var fileContents = await _downloader.DownloadList(downloadQueue, progress);
            return ImmutableArray.CreateRange(GetVersions(fileContents));
        }

        private async Task<IEnumerable<string>> GetListOfVersions()
        {
            var listFileContents = await _downloader.DownloadString(VERSION_LIST_URL);
            var versionListFile = JsonConvert.DeserializeObject<VersionListFile>(listFileContents);
            return versionListFile.versions
                .Select(version => version.url);
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
