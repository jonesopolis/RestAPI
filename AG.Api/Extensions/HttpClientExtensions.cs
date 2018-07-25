using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AG.Api.Extensions
{
    internal static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string url, object o)
        {
            var json = JsonConvert.SerializeObject(o);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PutJsonAsync(this HttpClient client, string url, object o)
        {
            var json = JsonConvert.SerializeObject(o);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PutAsync(url, content);
        }
    }
}
