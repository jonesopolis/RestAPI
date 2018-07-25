using AG.Service.Interface;
using AG.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AG.Web
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        private readonly ISettingsService _service;

        public SettingsController(ISettingsService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet()]
        public async Task<IActionResult> GetSettings()
        {
            var response = await _service.GetSettings();

            if (!response.Success)
            {
                return new ErrorResult(response);
            }

            return Ok(response.Item);
        }
    }
}
