using AG.Data.Model;
using AG.Dto;

namespace AG.Service.Extensions
{
    internal static class DtoExtensions
    {
        public static Course ToModel(this CourseDto dto)
        {
            var model = new Course();
            model.Id = dto.Id ?? 0;
            model.Name = dto.Name;
            model.ImagePath = dto.ImagePath;

            return model;
        }

        public static Hole ToModel(this HoleDto dto)
        {
            var model = new Hole();
            model.Id = dto.Id ?? 0;
            model.CourseId = dto.CourseId;
            model.Number = dto.Number;
            model.Par = dto.Par;

            return model;
        }
    }
}
