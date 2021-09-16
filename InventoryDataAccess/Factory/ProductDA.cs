using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Factory
{
    public sealed class ProductDA : IInventoryDA<Product>
    {
        private InventoryEntities objentities = null;

        public ProductDA()
        {
            objentities = new InventoryEntities();
        }

        public bool DeleteEntity(int id)
        {
            try
            {
                var data = objentities.Products.FirstOrDefault(c => c.InstanceId == id);
                if (data != null)
                {
                    objentities.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                    objentities.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            objentities.Dispose();
            objentities = null;
            GC.SuppressFinalize(this);
        }

        public IQueryable<Product> GetAllEntity()
        {
            try
            {
                return objentities.Products.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetEntityById(int id)
        {
            try
            {
                var dataResult = objentities.Products.FirstOrDefault(c => c.InstanceId == id);

                return dataResult ?? throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertEntity(Product entity)
        {
            try
            {
                objentities.Products.Add(entity);
                objentities.SaveChanges();
                return entity.InstanceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEntity(Product entity)
        {
            try
            {
                objentities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                objentities.SaveChanges();
                return entity.InstanceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
