using System;

namespace TogglMigrator.Models
{
    public class TimeEntry
    {
        public int id { get; set; }
        public string guid { get; set; }
        public int wid { get; set; }
        public int pid { get; set; }
        public bool billable { get; set; }
        public DateTime start { get; set; }
        public DateTime stop { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public bool duronly { get; set; }
        public DateTime at { get; set; }
        public int uid { get; set; }
    }

}