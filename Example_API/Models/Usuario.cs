using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace Example_API.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
    }
}
