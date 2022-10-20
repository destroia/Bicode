using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace Models
{
    public class DocumentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
    public class DocumentoValidator : AbstractValidator<DocumentoDto>
    {
        public DocumentoValidator()
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Abreviatura).NotNull().NotEmpty().MaximumLength(3);
        }
    }
}
