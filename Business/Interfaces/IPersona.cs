using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersona
    {
        Task<List<Persona>> Get();
        Task<Persona> GetById(int id);
        Task<Persona> Create(Persona persona);
        Task<Persona> Update(Persona persona);
        Task<bool> Delete(int id);
        string GetClasificacion(DateTime? fechaNacimiento);
    }
}
