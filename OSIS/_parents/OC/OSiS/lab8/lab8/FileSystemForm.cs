using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class FileSystemForm : Form
    {
        SystemAddressSpace SystemAddressSpace { get; }

        public FileSystemForm()
        {
            InitializeComponent();

            var size = 1024;
            var blockSize = 8;

            SystemAddressSpace = new SystemAddressSpace(size, blockSize);

            FillSystemInfo();

            FillTree(filesTree.TopNode, 0);
        }

        void FillTree(TreeNode treeNode, int index)
        {
            var systemNode = SystemAddressSpace.GetAddressSpaceBlock(index) as SystemNode;
            TreeNode newNode = null;
            if (treeNode == null)
                newNode = filesTree.Nodes.Add(systemNode.Name);
            else
                newNode = treeNode.Nodes.Add(systemNode.Name);

            newNode.Tag = systemNode;
            if (systemNode.Type == "Dictionary")
            {
                var dict = systemNode as SystemNodeDirectory;
                foreach (var elem in dict.innerFilesAddresses)                
                    FillTree(newNode, elem);                
            }
        }

        void FillSystemInfo()
        {
            systemClasterSize.Text = SystemAddressSpace.BlockSize.ToString();
            systemAllSpace.Text = SystemAddressSpace.Size.ToString();
            systemFreeSpace.Text = SystemAddressSpace.FreeSpace().ToString();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if ((filesTree.SelectedNode.Tag as SystemNode).Type != "Directory")
            {
                var prevNewNodeIndex = (filesTree.SelectedNode.Parent.Tag as SystemNode).Index;
                var newNodeIndex = (filesTree.SelectedNode.Tag as SystemNode).Index;

                (SystemAddressSpace.GetAddressSpaceBlock(prevNewNodeIndex) as SystemNodeDirectory).RemoveNode(newNodeIndex);

                if (radioButtonDirectory.Checked)
                    (SystemAddressSpace.GetAddressSpaceBlock(prevNewNodeIndex) as SystemNodeDirectory)
                        .AddNode(new SystemNodeDirectory
                        (
                            SystemAddressSpace,
                            newNodeIndex,
                            newNodeName.Text
                        ), newNodeIndex);
                else
                    (SystemAddressSpace.GetAddressSpaceBlock(prevNewNodeIndex) as SystemNodeDirectory)
                        .AddNode(new SystemNodeFile
                        (
                            SystemAddressSpace,
                            newNodeIndex,
                            newNodeName.Text,
                            fileText.Text
                        ), newNodeIndex);

                SystemNode newNode = SystemAddressSpace.GetAddressSpaceBlock(newNodeIndex) as SystemNode;

                filesTree.SelectedNode.Tag = newNode;
                filesTree.SelectedNode.Text = newNode.Name;

                FillSystemInfo();

                Refresh();
            }
            else
                MessageBox.Show("This is directory");
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            if (newNodeName.Text.Length != 0)
            {
                var prevNewNodeIndex = 0;
                var newNodeIndex = SystemAddressSpace.GetWasteBlockAdress();

                if (filesTree.SelectedNode == null)
                    filesTree.SelectedNode = filesTree.Nodes[0];

                if (filesTree.SelectedNode.Parent != null)
                    prevNewNodeIndex = (filesTree.SelectedNode.Parent.Tag as SystemNode).Index;

                if ((filesTree.SelectedNode.Tag as SystemNode).Type == "Directory")
                    prevNewNodeIndex = (filesTree.SelectedNode.Tag as SystemNode).Index;                
                else                
                    prevNewNodeIndex = (filesTree.SelectedNode.Parent.Tag as SystemNode).Index;
                

                if (radioButtonDirectory.Checked)
                    (SystemAddressSpace.GetAddressSpaceBlock(prevNewNodeIndex) as SystemNodeDirectory)
                        .AddNode(new SystemNodeDirectory
                        (
                            SystemAddressSpace,
                            newNodeIndex,
                            newNodeName.Text
                        ), newNodeIndex);
                else
                    (SystemAddressSpace.GetAddressSpaceBlock(prevNewNodeIndex) as SystemNodeDirectory)
                        .AddNode(new SystemNodeFile
                        (
                            SystemAddressSpace,
                            newNodeIndex,
                            newNodeName.Text,
                            fileText.Text
                        ), newNodeIndex);

                SystemNode newNode = SystemAddressSpace.GetAddressSpaceBlock(newNodeIndex) as SystemNode;

                if ((filesTree.SelectedNode.Tag as SystemNode).Type == "Directory")
                {
                    var node = filesTree.SelectedNode.Nodes.Add(newNode.Name);
                    node.Tag = newNode;
                }
                else
                {
                    var node = filesTree.SelectedNode.Parent.Nodes.Add(newNode.Name);
                    node.Tag = newNode;
                }

                FillSystemInfo();

                Refresh();
            }
            else
                MessageBox.Show("Enter name of the file or the directory");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var deletingNodeIndex = (filesTree.SelectedNode.Tag as SystemNode).Index;
            SystemAddressSpace.Remove(deletingNodeIndex);

            filesTree.SelectedNode.Remove();
            FillSystemInfo();
            Refresh();
        }

        private void filesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var treeNode = filesTree.SelectedNode?.Tag as SystemNode;
            if (treeNode != null)
            {
                if (treeNode.Type == "Directory")
                {
                    var systemNodeDirectory = treeNode as SystemNodeDirectory;
                    nodeName.Text = systemNodeDirectory.Name;
                    nodeType.Text = systemNodeDirectory.Type;
                    nodeAddress.Text = systemNodeDirectory.Index.ToString();
                    nodeSize.Text = systemNodeDirectory.GetSize().ToString();
                }
                else
                {
                    newNodeName.Text = treeNode.Name;
                    var systemNodeFile = treeNode as SystemNodeFile;
                    nodeName.Text = systemNodeFile.Name;
                    nodeType.Text = systemNodeFile.Type;
                    nodeAddress.Text = systemNodeFile.Index.ToString();
                    nodeSize.Text = systemNodeFile.GetSize().ToString();
                    fileText.Text = systemNodeFile.ToString();
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var address = SystemAddressSpace.FindByBinarySearch(searchNode.Text);
            if (address < 0)
                return;

            var node = FindNode(filesTree.Nodes[0], address);
            filesTree.SelectedNode = node;
            filesTree_AfterSelect(sender, null);
        }

        TreeNode FindNode(TreeNode treeNode, int address)
        {
            if ((treeNode.Tag as SystemNode).Index == address)
                return treeNode;

            foreach (TreeNode node in treeNode.Nodes)
            {
                var tmp = FindNode(node, address);
                if (tmp != null)
                    return tmp;
            }
            return null;
        }

        private void saveToHardDisk_Click(object sender, EventArgs e)
        {
            if ((filesTree.SelectedNode.Tag as SystemNode).Type == "Directory")
            {
                return;
            }
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FileName = (filesTree.SelectedNode.Tag as SystemNode).Name;

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog1.FileName;
                var text = (filesTree.SelectedNode.Tag as SystemNodeFile).ToString();

                File.WriteAllText(path, text);
            }
        }

        private void loadFromDisk_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)| *.txt";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                var name = openFileDialog1.SafeFileName;
                var text = File.ReadAllText(path);

                if (filesTree.SelectedNode == null)
                    filesTree.SelectedNode = filesTree.Nodes[0];

                var newNodeIndex = SystemAddressSpace.GetWasteBlockAdress();
                int prevNewNodeIndex = 0;
                if ((filesTree.SelectedNode.Tag as SystemNode).Type == "Directory")
                    prevNewNodeIndex = (filesTree.SelectedNode.Tag as SystemNode).Index;
                else
                    prevNewNodeIndex = (filesTree.SelectedNode.Parent.Tag as SystemNode).Index;

                (SystemAddressSpace.GetAddressSpaceBlock(prevNewNodeIndex) as SystemNodeDirectory)
                    .AddNode(new SystemNodeFile
                    (
                        SystemAddressSpace,
                        newNodeIndex,
                        name,
                        text
                    ), newNodeIndex);

                SystemNode newNode = SystemAddressSpace.GetAddressSpaceBlock(newNodeIndex) as SystemNode;
                if ((filesTree.SelectedNode.Tag as SystemNode).Type == "Directory")
                {
                    var node = filesTree.SelectedNode.Nodes.Add(newNode.Name);
                    node.Tag = newNode;
                }
                else
                {
                    var node = filesTree.SelectedNode.Parent.Nodes.Add(newNode.Name);
                    node.Tag = newNode;
                }
            }

            FillSystemInfo();

            Refresh();
        }

        private void FileSystemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
