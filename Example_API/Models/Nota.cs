using System;
using System.Collections.Generic;

namespace Example_API.Models
{
    public partial class Nota
    {
        public int Id { get; set; }
        public int IdTarea { get; set; }
        public string Contenido { get; set; } = null!;
        public DateTime? Fecha { get; set; }

        public virtual Tarea IdTareaNavigation { get; set; } = null!;
    }
}
