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