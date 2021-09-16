using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Factory
{
    public sealed class ProductAttributesDA : IInventoryDAExtended<ProductAttribute>
    {
        private InventoryEntities objentities = null;

        public ProductAttributesDA()
        {
            objentities = new InventoryEntities();
        }

        public int InsertEntity(ProductAttribute entity)
        {
            try
            {
                objentities.ProductAttributes.Add(entity);
                objentities.SaveChanges();
                return entity.InstanceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEntity(ProductAttribute entity)
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

        public  bool DeleteEntity(int id, string key)
        {
            try
            {
                var data= objentities.ProductAttributes.FirstOrDefault(c => c.InstanceId == id && c.Key.ToLower().Equals(key.Trim().ToLower()));
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

        public IQueryable<ProductAttribute> GetAllEntity()
        {
            try
            {
                return objentities.ProductAttributes.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductAttribute GetEntityById(int id, string key)
        {
            try
            {
                var dataResult = objentities.ProductAttributes.FirstOrDefault(c => c.InstanceId == id && c.Key.ToLower().Equals(key.Trim().ToLower()));

                return dataResult ?? throw new Exception("Not Found");
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

        public bool DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public ProductAttribute GetEntityById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
