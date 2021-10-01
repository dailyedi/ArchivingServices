using System;
using System.IO;

namespace SimpleLogger
{
    public static class Logger
    {
        static readonly string LoggingPath;

        static readonly string FileName;

        static Logger()
        {
            LoggingPath = @"Logs\";
            FileName = DateTime.Now.Date.ToString("dd_MM_yyyy") + ".txt";

            var fileInfo = Directory.CreateDirectory(LoggingPath);
        }

        public static void Info(string message)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(LoggingPath + FileName))
                {
                    streamWriter.WriteLine("Info at: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss:fff") + " " + message);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Error(string message)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(LoggingPath + FileName))
                {
                    streamWriter.WriteLine("Error at: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss:fff") + " " + message);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
