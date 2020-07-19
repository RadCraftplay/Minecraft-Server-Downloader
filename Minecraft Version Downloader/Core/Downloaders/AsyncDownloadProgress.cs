namespace Minecraft_Server_Downloader.Core.Downloaders
{
    public class AsyncDownloadProgress
    {
        public AsyncDownloadProgress(int current, int all)
        {
            Current = current;
            All = all;
        }

        public int Current { get; }
        public int All { get; }
    }
}
