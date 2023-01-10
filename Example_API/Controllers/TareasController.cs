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

        [HttpPut("update/{id}")]   
        public async Task<IActionResult> update(int id,[FromBody] Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest("El id no coincide con la tarea a modificar");
            }
            var found = await _context.Tareas.FindAsync(id);
            if(found != null) {
                found.Title = tarea.Title;
                found.Description = tarea.Description;
                found.Done = tarea.Done;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("deleted/{id}")]
        public async Task<IActionResult> destroy(int id)
        {
            var found = await _context.Tareas.FindAsync(id);
            if(found == null)
            {
                return BadRequest();
            }
            _context.Tareas.Remove(found);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }       
    }
        
    
}
