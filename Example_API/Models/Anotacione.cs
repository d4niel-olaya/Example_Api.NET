using System;
using System.Collections.Generic;

namespace Example_API.Models
{
    public partial class Anotacione
    {
        public int Id { get; set; }
        public int IdTarea { get; set; }
        public DateTime? Fecha { get; set; }
        public string Contenido { get; set; } = null!;

        public virtual Tarea IdTareaNavigation { get; set; } = null!;
    }
}
