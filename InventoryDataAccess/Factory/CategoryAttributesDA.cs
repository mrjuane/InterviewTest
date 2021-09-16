using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Factory
{
    public sealed class CategoryAttributesDA : IInventoryDAExtended<CategoryAttribute>
    {
        private InventoryEntities objentities = null;

        public CategoryAttributesDA()
        {
            objentities = new InventoryEntities();
        }

        public bool DeleteEntity(int id, string key)
        {
            try
            {
                var data = objentities.CategoryAttributes.FirstOrDefault(c => c.InstanceId == id && c.Key.ToLower().Equals(key.Trim().ToLower()));
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

        public bool DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            objentities.Dispose();
            objentities = null;
            GC.SuppressFinalize(this);
        }

        public IQueryable<CategoryAttribute> GetAllEntity()
        {
            try
            {
                return objentities.CategoryAttributes.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoryAttribute GetEntityById(int id, string key)
        {
            try
            {
                var dataResult = objentities.CategoryAttributes.FirstOrDefault(c => c.InstanceId == id && c.Key.ToLower().Equals(key.Trim().ToLower()));

                return dataResult ?? throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoryAttribute GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertEntity(CategoryAttribute entity)
        {
            try
            {
                objentities.CategoryAttributes.Add(entity);
                objentities.SaveChanges();
                return entity.InstanceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEntity(CategoryAttribute entity)
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
