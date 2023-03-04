using System;


namespace Example_API.Respuesta
{

    public class Esquema : IEsquema
    {

        public int Code {get;set;}

        public string Msg {get;set;}

        public object Data {get; set;}

        public Esquema(int code, string msg, object data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }
    }

    public interface IEsquema
    {
        int Code {get;set;}

        string Msg {get;set;}

        object Data {get; set;}
    } 
    
}