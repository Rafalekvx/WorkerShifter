using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerShifter.Models
{
    public class PositionModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string Position { get; set; }
        public bool IsBoss { get; set; } = false;
    }
}
