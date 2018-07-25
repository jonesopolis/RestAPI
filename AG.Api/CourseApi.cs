using AG.Utilities;
using AG.Api.Extensions;
using AG.Dto;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AG.Api
{
    public sealed class CourseApi : ApiBase
    {
        public CourseApi() : base("api/course") { }

        public async Task<ResponseMeta<List<CourseDto>>> SearchAsync(string search)
        {
            var response = await _client.GetAsync($"{_relativeUri}/search/{search}");
            return await response.GetResponseAsync<List<CourseDto>>();
        }

        public async Task<ResponseMeta<CourseDto>> GetByIdAsync(long id)
        {
            var response = await _client.GetAsync($"{_relativeUri}/{id}");
            return await response.GetResponseAsync<CourseDto>();            
        }

        public async Task<ResponseMeta> AddAsync(CourseDto course)
        {
            var response = await _client.PostJsonAsync(_relativeUri.ToString(), course);
            return await response.GetResponseAsync();
        }

        public async Task<ResponseMeta> UpdateAsync(CourseDto course)
        {
            var response = await _client.PutJsonAsync(_relativeUri.ToString(), course);
            return await response.GetResponseAsync();
        }

        public async Task<ResponseMeta> DeleteAsync(long id)
        {
            var response = await _client.DeleteAsync($"{_relativeUri}/{id}");
            return await response.GetResponseAsync();
        }
    }
}
