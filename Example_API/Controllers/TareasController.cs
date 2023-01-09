using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example_API.Models;

using Tarea = Example_API.Models.Tarea;
using Newtonsoft.Json;

namespace Example_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private static readonly List<Tarea> Listado = new List<Tarea> {
            new Tarea
            {
                id = 1,
                title = "Esta es mi primera tarea",
                description = "Esta es la desc",
                done = '1'

            },
            new Tarea
            {
                id = 2,
                title = "Esta es la segunda tarea",
                description = "Esta es la desc de la tercera",
                done = '1'
            }
        };
        public TareasController()
        {

        }

        [HttpGet("get")]
        public IActionResult Index()
        {
            string response = JsonConvert.SerializeObject(Listado);
            return Ok(Listado);
        }

        [HttpPost("create")]
        public ActionResult<Tarea> store(Tarea nuevaTarea) {
            Listado.Add(nuevaTarea);
            return StatusCode(201, "La tarea ha sido creada");
        }
        
    }
}
