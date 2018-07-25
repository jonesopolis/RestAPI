using AG.Service.Interface;
using AG.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Web
{
    [Route("api/[controller]")]
    public class CourseInfoController : Controller
    {
        private readonly ICourseInfoService _service;

        public CourseInfoController(ICourseInfoService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("course/{courseId:long}")]
        public async Task<IActionResult> GetCourseInfoForCourse(long courseId)
        {
            var response = await _service.GetCourseInfoForCourse(courseId);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok(response.Item);
        }
    }
}
