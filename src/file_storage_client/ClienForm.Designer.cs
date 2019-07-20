namespace file_storage_client
{
    partial class ClienForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.readFileGETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilePUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFilePOSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileDELETEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadCOPYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFileCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonconnect = new System.Windows.Forms.Button();
            this.textBoxuri = new System.Windows.Forms.TextBox();
            this.labeluri = new System.Windows.Forms.Label();
            this.labelcontent = new System.Windows.Forms.Label();
            this.listViewfiles = new System.Windows.Forms.ListView();
            this.labelfiles = new System.Windows.Forms.Label();
            this.textBoxfilecontent = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBoxselectedfile = new System.Windows.Forms.TextBox();
            this.labelselectedfile = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFileGETToolStripMenuItem,
            this.addFilePUTToolStripMenuItem,
            this.changeFilePOSTToolStripMenuItem,
            this.deleteFileDELETEToolStripMenuItem,
            this.downloadCOPYToolStripMenuItem,
            this.copyFileCopyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // readFileGETToolStripMenuItem
            // 
            this.readFileGETToolStripMenuItem.Name = "readFileGETToolStripMenuItem";
            this.readFileGETToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.readFileGETToolStripMenuItem.Text = "Read file";
            this.readFileGETToolStripMenuItem.Click += new System.EventHandler(this.readFileGETToolStripMenuItem_Click);
            // 
            // addFilePUTToolStripMenuItem
            // 
            this.addFilePUTToolStripMenuItem.Name = "addFilePUTToolStripMenuItem";
            this.addFilePUTToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.addFilePUTToolStripMenuItem.Text = "Add file";
            this.addFilePUTToolStripMenuItem.Click += new System.EventHandler(this.addFilePUTToolStripMenuItem_Click);
            // 
            // changeFilePOSTToolStripMenuItem
            // 
            this.changeFilePOSTToolStripMenuItem.Name = "changeFilePOSTToolStripMenuItem";
            this.changeFilePOSTToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.changeFilePOSTToolStripMenuItem.Text = "Change file";
            this.changeFilePOSTToolStripMenuItem.Click += new System.EventHandler(this.changeFilePOSTToolStripMenuItem_Click);
            // 
            // deleteFileDELETEToolStripMenuItem
            // 
            this.deleteFileDELETEToolStripMenuItem.Name = "deleteFileDELETEToolStripMenuItem";
            this.deleteFileDELETEToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.deleteFileDELETEToolStripMenuItem.Text = "Delete File";
            this.deleteFileDELETEToolStripMenuItem.Click += new System.EventHandler(this.deleteFileDELETEToolStripMenuItem_Click);
            // 
            // downloadCOPYToolStripMenuItem
            // 
            this.downloadCOPYToolStripMenuItem.Name = "downloadCOPYToolStripMenuItem";
            this.downloadCOPYToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.downloadCOPYToolStripMenuItem.Text = "Download file";
            this.downloadCOPYToolStripMenuItem.Click += new System.EventHandler(this.copyFileCOPYToolStripMenuItem_Click);
            // 
            // copyFileCopyToolStripMenuItem
            // 
            this.copyFileCopyToolStripMenuItem.Name = "copyFileCopyToolStripMenuItem";
            this.copyFileCopyToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.copyFileCopyToolStripMenuItem.Text = "Copy file";
            this.copyFileCopyToolStripMenuItem.Click += new System.EventHandler(this.copyFileCopyToolStripMenuItem_Click_1);
            // 
            // buttonconnect
            // 
            this.buttonconnect.Location = new System.Drawing.Point(338, 60);
            this.buttonconnect.Name = "buttonconnect";
            this.buttonconnect.Size = new System.Drawing.Size(94, 24);
            this.buttonconnect.TabIndex = 7;
            this.buttonconnect.Text = "Connect";
            this.buttonconnect.UseVisualStyleBackColor = true;
            this.buttonconnect.Click += new System.EventHandler(this.buttoncheckid_Click);
            // 
            // textBoxuri
            // 
            this.textBoxuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxuri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBoxuri.Location = new System.Drawing.Point(456, 60);
            this.textBoxuri.Name = "textBoxuri";
            this.textBoxuri.Size = new System.Drawing.Size(302, 24);
            this.textBoxuri.TabIndex = 8;
            this.textBoxuri.Text = "http://localhost:8888/file_storage/";
            // 
            // labeluri
            // 
            this.labeluri.AutoSize = true;
            this.labeluri.Location = new System.Drawing.Point(545, 34);
            this.labeluri.Name = "labeluri";
            this.labeluri.Size = new System.Drawing.Size(60, 13);
            this.labeluri.TabIndex = 9;
            this.labeluri.Text = "Server URI";
            // 
            // labelcontent
            // 
            this.labelcontent.AutoSize = true;
            this.labelcontent.Location = new System.Drawing.Point(12, 41);
            this.labelcontent.Name = "labelcontent";
            this.labelcontent.Size = new System.Drawing.Size(62, 13);
            this.labelcontent.TabIndex = 10;
            this.labelcontent.Text = "File content";
            // 
            // listViewfiles
            // 
            this.listViewfiles.HideSelection = false;
            this.listViewfiles.Location = new System.Drawing.Point(338, 128);
            this.listViewfiles.Name = "listViewfiles";
            this.listViewfiles.Size = new System.Drawing.Size(420, 310);
            this.listViewfiles.TabIndex = 11;
            this.listViewfiles.UseCompatibleStateImageBehavior = false;
            this.listViewfiles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewfiles_ItemSelectionChanged);
            // 
            // labelfiles
            // 
            this.labelfiles.AutoSize = true;
            this.labelfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelfiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelfiles.Location = new System.Drawing.Point(477, 103);
            this.labelfiles.Name = "labelfiles";
            this.labelfiles.Size = new System.Drawing.Size(143, 22);
            this.labelfiles.TabIndex = 12;
            this.labelfiles.Text = "Files from server";
            // 
            // textBoxfilecontent
            // 
            this.textBoxfilecontent.Location = new System.Drawing.Point(12, 64);
            this.textBoxfilecontent.Multiline = true;
            this.textBoxfilecontent.Name = "textBoxfilecontent";
            this.textBoxfilecontent.Size = new System.Drawing.Size(256, 374);
            this.textBoxfilecontent.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxselectedfile
            // 
            this.textBoxselectedfile.Location = new System.Drawing.Point(108, 38);
            this.textBoxselectedfile.Name = "textBoxselectedfile";
            this.textBoxselectedfile.Size = new System.Drawing.Size(160, 20);
            this.textBoxselectedfile.TabIndex = 14;
            this.textBoxselectedfile.Text = "\r\n";
            // 
            // labelselectedfile
            // 
            this.labelselectedfile.AutoSize = true;
            this.labelselectedfile.Location = new System.Drawing.Point(150, 22);
            this.labelselectedfile.Name = "labelselectedfile";
            this.labelselectedfile.Size = new System.Drawing.Size(65, 13);
            this.labelselectedfile.TabIndex = 15;
            this.labelselectedfile.Text = "Selected file";
            // 
            // ClienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelselectedfile);
            this.Controls.Add(this.textBoxselectedfile);
            this.Controls.Add(this.textBoxfilecontent);
            this.Controls.Add(this.labelfiles);
            this.Controls.Add(this.listViewfiles);
            this.Controls.Add(this.labelcontent);
            this.Controls.Add(this.labeluri);
            this.Controls.Add(this.textBoxuri);
            this.Controls.Add(this.buttonconnect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClienForm";
            this.Text = "ClienForm";
            this.Load += new System.EventHandler(this.ClienForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem readFileGETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilePUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFilePOSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileDELETEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadCOPYToolStripMenuItem;
        private System.Windows.Forms.Button buttonconnect;
        private System.Windows.Forms.TextBox textBoxuri;
        private System.Windows.Forms.Label labeluri;
        private System.Windows.Forms.Label labelcontent;
        private System.Windows.Forms.ListView listViewfiles;
        private System.Windows.Forms.Label labelfiles;
        private System.Windows.Forms.TextBox textBoxfilecontent;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem copyFileCopyToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxselectedfile;
        private System.Windows.Forms.Label labelselectedfile;
    }
}