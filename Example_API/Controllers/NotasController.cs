using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example_API.Models;
using Example_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Controllers
{
    [Route("api/notas")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _context;

        public NotasController(INotaService context){
            _context = context;
        }


        [HttpGet("message")]

        public IActionResult getMessage()
        {
            return Ok("Esto es un mesaje");
        }
        [HttpGet("index")]
        public async Task<IActionResult> getAll(){
            return Ok(await _context.get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> show(int id)
        {
            return Ok(await _context.getByid(id));
        }

        [HttpPost("store")]
        public async Task<IActionResult> Store(Nota nota)
        {
            
            var miNota = new Nota(){
                IdTarea = nota.IdTarea,
                Contenido = nota.Contenido
            };
            var result = await _context.Save(miNota);
            if(result == false){
                return StatusCode(404, "Bad request");
            }
            return StatusCode(201, "Se ha creado una nota");
        }
        
    }
}