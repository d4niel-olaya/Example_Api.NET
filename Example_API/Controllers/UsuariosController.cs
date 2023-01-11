using Example_API.Services;
using Example_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {

            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Store(Usuario user)
        {

            var response =await _service.Save(user);
            if (!response)
            {
                return BadRequest();
            }
            return StatusCode(201, "Se ha creado un usuario");

        }

    }
}
