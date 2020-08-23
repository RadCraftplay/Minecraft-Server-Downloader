using System;
using Minecraft_Server_Downloader.Core.Downloaders;

namespace Minecraft_Server_Downloader.Utils
{
    public class ProgressReporter
    {
        private IProgress<AsyncDownloadProgress> _progress;
        private object _progressReportLock = new object();
        private int _current = 0;
        private readonly int _all;

        public ProgressReporter(IProgress<AsyncDownloadProgress> progress, int all)
        {
            _progress = progress;
            _all = all;
        }

        public void Report()
        {
            lock(_progressReportLock)
                _progress.Report(new AsyncDownloadProgress(++_current, _all));
        }
    }
}
