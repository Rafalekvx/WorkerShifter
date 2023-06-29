using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerShifter.Models
{
    public class ShiftModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }
        public DateTime date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int personId { get; set; }
        public int storeId { get; set; }

    }
}
