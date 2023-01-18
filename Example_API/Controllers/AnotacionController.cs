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
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacionController : ControllerBase
    {
        private readonly IAnotacionService _context;

        public AnotacionController(IAnotacionService context){
            _context = context;
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
        
    }
}
