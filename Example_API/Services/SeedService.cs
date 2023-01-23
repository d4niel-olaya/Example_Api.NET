
using Example_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Example_API.Services
{

    public class SeedService
    {
        public readonly StudyAppContext _context; 


        public SeedService(StudyAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(!_context.Libros.Any())
            {
                var libros = new List<Libro>()
                {
                    new Libro(){
                        Titulo = "Clean Arquitecture"
                        
                    },

                    new Libro(){
                        Titulo = "Clean code"
                    }

                };

                _context.Libros.AddRange(libros);
                _context.SaveChanges();
            }
        }
    }
}