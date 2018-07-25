using AG.Utilities;
using AG.Api.Extensions;
using AG.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AG.Api
{
    public sealed class HoleApi : ApiBase
    {
        public HoleApi() : base("api/hole") { }

        public async Task<ResponseMeta<List<HoleDto>>> GetHolesForCourse(long courseId)
        {
            var response = await _client.GetAsync($"{_relativeUri}/course/{courseId}");
            return await response.GetResponseAsync<List<HoleDto>>();            
        }
    }
}
