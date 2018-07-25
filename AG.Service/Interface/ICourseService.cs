using AG.Utilities;
using AG.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AG.Service.Interface
{
    public interface ICourseService
    {
        Task<ResponseMeta<List<CourseDto>>> SearchAsync(string search);
        Task<ResponseMeta<CourseDto>> GetAsync(long id);
        Task<ResponseMeta> AddAsync(CourseDto rec);
        Task<ResponseMeta> UpdateAsync(CourseDto rec);
        Task<ResponseMeta> DeleteAsync(long id);
    }
}
