using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace THOK.WES.Dal
{
   public class FileUtil
    {
       public void logInfo(string logName, string logString)
       {
           Directory.CreateDirectory(Environment.CurrentDirectory + "\\日志");//在目录创建日志文件
           FileStream fs = new FileStream(Environment.CurrentDirectory + "\\日志\\" + logName + ".txt", FileMode.Append, FileAccess.Write);
           StreamWriter sw = new StreamWriter(fs);//开始写入
           sw.Write(logString + "\r\n");//写入
           sw.Flush();
           sw.Close();
           fs.Close();
       }
    }
}
