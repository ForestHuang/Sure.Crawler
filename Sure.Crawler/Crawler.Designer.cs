namespace Sure.Crawler
{
    partial class Crawler
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lab_Url = new System.Windows.Forms.Label();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.But_Crawler = new System.Windows.Forms.Button();
            this.but_Down = new System.Windows.Forms.Button();
            this.list_url = new System.Windows.Forms.ListBox();
            this.contextMenuCrawler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.爬取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二级爬取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_sonurl = new System.Windows.Forms.Label();
            this.list_sonurl = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_thread = new System.Windows.Forms.Label();
            this.txt_thread = new System.Windows.Forms.TextBox();
            this.lab_data = new System.Windows.Forms.Label();
            this.timerList = new System.Windows.Forms.Timer(this.components);
            this.LabDownPath = new System.Windows.Forms.Label();
            this.txtDownPath = new System.Windows.Forms.TextBox();
            this.butDownPath = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.序号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.文件名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.总大小 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.已完成 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.进度 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.速度 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.剩余 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.下载地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butOpenPath = new System.Windows.Forms.Button();
            this.contextMenuCrawler.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_Url
            // 
            this.lab_Url.AutoSize = true;
            this.lab_Url.Location = new System.Drawing.Point(14, 14);
            this.lab_Url.Name = "lab_Url";
            this.lab_Url.Size = new System.Drawing.Size(41, 12);
            this.lab_Url.TabIndex = 0;
            this.lab_Url.Text = "地址：";
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(59, 10);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(345, 21);
            this.txt_Url.TabIndex = 1;
            this.txt_Url.Text = "http://www.46ek.com";
            // 
            // But_Crawler
            // 
            this.But_Crawler.Location = new System.Drawing.Point(438, 10);
            this.But_Crawler.Name = "But_Crawler";
            this.But_Crawler.Size = new System.Drawing.Size(75, 23);
            this.But_Crawler.TabIndex = 2;
            this.But_Crawler.Text = "Crawler";
            this.But_Crawler.UseVisualStyleBackColor = true;
            this.But_Crawler.Click += new System.EventHandler(this.But_Crawler_Click);
            // 
            // but_Down
            // 
            this.but_Down.Location = new System.Drawing.Point(525, 10);
            this.but_Down.Name = "but_Down";
            this.but_Down.Size = new System.Drawing.Size(75, 23);
            this.but_Down.TabIndex = 3;
            this.but_Down.Text = "Down";
            this.but_Down.UseVisualStyleBackColor = true;
            this.but_Down.Click += new System.EventHandler(this.but_Down_Click);
            // 
            // list_url
            // 
            this.list_url.ContextMenuStrip = this.contextMenuCrawler;
            this.list_url.Cursor = System.Windows.Forms.Cursors.Hand;
            this.list_url.Enabled = false;
            this.list_url.FormattingEnabled = true;
            this.list_url.ItemHeight = 12;
            this.list_url.Location = new System.Drawing.Point(61, 100);
            this.list_url.Name = "list_url";
            this.list_url.Size = new System.Drawing.Size(250, 88);
            this.list_url.TabIndex = 4;
            this.list_url.SelectedIndexChanged += new System.EventHandler(this.list_url_SelectedIndexChanged);
            // 
            // contextMenuCrawler
            // 
            this.contextMenuCrawler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.爬取ToolStripMenuItem,
            this.二级爬取ToolStripMenuItem});
            this.contextMenuCrawler.Name = "contextMenuCrawler";
            this.contextMenuCrawler.Size = new System.Drawing.Size(125, 48);
            // 
            // 爬取ToolStripMenuItem
            // 
            this.爬取ToolStripMenuItem.Name = "爬取ToolStripMenuItem";
            this.爬取ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.爬取ToolStripMenuItem.Text = "爬取";
            this.爬取ToolStripMenuItem.Click += new System.EventHandler(this.爬取ToolStripMenuItem_Click);
            // 
            // 二级爬取ToolStripMenuItem
            // 
            this.二级爬取ToolStripMenuItem.Name = "二级爬取ToolStripMenuItem";
            this.二级爬取ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.二级爬取ToolStripMenuItem.Text = "二级爬取";
            this.二级爬取ToolStripMenuItem.Click += new System.EventHandler(this.二级爬取ToolStripMenuItem_Click);
            // 
            // lab_sonurl
            // 
            this.lab_sonurl.AutoSize = true;
            this.lab_sonurl.Location = new System.Drawing.Point(2, 102);
            this.lab_sonurl.Name = "lab_sonurl";
            this.lab_sonurl.Size = new System.Drawing.Size(53, 12);
            this.lab_sonurl.TabIndex = 5;
            this.lab_sonurl.Text = "子地址：";
            // 
            // list_sonurl
            // 
            this.list_sonurl.BackColor = System.Drawing.SystemColors.Window;
            this.list_sonurl.ContextMenuStrip = this.contextMenuCrawler;
            this.list_sonurl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.list_sonurl.Enabled = false;
            this.list_sonurl.FormattingEnabled = true;
            this.list_sonurl.ItemHeight = 12;
            this.list_sonurl.Location = new System.Drawing.Point(350, 102);
            this.list_sonurl.Name = "list_sonurl";
            this.list_sonurl.Size = new System.Drawing.Size(250, 88);
            this.list_sonurl.TabIndex = 6;
            this.list_sonurl.SelectedIndexChanged += new System.EventHandler(this.list_sonurl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = ">>";
            // 
            // lab_thread
            // 
            this.lab_thread.AutoSize = true;
            this.lab_thread.Location = new System.Drawing.Point(2, 72);
            this.lab_thread.Name = "lab_thread";
            this.lab_thread.Size = new System.Drawing.Size(53, 12);
            this.lab_thread.TabIndex = 8;
            this.lab_thread.Text = "线程数：";
            // 
            // txt_thread
            // 
            this.txt_thread.Location = new System.Drawing.Point(61, 66);
            this.txt_thread.Name = "txt_thread";
            this.txt_thread.Size = new System.Drawing.Size(55, 21);
            this.txt_thread.TabIndex = 9;
            this.txt_thread.Text = "5";
            // 
            // lab_data
            // 
            this.lab_data.AutoSize = true;
            this.lab_data.Location = new System.Drawing.Point(14, 202);
            this.lab_data.Name = "lab_data";
            this.lab_data.Size = new System.Drawing.Size(41, 12);
            this.lab_data.TabIndex = 10;
            this.lab_data.Text = "信息：";
            // 
            // timerList
            // 
            this.timerList.Interval = 3000;
            this.timerList.Tick += new System.EventHandler(this.timerList_Tick);
            // 
            // LabDownPath
            // 
            this.LabDownPath.AutoSize = true;
            this.LabDownPath.Location = new System.Drawing.Point(2, 42);
            this.LabDownPath.Name = "LabDownPath";
            this.LabDownPath.Size = new System.Drawing.Size(53, 12);
            this.LabDownPath.TabIndex = 12;
            this.LabDownPath.Text = "  路径：";
            // 
            // txtDownPath
            // 
            this.txtDownPath.Location = new System.Drawing.Point(61, 37);
            this.txtDownPath.Name = "txtDownPath";
            this.txtDownPath.Size = new System.Drawing.Size(343, 21);
            this.txtDownPath.TabIndex = 13;
            // 
            // butDownPath
            // 
            this.butDownPath.Location = new System.Drawing.Point(438, 37);
            this.butDownPath.Name = "butDownPath";
            this.butDownPath.Size = new System.Drawing.Size(75, 23);
            this.butDownPath.TabIndex = 14;
            this.butDownPath.Text = "选择路径";
            this.butDownPath.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.序号,
            this.文件名,
            this.总大小,
            this.已完成,
            this.进度,
            this.速度,
            this.剩余,
            this.时间,
            this.状态,
            this.下载地址});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(61, 202);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(539, 150);
            this.listView.TabIndex = 15;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // 序号
            // 
            this.序号.Text = "序号";
            this.序号.Width = 37;
            // 
            // 文件名
            // 
            this.文件名.Text = "文件名";
            this.文件名.Width = 118;
            // 
            // 总大小
            // 
            this.总大小.Text = "总大小";
            // 
            // 已完成
            // 
            this.已完成.Text = "已完成";
            // 
            // 进度
            // 
            this.进度.Text = "进度";
            // 
            // 速度
            // 
            this.速度.Text = "速度";
            // 
            // 剩余
            // 
            this.剩余.Text = "剩余";
            // 
            // 时间
            // 
            this.时间.Text = "时间";
            // 
            // 状态
            // 
            this.状态.Text = "状态";
            // 
            // 下载地址
            // 
            this.下载地址.Text = "下载地址";
            // 
            // butOpenPath
            // 
            this.butOpenPath.Location = new System.Drawing.Point(525, 39);
            this.butOpenPath.Name = "butOpenPath";
            this.butOpenPath.Size = new System.Drawing.Size(75, 23);
            this.butOpenPath.TabIndex = 16;
            this.butOpenPath.Text = "打开文件夹";
            this.butOpenPath.UseVisualStyleBackColor = true;
            this.butOpenPath.Click += new System.EventHandler(this.butOpenPath_Click);
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 365);
            this.Controls.Add(this.butOpenPath);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.butDownPath);
            this.Controls.Add(this.txtDownPath);
            this.Controls.Add(this.LabDownPath);
            this.Controls.Add(this.lab_data);
            this.Controls.Add(this.txt_thread);
            this.Controls.Add(this.lab_thread);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_sonurl);
            this.Controls.Add(this.lab_sonurl);
            this.Controls.Add(this.list_url);
            this.Controls.Add(this.but_Down);
            this.Controls.Add(this.But_Crawler);
            this.Controls.Add(this.txt_Url);
            this.Controls.Add(this.lab_Url);
            this.Name = "Crawler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crawler";
            this.Load += new System.EventHandler(this.Crawler_Load);
            this.contextMenuCrawler.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Url;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.Button But_Crawler;
        private System.Windows.Forms.Button but_Down;
        private System.Windows.Forms.ListBox list_url;
        private System.Windows.Forms.ContextMenuStrip contextMenuCrawler;
        private System.Windows.Forms.ToolStripMenuItem 爬取ToolStripMenuItem;
        private System.Windows.Forms.Label lab_sonurl;
        private System.Windows.Forms.ListBox list_sonurl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 二级爬取ToolStripMenuItem;
        private System.Windows.Forms.Label lab_thread;
        private System.Windows.Forms.TextBox txt_thread;
        private System.Windows.Forms.Label lab_data;
        private System.Windows.Forms.Timer timerList;
        private System.Windows.Forms.Label LabDownPath;
        private System.Windows.Forms.TextBox txtDownPath;
        private System.Windows.Forms.Button butDownPath;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader 序号;
        private System.Windows.Forms.ColumnHeader 文件名;
        private System.Windows.Forms.ColumnHeader 总大小;
        private System.Windows.Forms.ColumnHeader 已完成;
        private System.Windows.Forms.ColumnHeader 进度;
        private System.Windows.Forms.ColumnHeader 速度;
        private System.Windows.Forms.ColumnHeader 剩余;
        private System.Windows.Forms.ColumnHeader 时间;
        private System.Windows.Forms.ColumnHeader 状态;
        private System.Windows.Forms.ColumnHeader 下载地址;
        private System.Windows.Forms.Button butOpenPath;
    }
}

