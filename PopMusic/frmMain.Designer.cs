namespace PopMusic
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("播放列表");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msp = new System.Windows.Forms.MenuStrip();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.播放设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顺序播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列表循环ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.随机播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单曲循环ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空播放列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.tvList = new System.Windows.Forms.TreeView();
            this.mediaPlay = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.msp.SuspendLayout();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // msp
            // 
            this.msp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.播放设置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.msp.Location = new System.Drawing.Point(0, 0);
            this.msp.Name = "msp";
            this.msp.Size = new System.Drawing.Size(1005, 25);
            this.msp.TabIndex = 3;
            this.msp.Text = "menuStrip1";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 播放设置ToolStripMenuItem
            // 
            this.播放设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顺序播放ToolStripMenuItem,
            this.列表循环ToolStripMenuItem,
            this.随机播放ToolStripMenuItem,
            this.单曲循环ToolStripMenuItem});
            this.播放设置ToolStripMenuItem.Name = "播放设置ToolStripMenuItem";
            this.播放设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.播放设置ToolStripMenuItem.Text = "播放设置";
            // 
            // 顺序播放ToolStripMenuItem
            // 
            this.顺序播放ToolStripMenuItem.Name = "顺序播放ToolStripMenuItem";
            this.顺序播放ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.顺序播放ToolStripMenuItem.Text = "顺序播放";
            this.顺序播放ToolStripMenuItem.Click += new System.EventHandler(this.顺序播放ToolStripMenuItem_Click);
            // 
            // 列表循环ToolStripMenuItem
            // 
            this.列表循环ToolStripMenuItem.Name = "列表循环ToolStripMenuItem";
            this.列表循环ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.列表循环ToolStripMenuItem.Text = "列表循环";
            this.列表循环ToolStripMenuItem.Click += new System.EventHandler(this.列表循环ToolStripMenuItem_Click);
            // 
            // 随机播放ToolStripMenuItem
            // 
            this.随机播放ToolStripMenuItem.Name = "随机播放ToolStripMenuItem";
            this.随机播放ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.随机播放ToolStripMenuItem.Text = "随机播放";
            this.随机播放ToolStripMenuItem.Click += new System.EventHandler(this.随机播放ToolStripMenuItem_Click);
            // 
            // 单曲循环ToolStripMenuItem
            // 
            this.单曲循环ToolStripMenuItem.Name = "单曲循环ToolStripMenuItem";
            this.单曲循环ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.单曲循环ToolStripMenuItem.Text = "单曲循环";
            this.单曲循环ToolStripMenuItem.Click += new System.EventHandler(this.单曲循环ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "mp4";
            this.ofd.Filter = "视频文件|*.mp4|音频文件|*.mp3";
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.清空播放列表ToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(149, 70);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Opening);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            this.下载ToolStripMenuItem.Click += new System.EventHandler(this.下载ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 清空播放列表ToolStripMenuItem
            // 
            this.清空播放列表ToolStripMenuItem.Name = "清空播放列表ToolStripMenuItem";
            this.清空播放列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清空播放列表ToolStripMenuItem.Text = "清空播放列表";
            this.清空播放列表ToolStripMenuItem.Click += new System.EventHandler(this.清空播放列表ToolStripMenuItem_Click);
            // 
            // tvList
            // 
            this.tvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvList.BackColor = System.Drawing.Color.Lavender;
            this.tvList.ContextMenuStrip = this.cms;
            this.tvList.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tvList.Location = new System.Drawing.Point(0, 58);
            this.tvList.Name = "tvList";
            treeNode1.Name = "节点0";
            treeNode1.Text = "播放列表";
            this.tvList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvList.ShowNodeToolTips = true;
            this.tvList.Size = new System.Drawing.Size(196, 545);
            this.tvList.TabIndex = 13;
            this.tvList.DoubleClick += new System.EventHandler(this.tvList_DoubleClick);
            // 
            // mediaPlay
            // 
            this.mediaPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaPlay.Enabled = true;
            this.mediaPlay.Location = new System.Drawing.Point(204, 28);
            this.mediaPlay.Name = "mediaPlay";
            this.mediaPlay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlay.OcxState")));
            this.mediaPlay.Size = new System.Drawing.Size(800, 575);
            this.mediaPlay.TabIndex = 12;
            this.mediaPlay.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.mediaPlay_PlayStateChange);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Lavender;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrev.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnPrev.Location = new System.Drawing.Point(9, 28);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(92, 24);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.Text = "上一个";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Lavender;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnNext.Location = new System.Drawing.Point(108, 29);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "下一个";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 602);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.mediaPlay);
            this.Controls.Add(this.tvList);
            this.Controls.Add(this.msp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msp;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多媒体播放器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msp.ResumeLayout(false);
            this.msp.PerformLayout();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msp;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空播放列表ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlay;
        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.ToolStripMenuItem 播放设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 顺序播放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列表循环ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 随机播放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单曲循环ToolStripMenuItem;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}

