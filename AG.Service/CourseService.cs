using AG.Data;
using AG.Dto;
using AG.Service.Extensions;
using AG.Service.Interface;
using AG.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Service
{
    public class CourseService : ICourseService
    {
        private readonly AsyncFactory<AgContext> _contextFactory;

        public CourseService(AsyncFactory<AgContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ResponseMeta<List<CourseDto>>> SearchAsync(string search)
        {
            using (var context = await _contextFactory)
            {
                var items = context.Courses.ToList();
                var recs = context.Courses
                                  .Where(c => c.Name.Contains(search))
                                  .Take(25)
                                  .ToList()
                                  .Select(c => c.ToDto())
                                  .ToList();

                return ResponseMeta<List<CourseDto>>.CreateSuccess(recs);
            }
        }

        public async Task<ResponseMeta<CourseDto>> GetAsync(long id)
        {
            using (var context = await _contextFactory)
            {
                var model = await context.Courses.FirstOrDefaultAsync(m => m.Id == id);

                if (model == null)
                {
                    return ResponseMeta<CourseDto>.CreateFailure(ResponseFailureType.EntityNotFound);
                }
                
                return ResponseMeta<CourseDto>.CreateSuccess(model.ToDto());
            }
        }

        public async Task<ResponseMeta> AddAsync(CourseDto dto)
        { 
            if (dto.Id != null)
            {
                return ResponseMeta<CourseDto>.CreateFailure(ResponseFailureType.IdRequiredNull);
            }

            using (var context = await _contextFactory)
            {
                var model = dto.ToModel();

                try
                {
                    await context.Courses.AddAsync(model);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return ResponseMeta<CourseDto>.CreateFailure(ex.ToString());
                }

                return ResponseMeta.CreateSuccess();
            }
        }

        public async Task<ResponseMeta> UpdateAsync(CourseDto dto)
        {
            using (var context = await _contextFactory)
            {
                if (dto.Id == null)
                {
                    return ResponseMeta.CreateFailure(ResponseFailureType.IdRequired);
                }

                var existing = await context.Courses.FirstOrDefaultAsync(m => m.Id == dto.Id);
                if (existing == null)
                {
                    return ResponseMeta.CreateFailure(ResponseFailureType.EntityNotFound);
                }

                var model = dto.ToModel();

                try
                {
                    context.Entry(existing).CurrentValues.SetValues(model);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return ResponseMeta.CreateFailure(ex.ToString());
                }

                return ResponseMeta.CreateSuccess();
            }
        }

        public async Task<ResponseMeta> DeleteAsync(long id)
        {
            using (var context = await _contextFactory)
            {
                var model = await context.Courses.FirstOrDefaultAsync(m => m.Id == id);

                if (model == null)
                {
                    return ResponseMeta.CreateFailure(ResponseFailureType.EntityNotFound);
                }

                context.Courses.Remove(model);
                await context.SaveChangesAsync();
                return ResponseMeta.CreateSuccess();
            }
        }
    }
}
