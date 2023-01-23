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
        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            return Ok(await _service.Show(id));
        }
        [HttpPost]
        public async Task<IActionResult> Store(Usuario user)
        {

            var response = await _service.Save(user);
            if (!response)
            {
                return BadRequest();
            }
            return StatusCode(201, "Se ha creado un usuario");

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
             var response =  await _service.Destroy(id);

            if (!response)
            {
                return BadRequest($"El id {id} no existe");
            }
            return StatusCode(202, "Usuario borrado");
        }

    }
}
