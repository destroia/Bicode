using AutoMapper;
using Business.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class PersonaBI : IPersona
    {
        readonly Data.Interfaces.IPersona PersonaRepo;
        public PersonaBI(Data.Interfaces.IPersona personaRepo)
        {
            PersonaRepo = personaRepo;
        }
        public async Task<Persona> Create(Persona persona)
        {
            persona.Nombre = persona.Nombre.Trim();
            persona.Apellido = persona.Apellido.Trim();

            return await PersonaRepo.Create(persona);
        }

        public async Task<bool> Delete(int id)
        {
            return await PersonaRepo.Delete(id);
        }

        public async Task<List<Persona>> Get()
        {
            return await PersonaRepo.Get();
        }

        public async Task<Persona> GetById(int id)
        {
            return await PersonaRepo.GetById(id);
        }

        public async Task<Persona> Update(Persona persona)
        {
            return await PersonaRepo.Update(persona);
        }
        
        public string GetClasificacion(DateTime? fechaNacimiento)
        {
            DateTime dateNow = DateTime.Now;
            int edad = 0;
            var d = dateNow.Subtract(fechaNacimiento.Value).Days;

            DateTime e = new DateTime();
            edad = e.AddDays(d).Year;
           
            if (edad == 1 )
            {
                return "Niño";
            }
            else
            {
                edad -= 1;
            }
            if (edad >= 0 && edad <= 14) return "Niño";
            else if (edad >= 15 && edad <= 20) return "Adolescente";
            else if (edad >= 21 && edad <= 60) return "Mayor de edad";
            else return "Tercera edad";
        }
    }
}
