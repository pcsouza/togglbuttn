using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TogglButtn.TogglClient
{
    public class TogglAPIClient
    {
        HttpClient _client;
        public TogglAPIClient(Config.IConfig config) {
            _client = new HttpClient();
            var authParam = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{config.TogglApiKey}:api_token"));
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authParam);
            _client.BaseAddress = new Uri(API_URL);
        }
        private static string API_URL = @"https://www.toggl.com/api/v8/";
        public async Task<GetRunningTogglTaskResponse> GetCurrentTimeEntry() {
            var resp = await _client.GetAsync("time_entries/current");
            var respContent = await resp.Content.ReadAsStringAsync();
            using (var jReader = new JsonTextReader(new StreamReader(await resp.Content.ReadAsStreamAsync()))) {
                return GetRunningTogglTaskResponse.Build(await JToken.ReadFromAsync(jReader));
            }
        }

    }
}
