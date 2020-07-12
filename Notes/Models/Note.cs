using SQLite;
using System;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string DisplayCreateDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string DisplayLastUpdatedDate {get; set;}
        [Ignore]
        public string Detail { get; set; }
    }
}