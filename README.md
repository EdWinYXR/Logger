## LogClient.Init(LogType.NOMAIN  | LogType.MAIN | LogType.DEBUG);

#### //在程序启动时注册 log并开启权限，后边直接调用
LogClient.WriteERROR("this is error");

LogClient.WriteNOMAIN("this is no main");

LogClient.WriteINFO("this is info");

LogClient.WriteDEBUG("this is debug");

LogClient.WriteWARN("this is warn");

LogClient.WriteTRACE("this is trace");