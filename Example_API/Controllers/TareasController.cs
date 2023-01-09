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
        private readonly StudyAppContext _context;

        public TareasController(StudyAppContext context)
        {

            _context = context;
        }


    }
        
    }
}
