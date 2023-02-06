using Example_API.Response;


namespace Example_API.Services
{
    public class CustomService : ICustomService
    {
        private readonly IContext _context;

        public CustomService(IContext context)
        {
            _context = context;
        }

        public DataBinding<IEnumerable<string>> getWords()
        {
            return new DataBinding<IEnumerable<string>>(200, _context.Words(), "Ok");
        }
    }



    public class CustomContext : IContext
    {
        public IEnumerable<string> Words()
        {
            return new List<string>()
            {
                "Example1", "Example12"
            };
        }
    }

    

    
    public interface ICustomService
    {
        DataBinding<IEnumerable<string>> getWords();
    }
    public interface IContext
    {
        IEnumerable<string> Words();
    }
}