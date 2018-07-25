using System.Threading.Tasks;
using AG.Utilities;
using AG.Dto;

namespace AG.Service.Interface
{
    public interface ICourseInfoService
    {
        Task<ResponseMeta<CourseInfoDto>> GetCourseInfoForCourse(long courseId);
    }
}