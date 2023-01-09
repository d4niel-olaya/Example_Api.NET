using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example_API.Models;

using Microsoft.EntityFrameworkCore;

namespace Example_API.Controllers
{
    [Route("api/tareas")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly StudyAppContext _context;

        public TareasController(StudyAppContext context)
        {

            _context = context;
        }


        [HttpGet("index")]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Tareas.ToListAsync());
        }

        [HttpGet("show/{id}")]
        public async Task<IActionResult> get(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);  
            return Ok(tarea);
        }

        [HttpPost("create")]
        public async Task<IActionResult> storeTarea([FromBody] Tarea tarea)
        {

            if (!ModelState.IsValid)
            {
                
                return BadRequest();

            }
            _context.Add(tarea);
            await _context.SaveChangesAsync();
            return StatusCode(201);

        }

        
    }
        
    
}
