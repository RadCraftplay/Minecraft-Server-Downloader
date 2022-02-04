using System.Collections.Generic;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders
{
    public interface IVersionFileListDownloader
    {
        Task<IEnumerable<VersionListFile.MinecraftVersion>> GetVersionInfoFileUrls();
    }
}