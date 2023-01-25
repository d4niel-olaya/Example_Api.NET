
using System;
using System.Globalization;
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using static Newtonsoft.Json.JsonConvert;
using System;
using Example_API;
namespace Example_API.Middlewares
{
    public class Test
    {
        private readonly RequestDelegate _next;


        public Test(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context){
            await _next(context);
            
            if(context.Request.Path == "/Hour"){
                var auth = context.Request.Headers.Authorization.ToString();
                if(auth.Length == 0){
                    await context.Response.WriteAsync(DateTime.Now.ToString());
                }
            }
        } 
    }

    public static class TestMiddlewareExtensions
    {
        public static IApplicationBuilder UseTestMiddleware(
           this IApplicationBuilder builder
        ){
            return builder.UseMiddleware<Test>();
        }
    }
}