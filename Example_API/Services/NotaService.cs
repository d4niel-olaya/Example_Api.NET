using Example_API;
using Example_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Services
{
    public class NotaService : INotaService
    {
        private readonly StudyAppContext _service;


        public NotaService(StudyAppContext service){
            _service = service;
        }


        public string getMsg()
        {
            return "Esto es un string";
        }
        public async Task<IEnumerable<Nota>> get(){
            var response = await _service.Notas.Include(t => t.IdTareaNavigation)
            .ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Nota>> getByid(int id)
        {
            var found = await get();
            return found.Where(a => a.Id == id);
        }

        public async Task<bool> Save(Nota nota)
        {  

            var tarea = _service.Tareas.Include(t=>t.Nota).Where(t => t.Id ==nota.IdTarea).First();
            var miNota = new Nota{
                IdTarea = nota.IdTarea,
                Contenido = nota.Contenido
            };
            tarea.Nota.Add(miNota);
            await _service.SaveChangesAsync();
            return true;
        }

    }

    public interface INotaService
    {

        public string getMsg();
        public Task<IEnumerable<Nota>> get();
        public Task<IEnumerable<Nota>> getByid(int id);
        public Task<bool> Save(Nota nota);
    }
}
