using AutoMapper;
using Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<PersonaDto, Persona>();
            CreateMap<GeneroDto, Genero>();
            CreateMap<DocumentoDto, Documento>();

            CreateMap<Persona, PersonaDto>();
            CreateMap<Genero, GeneroDto>();
            CreateMap<Documento, DocumentoDto>();

        }
    }
}
