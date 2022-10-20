using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdGenero { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(200)]
        public string Apellido { get; set; }
        public long? NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Documento IdDocumentoNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
    }
}
