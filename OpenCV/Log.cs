using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;

namespace ReadLighterStatus
{
    class Log
    {
        //       static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
        public static void logOut(string str)
        {
            Console.WriteLine(str);
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath;
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            int year = currentTime.Year;
            int month = currentTime.Month;
            int day = currentTime.Day;
            int hour = currentTime.Hour;
            int minute = currentTime.Minute;
            int second = currentTime.Second;
            int millisecond = currentTime.Millisecond;
            string conStr;
            logFilePath = currentPath + "Log\\";
            string headStr = hour + ":" + minute + ":" + second + ":" + millisecond + "   ";
            conStr = headStr + str + "\r\n";
            string txtName = logFilePath + year + "-" + month + "-" + day + ".txt";
            if (!File.Exists(txtName))
            {
                string fileNameExt = logFilePath.Substring(logFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string folderPath = logFilePath.Substring(0, logFilePath.Length - fileNameExt.Length);
                if (!Directory.Exists(logFilePath))
                    Directory.CreateDirectory(logFilePath);
                if (!File.Exists(txtName))
                    File.Create(txtName).Close();
            }
            FileStream fs = new FileStream(txtName, FileMode.Append);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(conStr);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}
