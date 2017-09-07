using System;

namespace TogglMigrator.Harvest.Models
{
    public class ProjectResponse
    {
        public Project project { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool active { get; set; }
        public string bill_by { get; set; }
        public object budget { get; set; }
        public string budget_by { get; set; }
        public bool notify_when_over_budget { get; set; }
        public float over_budget_notification_percentage { get; set; }
        public object over_budget_notified_at { get; set; }
        public bool show_budget_to_all { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object starts_on { get; set; }
        public object ends_on { get; set; }
        public object estimate { get; set; }
        public string estimate_by { get; set; }
        public bool is_fixed_fee { get; set; }
        public bool billable { get; set; }
        public object hint_earliest_record_at { get; set; }
        public object hint_latest_record_at { get; set; }
        public string notes { get; set; }
        public float hourly_rate { get; set; }
        public object cost_budget { get; set; }
        public bool cost_budget_include_expenses { get; set; }
    }

}