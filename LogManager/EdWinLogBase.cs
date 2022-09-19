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
    创建时间：2022/7/1 13:47:14
    主要用途：log基类
    更改记录：
                    时间：              内容：
*/
namespace EdWinLogManager
{

    public  abstract class LogBase
    {
        public LogLevel B_level { get; protected set; }
        protected object m_syncObject = new object();
        protected string m_filename;
        protected string m_Directory;
        protected TimeSpan m_RetainTime;
        protected int m_Index = 1;
        protected string m_BaseName;
        protected int maxFileCount = 1000;

        public LogBase(LogLevel level)
        {
            B_level = level;
        }
        public abstract void Init(int retainTime);

        /// <summary>
        /// 格式化log write
        /// </summary>
        /// <param name="level">级别</param>
        /// <param name="manager">信息</param>
        /// <param name="callerName">文件名</param>
        /// <param name="callerFile">方法</param>
        /// <param name="callerLine">行</param>
        /// <returns></returns>
        public static string FormatManager(LogLevel level, string manager,
            string callerName,string callerFile,string callerLine )
        {
            StringBuilder mes = new StringBuilder();

            mes.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") +"  ");
            switch (level) {
                case LogLevel.INFO_LOG_LEVEL:
                    mes.Append("<INFO>--");
                    break;
                case LogLevel.ERROR_LOG_LEVEL:
                    mes.Append("<ERROR>--");
                    break;
                case LogLevel.WARN_LOG_LEVEL:
                    mes.Append("<WARN>--");
                    break;
                case LogLevel.TRACE_LOG_LEVEL:
                    mes.Append("[TRACE]->");
                    mes.Append($"{Path.GetFileName(callerFile)} > {callerName} > in line [{callerLine}] --");
                    break;
                case LogLevel.DEBUG_LOG_LEVEL:
                    mes.Append("[DEBUG]->");
                    mes.Append($"{Path.GetFileName(callerFile)} > {callerName} > in line [{callerLine}] --");
                    break;
                default:
                    break;
            }
            mes.Append(manager);
            return mes.ToString();
        }

        public  abstract void WriteLog(LogLevel level, string manager);

        //检测大小
        protected void CheckFileSize(int MaxFile)
        {
            if (!File.Exists(m_filename))
                return;
            FileInfo fileInfo = new FileInfo(m_filename);
            fileInfo.Refresh();
            if (fileInfo.Length >= MaxFile)
            {
                m_Index++;
                if (m_Index == maxFileCount + 1)
                    m_Index = 1;
                m_filename = string.Format("{0}\\{1}{2}.txt", m_Directory, m_BaseName, m_Index);
                File.Delete(m_filename);
            }
        }
        //检查时间
        protected void DeleteHistoryFile()
        {
            string[] txtFiles = Directory.GetFiles(m_Directory);
            DateTime deleteTime = DateTime.Now - m_RetainTime;
            foreach (string it in txtFiles)
            {
                if (File.GetLastWriteTime(it) <= deleteTime)
                {
                    File.Delete(it);
                }
            }
        }
    }
}
