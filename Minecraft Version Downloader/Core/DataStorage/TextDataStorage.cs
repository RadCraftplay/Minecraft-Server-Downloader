// This file is part of Minecraft Server Downloader.
// 
// Copyright (C) 2016-2022 Distroir
// 
// Minecraft Server Downloader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Minecraft Server Downloader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// Email: radcraftplay2@gmail.com

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core.DataStorage
{
    public class TextDataStorage : IDataStorage
    {
        public readonly string DATA_FILENAME = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            "Distroir", "Minecraft Version Downloader", "server_versions.txt");

        private readonly IFileSystem _fileSystem;
        private List<VersionInfoFile> versions = new();

        public TextDataStorage(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public TextDataStorage() : this(new FileSystem())
        {
        }
        
        public async Task Load()
        {
            var localVersions = new List<VersionInfoFile>();

            using var s = _fileSystem.FileStream.Create(DATA_FILENAME, FileMode.OpenOrCreate);
            using TextReader reader = new StreamReader(s);
            while (true)
            {
                var line = await reader.ReadLineAsync();

                if (string.IsNullOrEmpty(line))
                    break;

                var info = line.Split('|');
                var versionInfo = ParseVersionInfo(info);
                localVersions.Add(versionInfo);
            }

            versions = localVersions;
        }

        public async Task Save()
        {
            using var s = _fileSystem.FileStream.Create(DATA_FILENAME, FileMode.Truncate);
            using TextWriter writer = new StreamWriter(s);
            
            foreach (var version in versions)
            {
                await writer.WriteLineAsync($"{version.id}|{version.downloads.server.url}|{version.type}");
            }
        }

        public bool Contains(string name)
        {
            return name == "local-versions";
        }

        public T Get<T>(string name)
        {
            if (name != "local-versions")
                throw new NotSupportedException("This data storage supports only changing the value of \"local-versions\" setting");

            return !TryCast(versions, out T result) ? default : result;
        }

        public void Set<T>(string name, T value)
        {
            if (name != "local-versions")
                throw new NotSupportedException("This data storage supports only changing the value of \"local-versions\" setting");

            if (!TryCast(value, out List<VersionInfoFile> newListOfVersions))
                throw new ArgumentException($"Parameter {nameof(value)} has to be of type List<VersionInfoFile>");

            versions = newListOfVersions;
        }
        
        private static bool TryCast<T>(object obj, out T result)
        {
            if (obj is T casted)
            {
                result = casted;
                return true;
            }

            result = default;
            return false;
        }
        
        private static VersionInfoFile ParseVersionInfo(string[] unparsedInfo)
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
    }
}