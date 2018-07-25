using AG.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AG.Web.Infrastructure
{
    public class ErrorResult : IActionResult
    {
        private readonly ResponseMeta _response;

        public ErrorResult(ResponseMeta response)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var jsonResult = new JsonResult(_response);

            jsonResult.StatusCode = StatusCodes.Status400BadRequest;
            

            return jsonResult.ExecuteResultAsync(context);
        }
    }
}
