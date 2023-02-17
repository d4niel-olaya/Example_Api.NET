using Example_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example_API.Models;
using System.Text;
using System.IO;
using SpreadsheetLight;


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
            try{

                return StatusCode(_service.getWord(id).Code,_service.getWord(id));
            }
            catch(Exception error)
            { 
                return BadRequest(_service.BadResponse(error.Message.ToString(), 400, "Bad request"));
            }
        }

        [HttpGet("archivo")]
        public IActionResult getFile()
        {
            string[] lineas = {"Linea1", "Linea 2"};
            string contenido = "Este es el contenido de un archivo de texto";
            byte[] content = Encoding.UTF8.GetBytes(contenido);
            var arr = new ByteArrayContent(content);
            return File(content, "text/plain");
        }



        [HttpPost("excel")]
        public IActionResult leer([FromForm] IFormFile archivo)
        {
            if(archivo != null && archivo.Length > 0)
            {

                // string ruta = @"C:\Users\Juan Daniel\Downloads\Productos-y-Servicios (11).xlsx";
                SLDocument documento = new SLDocument(archivo.OpenReadStream());    
                int fila = 2;
                string valor = documento.GetCellValueAsString(fila, 2);
                Console.WriteLine(valor);
            }
            return Ok("OK");
        }
        

        
    }
}