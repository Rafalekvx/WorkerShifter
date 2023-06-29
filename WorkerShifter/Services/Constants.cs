using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerShifter.Services
{
    public static class Constants
    {
        public const string DatabaseFilename = "Global.db3";

        static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WShifter");
        public static string DatabasePath => Path.Combine(DBPath, DatabaseFilename);
    }
}
