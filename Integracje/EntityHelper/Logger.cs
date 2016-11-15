using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHelper
{
    public class Logger
    {
        private DateTime dateTime;
        private string info;
        private string name;

        public Logger(string info, DateTime dateTime, string name)
        {
            this.info = info;
            this.dateTime = dateTime;
            this.name = name;

            Log();
        }

        private void Log()
        {
            using (var db = new DbLogsContext())
            {
                try
                {
                    var log = db.CreateDefaultLog();
                    log.data = dateTime;
                    log.procedure_name = name;
                    log.ip = info;

                    db.DbLogs.Add(log);
                    db.SaveChanges();
                }
                catch { }
            }
        }

        public int GetActivitiesCountOfLastTenMinutes()
        {
            using (var db = new DbLogsContext())
            {
                try
                {
                    var list = db.DbLogs.ToList();
                    var logCountList = from log in list
                                       where (log.data + TimeSpan.FromMinutes(10)).CompareTo(dateTime) == 1 && log.ip.Trim() == info
                                       select log;

                    return logCountList.Count();
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}




