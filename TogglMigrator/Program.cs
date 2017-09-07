using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using RestSharp;
using RestSharp.Authenticators;
using TogglMigrator.Harvest;
using TogglMigrator.Harvest.Models;
using TogglMigrator.Models;
using TogglMigrator.Toggl;

namespace TogglMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var begin = DateTime.Now.AddDays(-10);
            var end = DateTime.Now.AddDays(-2);
            var togglProjectName = Environment.GetEnvironmentVariable("TOGGL_PROJECT_NAME");

            Console.WriteLine($"Loading account data for project '{togglProjectName}'...");

            var harvestApi = new HarvestApi(
                Environment.GetEnvironmentVariable("HARVEST_EMAIL"),
                Environment.GetEnvironmentVariable("HARVEST_PASSWORD"),
                Environment.GetEnvironmentVariable("HARVEST_DOMAIN"));

            List<ProjectResponse> projects = harvestApi.Projects();

            int harvestProjectId = projects.First().project.id;
            var harvestEntries = harvestApi.GetEntries(harvestProjectId, begin, end);


            var togglApi = new TogglApi(Environment.GetEnvironmentVariable("TOGGL_API_KEY"));

            var infos = togglApi.GetAccountInfos();
            int togglWorkspaceId = infos.data.workspaces.First().id;
            var project = togglApi.GetProjectByName(togglProjectName, togglWorkspaceId);
            var entries = togglApi.GetEntries(project.id, begin, end);
            var report = togglApi.Report(project.id, togglWorkspaceId, begin, end);
            var users = togglApi.GetUsers(togglWorkspaceId);

            Console.WriteLine($"Found {entries.Length} Toggl entries");

            int tasksSynchronized = 0;
            foreach (var timeEntry in report)
            {
                var harvestEntry =
                    harvestEntries.FirstOrDefault(i => i.day_entry.notes.StartsWith($"[{timeEntry.id}]"));
                if (harvestEntry == null)
                {
                    Console.WriteLine($"Inserting {timeEntry.start:d} {timeEntry.description}");

                    var user = users.First(i => i.id == timeEntry.uid);

                    harvestApi.CreateEntry(new CreateTimeEntryRequest()
                    {
                        SpentAt = timeEntry.start,
                        hours = ((double)timeEntry.dur / 1000) / 3600,
                        notes = $"[{timeEntry.id}] [{user.fullname}] {timeEntry.description}",
                        project_id = harvestProjectId.ToString(),
                        task_id = timeEntry.id.ToString(),
                    });
                    tasksSynchronized++;
                }
            }

            Console.WriteLine($"Done! {tasksSynchronized} task(s) synchronized");
        }
    }
}