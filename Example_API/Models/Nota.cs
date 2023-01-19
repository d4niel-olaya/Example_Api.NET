using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace Example_API.Models
{
    public partial class Nota
    {
        public int Id { get; set; }
        public int IdTarea { get; set; }
        public string Contenido { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        
        [JsonIgnore]
        public virtual Tarea IdTareaNavigation { get; set; } = null!;
    }
}
