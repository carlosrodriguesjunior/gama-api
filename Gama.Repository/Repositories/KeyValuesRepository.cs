using Gama.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Repository.Repositories
{
    public class KeyValuesRepository : IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task Insert(KeyValueModels model)
        {
            db.KeyValueModels.Add(model);
            await db.SaveChangesAsync();
        }

        public async Task Update(KeyValueModels model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            KeyValueModels keyValueModels = await db.KeyValueModels.FindAsync(id);

            if (keyValueModels == null)
            {
                throw new Exception("Nenhum KeyValue encontrado com o Id:" + id);
            }

            db.KeyValueModels.Remove(keyValueModels);
            await db.SaveChangesAsync();
        }

        public async Task<KeyValueModels> GetOne(int id)
        {
           return await db.KeyValueModels.Where(x => x.Id == id).FirstAsync();
        }

        public async Task< IList<KeyValueModels>> GetAll()
        {
            return await db.KeyValueModels.ToListAsync();
        }

        public void Dispose()
        {
                db.Dispose();
        }
    }
}
