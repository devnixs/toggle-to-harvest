using System;
using System.Collections.Generic;

namespace TogglMigrator.Models
{
    public class MyAccountResponse
    {
        public int since { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string api_token { get; set; }
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
        public DateTime created_at { get; set; }
        public int retention { get; set; }
        public bool record_timeline { get; set; }
        public bool render_timeline { get; set; }
        public bool timeline_enabled { get; set; }
        public bool timeline_experiment { get; set; }
        public bool should_upgrade { get; set; }
        public bool achievements_enabled { get; set; }
        public string timezone { get; set; }
        public bool openid_enabled { get; set; }
        public bool send_product_emails { get; set; }
        public bool send_weekly_report { get; set; }
        public bool send_timer_notifications { get; set; }
        public string last_blog_entry { get; set; }
        public List<Workspace> workspaces { get; set; }
        public string duration_format { get; set; }
        public Obm obm { get; set; }
    }

    public class Obm
    {
        public bool included { get; set; }
        public int nr { get; set; }
        public string actions { get; set; }
    }

    public class Workspace
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profile { get; set; }
        public bool premium { get; set; }
        public bool admin { get; set; }
        public int default_hourly_rate { get; set; }
        public string default_currency { get; set; }
        public bool only_admins_may_create_projects { get; set; }
        public bool only_admins_see_billable_rates { get; set; }
        public bool only_admins_see_team_dashboard { get; set; }
        public bool projects_billable_by_default { get; set; }
        public int rounding { get; set; }
        public int rounding_minutes { get; set; }
        public string api_token { get; set; }
        public DateTime at { get; set; }
        public bool ical_enabled { get; set; }
    }


}