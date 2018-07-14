using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minecraft_Server_Downloader.Structures
{
    public class VersionListFile
    {
        public class MinecraftVersion
        {
            public string id;
            public string url;
        }

        public List<MinecraftVersion> versions;
    }
}
