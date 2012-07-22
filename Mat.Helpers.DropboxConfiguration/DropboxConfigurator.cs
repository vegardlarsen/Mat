using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DropNet;

namespace Mat.Helpers.DropboxConfiguration
{
    public partial class DropboxConfigurator : Form
    {
        private DropNetClient _client;

        public DropboxConfigurator()
        {
            InitializeComponent();
        }

        private void Group1NextButtonClick(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            _client = new DropNetClient(AppKey.Text, AppSecret.Text);
            _client.UserLogin = _client.GetToken();
            webBrowser.Navigate(_client.BuildAuthorizeUrl());
            groupBox2.Enabled = true;
        }

        private void UpdateConfigText()
        {
            WebConfig.Text = String.Format(
                "<dropbox key=\"{0}\" secret=\"{1}\" userToken=\"{2}\" userSecret=\"{3}\" {4} {5} {6} />",
                  AppKey.Text,
                  AppSecret.Text,
                  _client.UserLogin.Token,
                  _client.UserLogin.Secret,
                  RecursiveCheckbox.Checked ? "recursive=\"true\"" : String.Empty,
                  FolderLabel.Text != "/" ? String.Format("path=\"{0}\"", FolderLabel.Text) : string.Empty,
                  LocalCopyCheckbox.Checked ? "local=\"true\"" : String.Empty);
        }

        private void Group2NextButtonClick(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            _client.GetAccessToken();

            groupBox3.Enabled = true;
            UpdateConfigText();
        }

        private void SandboxCheckboxCheckedChanged(object sender, EventArgs e)
        {
            _client.UseSandbox = SandboxCheckbox.Checked;
            UpdateConfigText();
        }

        private void PickFolderButtonClick(object sender, EventArgs e)
        {
            PickFolderButton.Enabled = true;
            var fb = new FolderBrowser(_client);
            fb.ShowDialog();
            if (fb.DialogResult == DialogResult.OK)
            {
                FolderLabel.Text = fb.Path;
            }
            UpdateConfigText();
        }

        private void RecursiveCheckboxCheckedChanged(object sender, EventArgs e)
        {
            UpdateConfigText();
        }
    }
}
