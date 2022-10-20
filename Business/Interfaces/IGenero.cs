using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGenero
    {
        Task<List<Genero>> Get();
        Task<Genero> Create(Genero genero);
        Task<Genero> Update(Genero genero);
        Task<bool> Delete(int id);
    }
}
