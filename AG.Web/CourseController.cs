using AG.Dto;
using AG.Service.Interface;
using AG.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AG.Web
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var response = await _service.SearchAsync(search);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok(response.Item);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _service.GetAsync(id);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok(response.Item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CourseDto rec)
        {
            var response = await _service.AddAsync(rec);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]CourseDto rec)
        {
            var response = await _service.UpdateAsync(rec);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _service.DeleteAsync(id);

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok();
        }
    }
}
