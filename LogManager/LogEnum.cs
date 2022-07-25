using System;

/*
    个人微信：a7761075
    个人邮箱：yinxurong@darsh.cn
    创建时间：2022/7/1 16:52:25
    主要用途：log 枚举集合
    更改记录：
                    时间：              内容：
*/
namespace LogManager
{
    public enum LogLevel
    {
        NOMAIN_LOG_LEVEL = 1,//数据量大且不重要
        INFO_LOG_LEVEL = 2,//信息
        ERROR_LOG_LEVEL= 4,//普通错误
        WARN_LOG_LEVEL= 8,//警告
        TRACE_LOG_LEVEL= 16,//跟踪
        DEBUG_LOG_LEVEL= 32,//调试
        CONSOLE_LOG_LEVEL=32,//调试
    }
    [Flags]
    public enum LogType
    {
        NOMAIN = 1,//数据量大且不重要
        MAIN= 2,//信息
        DEBUG= 4,//调试
        CONSOLE=8,//调试
    }
}
