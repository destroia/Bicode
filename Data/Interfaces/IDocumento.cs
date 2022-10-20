using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDocumento
    {
        Task<List<Documento>> Get();
        Task<Documento> Create(Documento doc);
        Task<Documento> Update(Documento doc);
        Task<bool> Delete(int id);
    }
}
