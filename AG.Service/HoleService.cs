using AG.Utilities;
using AG.Data;
using AG.Dto;
using AG.Service.Extensions;
using AG.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Service
{
    public class HoleService : IHoleService
    {
        private readonly AsyncFactory<AgContext> _contextFactory;

        public HoleService(AsyncFactory<AgContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ResponseMeta<List<HoleDto>>> GetHolesForCourse(long courseId)
        {
            using (var context = await _contextFactory)
            {
                var course = await context.Courses
                                          .Include(c => c.Holes)
                                          .FirstOrDefaultAsync(c => c.Id == courseId);

                if(course == null)
                {
                    return ResponseMeta<List<HoleDto>>.CreateFailure(ResponseFailureType.EntityNotFound);
                }

                var holes = course.Holes
                                  .Select(h => h.ToDto())
                                  .ToList();

                return ResponseMeta<List<HoleDto>>.CreateSuccess(holes);
            }
        }
    }
}
