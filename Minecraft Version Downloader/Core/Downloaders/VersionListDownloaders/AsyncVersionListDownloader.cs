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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.Downloaders.StringDownloaders;
using Minecraft_Server_Downloader.Core.Downloaders.VersionInfoFileListDownloaders;
using Minecraft_Server_Downloader.Structures;
using Newtonsoft.Json;

namespace Minecraft_Server_Downloader.Core.Downloaders.VersionListDownloaders
{
    public class AsyncVersionListDownloader : IAsyncVersionListDownloader
    {
	    private readonly AsyncStringDownloader _downloader;
	    private readonly IVersionFileListDownloader _versionListFileDownloader;

        public AsyncVersionListDownloader(
	        AsyncStringDownloader stringDownloader, 
	        IVersionFileListDownloader versionFileListDownloader)
        {
            _downloader = stringDownloader;
            _versionListFileDownloader = versionFileListDownloader;
        }

        public async Task<IEnumerable<VersionInfoFile>> DownloadListOfVersions(IProgress<AsyncDownloadProgress> progress)
        {
            var versions = await _versionListFileDownloader.GetVersionInfoFileUrls();
            var versionInfoFileUrls = versions.Select(version => version.url);
            var versionInfoFileContents = await _downloader.DownloadList(versionInfoFileUrls, progress);
            return versionInfoFileContents
                .Select(JsonConvert.DeserializeObject<VersionInfoFile>)
                .Where(info => info.downloads.server != null);
        }
    }
}
