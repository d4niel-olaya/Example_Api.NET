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
            var response = await _service.Notas
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
            if(nota.IdTarea == 0){
                return false;
            }
            _service.Notas.Add(nota);
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
