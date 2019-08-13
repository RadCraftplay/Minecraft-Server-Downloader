using Minecraft_Server_Downloader.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Server_Downloader.Core.Storage
{
    public interface ILocalStorage
    {
        void Save(List<VersionInfoFile> versions);
        List<VersionInfoFile> Load();
    }
}
