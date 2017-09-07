using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using TogglMigrator.Harvest.Models;

namespace TogglMigrator.Harvest
{
    public class HarvestApi
    {
        private RestClient _restClient;

        public HarvestApi(string email, string password, string domain)
        {
            _restClient = new RestClient($"https://{domain}/")
            {
                Authenticator = new HttpBasicAuthenticator(email, password)
            };
            _restClient.AddDefaultHeader("cache-control", "no-cache");
        }

        public string WhoAmI()
        {
            var request = new RestRequest("account/who_am_i", Method.GET);
            var response = this._restClient.Execute(request);
            return response.Content;
        }

        public List<ProjectResponse> Projects()
        {
            var request = new RestRequest("projects", Method.GET);
            var response = this._restClient.Execute<List<ProjectResponse>>(request);
            return response.Data;
        }

        public List<EntryResponse> GetEntries(int projectId, DateTime from, DateTime to)
        {
            var request = new RestRequest($"projects/{projectId}/entries", Method.GET);
            request.AddQueryParameter("from", from.ToString("yyyyMMdd"));
            request.AddQueryParameter("to", to.ToString("yyyyMMdd"));
            IRestResponse<List<EntryResponse>> response = this._restClient.Execute<List<EntryResponse>>(request);
            return response.Data;
        }

        public CreateTimeEntryResponse CreateEntry(CreateTimeEntryRequest entry)
        {
            var request = new RestRequest("daily/add", Method.POST);
            request.AddJsonBody(entry);
            var response = this._restClient.Execute<CreateTimeEntryResponse>(request);
            return response.Data;
        }
    }
}