using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Gama.WebApi.Models;
using GamaWebApi.Models;

namespace Gama.WebApi.Controllers
{
    public class KeyValueModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/KeyValueModels
        public IQueryable<KeyValueModels> GetKeyValueModels()
        {
            return db.KeyValueModels;
        }

        // GET: api/KeyValueModels/5
        [ResponseType(typeof(KeyValueModels))]
        public async Task<IHttpActionResult> GetKeyValueModels(int id)
        {
            KeyValueModels keyValueModels = await db.KeyValueModels.FindAsync(id);
            if (keyValueModels == null)
            {
                return NotFound();
            }

            return Ok(keyValueModels);
        }

        // PUT: api/KeyValueModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeyValueModels(int id, KeyValueModels keyValueModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyValueModels.Id)
            {
                return BadRequest();
            }

            db.Entry(keyValueModels).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyValueModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KeyValueModels
        [ResponseType(typeof(KeyValueModels))]
        public async Task<IHttpActionResult> PostKeyValueModels(KeyValueModels keyValueModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KeyValueModels.Add(keyValueModels);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = keyValueModels.Id }, keyValueModels);
        }

        // DELETE: api/KeyValueModels/5
        [ResponseType(typeof(KeyValueModels))]
        public async Task<IHttpActionResult> DeleteKeyValueModels(int id)
        {
            KeyValueModels keyValueModels = await db.KeyValueModels.FindAsync(id);
            if (keyValueModels == null)
            {
                return NotFound();
            }

            db.KeyValueModels.Remove(keyValueModels);
            await db.SaveChangesAsync();

            return Ok(keyValueModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyValueModelsExists(int id)
        {
            return db.KeyValueModels.Count(e => e.Id == id) > 0;
        }
    }
}