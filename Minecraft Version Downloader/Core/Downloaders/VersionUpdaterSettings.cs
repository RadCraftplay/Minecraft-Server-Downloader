namespace Minecraft_Server_Downloader.Core.Downloaders
{
    public class VersionUpdaterSettings
    {
        public bool DownloadSynchronously { get; set; }
        public bool DownloadAllVersions { get; set; }
        public int MaxConcurrentDownloads { get; set; }
    }
}