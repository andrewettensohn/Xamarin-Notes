using SQLite;
using System;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        [Ignore]
        public string DisplayCreateDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        [Ignore]
        public string DisplayLastUpdatedDate {get; set;}
    }
}