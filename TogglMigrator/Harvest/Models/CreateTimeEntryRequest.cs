using System;
using Newtonsoft.Json;

namespace TogglMigrator.Harvest.Models
{
    public class CreateTimeEntryRequest
    {
        public string notes { get; set; }
        public double hours { get; set; }
        public string project_id { get; set; }
        public string task_id { get; set; }
        public string spent_at { get; set; }

        public DateTime SpentAt
        {
            get
            {
                string[] timeElements = this.spent_at.Split("-");
                return new DateTime(int.Parse(timeElements[0]), int.Parse(timeElements[1]), int.Parse(timeElements[2]));
            }
            set => spent_at = value.ToString("yyyy-MM-dd");
        }
    }


    public class CreateTimeEntryResponse
    {
        public string project_id { get; set; }
        public string project { get; set; }
        public int user_id { get; set; }
        public string spent_at { get; set; }
        public string task_id { get; set; }
        public string task { get; set; }
        public string client { get; set; }
        public int id { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int hours_without_timer { get; set; }
        public int hours { get; set; }
    }


}