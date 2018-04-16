using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopMusic
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //程序启动时，判断有没有参数传入
            if (args.Length == 1)
            {
                string fileName = args[0];
                int index = fileName.LastIndexOf(".");
                string exeName = fileName.Substring(index + 1);
                //是否是MP3、MP4文件
                if (exeName.ToLower() == "mp3" || exeName.ToLower() == "mp4")
                {
                    Application.Run(new frmMain(fileName));
                }
                else
                {
                    MessageBox.Show("本播放器只支持MP3、MP4格式的文件！","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            else 
            {
                Application.Run(new frmMain());
            }
           
        }
    }
}
