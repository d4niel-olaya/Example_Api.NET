using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example_API.Controllers
{
    [Route("api/error")]
    [ApiController]
    public class ExceptionController : Controller
    {
        
        [HttpGet("estado")]
        public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
        {
            if(!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            return Problem(
                detail:exceptionHandlerFeature.Error.StackTrace,
                title:exceptionHandlerFeature.Error.Message
            );
        }
    }
}