using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logManager
{
    public class LogManager
    {
        private static LogManager _instance;
        public static LogManager Intance
        {
            get
            {
                return LogManager._instance;
            }
        }
        public List<string> Logs
        {
            get
            {
                return _strings;
            }
        }

        public delegate void logAddedEventRaiser(List<string> logs);
        public event logAddedEventRaiser OnLogAdded;
        private List<string> _strings;

        static LogManager()
        {
            LogManager._instance = new LogManager();
        }

        public LogManager()
        {
            this._strings = new List<string>();
        }

        public void Log(string text)
        {
            _strings.Add(text);
            OnLogAdded(_strings);
        }

        public void SaveLogsAs(string dir)
        {
            if (!File.Exists(dir))
                File.Create(dir).Close();

            using (StreamWriter file = new StreamWriter(dir, false))
                file.Write(dir);
        }
    }
}
