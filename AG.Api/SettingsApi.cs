using AG.Utilities;
using AG.Api.Extensions;
using AG.Dto;
using System.Threading.Tasks;

namespace AG.Api
{
    public sealed class SettingsApi : ApiBase
    {
        public SettingsApi() : base("api/settings") { }

        public async Task<ResponseMeta<SettingsDto>> GetSettings()
        {
            var response = await _client.GetAsync(_relativeUri);
            return await response.GetResponseAsync<SettingsDto>();
        }
    }
}
