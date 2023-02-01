using Example_API.Models;
using Example_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Services
{
    public class TareasService : ITareasService
    {
        private readonly StudyAppContext _services;

        public TareasService(StudyAppContext context)
        {
            _services = context;
        }


        public async Task<IEnumerable<Tarea>> get()
        {
            return await _services.Tareas.ToListAsync();
        }

        public async Task<IEnumerable<Tarea>> getByid()
        {
            return await _services.Tareas.ToListAsync();
        }
    }

    public interface ITareasService : IRead<Tarea>
    {


        
    }

}
