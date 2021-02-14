using Classification.Utils;
using MULTISYSDbContext.Models;
using PullAndClassification.Utils;
using SharpSvn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Classification.Service
{
    public class Classification
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
        public void CopyAndClassification(SvnClient client, string s, string d,string dir, bool fromSvn)
        {
            var log = Log.GetInstance();
            try
            {
                if (fromSvn)
                {
                    MemoryStream stream = new MemoryStream();
                    client.Write(SvnTarget.FromUri(new Uri(s)), stream);
                    string dest = Path.Combine(dir, d);
                    Directory.CreateDirectory(dest);
                    dest = Path.Combine(dest, Path.GetFileName(s));
                    using (FileStream outputFileStream = new FileStream(Path.Combine(dest), FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        stream.WriteTo(outputFileStream);
                    }
                    log.LogToFile("Move File, " + s + " ,to " + dest + " ,at " + DateTime.Now);
                    //log.LogToDataBase("Move", "Move File " + s + " to " + dest);

                }
                else
                {
                    string dest = Path.Combine(dir, d);
                    Directory.CreateDirectory(dest);
                    dest = Path.Combine(dest, Path.GetFileName(s));

                    File.Copy(s, dest, true);

                    //using (var db = new DatabaseContext())
                    //{
                    //    ProjectFile projectFile = new ProjectFile()
                    //    {
                    //        ProjectId = Session.CurrentProjectId,
                    //        Properties ="{test:test}",
                    //        File = d
                    //    };
                    //    db.ProjectFiles.Add(projectFile);
                    //    db.SaveChanges();
                    //}
                    //projectFile.
                    log.LogToFile("Move File, " + s + " ,to " + dest + " ,at " + DateTime.Now);
                    //log.LogToDataBase("Move", "Move File " + s + " to " + dest);
                    //}
                }
            }
            catch (Exception ex)
            {
                log.LogToFile(ex.Message);
            }
        }
    }
}