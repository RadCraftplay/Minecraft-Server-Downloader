using System.Collections.Generic;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders
{
    public class IncrementalVersionListDownloader : IVersionFileListDownloader
    {
        private readonly FilteredVersionListDownloader _downloader;

        public IncrementalVersionListDownloader(IAsyncStringDownloader downloader, List<string> localVersions)
        {
            _downloader = new FilteredVersionListDownloader(downloader, 
                version => !localVersions.Contains(version.id));
        }

        public async Task<IEnumerable<VersionListFile.MinecraftVersion>> GetVersionInfoFileUrls()
        {
            return await _downloader.GetVersionInfoFileUrls();
        }
    }
}