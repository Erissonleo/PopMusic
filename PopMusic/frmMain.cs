using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;//线程

//2015-3-12  何钊
namespace PopMusic
{
    public partial class frmMain : Form
    {
        public string initialFileName = string.Empty;//传入的参数
        public int playState = 1;//播放状态
        public string defaultExeName = "mp3";//默认文件类型

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string fileName)
        {
            InitializeComponent();
            this.initialFileName = fileName;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitialPlayList();
            GetDefaultExeName();
            GetState();
            if (this.initialFileName!=string.Empty)
            {
                addFileName(this.initialFileName);
            }
        }
        /// <summary>
        /// 初始化、从文件读取
        /// </summary>
        public void InitialPlayList()
        {
            if (!File.Exists("config/PlayList.popMusic"))
            {
                return;
            }
            this.tvList.Nodes[0].Nodes.Clear();
            FileStream fs = new FileStream("config/PlayList.popMusic", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string fileName = sr.ReadLine();
            //从文本中读取
            while (fileName != null)
            {
                int index = fileName.LastIndexOf(@"\");
                string exeName = fileName.Substring(index + 1);
                AddTreeNode(fileName, exeName);
                fileName = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            this.tvList.Nodes[0].ExpandAll();
        }
        /// <summary>
        /// 保存播放列表
        /// </summary>
        public void SaveList()
        {
            FileStream fs = new FileStream("config/PlayList.popMusic", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (TreeNode tn in this.tvList.Nodes[0].Nodes)
            {
                sw.WriteLine(tn.Tag.ToString());
            }
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 设置默认文件类型
        /// </summary>
        /// <param name="op"></param>
        public void SaveDefaultExeName()
        {
            FileStream fs = new FileStream("config/DefaultExeName.popMusic", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(this.defaultExeName.ToLower());
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 获得默认文件类型
        /// </summary>
        /// <returns></returns>
        public void GetDefaultExeName()
        {
            if (!File.Exists("config/DefaultExeName.popMusic"))
            {
                return;
            }
            FileStream fs = new FileStream("config/DefaultExeName.popMusic", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            this.defaultExeName = sr.ReadLine().ToLower();
            sr.Close();
            fs.Close();
            if (this.defaultExeName == "mp3")
            {
                this.ofd.Filter = "音频文件|*.mp3|视频文件|*.mp4";
                this.ofd.DefaultExt = "mp3";
            }
            else
            {
                this.ofd.Filter = "视频文件|*.mp4|音频文件|*.mp3";
                this.ofd.DefaultExt = "mp4";
            }
        }
        /// <summary>
        /// 设置播放状态
        /// </summary>
        /// <param name="op"></param>
        public void SaveState()
        {
            FileStream fs = new FileStream("config/State.popMusic", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(this.playState);
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 获得播放状态
        /// </summary>
        /// <returns></returns>
        public void GetState()
        {
            if (!File.Exists("config/State.popMusic"))
            {
                return;
            }
            FileStream fs = new FileStream("config/State.popMusic", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            this.playState = int.Parse(sr.ReadLine());
            sr.Close();
            fs.Close();
        }
        /// <summary>
        /// 打开文件播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = this.ofd.FileName;
            addFileName(fileName);
            int index = fileName.LastIndexOf(@".");
            string exeName = fileName.Substring(index + 1);
            this.defaultExeName = exeName.ToLower();
        }

        public void addFileName(string fileName)
        {
            int index = fileName.LastIndexOf(@"\");
            string exeName = fileName.Substring(index + 1);
            //如果播放列表已经有这个文件,就选中列表里的项
            foreach (TreeNode t in this.tvList.Nodes[0].Nodes)
            {
                string name = t.Text;
                if (name.Contains(exeName))
                {
                    this.tvList.SelectedNode = t;
                    play();
                    return;
                }
            }
            TreeNode tn = AddTreeNode(fileName, exeName);
            this.tvList.Nodes[0].ExpandAll();
            this.tvList.SelectedNode = tn;
            play();
        }

        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="exeName"></param>
        public TreeNode AddTreeNode(string fileName,string exeName) 
        {
            int count = this.tvList.Nodes[0].Nodes.Count+1;
            string showCount = count.ToString();
            if (count < 10) 
            {
                showCount = "0" + count;
            }
            TreeNode tn = new TreeNode(showCount+" "+exeName);
            tn.Tag = fileName;
            tn.ToolTipText = exeName;
            this.tvList.Nodes[0].Nodes.Add(tn);
            return tn;
        }
        private void cms_Opening(object sender, CancelEventArgs e)
        {
			if (this.tvList.Nodes[0].Nodes.Count<1)
			{
				this.下载ToolStripMenuItem.Enabled = false;
                this.删除ToolStripMenuItem.Enabled = false;
				this.清空播放列表ToolStripMenuItem.Enabled = false;
				return;
			}
			else
			{
				this.下载ToolStripMenuItem.Enabled = true;
				this.删除ToolStripMenuItem.Enabled = true;
				this.清空播放列表ToolStripMenuItem.Enabled = true;
			}
			//再次判断
			if (this.tvList.SelectedNode == null || this.tvList.SelectedNode.Level == 0)
            {
                this.下载ToolStripMenuItem.Enabled = false;
                this.删除ToolStripMenuItem.Enabled = false;
            }
            else 
            {
                this.下载ToolStripMenuItem.Enabled = true;
                this.删除ToolStripMenuItem.Enabled = true;
            }
        }
        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fbd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = this.tvList.SelectedNode.Tag.ToString();
            int index = fileName.LastIndexOf(@"\");
            string exeName = fileName.Substring(index + 1);
            string toName = this.fbd.SelectedPath + "\\" + exeName;
            File.Copy(fileName, toName);
            MessageBox.Show("下载" + exeName + "成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = this.tvList.SelectedNode;
            this.tvList.Nodes[0].Nodes[tn.Index].Remove();
            //说明列表里还有
            if (tvList.Nodes[0].Nodes.Count > 0)
            {
                SaveList();
                InitialPlayList();
                //如果当前是最后一项
                if (tvList.SelectedNode.Index == tvList.Nodes[0].Nodes.Count - 1)
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[0];
                }
                //不是最后一项
                else
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index + 1];
                }
                play();
            }
            else
            {
                this.mediaPlay.URL = "";
            }
        }

        private void 清空播放列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mediaPlay.URL = "";
            this.tvList.Nodes[0].Nodes.Clear();
        }
        /// <summary>
        /// 点击一项内容，播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void play()
        {
            TreeNode tn = this.tvList.SelectedNode;
            if (tn.Level == 1)
            {
                //文件不存在
                if (!File.Exists(tn.Tag.ToString()))
                {
                    MessageBox.Show("系统找不到文件，可能已经删除或移动到其他位置!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.mediaPlay.URL != tn.Tag.ToString())
                {
                    this.mediaPlay.URL = tn.Tag.ToString();
                }
            }
        }

       public bool isOne = false;//列表里是否只剩一首歌
        /// <summary>
        /// 自动播放下一项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaPlay_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            isOne = false;
            if (mediaPlay.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                bool isPaly = true;//是否进行下次播放
                //顺序播放
                if (this.playState == 1)
                {
                    //如果当前不是最后一项
                    if (tvList.SelectedNode.Index != tvList.Nodes[0].Nodes.Count - 1)
                    {
                        this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index + 1];
                    }
                    else
                    {
                        isPaly = false;
                    }
                }
                //循环
                else if (this.playState == 2)
                {
                    //如果当前是最后一项
                    if (tvList.SelectedNode.Index == tvList.Nodes[0].Nodes.Count - 1)
                    {
                         this.tvList.SelectedNode = tvList.Nodes[0].Nodes[0];
                         int maxIndex = tvList.Nodes[0].Nodes.Count;
                         if (maxIndex <= 1)
                         {
                             isOne = true;
                         }
                    }
                    //不是最后一项
                    else
                    {
                        this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index + 1];
                    }
                }
                //随机
                else if (this.playState == 3)
                {
                    int maxIndex = tvList.Nodes[0].Nodes.Count;
                    if (maxIndex<=1)
                    {
                         this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index];
                         isOne = true;
                    }
                    else
                    {
                        Random rd = new Random();
                        int index = rd.Next(0, maxIndex);
                        //随机数不能与当前index相等
                        while (index == tvList.SelectedNode.Index)
                        {
                            index = rd.Next(0, maxIndex);
                        }
                        this.tvList.SelectedNode = tvList.Nodes[0].Nodes[index];
                    }
                }
                //单曲
                else if (this.playState == 4)
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index];
                }
                if (isPaly)
                {
                    play();
                    //多线程
                    Thread thread = new Thread(new ThreadStart(PlayThread));
                    thread.Start();
                }
            }
        }
        private void PlayThread()
        {
            if (this.playState == 4 || this.isOne == false)
            {
                mediaPlay.Ctlcontrols.play();
            }
            else
            {
                //这里是判断播放器准备好没有
                if (mediaPlay.playState == WMPLib.WMPPlayState.wmppsReady)
                {
                    mediaPlay.Ctlcontrols.play();//处于准备好状态就开始播放
                }
            }
        }
        /// <summary>
        /// 下一曲
        /// </summary>
        /// <returns></returns>
        public bool playNext()
        {
            if (this.tvList.Nodes[0].Nodes.Count<=1)
            {
                return false;
            }
            if (this.tvList.SelectedNode==null||this.tvList.SelectedNode==this.tvList.Nodes[0])
            {
                this.tvList.SelectedNode = tvList.Nodes[0].Nodes[0];
            }
            bool isPaly = true;//是否进行下次播放
            //顺序播放
            if (this.playState == 1)
            {
                //如果当前不是最后一项
                if (tvList.SelectedNode.Index != tvList.Nodes[0].Nodes.Count - 1)
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index + 1];
                }
                else
                {
                    isPaly = false;
                }
            }
            //循环 ||单曲
            else if (this.playState == 2 || this.playState == 4)
            {
                //如果当前是最后一项
                if (tvList.SelectedNode.Index == tvList.Nodes[0].Nodes.Count - 1)
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[0];
                }
                //不是最后一项
                else
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index + 1];
                }
            }
            //随机
            else if (this.playState == 3)
            {
                int maxIndex = tvList.Nodes[0].Nodes.Count;
                Random rd = new Random();
                int index = rd.Next(0, maxIndex);
                //随机数不能与当前index相等
                while (index == tvList.SelectedNode.Index)
                {
                    index = rd.Next(0, maxIndex);
                }
                this.tvList.SelectedNode = tvList.Nodes[0].Nodes[index];
            }
            return isPaly;
        }
        /// <summary>
        /// 上一曲
        /// </summary>
        /// <returns></returns>
        public bool playPrev()
        {
            if (this.tvList.Nodes[0].Nodes.Count <=1)
            {
                return false;
            }
            if (this.tvList.SelectedNode == null || this.tvList.SelectedNode == this.tvList.Nodes[0])
            {
                this.tvList.SelectedNode = tvList.Nodes[0].Nodes[0];
            }
            bool isPaly = true;//是否进行下次播放
            //顺序播放
            if (this.playState == 1)
            {
                //如果当前不是第一项
                if (tvList.SelectedNode.Index != 0)
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index - 1];
                }
                else
                {
                    isPaly = false;
                }
            }
            //循环||单曲
            else if (this.playState == 2 || this.playState == 4)
            {
                //如果当前是第一项
                if (tvList.SelectedNode.Index == 0)
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.Nodes[0].Nodes.Count - 1];
                }
                //不是第一项
                else
                {
                    this.tvList.SelectedNode = tvList.Nodes[0].Nodes[tvList.SelectedNode.Index - 1];
                }
            }
            //随机
            else if (this.playState == 3)
            {
                int maxIndex = tvList.Nodes[0].Nodes.Count;
                Random rd = new Random();
                int index = rd.Next(0, maxIndex);
                //随机数不能与当前index相等
                while (index == tvList.SelectedNode.Index)
                {
                    index = rd.Next(0, maxIndex);
                }
                this.tvList.SelectedNode = tvList.Nodes[0].Nodes[index];
            }
            return isPaly;
        }
        private void 顺序播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playState = 1;
        }

        private void 列表循环ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playState = 2;
        }

        private void 随机播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playState = 3;
        }

        private void 单曲循环ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playState = 4;
        }

        private void tvList_DoubleClick(object sender, EventArgs e)
        {
            play();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (playPrev())
            {
                play();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (playNext())
            {
                play();
            }
        }
        /// <summary>
        /// 窗体关闭时，将列表里的文件地址存入到文件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveList();
            SaveDefaultExeName();
            SaveState();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
