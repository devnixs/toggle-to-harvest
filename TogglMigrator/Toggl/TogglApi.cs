using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using TogglMigrator.Models;

namespace TogglMigrator.Toggl
{
    public class TogglApi
    {
        private RestClient _restClient;

        public TogglApi(string apiKey)
        {
            _restClient = new RestClient("https://www.toggl.com")
            {
                Authenticator = new HttpBasicAuthenticator(apiKey, "api_token")
            };
            _restClient.AddDefaultHeader("cache-control", "no-cache");
        }

        public MyAccountResponse GetAccountInfos()
        {
            var request = new RestRequest("api/v8/me", Method.GET);
            var response = this._restClient.Execute<MyAccountResponse>(request);
            return response.Data;
        }

        public Project GetProjectByName(string name, int workspaceId)
        {
            var request = new RestRequest($"api/v8/workspaces/{workspaceId}/projects", Method.GET);
            var response = this._restClient.Execute<List<Project>>(request);
            return response.Data.First(i => i.name == name);
        }

        public List<TogglUser> GetUsers(int workspaceId)
        {
            var request = new RestRequest($"api/v8/workspaces/{workspaceId}/users", Method.GET);
            var response = this._restClient.Execute<List<TogglUser>>(request);
            return response.Data;
        }

        public TimeEntry[] GetEntries(int projectId, DateTime startDate, DateTime endDate)
        {
            var request = new RestRequest("api/v8/time_entries", Method.GET);
            request.AddQueryParameter("start_date", startDate.ToString("yyyy-MM-ddThh:mm:ss+02:00", CultureInfo.InvariantCulture));
            request.AddQueryParameter("end_date", endDate.ToString("yyyy-MM-ddThh:mm:ss+02:00", CultureInfo.InvariantCulture));
            IRestResponse<List<TimeEntry>> response = this._restClient.Execute<List<TimeEntry>>(request);

            return response.Data.Where(i => i.pid == projectId).ToArray();
        }

        public List<ReportEntry> Report(int projectId, int workspaceId,  DateTime startDate, DateTime endDate)
        {
            var entries = new List<ReportEntry>();
            int page = 1;
            int totalCount = 200;
            while (entries.Count < totalCount)
            {
                IRestResponse<GetReportResponse> response = ReportInternal(projectId, workspaceId, startDate, endDate, page);
                totalCount = response.Data.total_count;
                entries.AddRange(response.Data.data);
                page++;
            }


            return entries;
        }

        private IRestResponse<GetReportResponse> ReportInternal(int projectId, int workspaceId, DateTime startDate, DateTime endDate, int page)
        {
            var request = new RestRequest("/reports/api/v2/details", Method.GET);
            request.AddQueryParameter("since", startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            request.AddQueryParameter("until", endDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            request.AddQueryParameter("project_ids", projectId.ToString());
            request.AddQueryParameter("user_agent", "TogglReader");
            request.AddQueryParameter("workspace_id", workspaceId.ToString());
            request.AddQueryParameter("page", page.ToString());
            var response = this._restClient.Execute<GetReportResponse>(request);
            return response;
        }
    }
}