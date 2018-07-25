using System.Net.Http;

namespace AG.Api
{
    public static class Settings
    {
        public static string BaseUrl { get; set; }

        public static HttpClient Client { get; set; } = new HttpClient();
    }
}
