using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.Downloaders
{
    public class AsyncDownloadProgress
    {
        public AsyncDownloadProgress(int completed, int all)
        {
            Completed = completed;
            All = all;
        }

        public int Completed { get; }
        public int All { get; }
    }
}
