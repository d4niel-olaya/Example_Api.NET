using Example_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example_API.Models;

namespace Example_API.Controllers
{

    [Route("api/custom")]
    [ApiController]
    public class CustomController : Controller
    {
        private readonly ICustomService _service;

        public CustomController(ICustomService service)
        {
            _service = service;
        }

        [HttpGet("listado")]
        public IActionResult getList()
        {
            return Ok(_service.getWords());
        }

        [HttpGet("listado/{id}")]
        public IActionResult getWord(int id)
        {
            return StatusCode(_service.getWord(id).Code,_service.getWord(id));
        }
    }
}