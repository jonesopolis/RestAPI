using System;
using System.Net.Http;

namespace AG.Api
{
    public abstract class ApiBase
    {
        protected readonly Uri _relativeUri;
        protected readonly HttpClient _client;

        public ApiBase(string relativeUrl)
        {
            if (Settings.BaseUrl == null)
            {
                throw new ArgumentNullException(nameof(Settings.BaseUrl), "Settings.BaseUrl must be set");
            }

            _relativeUri = new Uri(new Uri(Settings.BaseUrl), relativeUrl);
            _client = Settings.Client;
        }        
    }
}
