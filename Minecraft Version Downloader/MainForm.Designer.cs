/*
	This file is part of Minecraft Server Downloader.

	Copyright (C) 2016 Distroir

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
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.refreshButton = new MetroFramework.Controls.MetroButton();
            this.downloadButton = new MetroFramework.Controls.MetroButton();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.serverVersionFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.otherCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.snapshotCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.releaseCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.serverVersionFiltersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroListView1
            // 
            this.metroListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(31, 78);
            this.metroListView1.Margin = new System.Windows.Forms.Padding(4);
            this.metroListView1.MultiSelect = false;
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(401, 345);
            this.metroListView1.TabIndex = 0;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            this.metroListView1.View = System.Windows.Forms.View.List;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshButton.Location = new System.Drawing.Point(32, 524);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 28);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseSelectable = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Location = new System.Drawing.Point(333, 524);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(100, 28);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseSelectable = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroProgressBar1.Location = new System.Drawing.Point(32, 488);
            this.metroProgressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(401, 28);
            this.metroProgressBar1.TabIndex = 3;
            // 
            // serverVersionFiltersGroupBox
            // 
            this.serverVersionFiltersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverVersionFiltersGroupBox.Controls.Add(this.otherCheckBox);
            this.serverVersionFiltersGroupBox.Controls.Add(this.snapshotCheckBox);
            this.serverVersionFiltersGroupBox.Controls.Add(this.releaseCheckBox);
            this.serverVersionFiltersGroupBox.Location = new System.Drawing.Point(32, 431);
            this.serverVersionFiltersGroupBox.Name = "serverVersionFiltersGroupBox";
            this.serverVersionFiltersGroupBox.Size = new System.Drawing.Size(400, 50);
            this.serverVersionFiltersGroupBox.TabIndex = 5;
            this.serverVersionFiltersGroupBox.TabStop = false;
            this.serverVersionFiltersGroupBox.Text = "Server type";
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.AutoSize = true;
            this.otherCheckBox.Checked = true;
            this.otherCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.otherCheckBox.Location = new System.Drawing.Point(165, 21);
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.Size = new System.Drawing.Size(57, 17);
            this.otherCheckBox.TabIndex = 4;
            this.otherCheckBox.Tag = "unknown";
            this.otherCheckBox.Text = "Other";
            this.otherCheckBox.UseSelectable = true;
            this.otherCheckBox.CheckedChanged += new System.EventHandler(this.FilterCheckBox_CheckedChanged);
            // 
            // snapshotCheckBox
            // 
            this.snapshotCheckBox.AutoSize = true;
            this.snapshotCheckBox.Checked = true;
            this.snapshotCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snapshotCheckBox.Location = new System.Drawing.Point(81, 21);
            this.snapshotCheckBox.Name = "snapshotCheckBox";
            this.snapshotCheckBox.Size = new System.Drawing.Size(78, 17);
            this.snapshotCheckBox.TabIndex = 4;
            this.snapshotCheckBox.Tag = "snapshot";
            this.snapshotCheckBox.Text = "Snapshot";
            this.snapshotCheckBox.UseSelectable = true;
            this.snapshotCheckBox.CheckedChanged += new System.EventHandler(this.FilterCheckBox_CheckedChanged);
            // 
            // releaseCheckBox
            // 
            this.releaseCheckBox.AutoSize = true;
            this.releaseCheckBox.Checked = true;
            this.releaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.releaseCheckBox.Location = new System.Drawing.Point(6, 21);
            this.releaseCheckBox.Name = "releaseCheckBox";
            this.releaseCheckBox.Size = new System.Drawing.Size(69, 17);
            this.releaseCheckBox.TabIndex = 4;
            this.releaseCheckBox.Tag = "release";
            this.releaseCheckBox.Text = "Release";
            this.releaseCheckBox.UseSelectable = true;
            this.releaseCheckBox.CheckedChanged += new System.EventHandler(this.FilterCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 581);
            this.Controls.Add(this.serverVersionFiltersGroupBox);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.metroListView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(464, 575);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Minecraft Server Downloader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.serverVersionFiltersGroupBox.ResumeLayout(false);
            this.serverVersionFiltersGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroListView metroListView1;
        private MetroFramework.Controls.MetroButton refreshButton;
        private MetroFramework.Controls.MetroButton downloadButton;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private System.Windows.Forms.GroupBox serverVersionFiltersGroupBox;
        private MetroFramework.Controls.MetroCheckBox otherCheckBox;
        private MetroFramework.Controls.MetroCheckBox snapshotCheckBox;
        private MetroFramework.Controls.MetroCheckBox releaseCheckBox;
    }
}