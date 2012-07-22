using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DropNet;
using DropNet.Models;

namespace Mat.Helpers.DropboxConfiguration
{
    public partial class FolderBrowser : Form
    {
        private readonly DropNetClient _client;
        public FolderBrowser(DropNetClient client)
        {
            _client = client;
            InitializeComponent();

            treeView.Nodes.Add(Recurse("/"));
        }

        private TreeNode Recurse(String path)
        {
            if (IsDisposed) return null;
            var name = "Dropbox";
            if (path != "/")
            {
                name = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).Last();
            }
            var node = new TreeNode(name);
            node.Nodes.Add(new TreeNode("Loading folders"));
            node.Tag = path;

            return node;
        }

        private static string BuildPath(TreeNode node)
        {
            if (node.Parent == null)
            {
                return String.Empty;
            }
            return BuildPath(node.Parent) + "/" + node.Text;
        }

        public string Path
        {
            get { return (string)(treeView.SelectedNode.Tag); }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            OKButton.Enabled = true;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var path = (String) e.Node.Tag;
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "Loading folders")
            {
                _client.GetMetaDataAsync(path, data => {
                    Invoke((MethodInvoker) (() => e.Node.Nodes.RemoveAt(0)));
                    foreach (var child in data.Contents.Where(d => d.Is_Dir))
                    {
                        var childNode = Recurse(child.Path);
                        if (childNode != null && !IsDisposed)
                        {
                            Invoke((MethodInvoker)(() => e.Node.Nodes.Add(childNode)));
                        }
                    }
                }, exception => { });
            }
        }
    }
}
