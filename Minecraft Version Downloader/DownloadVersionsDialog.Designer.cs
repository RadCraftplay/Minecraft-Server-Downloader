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
namespace Minecraft_Server_Downloader
{
    partial class DownloadVersionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.downloadInfoLabel = new MetroFramework.Controls.MetroLabel();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // dlProgressBar
            // 
            this.dlProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlProgressBar.Location = new System.Drawing.Point(17, 68);
            this.dlProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dlProgressBar.Name = "dlProgressBar";
            this.dlProgressBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.dlProgressBar.Size = new System.Drawing.Size(365, 19);
            this.dlProgressBar.TabIndex = 0;
            // 
            // downloadInfoLabel
            // 
            this.downloadInfoLabel.AutoSize = true;
            this.downloadInfoLabel.Location = new System.Drawing.Point(17, 89);
            this.downloadInfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.downloadInfoLabel.Name = "downloadInfoLabel";
            this.downloadInfoLabel.Size = new System.Drawing.Size(180, 19);
            this.downloadInfoLabel.TabIndex = 1;
            this.downloadInfoLabel.Text = "Downloading list of versions...";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(326, 126);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 19);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DownloadVersionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 163);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downloadInfoLabel);
            this.Controls.Add(this.dlProgressBar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DownloadVersionsDialog";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.ShowInTaskbar = false;
            this.Text = "Fetching list of versions...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadVersionsDialog_FormClosing);
            this.Load += new System.EventHandler(this.DownloadVersionsDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar dlProgressBar;
        private MetroFramework.Controls.MetroLabel downloadInfoLabel;
        private MetroFramework.Controls.MetroButton cancelButton;
    }
}