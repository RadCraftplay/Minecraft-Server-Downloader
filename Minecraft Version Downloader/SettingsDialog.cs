using System;
using MetroFramework.Forms;
using Minecraft_Server_Downloader.Core.Downloaders;

namespace Minecraft_Server_Downloader
{
    public partial class SettingsDialog : MetroForm
    {
        private readonly VersionUpdaterSettings _settings;
        
        public SettingsDialog(VersionUpdaterSettings settings)
        {
            _settings = settings;
            
            InitializeComponent();
            ApplyConfigToControls();
        }

        public VersionUpdaterSettings Settings
        {
            get => _settings;
        }

        private void ApplyConfigToControls()
        {
            threadsNumericUpDown.Value = _settings.MaxConcurrentDownloads;
            checkBox1.Checked = _settings.DownloadSynchronously;
            checkBox2.Checked = _settings.DownloadAllVersions;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _settings.MaxConcurrentDownloads = (int)threadsNumericUpDown.Value;
            _settings.DownloadSynchronously = checkBox1.Checked;
            _settings.DownloadAllVersions = checkBox2.Checked;
        }
    }
}