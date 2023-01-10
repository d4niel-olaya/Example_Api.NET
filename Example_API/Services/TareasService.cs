using Example_API.Models;

namespace Example_API.Services
{
    public class TareasService
    {
        private readonly StudyAppContext _services;

        public TareasService(StudyAppContext context)
        {
            _services = context;
        }


        public IEnumerable<Tarea> get()
        {
            return _services.Tareas;
        }

        
    }

    public interface ITareasService
    {
        public IEnumerable<Tarea> get();

        
    }
}
