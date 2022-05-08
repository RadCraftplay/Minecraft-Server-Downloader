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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Minecraft_Server_Downloader.Core.DataStorage;
using Minecraft_Server_Downloader.Core.Downloaders;
using Minecraft_Server_Downloader.Core.Downloaders.FileDownloaders;
using Minecraft_Server_Downloader.Core.Downloaders.VersionListDownloaders;
using Minecraft_Server_Downloader.Core.Storage;
using Minecraft_Server_Downloader.Structures;

namespace Minecraft_Server_Downloader.Core
{
    public class MinecraftServerDownloader
    {
        private readonly ILocalStorage _storage;
        private readonly IDataStorage _config;
        private List<VersionInfoFile> _localVersions;
        private IAsyncVersionListDownloader _remoteVersionListDownloader;
        private CancellationTokenSource _remoteVersionListDownloaderCancellationTokenSource;
        private IAsyncFileDownloader _downloader;

        public MinecraftServerDownloader()
        {
            var versionListFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "Distroir", "Minecraft Version Downloader", "server_versions.txt");
            
            _config = new FallbackDataStorage(
                new JsonDataStorage(), 
                new DefaultSettingsDataStorage(new Dictionary<string, object>
            {
                { "versionUpdaterSettings", new VersionUpdaterSettings()
                {
                    DownloadSynchronously = false, 
                    MaxConcurrentDownloads = 3, 
                    DownloadAllVersions = false
                } }
            }));
            
            _storage = new TextStorage(versionListFilePath);
        }

        public VersionUpdaterSettings VersionUpdaterSettings
        {
            get => _config.Get<VersionUpdaterSettings>("versionUpdaterSettings");
            set => _config.Set("versionUpdaterSettings", value);
        }

        public async Task Init()
        {
            // Check directories
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir"));
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader"));

            await _config.Load();
            await Task.Run(() => _localVersions = _storage.Load());
        }
        
        public async Task<IEnumerable<VersionInfoFile>> GetAllLocalServerVersions()
        {
            return await Task.FromResult(_localVersions);
        }
        
        public async Task<IEnumerable<VersionInfoFile>> GetLocalServerVersionsThat(Func<VersionInfoFile, bool> condition)
        {
            return await Task.FromResult(_localVersions.Where(condition));
        }

        public async Task UpdateLocalVersions(IProgress<AsyncDownloadProgress> versionUpdateProgress)
        {
            var settings = _config.Get<VersionUpdaterSettings>("versionUpdaterSettings");
            
            _remoteVersionListDownloaderCancellationTokenSource = new CancellationTokenSource();
            _remoteVersionListDownloader = settings.DownloadAllVersions switch
            {
                true => new StandardAsyncVersionListDownloader(
                    _remoteVersionListDownloaderCancellationTokenSource.Token,
                    settings),
                false => new IncrementalAsyncVersionListDownloader(
                    _remoteVersionListDownloaderCancellationTokenSource.Token,
                    _localVersions,
                    settings)
            };

            var versions = await _remoteVersionListDownloader
                .DownloadListOfVersions(versionUpdateProgress);
            _localVersions = new List<VersionInfoFile>(versions);
            _storage.Save(_localVersions);
        }

        public void CancelUpdatingLocalVersions()
        {
            _remoteVersionListDownloaderCancellationTokenSource.Cancel();
        }

        public async Task DownloadServer(string versionId, string filename, IProgress<AsyncDownloadProgress> fileDownloadProgress)
        {
            var versionUrl = _localVersions
                .Where(v => v.id == versionId)
                .Select(v => v.downloads.server.url)
                .FirstOrDefault();

            if (versionUrl is null)
                throw new ArgumentException($"Version with a key \"{versionId}\" doesn't exist in repository@");

            _downloader = new WebAsyncFileDownloader(fileDownloadProgress);
            await _downloader.DownloadFileAsync(versionUrl, filename);
        }

        public void CancelDownloadingServer()
        {
            _downloader.CancelAsync();
        }
    }
}