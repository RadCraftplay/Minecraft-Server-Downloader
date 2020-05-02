/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016-2020 Distroir

	Minecraft Server Downloader is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	Minecraft Server Downloader is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.

	Email: radcraftplay2@gmail.com
*/
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
