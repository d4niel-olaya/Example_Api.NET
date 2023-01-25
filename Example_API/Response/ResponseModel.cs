using Newtonsoft.Json;
namespace Example_API.Response
{

    // Resumen:
//          Clase para responder a una solicitud hecha por el controllador.
    public class ResponseHTTP: IResponse<IMessage>
    {       
        public IMessage GoodResponse(string msg, int code)
        {

            IMessage obj = new Message();
            return obj;
        }

        public string BadResponse(Exception error)
        {
            return "Esto fue una mala respueta";
        } 
    }

    public interface IResponse<Type>
    {
        public Type GoodResponse(string msg, int code);

        public string BadResponse(Exception error);
    }

    public class Message : IMessage
    {
        public string Msg {get;set;}

        public int Code  {get;set;}

        public Message(string msg = "ok", int code = 200)
        {
            Msg = msg;
            Code = code;
        }
    }
    public interface IMessage
    {
        public string Msg  {get; set;}

        public int Code {get;set;}
    }

}

