using Example_API;
using Example_API.Models;
using Example_API.Response;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Services
{
    public class NotaService : INotaService
    {
        private readonly StudyAppContext _service;


        public NotaService(StudyAppContext service){
            _service = service;
        }


        public INotaBody getMsg(int id)
        {
            INotasResponse res = new NotasResponse();
            try{
                int numero = id;
                return res.SuccesResponse();
            }
            catch(Exception error)
            {
                return res.BadResponse();
            }
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


    public class NotasResponse : INotasResponse
    {
        public int Code {get; set;}

        public string Data {get;set;}

        public string Msg {get; set;}

        public INotaBody SuccesResponse()
        {
            INotaBody res = new NotaBody(){
                Code = 200,
                Data = "Success",
                Msg = "mensaje"
            };
            return res;
        }

        public INotaBody BadResponse()
        {
            return new NotaBody(){
                Code = 400,
                Msg = "Not found",
                Data = "null"
            };
        }


    }

    public class NotaBody : INotaBody
    {
        public int Code {get;set;}

        public string Data {get; set;}

        public string Msg {get; set;}
    }
    public interface INotaService
    {

        public INotaBody getMsg(int id);
        public Task<IEnumerable<Nota>> get();
        public Task<IEnumerable<Nota>> getByid(int id);
        public Task<bool> Save(Nota nota);
    }

    public interface INotasResponse :  INotaBody, IActionsResponse<INotaBody>
    {

    }

    public interface INotaBody : IBodyRes
    {

    }
}
