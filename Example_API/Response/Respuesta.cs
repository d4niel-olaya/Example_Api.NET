using System;


namespace Example_API.Respuesta
{

    public class Esquema<T> : IEsquema<T>
    {

        public int Code {get;set;}

        public string Msg {get;set;}

        public T Data {get; set;}
        public Esquema(int code, string msg, T data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }
    }

    public interface IEsquema<T>
    {
        int Code {get;set;}

        string Msg {get;set;}

        T Data {get; set;}
    }
    
}