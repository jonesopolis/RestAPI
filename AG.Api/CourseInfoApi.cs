using AG.Utilities;
using AG.Api.Extensions;
using AG.Dto;
using System.Threading.Tasks;

namespace AG.Api
{
    public sealed class CourseInfoApi : ApiBase
    {
        public CourseInfoApi() : base("api/courseinfo") { }

        public async Task<ResponseMeta<CourseInfoDto>> GetCourseInfoForCourse(long courseId)
        {
            var response = await _client.GetAsync($"{_relativeUri}/course/{courseId}");
            return await response.GetResponseAsync<CourseInfoDto>();            
        }
    }
}
