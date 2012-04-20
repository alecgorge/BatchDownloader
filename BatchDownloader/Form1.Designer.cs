namespace BatchDownloader
{
    partial class batchDownloader
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
			this.layout = new System.Windows.Forms.TableLayoutPanel();
			this.buttonWrap = new System.Windows.Forms.Panel();
			this.concurrentCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.about = new System.Windows.Forms.Button();
			this.openFolder = new System.Windows.Forms.Button();
			this.saveDir = new System.Windows.Forms.TextBox();
			this.browse = new System.Windows.Forms.Button();
			this.download = new System.Windows.Forms.Button();
			this.progressGrid = new System.Windows.Forms.DataGridView();
			this.urlBox = new System.Windows.Forms.TextBox();
			this.layout.SuspendLayout();
			this.buttonWrap.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.progressGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// layout
			// 
			this.layout.ColumnCount = 1;
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.Controls.Add(this.buttonWrap, 0, 1);
			this.layout.Controls.Add(this.progressGrid, 0, 2);
			this.layout.Controls.Add(this.urlBox, 0, 0);
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(0, 0);
			this.layout.Name = "layout";
			this.layout.RowCount = 3;
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.layout.Size = new System.Drawing.Size(863, 462);
			this.layout.TabIndex = 0;
			// 
			// buttonWrap
			// 
			this.buttonWrap.Controls.Add(this.concurrentCount);
			this.buttonWrap.Controls.Add(this.label1);
			this.buttonWrap.Controls.Add(this.about);
			this.buttonWrap.Controls.Add(this.openFolder);
			this.buttonWrap.Controls.Add(this.saveDir);
			this.buttonWrap.Controls.Add(this.browse);
			this.buttonWrap.Controls.Add(this.download);
			this.buttonWrap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonWrap.Location = new System.Drawing.Point(3, 212);
			this.buttonWrap.Name = "buttonWrap";
			this.buttonWrap.Size = new System.Drawing.Size(857, 54);
			this.buttonWrap.TabIndex = 0;
			// 
			// concurrentCount
			// 
			this.concurrentCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.concurrentCount.Location = new System.Drawing.Point(408, 18);
			this.concurrentCount.Name = "concurrentCount";
			this.concurrentCount.Size = new System.Drawing.Size(23, 20);
			this.concurrentCount.TabIndex = 7;
			this.concurrentCount.Text = "1";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(284, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Concurrent Downloads:";
			// 
			// about
			// 
			this.about.Location = new System.Drawing.Point(142, 15);
			this.about.Name = "about";
			this.about.Size = new System.Drawing.Size(75, 23);
			this.about.TabIndex = 5;
			this.about.Text = "About";
			this.about.UseVisualStyleBackColor = true;
			this.about.Click += new System.EventHandler(this.about_Click);
			// 
			// openFolder
			// 
			this.openFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openFolder.Location = new System.Drawing.Point(779, 16);
			this.openFolder.Name = "openFolder";
			this.openFolder.Size = new System.Drawing.Size(75, 23);
			this.openFolder.TabIndex = 4;
			this.openFolder.Text = "Open folder";
			this.openFolder.UseVisualStyleBackColor = true;
			this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
			// 
			// saveDir
			// 
			this.saveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveDir.Location = new System.Drawing.Point(464, 18);
			this.saveDir.Name = "saveDir";
			this.saveDir.Size = new System.Drawing.Size(228, 20);
			this.saveDir.TabIndex = 2;
			this.saveDir.Text = "Folder to save files to...";
			// 
			// browse
			// 
			this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browse.Location = new System.Drawing.Point(698, 16);
			this.browse.Name = "browse";
			this.browse.Size = new System.Drawing.Size(75, 23);
			this.browse.TabIndex = 3;
			this.browse.Text = "Browse";
			this.browse.UseVisualStyleBackColor = true;
			this.browse.Click += new System.EventHandler(this.browse_Click);
			// 
			// download
			// 
			this.download.Location = new System.Drawing.Point(3, 3);
			this.download.Name = "download";
			this.download.Size = new System.Drawing.Size(132, 49);
			this.download.TabIndex = 1;
			this.download.Text = "Download";
			this.download.UseVisualStyleBackColor = true;
			this.download.Click += new System.EventHandler(this.button1_Click);
			// 
			// progressGrid
			// 
			this.progressGrid.AllowUserToAddRows = false;
			this.progressGrid.AllowUserToResizeRows = false;
			this.progressGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.progressGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.progressGrid.Cursor = System.Windows.Forms.Cursors.Default;
			this.progressGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressGrid.Location = new System.Drawing.Point(3, 272);
			this.progressGrid.Name = "progressGrid";
			this.progressGrid.ReadOnly = true;
			this.progressGrid.RowHeadersVisible = false;
			this.progressGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.progressGrid.Size = new System.Drawing.Size(857, 187);
			this.progressGrid.TabIndex = 5;
			this.progressGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.progressGrid_CellMouseDoubleClick);
			// 
			// urlBox
			// 
			this.urlBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.urlBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.urlBox.Location = new System.Drawing.Point(3, 3);
			this.urlBox.Multiline = true;
			this.urlBox.Name = "urlBox";
			this.urlBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.urlBox.Size = new System.Drawing.Size(857, 203);
			this.urlBox.TabIndex = 0;
			this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
			// 
			// batchDownloader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(863, 462);
			this.Controls.Add(this.layout);
			this.MinimumSize = new System.Drawing.Size(879, 500);
			this.Name = "batchDownloader";
			this.Text = "Batch Downloader";
			this.layout.ResumeLayout(false);
			this.layout.PerformLayout();
			this.buttonWrap.ResumeLayout(false);
			this.buttonWrap.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.progressGrid)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.DataGridView progressGrid;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Panel buttonWrap;
        private System.Windows.Forms.TextBox saveDir;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button openFolder;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.TextBox concurrentCount;
        private System.Windows.Forms.Label label1;
    }
}

