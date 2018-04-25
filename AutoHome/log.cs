using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoHome
{
    class log
    {
        public static List<String> LogList = new List<string>();
        public static int counter = 0;

        public static void msg(Object o, String msg)
        {
            String log = counter + " " + DateTime.Now.ToString() + " [" + o.ToString() + "] " + msg;
            File.AppendAllText(var.file_log, log + Environment.NewLine);
            LogList.Add(log);
            counter++;
        }
        public static void exception(Object o, String msg, Exception ex)
        {
            String log = counter + " " + DateTime.Now.ToString() + " +++ EXCEPTION +++ [" + o.ToString() + "] " + msg + " -> " + ex.ToString();
            File.AppendAllText(var.file_log, log + Environment.NewLine);
            LogList.Add(log);
            counter++;
        }
    }
}
