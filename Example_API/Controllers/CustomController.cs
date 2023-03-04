using Example_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example_API.Models;
using System.Text;
using System.IO;
using SpreadsheetLight;
using System.Net.Mail;
using System.Net;


namespace Example_API.Controllers
{

    [Route("api/custom")]
    [ApiController]
    public class CustomController : Controller
    {
        private readonly ICustomService _service;

        public CustomController(ICustomService service)
        {
            _service = service;
        }


        [HttpGet("Word")]
        public IActionResult MyWord()
        {
            return StatusCode(_service.Succes().Code, _service.Succes());
        }
        [HttpGet("listado/{id}")]
        public IActionResult getList(int id)
        {
            return StatusCode(_service.GetWordById(id).Code, _service.GetWordById(id));
        }


        [HttpGet("archivo")]
        public IActionResult getFile()
        {
            string[] lineas = {"Linea1", "Linea 2"};
            string contenido = "Este es el contenido de un archivo de texto";
            byte[] content = Encoding.UTF8.GetBytes(contenido);
            var arr = new ByteArrayContent(content);
            return File(content, "text/plain");
        }



        [HttpPost("excel")]
        public IActionResult leer([FromForm] IFormFile archivo)
        {
            if(archivo != null && archivo.Length > 0)
            {

                // string ruta = @"C:\Users\Juan Daniel\Downloads\Productos-y-Servicios (11).xlsx";
                SLDocument documento = new SLDocument(archivo.OpenReadStream());    
                int fila = 2;
                string valor = documento.GetCellValueAsString(2, 3);
                Console.WriteLine(valor);
                Console.WriteLine(archivo.ContentType);
            }
            return Ok("OK");
        }
        

        [HttpPost("Enviar-correo")]
        public async Task<IActionResult> Email([FromForm]string asunto,[FromForm] string destinatario, [FromForm] IFormFile archivo)
        {
            string AdminUser = "";
            string AdminPassword = "";
            string SMTPName = "smtp.office365.com";
            string port = "587";
            var mensaje = new MailMessage();
            mensaje.To.Add(new MailAddress(destinatario));
            mensaje.From = new MailAddress(AdminUser);
            mensaje.Subject = asunto;
            mensaje.Body = "Esto es un mensaje";
            var archivoEnviar = new Attachment(archivo.OpenReadStream(), archivo.FileName,archivo.ContentType);
            mensaje.Attachments.Add(archivoEnviar);
            using (var smtp = new SmtpClient())
            {
                var credencial = new NetworkCredential(AdminUser, AdminPassword);
                smtp.Credentials = credencial;
                smtp.Host = SMTPName;
                smtp.Port = int.Parse(port);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mensaje);
            }
            return Ok("Ok");
        }
    }
}