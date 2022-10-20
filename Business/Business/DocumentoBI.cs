using Business.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class DocumentoBI : IDocumento
    {
        readonly Data.Interfaces.IDocumento DocumentoRepo;
        public DocumentoBI(Data.Interfaces.IDocumento documentoRepo)
        {
            DocumentoRepo = documentoRepo;
        }

        public async Task<Documento> Create(Documento doc)
        {
            doc.Nombre = doc.Nombre.Trim();
            doc.Abreviatura = doc.Abreviatura.Trim();

            return await DocumentoRepo.Create(doc);
        }

        public async Task<bool> Delete(int id)
        {
            return await DocumentoRepo.Delete(id);
        }

        public async Task<List<Documento>> Get()
        {
            return await DocumentoRepo.Get();
        }

        public async Task<Documento> Update(Documento doc)
        {
            doc.Nombre = doc.Nombre.Trim();
            doc.Abreviatura = doc.Abreviatura.Trim();

            return await DocumentoRepo.Update(doc);
        }
    }
}
