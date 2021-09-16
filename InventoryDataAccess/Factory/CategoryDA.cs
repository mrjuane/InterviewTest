using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccess.Factory
{
    public sealed class CategoryDA : IInventoryDA<Category>
    {
        private InventoryEntities objentities = null;

        public CategoryDA()
        {
            objentities = new InventoryEntities();
        }

        public bool DeleteEntity(int id)
        {
            try
            {
                var data = objentities.Categories.FirstOrDefault(c => c.InstanceId == id);
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

        public IQueryable<Category> GetAllEntity()
        {
            try
            {
                return objentities.Categories.AsQueryable();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Category GetEntityById(int id)
        {
            try
            {
                var dataResult = objentities.Categories.FirstOrDefault(c => c.InstanceId == id);
                return dataResult ?? throw new Exception("Not Found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertEntity(Category entity)
        {
            try
            {
                objentities.Categories.Add(entity);
                objentities.SaveChanges();
                return entity.InstanceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEntity(Category entity)
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
