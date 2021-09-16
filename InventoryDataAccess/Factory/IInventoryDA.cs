using System.Collections.Generic;
using System;
using System.Linq;

namespace InventoryDataAccess.Factory
{
    public interface IInventoryDA<T>: IDisposable
    {
        bool DeleteEntity(int id);
        IQueryable<T> GetAllEntity();
        T GetEntityById(int id);
        int InsertEntity(T entity);
        int UpdateEntity(T entity);
    }
}