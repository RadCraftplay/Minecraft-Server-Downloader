using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders
{
    public class FilteredVersionListDownloader : IVersionFileListDownloader
    {
        private readonly StandardVersionFileListDownloader _downloader;
        private readonly Func<VersionListFile.MinecraftVersion, bool> _predicate;

        public FilteredVersionListDownloader(
            AsyncStringDownloader downloader, 
            Func<VersionListFile.MinecraftVersion, bool> predicate)
        {
            _predicate = predicate;
            _downloader = new StandardVersionFileListDownloader(downloader);
        }
        
        public async Task<IEnumerable<VersionListFile.MinecraftVersion>> GetVersionInfoFileUrls()
        {
            var unfilteredVersions = await _downloader.GetVersionInfoFileUrls();
            return unfilteredVersions.Where(_predicate);
        }
    }
}