using System.ComponentModel;

namespace Minecraft_Server_Downloader
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.concurrentThreadsLabel = new MetroFramework.Controls.MetroLabel();
            this.threadsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.downloadVersionListSynchronouslyLabel = new MetroFramework.Controls.MetroLabel();
            this.updateAllVersionsLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // concurrentThreadsLabel
            // 
            this.concurrentThreadsLabel.Location = new System.Drawing.Point(23, 60);
            this.concurrentThreadsLabel.Name = "concurrentThreadsLabel";
            this.concurrentThreadsLabel.Size = new System.Drawing.Size(250, 23);
            this.concurrentThreadsLabel.TabIndex = 0;
            this.concurrentThreadsLabel.Text = "Concurrent downloading threads:";
            // 
            // threadsNumericUpDown
            // 
            this.threadsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.threadsNumericUpDown.Location = new System.Drawing.Point(279, 60);
            this.threadsNumericUpDown.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            this.threadsNumericUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.threadsNumericUpDown.Name = "threadsNumericUpDown";
            this.threadsNumericUpDown.Size = new System.Drawing.Size(348, 20);
            this.threadsNumericUpDown.TabIndex = 1;
            this.threadsNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(552, 303);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 24);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(28, 86);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(245, 25);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Download version list synchronously";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(28, 186);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(245, 25);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Update all versions";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // downloadVersionListSynchronouslyLabel
            // 
            this.downloadVersionListSynchronouslyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadVersionListSynchronouslyLabel.Location = new System.Drawing.Point(279, 86);
            this.downloadVersionListSynchronouslyLabel.Name = "downloadVersionListSynchronouslyLabel";
            this.downloadVersionListSynchronouslyLabel.Size = new System.Drawing.Size(348, 100);
            this.downloadVersionListSynchronouslyLabel.TabIndex = 3;
            this.downloadVersionListSynchronouslyLabel.Text = resources.GetString("downloadVersionListSynchronouslyLabel.Text");
            this.downloadVersionListSynchronouslyLabel.WrapToLine = true;
            // 
            // updateAllVersionsLabel
            // 
            this.updateAllVersionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.updateAllVersionsLabel.Location = new System.Drawing.Point(279, 186);
            this.updateAllVersionsLabel.Name = "updateAllVersionsLabel";
            this.updateAllVersionsLabel.Size = new System.Drawing.Size(348, 85);
            this.updateAllVersionsLabel.TabIndex = 5;
            this.updateAllVersionsLabel.Text = resources.GetString("updateAllVersionsLabel.Text");
            this.updateAllVersionsLabel.WrapToLine = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.updateAllVersionsLabel);
            this.Controls.Add(this.downloadVersionListSynchronouslyLabel);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.threadsNumericUpDown);
            this.Controls.Add(this.concurrentThreadsLabel);
            this.MaximumSize = new System.Drawing.Size(650, 350);
            this.MinimumSize = new System.Drawing.Size(650, 350);
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private MetroFramework.Controls.MetroLabel updateAllVersionsLabel;

        private MetroFramework.Controls.MetroLabel downloadVersionListSynchronouslyLabel;

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;

        private System.Windows.Forms.Button saveButton;

        private System.Windows.Forms.NumericUpDown threadsNumericUpDown;

        private MetroFramework.Controls.MetroLabel concurrentThreadsLabel;

        #endregion
    }
}