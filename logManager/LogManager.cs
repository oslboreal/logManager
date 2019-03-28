using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logManager
{
    public class LogManager
    {
        public ConcurrentBag<string> Logs
        {
            get
            {
                return _strings;
            }
        }

        public delegate void logAddedEventRaiser(ConcurrentBag<string> logs);
        public event logAddedEventRaiser OnLogAdded;
        private ConcurrentBag<string> _strings;

        public LogManager()
        {
            this._strings = new ConcurrentBag<string>();
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
