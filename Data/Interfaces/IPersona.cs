using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersona
    {
        Task<List<Persona>> Get();
        Task<Persona> GetById(int id);
        Task<Persona> Create(Persona persona);
        Task<Persona> Update(Persona persona);
        Task<bool> Delete(int id);
    }
}
