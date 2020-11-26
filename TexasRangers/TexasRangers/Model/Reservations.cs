using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TexasRangers.Model
{
    public class Reservations
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime reDate { get; set; }
        public TimeSpan reTime { get; set; }
        public int peopleNum { get; set; }
        public string name { get; set; }
        public DateTime reCreated { get; set; }
    }
}
