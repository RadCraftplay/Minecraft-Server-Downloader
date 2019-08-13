using System.Collections.Generic;
using System.IO;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.Storage
{
    public class TextStorage : ILocalStorage
    {
        private readonly string _filename;

        public TextStorage(string filename)
        {
            _filename = filename;
        }

        public List<VersionInfoFile> Load()
        {
            List<VersionInfoFile> localVersions = new List<VersionInfoFile>();

            using (TextReader reader = new StreamReader(_filename))
            {
                while(true)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                        break;

                    string[] info = line.Split('|');
                    VersionInfoFile versionInfo = ParseVersionInfo(info);
                    localVersions.Add(versionInfo);
                }
            }

            return localVersions;
        }

        private VersionInfoFile ParseVersionInfo(string[] unparsedInfo)
        {
            return new VersionInfoFile()
            {
                id = unparsedInfo[0],
                type = unparsedInfo.Length >= 3 ? unparsedInfo[2] : "unknown",
                downloads = new VersionInfoFile.MinecraftDownloads()
                {
                    server = new VersionInfoFile.MinecraftDownloads.MinecraftDownloadInfo()
                    {
                        size = -1,
                        url = unparsedInfo[1]
                    }
                }
            };
        }

        public void Save(List<VersionInfoFile> versions)
        {
            using (TextWriter writer = new StreamWriter(_filename))
            {
                foreach (VersionInfoFile version in versions)
                {
                    writer.WriteLine($"{version.id}|{version.downloads.server.url}|{version.type}");
                }
            }
        }
    }
}
