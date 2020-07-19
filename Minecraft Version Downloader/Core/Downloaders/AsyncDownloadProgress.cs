using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
