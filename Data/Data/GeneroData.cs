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
    public class GeneroData : IGenero
    {
        readonly BI_TESTGENContext DB;
        public GeneroData(BI_TESTGENContext db)
        {
            DB = db;
        }
        public async Task<Genero> Create(Genero genero)
        {
            await DB.Generos.AddAsync(genero);
            await DB.SaveChangesAsync();

            return genero;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await DB.Generos.FindAsync(id);

            if (model != null)
            {
                DB.Generos.Remove(model);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<Genero>> Get()
        {
            return await DB.Generos.ToListAsync();
        }

        public async Task<Genero> Update(Genero genero)
        {
            var model = await DB.Generos.FindAsync(genero.Id);

            if (model != null)
            {
                model.Nombre = genero.Nombre;

                DB.Generos.Update(model);
                await DB.SaveChangesAsync();

                return genero;
            }
            return null;
        }
    }
}
