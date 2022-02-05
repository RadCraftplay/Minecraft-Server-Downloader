/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016-2022 Distroir

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
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders
{
    public class StandardVersionFileListDownloader : IVersionFileListDownloader
    {
        private const string VERSION_LIST_URL = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
        private readonly IAsyncStringDownloader _downloader;

        public StandardVersionFileListDownloader(IAsyncStringDownloader downloader)
        {
            _downloader = downloader;
        }
        
        public async Task<IEnumerable<VersionListFile.MinecraftVersion>> GetVersionInfoFileUrls()
        {
            var versionInfoFileContents = await _downloader.DownloadString(VERSION_LIST_URL);
            var versionListFileObject = JsonConvert.DeserializeObject<VersionListFile>(versionInfoFileContents);
            return versionListFileObject.versions;
        }
    }
}