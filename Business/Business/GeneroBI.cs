using Business.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class GeneroBI : IGenero
    {
        readonly Data.Interfaces.IGenero GeneroRepo;
        public GeneroBI(Data.Interfaces.IGenero generoRepo)
        {
            GeneroRepo = generoRepo;
        }

        public async Task<Genero> Create(Genero genero)
        {
            genero.Nombre = genero.Nombre.Trim();

            return await GeneroRepo.Create(genero);
        }

        public async Task<bool> Delete(int id)
        {
            return await GeneroRepo.Delete(id);
        }

        public async Task<List<Genero>> Get()
        {
            return await GeneroRepo.Get();
        }

        public async Task<Genero> Update(Genero genero)
        {
            genero.Nombre = genero.Nombre.Trim();

            return await GeneroRepo.Update(genero);
        }
    }
}
