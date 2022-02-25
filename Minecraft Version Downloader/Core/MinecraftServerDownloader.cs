using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private List<VersionInfoFile> _localVersions;
        private IAsyncVersionListDownloader _remoteVersionListDownloader;
        private CancellationTokenSource _remoteVersionListDownloaderCancellationTokenSource;
        private IAsyncFileDownloader _downloader;

        public MinecraftServerDownloader()
        {
            var versionListFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "Distroir", "Minecraft Version Downloader", "server_versions.txt");
            _storage = new TextStorage(versionListFilePath);
        }

        public async Task Init()
        {
            // Check directories
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir"));
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Minecraft Version Downloader"));
            
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
            _remoteVersionListDownloaderCancellationTokenSource = new CancellationTokenSource();
            _remoteVersionListDownloader =
                new IncrementalAsyncVersionListDownloader(_remoteVersionListDownloaderCancellationTokenSource.Token,
                    _localVersions);
            
            var versions = await _remoteVersionListDownloader
                .DownloadListOfVersions(versionUpdateProgress);
            _localVersions = new List<VersionInfoFile>(versions);
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