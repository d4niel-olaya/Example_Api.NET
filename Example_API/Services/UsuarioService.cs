using Example_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Services;

    public class UsuarioService : IUsuarioService
    {

        StudyAppContext _context;

        public UsuarioService(StudyAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> Get()
        {

            var response = _context.Usuarios; 
            return response;
        }



    }


    public interface IUsuarioService
    {
        IEnumerable<Usuario> Get();
    }

