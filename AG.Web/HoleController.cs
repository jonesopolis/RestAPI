using AG.Dto;
using AG.Service.Interface;
using AG.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AG.Web
{
    [Route("api/[controller]")]
    public class HoleController : Controller
    {
        private readonly IHoleService _service;

        public HoleController(IHoleService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("course/{courseId:long}")]
        public async Task<IActionResult> GetHolesForCourse(long courseId)
        {
            var response = await _service.GetHolesForCourse(courseId);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok(response.Item);
        }
    }
}
