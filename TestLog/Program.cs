using EdWinLogManager;
using LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLog
{
    class Program
    {
        static void Main(string[] args)
        {
            LogClient.Init(LogType.NOMAIN  | LogType.MAIN | LogType.DEBUG);
            LogClient.WriteERROR("this is error");
            LogClient.WriteNOMAIN("this is no main");
            LogClient.WriteINFO("this is info");
            LogClient.WriteDEBUG("this is debug");
            LogClient.WriteWARN("this is warn");
            LogClient.WriteTRACE("this is trace");
            Console.ReadKey();
        }
    }
}
