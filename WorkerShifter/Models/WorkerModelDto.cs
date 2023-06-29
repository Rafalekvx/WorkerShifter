using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerShifter.Models
{
    public class WorkerModelDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string position { get; set; }
        public string boss { get; set; }
        public string deafultStoreName { get; set; }
    }
}
