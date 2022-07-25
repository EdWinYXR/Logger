using EdWinLogManager;
using LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    个人微信：a7761075
    个人邮箱：yinxurong@darsh.cn
    创建时间：2022/7/25 14:56:31
    主要用途：
    更改记录：
                    时间：              内容：
*/
namespace EdWinLogManager
{
    internal class ConsoleLog : LogBase
    {
        public ConsoleLog(LogLevel level) : base(level) { }
        public override void Init(int retainTime)
        {
            throw new NotImplementedException();
        }

        public override void WriteLog(LogLevel level, string manager)
        {
            Console.WriteLine(manager);
        }
    }
}
