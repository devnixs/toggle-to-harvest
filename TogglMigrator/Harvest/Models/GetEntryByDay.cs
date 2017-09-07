using System;

namespace TogglMigrator.Harvest.Models
{
    public class EntryResponse
    {
        public DayEntry day_entry { get; set; }
    }

    public class DayEntry
    {
        public int id { get; set; }
        public string notes { get; set; }
        public string spent_at { get; set; }
        public float hours { get; set; }
        public int user_id { get; set; }
        public int project_id { get; set; }
        public int task_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool adjustment_record { get; set; }
        public object timer_started_at { get; set; }
        public bool is_closed { get; set; }
        public bool is_billed { get; set; }
    }

}