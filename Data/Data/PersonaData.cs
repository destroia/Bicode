using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class PersonaData : IPersona
    {
        readonly BI_TESTGENContext DB;
        public PersonaData(BI_TESTGENContext db)
        {
            DB = db;
        }
        public async Task<Persona> Create(Persona persona)
        {
            await DB.Personas.AddAsync(persona);
            await DB.SaveChangesAsync();

            return persona;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await DB.Personas.FindAsync(id);

            if (model != null)
            {
                DB.Personas.Remove(model);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<Persona>> Get()
        {
            return await DB.Personas.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await DB.Personas.FindAsync(id);
        }

        public async Task<Persona> Update(Persona persona)
        {
            var model = await DB.Personas.FindAsync(persona.Id);

            if (model != null)
            {
                model.Nombre = persona.Nombre;
                model.Apellido = persona.Apellido;
                model.FechaActualizacion = DateTime.Now;
                model.IdGenero = persona.IdGenero;
                model.NumeroDocumento = persona.NumeroDocumento;
                model.IdDocumento = persona.IdDocumento;

                DB.Personas.Update(model);
                await DB.SaveChangesAsync();

                return model;
            }
            return null;
        }
    }
}
