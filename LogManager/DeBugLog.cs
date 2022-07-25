using EdWinLogManager;
using LogManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    个人微信：a7761075
    个人邮箱：yinxurong@darsh.cn
    创建时间：2022/7/1 16:57:56
    主要用途：调试记录
    更改记录：
                    时间：              内容：
*/
namespace EdWinLogManager
{
    internal class DeBugLog : LogBase
    {
        public DeBugLog(LogLevel level) : base(level) { }

        public override void Init(int retainTime=7)
        {
            throw new NotImplementedException();
            
        }

        public override void WriteLog(LogLevel level, string manager)
        {
            Debug.WriteLine(manager);
        }
    }
}
