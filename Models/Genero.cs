using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models
{
    public partial class Genero
    {
        public Genero()
        {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
