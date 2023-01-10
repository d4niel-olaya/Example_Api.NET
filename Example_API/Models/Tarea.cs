using System;
using System.Collections.Generic;

namespace Example_API.Models
{
    public partial class Tarea
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Done { get; set; }
    }
}
