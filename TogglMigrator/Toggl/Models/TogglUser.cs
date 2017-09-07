using System;

namespace TogglMigrator.Models
{
    public class TogglUser
    {
        public int id { get; set; }
        public int default_wid { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string jquery_timeofday_format { get; set; }
        public string jquery_date_format { get; set; }
        public string timeofday_format { get; set; }
        public string date_format { get; set; }
        public bool store_start_and_stop_time { get; set; }
        public int beginning_of_week { get; set; }
        public string language { get; set; }
        public string image_url { get; set; }
        public bool sidebar_piechart { get; set; }
        public DateTime at { get; set; }
        public int retention { get; set; }
        public bool record_timeline { get; set; }
        public bool render_timeline { get; set; }
        public bool timeline_enabled { get; set; }
        public bool timeline_experiment { get; set; }
        public bool should_upgrade { get; set; }
    }

}