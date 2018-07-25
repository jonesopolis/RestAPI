using AG.Utilities;
using AG.Data;
using AG.Data.Model;
using AG.Dto;
using AG.Service.Extensions;
using AG.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Service
{
    public class CourseInfoService : ICourseInfoService
    {
        private readonly AsyncFactory<AgContext> _contextFactory;

        public CourseInfoService(AsyncFactory<AgContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ResponseMeta<CourseInfoDto>> GetCourseInfoForCourse(long courseId)
        {
            using (var context = await _contextFactory)
            {
                var address = await context.CourseAddresses.FirstOrDefaultAsync(a => a.CourseId == courseId);
                var info = await context.CourseContactInfo.FirstOrDefaultAsync(i => i.CourseId == courseId);
                var text = await context.CourseTexts.FirstOrDefaultAsync(t => t.CourseId == courseId);
                
                
                return ResponseMeta<CourseInfoDto>.CreateSuccess((address, info, text).ToCourseInfoDto());
            }
        }
    }
}
