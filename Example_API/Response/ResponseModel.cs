using Newtonsoft.Json;
namespace Example_API.Response
{

    // Resumen:
//          Clase para responder a una solicitud hecha por el controllador.
    // public class ResponseHTTP
    // {       
    //     public IMessage GoodResponse(string msg, int code)
    //     {

    //         IMessage obj = new Message();
    //         return obj;
    //     }

    //     public string BadResponse(Exception error)
    //     {
    //         return "Esto fue una mala respuesta";
    //     } 
    // }
    
    public interface IResponse<TModel>
    {
        public TModel GoodResponse(string msg, int code);

        public string BadResponse(Exception error);
    }

    public class Message
    {
        public string Msg {get;set;}

        public int Code  {get;set;}

        public Message(string msg = "ok", int code = 200)
        {
            Msg = msg;
            Code = code;
        }
    }


    public interface IMethods<T, X>
    {
        T SuccessResponse(X body);

        T BadResponse(X body);
    }

    public interface IBodyResponse<T>
    {
        int Code {get; set;}

        T Data {get;set;}

        string Msg {get; set;}
    }
    public interface IMessage<TModel>
    {
        public TModel Msg  {get; set;}

        public int Code {get;set;}
    }


    public interface IBodyRes
    {
        public string Msg {get; set;}

        public string Data {get;set;}
        
        public int Code {get; set;}
    }
    
    public interface IActionsResponse<TModel>
   {
        public TModel BadResponse();

        public TModel SuccesResponse();
   }
}

