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
    public class ProductController : ApiController
    {
        private readonly IInventoryDA<InventoryDataAccess.Product> objContext = null;

        public ProductController(IInventoryDA<InventoryDataAccess.Product> _Product)
        {
            objContext = _Product;
        }

        //GET
        public IQueryable<Product> GetProducts()
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
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
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
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PutProduct(int id, Product entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //if (entity.Categories.Count == 0 || entity.ProductAttributes.Count == 0)
                //{
                //    return BadRequest($"the product {entity.Name} not contain Categories or Attributes..");
                //}

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
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product entity)
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

        ////Delete 
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            try
            {
                var dataResult = await Task.Run(() => this.objContext.DeleteEntity(id));
                return Ok(dataResult);
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
