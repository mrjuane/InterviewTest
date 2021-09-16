using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using InventoryDataAccess.Factory;

using System.Web.Http.Description;
using InventoryDataAccess;

namespace InventoryWeb.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly IInventoryDA<InventoryDataAccess.Category> objContext = null;

        public CategoryController(IInventoryDA<InventoryDataAccess.Category> _category)
        {
            objContext = _category;
        }

        //GET
        public IQueryable<Category> GetProducts()
        {
            return this.objContext.GetAllEntity().AsQueryable();
        }

        //Get 
        //GET
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> GetProduct(int id , string metadata)
        //{
        //    //try
        //    //{
        //    //    var result = await Task.Run(() =>
        //    //    {
        //    //        var query = objContext.GetAllEntity().Where(c => c.InstanceId == id);


        //    //        return query.ToList();
        //    //    }

        //    //    );
        //    return Ok();// result);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}


        //GET
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            try
            {
                var result = await Task.Run(() => objContext.GetEntityById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PUT
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PutCategory(int id, Category entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (entity.Categories1.Count == 0 || entity.CategoryAttributes.Count == 0)
                {
                    return BadRequest($"the Category {entity.Name} not contain Categories or Attributes..");
                }

                if (id != entity.InstanceId)
                {
                    return BadRequest();
                }

                var result = await Task.Run(() => objContext.UpdateEntity(entity));

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //POST 
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostProduct(Category entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var dataResult = await Task.Run(() => this.objContext.InsertEntity(entity));

                return CreatedAtRoute("Default", new { id = entity.InstanceId }, entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.objContext.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
