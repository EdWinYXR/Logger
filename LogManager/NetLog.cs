using EdWinLogManager;
using LogManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    个人微信：a7761075
    个人邮箱：yinxurong@darsh.cn
    创建时间：2022/7/1 16:43:37
    主要用途：
    更改记录：
                    时间：              内容：
*/
namespace EdWinLogManager
{
    internal class NetLog: LogBase
    {
        public NetLog(LogLevel level) : base(level) { Init(); }

        public override void Init(int retainTime = 15)
        {
            m_Directory = Environment.CurrentDirectory + "\\log\\Net";
            if (!Directory.Exists(m_Directory))
            {
                Directory.CreateDirectory(m_Directory);
            }

            m_RetainTime = new TimeSpan(retainTime, 0, 0, 0);
            m_BaseName = DateTime.Now.ToString("yyyy_MM_dd_");
            for (int i = 1; i < maxFileCount + 1; i++)
            {
                string fileName = string.Format("{0}\\{1}{2}.txt", m_Directory, m_BaseName, i);
                if (File.Exists(fileName))
                {
                    m_filename = fileName;
                    m_Index = i;
                }
                else
                {
                    break;
                }
            }
            if (m_Index == maxFileCount)
            {
                m_Index = 1;
                m_filename = string.Format("{0}\\{1}{2}.txt", m_Directory, m_BaseName, m_Index);
                File.Delete(m_filename);
            }

            DeleteHistoryFile();

        }

        public override void WriteLog(LogLevel level, string manager)
        {
            if ((int)level ==(int)LogLevel.NOMAIN_LOG_LEVEL)
            {
                return;
            }
            try
            {
                lock (m_syncObject)
                {
                    string baseName = DateTime.Now.ToString("yyyy_MM_dd_");
                    if (!m_BaseName.Equals(baseName))
                    {
                        m_BaseName = baseName;
                        m_Index = 1;
                    }
                    m_filename = string.Format("{0}\\{1}{2}.txt", m_Directory, m_BaseName, m_Index);
                    DeleteHistoryFile();
                    using (StreamWriter writer = File.AppendText(m_filename))
                    {
                        //string strLog = string.Format("{0} -- {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), manager);
                        writer.WriteLine(manager);
                    }
                    CheckFileSize(200000);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
