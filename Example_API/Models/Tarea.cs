using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Example_API.Models
{
    public partial class Tarea
    {

        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public bool Done { get; set; }
    }
}
