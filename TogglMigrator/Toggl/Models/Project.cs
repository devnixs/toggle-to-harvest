using System;
using System.Collections.Generic;

namespace TogglMigrator.Models
{

    public class Project
    {
        public int id { get; set; }
        public int wid { get; set; }
        public int cid { get; set; }
        public string name { get; set; }
        public bool billable { get; set; }
        public bool is_private { get; set; }
        public bool active { get; set; }
        public bool template { get; set; }
        public DateTime at { get; set; }
        public DateTime created_at { get; set; }
        public string color { get; set; }
        public bool auto_estimates { get; set; }
        public int actual_hours { get; set; }
        public string hex_color { get; set; }
    }

}