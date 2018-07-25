using System.Collections.Generic;
using System.Threading.Tasks;
using AG.Utilities;
using AG.Dto;

namespace AG.Service.Interface
{
    public interface IHoleService
    {
        Task<ResponseMeta<List<HoleDto>>> GetHolesForCourse(long courseId);
    }
}