using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class BaseController<T> : ApiController where T : class, IEntity
    {        
        protected IRepository<T> repository = new BaseRepository<T>(new WebShopContext());

        // GET: api/Customers
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await repository.GetAll();
        }

        // GET: api/Customers/5        
        public virtual async Task<IHttpActionResult> GetById(long id)
        {
            T entity = await repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
        
        // POST: api/Customers        
        public virtual async Task<IHttpActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.Add(entity);            

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        // DELETE: api/Customers/5        
        public virtual async Task<IHttpActionResult> Delete(long id)
        {
            return Ok(await repository.Delete(id));            
        }
    }
}