using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Downloaders
{
    public interface IAsyncVersionListDownloader
    {
        Task<ImmutableArray<VersionInfoFile>> DownloadVersions(IProgress<AsyncDownloadProgress> progress);
    }
}