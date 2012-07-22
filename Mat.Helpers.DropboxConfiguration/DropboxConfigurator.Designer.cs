namespace Mat.Helpers.DropboxConfiguration
{
    partial class DropboxConfigurator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Group1NextButton = new System.Windows.Forms.Button();
            this.AppSecret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AppKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Group2NextButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WebConfig = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.PickFolderButton = new System.Windows.Forms.Button();
            this.RecursiveCheckbox = new System.Windows.Forms.CheckBox();
            this.SandboxCheckbox = new System.Windows.Forms.CheckBox();
            this.LocalCopyCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Group1NextButton);
            this.groupBox1.Controls.Add(this.AppSecret);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AppKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1";
            // 
            // Group1NextButton
            // 
            this.Group1NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Group1NextButton.Location = new System.Drawing.Point(534, 71);
            this.Group1NextButton.Name = "Group1NextButton";
            this.Group1NextButton.Size = new System.Drawing.Size(42, 23);
            this.Group1NextButton.TabIndex = 9;
            this.Group1NextButton.Text = "Next";
            this.Group1NextButton.UseVisualStyleBackColor = true;
            this.Group1NextButton.Click += new System.EventHandler(this.Group1NextButtonClick);
            // 
            // AppSecret
            // 
            this.AppSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppSecret.Location = new System.Drawing.Point(103, 45);
            this.AppSecret.Name = "AppSecret";
            this.AppSecret.Size = new System.Drawing.Size(473, 20);
            this.AppSecret.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Application secret";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AppKey
            // 
            this.AppKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppKey.Location = new System.Drawing.Point(103, 19);
            this.AppKey.Name = "AppKey";
            this.AppKey.Size = new System.Drawing.Size(473, 20);
            this.AppKey.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Application key";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Group2NextButton);
            this.groupBox2.Controls.Add(this.webBrowser);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 372);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2";
            // 
            // Group2NextButton
            // 
            this.Group2NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Group2NextButton.Location = new System.Drawing.Point(534, 343);
            this.Group2NextButton.Name = "Group2NextButton";
            this.Group2NextButton.Size = new System.Drawing.Size(42, 23);
            this.Group2NextButton.TabIndex = 10;
            this.Group2NextButton.Text = "Next";
            this.Group2NextButton.UseVisualStyleBackColor = true;
            this.Group2NextButton.Click += new System.EventHandler(this.Group2NextButtonClick);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(6, 19);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(570, 318);
            this.webBrowser.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.WebConfig);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 620);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(582, 128);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Copy this into your web.config file";
            // 
            // WebConfig
            // 
            this.WebConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebConfig.Location = new System.Drawing.Point(9, 41);
            this.WebConfig.Multiline = true;
            this.WebConfig.Name = "WebConfig";
            this.WebConfig.ReadOnly = true;
            this.WebConfig.Size = new System.Drawing.Size(567, 81);
            this.WebConfig.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.LocalCopyCheckbox);
            this.groupBox4.Controls.Add(this.FolderLabel);
            this.groupBox4.Controls.Add(this.PickFolderButton);
            this.groupBox4.Controls.Add(this.RecursiveCheckbox);
            this.groupBox4.Controls.Add(this.SandboxCheckbox);
            this.groupBox4.Location = new System.Drawing.Point(12, 496);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(582, 118);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 3";
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(87, 94);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(12, 13);
            this.FolderLabel.TabIndex = 3;
            this.FolderLabel.Text = "/";
            // 
            // PickFolderButton
            // 
            this.PickFolderButton.Location = new System.Drawing.Point(6, 89);
            this.PickFolderButton.Name = "PickFolderButton";
            this.PickFolderButton.Size = new System.Drawing.Size(75, 23);
            this.PickFolderButton.TabIndex = 2;
            this.PickFolderButton.Text = "Pick folder";
            this.PickFolderButton.UseVisualStyleBackColor = true;
            this.PickFolderButton.Click += new System.EventHandler(this.PickFolderButtonClick);
            // 
            // RecursiveCheckbox
            // 
            this.RecursiveCheckbox.AutoSize = true;
            this.RecursiveCheckbox.Checked = true;
            this.RecursiveCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RecursiveCheckbox.Location = new System.Drawing.Point(6, 43);
            this.RecursiveCheckbox.Name = "RecursiveCheckbox";
            this.RecursiveCheckbox.Size = new System.Drawing.Size(395, 17);
            this.RecursiveCheckbox.TabIndex = 1;
            this.RecursiveCheckbox.Text = "Recurse into subfolders (can be quite a bit slower if you have many subfolders)";
            this.RecursiveCheckbox.UseVisualStyleBackColor = true;
            this.RecursiveCheckbox.CheckedChanged += new System.EventHandler(this.RecursiveCheckboxCheckedChanged);
            // 
            // SandboxCheckbox
            // 
            this.SandboxCheckbox.AutoSize = true;
            this.SandboxCheckbox.Checked = true;
            this.SandboxCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SandboxCheckbox.Location = new System.Drawing.Point(6, 19);
            this.SandboxCheckbox.Name = "SandboxCheckbox";
            this.SandboxCheckbox.Size = new System.Drawing.Size(374, 17);
            this.SandboxCheckbox.TabIndex = 0;
            this.SandboxCheckbox.Text = "Use sandbox folder (this must match the privileges for the application key!)";
            this.SandboxCheckbox.UseVisualStyleBackColor = true;
            this.SandboxCheckbox.CheckedChanged += new System.EventHandler(this.SandboxCheckboxCheckedChanged);
            // 
            // LocalCopyCheckbox
            // 
            this.LocalCopyCheckbox.AutoSize = true;
            this.LocalCopyCheckbox.Location = new System.Drawing.Point(6, 66);
            this.LocalCopyCheckbox.Name = "LocalCopyCheckbox";
            this.LocalCopyCheckbox.Size = new System.Drawing.Size(128, 17);
            this.LocalCopyCheckbox.TabIndex = 4;
            this.LocalCopyCheckbox.Text = "Serve from local copy";
            this.LocalCopyCheckbox.UseVisualStyleBackColor = true;
            // 
            // DropboxConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 760);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DropboxConfigurator";
            this.Text = "Dropbox configurator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Group1NextButton;
        private System.Windows.Forms.TextBox AppSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AppKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WebConfig;
        private System.Windows.Forms.Button Group2NextButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox SandboxCheckbox;
        private System.Windows.Forms.CheckBox RecursiveCheckbox;
        private System.Windows.Forms.Button PickFolderButton;
        private System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.CheckBox LocalCopyCheckbox;


    }
}

