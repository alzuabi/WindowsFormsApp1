using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1.Service
{
    class Classification
    {
        private Classification() { }

        private static Classification _instance;

        private static readonly object _lock = new object();

        public static Classification GetInstance()
        {
            if (_instance == null)
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Classification();
                    }
                }
            }
            return _instance;
        }
        public void pullAndClassification(string s, string d) {
            var log = Log.GetInstance();
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(s);
                string dir = Path.Combine(fileName.Split('-'));
                string dest = Path.Combine(d, dir);
                Directory.CreateDirectory(dest);
                dest = Path.Combine(dest, Path.GetFileName(s));

                if (File.Exists(dest))
                {
                    File.Delete(s);
                }
                else
                {
                    File.Move(s, dest);
                    log.LogToFile("TEST "+DateTime.Now);
                    log.LogToDataBase();
                }
            }
            catch (Exception ex)
            {
                log.LogToFile(ex.Message);
            }
        }
    }
}
