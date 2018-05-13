namespace Sure.Crawler
{
    partial class SmallKunshan
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
            this.components = new System.ComponentModel.Container();
            this.labAddress = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.butGrab = new System.Windows.Forms.Button();
            this.labName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.butQuery = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看点评ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Location = new System.Drawing.Point(12, 19);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(41, 12);
            this.labAddress.TabIndex = 0;
            this.labAddress.Text = "地址：";
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(59, 15);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(287, 21);
            this.textAddress.TabIndex = 1;
            this.textAddress.Text = "http://www.shxksjx.com/dianping.asp";
            // 
            // butGrab
            // 
            this.butGrab.Location = new System.Drawing.Point(352, 13);
            this.butGrab.Name = "butGrab";
            this.butGrab.Size = new System.Drawing.Size(75, 23);
            this.butGrab.TabIndex = 2;
            this.butGrab.Text = "抓取";
            this.butGrab.UseVisualStyleBackColor = true;
            this.butGrab.Click += new System.EventHandler(this.butGrab_Click);
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(12, 59);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(41, 12);
            this.labName.TabIndex = 3;
            this.labName.Text = "名称：";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(61, 54);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(109, 21);
            this.textName.TabIndex = 4;
            // 
            // butQuery
            // 
            this.butQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butQuery.Location = new System.Drawing.Point(178, 54);
            this.butQuery.Name = "butQuery";
            this.butQuery.Size = new System.Drawing.Size(73, 23);
            this.butQuery.TabIndex = 5;
            this.butQuery.Text = "筛选";
            this.butQuery.UseVisualStyleBackColor = true;
            this.butQuery.Click += new System.EventHandler(this.butQuery_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(120, 120);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView
            // 
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(14, 100);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(838, 291);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看点评ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // 查看点评ToolStripMenuItem
            // 
            this.查看点评ToolStripMenuItem.Name = "查看点评ToolStripMenuItem";
            this.查看点评ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查看点评ToolStripMenuItem.Text = "查看点评";
            this.查看点评ToolStripMenuItem.Click += new System.EventHandler(this.查看点评ToolStripMenuItem_Click);
            // 
            // SmallKunshan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 448);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.butQuery);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.butGrab);
            this.Controls.Add(this.textAddress);
            this.Controls.Add(this.labAddress);
            this.Name = "SmallKunshan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmallKunshan";
            this.Load += new System.EventHandler(this.SmallKunshan_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Button butGrab;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button butQuery;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 查看点评ToolStripMenuItem;
    }
}