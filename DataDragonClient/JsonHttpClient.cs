using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataDragon
{
    /// <summary>
    /// Provides a HTTP client that can retrieve JSON-serialized responses.
    /// </summary>
    internal sealed class JsonHttpClient : IDisposable
    {
        private readonly HttpClient httpClient;

        internal JsonHttpClient()
        {
            this.httpClient = new HttpClient();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        internal async Task<T> GetAsync<T>(Uri uri)
        {
            Debug.WriteLine($"{nameof(JsonHttpClient)}: Fetching {uri}");
            string content = await httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<T>(content);
        }

        internal async Task<IDictionary<string, T>> GetDataAsync<T>(Uri uri)
        {
            Debug.WriteLine($"{nameof(JsonHttpClient)}: Fetching {uri}");
            string content = await httpClient.GetStringAsync(uri);
            string data = JObject.Parse(content)["data"].ToString();
            return JsonConvert.DeserializeObject<IDictionary<string, T>>(data);
        }
    }
}
