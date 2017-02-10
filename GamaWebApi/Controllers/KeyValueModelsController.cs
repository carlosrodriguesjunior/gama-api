using Gama.ApplicationService;
using Gama.Repository.Models;
using Gama.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace Gama.WebApi.Controllers
{
    public class KeyValueModelsController : ApiController
    {
        private KeyValuesRepository repository = new KeyValuesRepository();
        private KeyValuesApplicationService applicationService = new KeyValuesApplicationService();

        // GET: api/KeyValueModels
        [ResponseType(typeof(IList<KeyValueModels>))]
        public async Task<IHttpActionResult> GetKeyValueModels()
        {
            try
            {
                return Ok( await repository.GetAll());
            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }

            
        }

        // GET: api/KeyValueModels/5
        [ResponseType(typeof(KeyValueModels))]
        public async Task<IHttpActionResult> GetKeyValueModels(int id)
        {

            try
            {
                return Ok(await repository.GetOne(id));
            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // PUT: api/KeyValueModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeyValueModels(int id, KeyValueModels keyValueModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await repository.Update(keyValueModels);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/KeyValueModels
        [ResponseType(typeof(KeyValueModels))]
        public async Task<IHttpActionResult> PostKeyValueModels(KeyValueModels keyValueModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await applicationService.SaveKeyValueAndSendEmail(keyValueModels);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/KeyValueModels/5
        [ResponseType(typeof(KeyValueModels))]
        public async Task<IHttpActionResult> DeleteKeyValueModels(int id)
        {
            try
            {
                await repository.Delete(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}