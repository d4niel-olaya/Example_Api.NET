using Example_API.Response;
using Example_API.Respuesta;

namespace Example_API.Services
{
    public class CustomService : ICustomService
    {
        private readonly IContext _context;

        public CustomService(IContext context)
        {
            _context = context;
        }

        public IEsquema BadRes()
        {
            return new Esquema(404, "Bad Request", "Something went wrong");
        }
        public IEsquema Succes()
        {
            return new Esquema(200, "ok", "This is my response");
        }

        public IEsquema GetWordById(int id)
        {
            try{
                return new Esquema(200, "Ok", _context.getWord(id));
            }
            catch(Exception e) 
            {
                return new Esquema(404, "Not found",  e.Message.ToString());
            }
        }

    }



    public class CustomContext : IContext
    {
        public IEnumerable<string> Words()
        {
            return new List<string>()
            {
                "Example1", "Example12", "This a word"
            };
        }

        public string getWord(int index)
        {
            return Words().ElementAt(index);
        }


    }

    

    
    public interface ICustomService
    {
        IEsquema BadRes();
        IEsquema Succes();

        IEsquema GetWordById(int id);

    }
    public interface IContext
    {
        IEnumerable<string> Words();


        string getWord(int index);
    }
}