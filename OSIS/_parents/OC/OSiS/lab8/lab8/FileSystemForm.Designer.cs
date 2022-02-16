namespace lab8
{
    partial class FileSystemForm
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.nodeSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nodeAddress = new System.Windows.Forms.TextBox();
            this.nodeType = new System.Windows.Forms.TextBox();
            this.nodeName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.systemFreeSpace = new System.Windows.Forms.TextBox();
            this.systemAllSpace = new System.Windows.Forms.TextBox();
            this.systemClasterSize = new System.Windows.Forms.TextBox();
            this.fileText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonDirectory = new System.Windows.Forms.RadioButton();
            this.radioButtonFile = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newNodeName = new System.Windows.Forms.TextBox();
            this.addNewButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.filesTree = new System.Windows.Forms.TreeView();
            this.searchNode = new System.Windows.Forms.TextBox();
            this.saveToHardDisk = new System.Windows.Forms.Button();
            this.loadFromDisk = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Space";
            // 
            // nodeSize
            // 
            this.nodeSize.Location = new System.Drawing.Point(54, 111);
            this.nodeSize.Name = "nodeSize";
            this.nodeSize.Size = new System.Drawing.Size(136, 20);
            this.nodeSize.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Adress";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Name";
            // 
            // nodeAddress
            // 
            this.nodeAddress.Location = new System.Drawing.Point(54, 78);
            this.nodeAddress.Name = "nodeAddress";
            this.nodeAddress.Size = new System.Drawing.Size(136, 20);
            this.nodeAddress.TabIndex = 22;
            // 
            // nodeType
            // 
            this.nodeType.Location = new System.Drawing.Point(54, 48);
            this.nodeType.Name = "nodeType";
            this.nodeType.Size = new System.Drawing.Size(136, 20);
            this.nodeType.TabIndex = 21;
            // 
            // nodeName
            // 
            this.nodeName.Location = new System.Drawing.Point(54, 19);
            this.nodeName.Name = "nodeName";
            this.nodeName.Size = new System.Drawing.Size(136, 20);
            this.nodeName.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.nodeSize);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nodeAddress);
            this.groupBox3.Controls.Add(this.nodeType);
            this.groupBox3.Controls.Add(this.nodeName);
            this.groupBox3.Location = new System.Drawing.Point(508, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 147);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Node info";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Free space";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.systemFreeSpace);
            this.groupBox2.Controls.Add(this.systemAllSpace);
            this.groupBox2.Controls.Add(this.systemClasterSize);
            this.groupBox2.Location = new System.Drawing.Point(508, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 153);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File system info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Full space";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cluster size";
            // 
            // systemFreeSpace
            // 
            this.systemFreeSpace.Location = new System.Drawing.Point(81, 79);
            this.systemFreeSpace.Name = "systemFreeSpace";
            this.systemFreeSpace.Size = new System.Drawing.Size(109, 20);
            this.systemFreeSpace.TabIndex = 2;
            // 
            // systemAllSpace
            // 
            this.systemAllSpace.Location = new System.Drawing.Point(81, 49);
            this.systemAllSpace.Name = "systemAllSpace";
            this.systemAllSpace.Size = new System.Drawing.Size(109, 20);
            this.systemAllSpace.TabIndex = 1;
            // 
            // systemClasterSize
            // 
            this.systemClasterSize.Location = new System.Drawing.Point(81, 20);
            this.systemClasterSize.Name = "systemClasterSize";
            this.systemClasterSize.Size = new System.Drawing.Size(109, 20);
            this.systemClasterSize.TabIndex = 0;
            // 
            // fileText
            // 
            this.fileText.Location = new System.Drawing.Point(12, 82);
            this.fileText.Multiline = true;
            this.fileText.Name = "fileText";
            this.fileText.Size = new System.Drawing.Size(219, 159);
            this.fileText.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fileText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioButtonDirectory);
            this.groupBox1.Controls.Add(this.radioButtonFile);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.newNodeName);
            this.groupBox1.Controls.Add(this.addNewButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Location = new System.Drawing.Point(260, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 247);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Name";
            // 
            // radioButtonDirectory
            // 
            this.radioButtonDirectory.AutoSize = true;
            this.radioButtonDirectory.Checked = true;
            this.radioButtonDirectory.Location = new System.Drawing.Point(174, 59);
            this.radioButtonDirectory.Name = "radioButtonDirectory";
            this.radioButtonDirectory.Size = new System.Drawing.Size(54, 17);
            this.radioButtonDirectory.TabIndex = 6;
            this.radioButtonDirectory.TabStop = true;
            this.radioButtonDirectory.Text = "Folder";
            this.radioButtonDirectory.UseVisualStyleBackColor = true;
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize = true;
            this.radioButtonFile.Location = new System.Drawing.Point(174, 24);
            this.radioButtonFile.Name = "radioButtonFile";
            this.radioButtonFile.Size = new System.Drawing.Size(41, 17);
            this.radioButtonFile.TabIndex = 7;
            this.radioButtonFile.Text = "File";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(62, 19);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(44, 27);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Del";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newNodeName
            // 
            this.newNodeName.Location = new System.Drawing.Point(50, 58);
            this.newNodeName.Name = "newNodeName";
            this.newNodeName.Size = new System.Drawing.Size(118, 20);
            this.newNodeName.TabIndex = 9;
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(12, 19);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(44, 27);
            this.addNewButton.TabIndex = 10;
            this.addNewButton.Text = "Add";
            this.addNewButton.UseVisualStyleBackColor = true;
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(112, 19);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(46, 27);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // filesTree
            // 
            this.filesTree.Location = new System.Drawing.Point(12, 71);
            this.filesTree.Name = "filesTree";
            this.filesTree.Size = new System.Drawing.Size(242, 241);
            this.filesTree.TabIndex = 23;
            this.filesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.filesTree_AfterSelect);
            // 
            // searchNode
            // 
            this.searchNode.Location = new System.Drawing.Point(6, 19);
            this.searchNode.Name = "searchNode";
            this.searchNode.Size = new System.Drawing.Size(206, 20);
            this.searchNode.TabIndex = 21;
            // 
            // saveToHardDisk
            // 
            this.saveToHardDisk.Location = new System.Drawing.Point(285, 19);
            this.saveToHardDisk.Name = "saveToHardDisk";
            this.saveToHardDisk.Size = new System.Drawing.Size(80, 20);
            this.saveToHardDisk.TabIndex = 24;
            this.saveToHardDisk.Text = "Save to disk";
            this.saveToHardDisk.UseVisualStyleBackColor = true;
            this.saveToHardDisk.Click += new System.EventHandler(this.saveToHardDisk_Click);
            // 
            // loadFromDisk
            // 
            this.loadFromDisk.Location = new System.Drawing.Point(368, 19);
            this.loadFromDisk.Name = "loadFromDisk";
            this.loadFromDisk.Size = new System.Drawing.Size(95, 20);
            this.loadFromDisk.TabIndex = 25;
            this.loadFromDisk.Text = "Unload from disk";
            this.loadFromDisk.UseVisualStyleBackColor = true;
            this.loadFromDisk.Click += new System.EventHandler(this.loadFromDisk_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(218, 19);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(61, 20);
            this.searchButton.TabIndex = 29;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.searchButton);
            this.groupBox4.Controls.Add(this.loadFromDisk);
            this.groupBox4.Controls.Add(this.saveToHardDisk);
            this.groupBox4.Controls.Add(this.searchNode);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(490, 53);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // FileSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 328);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filesTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileSystemForm";
            this.Text = "FileSystem";
            this.Load += new System.EventHandler(this.FileSystemForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nodeSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nodeAddress;
        private System.Windows.Forms.TextBox nodeType;
        private System.Windows.Forms.TextBox nodeName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox systemFreeSpace;
        private System.Windows.Forms.TextBox systemAllSpace;
        private System.Windows.Forms.TextBox systemClasterSize;
        private System.Windows.Forms.TextBox fileText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonDirectory;
        private System.Windows.Forms.RadioButton radioButtonFile;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox newNodeName;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TreeView filesTree;
        private System.Windows.Forms.TextBox searchNode;
        private System.Windows.Forms.Button saveToHardDisk;
        private System.Windows.Forms.Button loadFromDisk;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

