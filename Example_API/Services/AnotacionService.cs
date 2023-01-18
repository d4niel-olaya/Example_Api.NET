using Example_API;
using Example_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Services
{
    public class AnotacionService : IAnotacionService
    {
        private readonly StudyAppContext _service;


        public AnotacionService(StudyAppContext context){
            _service = context;
        }

        public async Task<IEnumerable<Anotacione>> get(){
            var response = await _service.Anotaciones
            .Include(c => c.IdTareaNavigation)
            .ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Anotacione>> getByid(int id)
        {
            var found = await get();
            return found.Where(a => a.Id == id);
        }

    }

    public interface IAnotacionService
    {
        public Task<IEnumerable<Anotacione>> get();
        public Task<IEnumerable<Anotacione>> getByid(int id);
    }
}
