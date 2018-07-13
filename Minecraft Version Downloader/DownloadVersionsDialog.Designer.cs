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
            this.dlProgressBar.Location = new System.Drawing.Point(23, 84);
            this.dlProgressBar.Name = "dlProgressBar";
            this.dlProgressBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.dlProgressBar.Size = new System.Drawing.Size(487, 23);
            this.dlProgressBar.TabIndex = 0;
            // 
            // downloadInfoLabel
            // 
            this.downloadInfoLabel.AutoSize = true;
            this.downloadInfoLabel.Location = new System.Drawing.Point(23, 110);
            this.downloadInfoLabel.Name = "downloadInfoLabel";
            this.downloadInfoLabel.Size = new System.Drawing.Size(190, 20);
            this.downloadInfoLabel.TabIndex = 1;
            this.downloadInfoLabel.Text = "Downloading list of versions...";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(435, 155);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseSelectable = true;
            // 
            // DownloadVersionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 201);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.downloadInfoLabel);
            this.Controls.Add(this.dlProgressBar);
            this.Name = "DownloadVersionsDialog";
            this.Text = "Fetching version list...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar dlProgressBar;
        private MetroFramework.Controls.MetroLabel downloadInfoLabel;
        private MetroFramework.Controls.MetroButton cancelButton;
    }
}