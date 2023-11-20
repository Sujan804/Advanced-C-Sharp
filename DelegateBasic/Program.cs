using System;
using System.IO;
namespace DelegateBasic
{
    public class Program
    {
        delegate void LogDel(string message);
        static void Main(string[] args)
        {
            Log log = new Log();
            LogDel LogTextToScreenDel, LogTextToFileDel;
            LogTextToScreenDel = new LogDel(log.LogToScreen);
            LogTextToFileDel = new LogDel(log.LogToFile);
            LogDel multiLog = LogTextToScreenDel + LogTextToFileDel;
            var name = Console.ReadLine();
            multiLog(name);

        }
    }
    public class Log
    {
        public void LogToScreen(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }
        public void LogToFile(string message)
        {
            using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"),true))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
