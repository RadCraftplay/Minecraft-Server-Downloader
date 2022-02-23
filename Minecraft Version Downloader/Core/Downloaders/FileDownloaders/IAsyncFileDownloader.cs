using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.Downloaders.FileDownloaders
{
    public interface IAsyncFileDownloader
    {
        Task DownloadFileAsync(string url, string filename);
        Task CancelAsync();
    }
}