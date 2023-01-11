using Example_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Example_API.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly StudyAppContext _context;

        public UsuarioService(StudyAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> Get()
        {

            var response = await _context.Usuarios.ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Usuario>> Show(int id)
        {
            var found = await Get();
            return found.Where(element => element.Id == id);
        }

        public async Task<bool> Save(Usuario user)
        {
            if (user.Nombre == null)
            {
                return false;
            }
            _context.Add(user);
            await _context.SaveChangesAsync();
            return true;

        }



    }


    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> Get();
        Task<IEnumerable<Usuario>> Show(int id);
        Task<bool> Save(Usuario user);
    }
}

