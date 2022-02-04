using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionListDownloaders
{
    public interface IAsyncVersionListDownloader
    {
        Task<IEnumerable<VersionInfoFile>> DownloadListOfVersions(IProgress<AsyncDownloadProgress> progress);
    }
}