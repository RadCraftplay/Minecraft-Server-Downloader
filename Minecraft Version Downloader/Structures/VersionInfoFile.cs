using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minecraft_Server_Downloader.Structures
{
    public class VersionInfoFile
    {
        public class MinecraftDownloads
        {
            public class MinecraftDownloadInfo
            {
                public int size;
                public string url;
            }

            public MinecraftDownloadInfo server;
        }

        public string id;
        public MinecraftDownloads downloads;
    }
}
