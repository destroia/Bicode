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
    public class DocumentoData : IDocumento
    {
        readonly BI_TESTGENContext DB;
        public DocumentoData(BI_TESTGENContext db)
        {
            DB = db;
        }
        public async Task<Documento> Create(Documento doc)
        {
            await DB.Documentos.AddAsync(doc);
            await DB.SaveChangesAsync();

            return doc;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await DB.Documentos.FindAsync(id);

            if (model != null)
            {
                DB.Documentos.Remove(model);
                await DB.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<Documento>> Get()
        {
            return await DB.Documentos.ToListAsync();
        }

        public async Task<Documento> Update(Documento doc)
        {
            var model = await DB.Documentos.FindAsync(doc.Id);

            if (model != null)
            {
                model.Nombre = doc.Nombre;
                model.Abreviatura = doc.Abreviatura;

                DB.Documentos.Update(model);
                await DB.SaveChangesAsync();

                return doc;
            }
            return null;
        }
    }
}
