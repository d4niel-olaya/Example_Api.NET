
namespace Example_API.Response
{

    // Resumen:
//          Clase para responder a una solicitud hecha por el controllador.
    public class ResponseHTTP: IResponse
    {       
        public string GoodResponse(string msg)
        {
            return msg;
        }

        public string BadResponse(Exception error)
        {
            return "Esto fue una mala respueta";
        } 
    }

    public interface IResponse
    {
        public string GoodResponse(string msg);

        public string BadResponse(Exception error);
    }

    public interface IMessage
    {
        public string message  {get; set;}

        public Exception error {get;set;}
    }

}

