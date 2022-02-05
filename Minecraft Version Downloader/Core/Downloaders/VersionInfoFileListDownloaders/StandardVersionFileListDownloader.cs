using System.Collections.Generic;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders
{
    public class StandardVersionFileListDownloader : IVersionFileListDownloader
    {
        private const string VERSION_LIST_URL = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
        private readonly AsyncStringDownloader _downloader;

        public StandardVersionFileListDownloader(AsyncStringDownloader downloader)
        {
            _downloader = downloader;
        }
        
        public async Task<IEnumerable<VersionListFile.MinecraftVersion>> GetVersionInfoFileUrls()
        {
            var versionInfoFileContents = await _downloader.DownloadString(VERSION_LIST_URL);
            var versionListFileObject = JsonConvert.DeserializeObject<VersionListFile>(versionInfoFileContents);
            return versionListFileObject.versions;
        }
    }
}