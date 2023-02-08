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

        public DataBinding<string> getWord(int index)
        {
            return new DataBinding<string>(200, _context.getWord(index), "Found");
        } 

        public DataBinding<string> BadResponse(string msg , int code, string content)
        {
            return new DataBinding<string>(code,content, msg);
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

        public string getWord(int index)
        {
            return Words().ElementAt(index);
        }
    }

    

    
    public interface ICustomService
    {
        DataBinding<IEnumerable<string>> getWords();

        DataBinding<string> getWord(int index);

        DataBinding<string> BadResponse(string msg, int code, string content);
    }
    public interface IContext
    {
        IEnumerable<string> Words();


        string getWord(int index);
    }
}