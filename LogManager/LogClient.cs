using EdWinLogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

/*
    个人微信：a7761075
    个人邮箱：yinxurong@darsh.cn
    创建时间：2022/7/1 15:25:07
    主要用途：
    更改记录：
                    时间：              内容：
*/
namespace LogManager
{
    public static class LogClient
    {
        //public static Dictionary<string, LogBase> Insernet = new Dictionary<string, LogBase>();
        static List<LogBase> logBases = new List<LogBase>();
        public static void Init(LogType type, LogLevel level=LogLevel.INFO_LOG_LEVEL)
        {
            //if(level.HasFlag(LogLevel.NOMAIN_LOG_LEVEL))
            if (type.HasFlag(LogType.NOMAIN))
            {
                logBases.Add(new Logger());
            }
            if (type.HasFlag(LogType.DEBUG))
            {
                logBases.Add(new DeBugLog(level));
            }
            if (type.HasFlag(LogType.MAIN))
            {
                logBases.Add(new NetLog(level));
            }
            if (type.HasFlag(LogType.CONSOLE))
            {
                logBases.Add(new ConsoleLog(level));
            }
        }

        private static void WriteLog(LogLevel level, string manager,
            string callerName, string callerFile, string callerLine)
        {
            string mes = LogBase.FormatManager(level, manager, callerName, callerFile, callerLine);

            logBases.ForEach(
                        log => log.WriteLog(level, mes)
                        );
        }

        public static void WriteTRACE(string manager,
            [CallerMemberName] string callerName=null,
            [CallerFilePath] string callerFile=null,
            [CallerLineNumber] int callerLine=0)
            => WriteLog(LogLevel.TRACE_LOG_LEVEL, manager, callerName, callerFile, callerLine.ToString());
        public static void WriteNOMAIN(string manager,
          [CallerMemberName] string callerName = null,
          [CallerFilePath] string callerFile = null,
          [CallerLineNumber] int callerLine = 0)
          => WriteLog(LogLevel.NOMAIN_LOG_LEVEL, manager, callerName, callerFile, callerLine.ToString());
        public static void WriteINFO(string manager,
          [CallerMemberName] string callerName = null,
          [CallerFilePath] string callerFile = null,
          [CallerLineNumber] int callerLine = 0)
          => WriteLog(LogLevel.INFO_LOG_LEVEL, manager, callerName, callerFile, callerLine.ToString());
        public static void WriteWARN(string manager,
          [CallerMemberName] string callerName = null,
          [CallerFilePath] string callerFile = null,
          [CallerLineNumber] int callerLine = 0)
          => WriteLog(LogLevel.WARN_LOG_LEVEL, manager, callerName, callerFile, callerLine.ToString());
        public static void WriteERROR(string manager,
          [CallerMemberName] string callerName = null,
          [CallerFilePath] string callerFile = null,
          [CallerLineNumber] int callerLine = 0)
          => WriteLog(LogLevel.ERROR_LOG_LEVEL, manager, callerName, callerFile, callerLine.ToString());
        public static void WriteDEBUG(string manager,
          [CallerMemberName] string callerName = null,
          [CallerFilePath] string callerFile = null,
          [CallerLineNumber] int callerLine = 0)
          => WriteLog(LogLevel.DEBUG_LOG_LEVEL, manager, callerName, callerFile, callerLine.ToString());
    }
}
